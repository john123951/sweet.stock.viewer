using DevComponents.DotNetBar;
using sweet.stock.core.Contract;
using sweet.stock.core.Entity;
using sweet.stock.core.Model;
using sweet.stock.utility.Extentions;
using sweet.stock.viewer.Extentions;
using System;
using System.Collections;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timer = System.Timers.Timer;

namespace sweet.stock.viewer.Forms
{
    public partial class MainForm : OfficeForm
    {
        private readonly IStockService _stockService;
        private readonly ConfigInfo _configInfo;

        public MainForm()
        {
            InitializeComponent();
        }

        public MainForm(IStockService stockService)
            : this()
        {
            _stockService = stockService;
            _configInfo = _stockService.GetConfigEntity();

            ModifyComponent();
            InitializeEvent();
            InitStockData();
        }

        private void InitializeEvent()
        {
            //绑定风格选择框
            cb_themeStyle.Items.AddRange(ArrayList.Adapter(Enum.GetValues(typeof(eStyle))).ToArray());
            cb_themeStyle.SelectedIndexChanged += (sender, e) =>
            {
                var theme = (eStyle)cb_themeStyle.SelectedItem;
                styleManager1.ManagerStyle = theme;
            };

            //绑定右键菜单
            contextMenuBar.SetContextMenuEx(lv_stockInfo, bi_stockList_right);

            //右键上下文菜单事件
            rightContext_btnInsert.Click += (sender, e) => { bar2.Hide(); bar2.Show(); };
            rightContext_btnDelete.Click += (sender, e) =>
            {
                foreach (ListViewItem selectedItem in lv_stockInfo.SelectedItems)
                {
                    var stockInfo = selectedItem.Tag as StockInfo;
                    if (stockInfo != null)
                    {
                        _stockService.RemoveStockInfo(stockInfo.StockId);
                    }
                }
                InitStockData();
            };
            rightContext_btnOpenSina.Click += (sender, e) =>
            {
                foreach (ListViewItem selectedItem in lv_stockInfo.SelectedItems)
                {
                    var stockInfo = selectedItem.Tag as StockInfo;
                    if (stockInfo != null)
                    {
                        Process.Start(string.Format("http://finance.sina.com.cn/realstock/company/{0}/nc.shtml", stockInfo.StockId));
                    }
                }
            };

            int inputVersion = 1;
            //智能补全
            tb_stockId.KeyUp += (sender, e) =>
            {
                int currentVersion = Interlocked.Increment(ref inputVersion);

                var control = tb_stockId;
                string input = control.Text.Trim();

                Task.Factory.StartNew(() =>
                {
                    var dataList = _stockService.Suggest(input);

                    if (currentVersion == inputVersion)
                    {
                        control.Invoke(new Action(() => { control.DataSource = dataList; }));
                    }
                });
            };

            tb_stockId.AutoCompeleControl.Click += (sender, e) =>
            {
                var item = tb_stockId.AutoCompeleControl.SelectedItems[0];
                if (item != null)
                {
                    var suggestInfo = item.Tag as SuggestInfo;
                    if (suggestInfo != null)
                    {
                        tb_stockId.Text = suggestInfo.StockCode;
                    }
                }
            };

            //绑定显示列
            var attributes = _configInfo.ShowHeaderSetting;

            lb_property.DataSource = attributes;
            lb_property.DisplayMember = "Description";
            lb_property.CheckStateMember = "IsShow";
            lb_property.ValueMember = "IsShow";
            lb_property.SelectedIndexChanged += (sender, e) =>
                {
                    if (lb_property.SelectedIndex > 0)
                        lb_property.SetItemCheckState(lb_property.SelectedIndex, CheckState.Checked);
                };
            lb_property.ItemCheck += (sender, e) =>
                {
                    var attr = ((ShowDescriptionEntity)((ItemBindingData)e.Item.Tag).DataItem);

                    attr.IsShow = e.Item.CheckState == CheckState.Checked;
                    InitStockData();
                };

            //插入新股票

            Action<object, EventArgs> action = (sender, e) =>
            {
                var selectedItems = tb_stockId.AutoCompeleControl.SelectedItems;

                if (selectedItems.Count <= 0 && tb_stockId.AutoCompeleControl.Items.Count > 0)
                {
                    tb_stockId.AutoCompeleControl.Items[0].Selected = true;
                }

                if (selectedItems != null && selectedItems.Count == 1)
                {
                    var suggestInfo = (SuggestInfo)selectedItems[0].Tag;

                    _stockService.InsertStockInfo(new StockEntity() { StockId = suggestInfo.StockId });
                    InitStockData();
                }
            };

            btn_insertStock.Click += new EventHandler(action);
            tb_stockId.AutoCompeleControl.DoubleClick += new EventHandler(action);

            //退出时保存设置
            this.Closed += (sender, e) => _stockService.SaveConfigEntity(_configInfo);
        }

        private Timer _timer = null;

        private void InitStockData()
        {
            lv_stockInfo.Clear();
            if (lv_stockInfo.Columns.Count <= 0)
            {
                lv_stockInfo.Columns.Add("", lv_stockInfo.Width);
                lv_stockInfo.Items.Add("正在加载......");
            }
            if (_timer != null)
            {
                _timer.Stop();
                _timer.Dispose();
                _timer = null;
            }

            //加载数据
            Task.Factory.StartNew(() =>
            {
                var stockList = _stockService.InitAllStockInfos();

                this.Invoke(new Action(() => lv_stockInfo.Clear()));

                if (stockList.IsNotEmpty())
                {
                    var propNames = _configInfo.ShowHeaderSetting
                                               .Where(x => x.IsShow)
                                               .Select(x => x.PropertyName)
                                               .ToList();

                    this.Invoke(new Action(() => lv_stockInfo.ViewList(stockList, propNames)));

                    _timer = new Timer();
                    _timer.Elapsed += (sender, e) => ModifyStockData();
                    _timer.Interval = 500;
                    _timer.Start();
                }
                else
                {
                    this.Invoke(new Action(() =>
                    {
                        lv_stockInfo.Columns.Add("", lv_stockInfo.Width);
                        lv_stockInfo.Items.Add("请在下方“数据”中添加自选股");
                    }));
                }
            });
        }

        private void ModifyStockData()
        {
            var stockList = _stockService.UpdateAllStockInfos();

            var propNames = _configInfo.ShowHeaderSetting
                                       .Where(x => x.IsShow)
                                       .Select(x => x.PropertyName)
                                       .ToList();

            //修改显示颜色
            this.Invoke(new Action(() => lv_stockInfo.ModifyList(stockList, propNames,
                (model, item) =>
                {
                    if (model.PresentPrice > model.ClosingPrice)
                    {
                        item.ModifyColor(Color.Red);
                    }
                    else if (model.PresentPrice < model.ClosingPrice)
                    {
                        item.ModifyColor(Color.Green);
                    }
                    else
                    {
                        item.ModifyColor(Color.Black);
                    }
                })));
        }
    }
}
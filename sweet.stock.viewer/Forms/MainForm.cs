using DevComponents.DotNetBar;
using sweet.stock.core.Contract;
using sweet.stock.core.Entity;
using sweet.stock.core.Model;
using sweet.stock.utility.Extentions;
using sweet.stock.viewer.Extentions;
using System;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timer = System.Timers.Timer;

namespace sweet.stock.viewer.Forms
{
    public partial class MainForm : OfficeForm
    {
        private readonly IStockService _stockService;

        public MainForm()
        {
            InitializeComponent();
            ModifyComponent();
            InitializeEvent();
        }

        public MainForm(IStockService stockService)
            : this()
        {
            _stockService = stockService;

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
                        _stockService.RemoveStockInfo(stockInfo.StockCode);
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

            //智能补全
            tb_stockId.KeyUp += (sender, e) =>
            {
                var control = tb_stockId;
                string input = control.Text.Trim();

                Task.Factory.StartNew(() =>
                {
                    var dataList = _stockService.Suggest(input);

                    control.Invoke(new Action(() => { control.DataSource = dataList; }));
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
            var props = typeof(StockInfo).GetProperties()
                                         .Select(x => x.GetCustomAttributes(typeof(DescriptionAttribute), false).FirstOrDefault() as DescriptionAttribute)
                                         .Where(x => x != null)
                                         .Distinct()
                                         .ToList();

            foreach (var propertyInfo in props)
            {
                lb_property.Items.Add(propertyInfo.Description);
            }

            //插入新股票
            Action<object, EventArgs> a = (sender, e) =>
            {
                _stockService.InsertStockInfo(new StockEntity() { StockCode = tb_stockId.Text.Trim() });
                InitStockData();
            };

            btn_insertStock.Click += new EventHandler(a);
            tb_stockId.AutoCompeleControl.DoubleClick += new EventHandler(a);
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

            //加载数据
            Task.Factory.StartNew(() =>
            {
                var stockList = _stockService.InitAllStockInfos();

                this.Invoke(new Action(() => lv_stockInfo.Clear()));

                if (stockList.IsNotEmpty())
                {
                    this.Invoke(new Action(() => lv_stockInfo.ViewList(stockList)));

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

            //修改显示颜色
            this.Invoke(new Action(() => lv_stockInfo.ModifyList(stockList, (model, item) =>
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
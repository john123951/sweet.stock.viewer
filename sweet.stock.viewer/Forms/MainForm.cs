using DevComponents.DotNetBar;
using sweet.stock.core.Contract;
using sweet.stock.core.Model;
using sweet.stock.viewer.Extentions;
using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Timers;

namespace sweet.stock.viewer.Forms
{
    public partial class MainForm : Office2007Form
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
            //绑定右键菜单
            contextMenuBar.SetContextMenuEx(lv_stockInfo, bi_stockList_right);

            //右键上下文菜单事件
            rightContext_btnInsert.Click += (sender, e) => { bar2.Hide(); bar2.Show(); };

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
        }

        private System.Timers.Timer _timer = null;

        private void InitStockData()
        {
            lv_stockInfo.Columns.Add("", lv_stockInfo.Width);
            lv_stockInfo.Items.Add("正在加载......");

            //加载数据
            Task.Factory.StartNew(() =>
            {
                var stockList = _stockService.InitAllStockInfos();
                this.Invoke(new Action(() => lv_stockInfo.ViewList(stockList)));

                _timer = new Timer();
                _timer.Elapsed += (sender, e) => ModifyStockData();
                _timer.Interval = 500;
                _timer.Start();
            });
        }

        private void ModifyStockData()
        {
            var stockList = _stockService.UpdateAllStockInfos();

            //修改显示颜色
            this.Invoke(new Action(() => lv_stockInfo.ModifyList(stockList, (model, item) =>
            {
                if ((model.PresentPrice / model.ClosingPrice) > 1)
                {
                    item.ModifyColor(Color.Red);
                }
                else if ((model.PresentPrice / model.ClosingPrice) < 1)
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
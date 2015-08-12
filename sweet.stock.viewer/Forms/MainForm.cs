using DevComponents.DotNetBar;
using sweet.stock.core.Contract;
using sweet.stock.viewer.Extentions;
using System;
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
        }

        private void InitStockData()
        {
            Task.Factory.StartNew(() =>
            {
                var stockList = _stockService.InitAllStockInfos();
                this.Invoke(new Action(() => lv_stockInfo.ViewList(stockList)));
            });

            timer.Elapsed += (sender, e) => ModifyStockData();
            timer.Interval = 500;
            timer.Start();
        }

        private System.Timers.Timer timer = new Timer();

        private void ModifyStockData()
        {
            var stockList = _stockService.UpdateAllStockInfos();
            this.Invoke(new Action(() => lv_stockInfo.ModifyList(stockList)));
        }
    }
}
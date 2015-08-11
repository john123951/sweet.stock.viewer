using System.Collections.Generic;
using DevComponents.DotNetBar;
using sweet.stock.core.Contract;
using sweet.stock.core.Model;
using sweet.stock.viewer.Extentions;

namespace sweet.stock.viewer.Forms
{
    public partial class MainForm : Office2007Form
    {
        private readonly IStockReader _stockReader;

        public MainForm()
        {
            InitializeComponent();
            ModifyComponent();
            InitializeEvent();
        }

        public MainForm(IStockReader stockReader)
            : this()
        {
            _stockReader = stockReader;
            InitStockData();
        }

        private void InitStockData()
        {
            var stockList = new List<StockInfo>
            {
                new StockInfo {StockId = "ss", OpeningPrice = 11m, PresentPrice = 22m},
                new StockInfo {StockId = "tt", OpeningPrice = 12m, PresentPrice = 20m},
            };
            lv_stockInfo.ViewList(stockList);
        }

        private void ModifyStockData()
        {
        }
    }
}
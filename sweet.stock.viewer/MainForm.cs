using DevComponents.DotNetBar;
using sweet.stock.core.Model;
using sweet.stock.viewer.Extentions;
using System.Collections.Generic;

namespace sweet.stock.viewer
{
    public partial class MainForm : Office2007Form
    {
        public MainForm()
        {
            InitializeComponent();
            ModifyComponent();
            InitializeEvent();

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
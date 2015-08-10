using DevComponents.DotNetBar;
using sweet.stock.model;
using System.Collections.Generic;
using System.Windows.Forms;
using sweet.stock.viewer.Extentions;

namespace sweet.stock.viewer
{
    public partial class MainForm2 : Office2007Form
    {
        public MainForm2()
        {
            InitializeComponent();
            ModifyComponent();
            InitStockData();
        }

        private void InitStockData()
        {
            var stockList = new List<StockInfo>
            {
                new StockInfo {StockId = "ss", OpeningPrice = 11m, PresentPrice = 22m},
                new StockInfo {StockId = "tt", OpeningPrice = 12m, PresentPrice = 20m},
            };
            
            listViewEx1.ViewList(stockList);
        }
    }
}
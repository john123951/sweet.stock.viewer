using System.ComponentModel;

namespace sweet.stock.model
{
    public class StockInfo
    {
        [Description("股票代码")]
        public string StockId { get; set; }

        [Description("股票名字")]
        public string StockName { get; set; }

        [Description("开盘价")]
        public decimal OpeningPrice { get; set; }

        [Description("当前价格")]
        public decimal PresentPrice { get; set; }
    }
}
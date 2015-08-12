using System.ComponentModel;

namespace sweet.stock.core.Model
{
    /// <summary>
    /// 股票信息
    /// </summary>
    public class StockInfo
    {
        public string StockId { get; set; }

        [Description("股票代码")]
        public string StockCode { get; set; }

        [Description("股票名字")]
        public string StockName { get; set; }

        [Description("今日开盘价")]
        public decimal OpeningPrice { get; set; }

        [Description("昨日收盘价")]
        public decimal ClosingPrice { get; set; }

        [Description("当前价格")]
        public decimal PresentPrice { get; set; }

        [Description("今日最高价")]
        public decimal HighestPrice { get; set; }

        [Description("今日最低价")]
        public decimal LowestPrice { get; set; }

        [Description("今日涨幅")]
        public string Increase { get { return ((PresentPrice / ClosingPrice - 1) * 1).ToString("+0.00%;-0.00%;0%"); } }
    }
}
using sweet.stock.core.Attribute;
using System;

namespace sweet.stock.core.Model
{
    public class MyFormatProvider : IFormatProvider, ICustomFormatter
    {
        public object GetFormat(Type formatType)
        {
            if (formatType == typeof(ICustomFormatter))
                return this;
            else
                return null;
        }

        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            // Convert argument to a string
            string result = arg.ToString() + "test";

            return result;
        }
    }

    /// <summary>
    /// 股票信息
    /// </summary>
    public class StockInfo
    {
        public string StockId { get; set; }

        [ShowDescription("股票代码", IsShow = true)]
        public string StockCode { get; set; }

        [ShowDescription("股票名字", IsShow = true)]
        public string StockName { get; set; }

        [ShowDescription("今日开盘价")]
        public decimal OpeningPrice { get; set; }

        [ShowDescription("昨日收盘价")]
        public decimal ClosingPrice { get; set; }

        [ShowDescription("当前价格")]
        public decimal PresentPrice { get; set; }

        [ShowDescription("今日最高价")]
        public decimal HighestPrice { get; set; }

        [ShowDescription("今日最低价")]
        public decimal LowestPrice { get; set; }

        public double TradingQuantity { get; set; }

        [ShowDescription("成交量(万手)")]
        public string TradingQuantityShow
        {
            get { return (TradingQuantity / 100 / 10000).ToString("F2"); }
        }

        public decimal TradingAmount { get; set; }

        [ShowDescription("成交额(万元)")]
        public string TradingAmountShow
        {
            get { return (TradingAmount / 10000).ToString("F2"); }
        }

        [ShowDescription("今日涨幅", IsShow = true)]
        public string Increase { get { return ((PresentPrice / Math.Max(0.01m, ClosingPrice) - 1) * 1).ToString("+0.00%;-0.00%;0%"); } }
    }
}
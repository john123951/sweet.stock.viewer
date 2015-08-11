using System.ComponentModel;

namespace sweet.stock.core.Model
{
    /// <summary>
    /// 提示信息
    /// </summary>
    public class SuggestInfo
    {
        public string StockId { get; set; }

        [Description("股票代码")]
        public string StockCode { get; set; }

        [Description("股票名字")]
        public string StockName { get; set; }
    }
}
using sweet.stock.core.Attribute;

namespace sweet.stock.core.Model
{
    /// <summary>
    /// 提示信息
    /// </summary>
    public class SuggestInfo
    {
        public string StockId { get; set; }

        [ShowDescription("股票代码", IsShow = true)]
        public string StockCode { get; set; }

        [ShowDescription("股票名字", IsShow = true)]
        public string StockName { get; set; }
    }
}
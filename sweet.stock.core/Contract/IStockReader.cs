using sweet.stock.core.Model;
using System.Collections.Generic;

namespace sweet.stock.core.Contract
{
    public interface IStockReader
    {
        /// <summary>
        /// 补全提示
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        List<SuggestInfo> Suggest(string input);

        /// <summary>
        /// 获取投票行情
        /// </summary>
        /// <param name="stockIds"></param>
        /// <returns></returns>
        List<StockInfo> MarketPrice(string[] stockIds);
    }
}
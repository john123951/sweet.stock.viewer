using sweet.stock.core.Entity;
using sweet.stock.core.Model;
using System.Collections.Generic;

namespace sweet.stock.core.Contract
{
    public interface IStockService
    {
        /// <summary>
        /// 获取股票信息
        /// </summary>
        /// <returns></returns>
        List<StockInfo> InitAllStockInfos();

        /// <summary>
        /// 获取股票最新行情
        /// </summary>
        /// <returns></returns>
        List<StockInfo> UpdateAllStockInfos();

        /// <summary>
        /// 补全提示
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        List<SuggestInfo> Suggest(string input);

        /// <summary>
        /// 插入一个新股票
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        bool InsertStockInfo(StockEntity entity);
    }
}
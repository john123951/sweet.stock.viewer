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

        /// <summary>
        /// 移除一个股票
        /// </summary>
        /// <param name="stockId"></param>
        /// <returns></returns>
        bool RemoveStockInfo(string stockId);

        /// <summary>
        /// 获取配置信息
        /// </summary>
        /// <returns></returns>
        ConfigInfo GetConfigEntity();

        /// <summary>
        /// 保存配置
        /// </summary>
        /// <param name="configInfo"></param>
        /// <returns></returns>
        bool SaveConfigEntity(ConfigInfo configInfo);
    }
}
using sweet.stock.core.Entity;
using System.Collections.Generic;

namespace sweet.stock.core.Contract
{
    public interface IStockRepository
    {
        /// <summary>
        /// 获取保存的股票信息
        /// </summary>
        /// <returns></returns>
        List<StockEntity> GetStoreEntities();

        /// <summary>
        /// 保存股票信息
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        bool SaveEntities(List<StockEntity> entities);
    }
}
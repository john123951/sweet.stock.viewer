using sweet.stock.core.Contract;
using sweet.stock.core.Entity;
using sweet.stock.core.Model;
using sweet.stock.utility.Extentions;
using System.Collections.Generic;

namespace sweet.stock.service.Proxy
{
    public class StockServiceCached : IStockService
    {
        private readonly IStockService _target;
        private readonly ICacheProvider _cacheProvider;

        public StockServiceCached(IStockService stockService, ICacheProvider cacheProvider)
        {
            _target = stockService;
            _cacheProvider = cacheProvider;
        }

        public List<StockInfo> InitAllStockInfos()
        {
            return _target.InitAllStockInfos();
        }

        public List<StockInfo> UpdateAllStockInfos()
        {
            return _target.UpdateAllStockInfos();
        }

        public List<SuggestInfo> Suggest(string input)
        {
            string cacheKey = "IStockService.Suggest." + input;
            var cacheData = _cacheProvider.Get<List<SuggestInfo>>(cacheKey);

            if (!cacheData.IsNotEmpty())
            {
                cacheData = _target.Suggest(input);
                _cacheProvider.Set(cacheKey, cacheData);
            }

            return cacheData;
        }

        public bool InsertStockInfo(StockEntity entity)
        {
            return _target.InsertStockInfo(entity);
        }

        public bool RemoveStockInfo(string stockId)
        {
            return _target.RemoveStockInfo(stockId);
        }

        public ConfigInfo GetConfigEntity()
        {
            return _target.GetConfigEntity();
        }

        public bool SaveConfigEntity(ConfigInfo configInfo)
        {
            return _target.SaveConfigEntity(configInfo);
        }
    }
}
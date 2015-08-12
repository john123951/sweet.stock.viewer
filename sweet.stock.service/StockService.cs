using sweet.stock.core.Contract;
using sweet.stock.core.Entity;
using sweet.stock.core.Model;
using sweet.stock.utility.Extentions;
using System.Collections.Generic;
using System.Linq;

namespace sweet.stock.service
{
    public class StockService : IStockService
    {
        private readonly IStockReader _stockReader;
        private readonly IStockRepository _stockRepository;
        private readonly ISettingRepository _settingRepository;

        private string[] _stockIds;

        public StockService(IStockReader stockReader, IStockRepository stockRepository, ISettingRepository settingRepository)
        {
            _stockReader = stockReader;
            _stockRepository = stockRepository;
            _settingRepository = settingRepository;
        }

        public List<StockInfo> InitAllStockInfos()
        {
            var entities = _stockRepository.GetStoreEntities();

            //根据保存的code，搜索股票
            var stockId = entities.AsParallel()
                                  .Select(stockEntity =>
                                  {
                                      var suggestInfo = _stockReader.Suggest(stockEntity.StockCode).FirstOrDefault();

                                      return suggestInfo != null ? suggestInfo.StockId : string.Empty;
                                  })
                                  .Where(x => !string.IsNullOrEmpty(x))
                                  .ToArray();

            if (stockId.IsNotEmpty())
            {
                _stockIds = stockId;
            }

            return UpdateAllStockInfos();
        }

        public List<StockInfo> UpdateAllStockInfos()
        {
            if (_stockIds == null || _stockIds.Length <= 0)
            {
                return new List<StockInfo>();
            }

            var result = _stockReader.MarketPrice(_stockIds);

            return result;
        }

        public List<SuggestInfo> Suggest(string input)
        {
            if (string.IsNullOrEmpty(input)) { return new List<SuggestInfo>(); }

            return _stockReader.Suggest(input);
        }

        public bool InsertStockInfo(StockEntity entity)
        {
            if (entity == null)
            {
                return false;
            }

            var entites = _stockRepository.GetStoreEntities();

            entites.Add(entity);

            return _stockRepository.SaveEntities(entites);
        }
    }
}
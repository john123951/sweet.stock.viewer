using sweet.stock.core.Attributes;
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

            if (entites.Exists(x => System.String.Compare(x.StockCode.Trim(), entity.StockCode.Trim(), System.StringComparison.OrdinalIgnoreCase) == 0))
            {
                return false;
            }

            entites.Add(entity);

            return _stockRepository.SaveEntities(entites);
        }

        public bool RemoveStockInfo(string stockCode)
        {
            var entites = _stockRepository.GetStoreEntities();

            var entity = entites.FirstOrDefault(x => System.String.Compare(x.StockCode, stockCode, System.StringComparison.OrdinalIgnoreCase) == 0);

            if (entity != null)
            {
                entites.Remove(entity);

                return _stockRepository.SaveEntities(entites);
            }
            return false;
        }

        public ConfigInfo GetConfigEntity()
        {
            var configInfo = _settingRepository.GetConfigEntity();

            if (configInfo == null)
            {
                configInfo = new ConfigInfo()
               {
                   ShowHeaderSetting = typeof(StockInfo).GetProperties()
                                                             .Select(propertyInfo =>
                                                             {
                                                                 var showDescriptionAttribute = propertyInfo.GetCustomAttributes(typeof(ShowDescriptionAttribute), false).FirstOrDefault() as ShowDescriptionAttribute;
                                                                 if (showDescriptionAttribute != null)
                                                                 {
                                                                     return new ShowDescriptionEntity
                                                                     {
                                                                         IsShow = showDescriptionAttribute.IsShow,
                                                                         Description = showDescriptionAttribute.Description,
                                                                         PropertyName = propertyInfo.Name
                                                                     };
                                                                 }
                                                                 return null;
                                                             })
                                                             .Where(x => x != null)
                                                             .ToList(),

                   WindowWidth = 605,
                   WindowHeight = 190,
                   WindowOpacity = 100,
               };

                _settingRepository.SaveConfigEntity(configInfo);
            }

            return configInfo;
        }

        public bool SaveConfigEntity(ConfigInfo configInfo)
        {
            if (configInfo == null) { return false; }

            return _settingRepository.SaveConfigEntity(configInfo);
        }
    }
}
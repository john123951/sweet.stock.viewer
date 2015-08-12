using sweet.stock.core.Contract;
using sweet.stock.core.Entity;
using System.Collections.Generic;

namespace sweet.stock.repository
{
    public class XmlStockRepository : IStockRepository
    {
        private List<StockEntity> _db = new List<StockEntity>()
        {
                new StockEntity(){ StockCode = "002017", StockName = "东信和平"},
                new StockEntity(){ StockCode = "300021", StockName = "东信和平"},
                new StockEntity(){ StockCode = "600839", StockName = "东信和平"},
                new StockEntity(){ StockCode = "601933", StockName = "东信和平"},
                new StockEntity(){ StockCode = "600343", StockName = "东信和平"},
                new StockEntity(){ StockCode = "601989", StockName = "东信和平"},
        };

        public List<StockEntity> GetStoreEntities()
        {
            return _db;
        }

        public bool SaveEntities(List<StockEntity> entities)
        {
            _db = entities;

            return true;
        }
    }
}
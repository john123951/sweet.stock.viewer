using sweet.stock.core.Contract;
using sweet.stock.core.Entity;
using sweet.stock.utility.Serialization;
using System.Collections.Generic;
using System.IO;

namespace sweet.stock.repository
{
    public class XmlStockRepository : IStockRepository
    {
        private List<StockEntity> _db = new List<StockEntity>();

        private const string FilePath = "db/stockEntity.db";

        public List<StockEntity> GetStoreEntities()
        {
            string dirPath = Path.GetDirectoryName(FilePath);

            if (!string.IsNullOrEmpty(dirPath) && !Directory.Exists(dirPath)) { Directory.CreateDirectory(dirPath); }

            if (!File.Exists(FilePath))
            {
                var doc = XmlUtility.Serialize(new List<StockEntity>());
                File.WriteAllText(FilePath, doc);
            }

            string fileDoc = File.ReadAllText(FilePath);

            _db = XmlUtility.Deserialize<List<StockEntity>>(fileDoc);

            return _db;
        }

        public bool SaveEntities(List<StockEntity> entities)
        {
            _db = entities;

            var doc = XmlUtility.Serialize(_db);
            File.WriteAllText(FilePath, doc);
            return true;
        }
    }
}
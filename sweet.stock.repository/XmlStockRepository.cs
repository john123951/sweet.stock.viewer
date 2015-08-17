using sweet.stock.core.Contract;
using sweet.stock.core.Entity;
using sweet.stock.utility.Extentions;
using sweet.stock.utility.Serialization;
using System.Collections.Generic;
using System.IO;

namespace sweet.stock.repository
{
    public class XmlStockRepository : IStockRepository
    {
        private List<StockEntity> _db = null;

        private const string FilePath = "App_Data/stockEntity.db";

        public List<StockEntity> GetStoreEntities()
        {
            if (_db.IsNotEmpty())
            {
                return _db;
            }

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
            var doc = XmlUtility.Serialize(_db);
            File.WriteAllText(FilePath, doc);

            _db = entities;
            return true;
        }
    }
}
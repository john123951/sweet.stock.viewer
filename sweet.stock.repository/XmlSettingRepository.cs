using sweet.stock.core.Contract;
using sweet.stock.core.Model;
using sweet.stock.utility.Serialization;
using System.IO;

namespace sweet.stock.repository
{
    public class XmlSettingRepository : ISettingRepository
    {
        private const string FilePath = "db/configEntity.db";

        private static ConfigInfo _cache = null;

        public ConfigInfo GetConfigEntity()
        {
            if (_cache != null) { return _cache; }

            string dirPath = Path.GetDirectoryName(FilePath);

            if (!string.IsNullOrEmpty(dirPath) && !Directory.Exists(dirPath)) { Directory.CreateDirectory(dirPath); }

            if (!File.Exists(FilePath))
            {
                return null;
            }

            string fileDoc = File.ReadAllText(FilePath);

            var result = XmlUtility.Deserialize<ConfigInfo>(fileDoc);

            _cache = result;
            return result;
        }

        public bool SaveConfigEntity(ConfigInfo entity)
        {
            var doc = XmlUtility.Serialize(entity);
            File.WriteAllText(FilePath, doc);

            _cache = null;
            return true;
        }
    }
}
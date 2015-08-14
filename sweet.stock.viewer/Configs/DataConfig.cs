using sweet.stock.core.Attribute;
using sweet.stock.core.Model;
using System.Collections.Generic;
using System.Linq;

namespace sweet.stock.viewer.Configs
{
    internal class DataConfig
    {
        private DataConfig()
        {
            this.ShowHeaderSetting = typeof(StockInfo).GetProperties()
                                                      .Select(x => x.GetCustomAttributes(typeof(ShowDescriptionAttribute), false)
                                                                    .FirstOrDefault() as ShowDescriptionAttribute)
                                                      .Where(x => x != null)
                                                      .Distinct()
                                                      .ToList();
        }

        private static DataConfig _instance = null;

        public static DataConfig GetInstance()
        {
            if (_instance == null)
            {
                _instance = new DataConfig();
            }
            return _instance;
        }

        public List<ShowDescriptionAttribute> ShowHeaderSetting { get; set; }
    }
}
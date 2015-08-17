using sweet.stock.core.Model;

namespace sweet.stock.core.Contract
{
    public interface ISettingRepository
    {
        ConfigInfo GetConfigEntity();

        bool SaveConfigEntity(ConfigInfo entity);
    }
}
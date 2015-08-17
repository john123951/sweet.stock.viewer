using sweet.stock.core.Entity;
using System.Collections.Generic;

namespace sweet.stock.core.Model
{
    public class ConfigInfo
    {
        /// <summary>
        /// 显示列
        /// </summary>
        public List<ShowDescriptionEntity> ShowHeaderSetting { get; set; }

        /// <summary>
        /// 透明度
        /// </summary>
        public int WindowOpacity { get; set; }

        /// <summary>
        /// 窗口高度
        /// </summary>
        public int WindowHeight { get; set; }

        /// <summary>
        /// 窗口宽度
        /// </summary>
        public int WindowWidth { get; set; }

        /// <summary>
        /// 窗口最前
        /// </summary>
        public bool WindowTop { get; set; }
    }
}
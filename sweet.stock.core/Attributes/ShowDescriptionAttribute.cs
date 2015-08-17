using System.ComponentModel;

namespace sweet.stock.core.Attributes
{
    public class ShowDescriptionAttribute : DescriptionAttribute
    {
        public bool IsShow { get; set; }

        public ShowDescriptionAttribute()
        {
        }

        public ShowDescriptionAttribute(string description)
            : base(description)
        {
        }
    }
}
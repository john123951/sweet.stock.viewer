using System.ComponentModel;

namespace sweet.stock.core.Attribute
{
    public class ShowDescriptionAttribute : DescriptionAttribute
    {
        public bool IsShow { get; set; }

        public ShowDescriptionAttribute(string description)
            : base(description)
        {
        }
    }
}
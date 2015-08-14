using DevComponents.DotNetBar;
using System.Windows.Forms;

namespace sweet.stock.viewer.UserControls
{
    public class ListBoxCheckBoxItem : ListBoxItem
    {
        public bool Checked
        {
            get { return this.CheckState == CheckState.Checked; }
            set
            {
                this.CheckState = value ? CheckState.Checked : CheckState.Unchecked;
            }
        }
    }
}
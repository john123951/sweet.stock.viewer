using DevComponents.DotNetBar.Controls;
using sweet.stock.core.Model;
using sweet.stock.utility.Extentions;
using sweet.stock.viewer.Extentions;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace sweet.stock.viewer.UserControls
{
    public class AutoCompleteTextBoxX<T> : TextBoxX
        where T : Control, new()
    {
        public T AutoCompeleControl { get; private set; }

        public AutoCompleteTextBoxX()
        {
            AutoCompeleControl = new T();
            this.InitControl();
        }

        protected virtual void InitControl()
        {
            this.AutoCompeleControl.Font = this.Font;

            //获得焦点
            this.GotFocus += (sender, e) => { if (!string.IsNullOrEmpty(this.Text)) this.ShowList(); };

            //丢失焦点
            this.LostFocus += (sender, e) => CloseList();
            AutoCompeleControl.LostFocus += (sender, e) => CloseList();

            //调整宽度
            this.SizeChanged += (sender, e) => this.AutoCompeleControl.Width = this.Width;
        }

        protected void ShowList()
        {
            var form = this.FindForm();
            var screenPoint = this.Parent.PointToScreen(this.Location);
            var point = form.PointToClient(screenPoint);

            if (!form.Controls.Contains(AutoCompeleControl)) { form.Controls.Add(AutoCompeleControl); }

            //计算是否大于屏幕高度
            var high = screenPoint.Y + this.Size.Height + AutoCompeleControl.Height;

            if (high > Screen.PrimaryScreen.WorkingArea.Height)
            {
                AutoCompeleControl.Location = new Point(point.X, point.Y - AutoCompeleControl.Height);
            }
            else
            {
                AutoCompeleControl.Location = new Point(point.X, point.Y + this.Size.Height);
            }

            AutoCompeleControl.BringToFront();
        }

        protected void CloseList()
        {
            var form = this.FindForm();
            if (!this.Focused && !AutoCompeleControl.Focused && form != null)
            {
                form.Controls.Remove(AutoCompeleControl);
            }
        }
    }

    public class AutoCompleteTextBoxXListView : AutoCompleteTextBoxX<ListViewEx>
    {
        private ICollection<SuggestInfo> _dataSource;

        public ICollection<SuggestInfo> DataSource
        {
            get { return _dataSource; }
            set
            {
                var listViewEx = AutoCompeleControl as ListView;
                if (listViewEx != null && value.IsNotEmpty())
                {
                    listViewEx.ViewList(value); ShowList();
                }
                _dataSource = value;
            }
        }

        public AutoCompleteTextBoxXListView()
            : base()
        {
            AutoCompeleControl.View = View.Details;
            AutoCompeleControl.FullRowSelect = true;
        }

        protected override void InitControl()
        {
            base.InitControl();
            AutoCompeleControl.Click += (sender, e) =>
            {
                var item = AutoCompeleControl.SelectedItems[0];
                if (item != null)
                {
                    this.Text = item.SubItems[1].Text;
                }
            };
        }
    }
}
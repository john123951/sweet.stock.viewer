using DevComponents.DotNetBar.Controls;
using sweet.stock.core.Model;
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

            form.Controls.Add(AutoCompeleControl);

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
            if (!this.Focused && !AutoCompeleControl.Focused)
            {
                this.FindForm().Controls.Remove(AutoCompeleControl);
            }
        }
    }

    public class AutoCompleteTextBoxXListView : AutoCompleteTextBoxX<ListViewEx>
    {
        public ICollection<SuggestInfo> DataSource { get; set; }

        public AutoCompleteTextBoxXListView()
            : base()
        {
            AutoCompeleControl.View = View.Details;
            AutoCompeleControl.FullRowSelect = true;
        }

        protected override void InitControl()
        {
            base.InitControl();
            AutoCompeleControl.DoubleClick += (sender, e) =>
            {
                this.Text = AutoCompeleControl.SelectedItems[0].SubItems[1].Text;
            };
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            base.OnKeyUp(e);
            if (DataSource != null)
            {
                var listViewEx = AutoCompeleControl as ListView;

                if (listViewEx != null)
                {
                    //listViewEx.ViewList(DataSource, view => view.Columns.Add("操作"), (view, item) =>
                    //{
                    //    Button btn = new Button();
                    //    btn.Text = "...";
                    //    view.Controls.Add(btn);
                    //    //btn.Location = item.SubItems[2].Bounds.Height;
                    //    btn.Size = new Size(item.SubItems[2].Bounds.Width, item.SubItems[2].Bounds.Height);
                    //});
                }
                ShowList();
            }
        }
    }
}
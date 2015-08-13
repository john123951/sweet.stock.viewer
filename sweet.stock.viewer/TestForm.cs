using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;

namespace sweet.stock.viewer
{
    public partial class TestForm : DevComponents.DotNetBar.OfficeForm
    {
        public TestForm()
        {
            InitializeComponent();

            for (int i = 0; i < 30; i++)
            {
                flowLayoutPanel1.Controls.Add(new ButtonX());
                itemPanel1.AddItem("test");
                listBoxAdv1.Items.Add(i.ToString());

                listBoxAdv1.SelectedIndexChanged += listBoxAdv1_SelectedIndexChanged;
                //listBoxAdv1.Click += listBoxAdv1_SelectedIndexChanged;
            }
        }

        void listBoxAdv1_SelectedIndexChanged(object sender, EventArgs e)
        {

            foreach (var selectedIndex in listBoxAdv1.SelectedIndices)
            {
                listBoxAdv1.SetItemCheckState(selectedIndex, CheckState.Checked);
            }
        }
    }
}
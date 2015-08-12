using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using DevComponents.DotNetBar.Controls;
using EmitMapper;
using sweet.stock.core.Model;
using sweet.stock.viewer.UserControls;

namespace sweet.stock.viewer.Forms
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            DevComponents.DotNetBar.LabelX labelX2;
            this.dotNetBarManager1 = new DevComponents.DotNetBar.DotNetBarManager(this.components);
            this.dockSite4 = new DevComponents.DotNetBar.DockSite();
            this.bar1 = new DevComponents.DotNetBar.Bar();
            this.panelDockContainer1 = new DevComponents.DotNetBar.PanelDockContainer();
            this.contextMenuBar = new DevComponents.DotNetBar.ContextMenuBar();
            this.bi_stockList_right = new DevComponents.DotNetBar.ButtonItem();
            this.rightContext_btnInsert = new DevComponents.DotNetBar.ButtonItem();
            this.rightContext_btnDelete = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem2 = new DevComponents.DotNetBar.ButtonItem();
            this.s_opacity = new DevComponents.DotNetBar.Controls.Slider();
            this.sb_alwayTop = new DevComponents.DotNetBar.Controls.SwitchButton();
            this.dockContainerItem1 = new DevComponents.DotNetBar.DockContainerItem();
            this.bar2 = new DevComponents.DotNetBar.Bar();
            this.panelDockContainer2 = new DevComponents.DotNetBar.PanelDockContainer();
            this.tb_stockId = new sweet.stock.viewer.UserControls.AutoCompleteTextBoxXListView();
            this.dockContainerItem2 = new DevComponents.DotNetBar.DockContainerItem();
            this.dockSite1 = new DevComponents.DotNetBar.DockSite();
            this.dockSite2 = new DevComponents.DotNetBar.DockSite();
            this.dockSite8 = new DevComponents.DotNetBar.DockSite();
            this.dockSite5 = new DevComponents.DotNetBar.DockSite();
            this.dockSite6 = new DevComponents.DotNetBar.DockSite();
            this.dockSite7 = new DevComponents.DotNetBar.DockSite();
            this.dockSite3 = new DevComponents.DotNetBar.DockSite();
            this.lv_stockInfo = new DevComponents.DotNetBar.Controls.ListViewEx();
            labelX2 = new DevComponents.DotNetBar.LabelX();
            this.dockSite4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            this.bar1.SuspendLayout();
            this.panelDockContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.contextMenuBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bar2)).BeginInit();
            this.bar2.SuspendLayout();
            this.panelDockContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelX2
            // 
            labelX2.AutoSize = true;
            // 
            // 
            // 
            labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            labelX2.Location = new System.Drawing.Point(9, 10);
            labelX2.Name = "labelX2";
            labelX2.Size = new System.Drawing.Size(68, 18);
            labelX2.TabIndex = 1;
            labelX2.Text = "股票代码：";
            // 
            // dotNetBarManager1
            // 
            this.dotNetBarManager1.AutoDispatchShortcuts.Add(DevComponents.DotNetBar.eShortcut.F1);
            this.dotNetBarManager1.AutoDispatchShortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlC);
            this.dotNetBarManager1.AutoDispatchShortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlA);
            this.dotNetBarManager1.AutoDispatchShortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlV);
            this.dotNetBarManager1.AutoDispatchShortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlX);
            this.dotNetBarManager1.AutoDispatchShortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlZ);
            this.dotNetBarManager1.AutoDispatchShortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlY);
            this.dotNetBarManager1.AutoDispatchShortcuts.Add(DevComponents.DotNetBar.eShortcut.Del);
            this.dotNetBarManager1.AutoDispatchShortcuts.Add(DevComponents.DotNetBar.eShortcut.Ins);
            this.dotNetBarManager1.BottomDockSite = this.dockSite4;
            this.dotNetBarManager1.EnableFullSizeDock = false;
            this.dotNetBarManager1.LeftDockSite = this.dockSite1;
            this.dotNetBarManager1.ParentForm = this;
            this.dotNetBarManager1.RightDockSite = this.dockSite2;
            this.dotNetBarManager1.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.dotNetBarManager1.ToolbarBottomDockSite = this.dockSite8;
            this.dotNetBarManager1.ToolbarLeftDockSite = this.dockSite5;
            this.dotNetBarManager1.ToolbarRightDockSite = this.dockSite6;
            this.dotNetBarManager1.ToolbarTopDockSite = this.dockSite7;
            this.dotNetBarManager1.TopDockSite = this.dockSite3;
            // 
            // dockSite4
            // 
            this.dockSite4.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.dockSite4.Controls.Add(this.bar1);
            this.dockSite4.Controls.Add(this.bar2);
            this.dockSite4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dockSite4.DocumentDockContainer = new DevComponents.DotNetBar.DocumentDockContainer(new DevComponents.DotNetBar.DocumentBaseContainer[] {
            ((DevComponents.DotNetBar.DocumentBaseContainer)(new DevComponents.DotNetBar.DocumentBarContainer(this.bar1, 594, 92))),
            ((DevComponents.DotNetBar.DocumentBaseContainer)(new DevComponents.DotNetBar.DocumentBarContainer(this.bar2, 594, 140)))}, DevComponents.DotNetBar.eOrientation.Vertical);
            this.dockSite4.Location = new System.Drawing.Point(0, 48);
            this.dockSite4.Name = "dockSite4";
            this.dockSite4.Size = new System.Drawing.Size(594, 238);
            this.dockSite4.TabIndex = 3;
            this.dockSite4.TabStop = false;
            // 
            // bar1
            // 
            this.bar1.AccessibleDescription = "DotNetBar Bar (bar1)";
            this.bar1.AccessibleName = "DotNetBar Bar";
            this.bar1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.bar1.AutoHide = true;
            this.bar1.AutoSyncBarCaption = true;
            this.bar1.CloseSingleTab = true;
            this.bar1.Controls.Add(this.panelDockContainer1);
            this.bar1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bar1.GrabHandleStyle = DevComponents.DotNetBar.eGrabHandleStyle.Caption;
            this.bar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.dockContainerItem1});
            this.bar1.LayoutType = DevComponents.DotNetBar.eLayoutType.DockContainer;
            this.bar1.Location = new System.Drawing.Point(0, 3);
            this.bar1.Name = "bar1";
            this.bar1.Size = new System.Drawing.Size(594, 92);
            this.bar1.Stretch = true;
            this.bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.bar1.TabIndex = 0;
            this.bar1.TabStop = false;
            this.bar1.Text = "外观";
            // 
            // panelDockContainer1
            // 
            this.panelDockContainer1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.panelDockContainer1.Controls.Add(this.contextMenuBar);
            this.panelDockContainer1.Controls.Add(this.s_opacity);
            this.panelDockContainer1.Controls.Add(this.sb_alwayTop);
            this.panelDockContainer1.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelDockContainer1.Location = new System.Drawing.Point(3, 23);
            this.panelDockContainer1.Name = "panelDockContainer1";
            this.panelDockContainer1.Size = new System.Drawing.Size(588, 66);
            this.panelDockContainer1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelDockContainer1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.panelDockContainer1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.panelDockContainer1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.panelDockContainer1.Style.GradientAngle = 90;
            this.panelDockContainer1.TabIndex = 0;
            // 
            // contextMenuBar
            // 
            this.contextMenuBar.AntiAlias = true;
            this.contextMenuBar.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.contextMenuBar.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.bi_stockList_right,
            this.buttonItem2});
            this.contextMenuBar.Location = new System.Drawing.Point(349, 7);
            this.contextMenuBar.Name = "contextMenuBar";
            this.contextMenuBar.Size = new System.Drawing.Size(124, 51);
            this.contextMenuBar.Stretch = true;
            this.contextMenuBar.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.contextMenuBar.TabIndex = 9;
            this.contextMenuBar.TabStop = false;
            this.contextMenuBar.Text = "contextMenuBar1";
            // 
            // bi_stockList_right
            // 
            this.bi_stockList_right.AutoExpandOnClick = true;
            this.bi_stockList_right.Name = "bi_stockList_right";
            this.bi_stockList_right.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.rightContext_btnInsert,
            this.rightContext_btnDelete});
            this.bi_stockList_right.Text = "bi_stockList_right";
            // 
            // rightContext_btnInsert
            // 
            this.rightContext_btnInsert.Name = "rightContext_btnInsert";
            this.rightContext_btnInsert.Text = "新增(&I)";
            // 
            // rightContext_btnDelete
            // 
            this.rightContext_btnDelete.Name = "rightContext_btnDelete";
            this.rightContext_btnDelete.Text = "删除(&D)";
            // 
            // buttonItem2
            // 
            this.buttonItem2.AutoExpandOnClick = true;
            this.buttonItem2.Name = "buttonItem2";
            this.buttonItem2.Text = "buttonItem2";
            // 
            // s_opacity
            // 
            // 
            // 
            // 
            this.s_opacity.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.s_opacity.Location = new System.Drawing.Point(9, 35);
            this.s_opacity.Minimum = 20;
            this.s_opacity.Name = "s_opacity";
            this.s_opacity.Size = new System.Drawing.Size(150, 23);
            this.s_opacity.Step = 5;
            this.s_opacity.TabIndex = 1;
            this.s_opacity.TabStop = false;
            this.s_opacity.Text = "透明：";
            this.s_opacity.Value = 100;
            // 
            // sb_alwayTop
            // 
            // 
            // 
            // 
            this.sb_alwayTop.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.sb_alwayTop.Location = new System.Drawing.Point(9, 6);
            this.sb_alwayTop.Name = "sb_alwayTop";
            this.sb_alwayTop.OnText = "Top";
            this.sb_alwayTop.Size = new System.Drawing.Size(66, 22);
            this.sb_alwayTop.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.sb_alwayTop.TabIndex = 0;
            this.sb_alwayTop.TabStop = false;
            this.sb_alwayTop.Value = true;
            this.sb_alwayTop.ValueObject = "Y";
            // 
            // dockContainerItem1
            // 
            this.dockContainerItem1.Control = this.panelDockContainer1;
            this.dockContainerItem1.Name = "dockContainerItem1";
            this.dockContainerItem1.Text = "外观";
            // 
            // bar2
            // 
            this.bar2.AccessibleDescription = "DotNetBar Bar (bar2)";
            this.bar2.AccessibleName = "DotNetBar Bar";
            this.bar2.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.bar2.AutoHide = true;
            this.bar2.AutoSyncBarCaption = true;
            this.bar2.CloseSingleTab = true;
            this.bar2.Controls.Add(this.panelDockContainer2);
            this.bar2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bar2.GrabHandleStyle = DevComponents.DotNetBar.eGrabHandleStyle.Caption;
            this.bar2.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.dockContainerItem2});
            this.bar2.LayoutType = DevComponents.DotNetBar.eLayoutType.DockContainer;
            this.bar2.Location = new System.Drawing.Point(0, 98);
            this.bar2.Name = "bar2";
            this.bar2.Size = new System.Drawing.Size(594, 140);
            this.bar2.Stretch = true;
            this.bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.bar2.TabIndex = 1;
            this.bar2.TabStop = false;
            this.bar2.Text = "数据";
            // 
            // panelDockContainer2
            // 
            this.panelDockContainer2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.panelDockContainer2.Controls.Add(labelX2);
            this.panelDockContainer2.Controls.Add(this.tb_stockId);
            this.panelDockContainer2.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelDockContainer2.Location = new System.Drawing.Point(3, 23);
            this.panelDockContainer2.Name = "panelDockContainer2";
            this.panelDockContainer2.Size = new System.Drawing.Size(588, 114);
            this.panelDockContainer2.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelDockContainer2.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.panelDockContainer2.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.panelDockContainer2.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.panelDockContainer2.Style.GradientAngle = 90;
            this.panelDockContainer2.TabIndex = 0;
            // 
            // tb_stockId
            // 
            this.tb_stockId.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.tb_stockId.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            // 
            // 
            // 
            this.tb_stockId.Border.Class = "TextBoxBorder";
            this.tb_stockId.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tb_stockId.DataSource = null;
            this.tb_stockId.Location = new System.Drawing.Point(81, 9);
            this.tb_stockId.Name = "tb_stockId";
            this.tb_stockId.PreventEnterBeep = true;
            this.tb_stockId.Size = new System.Drawing.Size(154, 21);
            this.tb_stockId.TabIndex = 0;
            // 
            // dockContainerItem2
            // 
            this.dockContainerItem2.Control = this.panelDockContainer2;
            this.dockContainerItem2.Name = "dockContainerItem2";
            this.dockContainerItem2.Text = "数据";
            // 
            // dockSite1
            // 
            this.dockSite1.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.dockSite1.Dock = System.Windows.Forms.DockStyle.Left;
            this.dockSite1.DocumentDockContainer = new DevComponents.DotNetBar.DocumentDockContainer();
            this.dockSite1.Location = new System.Drawing.Point(0, 0);
            this.dockSite1.Name = "dockSite1";
            this.dockSite1.Size = new System.Drawing.Size(0, 48);
            this.dockSite1.TabIndex = 0;
            this.dockSite1.TabStop = false;
            // 
            // dockSite2
            // 
            this.dockSite2.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.dockSite2.Dock = System.Windows.Forms.DockStyle.Right;
            this.dockSite2.DocumentDockContainer = new DevComponents.DotNetBar.DocumentDockContainer();
            this.dockSite2.Location = new System.Drawing.Point(594, 0);
            this.dockSite2.Name = "dockSite2";
            this.dockSite2.Size = new System.Drawing.Size(0, 48);
            this.dockSite2.TabIndex = 1;
            this.dockSite2.TabStop = false;
            // 
            // dockSite8
            // 
            this.dockSite8.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.dockSite8.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dockSite8.Location = new System.Drawing.Point(0, 286);
            this.dockSite8.Name = "dockSite8";
            this.dockSite8.Size = new System.Drawing.Size(594, 0);
            this.dockSite8.TabIndex = 7;
            this.dockSite8.TabStop = false;
            // 
            // dockSite5
            // 
            this.dockSite5.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.dockSite5.Dock = System.Windows.Forms.DockStyle.Left;
            this.dockSite5.Location = new System.Drawing.Point(0, 0);
            this.dockSite5.Name = "dockSite5";
            this.dockSite5.Size = new System.Drawing.Size(0, 286);
            this.dockSite5.TabIndex = 4;
            this.dockSite5.TabStop = false;
            // 
            // dockSite6
            // 
            this.dockSite6.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.dockSite6.Dock = System.Windows.Forms.DockStyle.Right;
            this.dockSite6.Location = new System.Drawing.Point(594, 0);
            this.dockSite6.Name = "dockSite6";
            this.dockSite6.Size = new System.Drawing.Size(0, 286);
            this.dockSite6.TabIndex = 5;
            this.dockSite6.TabStop = false;
            // 
            // dockSite7
            // 
            this.dockSite7.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.dockSite7.Dock = System.Windows.Forms.DockStyle.Top;
            this.dockSite7.Location = new System.Drawing.Point(0, 0);
            this.dockSite7.Name = "dockSite7";
            this.dockSite7.Size = new System.Drawing.Size(594, 0);
            this.dockSite7.TabIndex = 6;
            this.dockSite7.TabStop = false;
            // 
            // dockSite3
            // 
            this.dockSite3.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.dockSite3.Dock = System.Windows.Forms.DockStyle.Top;
            this.dockSite3.DocumentDockContainer = new DevComponents.DotNetBar.DocumentDockContainer();
            this.dockSite3.Location = new System.Drawing.Point(0, 0);
            this.dockSite3.Name = "dockSite3";
            this.dockSite3.Size = new System.Drawing.Size(594, 0);
            this.dockSite3.TabIndex = 2;
            this.dockSite3.TabStop = false;
            // 
            // lv_stockInfo
            // 
            // 
            // 
            // 
            this.lv_stockInfo.Border.Class = "ListViewBorder";
            this.lv_stockInfo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lv_stockInfo.DisabledBackColor = System.Drawing.Color.Empty;
            this.lv_stockInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lv_stockInfo.FullRowSelect = true;
            this.lv_stockInfo.GridLines = true;
            this.lv_stockInfo.Location = new System.Drawing.Point(0, 0);
            this.lv_stockInfo.Name = "lv_stockInfo";
            this.lv_stockInfo.Size = new System.Drawing.Size(594, 48);
            this.lv_stockInfo.TabIndex = 8;
            this.lv_stockInfo.UseCompatibleStateImageBehavior = false;
            this.lv_stockInfo.View = System.Windows.Forms.View.Details;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 286);
            this.Controls.Add(this.lv_stockInfo);
            this.Controls.Add(this.dockSite2);
            this.Controls.Add(this.dockSite1);
            this.Controls.Add(this.dockSite3);
            this.Controls.Add(this.dockSite4);
            this.Controls.Add(this.dockSite5);
            this.Controls.Add(this.dockSite6);
            this.Controls.Add(this.dockSite7);
            this.Controls.Add(this.dockSite8);
            this.DoubleBuffered = true;
            this.Name = "MainForm";
            this.Text = "股票价格一瞥";
            this.dockSite4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
            this.bar1.ResumeLayout(false);
            this.panelDockContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.contextMenuBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bar2)).EndInit();
            this.bar2.ResumeLayout(false);
            this.panelDockContainer2.ResumeLayout(false);
            this.panelDockContainer2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        void ModifyComponent()
        {
            //最在最前
            this.DataBindings.Add("TopMost", sb_alwayTop, "Value");

            //透明度
            s_opacity.ValueChanging += (sender, e) => this.Opacity = e.NewValue * 1.0 / 100;

            //调整窗口位置
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(SystemInformation.WorkingArea.Width - this.Width, SystemInformation.WorkingArea.Height - this.Height);
        }

        private DevComponents.DotNetBar.DotNetBarManager dotNetBarManager1;
        private DevComponents.DotNetBar.DockSite dockSite4;
        private DevComponents.DotNetBar.DockSite dockSite1;
        private DevComponents.DotNetBar.DockSite dockSite2;
        private DevComponents.DotNetBar.DockSite dockSite3;
        private DevComponents.DotNetBar.DockSite dockSite5;
        private DevComponents.DotNetBar.DockSite dockSite6;
        private DevComponents.DotNetBar.DockSite dockSite7;
        private DevComponents.DotNetBar.DockSite dockSite8;
        private DevComponents.DotNetBar.Bar bar1;
        private DevComponents.DotNetBar.PanelDockContainer panelDockContainer1;
        private DevComponents.DotNetBar.Controls.Slider s_opacity;
        private DevComponents.DotNetBar.Controls.SwitchButton sb_alwayTop;
        private DevComponents.DotNetBar.DockContainerItem dockContainerItem1;
        private DevComponents.DotNetBar.Controls.ListViewEx lv_stockInfo;
        private DevComponents.DotNetBar.ContextMenuBar contextMenuBar;
        private DevComponents.DotNetBar.ButtonItem bi_stockList_right;
        private DevComponents.DotNetBar.ButtonItem buttonItem2;
        private DevComponents.DotNetBar.ButtonItem rightContext_btnDelete;
        private DevComponents.DotNetBar.ButtonItem rightContext_btnInsert;
        private DevComponents.DotNetBar.Bar bar2;
        private DevComponents.DotNetBar.PanelDockContainer panelDockContainer2;
        private DevComponents.DotNetBar.DockContainerItem dockContainerItem2;
        private AutoCompleteTextBoxXListView tb_stockId;
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using NHibernate.Linq;
using SWSPET.BL.Infrastructure;
using SWSPET.BL.SWSPET.Model;
using Telerik.WinControls.RichTextBox;
using Telerik.WinControls.UI;

namespace SWSPEmailTracker
{
    partial class SendingMail
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
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.radPanel1 = new Telerik.WinControls.UI.RadPanel();
            this.radSplitContainer2 = new Telerik.WinControls.UI.RadSplitContainer();
            this.splitPanel5 = new Telerik.WinControls.UI.SplitPanel();
            this.radGroupBox3 = new Telerik.WinControls.UI.RadGroupBox();
            this.radRadioButton2 = new Telerik.WinControls.UI.RadRadioButton();
            this.radRadioButton1 = new Telerik.WinControls.UI.RadRadioButton();
            this.splitPanel6 = new Telerik.WinControls.UI.SplitPanel();
            this.radGroupBox2 = new Telerik.WinControls.UI.RadGroupBox();
            this.radScrollablePanel1 = new Telerik.WinControls.UI.RadScrollablePanel();
            this.splitPanel7 = new Telerik.WinControls.UI.SplitPanel();
            this.radButton1 = new Telerik.WinControls.UI.RadButton();
            this.radProgressBar2 = new Telerik.WinControls.UI.RadProgressBar();
            this.radCheckBox1 = new Telerik.WinControls.UI.RadCheckBox();
            this.radSplitContainer1 = new Telerik.WinControls.UI.RadSplitContainer();
            this.splitPanel1 = new Telerik.WinControls.UI.SplitPanel();
            this.splitPanel2 = new Telerik.WinControls.UI.SplitPanel();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.radScrollablePanel2 = new Telerik.WinControls.UI.RadScrollablePanel();
            this.radListView1 = new Telerik.WinControls.UI.RadListView();
            this.splitPanel3 = new Telerik.WinControls.UI.SplitPanel();
            this.radProgressBar1 = new Telerik.WinControls.UI.RadProgressBar();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.splitPanel4 = new Telerik.WinControls.UI.SplitPanel();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.radMarkupDialog1 = new Telerik.WinControls.UI.RadMarkupDialog();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
            this.radPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radSplitContainer2)).BeginInit();
            this.radSplitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitPanel5)).BeginInit();
            this.splitPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox3)).BeginInit();
            this.radGroupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radRadioButton2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radRadioButton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitPanel6)).BeginInit();
            this.splitPanel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).BeginInit();
            this.radGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radScrollablePanel1)).BeginInit();
            this.radScrollablePanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitPanel7)).BeginInit();
            this.splitPanel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radProgressBar2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radCheckBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radSplitContainer1)).BeginInit();
            this.radSplitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitPanel1)).BeginInit();
            this.splitPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitPanel2)).BeginInit();
            this.splitPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radScrollablePanel2)).BeginInit();
            this.radScrollablePanel2.PanelContainer.SuspendLayout();
            this.radScrollablePanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radListView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitPanel3)).BeginInit();
            this.splitPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radProgressBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitPanel4)).BeginInit();
            this.splitPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Template:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Left;
            this.button1.Location = new System.Drawing.Point(518, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(61, 25);
            this.button1.TabIndex = 5;
            this.button1.Text = "send";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1Click);
            // 
            // radPanel1
            // 
            this.radPanel1.Controls.Add(this.radSplitContainer2);
            this.radPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radPanel1.Location = new System.Drawing.Point(0, 0);
            this.radPanel1.Name = "radPanel1";
            this.radPanel1.Size = new System.Drawing.Size(1008, 85);
            this.radPanel1.TabIndex = 7;
            // 
            // radSplitContainer2
            // 
            this.radSplitContainer2.Controls.Add(this.splitPanel5);
            this.radSplitContainer2.Controls.Add(this.splitPanel6);
            this.radSplitContainer2.Controls.Add(this.splitPanel7);
            this.radSplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radSplitContainer2.Location = new System.Drawing.Point(0, 0);
            this.radSplitContainer2.Name = "radSplitContainer2";
            // 
            // 
            // 
            this.radSplitContainer2.RootElement.MinSize = new System.Drawing.Size(25, 25);
            this.radSplitContainer2.Size = new System.Drawing.Size(1008, 85);
            this.radSplitContainer2.TabIndex = 3;
            this.radSplitContainer2.TabStop = false;
            this.radSplitContainer2.Text = "radSplitContainer2";
            // 
            // splitPanel5
            // 
            this.splitPanel5.Controls.Add(this.radGroupBox3);
            this.splitPanel5.Location = new System.Drawing.Point(0, 0);
            this.splitPanel5.Name = "splitPanel5";
            // 
            // 
            // 
            this.splitPanel5.RootElement.MinSize = new System.Drawing.Size(25, 25);
            this.splitPanel5.Size = new System.Drawing.Size(117, 85);
            this.splitPanel5.SizeInfo.AutoSizeScale = new System.Drawing.SizeF(-0.2165669F, 0F);
            this.splitPanel5.SizeInfo.SplitterCorrection = new System.Drawing.Size(-232, 0);
            this.splitPanel5.TabIndex = 0;
            this.splitPanel5.TabStop = false;
            this.splitPanel5.Text = "splitPanel5";
            // 
            // radGroupBox3
            // 
            this.radGroupBox3.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox3.Controls.Add(this.radRadioButton2);
            this.radGroupBox3.Controls.Add(this.radRadioButton1);
            this.radGroupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radGroupBox3.FooterImageIndex = -1;
            this.radGroupBox3.FooterImageKey = "";
            this.radGroupBox3.HeaderImageIndex = -1;
            this.radGroupBox3.HeaderImageKey = "";
            this.radGroupBox3.HeaderMargin = new System.Windows.Forms.Padding(0);
            this.radGroupBox3.HeaderText = "By Contact:";
            this.radGroupBox3.Location = new System.Drawing.Point(0, 0);
            this.radGroupBox3.Name = "radGroupBox3";
            this.radGroupBox3.Padding = new System.Windows.Forms.Padding(2, 18, 2, 2);
            // 
            // 
            // 
            this.radGroupBox3.RootElement.Padding = new System.Windows.Forms.Padding(2, 18, 2, 2);
            this.radGroupBox3.Size = new System.Drawing.Size(117, 85);
            this.radGroupBox3.TabIndex = 2;
            this.radGroupBox3.Text = "By Contact:";
            // 
            // radRadioButton2
            // 
            this.radRadioButton2.Location = new System.Drawing.Point(5, 45);
            this.radRadioButton2.Name = "radRadioButton2";
            this.radRadioButton2.Size = new System.Drawing.Size(110, 18);
            this.radRadioButton2.TabIndex = 1;
            this.radRadioButton2.Text = "Just Valid Emails";
            this.radRadioButton2.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
            // 
            // radRadioButton1
            // 
            this.radRadioButton1.Location = new System.Drawing.Point(5, 21);
            this.radRadioButton1.Name = "radRadioButton1";
            this.radRadioButton1.Size = new System.Drawing.Size(110, 18);
            this.radRadioButton1.TabIndex = 0;
            this.radRadioButton1.Text = "All Contacts";
            // 
            // splitPanel6
            // 
            this.splitPanel6.Controls.Add(this.radGroupBox2);
            this.splitPanel6.Location = new System.Drawing.Point(120, 0);
            this.splitPanel6.Name = "splitPanel6";
            // 
            // 
            // 
            this.splitPanel6.RootElement.MinSize = new System.Drawing.Size(25, 25);
            this.splitPanel6.Size = new System.Drawing.Size(785, 85);
            this.splitPanel6.SizeInfo.AutoSizeScale = new System.Drawing.SizeF(0.4500998F, 0F);
            this.splitPanel6.SizeInfo.SplitterCorrection = new System.Drawing.Size(445, 0);
            this.splitPanel6.TabIndex = 1;
            this.splitPanel6.TabStop = false;
            this.splitPanel6.Text = "splitPanel6";
            // 
            // radGroupBox2
            // 
            this.radGroupBox2.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox2.Controls.Add(this.radScrollablePanel1);
            this.radGroupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radGroupBox2.FooterImageIndex = -1;
            this.radGroupBox2.FooterImageKey = "";
            this.radGroupBox2.HeaderImageIndex = -1;
            this.radGroupBox2.HeaderImageKey = "";
            this.radGroupBox2.HeaderMargin = new System.Windows.Forms.Padding(0);
            this.radGroupBox2.HeaderText = "Categorye";
            this.radGroupBox2.Location = new System.Drawing.Point(0, 0);
            this.radGroupBox2.Name = "radGroupBox2";
            this.radGroupBox2.Padding = new System.Windows.Forms.Padding(2, 18, 2, 2);
            // 
            // 
            // 
            this.radGroupBox2.RootElement.Padding = new System.Windows.Forms.Padding(2, 18, 2, 2);
            this.radGroupBox2.Size = new System.Drawing.Size(785, 85);
            this.radGroupBox2.TabIndex = 1;
            this.radGroupBox2.Text = "Categorye";
            // 
            // radScrollablePanel1
            // 
            this.radScrollablePanel1.AutoScroll = true;
            this.radScrollablePanel1.AutoScrollMargin = new System.Drawing.Size(10, 0);
            this.radScrollablePanel1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.radScrollablePanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radScrollablePanel1.Location = new System.Drawing.Point(2, 18);
            this.radScrollablePanel1.Name = "radScrollablePanel1";
            this.radScrollablePanel1.Padding = new System.Windows.Forms.Padding(1);
            // 
            // radScrollablePanel1.PanelContainer
            // 
            this.radScrollablePanel1.PanelContainer.AutoScroll = true;
            this.radScrollablePanel1.PanelContainer.AutoScrollMargin = new System.Drawing.Size(10, 0);
            this.radScrollablePanel1.PanelContainer.BackColor = System.Drawing.Color.Transparent;
            this.radScrollablePanel1.PanelContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radScrollablePanel1.PanelContainer.Location = new System.Drawing.Point(1, 1);
            this.radScrollablePanel1.PanelContainer.Name = "PanelContainer";
            this.radScrollablePanel1.PanelContainer.Size = new System.Drawing.Size(779, 63);
            this.radScrollablePanel1.PanelContainer.TabIndex = 0;
            // 
            // 
            // 
            this.radScrollablePanel1.RootElement.Padding = new System.Windows.Forms.Padding(1);
            this.radScrollablePanel1.Size = new System.Drawing.Size(781, 65);
            this.radScrollablePanel1.TabIndex = 0;
            this.radScrollablePanel1.Text = "radScrollablePanel1";
            // 
            // splitPanel7
            // 
            this.splitPanel7.Controls.Add(this.radButton1);
            this.splitPanel7.Controls.Add(this.radProgressBar2);
            this.splitPanel7.Controls.Add(this.radCheckBox1);
            this.splitPanel7.Location = new System.Drawing.Point(908, 0);
            this.splitPanel7.Name = "splitPanel7";
            // 
            // 
            // 
            this.splitPanel7.RootElement.MinSize = new System.Drawing.Size(25, 25);
            this.splitPanel7.Size = new System.Drawing.Size(100, 85);
            this.splitPanel7.SizeInfo.AutoSizeScale = new System.Drawing.SizeF(-0.2335329F, 0F);
            this.splitPanel7.SizeInfo.SplitterCorrection = new System.Drawing.Size(-213, 0);
            this.splitPanel7.TabIndex = 2;
            this.splitPanel7.TabStop = false;
            this.splitPanel7.Text = "splitPanel7";
            // 
            // radButton1
            // 
            this.radButton1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radButton1.Location = new System.Drawing.Point(0, 18);
            this.radButton1.Name = "radButton1";
            this.radButton1.Size = new System.Drawing.Size(100, 44);
            this.radButton1.TabIndex = 0;
            this.radButton1.Text = "Prepare List";
            this.radButton1.Click += new System.EventHandler(this.RadButton1Click1);
            // 
            // radProgressBar2
            // 
            this.radProgressBar2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.radProgressBar2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.radProgressBar2.ImageIndex = -1;
            this.radProgressBar2.ImageKey = "";
            this.radProgressBar2.ImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.radProgressBar2.Location = new System.Drawing.Point(0, 62);
            this.radProgressBar2.Name = "radProgressBar2";
            this.radProgressBar2.SeparatorColor1 = System.Drawing.Color.White;
            this.radProgressBar2.SeparatorColor2 = System.Drawing.Color.White;
            this.radProgressBar2.SeparatorColor3 = System.Drawing.Color.White;
            this.radProgressBar2.SeparatorColor4 = System.Drawing.Color.White;
            this.radProgressBar2.Size = new System.Drawing.Size(100, 23);
            this.radProgressBar2.TabIndex = 7;
            // 
            // radCheckBox1
            // 
            this.radCheckBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.radCheckBox1.Location = new System.Drawing.Point(0, 0);
            this.radCheckBox1.Name = "radCheckBox1";
            this.radCheckBox1.Size = new System.Drawing.Size(97, 18);
            this.radCheckBox1.TabIndex = 8;
            this.radCheckBox1.Text = "Show Email List";
            this.radCheckBox1.ToggleStateChanged += new Telerik.WinControls.UI.StateChangedEventHandler(this.RadCheckBox1ToggleStateChanged);
            // 
            // radSplitContainer1
            // 
            this.radSplitContainer1.Controls.Add(this.splitPanel1);
            this.radSplitContainer1.Controls.Add(this.splitPanel2);
            this.radSplitContainer1.Controls.Add(this.splitPanel3);
            this.radSplitContainer1.Controls.Add(this.splitPanel4);
            this.radSplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radSplitContainer1.Location = new System.Drawing.Point(0, 0);
            this.radSplitContainer1.Name = "radSplitContainer1";
            this.radSplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // 
            // 
            this.radSplitContainer1.RootElement.MinSize = new System.Drawing.Size(25, 25);
            this.radSplitContainer1.Size = new System.Drawing.Size(1008, 552);
            this.radSplitContainer1.TabIndex = 3;
            this.radSplitContainer1.TabStop = false;
            this.radSplitContainer1.Text = "radSplitContainer1";
            // 
            // splitPanel1
            // 
            this.splitPanel1.Controls.Add(this.radPanel1);
            this.splitPanel1.Location = new System.Drawing.Point(0, 0);
            this.splitPanel1.Name = "splitPanel1";
            // 
            // 
            // 
            this.splitPanel1.RootElement.MinSize = new System.Drawing.Size(25, 25);
            this.splitPanel1.Size = new System.Drawing.Size(1008, 85);
            this.splitPanel1.SizeInfo.AutoSizeScale = new System.Drawing.SizeF(0F, -0.09346224F);
            this.splitPanel1.SizeInfo.SplitterCorrection = new System.Drawing.Size(0, -51);
            this.splitPanel1.TabIndex = 0;
            this.splitPanel1.TabStop = false;
            this.splitPanel1.Text = "splitPanel1";
            // 
            // splitPanel2
            // 
            this.splitPanel2.Controls.Add(this.radGroupBox1);
            this.splitPanel2.Location = new System.Drawing.Point(0, 88);
            this.splitPanel2.Name = "splitPanel2";
            // 
            // 
            // 
            this.splitPanel2.RootElement.MinSize = new System.Drawing.Size(25, 25);
            this.splitPanel2.Size = new System.Drawing.Size(1008, 145);
            this.splitPanel2.SizeInfo.AutoSizeScale = new System.Drawing.SizeF(0F, 0.01703499F);
            this.splitPanel2.SizeInfo.SplitterCorrection = new System.Drawing.Size(0, 9);
            this.splitPanel2.TabIndex = 1;
            this.splitPanel2.TabStop = false;
            this.splitPanel2.Text = "splitPanel2";
            this.splitPanel2.Click += new System.EventHandler(this.SplitPanel2Click);
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Controls.Add(this.radScrollablePanel2);
            this.radGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radGroupBox1.FooterImageIndex = -1;
            this.radGroupBox1.FooterImageKey = "";
            this.radGroupBox1.HeaderImageIndex = -1;
            this.radGroupBox1.HeaderImageKey = "";
            this.radGroupBox1.HeaderMargin = new System.Windows.Forms.Padding(0);
            this.radGroupBox1.HeaderText = "Categorye";
            this.radGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Padding = new System.Windows.Forms.Padding(2, 18, 2, 2);
            // 
            // 
            // 
            this.radGroupBox1.RootElement.Padding = new System.Windows.Forms.Padding(2, 18, 2, 2);
            this.radGroupBox1.Size = new System.Drawing.Size(1008, 145);
            this.radGroupBox1.TabIndex = 2;
            this.radGroupBox1.Text = "Categorye";
            // 
            // radScrollablePanel2
            // 
            this.radScrollablePanel2.AutoScroll = true;
            this.radScrollablePanel2.AutoScrollMargin = new System.Drawing.Size(10, 0);
            this.radScrollablePanel2.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.radScrollablePanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radScrollablePanel2.Location = new System.Drawing.Point(2, 18);
            this.radScrollablePanel2.Name = "radScrollablePanel2";
            this.radScrollablePanel2.Padding = new System.Windows.Forms.Padding(1);
            // 
            // radScrollablePanel2.PanelContainer
            // 
            this.radScrollablePanel2.PanelContainer.AutoScroll = true;
            this.radScrollablePanel2.PanelContainer.AutoScrollMargin = new System.Drawing.Size(10, 0);
            this.radScrollablePanel2.PanelContainer.BackColor = System.Drawing.Color.Transparent;
            this.radScrollablePanel2.PanelContainer.Controls.Add(this.radListView1);
            this.radScrollablePanel2.PanelContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radScrollablePanel2.PanelContainer.Location = new System.Drawing.Point(1, 1);
            this.radScrollablePanel2.PanelContainer.Name = "PanelContainer";
            this.radScrollablePanel2.PanelContainer.Size = new System.Drawing.Size(1002, 123);
            this.radScrollablePanel2.PanelContainer.TabIndex = 0;
            // 
            // 
            // 
            this.radScrollablePanel2.RootElement.Padding = new System.Windows.Forms.Padding(1);
            this.radScrollablePanel2.Size = new System.Drawing.Size(1004, 125);
            this.radScrollablePanel2.TabIndex = 0;
            this.radScrollablePanel2.Text = "radScrollablePanel2";
            // 
            // radListView1
            // 
            this.radListView1.DisplayMember = "Key";
            this.radListView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radListView1.GroupItemSize = new System.Drawing.Size(200, 20);
            this.radListView1.ItemSize = new System.Drawing.Size(200, 20);
            this.radListView1.Location = new System.Drawing.Point(0, 0);
            this.radListView1.Name = "radListView1";
            this.radListView1.ShowCheckBoxes = true;
            this.radListView1.Size = new System.Drawing.Size(1002, 123);
            this.radListView1.TabIndex = 7;
            this.radListView1.Text = "radListView1";
            this.radListView1.ValueMember = "Key";
            // 
            // splitPanel3
            // 
            this.splitPanel3.Controls.Add(this.radProgressBar1);
            this.splitPanel3.Controls.Add(this.button1);
            this.splitPanel3.Controls.Add(this.comboBox1);
            this.splitPanel3.Controls.Add(this.label1);
            this.splitPanel3.Location = new System.Drawing.Point(0, 236);
            this.splitPanel3.Name = "splitPanel3";
            // 
            // 
            // 
            this.splitPanel3.RootElement.MinSize = new System.Drawing.Size(25, 25);
            this.splitPanel3.Size = new System.Drawing.Size(1008, 25);
            this.splitPanel3.SizeInfo.AutoSizeScale = new System.Drawing.SizeF(0F, -0.2039595F);
            this.splitPanel3.SizeInfo.SplitterCorrection = new System.Drawing.Size(0, -111);
            this.splitPanel3.TabIndex = 2;
            this.splitPanel3.TabStop = false;
            this.splitPanel3.Text = "splitPanel3";
            // 
            // radProgressBar1
            // 
            this.radProgressBar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.radProgressBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radProgressBar1.ImageIndex = -1;
            this.radProgressBar1.ImageKey = "";
            this.radProgressBar1.ImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.radProgressBar1.Location = new System.Drawing.Point(579, 0);
            this.radProgressBar1.Name = "radProgressBar1";
            this.radProgressBar1.SeparatorColor1 = System.Drawing.Color.White;
            this.radProgressBar1.SeparatorColor2 = System.Drawing.Color.White;
            this.radProgressBar1.SeparatorColor3 = System.Drawing.Color.White;
            this.radProgressBar1.SeparatorColor4 = System.Drawing.Color.White;
            this.radProgressBar1.Size = new System.Drawing.Size(429, 25);
            this.radProgressBar1.TabIndex = 6;
            // 
            // comboBox1
            // 
            this.comboBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(56, 0);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(462, 21);
            this.comboBox1.TabIndex = 7;
            // 
            // splitPanel4
            // 
            this.splitPanel4.Controls.Add(this.richTextBox1);
            this.splitPanel4.Location = new System.Drawing.Point(0, 264);
            this.splitPanel4.Name = "splitPanel4";
            // 
            // 
            // 
            this.splitPanel4.RootElement.MinSize = new System.Drawing.Size(25, 25);
            this.splitPanel4.Size = new System.Drawing.Size(1008, 288);
            this.splitPanel4.SizeInfo.AutoSizeScale = new System.Drawing.SizeF(0F, 0.2803867F);
            this.splitPanel4.SizeInfo.SplitterCorrection = new System.Drawing.Size(0, 153);
            this.splitPanel4.TabIndex = 3;
            this.splitPanel4.TabStop = false;
            this.splitPanel4.Text = "splitPanel4";
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.Color.SeaGreen;
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.ForeColor = System.Drawing.Color.Linen;
            this.richTextBox1.Location = new System.Drawing.Point(0, 0);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(1008, 288);
            this.richTextBox1.TabIndex = 7;
            this.richTextBox1.Text = "";
            this.richTextBox1.TextChanged += new System.EventHandler(this.RichTextBox1TextChanged);
            // 
            // radMarkupDialog1
            // 
            this.radMarkupDialog1.DefaultFont = null;
            this.radMarkupDialog1.Value = null;
            // 
            // SendingMail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 552);
            this.Controls.Add(this.radSplitContainer1);
            this.Name = "SendingMail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SendingMail";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SendingMail_FormClosing);
            this.Load += new System.EventHandler(this.SendingMail_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
            this.radPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radSplitContainer2)).EndInit();
            this.radSplitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitPanel5)).EndInit();
            this.splitPanel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox3)).EndInit();
            this.radGroupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radRadioButton2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radRadioButton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitPanel6)).EndInit();
            this.splitPanel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).EndInit();
            this.radGroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radScrollablePanel1)).EndInit();
            this.radScrollablePanel1.ResumeLayout(false);
            this.radScrollablePanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitPanel7)).EndInit();
            this.splitPanel7.ResumeLayout(false);
            this.splitPanel7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radProgressBar2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radCheckBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radSplitContainer1)).EndInit();
            this.radSplitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitPanel1)).EndInit();
            this.splitPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitPanel2)).EndInit();
            this.splitPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            this.radScrollablePanel2.PanelContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radScrollablePanel2)).EndInit();
            this.radScrollablePanel2.ResumeLayout(false);
            this.radScrollablePanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radListView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitPanel3)).EndInit();
            this.splitPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radProgressBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitPanel4)).EndInit();
            this.splitPanel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private Telerik.WinControls.UI.RadProgressBar radProgressBar1;
        private Telerik.WinControls.UI.RadMarkupDialog radMarkupDialog1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private Telerik.WinControls.UI.RadPanel radPanel1;
        private Telerik.WinControls.UI.RadSplitContainer radSplitContainer1;
        private Telerik.WinControls.UI.SplitPanel splitPanel1;
        private Telerik.WinControls.UI.SplitPanel splitPanel2;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox3;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox2;
        private Telerik.WinControls.UI.SplitPanel splitPanel3;
        private Telerik.WinControls.UI.SplitPanel splitPanel4;
        private Telerik.WinControls.UI.RadRadioButton radRadioButton2;
        private Telerik.WinControls.UI.RadRadioButton radRadioButton1;
        private Telerik.WinControls.UI.RadScrollablePanel radScrollablePanel1;
        private RadSplitContainer radSplitContainer2;
        private SplitPanel splitPanel5;
        private SplitPanel splitPanel6;
        private SplitPanel splitPanel7;
        private RadButton radButton1;
        private RadGroupBox radGroupBox1;
        private RadScrollablePanel radScrollablePanel2;
        private RadCheckBox radCheckBox1;
        private RadProgressBar radProgressBar2;
        private RadListView radListView1;
        private ComboBox comboBox1;

    }
}
namespace SWSPEmailTracker
{
    partial class PersonTrack
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PersonTrack));
            this.panel1 = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.radScrollablePanel1 = new Telerik.WinControls.UI.RadScrollablePanel();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radScrollablePanel1)).BeginInit();
            this.radScrollablePanel1.PanelContainer.SuspendLayout();
            this.radScrollablePanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(725, 114);
            this.panel1.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.toolStripTextBox1,
            this.toolStripButton2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(725, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(39, 22);
            this.toolStripLabel1.Text = "Email:";
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Size = new System.Drawing.Size(100, 25);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(50, 22);
            this.toolStripButton2.Text = "Find";
            this.toolStripButton2.Click += new System.EventHandler(this.ToolStripButton2Click);
            // 
            // radLabel1
            // 
            this.radLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radLabel1.Location = new System.Drawing.Point(0, 0);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(2, 2);
            this.radLabel1.TabIndex = 2;
            // 
            // radScrollablePanel1
            // 
            this.radScrollablePanel1.AutoScroll = true;
            this.radScrollablePanel1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.radScrollablePanel1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.radScrollablePanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radScrollablePanel1.Location = new System.Drawing.Point(0, 139);
            this.radScrollablePanel1.Name = "radScrollablePanel1";
            this.radScrollablePanel1.Padding = new System.Windows.Forms.Padding(1);
            // 
            // radScrollablePanel1.PanelContainer
            // 
            this.radScrollablePanel1.PanelContainer.AutoScroll = true;
            this.radScrollablePanel1.PanelContainer.Controls.Add(this.radLabel1);
            this.radScrollablePanel1.PanelContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radScrollablePanel1.PanelContainer.Location = new System.Drawing.Point(1, 1);
            this.radScrollablePanel1.PanelContainer.Name = "PanelContainer";
            this.radScrollablePanel1.PanelContainer.Size = new System.Drawing.Size(723, 254);
            this.radScrollablePanel1.PanelContainer.TabIndex = 0;
            // 
            // 
            // 
            this.radScrollablePanel1.RootElement.Padding = new System.Windows.Forms.Padding(1);
            this.radScrollablePanel1.Size = new System.Drawing.Size(725, 256);
            this.radScrollablePanel1.TabIndex = 3;
            this.radScrollablePanel1.Text = "radScrollablePanel1";
            // 
            // PersonTrack
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(725, 395);
            this.Controls.Add(this.radScrollablePanel1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "PersonTrack";
            this.Text = "PersonTrack";
            this.Load += new System.EventHandler(this.PersonTrack_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            this.radScrollablePanel1.PanelContainer.ResumeLayout(false);
            this.radScrollablePanel1.PanelContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radScrollablePanel1)).EndInit();
            this.radScrollablePanel1.ResumeLayout(false);
            this.radScrollablePanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadScrollablePanel radScrollablePanel1;
    }
}
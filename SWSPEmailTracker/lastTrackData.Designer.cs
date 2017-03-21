namespace SWSPEmailTracker
{
    partial class lastTrackData
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
            this.baseGridView1 = new SWSPET.BL.Controls.WinControls.BaseGridView();
            this.radTreeView1 = new Telerik.WinControls.UI.RadTreeView();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.baseGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTreeView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // baseGridView1
            // 
            this.baseGridView1.AllowUserToAddRows = false;
            this.baseGridView1.AllowUserToDeleteRows = false;
            this.baseGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.baseGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.baseGridView1.HiddenColumns = null;
            this.baseGridView1.Location = new System.Drawing.Point(0, 0);
            this.baseGridView1.Name = "baseGridView1";
            this.baseGridView1.ReadOnly = true;
            this.baseGridView1.Size = new System.Drawing.Size(418, 395);
            this.baseGridView1.TabIndex = 0;
            // 
            // radTreeView1
            // 
            this.radTreeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radTreeView1.Location = new System.Drawing.Point(0, 0);
            this.radTreeView1.Name = "radTreeView1";
            this.radTreeView1.Size = new System.Drawing.Size(210, 395);
            this.radTreeView1.SpacingBetweenNodes = -1;
            this.radTreeView1.TabIndex = 1;
            this.radTreeView1.Text = "radTreeView1";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.radTreeView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.baseGridView1);
            this.splitContainer1.Size = new System.Drawing.Size(632, 395);
            this.splitContainer1.SplitterDistance = 210;
            this.splitContainer1.TabIndex = 2;
            // 
            // lastTrackData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 395);
            this.Controls.Add(this.splitContainer1);
            this.Name = "lastTrackData";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "lastTrackData";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.lastTrackData_Load);
            ((System.ComponentModel.ISupportInitialize)(this.baseGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTreeView1)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private SWSPET.BL.Controls.WinControls.BaseGridView baseGridView1;
        private Telerik.WinControls.UI.RadTreeView radTreeView1;
        private System.Windows.Forms.SplitContainer splitContainer1;
    }
}
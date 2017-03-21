using Telerik.WinControls.UI;

namespace SWSPET.BL.Controls.WinControls
{
    partial class MainFormDataEntry
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainFormDataEntry));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnSaveAndNew = new Telerik.WinControls.UI.RadButton();
            this.btnClose = new Telerik.WinControls.UI.RadButton();
            this.btnSaveAndClose = new Telerik.WinControls.UI.RadButton();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.containerPanel = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveAndNew)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveAndClose)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.containerPanel, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(963, 440);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.btnSaveAndNew, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnClose, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnSaveAndClose, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.listBox1, 3, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 397);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(957, 40);
            this.tableLayoutPanel2.TabIndex = 4;
            // 
            // btnSaveAndNew
            // 
            this.btnSaveAndNew.DisplayStyle = Telerik.WinControls.DisplayStyle.Text;
            this.btnSaveAndNew.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSaveAndNew.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveAndNew.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveAndNew.Image")));
            this.btnSaveAndNew.Location = new System.Drawing.Point(3, 3);
            this.btnSaveAndNew.Name = "btnSaveAndNew";
            this.btnSaveAndNew.Size = new System.Drawing.Size(80, 37);
            this.btnSaveAndNew.TabIndex = 4;
            this.btnSaveAndNew.Text = "Save && new";
            this.btnSaveAndNew.Click += new System.EventHandler(this.BtnSaveAndNewClick);
            // 
            // btnClose
            // 
            this.btnClose.DisplayStyle = Telerik.WinControls.DisplayStyle.Text;
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Location = new System.Drawing.Point(175, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(80, 37);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "close";
            this.btnClose.Click += new System.EventHandler(this.BtnCloseClick);
            // 
            // btnSaveAndClose
            // 
            this.btnSaveAndClose.DisplayStyle = Telerik.WinControls.DisplayStyle.Text;
            this.btnSaveAndClose.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSaveAndClose.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveAndClose.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveAndClose.Image")));
            this.btnSaveAndClose.Location = new System.Drawing.Point(89, 3);
            this.btnSaveAndClose.Name = "btnSaveAndClose";
            this.btnSaveAndClose.Size = new System.Drawing.Size(80, 37);
            this.btnSaveAndClose.TabIndex = 2;
            this.btnSaveAndClose.Text = "save && close";
            this.btnSaveAndClose.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnSaveAndClose.Click += new System.EventHandler(this.BtnSaveAndCloseClick);
            // 
            // listBox1
            // 
            this.listBox1.BackColor = System.Drawing.SystemColors.Info;
            this.listBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox1.ForeColor = System.Drawing.Color.Red;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 14;
            this.listBox1.Location = new System.Drawing.Point(261, 3);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(693, 37);
            this.listBox1.TabIndex = 5;
            this.listBox1.Visible = false;
            // 
            // containerPanel
            // 
            this.containerPanel.BackColor = System.Drawing.SystemColors.Control;
            this.containerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.containerPanel.Location = new System.Drawing.Point(3, 13);
            this.containerPanel.Name = "containerPanel";
            this.containerPanel.Size = new System.Drawing.Size(957, 378);
            this.containerPanel.TabIndex = 3;
            // 
            // MainFormDataEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(963, 440);
            this.ControlBox = false;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "MainFormDataEntry";
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainFormLoad);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveAndNew)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveAndClose)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private RadButton btnSaveAndNew;
        private RadButton btnClose;
        private RadButton btnSaveAndClose;
        private System.Windows.Forms.Panel containerPanel;
        private System.Windows.Forms.ListBox listBox1;
    }
}
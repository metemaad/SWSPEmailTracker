namespace SWSPEmailTracker
{
    partial class pop3test
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
            this.radRepeatButton1 = new Telerik.WinControls.UI.RadRepeatButton();
            this.progressBar = new Telerik.WinControls.UI.RadProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.radRepeatButton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.progressBar)).BeginInit();
            this.SuspendLayout();
            // 
            // radRepeatButton1
            // 
            this.radRepeatButton1.Location = new System.Drawing.Point(118, 99);
            this.radRepeatButton1.Name = "radRepeatButton1";
            this.radRepeatButton1.Size = new System.Drawing.Size(100, 23);
            this.radRepeatButton1.TabIndex = 0;
            this.radRepeatButton1.Text = "radRepeatButton1";
            this.radRepeatButton1.Click += new System.EventHandler(this.radRepeatButton1_Click);
            // 
            // progressBar
            // 
            this.progressBar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.progressBar.ImageIndex = -1;
            this.progressBar.ImageKey = "";
            this.progressBar.ImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.progressBar.Location = new System.Drawing.Point(28, 192);
            this.progressBar.Name = "progressBar";
            this.progressBar.SeparatorColor1 = System.Drawing.Color.White;
            this.progressBar.SeparatorColor2 = System.Drawing.Color.White;
            this.progressBar.SeparatorColor3 = System.Drawing.Color.White;
            this.progressBar.SeparatorColor4 = System.Drawing.Color.White;
            this.progressBar.Size = new System.Drawing.Size(137, 23);
            this.progressBar.TabIndex = 1;
            this.progressBar.Text = "radProgressBar1";
            // 
            // pop3test
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.radRepeatButton1);
            this.Name = "pop3test";
            this.Text = "pop3test";
            ((System.ComponentModel.ISupportInitialize)(this.radRepeatButton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.progressBar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadRepeatButton radRepeatButton1;
        private Telerik.WinControls.UI.RadProgressBar progressBar;
    }
}
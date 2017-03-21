namespace SWSPEmailTracker
{
    partial class ImportContact
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.radRepeatButton1 = new Telerik.WinControls.UI.RadRepeatButton();
            this.radButton1 = new Telerik.WinControls.UI.RadButton();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.radRepeatButton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // radRepeatButton1
            // 
            this.radRepeatButton1.Location = new System.Drawing.Point(62, 42);
            this.radRepeatButton1.Name = "radRepeatButton1";
            this.radRepeatButton1.Size = new System.Drawing.Size(163, 23);
            this.radRepeatButton1.TabIndex = 0;
            this.radRepeatButton1.Text = "Import By Google Format";
            this.radRepeatButton1.Click += new System.EventHandler(this.radRepeatButton1_Click);
            // 
            // radButton1
            // 
            this.radButton1.Location = new System.Drawing.Point(62, 85);
            this.radButton1.Name = "radButton1";
            this.radButton1.Size = new System.Drawing.Size(161, 24);
            this.radButton1.TabIndex = 1;
            this.radButton1.Text = "Import SWSPETS Format";
            this.radButton1.Click += new System.EventHandler(this.radButton1_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(62, 139);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "email list";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(62, 169);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "simple contact";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(182, 215);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 4;
            this.button3.Text = "Vcard";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // ImportContact
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.radButton1);
            this.Controls.Add(this.radRepeatButton1);
            this.Name = "ImportContact";
            this.Text = "ImportContact";
            ((System.ComponentModel.ISupportInitialize)(this.radRepeatButton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private Telerik.WinControls.UI.RadRepeatButton radRepeatButton1;
        private Telerik.WinControls.UI.RadButton radButton1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}
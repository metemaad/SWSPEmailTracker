namespace SWSPEmailTracker
{
    partial class AddPersonLigth
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
            this.personInstantEdit1 = new SWSPET.BL.Controls.WinControls.PersonInstantEdit();
            this.SuspendLayout();
            // 
            // personInstantEdit1
            // 
            this.personInstantEdit1.CurrentPerson = null;
            this.personInstantEdit1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.personInstantEdit1.Location = new System.Drawing.Point(0, 0);
            this.personInstantEdit1.Name = "personInstantEdit1";
            this.personInstantEdit1.Size = new System.Drawing.Size(679, 450);
            this.personInstantEdit1.TabIndex = 0;
            this.personInstantEdit1.Load += new System.EventHandler(this.personInstantEdit1_Load);
            // 
            // AddPersonLigth
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(679, 450);
            this.Controls.Add(this.personInstantEdit1);
            this.Name = "AddPersonLigth";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddPersonLigth";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.AddPersonLigth_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private SWSPET.BL.Controls.WinControls.PersonInstantEdit personInstantEdit1;
    }
}
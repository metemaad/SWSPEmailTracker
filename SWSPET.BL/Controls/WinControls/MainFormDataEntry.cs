using System;
using System.Linq;
using System.Windows.Forms;
using SWSPET.BL.Infrastructure;

namespace SWSPET.BL.Controls.WinControls
{
    public partial class MainFormDataEntry : Form
    {
        public MainFormDataEntry()
        {
            InitializeComponent();
        }
        private void BtnSaveAndCloseClick(object sender, EventArgs e)
        {
            var innerPart = (UiPart)containerPanel.Controls[0];
            innerPart.OnSave();
            InnerInstance = (IPersistable)innerPart.ObjectInstance;
            var errors = InnerInstance.Validate();
            var uiErrors = innerPart.UiValidate();
            listBox1.Items.Clear();
            if (errors.Count > 0 || uiErrors.Count() > 0)
            {
                listBox1.Visible = true; foreach (var error in errors) { listBox1.Items.Add(error); }
                foreach (var uiError in uiErrors) { listBox1.Items.Add(uiError); } return;
            }
            else { listBox1.Visible = false; } InnerInstance.Persist(); DataAccess.Flush(); this.Close();
        }
        public void IncludeUiPart(UiPart uiPart)
        {
            var instance = (Entity)uiPart.ObjectInstance;
            InnerInstance = instance;
            this.Text = instance.TypeDesc; containerPanel.Controls.Add(uiPart);
            uiPart.Dock = DockStyle.Fill; this.WindowState = uiPart.WindowState;
            uiPart.OnCurrentChanged(null, instance);
        }
        private void BtnSaveAndNewClick(object sender, EventArgs e)
        {
            var innerPart = (UiPart)containerPanel.Controls[0]; 
            innerPart.OnSave();
            InnerInstance = (IPersistable)innerPart.ObjectInstance; 
            var errors = InnerInstance.Validate();
            var uiErrors = innerPart.UiValidate(); listBox1.Items.Clear();
            if (errors.Count > 0 || uiErrors.Count() > 0)
            {
                listBox1.Visible = true;
                foreach (var error in errors)
                {
                    listBox1.Items.Add(error);
                }
                foreach (var uiError in uiErrors)
                {
                    listBox1.Items.Add(uiError);
                } 
                return;
            }
            else
            {
                listBox1.Visible = false;
            } 
            InnerInstance.Persist(); 
            DataAccess.Flush(); var type = InnerInstance.GetType();
            var newInstance = (IPersistable)Activator.CreateInstance(type); 
            innerPart.ObjectInstance = newInstance;
            innerPart.OnCurrentChanged(InnerInstance, newInstance); 
            InnerInstance = newInstance;
        }
        private void BtnCloseClick(object sender, EventArgs e)
        {
            var innerPart = (UiPart)containerPanel.Controls[0];
            var instance = (IPersistable)innerPart.ObjectInstance;
            DataAccess.NhSession.Evict(instance); 
            InnerInstance = null; 
            this.Close();
        }
        public DialogResult ShowEditDialog() { btnSaveAndNew.Visible = false; return ShowDialog(); }
        public IPersistable InnerInstance { get; set; }
        private void MainFormLoad(object sender, EventArgs e) { }
    }
}

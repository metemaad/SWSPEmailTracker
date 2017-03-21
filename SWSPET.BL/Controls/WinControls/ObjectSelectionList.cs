using System;
using System.ComponentModel;
using System.Reflection;
using System.Windows.Forms;
using SWSPET.BL.Infrastructure;

namespace SWSPET.BL.Controls.WinControls
{
    public partial class ObjectSelectionList : Form
    {
        public ObjectSelectionList()
        {
            InitializeComponent();
        }

        public void LoadGrid()
        {
            Loadgrid();
        }
        public object SelectedObject { get; set; }


        internal void InitGrid(Type type)
        {
            _gridInternalType = type;
            baseGridView1.InitilizeGrid(type);
        }

        private void BaseGridView1CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(baseGridView1.SelectedRows.Count > 0)
                SelectedObject = baseGridView1.SelectedRows[0].DataBoundItem;
            this.Close();
        }

        private void TextBox1TextChanged(object sender, EventArgs e)
        {
            Loadgrid();
        }

        private Type _gridInternalType;

        private void Loadgrid()
        {
            if (_gridInternalType == null)
                return;
          var list = _gridInternalType.InvokeMember("Search", BindingFlags.InvokeMethod, null, null, new object[] {textBox1.Text});
            baseGridView1.DataSource = list;
        }

        private void Button1Click(object sender, EventArgs e)
        {
            var personel = EntityFormService.NewDialog(_gridInternalType);
            if (personel != null)
            {
                SelectedObject = personel;
                Close();
            }


        }

        private void ObjectSelectionListKeyPress(object sender, KeyPressEventArgs eventArgs)
        {
            
        }

        private void Button2Click(object sender, EventArgs e)
        {
            this.Close();
        }

        

        private void EditToolStripMenuItemClicked(object sender, EventArgs e)
        {
            Entity entity = null;
            if (baseGridView1.SelectedRows.Count > 0)
            {
                entity = (Entity)baseGridView1.SelectedRows[0].DataBoundItem;
                EntityFormService.Edit(entity);
                Loadgrid();
            }
        }

        private void ContextMenuStrip1Opening(object sender, CancelEventArgs e)
        {
            if (baseGridView1.SelectedRows.Count == 0)
                e.Cancel = true;
        }

        private void DeleteToolStripMenuItemClick(object sender, EventArgs e)
        {
            Entity entity = null;
            if (baseGridView1.SelectedRows.Count > 0)
            {
                entity = (Entity)baseGridView1.SelectedRows[0].DataBoundItem;
                EntityFormService.Delete(entity);
                Loadgrid();
            }
        }

 

    
    }
}

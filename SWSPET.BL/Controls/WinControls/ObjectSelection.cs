using System;
using System.ComponentModel;
using System.Windows.Forms;
using SWSPET.BL.Infrastructure;

namespace SWSPET.BL.Controls.WinControls
{
    public partial class ObjectSelection : UserControl
    {
        public ObjectSelection()
        {
            InitializeComponent();
           
        }

        

        private void Button1Click(object sender, EventArgs e)
        {
            var form = new ObjectSelectionList();
            var type = ListType;
            form.InitGrid(type);
            form.LoadGrid();
            

            form.StartPosition = FormStartPosition.CenterParent;
            //form.Location = new Point(form.Location.X + ((TableLayoutPanel)Parent).GetColumnWidths()[c.Column], form.Location.Y + ((TableLayoutPanel)Parent).GetRowHeights()[c.Row]);
            //form.Location = new Point(50,800);
            //form.DesktopLocation = new Point(1, 1);
            form.ShowDialog();

            SelectedItem = form.SelectedObject;
            //comboBox1.DisplayMember = "Descriptor";
        }

        public Type ListType { get; set; }

        private object _selectedItem;
        [Bindable(BindableSupport.Yes,BindingDirection.TwoWay)]
        public object SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                if(value == DBNull.Value)
                {
                    _selectedItem = null;
                    textBox1.Clear();
                    
                }
                else
                {
                    _selectedItem = value;
                    if (_selectedItem != null) textBox1.Text = ((Entity) _selectedItem).Descriptor;
                    else textBox1.Clear();
                }
                InvokeSelectedItemChanged(new EventArgs());
                
            }
        }

        public event SelectedItemChanged SelectedItemChanged;

        public void InvokeSelectedItemChanged(EventArgs eventargs)
        {
            SelectedItemChanged handler = SelectedItemChanged;
            if (handler != null) handler(this, eventargs);
        }
    }

    public delegate void SelectedItemChanged(object sender, EventArgs eventArgs);
}

using System.Collections.Generic;
using System.Windows.Forms;
using SWSPET.BL.Infrastructure;

namespace SWSPET.BL.Controls.WinControls
{
    public partial class UiPart : UserControl, IUiPart
    {
        public UiPart()
        {
            InitializeComponent();
        }
        public virtual FormWindowState WindowState
        {
            get
            {
                return FormWindowState.Normal;
            }
        }
        private object _objectInstance;
        public object ObjectInstance
        {
            get
            {
                return _objectInstance;
            } 
            set
            {
                bindingSource1.DataSource = value; 
                _objectInstance = value;
            }
        }
        public virtual IEnumerable<string> UiValidate()
        {
            return new List<string>();
        }
        public virtual void OnSave()
        {
            DataAccess.Flush();
        }
        public virtual void OnCurrentChanged(object oldInstance, object newInstance)
        {
            
        }
    }
}

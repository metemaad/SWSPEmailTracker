using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using SWSPET.BL.Infrastructure;

namespace SWSPET.BL.Controls.WinControls
{
    public partial class BaseGridView : DataGridView
    {
        public BaseGridView()
        {
            InitializeComponent();
        }
        public string HiddenColumns { get; set; }
        //public void InitilizeGrid(IList<ServiceParameters> type)
        //{
        //    this.Columns.Clear();
        //    foreach (DataGridViewTextBoxColumn col in
        //        type.Select(sp => new DataGridViewTextBoxColumn {HeaderText = sp.ParamName, DataPropertyName = sp.ParamName}))
        //    {
        //        this.Columns.Add(col);
        //    }
        //}
        //public void FillBylist(IList<PublicService> l1) 
        //{
        //    this.Rows.Clear();
        //    foreach (var a in l1) 
        //    {
        //        var r1 = new DataGridViewRow();
        //        foreach(var s in a.ServiceParametersValuelist)
        //        {
        //            var c1=new DataGridViewTextBoxCell {Value = s.Value};
        //            r1.Cells.Add(c1);
        //        }
        //        var add = this.Rows.Add(r1);
        //    }
        //}
        
        public void InitilizeGrid(Type type)
        {
            this.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.Columns.Clear();
            this.AutoGenerateColumns = false;
            var propInfos = type.GetProperties();
            foreach (var prop in propInfos)
            {
                if (HiddenColumns!=null)
                {
                    var hiddenCols = HiddenColumns.Split(',');
                    if (hiddenCols.Contains(prop.Name))
                        continue;
                }
                var att = prop.GetCustomAttributes(typeof(DisplayNameAttribute),true);
                var att2 = prop.GetCustomAttributes(typeof(AutoSizeAttribute), true);
                var att3 = prop.GetCustomAttributes(typeof(BoldColumnAttribute), true);
                if (att.Length > 0)
                {
                    string disName = ((DisplayNameAttribute)att[0]).DisplayName;
                    var t = prop.DeclaringType.IsGenericType ? prop.PropertyType.GetGenericTypeDefinition() : prop.PropertyType;
                    DataGridViewColumn col = new DataGridViewTextBoxColumn {ValueType = t};
                    if (att2.Length > 0)
                    {
                        var autoSize = ((AutoSizeAttribute)att2[0]).AutoSizeMode;
                        col.AutoSizeMode = autoSize;
                    }
                    col.HeaderText = disName;
                    col.DataPropertyName = prop.Name;
                    
                        if (att3.Length > 0)
                    {
                        var fontstyle = ((BoldColumnAttribute)att3[0]).FontStyle;
                        var fontname = ((BoldColumnAttribute)att3[0]).FontName;
                        var fontSize = ((BoldColumnAttribute)att3[0]).FontSize;

                        var forecolor= ((BoldColumnAttribute)att3[0]).ForeColor;
                        col.DefaultCellStyle.Font = new Font(fontname, fontSize, fontstyle);
                        col.DefaultCellStyle.ForeColor = forecolor;
                    }
                    this.Columns.Add(col);
                }
            }
        }
    }
}

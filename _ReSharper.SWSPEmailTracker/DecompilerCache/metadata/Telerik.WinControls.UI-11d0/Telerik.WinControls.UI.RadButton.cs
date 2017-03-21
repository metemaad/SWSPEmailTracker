// Type: Telerik.WinControls.UI.RadButton
// Assembly: Telerik.WinControls.UI, Version=2011.2.11.712, Culture=neutral, PublicKeyToken=5bb2a467cbec794e
// Assembly location: C:\Program Files (x86)\Telerik\RadControls for WinForms Q2 2011\Bin\Telerik.WinControls.UI.dll

using System.ComponentModel;
using System.Windows.Forms;
using Telerik.WinControls.Themes.Design;

namespace Telerik.WinControls.UI
{
    [DefaultProperty("Text")]
    [ToolboxItem(true)]
    [RadThemeDesignerData(typeof (RadButtonDesignTimeData))]
    [Description("Responds to user clicks.")]
    [DefaultBindingProperty("Text")]
    [DefaultEvent("Click")]
    public class RadButton : RadButtonBase, IButtonControl
    {
        #region IButtonControl Members

        public void NotifyDefault(bool value);

        [DefaultValue(0)]
        public DialogResult DialogResult { get; set; }

        #endregion
    }
}

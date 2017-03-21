using System;
using System.Windows.Forms;

namespace SWSPET.BL.Infrastructure
{
    public class AutoSizeAttribute : Attribute
    {
        public AutoSizeAttribute()
        {
            AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
        }

        public AutoSizeAttribute(DataGridViewAutoSizeColumnMode autoSizeMode)
        {
            AutoSizeMode = autoSizeMode;
        }
        public DataGridViewAutoSizeColumnMode AutoSizeMode { get; set; }
    }
}

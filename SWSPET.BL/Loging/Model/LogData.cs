using System;
using System.ComponentModel;
using System.Windows.Forms;
using SWSPET.BL.Infrastructure;
using SWSPET.BL.Login.Model;

namespace SWSPET.BL.Loging.Model
{
    public class LogData : Entity<LogData>
    {
        
        public virtual string ObjectType { get; set; }
        

        public virtual DateTime LogDate { get; set; }
        
        public virtual User User { get; set; }

        [DisplayName("کاربر")]

        [AutoSize(DataGridViewAutoSizeColumnMode.DisplayedCells)]
        public virtual string Userdes { get { return User.FirstName + " " + User.LastName; } }

        [DisplayName("شرح ویرایش")]

        [AutoSizeAttribute(DataGridViewAutoSizeColumnMode.DisplayedCells)]
        public virtual string Txt { get; set; }
        

        public virtual string Guid { get; set; }

        public virtual LogType Type { get; set; }


        [DisplayName("تاریخ ")]
        [AutoSizeAttribute(DataGridViewAutoSizeColumnMode.DisplayedCells)]
        public virtual string PersianEmployeeDate
        {
            get
            {
                return FarsiLibrary.Utils.PersianDateConverter.ToPersianDate(LogDate).ToString("yyyy/MM/dd");
            }
        }

        [DisplayName("ساعت ")]
        [AutoSizeAttribute(DataGridViewAutoSizeColumnMode.DisplayedCells)]
        public virtual string PersianEmployeetime
        {
            get
            {
                return LogDate.ToShortTimeString();
            }
        }

    }
}

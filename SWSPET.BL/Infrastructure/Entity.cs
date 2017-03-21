using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using NHibernate;
using NHibernate.Linq;
using SWSPET.BL.Login.Model;
using SWSPET.BL.Loging.Model;

namespace SWSPET.BL.Infrastructure
{
    

    public abstract class Entity<T> : IPersistable where T : Entity<T>
    {
        private int? _oldHashCode;
        public virtual Guid Id { get; private set; }
        private bool _isActive = true;
        public virtual bool IsActive
        {
            get { return _isActive; }
            set { _isActive = value; }
        }
        public override bool Equals(object obj)
        {
            var other = obj as T;
            if (other == null) return false;
            var thisIsNew = Equals(Id, Guid.Empty);
            var otherIsNew = Equals(other.Id, Guid.Empty);
            if (thisIsNew && otherIsNew)
                return ReferenceEquals(this, other);
            return Id.Equals(other.Id);
        }
        public override int GetHashCode()
        {
            if (_oldHashCode.HasValue) return _oldHashCode.Value;
            var thisIsNew = Equals(Id, Guid.Empty);
            if (thisIsNew)
            {
                _oldHashCode = base.GetHashCode();
                return _oldHashCode.Value;
            }
            return Id.GetHashCode();
        }
        public static bool operator ==(Entity<T> lhs, Entity<T> rhs)
        {
            return Equals(lhs, rhs);
        }
        public static bool operator !=(Entity<T> lhs, Entity<T> rhs)
        {
            return !Equals(lhs, rhs);
        }
        private static ISession NhSession { get { return DataAccess.NhSession; } }
        public virtual bool Persist(ISession PS)
        {
            //PS = DataAccess.SessionFactory.OpenSession();
            using (var tr = PS.BeginTransaction())
            {
                try
                {
                    LogUpdate();
                    PS.SaveOrUpdate(this);
                    tr.Commit();
                }
                catch (Exception e)
                {
                    tr.Rollback();
                    throw;
                }
                return true;
            }
        }
        public virtual bool Persist()
        {
            using (var tr = NhSession.BeginTransaction())
            {
                try
                {
                   // LogUpdate();
                    NhSession.SaveOrUpdate(this);
                    tr.Commit();
                }
                catch (Exception e)
                {
                    tr.Rollback();
                    throw;
                }
                return true;
            }
        }
        public virtual bool PersistL()
        {
            NhSession.SaveOrUpdate(this);
            return true;
        }
        public virtual bool Delete()
        {
            //var log = Delprop();
            //var l = new LogData
            //{
            //    LogDate = DateTime.Now,
            //    Txt = log,
            //    Type = LogType.Remove,
            //    User = User.Currentuser,
            //    ObjectType = this.GetType().ToString(),
            //    Guid = this.Id.ToString()
            //};
            //l.PersistL();
            NhSession.Delete(this);
            NhSession.Flush();
            return true;
        }
        public static List<L> LoadAll<L>()
        {
            List<L> list = NhSession.Query<L>().ToList();
            return list;
        }
        public virtual T Clone()
        {
            return MemberwiseClone() as T;
        }
        public static IList<T> LoadList(Func<T, bool> predicate)
        {
            List<T> list = NhSession.Query<T>().Where(predicate).ToList();
            return list;
        }
        public virtual IList<string> Validate()
        {
            var invalidValues = DataAccess.Validator.Validate(this);
            var errors = invalidValues.Select(x => x.Message).ToList();
            errors.AddRange(CustomValidation());
            return errors;
        }


        public virtual IList<string> Validate(params object[] activeTags)
        {
            var invalidValues = DataAccess.Validator.Validate(this, activeTags);
            var errors = invalidValues.Select(x => x.Message).ToList();
            errors.AddRange(CustomValidation());
            return errors;
        }
        public virtual IEnumerable<string> CustomValidation()
        {
            return new List<string>();
        }
        private string Delprop()
        {
            var aa = "";
            var newT = (T)this;
            aa = " حذف \r\n";
            var proi = newT.GetType().GetProperties();
            foreach (System.Reflection.PropertyInfo a in proi)
            {
                var att = a.GetCustomAttributes(typeof(LogableAttribute), true);
                bool disName = att.Count() <= 0 ? false : ((LogableAttribute)att[0]).LogableMode;
                if (disName)
                {
                    string newt = newT.GetType().InvokeMember(a.Name, System.Reflection.BindingFlags.GetProperty, null, newT, null) != null ? newT.GetType().InvokeMember(a.Name, System.Reflection.BindingFlags.GetProperty, null, newT, null).ToString() : string.Empty;
                    var att1 = a.GetCustomAttributes(typeof(DisplayNameAttribute), true);
                    string disName1 = att1.Count() <= 0 ? string.Empty : ((DisplayNameAttribute)att1[0]).DisplayName;
                    aa += "-" + disName1 + ":" + newt + "\r\n";
                }
            }
            return aa.Substring(0, Math.Min(4000, aa.Length));
        }
        private string Saveprop(T old)
        {
            var aa = "";
            if (old == null)
            {
                var newT = (T)this;
                aa = " ایجاد \r\n";
                var proi = newT.GetType().GetProperties();
                foreach (System.Reflection.PropertyInfo a in proi)
                {
                    var att = a.GetCustomAttributes(typeof(LogableAttribute), true);
                    bool disName = att.Count() <= 0 ? false : ((LogableAttribute)att[0]).LogableMode;
                    if (disName)
                    {
                        string newt = newT.GetType().InvokeMember(a.Name, System.Reflection.BindingFlags.GetProperty, null, newT, null) != null ? newT.GetType().InvokeMember(a.Name, System.Reflection.BindingFlags.GetProperty, null, newT, null).ToString() : string.Empty;
                        var att1 = a.GetCustomAttributes(typeof(DisplayNameAttribute), true);
                        string disName1 = att1.Count() <= 0 ? string.Empty : ((DisplayNameAttribute)att1[0]).DisplayName;
                        aa += "-" + disName1 + "=>" + newt + "\r\n";
                    }
                }
            }
            else
            {
                var newT = (T)this;
                aa = " " + ((T)old).Descriptor.ToString() + "\r\n";
                var proi = old.GetType().GetProperties();
                foreach (System.Reflection.PropertyInfo a in proi)
                {
                    var att = a.GetCustomAttributes(typeof(LogableAttribute), true);
                    bool disName = att.Count() <= 0 ? false : ((LogableAttribute)att[0]).LogableMode;
                    if (disName)
                    {
                        string newt = old.GetType().InvokeMember(a.Name, System.Reflection.BindingFlags.GetProperty, null, newT, null) != null ? old.GetType().InvokeMember(a.Name, System.Reflection.BindingFlags.GetProperty, null, newT, null).ToString() : string.Empty;
                        string oldt = old.GetType().InvokeMember(a.Name, System.Reflection.BindingFlags.GetProperty, null, old, null) != null ? old.GetType().InvokeMember(a.Name, System.Reflection.BindingFlags.GetProperty, null, old, null).ToString() : string.Empty;
                        if (oldt != newt)
                        {
                            var att1 = a.GetCustomAttributes(typeof(DisplayNameAttribute), true);
                            string disName1 = att1.Count() <= 0 ? string.Empty : ((DisplayNameAttribute)att1[0]).DisplayName;
                            aa += "-" + disName1 + ":" + oldt + " => " + newt + "\r\n";
                        }
                    }
                }
            }
            return aa.Substring(0, Math.Min(4000, aa.Length));
        }

        private T _oldv;

        public virtual void SetOldv(T oldv)
        {
            _oldv = oldv;
        }
        public virtual T GetOldV()
        {
            return _oldv;
        }



        public virtual void LogUpdate()
        {
            if (_oldv == null)
            {
                var logtxt = Saveprop(_oldv);
                var l = new LogData
                {
                    Type = LogType.Insert,
                    LogDate = DateTime.Now,
                    Txt = logtxt,
                    User = User.Currentuser,
                    ObjectType = this.GetType().ToString(),
                    Guid = this.Id.ToString()
                };
                l.PersistL();
            }
            else
            {
                var logtxt = Saveprop(_oldv);
                var l = new LogData
                {
                    Type = LogType.Edit,
                    LogDate = DateTime.Now,
                    Txt = logtxt,
                    User = User.Currentuser,
                    ObjectType = this.GetType().ToString(),
                    Guid = this.Id.ToString()

                };
                l.PersistL();
            }
        }
        public virtual string Descriptor { get { return Id.ToString(); } }
    }
    public abstract class Entity : Entity<Entity>
    {
        public abstract string TypeDesc { get; }
        
    }
}

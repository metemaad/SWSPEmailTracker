using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SWSPET.BL.Controls.WinControls;
using SWSPET.BL.Infrastructure;

namespace SWSPET.BL.Controls
{
    public static class EntityFormService
    {
        public static void New<T>(bool modal ,bool fetch) where T : Entity
        {
            var obj = Activator.CreateInstance<T>();
            if(obj is IConfigurable)
            {
                var configurable = obj as IConfigurable;
                foreach (var param in ExtendedParameters)
                {
                    configurable.Configure(param);
                }
            }
            var att =(ObjectViewAttribute) Attribute.GetCustomAttribute(obj.GetType(), typeof (ObjectViewAttribute));
            //var type =att.UIPartType;
            
            if (fetch)
            {
                var uiPart = (UiPart)Activator.CreateInstance(att.FetchUIPartType);
                uiPart.ObjectInstance = obj;
                var form = new MainFormDataEntry();
                form.IncludeUiPart(uiPart);

                if (modal)
                    form.ShowDialog();
                else
                    form.Show();

            }
            else
            {
                var uiPart = (UiPart)Activator.CreateInstance(att.ListUIPartType);
                uiPart.ObjectInstance = obj;
                var form = new MainForm();
                form.IncludeUiPart(uiPart);
                form.WindowState = FormWindowState.Maximized;
                uiPart.Dock = DockStyle.Fill;

                if (modal)
                    form.ShowDialog();
                else
                    form.Show();

            }

            
        }
        public static void New<T>(bool modal, bool fetch,Dictionary<string,object> dictionary ) where T : Entity
        {
            var obj = Activator.CreateInstance<T>();
            if (obj is IConfigurable)
            {
                var configurable = obj as IConfigurable;
                foreach (var param in ExtendedParameters)
                {
                    configurable.Configure(param);
                }
                configurable.Configure(dictionary);
            }
            var att = (ObjectViewAttribute)Attribute.GetCustomAttribute(obj.GetType(), typeof(ObjectViewAttribute));
            //var type =att.UIPartType;

            if (fetch)
            {
                var uiPart = (UiPart)Activator.CreateInstance(att.FetchUIPartType);
                uiPart.ObjectInstance = obj;
                var form = new MainFormDataEntry();
                form.IncludeUiPart(uiPart);

                if (modal)
                    form.ShowDialog();
                else
                    form.Show();

            }
            else
            {
                var uiPart = (UiPart)Activator.CreateInstance(att.ListUIPartType);
                uiPart.ObjectInstance = obj;
                var form = new MainForm();
                form.IncludeUiPart(uiPart);
                form.WindowState = FormWindowState.Maximized;
                uiPart.Dock = DockStyle.Fill;

                if (modal)
                    form.ShowDialog();
                else
                    form.Show();

            }


        }

        private static readonly List<Entity> _extendedParameters = new List<Entity>();
        private static List<Entity> ExtendedParameters
        {
            get { return _extendedParameters; }
        }

        public static void ClearParameters()
        {
            ExtendedParameters.Clear();
        }

        public static void AddToExtendedParameters(Entity entity)
        {
            if(!ExtendedParameters.Contains(entity))
                ExtendedParameters.Add(entity);
        }

        public static void ClearAndAddToExtendedParameters(Entity entity)
        {
            ClearParameters();
            AddToExtendedParameters(entity);
        }

        public static object NewDialog(Type newType)
        {
            var obj = Activator.CreateInstance(newType);
            var att =(ObjectViewAttribute)Attribute.GetCustomAttribute(obj.GetType(), typeof(ObjectViewAttribute));
            //var type = Type.GetType(att.UIPart);
            var uiPart = (UiPart)Activator.CreateInstance(att.FetchUIPartType);
            uiPart.ObjectInstance = obj;
            var form = new MainFormDataEntry();
            form.IncludeUiPart(uiPart);
            form.ShowDialog();
            return form.InnerInstance;
        }

        public static void Edit<T>(T entity) where T : Entity
        {
            var obj = entity;
            var att = (ObjectViewAttribute)Attribute.GetCustomAttribute(obj.GetType(), typeof(ObjectViewAttribute));
            //var type = Type.GetType(att.UIPart);
            var uiPart = (UiPart)Activator.CreateInstance(att.FetchUIPartType);
            uiPart.ObjectInstance = obj;
            var form = new MainFormDataEntry();
            form.IncludeUiPart(uiPart);
            form.ShowEditDialog();
        }

        public static void Delete<T>(T entity) where T : Entity
        {
            //entity.IsActive = false;
            //entity.Persist();
            try
            {
                entity.Delete();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        
    }
}

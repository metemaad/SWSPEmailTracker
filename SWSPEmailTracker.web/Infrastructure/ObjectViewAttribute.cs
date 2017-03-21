using System;

namespace SWSPEmailTracker.web.Infrastructure
{
    public class ObjectViewAttribute : Attribute
    {
        //public string UIPart { get; set; }
        public Type ListUIPartType { get; set; }
        public Type FetchUIPartType { get; set; }

        //public ObjectViewAttribute(string uiPart)
        //{
        //    UIPart = uiPart;
        //}

        public ObjectViewAttribute(Type listuiPart,Type fetchuiPart)
        {
            ListUIPartType = listuiPart;
            FetchUIPartType = fetchuiPart;
        }



    }
}

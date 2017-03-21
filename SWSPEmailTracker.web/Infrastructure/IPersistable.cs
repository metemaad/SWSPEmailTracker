using System.Collections.Generic;

namespace SWSPEmailTracker.web.Infrastructure
{
    public interface IPersistable
    {
        bool Persist();
        bool Delete();
        IList<string> Validate();
    }
}
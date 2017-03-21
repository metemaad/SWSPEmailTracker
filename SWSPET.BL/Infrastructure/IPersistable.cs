using System.Collections.Generic;

namespace SWSPET.BL.Infrastructure
{
    public interface IPersistable
    {
        bool Persist();
        bool Delete();
        IList<string> Validate();
    }
}
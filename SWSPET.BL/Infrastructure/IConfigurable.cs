using System.Collections.Generic;

namespace SWSPET.BL.Infrastructure
{
    public interface IConfigurable
    {
        void Configure(Entity container);
        void Configure(Dictionary<string,object> dictionary  );
    }
}
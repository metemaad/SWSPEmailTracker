using System.Collections.Generic;

namespace SWSPEmailTracker.web.Infrastructure
{
    public interface IConfigurable
    {
        void Configure(Entity container);
        void Configure(Dictionary<string,object> dictionary  );
    }
}
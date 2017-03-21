using FluentNHibernate.Mapping;
using SWSPET.BL.Login.Model;

namespace SWSPET.BL.Login.Mapping
{
       public class UserMap : ClassMap<User>
    {
           public UserMap()
        {
            Id(x => x.Id).GeneratedBy.GuidComb();
            Map(x => x.FirstName);
            Map(x => x.LastName);
            Map(x => x.UserName);
            Map(x => x.PasswordHash);
        }
    }
}

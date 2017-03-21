using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Conventions.Inspections;
using FluentNHibernate.Mapping;
using NHibernate.Criterion;
using SWSPET.BL.SWSPET.Model;

namespace SWSPET.BL.SWSPET.Mapping
{


    public class PersonMap : ClassMap<Person>
    {
        public PersonMap()
        {
            Id(x => x.Id);
            Map(x => x.Name).Index("PersonNameIndex");
            Map(x => x.GivenName).Index("PersonGivenNameIndex");
            Map(x => x.AdditionalName).Index("PersonAdditionalNameIndex");
            Map(x => x.FamilyName).Index("PersonFamilyNameIndex");
            Map(x => x.YomiName).Index("PersonYomiNameIndex");
            Map(x => x.GivenNameYomi).Index("PersonGivenNameYomiIndex");
            Map(x => x.AdditionalNameYomi).Index("PersonAdditionalNameYomiIndex");
            Map(x => x.FamilyNameYomi).Index("PersonFamilyNameYomiIndex");
            Map(x => x.NamePrefix).Index("PersonNamePrefixIndex");
            Map(x => x.NameSuffix).Index("PersonNameSuffixIndex");
            Map(x => x.Initials).Index("PersonInitialsIndex");
            Map(x => x.Nickname).Index("PersonNicknameIndex");
            Map(x => x.ShortName).Index("PersonShortNameIndex");
            Map(x => x.Birthday).Index("PersonBirthdayIndex");
            Map(x => x.Gender).Index("PersonGenderIndex");
            Map(x => x.Location).Index("PersonLocationIndex");
            Map(x => x.BillingInformation).Index("PersonBillingInformationIndex");
            Map(x => x.Mileage).Index("PersonMileageIndex");
            Map(x => x.MaidenName).Index("PersonMaidenNameIndex");
            Map(x => x.DirectoryServer).Index("PersonDirectoryServerIndex");
            Map(x => x.Occupation).Index("PersonOccupationIndex");
            Map(x => x.Hobby).Index("PersonHobbyIndex");
            Map(x => x.Sensitivity).Index("PersonSensitivityIndex");
            Map(x => x.Priority).Index("PersonPriorityIndex");
            Map(x => x.Subject).Index("PersonSubjectIndex");
            Map(x => x.Notes).Index("PersonNotesIndex");
            Map(x => x.GroupMembership).Index("PersonGroupMembershipIndex");
            
            HasMany(x => x.Phones).LazyLoad().Cascade.All();
            HasMany(x => x.IMs).LazyLoad().Cascade.All();
            HasMany(x => x.Addresses).LazyLoad().Cascade.All();
            HasMany(x => x.Websites).LazyLoad().Cascade.All();
            HasMany(x => x.Emails).LazyLoad().Cascade.All();
        }
    }
}

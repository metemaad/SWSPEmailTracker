using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SWSPET.BL.Infrastructure;

namespace SWSPET.BL.SWSPET.Model
{
    public class Person:Entity 
    {
        public virtual SWSPVCard.vCard Vcard { get; set; }

        public virtual string SendingName { get
        {
            string s = Name + " " + FamilyName;
            
            return s;

        }
        }
        [DisplayName("Name")]
        public virtual string Name { get; set; }
        [DisplayName("Given Name")]
        public virtual string GivenName { get; set; }
        [DisplayName("Additional Name")]
        public virtual string AdditionalName { get; set; }
        [DisplayName("Family Name")]
        public virtual string FamilyName { get; set; }
        [DisplayName("YomiName")]
        public virtual string YomiName { get; set; }
        [DisplayName("GivenNameYomi")]
        public virtual string GivenNameYomi { get; set; }
        [DisplayName("AdditionalNameYomi")]
        public virtual string AdditionalNameYomi { get; set; }
        [DisplayName("FamilyNameYomi")]
        public virtual string FamilyNameYomi { get; set; }
        [DisplayName("NamePrefix")]
        public virtual string NamePrefix { get; set; }
        [DisplayName("NameSuffix")]
        public virtual string NameSuffix { get; set; }
        [DisplayName("Initials")]
        public virtual string Initials { get; set; }
        [DisplayName("Nickname")]
        public virtual string Nickname { get; set; }
        [DisplayName("ShortName")]
        public virtual string ShortName { get; set; }
        [DisplayName("Birthday")]
        public virtual string Birthday { get; set; }
        [DisplayName("Gender")]
        public virtual string Gender { get; set; }
        [DisplayName("Location")]
        public virtual string Location { get; set; }
        [DisplayName("BillingInformation")]
        public virtual string BillingInformation { get; set; }
        [DisplayName("MaidenName")]
        public virtual string MaidenName { get; set; }


        [DisplayName("DirectoryServer")]
        public virtual string DirectoryServer { get; set; }
        [DisplayName("Mileage")]
        public virtual string Mileage { get; set; }
        [DisplayName("Occupation")]
        public virtual string Occupation { get; set; }
        
        [DisplayName("Hobby")]
        public virtual string Hobby { get; set; }
        [DisplayName("Sensitivity")]
        public virtual string Sensitivity { get; set; }
        [DisplayName("Priority")]
        public virtual string Priority { get; set; }
        [DisplayName("Subject")]
        public virtual string Subject { get; set; }
        [DisplayName("Notes")]
        public virtual string Notes { get; set; }
        [DisplayName("Group Membership")]
        public virtual string GroupMembership { get; set; }
        [AutoSize(DataGridViewAutoSizeColumnMode.AllCells)]
        [DisplayName("Descriptor")]
        public override string Descriptor
        {
            get { 
                string s=" <" +Name + " " + FamilyName+"  ";
                return Emails.Aggregate(s, (current, email) => current +" "+ email.Value)+" > ";
            }
        }
        [DisplayName("Has Email")]
        public virtual bool Hasemail
        {
            get
            {
                bool a = false;
                if (Emails.Count>0)
                {
                    a = true;
                }
                return a;
            }
        }
        private IList<Email> _emailItems;
        public virtual IList<Email> Emails
        {
            get { return _emailItems ?? (_emailItems = new List<Email>()); }
            set { _emailItems = value; }
        }

        private IList<IM> _imItems;
        public virtual IList<IM> IMs
        {
            get { return _imItems ?? (_imItems = new List<IM>()); }
            set { _imItems = value; }
        }

        private IList<Phone> _phoneItems;
        public virtual IList<Phone> Phones
        {
            get { return _phoneItems ?? (_phoneItems = new List<Phone>()); }
            set { _phoneItems = value; }
        }


        private IList<Address> _addressItems;
        public virtual IList<Address> Addresses
        {
            get { return _addressItems ?? (_addressItems = new List<Address>()); }
            set { _addressItems = value; }
        }


        private IList<Organization> _organizationItems;
        public virtual IList<Organization> Organizations
        {
            get { return _organizationItems ?? (_organizationItems = new List<Organization>()); }
            set { _organizationItems = value; }
        }


        private IList<Website> _websiteItems;
        public virtual IList<Website> Websites
        {
            get { return _websiteItems ?? (_websiteItems = new List<Website>()); }
            set { _websiteItems = value; }
        }
        
        public override string TypeDesc
        {
            get { return "Person"; }
        }
    }
}

using System;
using System.IO;
using System.Net;

using System.Linq;
using NHibernate.Linq;
using SWSPET.BL.Infrastructure;
using System.Xml;


namespace SWSPET.BL.SWSPET.Model
{
    public class IPInfo : Entity
    {
        public virtual string IP { get; set; }
        public virtual string CountryCode { get; set; }
        public virtual string CountryName { get; set; }
        public virtual string RegionCode { get; set; }
        public virtual string RegionName { get; set; }
        public virtual string City { get; set; }
        public virtual string ZipCode { get; set; }
        public virtual string Latitude { get; set; }
        public virtual string Longitude { get; set; }
        public virtual string MetroCode { get; set; }
        public virtual string AreaCode { get; set; }




        public virtual void UpdateIPInformation(string ip)
        {
            




            try
            {
                var request =WebRequest.Create("http://freegeoip.net/xml/" + ip);
                var response = request.GetResponse();
                using (var responseStream = response.GetResponseStream())
                {
                    var doc = new XmlDocument();
                    doc.Load(responseStream);
                    var root = doc.DocumentElement;
                    if (root != null)
                        foreach (XmlNode variable in root)
                        {
                            switch (variable.Name)
                            {
                                case "Ip":
                                    IP = variable.InnerText;
                                    break;
                                case "CountryCode":
                                    CountryCode = variable.InnerText;
                                    break;
                                case "CountryName":
                                    CountryName = variable.InnerText;
                                    break;
                                case "RegionCode":
                                    RegionCode = variable.InnerText;
                                    break;
                                case "RegionName":
                                    RegionName = variable.InnerText;
                                    break;
                                case "City":
                                    City = variable.InnerText;
                                    break;
                                case "ZipCode":
                                    ZipCode = variable.InnerText;
                                    break;
                                case "Latitude":
                                    Latitude = variable.InnerText;
                                    break;
                                case "Longitude":
                                    Longitude = variable.InnerText;
                                    break;
                                case "MetroCode":
                                    MetroCode = variable.InnerText;
                                    break;
                                case "AreaCode":
                                    AreaCode = variable.InnerText;
                                    break;
                            }
                        }
                }
            }
            catch (Exception ex)
            {
                IP = ip;
                CountryName = "Error";
            }
        }
        public override string Descriptor
        {
            get
            {
                return CountryCode+" "+RegionCode+" "+RegionName+" "+City+" "+AreaCode;
            }
        }
        public override string TypeDesc
        {
            get { return ""; }
        }
    }
}
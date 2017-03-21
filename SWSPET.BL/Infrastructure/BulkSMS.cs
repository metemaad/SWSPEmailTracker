using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Net;
using System.IO;

namespace SWSPET.BL.Infrastructure
{
    public class BulkSMS
    {
        public string SendMessageByclickatell(string user,string password,string apiID,string to,string text)
        {
            var client = new WebClient();
            client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
            client.QueryString.Add("user", user);
            client.QueryString.Add("password", password);
            client.QueryString.Add("api_id", apiID);
            client.QueryString.Add("to", to);
            client.QueryString.Add("text", text);
            const string baseurl = "http://api.clickatell.com/http/sendmsg";
            var data = client.OpenRead(baseurl);
            var reader = new StreamReader(data);
            var s = reader.ReadToEnd();
            data.Close();
            reader.Close();
            return (s);

        }

        public string SendMessageByOpilo(string username, string password, string from, string to, string text)
        {
            var s = @"http://webservice.opilo.com/WS/httpsend/?username=" + username + "&password=" + password +
                    "&from=" + from + "&to=" + to + "&text=" + text;
          
            return (s);

        }
    }
}

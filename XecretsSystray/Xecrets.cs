using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Web.Script.Serialization;


namespace XecretsSystray
{
    class Xecrets
    {
        private string m_username;
        private string m_passphraseBase64;
        private string m_serviceUrl = "https://www.axantum.com/Xecrets/RestApi.ashx";

        public Xecrets(String username, SecureString password)
        {
            m_username = username;
            m_passphraseBase64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(SecureStringToString(password).Trim()));
        }


        private static String SecureStringToString(SecureString value)
        {
            IntPtr bstr = Marshal.SecureStringToBSTR(value);

            try
            {
                return Marshal.PtrToStringBSTR(bstr);
            }
            finally
            {
                Marshal.FreeBSTR(bstr);
            }
        }

        
        public List<Secret> DownloadListOfSecrets()
        {
            WebRequest req = CreateApiRequest("/list");

            WebResponse resp = req.GetResponse();
            string response = new System.IO.StreamReader(resp.GetResponseStream(), Encoding.UTF8).ReadToEnd();

            var secrets = DeserializeListOfSecrets(response);
            Console.Out.WriteLine("Downloaded {0} secrets.", secrets.Count);
            return secrets;
        }


        private WebRequest CreateApiRequest(string call)
        {
            WebRequest req = HttpWebRequest.Create(m_serviceUrl + call);
            req.Headers["Authorization"] =
                "Basic " + Convert.ToBase64String(Encoding.UTF8.GetBytes(m_username + ":" + m_passphraseBase64));
            return req;
        }


        private List<Secret> DeserializeListOfSecrets(string response)
        {
            var jsonDecoder = new System.Web.Script.Serialization.JavaScriptSerializer();
            var tcl = jsonDecoder.Deserialize<Dictionary<string, object>>(response);
            System.Collections.ArrayList items = (System.Collections.ArrayList)tcl["TCL"];

            var secrets = new List<Secret>();
            foreach (var item in items)
            {
                Dictionary<string, object> values = (Dictionary<string, object>)item;
                string title = values["T"].ToString();
                string content = values["C"].ToString();
                string guid = values["G"].ToString();
                secrets.Add(new Secret(title, content, guid));
            }

            return secrets;
        }


        public String FetchSecret(Secret secret)
        {
            if (secret == null)
            {
                return null;
            }

            Console.Out.WriteLine("Fetching secret for '{0}'...", secret);
            WebRequest req = CreateApiRequest("/secret/" + secret.m_guid);

            try
            {
                WebResponse resp = req.GetResponse();
                string response = new System.IO.StreamReader(resp.GetResponseStream(), Encoding.UTF8).ReadToEnd();

                var secretString = DeserializeSecret(response);
                return secretString;
            }
            catch (WebException exception)
            {
                Console.Out.WriteLine("Error: {0}", exception.Message);
            }

            return null;
        }


        private string DeserializeSecret(string response)
        {
            var jsonDecoder = new System.Web.Script.Serialization.JavaScriptSerializer();
            var sec = jsonDecoder.Deserialize<Dictionary<string, object>>(response);

            string secret = (string)sec["X"];
            return secret;
        }
    }
}

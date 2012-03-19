using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Web.Script.Serialization;

namespace XecretsSystray
{
    class Xecrets
    {
        private string m_username;
        private string m_passphraseBase64;
        private string m_serviceUrl = "https://www.axantum.com/Xecrets/RestApi.ashx";

        public Xecrets()
        {
            ReadCredentials();
        }


        private void ReadCredentials()
        {
            m_username = "carl.seleborg@gmail.com";

            System.IO.FileStream stream = new System.IO.FileStream(
                "C:\\Temp\\passphrase.txt", System.IO.FileMode.Open);

            byte[] passphraseBytesUtf8 = new byte[stream.Length];
            stream.Read(passphraseBytesUtf8, 0, (int)stream.Length);
            string passphraseString = Encoding.UTF8.GetString(passphraseBytesUtf8).Trim();

            m_passphraseBase64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(passphraseString));
        }


        public List<Secret> DownloadListOfSecrets()
        {
            WebRequest req = CreateApiRequest("/list");

            try
            {
                WebResponse resp = req.GetResponse();
                string response = new System.IO.StreamReader(resp.GetResponseStream(), Encoding.UTF8).ReadToEnd();

                var secrets = DeserializeListOfSecrets(response);
                Console.Out.WriteLine("Downloaded {0} secrets.", secrets.Count);
                return secrets;
            }
            catch (WebException exception)
            {
                Console.Out.WriteLine("Error: {0}", exception.Message);
                return new List<Secret>();
            }
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

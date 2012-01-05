using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Web.Script.Serialization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace XecretsSystray
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string m_username;
        private string m_passphraseBase64;
        private string m_serviceUrl = "https://www.axantum.com/Xecrets/RestApi.ashx";
        private List<Secret> m_secrets = new List<Secret>();

        public MainWindow()
        {
            InitializeComponent();
            ReadCredentials();
            m_secrets = DownloadListOfSecrets();
        }


        private void ReadCredentials()
        {
            m_username = "carl.seleborg@gmail.com";
            
            System.IO.FileStream stream = new System.IO.FileStream(
                "C:\\Users\\Carl\\passphrase.txt", System.IO.FileMode.Open);

            byte[] passphraseBytesUtf8 = new byte[stream.Length];
            stream.Read(passphraseBytesUtf8, 0, (int)stream.Length);
            string passphraseString = Encoding.UTF8.GetString(passphraseBytesUtf8).Trim();

            Console.Out.WriteLine("'{0}'", passphraseString);
            m_passphraseBase64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(passphraseString));

            Console.Out.WriteLine("Username = {0}, Passphrase = {1}", m_username, m_passphraseBase64);
        }


        private List<Secret> DownloadListOfSecrets()
        {
            WebRequest req = HttpWebRequest.Create(m_serviceUrl + "/list");
            req.Headers["Authorization"] = 
                "Basic " + Convert.ToBase64String(Encoding.UTF8.GetBytes(m_username + ":" + m_passphraseBase64));

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
    }
}

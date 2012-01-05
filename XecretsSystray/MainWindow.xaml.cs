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
        private bool m_searchFieldShowsPrompt = true;
        private string m_filter;

        public MainWindow()
        {
            InitializeComponent();
            m_searchField.SelectAll();
            m_searchField.Focus();
            ReadCredentials();
            m_secrets = DownloadListOfSecrets();
            m_searchFieldShowsPrompt = false;
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


        private void textBox1_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (m_searchFieldShowsPrompt)
            {
                return;
            }

            TextBox box = (TextBox)sender;
            m_filter = box.Text;
            FilterResults();
        }

        
        private void FilterResults()
        {
            if (m_filter.Length == 0)
            {
                m_resultListView.ItemsSource = null;
            }
            else
            {
                m_resultListView.ItemsSource = m_secrets;
                string searchString = m_searchField.Text.ToLower();
                m_resultListView.Items.Filter = (s)=>
                {
                    var secret = (Secret)s;
                    return secret.m_title.ToLower().Contains(searchString)
                        || secret.m_content.ToLower().Contains(searchString);
                };
            }
        }

        private void m_resultListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            FetchSecret((Secret)m_resultListView.SelectedItem);
        }

        private void FetchSecret(Secret secret)
        {
            if (secret == null)
            {
                return;
            }

            Console.Out.WriteLine("Fetching secret for '{0}'...", secret);
            WebRequest req = CreateApiRequest("/secret/" + secret.m_guid.ToUpper());

            try
            {
                WebResponse resp = req.GetResponse();
                string response = new System.IO.StreamReader(resp.GetResponseStream(), Encoding.UTF8).ReadToEnd();

                var secretString = DeserializeSecret(response);
                Clipboard.SetText(secretString);
            }
            catch (WebException exception)
            {
                Console.Out.WriteLine("Error: {0}", exception.Message);
            }
        }

        private string DeserializeSecret(string response)
        {
            var jsonDecoder = new System.Web.Script.Serialization.JavaScriptSerializer();
            var sec = jsonDecoder.Deserialize<Dictionary<string, object>>(response);

            string secret = (string)sec["X"];
            return secret;
        }

        private void m_searchField_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Down && m_resultListView.HasItems)
            {
                m_resultListView.Focus();
                m_resultListView.SelectedItem = m_resultListView.Items[0];
            }
        }

        private void m_resultListView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter && m_resultListView.SelectedItem != null)
            {
                FetchSecret((Secret)m_resultListView.SelectedItem);
            }
        }
    }
}

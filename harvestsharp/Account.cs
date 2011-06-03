using System;
using System.Collections;
using System.Net;
using System.Text;
using System.Web;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;

namespace harvestsharp
{
    public class Account : IAccount
    {
        private string HarvestUri;
        private string UserName;
        private string Password;

        public Account(string userName, string password, string subDomain)
        {
            this.UserName = userName;
            this.Password = password;
            this.HarvestUri = String.Format("https://{0}.harvestapp.com", subDomain);
        }

        public string GetEncodedCredentials()
        {
            return Convert.ToBase64String(Encoding.ASCII.GetBytes(String.Format("{0}:{1}", this.UserName, this.Password)));
        }

        public string GetHavestPath(string path)
        {
            if (path[0] == '/')
                return HarvestUri + path;
            else
                return HarvestUri + "/" + path;
        }

        public string request(string path, string method, Hashtable vars = null, string postData = null)
        {
            string response = null;
            if (path == null || path.Length <= 0)
                throw (new ArgumentException("Invalid path parameter"));
            
            if (method == null)
                throw (new ArgumentException("Invalid method parameter"));
            method = method.ToUpper();
            if (method == null || (method != "GET" && method != "POST" && method != "PUT" && method != "DELETE"))
                throw (new ArgumentException("Invalid method parameter"));

            var url = GetHavestPath(path);

            if (method == "GET") {
                response = Download(url, null);
            }
            else {
                response = Upload(url, method, postData);
            }

            return response;
        }

        private string Download(string uri, Hashtable vars)
        {
            if (vars != null)
            {
                string query = String.Empty;
                foreach (DictionaryEntry d in vars)
                    query += "&" + d.Key.ToString() + "=" + HttpUtility.UrlEncode(d.Value.ToString());
                if (query.Length > 0)
                    uri = uri + "?" + query.Substring(1);
            }

            WebClient client = new WebClient();
            SetAuthHeader(GetEncodedCredentials(), client);
            client.Headers.Add("Content-Type", "application/json");
            client.Headers.Add("accept", "application/json");
            byte[] resp = client.DownloadData(uri);

            return Encoding.ASCII.GetString(resp);
        }

        private string Upload(string uri, string method, string postData)
        {
            ServicePointManager.ServerCertificateValidationCallback = Validator;

            ServicePointManager.Expect100Continue = false;
            WebClient client = new WebClient();
            SetAuthHeader(GetEncodedCredentials(), client);
            client.Headers.Add("Content-Type", "application/xml");
            client.Headers.Add("Accept", "application/xml");
            client.Headers.Add("User-Agent", "harvestsharp");

            if (!String.IsNullOrEmpty(postData)) {
                Byte[] postbytes = Encoding.ASCII.GetBytes(postData);
                byte[] resp = client.UploadData(uri, method, postbytes);
                return Encoding.ASCII.GetString(resp);
            } else {
                return client.UploadString(uri, method, String.Empty);
            }
        }

        private static void SetAuthHeader(string authstring, WebClient client)
        {
            client.Headers.Add("Authorization", String.Format("Basic {0}", authstring));
        }

        public static bool Validator(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }
    }
}

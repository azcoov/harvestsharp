using System;
using System.Text;

namespace harvestsharp.test
{
    public class Account_Mock : IAccount
    {
        public string GetEncodedCredentials()
        {
            return Convert.ToBase64String(Encoding.ASCII.GetBytes(String.Format("{0}:{1}", "test", "test")));
        }

        public string GetHavestPath(string path)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Just returning fake json here
        /// </summary>
        /// <param name="path"></param>
        /// <param name="method"></param>
        /// <param name="vars"></param>
        /// <returns>String</returns>
        public string request(string path, string method, System.Collections.Hashtable vars = null, string postData = null)
        {
            if (path == null || path.Length <= 0)
                throw (new ArgumentException("Invalid path parameter"));

            if (method == null || (method != "GET" && method != "POST" && method != "PUT" && method != "DELETE"))
                throw (new ArgumentException("Invalid method parameter"));

            if (path.ToLower().Contains("projects") && method == "GET")
            {
                return "[{\"project\":{\"id\":\"1\",\"name\":\"SuprGlu\",\"active\":\"true\",\"billable\":\"false\",\"bill_by\":\"none\",\"hourly_rate\":\"150.0\",\"client_id\":\"2\",\"budget_by\":\"none\",\"hint_latest_record_at\":\"2007-06-06\",\"hint_earliest_record_at\":\"2006-01-04\",\"updated_at\":\"2008-04-09T12:07:56Z\",\"created_at\":\"2008-04-09T12:07:56Z\"}}]";
            }
            if (path.ToLower().Contains("projects") && (method == "POST" || method == "PUT"))
            {
                return String.Empty;
            }
            throw new NotImplementedException("Method is not implemented");
        }
    }
}

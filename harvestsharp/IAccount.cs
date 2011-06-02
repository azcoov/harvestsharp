using System;

namespace harvestsharp
{
    public interface IAccount
    {
        string GetEncodedCredentials();
        string GetHavestPath(string path);
        string request(string path, string method, System.Collections.Hashtable vars = null, string postData = null);
    }
}

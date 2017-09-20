using DB.Leo.Lib.Interfaces;
using System.Configuration;

namespace DB.Leo.Libraries.Implementations.Connections
{
    public class CotConnection : ICotConnection
    {
        public string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings[ConnectionNames.Cot].ConnectionString;
        }
    }
}

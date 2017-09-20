using DB.Leo.Lib.Interfaces;
using System.Configuration;

namespace DB.Leo.Libraries.Implementations.Connections
{
    public class SacConnection : ISacConnection
    {
        public string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings[ConnectionNames.Sac].ConnectionString;
        }
    }
}

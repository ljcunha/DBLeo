using DB.Leo.Lib.Interfaces;
using System.Configuration;

namespace DB.Leo.Libraries.Implementations.Connections
{
    public class InvestorServiceConnection : IInvestorServiceConnection
    {
        public string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings[ConnectionNames.InvestorService].ConnectionString;
        }
    }
}

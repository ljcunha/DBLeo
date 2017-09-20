using DB.Leo.Lib.Interfaces;
using DB.Leo.Libraries.Implementations.Connections;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Leo.Libraries.Implementations.Factories
{
    public class ConnectionFactory
    {
        public static IConnection CreateWithInjector<TConnection>()
        {
            return (IConnection)Injector.GetInstance<TConnection>();
        }

        public static IConnection Create<TConnection>()
        {
            if (typeof(TConnection) is IInvestorServiceConnection)
            {
                return new InvestorServiceConnection();
            }

            if (typeof(TConnection) is ICotConnection)
            {
                return new CotConnection();
            }

            if (typeof(TConnection) is ISacConnection)
            {
                return new SacConnection();
            }

            throw new InvalidOperationException($"Unexpected type of {nameof(TConnection)}.");
        }
    }
}

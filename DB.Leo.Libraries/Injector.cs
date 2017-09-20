using DB.Leo.Lib.Interfaces;
using DB.Leo.Libraries.Implementations.Connections;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Leo.Libraries
{
    public class Injector
    {
        static Container Container { get; set; }

        static Injector()
        {
            Container = new Container();
        }

        public static void Register()
        {
            Container.Register(typeof(ISacConnection), typeof(SacConnection));
            Container.Register(typeof(ICotConnection), typeof(CotConnection));
            Container.Register(typeof(IInvestorServiceConnection), typeof(InvestorServiceConnection));
        }

        public static TObject GetInstance<TObject>()
        {
            return (TObject)Container.GetInstance(typeof(TObject));
        }
    }
}

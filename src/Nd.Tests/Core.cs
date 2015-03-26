using Castle.DynamicProxy;
using Nd.Framework.Core;
using Nd.Framework.Core.Castle;
using Nd.Framework.Logging;
using Nd.Framework.Logging.Log4Net;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nd.Tests
{
    public sealed class Core
    {
        public static void Test()
        {
            INdContainer container = AppRuntime.Current.Container;
            //container.AddFacility(new NdInterceptorFacility());
            //container.RegisterType(typeof(NdInterceptor), NdLifeStyle.Singleton);
            container.Register<INdLogger, NdLogger>();
            container.Register<ITT, TT>();

            ITT tt = container.Resolve<ITT>();
            tt.Op("hhhh");

            Console.ReadLine();
        }
    }

    public class TT : ITT
    {
        public void Op(string message)
        {
            Console.WriteLine("TT.Op():" + message);
        }
    }

    public interface ITT
    {
        void Op(string message);
    }
}
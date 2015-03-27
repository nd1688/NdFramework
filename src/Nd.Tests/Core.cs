using Nd.Framework;
using Nd.Framework.Application;
using Nd.Framework.Core;
using Nd.Framework.Logging;
using Nd.Framework.Logging.Log4Net;
using System;

namespace Nd.Tests
{
    public sealed class Core
    {
        public static void Test()
        {
            INdContainer container = AppRuntime.Instance.Container;
            //container.AddFacility(new NdInterceptorFacility());
            //container.RegisterType(typeof(NdInterceptor), NdLifeStyle.Singleton);
            container.Register<ILogger, LoggerManager>();
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
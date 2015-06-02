using Nd.Framework.Application;
using Nd.Framework.Caching;
using Nd.Framework.Configuration;
using Nd.Framework.Logging;
using Nd.Framework.Logging.Log4Net;

namespace Nd.Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            AppRuntime.Create(new AppConfigSource()).Register(o =>
            {
                o.Register<ILogger, LoggerManager>();
                o.Register<ITT, TT>();
                o.RegisterType(typeof(Bus));
            });

            Bus b = (Bus)AppRuntime.Instance.Container.Resolve(typeof(Bus));

            //Core.Test();

            //Bus.Test();
        }
    }
}
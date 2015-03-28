using Castle.Core.Logging;
using Nd.Framework.Application;
using Nd.Framework.Caching;
using Nd.Framework.Configuration;
using Nd.Framework.Logging.Log4Net;

namespace Nd.Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            //AppRuntime.Create(new AppConfigSource()).Register(t =>
            //{
            //    t.Register<ILogger, LoggerManager>();
            //});

            Core.Test();
        }
    }
}
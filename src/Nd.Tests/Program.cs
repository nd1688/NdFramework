
using Nd.Framework.Application;
using Nd.Framework.Configuration;
namespace Nd.Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            AppRuntime.Create(new AppConfigSource());
            AppRuntime.Instance.CurrentApplication.Start();

            Core.Test();
        }
    }
}
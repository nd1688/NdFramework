
using Nd.Framework.Application;
namespace Nd.Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            AppRuntime.Create(null);

            Core.Test();
        }
    }
}
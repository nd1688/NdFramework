using Nd.Framework.Services;
using System;

namespace Nd.Tests
{
    public sealed class Service
    {
        public static void Test()
        {
            ServiceA serviceA = new ServiceA();
            ServiceRunTimePoint serviceRunTimePoint = serviceA.ServiceRunTimePoint;
            if ((serviceRunTimePoint & ServiceRunTimePoint.H12) > 0)
            {
                Console.WriteLine("");
            }
            if ((serviceRunTimePoint & ServiceRunTimePoint.H24) > 0)
            {
                Console.WriteLine("");
            }
            if ((serviceRunTimePoint & ServiceRunTimePoint.H3) > 0)
            {
                Console.WriteLine("");
            }
        }
    }

    public class ServiceA : ServiceBase
    {
        public ServiceA()
            : base("")
        {

        }
    }
}
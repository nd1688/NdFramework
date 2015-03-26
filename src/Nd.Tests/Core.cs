using Castle.DynamicProxy;
using Nd.Framework.Core;
using Nd.Framework.Core.Castle;
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
            INdContainer container = new NdContainer();
            container.AddFacility(new NdInterceptorFacility());
            container.RegisterType(typeof(NdInterceptor), NdLifeStyle.Singleton);
            container.Register<ITT, TT>();

            ITT tt = container.Resolve<ITT>();
            tt.Op();

            Console.ReadLine();
        }
    }

    public class TT : ITT
    {
        public void Op()
        {
            Console.WriteLine("TT.Op()");
        }
    }

    public interface ITT
    {
        void Op();
    }
}
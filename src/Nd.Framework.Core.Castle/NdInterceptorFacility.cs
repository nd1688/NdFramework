using Castle.Core;
using Castle.Core.Configuration;
using Castle.DynamicProxy;
using Castle.MicroKernel;
using Nd.Framework.Logging;
using System.Collections.Generic;
using System.Linq;

namespace Nd.Framework.Core.Castle
{
    public class NdInterceptorFacility : ICastleFacility
    {
        private static List<string> sysAssembly = new List<string>();
        static NdInterceptorFacility()
        {
            sysAssembly.Add("msco");
            sysAssembly.Add("System");
            sysAssembly.Add("Microsoft.");
            sysAssembly.Add("WindowsBase");
            sysAssembly.Add("WindowsForms");
            sysAssembly.Add("Presentation");
            sysAssembly.Add("Policy.");
            sysAssembly.Add("UIAutomation");
            sysAssembly.Add("Env");
            sysAssembly.Add("vjs");
            sysAssembly.Add("Vslang");
            sysAssembly.Add("EnvDTE");
        }

        public void Init(IKernel kernel, IConfiguration facilityConfig)
        {
            kernel.ComponentRegistered += OnComponentRegistered;
        }
        public void Terminate()
        {
        }
        private void OnComponentRegistered(string key, IHandler handler)
        {
            if (handler.ComponentModel.Services.Any(t => t == typeof(IInterceptor)))
            {
                return;
            }
            if (handler.ComponentModel.Services.Any(t => t == typeof(INdLogger)))
            {
                return;
            }
            if (handler.ComponentModel.Services.Any(t => sysAssembly.Any(f => t.FullName.StartsWith(f))))
            {
                return;
            }
            if (handler.ComponentModel.Services.Any(t => sysAssembly.Any(f => t.Assembly.FullName.StartsWith(f))))
            {
                return;
            }
            handler.ComponentModel.Interceptors.Add(new InterceptorReference(typeof(NdInterceptor)));
        }
    }
}
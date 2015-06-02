using Castle.Core;
using Castle.Core.Configuration;
using Castle.MicroKernel;
using Nd.Framework.Core;
using Nd.Framework.Logging;
using Nd.Framework.Repositories;
using Nd.Framework.Web;
using System.Collections.Generic;
using System.Linq;

namespace Nd.Framework.ObjectContainers.Castle
{
    public class CastleInterceptorFacility : ICastleFacility
    {
        private static List<string> sysAssembly = new List<string>();
        static CastleInterceptorFacility()
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
            sysAssembly.Add("Nd.");
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
            if (handler.ComponentModel.Services.Any(t => t == typeof(INdInterceptor)))
            {
                return;
            }
            if (handler.ComponentModel.Services.Any(t => t == typeof(ILogger)))
            {
                return;
            }
            if (handler.ComponentModel.Services.Any(t => typeof(RequestBase).IsAssignableFrom(t)))
            {
                return;
            }
            if (handler.ComponentModel.Services.Any(t => typeof(ResponseBase).IsAssignableFrom(t)))
            {
                return;
            }
            if (handler.ComponentModel.Services.Any(t => typeof(IService).IsAssignableFrom(t)))
            {
                return;
            }
            if (handler.ComponentModel.Services.Any(t => t == typeof(IRepositoryContext)))
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
            handler.ComponentModel.Interceptors.Add(new InterceptorReference(typeof(CastleInterceptor)));
        }
    }
}
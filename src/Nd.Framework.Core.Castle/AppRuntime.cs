using Nd.Framework.Configuration;
using Nd.Framework.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nd.Framework.Core.Castle
{
    public sealed class AppRuntime
    {
        #region Private Field
        private static readonly AppRuntime instance = new AppRuntime();
        private readonly NdApp app = new NdApp();
        #endregion

        #region Public Property
        public static AppRuntime Current
        {
            get
            {
                return instance;
            }
        }
        public INdContainer Container
        {
            get
            {
                return this.app.Container;
            }
        }
        public INdLogger Logger
        {
            get
            {
                if (this.Container.HasRegister<INdLogger>())
                {
                    return this.Container.Resolve<INdLogger>();
                }
                return new TraceLogger();
            }
        }
        #endregion

        #region Ctor
        static AppRuntime()
        {
        }
        private AppRuntime()
        {
        }
        #endregion
    }
}
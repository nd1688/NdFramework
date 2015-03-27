using Nd.Framework.Core;
using Nd.Framework.Logging;

namespace Nd.Framework
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
        public ILogger Logger
        {
            get
            {
                if (this.Container.HasRegister<ILogger>())
                {
                    return this.Container.Resolve<ILogger>();
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
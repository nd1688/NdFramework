using log4net;
using log4net.Config;
using Nd.Framework.Configuration;
using System;
using System.IO;

namespace Nd.Framework.Logging.Log4Net
{
    /// <summary>
    /// 日志记录器组件
    /// </summary>
    public class LoggerManager : ILogger
    {
        #region Private Field
        private readonly IConfigSource configSource = new AppConfigSource();
        private ILog errorLogger;
        private ILog infoLogger;
        #endregion

        #region Ctor
        public LoggerManager()
            : this(null)
        {
        }
        public LoggerManager(string configFile, bool watch = true)
        {
            this.errorLogger = LogManager.GetLogger(this.configSource.Config.Logging.ErrorLogger);
            this.infoLogger = LogManager.GetLogger(this.configSource.Config.Logging.InfoLogger);

            if (!string.IsNullOrEmpty(configFile))
            {
                if (watch)
                {
                    XmlConfigurator.ConfigureAndWatch(new FileInfo(configFile));
                }
                else
                {
                    XmlConfigurator.Configure(new FileInfo(configFile));
                }
            }
            else
            {
                XmlConfigurator.Configure();
            }
        }
        #endregion

        #region INdLogger Member
        public void Debug(object message)
        {
            this.infoLogger.Debug(message);
        }

        public void Debug(object message, Exception exception)
        {
            this.infoLogger.Debug(message, exception);
        }

        public void DebugFormat(string format, params object[] args)
        {
            this.infoLogger.DebugFormat(format, args);
        }

        public void DebugFormat(IFormatProvider provider, string format, params object[] args)
        {
            this.infoLogger.DebugFormat(provider, format, args);
        }

        public void Error(object message)
        {
            this.errorLogger.Error(message);
        }

        public void Error(object message, Exception exception)
        {
            this.errorLogger.Error(message, exception);
        }

        public void ErrorFormat(string format, params object[] args)
        {
            this.errorLogger.ErrorFormat(format, args);
        }

        public void ErrorFormat(IFormatProvider provider, string format, params object[] args)
        {
            this.errorLogger.ErrorFormat(provider, format, args);
        }

        public void Fatal(object message)
        {
            this.errorLogger.Fatal(message);
        }

        public void Fatal(object message, Exception exception)
        {
            this.errorLogger.Fatal(message, exception);
        }

        public void FatalFormat(string format, params object[] args)
        {
            this.errorLogger.FatalFormat(format, args);
        }

        public void FatalFormat(IFormatProvider provider, string format, params object[] args)
        {
            this.errorLogger.FatalFormat(provider, format, args);
        }

        public void Info(object message)
        {
            this.infoLogger.Info(message);
        }

        public void Info(object message, Exception exception)
        {
            this.infoLogger.Info(message, exception);
        }

        public void InfoFormat(string format, params object[] args)
        {
            this.infoLogger.InfoFormat(format, args);
        }

        public void InfoFormat(IFormatProvider provider, string format, params object[] args)
        {
            this.infoLogger.InfoFormat(provider, format, args);
        }

        public void Warn(object message)
        {
            this.infoLogger.Warn(message);
        }

        public void Warn(object message, Exception exception)
        {
            this.infoLogger.Warn(message, exception);
        }

        public void WarnFormat(string format, params object[] args)
        {
            this.infoLogger.WarnFormat(format, args);
        }

        public void WarnFormat(IFormatProvider provider, string format, params object[] args)
        {
            this.infoLogger.WarnFormat(provider, format, args);
        }
        #endregion
    }
}

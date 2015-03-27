using System;
using System.Diagnostics;

namespace Nd.Framework.Logging
{
    public class TraceLogger : ILogger
    {
        #region Ctor
        public TraceLogger() { }
        #endregion

        #region INdLogger Member
        public void Debug(object message)
        {
            this.Log(message.ToString());
        }

        public void Debug(object message, Exception exception)
        {
            this.Log(message.ToString(), exception);
        }

        public void DebugFormat(string format, params object[] args)
        {
            this.Log(format, args);
        }

        public void DebugFormat(IFormatProvider provider, string format, params object[] args)
        {
            this.Log(format, args);
        }

        public void Error(object message)
        {
            this.Log(message.ToString());
        }

        public void Error(object message, Exception exception)
        {
            this.Log(message.ToString(), exception);
        }

        public void ErrorFormat(string format, params object[] args)
        {
            this.Log(format, args);
        }

        public void ErrorFormat(IFormatProvider provider, string format, params object[] args)
        {
            this.Log(format, args);
        }

        public void Fatal(object message)
        {
            this.Log(message.ToString());
        }

        public void Fatal(object message, Exception exception)
        {
            this.Log(message.ToString(), exception);
        }

        public void FatalFormat(string format, params object[] args)
        {
            this.Log(format, args);
        }

        public void FatalFormat(IFormatProvider provider, string format, params object[] args)
        {
            this.Log(format, args);
        }

        public void Info(object message)
        {
            this.Log(message.ToString());
        }

        public void Info(object message, Exception exception)
        {
            this.Log(message.ToString(), exception);
        }

        public void InfoFormat(string format, params object[] args)
        {
            this.Log(format, args);
        }

        public void InfoFormat(IFormatProvider provider, string format, params object[] args)
        {
            this.Log(format, args);
        }

        public void Warn(object message)
        {
            this.Log(message.ToString());
        }

        public void Warn(object message, Exception exception)
        {
            this.Log(message.ToString(), exception);
        }

        public void WarnFormat(string format, params object[] args)
        {
            this.Log(format, args);
        }

        public void WarnFormat(IFormatProvider provider, string format, params object[] args)
        {
            this.Log(format, args);
        }
        #endregion

        #region Private Method

        private void Log(string format, params object[] args)
        {
            string message = args == null || args.Length == 0 ? format : String.Format(format, args);
            Trace.WriteLine(message);
        }
        #endregion
    }
}
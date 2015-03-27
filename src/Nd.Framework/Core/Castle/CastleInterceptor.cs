using Castle.DynamicProxy;
using Nd.Framework.Application;
using Nd.Framework.Logging;
using System;
using System.Diagnostics;
using System.Text;

namespace Nd.Framework.Core.Castle
{
    public class CastleInterceptor : ICastleInterceptor
    {
        #region Private Field
        private ILogger logger = AppRuntime.Instance.Logger;
        #endregion

        #region ICastleInterceptor Member
        public void Intercept(IInvocation invocation)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            this.BeforeAdvice(invocation);
            this.PerformProceed(invocation);
            stopwatch.Stop();
            this.logger.InfoFormat("Source:{0}.{1}() Return,Elapsed {2}ms",
                invocation.Method.ReflectedType.FullName, invocation.Method.Name, stopwatch.ElapsedMilliseconds);
        }
        #endregion

        #region Public Method
        public virtual void PerformProceed(IInvocation invocation)
        {
            try
            {
                invocation.Proceed();
            }
            catch (Exception exc)
            {
                this.ThrowsAdvice(invocation, exc);
                throw exc;
            }
        }
        public virtual void BeforeAdvice(IInvocation invocation)
        {
            this.LogInfo(invocation);
        }
        public virtual void ThrowsAdvice(IInvocation invocation, Exception exception)
        {
            this.LogError(invocation, exception);
        }
        #endregion

        #region Private Method
        private void LogInfo(IInvocation invocation)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Source:{0}.{1}", invocation.Method.ReflectedType.FullName, invocation.Method.Name);
            sb.Append(",Params:[");
            if (invocation.Arguments != null && invocation.Arguments.Length > 0)
            {
                for (int i = 0; i < invocation.Arguments.Length; i++)
                {
                    if (i > 0)
                    {
                        sb.AppendFormat(",");
                    }
                    sb.AppendFormat("{0}", invocation.Arguments[i] ?? "null");
                }
            }
            sb.Append("]");
            this.logger.Info(sb.ToString());
        }
        private void LogError(IInvocation invocation, Exception ex)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Source:{0}.{1}", invocation.Method.ReflectedType.FullName, invocation.Method.Name);
            sb.Append(",Params:[");
            if (invocation.Arguments != null && invocation.Arguments.Length > 0)
            {
                for (int i = 0; i < invocation.Arguments.Length; i++)
                {
                    if (i > 0)
                    {
                        sb.AppendFormat(",");
                    }
                    sb.AppendFormat("{0}", invocation.Arguments[i] ?? "null");
                }
            }
            sb.AppendFormat("],Exception:{0}", ex.ToString());
            this.logger.Error(sb.ToString());
        }
        #endregion
    }
}
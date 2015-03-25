using Castle.DynamicProxy;
using System;

namespace Nd.Framework.Core.Castle
{
    public class NdInterceptor : ICastleInterceptor
    {
        public void Intercept(IInvocation objInvocation)
        {
            this.BeforeAdvice(objInvocation);
            this.PerformProceed(objInvocation);
            this.AfterAdvice(objInvocation);
        }
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
        public virtual void BeforeAdvice(IInvocation objInvocation)
        {
            Console.WriteLine("BeforeAdvice");
        }
        public virtual void AfterAdvice(IInvocation objInvocation)
        {
            Console.WriteLine("AfterAdvice");
        }
        public virtual void ThrowsAdvice(IInvocation objInvocation, Exception objException)
        {
            Console.WriteLine("ThrowsAdvice");
        }
    }
}
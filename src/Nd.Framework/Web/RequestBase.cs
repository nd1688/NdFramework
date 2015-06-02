using System.Collections.Generic;

namespace Nd.Framework.Web
{
    public abstract class RequestBase : IRequest
    {
        #region IRequest 成员
        public string Verb { get; set; }

        public string MethodRouteKey { get; set; }

        public virtual Dictionary<string, string> GetRequestParams() { return null; }
        #endregion
    }
}
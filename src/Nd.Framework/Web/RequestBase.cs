using System.Collections.Generic;

namespace Nd.Framework.Web
{
    public abstract class RequestBase : IRequest
    {
        #region IRequest 成员
        public string Verb { get; set; }

        public string MethodRouteKey { get; set; }

        public virtual Dictionary<string, string> GetRequestParams() { return null; }

        public string Method { get; set; }

        public Format Format { get; set; }

        public string Signature { get; set; }

        public string Timestamp { get; set; }

        public string Version { get; set; }

        public string AppKey { get; set; }
        #endregion
    }
}
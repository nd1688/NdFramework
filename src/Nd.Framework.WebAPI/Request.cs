using Nd.Framework.WebAPI.Enums;
using System;

namespace Nd.Framework.WebAPI
{
    public abstract class Request<TRequest> : IRequest<TRequest>
        where TRequest : class,IRequest
    {
        #region IRequest<TRequest> 成员
        public string Method { get; set; }

        public string Timestamp { get; set; }

        public string Version { get; set; }

        public Format Format { get; set; }

        public string Signature { get; set; }

        public string AppKey { get; set; }

        public string AppSecret { get; set; }
        #endregion
    }
}
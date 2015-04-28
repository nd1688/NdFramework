using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nd.Framework.WebAPI
{
    public abstract class Response<TResponse> : IResponse<TResponse>
        where TResponse : class,IResponse
    {
    }
}
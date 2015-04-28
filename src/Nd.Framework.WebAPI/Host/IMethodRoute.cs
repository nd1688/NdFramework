using System;
using System.Collections.Generic;

namespace Nd.Framework.WebAPI.Host
{
    /// <summary>
    /// WebAPI接口方法路由协定
    /// </summary>
    public interface IMethodRoute
    {
        /// <summary>
        /// WebAPI接口方法名称
        /// </summary>
        string MethodName { get; }

        /// <summary>
        /// 
        /// </summary>
        Type RequestType { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="queryStringAndFormData"></param>
        /// <param name="requestInstance"></param>
        /// <returns></returns>
        object CreateRequest(Dictionary<string, string> queryStringAndFormData, object requestInstance);
    }
}
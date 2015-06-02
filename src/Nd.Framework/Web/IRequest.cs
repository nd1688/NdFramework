
using System.Collections.Generic;
namespace Nd.Framework.Web
{
    /// <summary>
    /// 接口请求封装服务
    /// </summary>
    public interface IRequest
    {
        /// <summary>
        /// HTTP 谓词
        /// </summary>
        string Verb { get; }

        /// <summary>
        /// 方法路由键
        /// </summary>
        string MethodRouteKey { get; }

        /// <summary>
        /// 获取请求参数字典
        /// </summary>
        /// <returns></returns>
        Dictionary<string, string> GetRequestParams();
    }
}
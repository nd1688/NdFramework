
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

        /// <summary>
        /// 调用接口方法 如：oph.method.get
        /// </summary>
        string Method { get; }

        /// <summary>
        /// 调用接口方法 如：oph.method.get
        /// </summary>
        Format Format { get; }

        /// <summary>
        /// 加密之后的参数字符串
        /// </summary>
        string Signature { get; }

        /// <summary>
        /// 时间戳，格式为yyyy-MM-dd HH:mm:ss
        /// </summary>
        string Timestamp { get; }

        /// <summary>
        /// 接口方法的版本
        /// </summary>
        string Version { get; }

        /// <summary>
        /// 分配给应用的AppKey
        /// </summary>
        string AppKey { get; }
    }
}
using Nd.Framework.WebAPI.Enums;

namespace Nd.Framework.WebAPI
{
    public interface IRequest
    {
    }

    public interface IRequest<TRequest>
        where TRequest : class,IRequest
    {
        /// <summary>
        /// API接口方法
        /// </summary>
        string Method { get; set; }

        /// <summary>
        /// 时间戳，格式为yyyy-mm-dd HH:mm:ss
        /// </summary>
        string Timestamp { get; set; }

        /// <summary>
        /// 版本号
        /// </summary>
        string Version { get; set; }

        /// <summary>
        /// 指定响应格式，默认xml
        /// </summary>
        Format Format { get; set; }

        /// <summary>
        /// 加密之后的参数字符串
        /// </summary>
        string Signature { get; set; }

        /// <summary>
        /// 分配给应用的AppKey
        /// </summary>
        string AppKey { get; set; }

        /// <summary>
        /// 分配给应用的AppSecret
        /// </summary>
        string AppSecret { get; set; }
    }
}
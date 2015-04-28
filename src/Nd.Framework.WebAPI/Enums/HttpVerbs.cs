using System;

namespace Nd.Framework.WebAPI.Enums
{
    /// <summary>
    /// 枚举 HTTP 谓词
    /// 将枚举作为位域（即一组标志）处理
    /// 所谓作为位域处理就是说要求声明枚举的每一个数值没有位重叠，例如0，1，4，8
    /// </summary>
    [FlagsAttribute]
    public enum HttpVerbs
    {
        /// <summary>
        /// 检索由请求的 URI 标识的信息或实体
        /// </summary>
        Get = 1 << 0,
        /// <summary>
        /// 发布新实体作为对 URI 的补充
        /// </summary>
        Post = 1 << 1,
        /// <summary>
        /// 替换由 URI 标识的实体
        /// </summary>
        PUT = 1 << 2,
        /// <summary>
        /// 请求删除指定的 URI
        /// </summary>
        DELETE = 1 << 3,
        /// <summary>
        /// 请求将请求实体中描述的一组更改应用于请求 URI 所标识的资源
        /// </summary>
        PATCH = 1 << 4,
        /// <summary>
        /// 检索由请求的 URI 标识的信息或实体的消息头
        /// </summary>
        HEAD = 1 << 5,
        /// <summary>
        /// 表示由请求 URI 标识的请求/响应链上提供的通信选项的相关信息请求
        /// </summary>
        OPTIONS = 1 << 6
    }
}
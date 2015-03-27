
namespace Nd.Framework
{
    /// <summary>
    /// 消息处理服务
    /// </summary>
    /// <typeparam name="T">消息</typeparam>
    public interface IHandler<in T>
    {
        /// <summary>
        /// 消息处理函数
        /// </summary>
        /// <param name="message">特定消息</param>
        void Handle(T message);
    }
}
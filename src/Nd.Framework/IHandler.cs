
namespace Nd.Framework
{
    /// <summary>
    /// 表示该接口实现类为消息处理程序
    /// </summary>
    /// <typeparam name="T">消息</typeparam>
    public interface IHandler<in T>
    {
        /// <summary>
        /// 处理消息，如：事件、命令、服务等等
        /// </summary>
        /// <param name="message">被处理的消息</param>
        void Handle(T message);
    }
}

namespace Nd.Framework.Events
{
    /// <summary>
    /// 事件处理服务
    /// </summary>
    /// <typeparam name="TEvent">事件</typeparam>
    public interface IEventHandler<in TEvent> : IHandler<TEvent>
        where TEvent : class,IEvent
    {
    }
}
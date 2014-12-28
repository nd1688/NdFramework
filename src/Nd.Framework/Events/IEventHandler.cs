
namespace Nd.Framework.Events
{
    /// <summary>
    /// 表示该接口实现类为事件处理程序
    /// </summary>
    /// <typeparam name="TEvent">事件</typeparam>
    public interface IEventHandler<TEvent> : IHandler<TEvent>
        where TEvent : class,IEvent
    {
    }
}
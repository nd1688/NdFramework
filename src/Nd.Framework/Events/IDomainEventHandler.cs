
namespace Nd.Framework.Events
{
    /// <summary>
    /// 领域事件处理服务
    /// </summary>
    /// <typeparam name="TDomainEvent">领域事件</typeparam>
    public interface IDomainEventHandler<in TDomainEvent> : IEventHandler<TDomainEvent>
        where TDomainEvent : class, IDomainEvent
    {
    }
}
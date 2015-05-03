using System;
using System.Collections.Generic;

namespace Nd.Framework.Bus
{
    /// <summary>
    /// 消息总线服务
    /// </summary>
    public interface IBus : IUnitOfWork, IDisposable
    {
        /// <summary>
        /// 发布消息到消息总线
        /// </summary>
        /// <typeparam name="TMessage">消息类型</typeparam>
        /// <param name="message">消息</param>
        void Publish<TMessage>(TMessage message);

        /// <summary>
        /// 发布消息到消息总线
        /// </summary>
        /// <typeparam name="TMessage">消息类型</typeparam>
        /// <param name="message">消息</param>
        void Publish<TMessage>(IEnumerable<TMessage> messages);

        /// <summary>
        /// 清理消息
        /// </summary>
        void Clear();
    }
}
using Nd.Framework.Core;
using Nd.Framework.Serialization;
using RabbitMQ.Client;
using System.Collections.Generic;
using System.Linq;

namespace Nd.Framework.Bus.RabbitMQ
{
    /// <summary>
    /// 基于RabbitMQ的消息总线基类
    /// </summary>
    public abstract class RabbitMQBus : DisposableObject, IBus
    {
        #region 私有字段
        private volatile bool committed = true;
        private readonly object lockObj = new object();
        private IObjectSerializer objectSerializer = null;
        private readonly Queue<object> mockQueue = new Queue<object>();

        private ConnectionFactory connectionFactory = null;
        private IConnection connection = null;
        #endregion

        #region 构造函数
        public RabbitMQBus()
        {
            this.objectSerializer = new ObjectJsonSerializer();
        }
        public RabbitMQBus(string hostName)
            : this()
        {
            this.connectionFactory = new ConnectionFactory();
            this.connectionFactory.HostName = hostName;
            this.connection = this.connectionFactory.CreateConnection();
        }
        #endregion

        #region 受保护的方法
        protected void SendMessage(object message)
        {
            using (IModel channel = this.connection.CreateModel())
            {
                //在MQ上定义一个队列
                channel.QueueDeclare("esbtest.rmq.consoleserver", false, false, false, null);
                channel.BasicPublish("", "esbtest.rmq.consoleserver", null, this.objectSerializer.Serialize(message));
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (!this.Committed)
                {
                    try
                    {
                        this.Commit();
                    }
                    catch
                    {
                        this.Rollback();
                        throw;
                    }
                }
                if (connection != null)
                {
                    connection.Close();
                    connection.Dispose();
                }
            }
        }
        #endregion

        #region IBus 成员
        public void Publish<TMessage>(TMessage message)
        {
            lock (lockObj)
            {
                mockQueue.Enqueue(message);
                committed = false;
            }
        }

        public void Publish<TMessage>(IEnumerable<TMessage> messages)
        {
            lock (lockObj)
            {
                messages.ToList().ForEach(p => { mockQueue.Enqueue(p); committed = false; });
            }
        }

        public void Clear()
        {
            lock (lockObj)
            {
                this.mockQueue.Clear();
            }
        }
        #endregion

        #region IUnitOfWork 成员
        public bool DistributedTransactionSupported
        {
            get { return true; }
        }

        public bool Committed
        {
            get { return this.committed; }
        }

        public void Commit()
        {
            lock (lockObj)
            {
                while (mockQueue.Count > 0)
                {
                    object msg = mockQueue.Dequeue();
                    SendMessage(msg);
                }

                committed = true;
            }
        }

        public void Rollback()
        {
            committed = false;
        }
        #endregion
    }
}
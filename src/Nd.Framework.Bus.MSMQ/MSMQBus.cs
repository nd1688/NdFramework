using Nd.Framework.Core;

namespace Nd.Framework.Bus.MSMQ
{
    /// <summary>
    /// 基于消息队列的消息总线基类
    /// </summary>
    public abstract class MSMQBus : DisposableObject, IBus
    {
        #region 私有字段

        #endregion

        #region 构造函数

        #endregion

        #region 受保护的方法

        #endregion

        #region IBus 成员
        public void Publish<TMessage>(TMessage message)
        {
            throw new System.NotImplementedException();
        }

        public void Publish<TMessage>(System.Collections.Generic.IEnumerable<TMessage> message)
        {
            throw new System.NotImplementedException();
        }

        public void Clear()
        {
            throw new System.NotImplementedException();
        }
        #endregion

        #region IUnitOfWork 成员
        public bool DistributedTransactionSupported
        {
            get { throw new System.NotImplementedException(); }
        }

        public bool Committed
        {
            get { throw new System.NotImplementedException(); }
        }

        public void Commit()
        {
            throw new System.NotImplementedException();
        }

        public void Rollback()
        {
            throw new System.NotImplementedException();
        }
        #endregion
    }
}
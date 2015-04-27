using Nd.Framework.Core;
using System;
using System.Threading;

namespace Nd.Framework.Repositories
{
    /// <summary>
    /// 仓储上下文抽象基类
    /// </summary>
    public abstract class RepositoryContext : DisposableObject, IRepositoryContext
    {
        #region 私有字段
        private readonly Guid id = Guid.NewGuid();
        private readonly ThreadLocal<bool> localCommitted = new ThreadLocal<bool>(() => true);
        #endregion

        #region 受保护的方法
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.localCommitted.Dispose();
            }
        }
        #endregion

        #region IRepositoryContext 成员
        public Guid Id
        {
            get { return id; }
        }

        public abstract void Create<T>(T obj) where T : class;

        public abstract void Update<T>(T obj) where T : class;

        public abstract void Delete<T>(T obj) where T : class;

        public virtual bool DistributedTransactionSupported
        {
            get { return false; }
        }

        public virtual bool Committed
        {
            get { return localCommitted.Value; }
            protected set { localCommitted.Value = value; }
        }

        public abstract void Commit();

        public abstract void Rollback();
        #endregion
    }
}
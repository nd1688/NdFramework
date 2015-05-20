using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;

namespace Nd.Framework.Repositories.EntityFramework
{
    public class EntityFrameworkRepositoryContext : RepositoryContext, IEntityFrameworkRepositoryContext
    {
        #region 私有字段
        private DbContext context = null;
        private readonly object objLock = new object();
        #endregion

        #region 构造方法
        public EntityFrameworkRepositoryContext(DbContext context)
        {
            this.context = context;
            this.context.Configuration.AutoDetectChangesEnabled = false;
            this.context.Configuration.ValidateOnSaveEnabled = false;
        }
        #endregion

        #region 保护方法
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.context.Dispose();
            }
            base.Dispose(disposing);
        }
        #endregion

        #region IRepositoryContext 成员
        public override void Create<T>(T obj)
        {
            this.context.Entry<T>(obj).State = EntityState.Added;
            this.Committed = false;
        }
        public override void Update<T>(T obj)
        {
            RemoveHoldingEntityInContext(obj);

            this.context.Entry<T>(obj).State = EntityState.Modified;
            this.Committed = false;
        }
        public override void Delete<T>(T obj)
        {
            RemoveHoldingEntityInContext(obj);

            this.context.Entry<T>(obj).State = EntityState.Deleted;
            this.Committed = false;
        }
        #endregion

        #region IUnitOfWork 成员
        public override bool DistributedTransactionSupported
        {
            get
            {
                return true;
            }
        }
        public override void Commit()
        {
            if (!this.Committed)
            {
                lock (this.objLock)
                {
                    this.context.SaveChanges();
                }
                this.Committed = true;
            }
        }
        public override void Rollback()
        {
            this.Committed = false;
        }
        #endregion

        #region IEntityFrameworkRepositoryContext 成员
        public DbContext Context
        {
            get { return this.context; }
        }
        #endregion

        #region 私有方法
        /// <summary>
        /// 监测Context中的Entity是否存在，如果存在，将其Detach，防止出现问题
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        private bool RemoveHoldingEntityInContext<T>(T obj) where T : class
        {
            ObjectContext objContext = ((IObjectContextAdapter)this.context).ObjectContext;
            var objSet = objContext.CreateObjectSet<T>();
            var entityKey = objContext.CreateEntityKey(objSet.EntitySet.Name, obj);
            object foundEntity;
            var exists = objContext.TryGetObjectByKey(entityKey, out foundEntity);
            if (exists)
            {
                objContext.Detach(foundEntity);
            }

            return (exists);
        }
        #endregion
    }
}
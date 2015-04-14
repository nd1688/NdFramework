using System.Data.Entity;

namespace Nd.Framework.Repositories.EntityFramework
{
    public class EntityFrameworkRepositoryContext : RepositoryContext
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

        #region IRepositoryContext接口方法
        public override void Create<T>(T obj)
        {
            this.context.Entry<T>(obj).State = EntityState.Added;
            this.Committed = false;
        }
        public override void Update<T>(T obj)
        {
            this.context.Entry<T>(obj).State = EntityState.Modified;
            this.Committed = false;
        }
        public override void Delete<T>(T obj)
        {
            this.context.Entry<T>(obj).State = EntityState.Deleted;
            this.Committed = false;
        }
        #endregion

        #region IUnitOfWork接口方法
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
    }
}
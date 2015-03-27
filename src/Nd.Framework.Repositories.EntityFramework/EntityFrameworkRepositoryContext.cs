using Nd.Framework.Application;
using Nd.Framework.Core;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Nd.Framework.Repositories.EntityFramework
{
    public class EntityFrameworkRepositoryContext : BooleanDisposable, IEntityFrameworkRepositoryContext
    {
        #region 私有字段
        private Guid objUniquedID = Guid.NewGuid();
        private DbContext objContext = null;
        private readonly object objLock = new object();
        private readonly ThreadLocal<bool> bCommitted = new ThreadLocal<bool>(() => true);
        #endregion

        #region 构造方法
        public EntityFrameworkRepositoryContext(DbContext objEFContext)
        {
            this.objContext = objEFContext;
            this.Context.Configuration.ValidateOnSaveEnabled = false;
        }
        #endregion

        #region 保护方法
        protected override void Dispose(bool bDisposed)
        {
            if (bDisposed)
            {
                this.objContext.Dispose();
            }
            base.Dispose(bDisposed);
        }
        #endregion

        #region 属性
        public Guid UniquedID
        {
            get
            {
                return this.objUniquedID;
            }
        }
        public DbContext Context
        {
            get
            {
                return this.objContext;
            }
        }
        public bool Committed
        {
            get
            {
                return this.bCommitted.Value;
            }
            protected set
            {
                this.bCommitted.Value = value;
            }
        }
        private DbConnection Connection
        {
            get
            {
                return this.Context.Database.Connection;
            }
        }
        #endregion

        #region IRepositoryContext接口方法
        public virtual bool Create<TDao>(TDao objDao) where TDao : class
        {
            try
            {
                this.objContext.Entry<TDao>(objDao).State = EntityState.Added;
                this.Committed = false;
                return true;
            }
            catch (Exception ex)
            {
                AppRuntime.Instance.Logger.ErrorFormat("Source:Basf.EFRepository.EFRepositoryContext.Create(TDao [{0}]),Exception:{1}", objDao.ToString(), ex.ToString());
                if (!Util.IsNull(this.Connection))
                {
                    this.Connection.Close();
                }
                throw ex;
            }
        }
        public virtual bool Update<TDao>(TDao objDao) where TDao : class
        {
            try
            {
                this.RemoveHoldingEntity(objDao);
                this.objContext.Entry<TDao>(objDao).State = EntityState.Modified;
                this.Committed = false;
                return true;
            }
            catch (Exception ex)
            {
                AppRuntime.Instance.Logger.ErrorFormat("Source:Basf.EFRepository.EFRepositoryContext.Update(TDao [{0}]),Exception:{1}", objDao.ToString(), ex.ToString());
                if (!Util.IsNull(this.Connection))
                {
                    this.Connection.Close();
                }
                throw ex;
            }
        }
        public virtual bool Delete<TDao>(TDao objDao) where TDao : class
        {
            try
            {
                this.RemoveHoldingEntity(objDao);
                this.objContext.Entry<TDao>(objDao).State = EntityState.Deleted;
                this.Committed = false;
                return true;
            }
            catch (Exception ex)
            {
                AppRuntime.Instance.Logger.ErrorFormat("Source:Basf.EFRepository.EFRepositoryContext.Delete(TDao [{0}]),Exception:{1}", objDao.ToString(), ex.ToString());
                if (!Util.IsNull(this.Connection))
                {
                    this.Connection.Close();
                }
                throw ex;
            }
        }
        public virtual bool CreateRange<TDao>(ICollection<TDao> objDaoList) where TDao : class
        {
            try
            {
                foreach (TDao objDao in objDaoList)
                {
                    this.objContext.Entry<TDao>(objDao).State = EntityState.Added;
                }
                this.Committed = false;
                return true;
            }
            catch (Exception ex)
            {
                AppRuntime.Instance.Logger.ErrorFormat("Source:Basf.EFRepository.EFRepositoryContext.CreateRange(ICollection<TDao> [{0}]),Exception:{1}", objDaoList.ToString(), ex.ToString());
                if (!Util.IsNull(this.Connection))
                {
                    this.Connection.Close();
                }
                throw ex;
            }
        }
        public virtual bool UpdateRange<TDao>(ICollection<TDao> objDaoList) where TDao : class
        {
            try
            {
                foreach (TDao objDao in objDaoList)
                {
                    this.RemoveHoldingEntity(objDao);
                    this.objContext.Entry<TDao>(objDao).State = EntityState.Modified;
                }
                this.Committed = false;
                return true;
            }
            catch (Exception ex)
            {
                AppRuntime.Instance.Logger.ErrorFormat("Source:Basf.EFRepository.EFRepositoryContext.UpdateRange(ICollection<TDao> [{0}]),Exception:{1}", objDaoList.ToString(), ex.ToString());
                if (!Util.IsNull(this.Connection))
                {
                    this.Connection.Close();
                }
                throw ex;
            }
        }
        public virtual bool DeleteRange<TDao>(ICollection<TDao> objDaoList) where TDao : class
        {
            try
            {
                foreach (TDao objDao in objDaoList)
                {
                    this.RemoveHoldingEntity(objDao);
                    this.objContext.Entry<TDao>(objDao).State = EntityState.Deleted;
                }
                this.Committed = false;
                return true;
            }
            catch (Exception ex)
            {
                AppRuntime.Instance.Logger.ErrorFormat("Source:Basf.EFRepository.EFRepositoryContext.DeleteRange(ICollection<TDao> [{0}]),Exception:{1}", objDaoList.ToString(), ex.ToString());
                if (!Util.IsNull(this.Connection))
                {
                    this.Connection.Close();
                }
                throw ex;
            }
        }
        private void RemoveHoldingEntity<TDao>(TDao objDao) where TDao : class
        {
            var objCtx = ((IObjectContextAdapter)this.objContext).ObjectContext;
            var objSet = objCtx.CreateObjectSet<TDao>();
            var objKey = objCtx.CreateEntityKey(objSet.EntitySet.Name, objDao);
            object objEntity;
            if (objCtx.TryGetObjectByKey(objKey, out objEntity))
            {
                objCtx.Detach(objEntity);
            }
        }
        #endregion

        #region IUnitOfWork接口方法
        public virtual bool DistributedTransactionSupported
        {
            get
            {
                return true;
            }
        }
        public virtual bool Commit()
        {
            if (!this.Committed)
            {
                lock (this.objLock)
                {
                    try
                    {
                        this.Context.Configuration.ValidateOnSaveEnabled = false;
                        return this.objContext.SaveChanges() > 0;
                    }
                    catch (Exception ex)
                    {
                        AppRuntime.Instance.Logger.ErrorFormat("Source:Basf.EFRepository.EFRepositoryContext.Commit(),Exception:{0}", ex.ToString());
                        throw ex;
                    }
                    finally
                    {
                        this.Committed = true;
                    }
                }
            }
            return false;
        }
        public virtual bool Rollback()
        {
            this.Committed = false;
            return true;
        }
        #endregion
    }
}
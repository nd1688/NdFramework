using Nd.Framework.Specifications;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;

namespace Nd.Framework.Repositories
{
    public abstract class Repository<TAggregateRoot> : IRepository<TAggregateRoot>
        where TAggregateRoot : class, IAggregateRoot
    {
        #region Private Fields
        private IRepositoryContext objContext;
        private Guid objUniquedID = Guid.NewGuid();
        #endregion

        #region Ctor
        public Repository(IRepositoryContext objContext)
        {
            this.objContext = objContext;
        }
        #endregion

        #region 保护方法
        protected virtual IQueryable<TAggregateRoot> DoFindAll()
        {
            return this.DoFindAll(new AnySpecification<TAggregateRoot>(), null, SortOrder.Unspecified);
        }
        protected virtual IQueryable<TAggregateRoot> DoFindAll(Expression<Func<TAggregateRoot, dynamic>> objSortPredicate, SortOrder iSortOrder)
        {
            return this.DoFindAll(new AnySpecification<TAggregateRoot>(), objSortPredicate, iSortOrder);
        }
        protected virtual PagedResult<TAggregateRoot> DoFindAll(Expression<Func<TAggregateRoot, dynamic>> objSortPredicate, SortOrder iSortOrder, int iPageNumber, int iPageSize)
        {
            return this.DoFindAll(new AnySpecification<TAggregateRoot>(), objSortPredicate, iSortOrder, iPageNumber, iPageSize);
        }
        protected virtual IQueryable<TAggregateRoot> DoFindAll(ISpecification<TAggregateRoot> objSpecification)
        {
            return this.DoFindAll(objSpecification, null, SortOrder.Unspecified);
        }
        protected virtual IQueryable<TAggregateRoot> DoFindAll(params Expression<Func<TAggregateRoot, dynamic>>[] objEagerLoadingProperties)
        {
            return DoFindAll(new AnySpecification<TAggregateRoot>(), null, SortOrder.Unspecified, objEagerLoadingProperties);
        }
        protected virtual IQueryable<TAggregateRoot> DoFindAll(Expression<Func<TAggregateRoot, dynamic>> objSortPredicate, SortOrder iSortOrder, params Expression<Func<TAggregateRoot, dynamic>>[] objEagerLoadingProperties)
        {
            return this.DoFindAll(new AnySpecification<TAggregateRoot>(), objSortPredicate, iSortOrder, objEagerLoadingProperties);
        }
        protected virtual PagedResult<TAggregateRoot> DoFindAll(Expression<Func<TAggregateRoot, dynamic>> objSortPredicate, SortOrder iSortOrder, int iPageNumber, int iPageSize, params Expression<Func<TAggregateRoot, dynamic>>[] objEagerLoadingProperties)
        {
            return this.DoFindAll(new AnySpecification<TAggregateRoot>(), objSortPredicate, iSortOrder, iPageNumber, iPageSize, objEagerLoadingProperties);
        }
        protected virtual IQueryable<TAggregateRoot> DoFindAll(ISpecification<TAggregateRoot> objSpecification, params Expression<Func<TAggregateRoot, dynamic>>[] objEagerLoadingProperties)
        {
            return this.DoFindAll(objSpecification, null, SortOrder.Unspecified, objEagerLoadingProperties);
        }
        protected abstract TAggregateRoot DoGet(Expression<Func<TAggregateRoot, bool>> objSpecification);
        protected abstract TAggregateRoot DoGet(ISpecification<TAggregateRoot> objSpecification);
        protected abstract IQueryable<TAggregateRoot> DoFindAll(ISpecification<TAggregateRoot> objSpecification, Expression<Func<TAggregateRoot, dynamic>> objSortPredicate, SortOrder iSortOrder);
        protected abstract PagedResult<TAggregateRoot> DoFindAll(ISpecification<TAggregateRoot> objSpecification, Expression<Func<TAggregateRoot, dynamic>> objSortPredicate, SortOrder iSortOrder, int iPageNumber, int iPageSize);
        protected abstract IQueryable<TAggregateRoot> DoFindAll(ISpecification<TAggregateRoot> objSpecification, Expression<Func<TAggregateRoot, dynamic>> objSortPredicate, SortOrder iSortOrder, params Expression<Func<TAggregateRoot, dynamic>>[] objEagerLoadingProperties);
        protected abstract PagedResult<TAggregateRoot> DoFindAll(ISpecification<TAggregateRoot> objSpecification, Expression<Func<TAggregateRoot, dynamic>> objSortPredicate, SortOrder iSortOrder, int iPageNumber, int iPageSize, params Expression<Func<TAggregateRoot, dynamic>>[] objEagerLoadingProperties);
        protected abstract bool DoExists(ISpecification<TAggregateRoot> objSpecification);
        protected abstract bool DoExists(Expression<Func<TAggregateRoot, bool>> objSpecification);
        protected abstract bool DoExists<TModel>(ISpecification<TModel> objSpecification) where TModel : class;
        protected abstract bool DoExists<TModel>(Expression<Func<TModel, bool>> objSpecification) where TModel : class;
        protected abstract TAggregateRoot DoFind(ISpecification<TAggregateRoot> objSpecification);
        protected abstract TAggregateRoot DoFind(ISpecification<TAggregateRoot> objSpecification, params Expression<Func<TAggregateRoot, dynamic>>[] objEagerLoadingProperties);
        #endregion

        #region IRepository<TAggregateRoot> Members
        public Guid UniquedID
        {
            get
            {
                return this.objUniquedID;
            }
        }
        public virtual IRepositoryContext Context
        {
            get
            {
                return this.objContext;
            }
        }
        public virtual void InitContext(IRepositoryContext objContext)
        {
            this.objContext = objContext;
        }
        public virtual bool Create(TAggregateRoot objEntity)
        {
            return this.objContext.Create(objEntity);
        }
        public virtual bool Update(TAggregateRoot objEntity)
        {
            return this.objContext.Update(objEntity);
        }
        public virtual bool Delete(TAggregateRoot objEntity)
        {
            return this.objContext.Delete(objEntity);
        }
        public virtual bool CreateRange(ICollection<TAggregateRoot> objEntityList)
        {
            return this.objContext.CreateRange(objEntityList);
        }
        public virtual bool UpdateRange(ICollection<TAggregateRoot> objEntityList)
        {
            return this.objContext.UpdateRange(objEntityList);
        }
        public virtual bool DeleteRange(ICollection<TAggregateRoot> objEntityList)
        {
            return this.objContext.DeleteRange(objEntityList);
        }
        public virtual T CreateSequence<T>()
        {
            return default(T);
        }
        public virtual T CreateSequence<T>(string strSequenceCode)
        {
            return default(T);
        }
        public virtual TAggregateRoot Get(Expression<Func<TAggregateRoot, bool>> objSpecification)
        {
            return this.DoGet(objSpecification);
        }
        public virtual TAggregateRoot Get(ISpecification<TAggregateRoot> objSpecification)
        {
            return this.DoGet(objSpecification);
        }
        public IQueryable<TAggregateRoot> FindAll()
        {
            return this.DoFindAll();
        }
        public IQueryable<TAggregateRoot> FindAll(Expression<Func<TAggregateRoot, dynamic>> objSortPredicate, SortOrder iSortOrder)
        {
            return this.DoFindAll(objSortPredicate, iSortOrder);
        }
        public PagedResult<TAggregateRoot> FindAll(Expression<Func<TAggregateRoot, dynamic>> objSortPredicate, SortOrder iSortOrder, int iPageNumber, int iPageSize)
        {
            return this.DoFindAll(objSortPredicate, iSortOrder, iPageNumber, iPageSize);
        }
        public IQueryable<TAggregateRoot> FindAll(ISpecification<TAggregateRoot> objSpecification)
        {
            return this.DoFindAll(objSpecification);
        }
        public IQueryable<TAggregateRoot> FindAll(ISpecification<TAggregateRoot> objSpecification, Expression<Func<TAggregateRoot, dynamic>> objSortPredicate, SortOrder iSortOrder)
        {
            return this.DoFindAll(objSpecification, objSortPredicate, iSortOrder);
        }
        public PagedResult<TAggregateRoot> FindAll(ISpecification<TAggregateRoot> objSpecification, Expression<Func<TAggregateRoot, dynamic>> objSortPredicate, SortOrder iSortOrder, int iPageNumber, int iPageSize)
        {
            return this.DoFindAll(objSortPredicate, iSortOrder, iPageNumber, iPageSize);
        }
        public IQueryable<TAggregateRoot> FindAll(params Expression<Func<TAggregateRoot, dynamic>>[] objEagerLoadingProperties)
        {
            return this.DoFindAll(objEagerLoadingProperties);
        }
        public IQueryable<TAggregateRoot> FindAll(Expression<Func<TAggregateRoot, dynamic>> objSortPredicate, SortOrder iSortOrder, params Expression<Func<TAggregateRoot, dynamic>>[] objEagerLoadingProperties)
        {
            return this.DoFindAll(objSortPredicate, iSortOrder, objEagerLoadingProperties);
        }
        public PagedResult<TAggregateRoot> FindAll(Expression<Func<TAggregateRoot, dynamic>> objSortPredicate, SortOrder iSortOrder, int iPageNumber, int iPageSize, params Expression<Func<TAggregateRoot, dynamic>>[] objEagerLoadingProperties)
        {
            return this.DoFindAll(objSortPredicate, iSortOrder, iPageNumber, iPageSize, objEagerLoadingProperties);
        }
        public IQueryable<TAggregateRoot> FindAll(ISpecification<TAggregateRoot> objSpecification, params Expression<Func<TAggregateRoot, dynamic>>[] objEagerLoadingProperties)
        {
            return this.DoFindAll(objSpecification, objEagerLoadingProperties);
        }
        public IQueryable<TAggregateRoot> FindAll(ISpecification<TAggregateRoot> objSpecification, Expression<Func<TAggregateRoot, dynamic>> objSortPredicate, SortOrder iSortOrder, params Expression<Func<TAggregateRoot, dynamic>>[] objEagerLoadingProperties)
        {
            return this.DoFindAll(objSortPredicate, iSortOrder, objEagerLoadingProperties);
        }
        public PagedResult<TAggregateRoot> FindAll(ISpecification<TAggregateRoot> objSpecification, Expression<Func<TAggregateRoot, dynamic>> objSortPredicate, SortOrder iSortOrder, int iPageNumber, int iPageSize, params Expression<Func<TAggregateRoot, dynamic>>[] objEagerLoadingProperties)
        {
            return this.DoFindAll(objSpecification, objSortPredicate, iSortOrder, iPageNumber, iPageSize, objEagerLoadingProperties);
        }
        public bool Exists(ISpecification<TAggregateRoot> objSpecification)
        {
            return this.DoExists(objSpecification);
        }
        public bool Exists(Expression<Func<TAggregateRoot, bool>> objSpecification)
        {
            return this.DoExists(objSpecification);
        }
        public bool Exists<TModel>(ISpecification<TModel> objSpecification) where TModel : class
        {
            return this.DoExists<TModel>(objSpecification);
        }
        public bool Exists<TModel>(Expression<Func<TModel, bool>> objSpecification) where TModel : class
        {
            return this.DoExists<TModel>(objSpecification);
        }
        public TAggregateRoot Find(ISpecification<TAggregateRoot> objSpecification)
        {
            return this.DoFind(objSpecification);
        }
        public TAggregateRoot Find(ISpecification<TAggregateRoot> objSpecification, params Expression<Func<TAggregateRoot, dynamic>>[] objEagerLoadingProperties)
        {
            return this.DoFind(objSpecification, objEagerLoadingProperties);
        }
        #endregion
    }
}
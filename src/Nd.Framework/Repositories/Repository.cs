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
        private IRepositoryContext context;
        private Guid id = Guid.NewGuid();
        #endregion

        #region Ctor
        public Repository(IRepositoryContext context)
        {
            this.context = context;
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
        protected virtual IQueryable<TAggregateRoot> DoFindAll(ISpecification<TAggregateRoot> specification)
        {
            return this.DoFindAll(specification, null, SortOrder.Unspecified);
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
        protected virtual IQueryable<TAggregateRoot> DoFindAll(ISpecification<TAggregateRoot> specification, params Expression<Func<TAggregateRoot, dynamic>>[] objEagerLoadingProperties)
        {
            return this.DoFindAll(specification, null, SortOrder.Unspecified, objEagerLoadingProperties);
        }
        protected abstract IQueryable<TAggregateRoot> DoFindAll(ISpecification<TAggregateRoot> specification, Expression<Func<TAggregateRoot, dynamic>> objSortPredicate, SortOrder iSortOrder);
        protected abstract PagedResult<TAggregateRoot> DoFindAll(ISpecification<TAggregateRoot> specification, Expression<Func<TAggregateRoot, dynamic>> objSortPredicate, SortOrder iSortOrder, int iPageNumber, int iPageSize);
        protected abstract IQueryable<TAggregateRoot> DoFindAll(ISpecification<TAggregateRoot> specification, Expression<Func<TAggregateRoot, dynamic>> objSortPredicate, SortOrder iSortOrder, params Expression<Func<TAggregateRoot, dynamic>>[] objEagerLoadingProperties);
        protected abstract PagedResult<TAggregateRoot> DoFindAll(ISpecification<TAggregateRoot> specification, Expression<Func<TAggregateRoot, dynamic>> objSortPredicate, SortOrder iSortOrder, int iPageNumber, int iPageSize, params Expression<Func<TAggregateRoot, dynamic>>[] objEagerLoadingProperties);
        protected abstract bool DoExists(ISpecification<TAggregateRoot> specification);
        protected abstract bool DoExists(Expression<Func<TAggregateRoot, bool>> specification);
        protected abstract bool DoExists<TModel>(ISpecification<TModel> specification) where TModel : class;
        protected abstract bool DoExists<TModel>(Expression<Func<TModel, bool>> specification) where TModel : class;
        protected abstract TAggregateRoot DoFind(Expression<Func<TAggregateRoot, bool>> specification);
        protected abstract TAggregateRoot DoFind(ISpecification<TAggregateRoot> specification);
        protected abstract TAggregateRoot DoFind(ISpecification<TAggregateRoot> specification, params Expression<Func<TAggregateRoot, dynamic>>[] objEagerLoadingProperties);
        #endregion

        #region IRepository<TAggregateRoot> Members
        public Guid Id
        {
            get
            {
                return this.id;
            }
        }
        public virtual IRepositoryContext Context
        {
            get
            {
                return this.context;
            }
        }
        public virtual void Create(TAggregateRoot objEntity)
        {
            this.context.Create(objEntity);
        }
        public virtual void Update(TAggregateRoot objEntity)
        {
            this.context.Update(objEntity);
        }
        public virtual void Delete(TAggregateRoot objEntity)
        {
            this.context.Delete(objEntity);
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
        public IQueryable<TAggregateRoot> FindAll(ISpecification<TAggregateRoot> specification)
        {
            return this.DoFindAll(specification);
        }
        public IQueryable<TAggregateRoot> FindAll(ISpecification<TAggregateRoot> specification, Expression<Func<TAggregateRoot, dynamic>> objSortPredicate, SortOrder iSortOrder)
        {
            return this.DoFindAll(specification, objSortPredicate, iSortOrder);
        }
        public PagedResult<TAggregateRoot> FindAll(ISpecification<TAggregateRoot> specification, Expression<Func<TAggregateRoot, dynamic>> objSortPredicate, SortOrder iSortOrder, int iPageNumber, int iPageSize)
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
        public IQueryable<TAggregateRoot> FindAll(ISpecification<TAggregateRoot> specification, params Expression<Func<TAggregateRoot, dynamic>>[] objEagerLoadingProperties)
        {
            return this.DoFindAll(specification, objEagerLoadingProperties);
        }
        public IQueryable<TAggregateRoot> FindAll(ISpecification<TAggregateRoot> specification, Expression<Func<TAggregateRoot, dynamic>> objSortPredicate, SortOrder iSortOrder, params Expression<Func<TAggregateRoot, dynamic>>[] objEagerLoadingProperties)
        {
            return this.DoFindAll(objSortPredicate, iSortOrder, objEagerLoadingProperties);
        }
        public PagedResult<TAggregateRoot> FindAll(ISpecification<TAggregateRoot> specification, Expression<Func<TAggregateRoot, dynamic>> objSortPredicate, SortOrder iSortOrder, int iPageNumber, int iPageSize, params Expression<Func<TAggregateRoot, dynamic>>[] objEagerLoadingProperties)
        {
            return this.DoFindAll(specification, objSortPredicate, iSortOrder, iPageNumber, iPageSize, objEagerLoadingProperties);
        }
        public bool Exists(ISpecification<TAggregateRoot> specification)
        {
            return this.DoExists(specification);
        }
        public bool Exists(Expression<Func<TAggregateRoot, bool>> specification)
        {
            return this.DoExists(specification);
        }
        public bool Exists<TModel>(ISpecification<TModel> specification) where TModel : class
        {
            return this.DoExists<TModel>(specification);
        }
        public bool Exists<TModel>(Expression<Func<TModel, bool>> specification) where TModel : class
        {
            return this.DoExists<TModel>(specification);
        }
        public virtual TAggregateRoot Find(Expression<Func<TAggregateRoot, bool>> specification)
        {
            return this.DoFind(specification);
        }
        public TAggregateRoot Find(ISpecification<TAggregateRoot> specification)
        {
            return this.DoFind(specification);
        }
        public TAggregateRoot Find(ISpecification<TAggregateRoot> specification, params Expression<Func<TAggregateRoot, dynamic>>[] objEagerLoadingProperties)
        {
            return this.DoFind(specification, objEagerLoadingProperties);
        }
        #endregion
    }
}
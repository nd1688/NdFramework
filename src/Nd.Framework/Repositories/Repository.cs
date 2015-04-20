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

        #region 操作对象为聚合
        protected abstract bool DoExists(ISpecification<TAggregateRoot> specification);
        protected abstract bool DoExists(Expression<Func<TAggregateRoot, bool>> specification);

        protected abstract TAggregateRoot DoFind(Expression<Func<TAggregateRoot, bool>> specification);
        protected abstract TAggregateRoot DoFind(ISpecification<TAggregateRoot> specification);
        protected abstract TAggregateRoot DoFind(ISpecification<TAggregateRoot> specification, params Expression<Func<TAggregateRoot, dynamic>>[] objEagerLoadingProperties);

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
        #endregion

        #region 操作对象为所有实体
        protected abstract bool DoExists<TModel>(ISpecification<TModel> specification) where TModel : class;
        protected abstract bool DoExists<TModel>(Expression<Func<TModel, bool>> specification) where TModel : class;

        protected abstract TModel DoFind<TModel>(Expression<Func<TModel, bool>> specification) where TModel : class;
        protected abstract TModel DoFind<TModel>(ISpecification<TModel> specification) where TModel : class;
        protected abstract TModel DoFind<TModel>(ISpecification<TModel> specification, params Expression<Func<TModel, dynamic>>[] objEagerLoadingProperties) where TModel : class;

        protected virtual IQueryable<TModel> DoFindAll<TModel>() where TModel : class
        {
            return this.DoFindAll(new AnySpecification<TModel>(), null, SortOrder.Unspecified);
        }
        protected virtual IQueryable<TModel> DoFindAll<TModel>(Expression<Func<TModel, dynamic>> objSortPredicate, SortOrder iSortOrder) where TModel : class
        {
            return this.DoFindAll(new AnySpecification<TModel>(), objSortPredicate, iSortOrder);
        }
        protected virtual PagedResult<TModel> DoFindAll<TModel>(Expression<Func<TModel, dynamic>> objSortPredicate, SortOrder iSortOrder, int iPageNumber, int iPageSize) where TModel : class
        {
            return this.DoFindAll(new AnySpecification<TModel>(), objSortPredicate, iSortOrder, iPageNumber, iPageSize);
        }
        protected virtual IQueryable<TModel> DoFindAll<TModel>(ISpecification<TModel> specification) where TModel : class
        {
            return this.DoFindAll(specification, null, SortOrder.Unspecified);
        }
        protected virtual IQueryable<TModel> DoFindAll<TModel>(params Expression<Func<TModel, dynamic>>[] objEagerLoadingProperties) where TModel : class
        {
            return DoFindAll(new AnySpecification<TModel>(), null, SortOrder.Unspecified, objEagerLoadingProperties);
        }
        protected virtual IQueryable<TModel> DoFindAll<TModel>(Expression<Func<TModel, dynamic>> objSortPredicate, SortOrder iSortOrder, params Expression<Func<TModel, dynamic>>[] objEagerLoadingProperties) where TModel : class
        {
            return this.DoFindAll(new AnySpecification<TModel>(), objSortPredicate, iSortOrder, objEagerLoadingProperties);
        }
        protected virtual PagedResult<TModel> DoFindAll<TModel>(Expression<Func<TModel, dynamic>> objSortPredicate, SortOrder iSortOrder, int iPageNumber, int iPageSize, params Expression<Func<TModel, dynamic>>[] objEagerLoadingProperties) where TModel : class
        {
            return this.DoFindAll(new AnySpecification<TModel>(), objSortPredicate, iSortOrder, iPageNumber, iPageSize, objEagerLoadingProperties);
        }
        protected virtual IQueryable<TModel> DoFindAll<TModel>(ISpecification<TModel> specification, params Expression<Func<TModel, dynamic>>[] objEagerLoadingProperties) where TModel : class
        {
            return this.DoFindAll(specification, null, SortOrder.Unspecified, objEagerLoadingProperties);
        }
        protected abstract IQueryable<TModel> DoFindAll<TModel>(ISpecification<TModel> specification, Expression<Func<TModel, dynamic>> objSortPredicate, SortOrder iSortOrder) where TModel : class;
        protected abstract PagedResult<TModel> DoFindAll<TModel>(ISpecification<TModel> specification, Expression<Func<TModel, dynamic>> objSortPredicate, SortOrder iSortOrder, int iPageNumber, int iPageSize) where TModel : class;
        protected abstract IQueryable<TModel> DoFindAll<TModel>(ISpecification<TModel> specification, Expression<Func<TModel, dynamic>> objSortPredicate, SortOrder iSortOrder, params Expression<Func<TModel, dynamic>>[] objEagerLoadingProperties) where TModel : class;
        protected abstract PagedResult<TModel> DoFindAll<TModel>(ISpecification<TModel> specification, Expression<Func<TModel, dynamic>> objSortPredicate, SortOrder iSortOrder, int iPageNumber, int iPageSize, params Expression<Func<TModel, dynamic>>[] objEagerLoadingProperties) where TModel : class;
        #endregion

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

        #region 操作对象为聚合
        public virtual void Create(TAggregateRoot model)
        {
            this.context.Create(model);
        }
        public virtual void Update(TAggregateRoot model)
        {
            this.context.Update(model);
        }
        public virtual void Delete(TAggregateRoot model)
        {
            this.context.Delete(model);
        }

        public bool Exists(ISpecification<TAggregateRoot> specification)
        {
            return this.DoExists(specification);
        }
        public bool Exists(Expression<Func<TAggregateRoot, bool>> specification)
        {
            return this.DoExists(specification);
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
        #endregion

        #region 操作对象为所有实体
        public virtual void Create<TModel>(TModel model) where TModel : class
        {
            this.context.Create(model);
        }
        public virtual void Update<TModel>(TModel model) where TModel : class
        {
            this.context.Update(model);
        }
        public virtual void Delete<TModel>(TModel model) where TModel : class
        {
            this.context.Delete(model);
        }

        public bool Exists<TModel>(ISpecification<TModel> specification) where TModel : class
        {
            return this.DoExists<TModel>(specification);
        }
        public bool Exists<TModel>(Expression<Func<TModel, bool>> specification) where TModel : class
        {
            return this.DoExists<TModel>(specification);
        }

        public virtual TModel Find<TModel>(Expression<Func<TModel, bool>> specification) where TModel : class
        {
            return this.DoFind(specification);
        }
        public TModel Find<TModel>(ISpecification<TModel> specification) where TModel : class
        {
            return this.DoFind(specification);
        }
        public TModel Find<TModel>(ISpecification<TModel> specification, params Expression<Func<TModel, dynamic>>[] objEagerLoadingProperties) where TModel : class
        {
            return this.DoFind(specification, objEagerLoadingProperties);
        }

        public IQueryable<TModel> FindAll<TModel>() where TModel : class
        {
            return this.DoFindAll<TModel>();
        }
        public IQueryable<TModel> FindAll<TModel>(Expression<Func<TModel, dynamic>> objSortPredicate, SortOrder iSortOrder) where TModel : class
        {
            return this.DoFindAll(objSortPredicate, iSortOrder);
        }
        public PagedResult<TModel> FindAll<TModel>(Expression<Func<TModel, dynamic>> objSortPredicate, SortOrder iSortOrder, int iPageNumber, int iPageSize) where TModel : class
        {
            return this.DoFindAll(objSortPredicate, iSortOrder, iPageNumber, iPageSize);
        }
        public IQueryable<TModel> FindAll<TModel>(ISpecification<TModel> specification) where TModel : class
        {
            return this.DoFindAll(specification);
        }
        public IQueryable<TModel> FindAll<TModel>(ISpecification<TModel> specification, Expression<Func<TModel, dynamic>> objSortPredicate, SortOrder iSortOrder) where TModel : class
        {
            return this.DoFindAll(specification, objSortPredicate, iSortOrder);
        }
        public PagedResult<TModel> FindAll<TModel>(ISpecification<TModel> specification, Expression<Func<TModel, dynamic>> objSortPredicate, SortOrder iSortOrder, int iPageNumber, int iPageSize) where TModel : class
        {
            return this.DoFindAll(objSortPredicate, iSortOrder, iPageNumber, iPageSize);
        }
        public IQueryable<TModel> FindAll<TModel>(params Expression<Func<TModel, dynamic>>[] objEagerLoadingProperties) where TModel : class
        {
            return this.DoFindAll(objEagerLoadingProperties);
        }
        public IQueryable<TModel> FindAll<TModel>(Expression<Func<TModel, dynamic>> objSortPredicate, SortOrder iSortOrder, params Expression<Func<TModel, dynamic>>[] objEagerLoadingProperties) where TModel : class
        {
            return this.DoFindAll(objSortPredicate, iSortOrder, objEagerLoadingProperties);
        }
        public PagedResult<TModel> FindAll<TModel>(Expression<Func<TModel, dynamic>> objSortPredicate, SortOrder iSortOrder, int iPageNumber, int iPageSize, params Expression<Func<TModel, dynamic>>[] objEagerLoadingProperties) where TModel : class
        {
            return this.DoFindAll(objSortPredicate, iSortOrder, iPageNumber, iPageSize, objEagerLoadingProperties);
        }
        public IQueryable<TModel> FindAll<TModel>(ISpecification<TModel> specification, params Expression<Func<TModel, dynamic>>[] objEagerLoadingProperties) where TModel : class
        {
            return this.DoFindAll(specification, objEagerLoadingProperties);
        }
        public IQueryable<TModel> FindAll<TModel>(ISpecification<TModel> specification, Expression<Func<TModel, dynamic>> objSortPredicate, SortOrder iSortOrder, params Expression<Func<TModel, dynamic>>[] objEagerLoadingProperties) where TModel : class
        {
            return this.DoFindAll(objSortPredicate, iSortOrder, objEagerLoadingProperties);
        }
        public PagedResult<TModel> FindAll<TModel>(ISpecification<TModel> specification, Expression<Func<TModel, dynamic>> objSortPredicate, SortOrder iSortOrder, int iPageNumber, int iPageSize, params Expression<Func<TModel, dynamic>>[] objEagerLoadingProperties) where TModel : class
        {
            return this.DoFindAll(specification, objSortPredicate, iSortOrder, iPageNumber, iPageSize, objEagerLoadingProperties);
        }
        #endregion

        #endregion
    }
}
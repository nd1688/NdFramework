using Nd.Framework.Specifications;
using System;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;

namespace Nd.Framework.Repositories
{
    /// <summary>
    /// 仓储服务
    /// </summary>
    /// <typeparam name="TAggregateRoot">聚合</typeparam>
    public interface IRepository<TAggregateRoot>
        where TAggregateRoot : class, IAggregateRoot
    {
        Guid Id
        {
            get;
        }

        IRepositoryContext Context { get; }

        #region 操作对象为聚合
        void Create(TAggregateRoot aggregateRoot);
        void Delete(TAggregateRoot aggregateRoot);
        void Update(TAggregateRoot aggregateRoot);

        bool Exists(Expression<Func<TAggregateRoot, bool>> specification);
        bool Exists(ISpecification<TAggregateRoot> specification);

        TAggregateRoot Find(Expression<Func<TAggregateRoot, bool>> specification);
        TAggregateRoot Find(Expression<Func<TAggregateRoot, bool>> specification, params Expression<Func<TAggregateRoot, dynamic>>[] eagerLoadingProperties);
        TAggregateRoot Find(ISpecification<TAggregateRoot> specification);
        TAggregateRoot Find(ISpecification<TAggregateRoot> specification, params Expression<Func<TAggregateRoot, dynamic>>[] eagerLoadingProperties);

        IQueryable<TAggregateRoot> FindAll();
        IQueryable<TAggregateRoot> FindAll(Expression<Func<TAggregateRoot, dynamic>> sortPredicate, SortOrder sortOrder);
        PagedResult<TAggregateRoot> FindAll(Expression<Func<TAggregateRoot, dynamic>> sortPredicate, SortOrder sortOrder, int pageIndex, int pageSize);
        IQueryable<TAggregateRoot> FindAll(Expression<Func<TAggregateRoot, bool>> specification);
        IQueryable<TAggregateRoot> FindAll(Expression<Func<TAggregateRoot, bool>> specification, Expression<Func<TAggregateRoot, dynamic>> sortPredicate, SortOrder sortOrder);
        PagedResult<TAggregateRoot> FindAll(Expression<Func<TAggregateRoot, bool>> specification, Expression<Func<TAggregateRoot, dynamic>> sortPredicate, SortOrder sortOrder, int pageIndex, int pageSize);
        IQueryable<TAggregateRoot> FindAll(ISpecification<TAggregateRoot> specification);
        IQueryable<TAggregateRoot> FindAll(ISpecification<TAggregateRoot> specification, Expression<Func<TAggregateRoot, dynamic>> sortPredicate, SortOrder sortOrder);
        PagedResult<TAggregateRoot> FindAll(ISpecification<TAggregateRoot> specification, Expression<Func<TAggregateRoot, dynamic>> sortPredicate, SortOrder sortOrder, int pageIndex, int pageSize);
        IQueryable<TAggregateRoot> FindAll(params Expression<Func<TAggregateRoot, dynamic>>[] eagerLoadingProperties);
        IQueryable<TAggregateRoot> FindAll(Expression<Func<TAggregateRoot, dynamic>> sortPredicate, SortOrder sortOrder, params Expression<Func<TAggregateRoot, dynamic>>[] eagerLoadingProperties);
        PagedResult<TAggregateRoot> FindAll(Expression<Func<TAggregateRoot, dynamic>> sortPredicate, SortOrder sortOrder, int pageIndex, int pageSize, params Expression<Func<TAggregateRoot, dynamic>>[] eagerLoadingProperties);
        IQueryable<TAggregateRoot> FindAll(Expression<Func<TAggregateRoot, bool>> specification, params Expression<Func<TAggregateRoot, dynamic>>[] eagerLoadingProperties);
        IQueryable<TAggregateRoot> FindAll(Expression<Func<TAggregateRoot, bool>> specification, Expression<Func<TAggregateRoot, dynamic>> sortPredicate, SortOrder sortOrder, params Expression<Func<TAggregateRoot, dynamic>>[] eagerLoadingProperties);
        PagedResult<TAggregateRoot> FindAll(Expression<Func<TAggregateRoot, bool>> specification, Expression<Func<TAggregateRoot, dynamic>> sortPredicate, SortOrder sortOrder, int pageIndex, int pageSize, params Expression<Func<TAggregateRoot, dynamic>>[] eagerLoadingProperties);
        IQueryable<TAggregateRoot> FindAll(ISpecification<TAggregateRoot> specification, params Expression<Func<TAggregateRoot, dynamic>>[] eagerLoadingProperties);
        IQueryable<TAggregateRoot> FindAll(ISpecification<TAggregateRoot> specification, Expression<Func<TAggregateRoot, dynamic>> sortPredicate, SortOrder sortOrder, params Expression<Func<TAggregateRoot, dynamic>>[] eagerLoadingProperties);
        PagedResult<TAggregateRoot> FindAll(ISpecification<TAggregateRoot> specification, Expression<Func<TAggregateRoot, dynamic>> sortPredicate, SortOrder sortOrder, int pageIndex, int pageSize, params Expression<Func<TAggregateRoot, dynamic>>[] eagerLoadingProperties);
        #endregion

        #region 操作对象为所有实体
        void Create<TModel>(TModel model) where TModel : class;
        void Delete<TModel>(TModel model) where TModel : class;
        void Update<TModel>(TModel model) where TModel : class;

        bool Exists<TModel>(ISpecification<TModel> specification) where TModel : class;
        bool Exists<TModel>(Expression<Func<TModel, bool>> specification) where TModel : class;

        TModel Find<TModel>(Expression<Func<TModel, bool>> specification) where TModel : class;
        TModel Find<TModel>(Expression<Func<TModel, bool>> specification, params Expression<Func<TModel, dynamic>>[] eagerLoadingProperties) where TModel : class;
        TModel Find<TModel>(ISpecification<TModel> specification) where TModel : class;
        TModel Find<TModel>(ISpecification<TModel> specification, params Expression<Func<TModel, dynamic>>[] eagerLoadingProperties) where TModel : class;

        IQueryable<TModel> FindAll<TModel>() where TModel : class;
        IQueryable<TModel> FindAll<TModel>(Expression<Func<TModel, dynamic>> sortPredicate, SortOrder sortOrder) where TModel : class;
        PagedResult<TModel> FindAll<TModel>(Expression<Func<TModel, dynamic>> sortPredicate, SortOrder sortOrder, int pageIndex, int pageSize) where TModel : class;
        IQueryable<TModel> FindAll<TModel>(Expression<Func<TModel, bool>> specification) where TModel : class;
        IQueryable<TModel> FindAll<TModel>(Expression<Func<TModel, bool>> specification, Expression<Func<TModel, dynamic>> sortPredicate, SortOrder sortOrder) where TModel : class;
        PagedResult<TModel> FindAll<TModel>(Expression<Func<TModel, bool>> specification, Expression<Func<TModel, dynamic>> sortPredicate, SortOrder sortOrder, int pageIndex, int pageSize) where TModel : class;
        IQueryable<TModel> FindAll<TModel>(ISpecification<TModel> specification) where TModel : class;
        IQueryable<TModel> FindAll<TModel>(ISpecification<TModel> specification, Expression<Func<TModel, dynamic>> sortPredicate, SortOrder sortOrder) where TModel : class;
        PagedResult<TModel> FindAll<TModel>(ISpecification<TModel> specification, Expression<Func<TModel, dynamic>> sortPredicate, SortOrder sortOrder, int pageIndex, int pageSize) where TModel : class;
        IQueryable<TModel> FindAll<TModel>(params Expression<Func<TModel, dynamic>>[] eagerLoadingProperties) where TModel : class;
        IQueryable<TModel> FindAll<TModel>(Expression<Func<TModel, dynamic>> sortPredicate, SortOrder sortOrder, params Expression<Func<TModel, dynamic>>[] eagerLoadingProperties) where TModel : class;
        PagedResult<TModel> FindAll<TModel>(Expression<Func<TModel, dynamic>> sortPredicate, SortOrder sortOrder, int pageIndex, int pageSize, params Expression<Func<TModel, dynamic>>[] eagerLoadingProperties) where TModel : class;
        IQueryable<TModel> FindAll<TModel>(Expression<Func<TModel, bool>> specification, params Expression<Func<TModel, dynamic>>[] eagerLoadingProperties) where TModel : class;
        IQueryable<TModel> FindAll<TModel>(Expression<Func<TModel, bool>> specification, Expression<Func<TModel, dynamic>> sortPredicate, SortOrder sortOrder, params Expression<Func<TModel, dynamic>>[] eagerLoadingProperties) where TModel : class;
        PagedResult<TModel> FindAll<TModel>(Expression<Func<TModel, bool>> specification, Expression<Func<TModel, dynamic>> sortPredicate, SortOrder sortOrder, int pageIndex, int pageSize, params Expression<Func<TModel, dynamic>>[] eagerLoadingProperties) where TModel : class;
        IQueryable<TModel> FindAll<TModel>(ISpecification<TModel> specification, params Expression<Func<TModel, dynamic>>[] eagerLoadingProperties) where TModel : class;
        IQueryable<TModel> FindAll<TModel>(ISpecification<TModel> specification, Expression<Func<TModel, dynamic>> sortPredicate, SortOrder sortOrder, params Expression<Func<TModel, dynamic>>[] eagerLoadingProperties) where TModel : class;
        PagedResult<TModel> FindAll<TModel>(ISpecification<TModel> specification, Expression<Func<TModel, dynamic>> sortPredicate, SortOrder sortOrder, int pageIndex, int pageSize, params Expression<Func<TModel, dynamic>>[] eagerLoadingProperties) where TModel : class;
        #endregion
    }
}
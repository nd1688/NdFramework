using Nd.Framework.Specifications;
using System;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;

namespace Nd.Framework.Repositories.EntityFramework
{
    public class EntityFrameworkRepository<TAggregateRoot> : Repository<TAggregateRoot>
        where TAggregateRoot : class, IAggregateRoot
    {
        private IEntityFrameworkRepositoryContext context = null;

        public EntityFrameworkRepository(IRepositoryContext context)
            : base(context)
        {
            this.context = base.Context as IEntityFrameworkRepositoryContext;
        }
        public override IRepositoryContext Context
        {
            get
            {
                return base.Context;
            }
        }
        #region Private Methods
        private MemberExpression GetMemberInfo(LambdaExpression objLambda)
        {
            if (objLambda == null)
                throw new ArgumentNullException("method");

            MemberExpression memberExpr = null;

            if (objLambda.Body.NodeType == ExpressionType.Convert)
            {
                memberExpr =
                    ((UnaryExpression)objLambda.Body).Operand as MemberExpression;
            }
            else if (objLambda.Body.NodeType == ExpressionType.MemberAccess)
            {
                memberExpr = objLambda.Body as MemberExpression;
            }

            if (memberExpr == null)
                throw new ArgumentException("method");

            return memberExpr;
        }

        private string GetEagerLoadingPath(Expression<Func<TAggregateRoot, dynamic>> eagerLoadingProperty)
        {
            return GetEagerLoadingPath<TAggregateRoot>(eagerLoadingProperty);
        }

        private string GetEagerLoadingPath<TModel>(Expression<Func<TModel, dynamic>> eagerLoadingProperty)
        {
            MemberExpression memberExpression = this.GetMemberInfo(eagerLoadingProperty);
            var parameterName = eagerLoadingProperty.Parameters.First().Name;
            var memberExpressionStr = memberExpression.ToString();
            var path = memberExpressionStr.Replace(parameterName + ".", "");
            return path;
        }
        #endregion

        #region Protected Methods

        #region 操作对象为聚合
        protected override bool DoExists(ISpecification<TAggregateRoot> specification)
        {
            return DoExists<TAggregateRoot>(specification);
        }
        protected override bool DoExists(Expression<Func<TAggregateRoot, bool>> specification)
        {
            return DoExists<TAggregateRoot>(specification);
        }
        protected override TAggregateRoot DoFind(Expression<Func<TAggregateRoot, bool>> specification)
        {
            return DoFind<TAggregateRoot>(specification);
        }
        protected override TAggregateRoot DoFind(Expression<Func<TAggregateRoot, bool>> specification, params Expression<Func<TAggregateRoot, dynamic>>[] eagerLoadingProperties)
        {
            return DoFind<TAggregateRoot>(specification, eagerLoadingProperties);
        }
        protected override IQueryable<TAggregateRoot> DoFindAll(Expression<Func<TAggregateRoot, bool>> specification, Expression<Func<TAggregateRoot, dynamic>> sortPredicate, SortOrder sortOrder)
        {
            return DoFindAll<TAggregateRoot>(specification, sortPredicate, sortOrder);
        }
        protected override PagedResult<TAggregateRoot> DoFindAll(Expression<Func<TAggregateRoot, bool>> specification, Expression<Func<TAggregateRoot, dynamic>> sortPredicate, SortOrder sortOrder, int pageIndex, int pageSize)
        {
            return DoFindAll<TAggregateRoot>(specification, sortPredicate, sortOrder, pageIndex, pageSize);
        }
        protected override IQueryable<TAggregateRoot> DoFindAll(Expression<Func<TAggregateRoot, bool>> specification, Expression<Func<TAggregateRoot, dynamic>> sortPredicate, SortOrder sortOrder, params Expression<Func<TAggregateRoot, dynamic>>[] eagerLoadingProperties)
        {
            return DoFindAll<TAggregateRoot>(specification, sortPredicate, sortOrder, eagerLoadingProperties);
        }
        protected override PagedResult<TAggregateRoot> DoFindAll(Expression<Func<TAggregateRoot, bool>> specification, Expression<Func<TAggregateRoot, dynamic>> sortPredicate, SortOrder sortOrder, int pageIndex, int pageSize, params Expression<Func<TAggregateRoot, dynamic>>[] eagerLoadingProperties)
        {
            return DoFindAll<TAggregateRoot>(specification, sortPredicate, sortOrder, pageIndex, pageSize, eagerLoadingProperties);
        }
        protected override TAggregateRoot DoFind(ISpecification<TAggregateRoot> specification)
        {
            return DoFind<TAggregateRoot>(specification);
        }
        protected override TAggregateRoot DoFind(ISpecification<TAggregateRoot> specification, params Expression<Func<TAggregateRoot, dynamic>>[] eagerLoadingProperties)
        {
            return DoFind<TAggregateRoot>(specification, eagerLoadingProperties);
        }
        protected override IQueryable<TAggregateRoot> DoFindAll(ISpecification<TAggregateRoot> specification, Expression<Func<TAggregateRoot, dynamic>> sortPredicate, SortOrder sortOrder)
        {
            return DoFindAll<TAggregateRoot>(specification, sortPredicate, sortOrder);
        }
        protected override PagedResult<TAggregateRoot> DoFindAll(ISpecification<TAggregateRoot> specification, Expression<Func<TAggregateRoot, dynamic>> sortPredicate, SortOrder sortOrder, int pageIndex, int pageSize)
        {
            return DoFindAll<TAggregateRoot>(specification, sortPredicate, sortOrder, pageIndex, pageSize);
        }
        protected override IQueryable<TAggregateRoot> DoFindAll(ISpecification<TAggregateRoot> specification, Expression<Func<TAggregateRoot, dynamic>> sortPredicate, SortOrder sortOrder, params Expression<Func<TAggregateRoot, dynamic>>[] eagerLoadingProperties)
        {
            return DoFindAll<TAggregateRoot>(specification, sortPredicate, sortOrder, eagerLoadingProperties);
        }
        protected override PagedResult<TAggregateRoot> DoFindAll(ISpecification<TAggregateRoot> specification, Expression<Func<TAggregateRoot, dynamic>> sortPredicate, SortOrder sortOrder, int pageIndex, int pageSize, params Expression<Func<TAggregateRoot, dynamic>>[] eagerLoadingProperties)
        {
            return DoFindAll<TAggregateRoot>(specification, sortPredicate, sortOrder, pageIndex, pageSize, eagerLoadingProperties);
        }
        #endregion

        #region 操作对象为所有实体
        protected override bool DoExists<TModel>(Expression<Func<TModel, bool>> specification)
        {
            return this.context.Context.Set<TModel>().AsNoTracking().Count(specification) > 0;
        }
        protected override bool DoExists<TModel>(ISpecification<TModel> specification)
        {
            return DoExists(specification.GetExpression());
        }
        
        protected override TModel DoFind<TModel>(Expression<Func<TModel, bool>> specification)
        {
            return this.context.Context.Set<TModel>().AsNoTracking().Where(specification).FirstOrDefault();
        }
        protected override TModel DoFind<TModel>(Expression<Func<TModel, bool>> specification, params Expression<Func<TModel, dynamic>>[] eagerLoadingProperties)
        {
            var dbset = context.Context.Set<TModel>();
            if (eagerLoadingProperties != null &&
                eagerLoadingProperties.Length > 0)
            {
                var eagerLoadingProperty = eagerLoadingProperties[0];
                var eagerLoadingPath = this.GetEagerLoadingPath(eagerLoadingProperty);
                var dbquery = dbset.AsNoTracking().Include(eagerLoadingPath);
                for (int i = 1; i < eagerLoadingProperties.Length; i++)
                {
                    eagerLoadingProperty = eagerLoadingProperties[i];
                    eagerLoadingPath = this.GetEagerLoadingPath(eagerLoadingProperty);
                    dbquery = dbquery.Include(eagerLoadingPath);
                }
                return dbquery.Where(specification).FirstOrDefault();
            }
            else
                return dbset.AsNoTracking().Where(specification).FirstOrDefault();
        }
        protected override IQueryable<TModel> DoFindAll<TModel>(Expression<Func<TModel, bool>> specification, Expression<Func<TModel, dynamic>> sortPredicate, SortOrder sortOrder)
        {
            var query = context.Context.Set<TModel>().AsNoTracking()
                .Where(specification);
            if (sortPredicate != null)
            {
                switch (sortOrder)
                {
                    case SortOrder.Ascending:
                        return query.OrderBy(sortPredicate);
                    case SortOrder.Descending:
                        return query.OrderByDescending(sortPredicate);
                    default:
                        break;
                }
            }
            return query;
        }
        protected override PagedResult<TModel> DoFindAll<TModel>(Expression<Func<TModel, bool>> specification, Expression<Func<TModel, dynamic>> sortPredicate, SortOrder sortOrder, int pageIndex, int pageSize)
        {
            if (pageIndex <= 0)
                throw new ArgumentOutOfRangeException("pageIndex", pageIndex, "The pageIndex is one-based and should be larger than zero.");
            if (pageSize <= 0)
                throw new ArgumentOutOfRangeException("pageSize", pageSize, "The pageSize is one-based and should be larger than zero.");
            if (sortPredicate == null)
                throw new ArgumentNullException("sortPredicate");

            var query = context.Context.Set<TModel>().AsNoTracking()
                .Where(specification);
            int skip = (pageIndex - 1) * pageSize;
            int take = pageSize;

            switch (sortOrder)
            {
                case SortOrder.Ascending:
                    var pagedGroupAscending = query.OrderBy(sortPredicate).Skip(skip).Take(take).GroupBy(p => new { Total = query.Count() }).FirstOrDefault();
                    if (pagedGroupAscending == null)
                        return null;
                    return new PagedResult<TModel>(pagedGroupAscending.Key.Total, (pagedGroupAscending.Key.Total + pageSize - 1) / pageSize, pageSize, pageIndex, pagedGroupAscending.Select(p => p).ToList());
                case SortOrder.Descending:
                    var pagedGroupDescending = query.OrderByDescending(sortPredicate).Skip(skip).Take(take).GroupBy(p => new { Total = query.Count() }).FirstOrDefault();
                    if (pagedGroupDescending == null)
                        return null;
                    return new PagedResult<TModel>(pagedGroupDescending.Key.Total, (pagedGroupDescending.Key.Total + pageSize - 1) / pageSize, pageSize, pageIndex, pagedGroupDescending.Select(p => p).ToList());
                default:
                    break;
            }

            return null;
        }
        protected override IQueryable<TModel> DoFindAll<TModel>(Expression<Func<TModel, bool>> specification, Expression<Func<TModel, dynamic>> sortPredicate, SortOrder sortOrder, params Expression<Func<TModel, dynamic>>[] eagerLoadingProperties)
        {
            var dbset = context.Context.Set<TModel>();
            IQueryable<TModel> queryable = null;
            if (eagerLoadingProperties != null && eagerLoadingProperties.Length > 0)
            {
                var eagerLoadingProperty = eagerLoadingProperties[0];
                var eagerLoadingPath = this.GetEagerLoadingPath(eagerLoadingProperty);
                var dbquery = dbset.AsNoTracking().Include(eagerLoadingPath);
                for (int i = 1; i < eagerLoadingProperties.Length; i++)
                {
                    eagerLoadingProperty = eagerLoadingProperties[i];
                    eagerLoadingPath = this.GetEagerLoadingPath(eagerLoadingProperty);
                    dbquery = dbquery.Include(eagerLoadingPath);
                }
                queryable = dbquery.Where(specification);
            }
            else
                queryable = dbset.AsNoTracking().Where(specification);

            if (sortPredicate != null)
            {
                switch (sortOrder)
                {
                    case SortOrder.Ascending:
                        return queryable.OrderBy(sortPredicate);
                    case SortOrder.Descending:
                        return queryable.OrderByDescending(sortPredicate);
                    default:
                        break;
                }
            }
            return queryable;
        }
        protected override PagedResult<TModel> DoFindAll<TModel>(Expression<Func<TModel, bool>> specification, Expression<Func<TModel, dynamic>> sortPredicate, SortOrder sortOrder, int pageIndex, int pageSize, params Expression<Func<TModel, dynamic>>[] eagerLoadingProperties)
        {
            if (pageIndex <= 0)
                throw new ArgumentOutOfRangeException("pageIndex", pageIndex, "The pageIndex is one-based and should be larger than zero.");
            if (pageSize <= 0)
                throw new ArgumentOutOfRangeException("pageSize", pageSize, "The pageSize is one-based and should be larger than zero.");
            if (sortPredicate == null)
                throw new ArgumentNullException("sortPredicate");

            int skip = (pageIndex - 1) * pageSize;
            int take = pageSize;

            var dbset = context.Context.Set<TModel>();
            IQueryable<TModel> queryable = null;
            if (eagerLoadingProperties != null &&
                eagerLoadingProperties.Length > 0)
            {
                var eagerLoadingProperty = eagerLoadingProperties[0];
                var eagerLoadingPath = this.GetEagerLoadingPath(eagerLoadingProperty);
                var dbquery = dbset.AsNoTracking().Include(eagerLoadingPath);
                for (int i = 1; i < eagerLoadingProperties.Length; i++)
                {
                    eagerLoadingProperty = eagerLoadingProperties[i];
                    eagerLoadingPath = this.GetEagerLoadingPath(eagerLoadingProperty);
                    dbquery = dbquery.Include(eagerLoadingPath);
                }
                queryable = dbquery.Where(specification);
            }
            else
                queryable = dbset.AsNoTracking().Where(specification);

            switch (sortOrder)
            {
                case SortOrder.Ascending:
                    var pagedGroupAscending = queryable.OrderBy(sortPredicate).Skip(skip).Take(take).GroupBy(p => new { Total = queryable.Count() }).FirstOrDefault();
                    if (pagedGroupAscending == null)
                        return null;
                    return new PagedResult<TModel>(pagedGroupAscending.Key.Total, (pagedGroupAscending.Key.Total + pageSize - 1) / pageSize, pageSize, pageIndex, pagedGroupAscending.Select(p => p).ToList());
                case SortOrder.Descending:
                    var pagedGroupDescending = queryable.OrderByDescending(sortPredicate).Skip(skip).Take(take).GroupBy(p => new { Total = queryable.Count() }).FirstOrDefault();
                    if (pagedGroupDescending == null)
                        return null;
                    return new PagedResult<TModel>(pagedGroupDescending.Key.Total, (pagedGroupDescending.Key.Total + pageSize - 1) / pageSize, pageSize, pageIndex, pagedGroupDescending.Select(p => p).ToList());
                default:
                    break;
            }

            return null;
        }
        protected override TModel DoFind<TModel>(ISpecification<TModel> specification)
        {
            return DoFind(specification.GetExpression());
        }
        protected override TModel DoFind<TModel>(ISpecification<TModel> specification, params Expression<Func<TModel, dynamic>>[] eagerLoadingProperties)
        {
            return DoFind(specification.GetExpression(), eagerLoadingProperties);
        }
        protected override IQueryable<TModel> DoFindAll<TModel>(ISpecification<TModel> specification, Expression<Func<TModel, dynamic>> sortPredicate, SortOrder sortOrder)
        {
            return DoFindAll(specification.GetExpression(), sortPredicate, sortOrder);
        }
        protected override PagedResult<TModel> DoFindAll<TModel>(ISpecification<TModel> specification, Expression<Func<TModel, dynamic>> sortPredicate, SortOrder sortOrder, int pageIndex, int pageSize)
        {
            return DoFindAll(specification.GetExpression(), sortPredicate, sortOrder, pageIndex, pageSize);
        }
        protected override IQueryable<TModel> DoFindAll<TModel>(ISpecification<TModel> specification, Expression<Func<TModel, dynamic>> sortPredicate, SortOrder sortOrder, params Expression<Func<TModel, dynamic>>[] eagerLoadingProperties)
        {
            return DoFindAll(specification.GetExpression(), sortPredicate, sortOrder, eagerLoadingProperties);
        }
        protected override PagedResult<TModel> DoFindAll<TModel>(ISpecification<TModel> specification, Expression<Func<TModel, dynamic>> sortPredicate, SortOrder sortOrder, int pageIndex, int pageSize, params Expression<Func<TModel, dynamic>>[] eagerLoadingProperties)
        {
            return DoFindAll(specification.GetExpression(), sortPredicate, sortOrder, pageIndex, pageSize, eagerLoadingProperties);
        }
        #endregion

        #endregion
    }
}
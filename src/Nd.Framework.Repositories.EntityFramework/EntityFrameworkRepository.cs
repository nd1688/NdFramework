using Nd.Framework.Specifications;
using System;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;

namespace Nd.Framework.Repositories.EntityFramework
{
    public class EntityFrameworkRepositoryContext<TAggregateRoot> : Repository<TAggregateRoot>
        where TAggregateRoot : class, IAggregateRoot
    {
        private IEntityFrameworkRepositoryContext objContext = null;

        public EntityFrameworkRepositoryContext(IRepositoryContext objContext)
            : base(objContext)
        {
            this.objContext = base.Context as IEntityFrameworkRepositoryContext;
        }
        public override IRepositoryContext Context
        {
            get
            {
                return base.Context;
            }
        }
        public IEntityFrameworkRepositoryContext EFContext
        {
            get
            {
                return base.Context as IEntityFrameworkRepositoryContext;
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

        private string GetEagerLoadingPath(Expression<Func<TAggregateRoot, dynamic>> objEagerLoadingProperty)
        {
            MemberExpression memberExpression = this.GetMemberInfo(objEagerLoadingProperty);
            var parameterName = objEagerLoadingProperty.Parameters.First().Name;
            var memberExpressionStr = memberExpression.ToString();
            var path = memberExpressionStr.Replace(parameterName + ".", "");
            return path;
        }
        #endregion

        #region Protected Methods
        protected override IQueryable<TAggregateRoot> DoFindAll(ISpecification<TAggregateRoot> objSpecification, Expression<Func<TAggregateRoot, dynamic>> objSortPredicate, SortOrder iSortOrder)
        {
            var query = objContext.Context.Set<TAggregateRoot>().AsNoTracking()
                .Where(objSpecification.GetExpression());
            if (objSortPredicate != null)
            {
                switch (iSortOrder)
                {
                    case SortOrder.Ascending:
                        return query.OrderBy(objSortPredicate);
                    case SortOrder.Descending:
                        return query.OrderByDescending(objSortPredicate);
                    default:
                        break;
                }
            }
            return query;
        }
        protected override PagedResult<TAggregateRoot> DoFindAll(ISpecification<TAggregateRoot> objSpecification, Expression<Func<TAggregateRoot, dynamic>> objSortPredicate, SortOrder iSortOrder, int iPageNumber, int iPageSize)
        {
            if (iPageNumber <= 0)
                throw new ArgumentOutOfRangeException("iPageNumber", iPageNumber, "The iPageNumber is one-based and should be larger than zero.");
            if (iPageSize <= 0)
                throw new ArgumentOutOfRangeException("iPageSize", iPageSize, "The iPageSize is one-based and should be larger than zero.");
            if (objSortPredicate == null)
                throw new ArgumentNullException("objSortPredicate");

            var query = objContext.Context.Set<TAggregateRoot>().AsNoTracking()
                .Where(objSpecification.GetExpression());
            int skip = (iPageNumber - 1) * iPageSize;
            int take = iPageSize;

            switch (iSortOrder)
            {
                case SortOrder.Ascending:
                    var pagedGroupAscending = query.OrderBy(objSortPredicate).Skip(skip).Take(take).GroupBy(p => new { Total = query.Count() }).FirstOrDefault();
                    if (pagedGroupAscending == null)
                        return null;
                    return new PagedResult<TAggregateRoot>(pagedGroupAscending.Key.Total, (pagedGroupAscending.Key.Total + iPageSize - 1) / iPageSize, iPageSize, iPageNumber, pagedGroupAscending.Select(p => p).ToList());
                case SortOrder.Descending:
                    var pagedGroupDescending = query.OrderByDescending(objSortPredicate).Skip(skip).Take(take).GroupBy(p => new { Total = query.Count() }).FirstOrDefault();
                    if (pagedGroupDescending == null)
                        return null;
                    return new PagedResult<TAggregateRoot>(pagedGroupDescending.Key.Total, (pagedGroupDescending.Key.Total + iPageSize - 1) / iPageSize, iPageSize, iPageNumber, pagedGroupDescending.Select(p => p).ToList());
                default:
                    break;
            }

            return null;
        }
        protected override IQueryable<TAggregateRoot> DoFindAll(ISpecification<TAggregateRoot> objSpecification, Expression<Func<TAggregateRoot, dynamic>> objSortPredicate, SortOrder iSortOrder, params Expression<Func<TAggregateRoot, dynamic>>[] objEagerLoadingProperties)
        {
            var dbset = objContext.Context.Set<TAggregateRoot>();
            IQueryable<TAggregateRoot> queryable = null;
            if (objEagerLoadingProperties != null && objEagerLoadingProperties.Length > 0)
            {
                var eagerLoadingProperty = objEagerLoadingProperties[0];
                var eagerLoadingPath = this.GetEagerLoadingPath(eagerLoadingProperty);
                var dbquery = dbset.AsNoTracking().Include(eagerLoadingPath);
                for (int i = 1; i < objEagerLoadingProperties.Length; i++)
                {
                    eagerLoadingProperty = objEagerLoadingProperties[i];
                    eagerLoadingPath = this.GetEagerLoadingPath(eagerLoadingProperty);
                    dbquery = dbquery.Include(eagerLoadingPath);
                }
                queryable = dbquery.Where(objSpecification.GetExpression());
            }
            else
                queryable = dbset.AsNoTracking().Where(objSpecification.GetExpression());

            if (objSortPredicate != null)
            {
                switch (iSortOrder)
                {
                    case SortOrder.Ascending:
                        return queryable.OrderBy(objSortPredicate);
                    case SortOrder.Descending:
                        return queryable.OrderByDescending(objSortPredicate);
                    default:
                        break;
                }
            }
            return queryable;
        }
        protected override PagedResult<TAggregateRoot> DoFindAll(ISpecification<TAggregateRoot> objSpecification, Expression<Func<TAggregateRoot, dynamic>> objSortPredicate, SortOrder iSortOrder, int iPageNumber, int iPageSize, params Expression<Func<TAggregateRoot, dynamic>>[] objEagerLoadingProperties)
        {
            if (iPageNumber <= 0)
                throw new ArgumentOutOfRangeException("iPageNumber", iPageNumber, "The iPageNumber is one-based and should be larger than zero.");
            if (iPageSize <= 0)
                throw new ArgumentOutOfRangeException("iPageSize", iPageSize, "The iPageSize is one-based and should be larger than zero.");
            if (objSortPredicate == null)
                throw new ArgumentNullException("objSortPredicate");

            int skip = (iPageNumber - 1) * iPageSize;
            int take = iPageSize;

            var dbset = objContext.Context.Set<TAggregateRoot>();
            IQueryable<TAggregateRoot> queryable = null;
            if (objEagerLoadingProperties != null &&
                objEagerLoadingProperties.Length > 0)
            {
                var eagerLoadingProperty = objEagerLoadingProperties[0];
                var eagerLoadingPath = this.GetEagerLoadingPath(eagerLoadingProperty);
                var dbquery = dbset.AsNoTracking().Include(eagerLoadingPath);
                for (int i = 1; i < objEagerLoadingProperties.Length; i++)
                {
                    eagerLoadingProperty = objEagerLoadingProperties[i];
                    eagerLoadingPath = this.GetEagerLoadingPath(eagerLoadingProperty);
                    dbquery = dbquery.Include(eagerLoadingPath);
                }
                queryable = dbquery.Where(objSpecification.GetExpression());
            }
            else
                queryable = dbset.AsNoTracking().Where(objSpecification.GetExpression());

            switch (iSortOrder)
            {
                case SortOrder.Ascending:
                    var pagedGroupAscending = queryable.OrderBy(objSortPredicate).Skip(skip).Take(take).GroupBy(p => new { Total = queryable.Count() }).FirstOrDefault();
                    if (pagedGroupAscending == null)
                        return null;
                    return new PagedResult<TAggregateRoot>(pagedGroupAscending.Key.Total, (pagedGroupAscending.Key.Total + iPageSize - 1) / iPageSize, iPageSize, iPageNumber, pagedGroupAscending.Select(p => p).ToList());
                case SortOrder.Descending:
                    var pagedGroupDescending = queryable.OrderByDescending(objSortPredicate).Skip(skip).Take(take).GroupBy(p => new { Total = queryable.Count() }).FirstOrDefault();
                    if (pagedGroupDescending == null)
                        return null;
                    return new PagedResult<TAggregateRoot>(pagedGroupDescending.Key.Total, (pagedGroupDescending.Key.Total + iPageSize - 1) / iPageSize, iPageSize, iPageNumber, pagedGroupDescending.Select(p => p).ToList());
                default:
                    break;
            }

            return null;
        }
        protected override bool DoExists(ISpecification<TAggregateRoot> objSpecification)
        {
            return this.objContext.Context.Set<TAggregateRoot>().AsNoTracking().Count(objSpecification.GetExpression()) > 0;
        }
        protected override bool DoExists(Expression<Func<TAggregateRoot, bool>> objSpecification)
        {
            return this.objContext.Context.Set<TAggregateRoot>().AsNoTracking().Count(objSpecification) > 0;
        }
        protected override bool DoExists<TModel>(ISpecification<TModel> objSpecification)
        {
            return this.objContext.Context.Set<TModel>().AsNoTracking().Count(objSpecification.GetExpression()) > 0;
        }
        protected override bool DoExists<TModel>(Expression<Func<TModel, bool>> objSpecification)
        {
            return this.objContext.Context.Set<TModel>().AsNoTracking().Count(objSpecification) > 0;
        }
        protected override TAggregateRoot DoFind(Expression<Func<TAggregateRoot, bool>> objSpecification)
        {
            return this.objContext.Context.Set<TAggregateRoot>().AsNoTracking().Where(objSpecification).FirstOrDefault();
        }
        protected override TAggregateRoot DoFind(ISpecification<TAggregateRoot> objSpecification)
        {
            return objContext.Context.Set<TAggregateRoot>().AsNoTracking().Where(objSpecification.IsSatisfiedBy).FirstOrDefault();
        }
        protected override TAggregateRoot DoFind(ISpecification<TAggregateRoot> objSpecification, params Expression<Func<TAggregateRoot, dynamic>>[] objEagerLoadingProperties)
        {
            var dbset = objContext.Context.Set<TAggregateRoot>();
            if (objEagerLoadingProperties != null &&
                objEagerLoadingProperties.Length > 0)
            {
                var eagerLoadingProperty = objEagerLoadingProperties[0];
                var eagerLoadingPath = this.GetEagerLoadingPath(eagerLoadingProperty);
                var dbquery = dbset.AsNoTracking().Include(eagerLoadingPath);
                for (int i = 1; i < objEagerLoadingProperties.Length; i++)
                {
                    eagerLoadingProperty = objEagerLoadingProperties[i];
                    eagerLoadingPath = this.GetEagerLoadingPath(eagerLoadingProperty);
                    dbquery = dbquery.Include(eagerLoadingPath);
                }
                return dbquery.Where(objSpecification.GetExpression()).FirstOrDefault();
            }
            else
                return dbset.AsNoTracking().Where(objSpecification.GetExpression()).FirstOrDefault();
        }
        #endregion
    }
}
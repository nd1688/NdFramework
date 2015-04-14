using Nd.Framework.Specifications;
using System;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;

namespace Nd.Framework.Repositories
{
    public interface IRepository<TAggregateRoot>
        where TAggregateRoot : class, IAggregateRoot
    {
        Guid Id
        {
            get;
        }

        IRepositoryContext Context { get; }

        void Create(TAggregateRoot aggregateRoot);
        void Delete(TAggregateRoot aggregateRoot);
        void Update(TAggregateRoot aggregateRoot);

        bool Exists(ISpecification<TAggregateRoot> specification);
        bool Exists(Expression<Func<TAggregateRoot, bool>> specification);
        bool Exists<TModel>(ISpecification<TModel> objSpecification) where TModel : class;
        bool Exists<TModel>(Expression<Func<TModel, bool>> objSpecification) where TModel : class;

        TAggregateRoot Find(Expression<Func<TAggregateRoot, bool>> specification);
        TAggregateRoot Find(ISpecification<TAggregateRoot> specification);
        TAggregateRoot Find(ISpecification<TAggregateRoot> specification, params Expression<Func<TAggregateRoot, dynamic>>[] eagerLoadingProperties);

        IQueryable<TAggregateRoot> FindAll();
        IQueryable<TAggregateRoot> FindAll(Expression<Func<TAggregateRoot, dynamic>> sortPredicate, SortOrder sortOrder);
        PagedResult<TAggregateRoot> FindAll(Expression<Func<TAggregateRoot, dynamic>> sortPredicate, SortOrder sortOrder, int pageNumber, int pageSize);
        IQueryable<TAggregateRoot> FindAll(ISpecification<TAggregateRoot> specification);
        IQueryable<TAggregateRoot> FindAll(ISpecification<TAggregateRoot> specification, Expression<Func<TAggregateRoot, dynamic>> sortPredicate, SortOrder sortOrder);
        PagedResult<TAggregateRoot> FindAll(ISpecification<TAggregateRoot> specification, Expression<Func<TAggregateRoot, dynamic>> sortPredicate, SortOrder sortOrder, int pageNumber, int pageSize);
        IQueryable<TAggregateRoot> FindAll(params Expression<Func<TAggregateRoot, dynamic>>[] eagerLoadingProperties);
        IQueryable<TAggregateRoot> FindAll(Expression<Func<TAggregateRoot, dynamic>> sortPredicate, SortOrder sortOrder, params Expression<Func<TAggregateRoot, dynamic>>[] eagerLoadingProperties);
        PagedResult<TAggregateRoot> FindAll(Expression<Func<TAggregateRoot, dynamic>> sortPredicate, SortOrder sortOrder, int pageNumber, int pageSize, params Expression<Func<TAggregateRoot, dynamic>>[] eagerLoadingProperties);
        IQueryable<TAggregateRoot> FindAll(ISpecification<TAggregateRoot> specification, params Expression<Func<TAggregateRoot, dynamic>>[] eagerLoadingProperties);
        IQueryable<TAggregateRoot> FindAll(ISpecification<TAggregateRoot> specification, Expression<Func<TAggregateRoot, dynamic>> sortPredicate, SortOrder sortOrder, params Expression<Func<TAggregateRoot, dynamic>>[] eagerLoadingProperties);
        PagedResult<TAggregateRoot> FindAll(ISpecification<TAggregateRoot> specification, Expression<Func<TAggregateRoot, dynamic>> sortPredicate, SortOrder sortOrder, int pageNumber, int pageSize, params Expression<Func<TAggregateRoot, dynamic>>[] eagerLoadingProperties);
    }
}
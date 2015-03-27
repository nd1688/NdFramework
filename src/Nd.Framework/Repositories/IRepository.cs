using Nd.Framework.Specifications;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;

namespace Nd.Framework.Repositories
{
    public interface IRepository<TAggregateRoot>
        where TAggregateRoot : class, IAggregateRoot
    {
        Guid UniquedID
        {
            get;
        }
        IRepositoryContext Context { get; }
        void InitContext(IRepositoryContext objContext);
        T CreateSequence<T>();
        T CreateSequence<T>(string strSequenceCode);
        bool Create(TAggregateRoot aggregateRoot);
        bool Delete(TAggregateRoot aggregateRoot);
        bool Update(TAggregateRoot aggregateRoot);
        bool CreateRange(ICollection<TAggregateRoot> aggregateRootList);
        bool UpdateRange(ICollection<TAggregateRoot> aggregateRootList);
        bool DeleteRange(ICollection<TAggregateRoot> aggregateRootList);
        TAggregateRoot Get(Expression<Func<TAggregateRoot, bool>> objSpecification);
        TAggregateRoot Get(ISpecification<TAggregateRoot> objSpecification);
        bool Exists(ISpecification<TAggregateRoot> objSpecification);
        bool Exists(Expression<Func<TAggregateRoot, bool>> objSpecification);
        bool Exists<TModel>(ISpecification<TModel> objSpecification) where TModel : class;
        bool Exists<TModel>(Expression<Func<TModel, bool>> objSpecification) where TModel : class;
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
        TAggregateRoot Find(ISpecification<TAggregateRoot> specification);
        TAggregateRoot Find(ISpecification<TAggregateRoot> specification, params Expression<Func<TAggregateRoot, dynamic>>[] eagerLoadingProperties);
    }
}
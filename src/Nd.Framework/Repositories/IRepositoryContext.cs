using System;
using System.Collections.Generic;

namespace Nd.Framework.Repositories
{
    public interface IRepositoryContext : IUnitOfWork, IDisposable
    {
        Guid UniquedID { get; }
        bool Create<TDao>(TDao objDao) where TDao : class;
        bool Update<TDao>(TDao objDao) where TDao : class;
        bool Delete<TDao>(TDao objDao) where TDao : class;
        bool CreateRange<TDao>(ICollection<TDao> objDaoList) where TDao : class;
        bool UpdateRange<TDao>(ICollection<TDao> objDaoList) where TDao : class;
        bool DeleteRange<TDao>(ICollection<TDao> objDaoList) where TDao : class;
    }
}
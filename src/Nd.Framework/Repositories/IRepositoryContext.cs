using System;

namespace Nd.Framework.Repositories
{
    /// <summary>
    /// 仓储上下文服务
    /// </summary>
    public interface IRepositoryContext : IUnitOfWork, IDisposable
    {
        /// <summary>
        /// 仓储上下文唯一编号
        /// </summary>
        Guid UniquedId { get; }

        /// <summary>
        /// 创建
        /// </summary>
        /// <typeparam name="T">DAO 数据访问对象</typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        void Create<T>(T obj) where T : class;

        /// <summary>
        /// 修改
        /// </summary>
        void Update<T>(T obj) where T : class;

        /// <summary>
        /// 删除
        /// </summary>
        void Delete<T>(T obj) where T : class;
    }
}
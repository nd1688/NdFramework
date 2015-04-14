
namespace Nd.Framework
{
    /// <summary>
    /// 工作单元服务
    /// </summary>
    public interface IUnitOfWork
    {
        /// <summary>
        /// 获取是否支持微软分布式事务（MS-DTC）
        /// </summary>
        bool DistributedTransactionSupported { get; }

        /// <summary>
        /// 获取是否成功提交事务
        /// </summary>
        bool Committed { get; }

        /// <summary>
        /// 提交事务
        /// </summary>
        void Commit();

        /// <summary>
        /// 回滚事务
        /// </summary>
        void Rollback();
    }
}
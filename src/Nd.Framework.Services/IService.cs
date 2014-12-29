
namespace Nd.Framework.Services
{
    /// <summary>
    /// 表示该接口实现类为服务
    /// </summary>
    public interface IService : IEntity
    {
        /// <summary>
        /// 间隔时间（单位为毫秒）
        /// 当ServiceRunType为BackgroundWorker时，表示此次运行完延后多少毫秒再运行
        /// </summary>
        int Interval { get; set; }

        ServiceRunTimePoint ServiceRunTimePoint { get; set; }

        ServiceRunMode ServiceRunMode { get; set; }

        ServiceRunStatus ServiceRunStatus { get; set; }
    }
}
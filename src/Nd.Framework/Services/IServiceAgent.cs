
namespace Nd.Framework.Services
{
    /// <summary>
    /// 表示该接口实现类为服务运行代理者
    /// </summary>
    public interface IServiceAgent
    {
        /// <summary>
        /// 运行服务
        /// </summary>
        void StartService();

        /// <summary>
        /// 停止服务
        /// </summary>
        void StopService();

        /// <summary>
        /// 暂停服务
        /// </summary>
        void PauseService();
    }
}
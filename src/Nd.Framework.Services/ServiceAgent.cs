using Nd.Framework.Services.Agents;

namespace Nd.Framework.Services
{
    /// <summary>
    /// 服务代理者
    /// </summary>
    /// <typeparam name="TService">服务</typeparam>
    public class ServiceAgent<TService> : IServiceAgent
        where TService : ServiceBase
    {
        #region 私有字段
        private IServiceAgent _serviceRunAgent = null;
        #endregion

        #region 构造函数
        /// <summary>
        /// 初始化一个新的<c>ServiceAgent</c>实例
        /// </summary>
        /// <param name="service">服务</param>
        /// <param name="handler">服务处理程序</param>
        public ServiceAgent(TService service, IServiceHandler<TService> handler)
        {
            switch (service.ServiceRunMode)
            {
                case ServiceRunMode.BackgroundWorker:
                    _serviceRunAgent = new BackgroundWorkerRunAgent<TService>(service, handler);
                    break;
                case ServiceRunMode.Timer:
                    _serviceRunAgent = new TimerRunAgent<TService>(service, handler);
                    break;
            }
        }
        #endregion

        #region IServiceRunMode 成员
        public void StartService()
        {
            _serviceRunAgent.StartService();
        }

        public void StopService()
        {
            _serviceRunAgent.StopService();
        }

        public void PauseService()
        {
            _serviceRunAgent.PauseService();
        }
        #endregion
    }
}
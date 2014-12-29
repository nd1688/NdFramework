using System;

namespace Nd.Framework.Services
{
    /// <summary>
    /// 服务运行代理者基类
    /// </summary>
    /// <typeparam name="TService">服务</typeparam>
    public abstract class ServiceRunAgentBase<TService> : IServiceAgent
        where TService : ServiceBase
    {
        #region 私有字段
        private IServiceHandler<TService> _handler = null;
        /// <summary>
        /// 上次运行时间点
        /// </summary>
        private int _lastHour = 0;
        /// <summary>
        /// 服务处理委托
        /// </summary>
        private delegate void ServiceHandler();
        #endregion

        #region 受保护字段
        protected TService Service = null;
        #endregion

        #region 构造函数
        /// <summary>
        /// 初始化一个新的<c>ServiceRunAgentBase</c>实例
        /// </summary>
        /// <param name="service">服务</param>
        /// <param name="handler">服务处理程序</param>
        public ServiceRunAgentBase(TService service, IServiceHandler<TService> handler)
        {
            _handler = handler;
            this.Service = service;
        }
        #endregion

        #region 受保护方法
        /// <summary>
        /// 执行服务代理
        /// </summary>
        protected void Execute()
        {
            ServiceHandler serviceHandler = new ServiceHandler(Handle);
            AsyncCallback executeCompleted = new AsyncCallback(ExecuteCompleted);
            IAsyncResult asyncResult = serviceHandler.BeginInvoke(executeCompleted, serviceHandler);
        }
        /// <summary>
        /// 运行服务处理程序
        /// </summary>
        protected void Handle()
        {
            try
            {
                if (this.Service.ServiceRunStatus == ServiceRunStatus.Run && CheckRunTimePoint())
                {
                    this._handler.Handle(this.Service);
                }
            }
            catch (Exception) { }
        }
        #endregion

        #region 私有方法
        /// <summary>
        /// 执行完成服务代理
        /// </summary>
        /// <param name="objAsyncResult"></param>
        private void ExecuteCompleted(IAsyncResult objAsyncResult)
        {
            ServiceHandler serviceHandler = objAsyncResult.AsyncState as ServiceHandler;
            serviceHandler.EndInvoke(objAsyncResult);
        }
        /// <summary>
        /// 检查运行时间点
        /// </summary>
        /// <returns>true可以运行，false不可以运行</returns>
        private bool CheckRunTimePoint()
        {
            if ((this.Service.ServiceRunTimePoint & ServiceRunTimePoint.None) > 0)
                return true;

            int currentHour = DateTime.Now.Hour;
            if ((this.Service.ServiceRunTimePoint & Util.GetEnumValue<ServiceRunTimePoint>("H" + currentHour, ServiceRunTimePoint.None)) > 0
                && _lastHour != currentHour)
            {
                _lastHour = currentHour;
                return true;
            }
            else
            {
                _lastHour = currentHour;
                return false;
            }
        }
        #endregion

        #region IServiceRunMode 成员
        public virtual void StartService()
        {
            this.Service.ServiceRunStatus = ServiceRunStatus.Run;
        }

        public virtual void StopService()
        {
            this.Service.ServiceRunStatus = ServiceRunStatus.Stop;
        }

        public virtual void PauseService()
        {
            this.Service.ServiceRunStatus = ServiceRunStatus.Pause;
        }
        #endregion
    }
}
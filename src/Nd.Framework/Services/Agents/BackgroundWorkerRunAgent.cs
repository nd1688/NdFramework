using System.ComponentModel;
using System.Threading;

namespace Nd.Framework.Services.Agents
{
    /// <summary>
    /// 线程封装组件服务运行代理者
    /// 实现延迟一定时间执行一次的效果
    /// </summary>
    internal class BackgroundWorkerRunAgent<TService> : ServiceRunAgentBase<TService>
        where TService : ServiceBase
    {
        #region 私有字段
        /// <summary>
        /// 线程封装组件
        /// </summary>
        private BackgroundWorker _backgroundWorker = null;
        #endregion

        #region 构造函数
        /// <summary>
        /// 初始化一个新的<c>BackgroundWorkerRunAgent</c>实例
        /// </summary>
        /// <param name="service">服务</param>
        /// <param name="handler">服务处理程序</param>
        public BackgroundWorkerRunAgent(TService service, IServiceHandler<TService> handler)
            : base(service, handler)
        {
            _backgroundWorker = new BackgroundWorker();
            _backgroundWorker.DoWork += new DoWorkEventHandler(Execute);
            _backgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(ExecuteCompleted);
        }
        #endregion

        #region 私有方法
        /// <summary>
        /// 执行服务代理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Execute(object sender, DoWorkEventArgs e)
        {
            base.Execute();
        }
        /// <summary>
        /// 执行完成服务代理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExecuteCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (this.Service.ServiceRunStatus == ServiceRunStatus.Stop)
                return;

            if (this.Service.Interval > 0)
                Thread.Sleep(this.Service.Interval);

            BackgroundWorker backgroundWorker = sender as BackgroundWorker;
            backgroundWorker.RunWorkerAsync();
        }
        #endregion

        #region 公共方法
        public override void StartService()
        {
            _backgroundWorker.RunWorkerAsync();
            base.StartService();
        }
        #endregion
    }
}
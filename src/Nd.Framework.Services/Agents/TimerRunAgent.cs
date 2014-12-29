using System.Timers;

namespace Nd.Framework.Services.Agents
{
    /// <summary>
    /// 计时器服务运行代理者
    /// 实现在指定时间内运行一次的效果
    /// </summary>
    /// <typeparam name="TService">服务</typeparam>
    internal class TimerRunAgent<TService> : ServiceRunAgentBase<TService>
        where TService : ServiceBase
    {
        #region 私有字段
        /// <summary>
        /// 计时器
        /// </summary>
        private Timer _timer = null;
        #endregion

        #region 构造函数
        /// <summary>
        /// 初始化一个新的<c>TimerRunAgent</c>实例
        /// </summary>
        /// <param name="service">服务</param>
        /// <param name="handler">服务处理程序</param>
        public TimerRunAgent(TService service, IServiceHandler<TService> handler)
            : base(service, handler)
        {
            _timer = new Timer(service.Interval);
            _timer.Elapsed += new ElapsedEventHandler(Execute);
        }
        #endregion

        #region 私有方法
        /// <summary>
        /// 执行服务代理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Execute(object sender, ElapsedEventArgs e)
        {
            base.Execute();
        }
        #endregion

        #region 公共方法
        public override void StartService()
        {
            _timer.Start();
            base.StartService();
        }

        public override void StopService()
        {
            _timer.Stop();
            base.StopService();
        }
        #endregion
    }
}
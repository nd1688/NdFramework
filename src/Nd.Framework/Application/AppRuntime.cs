using Nd.Framework.Caching;
using Nd.Framework.Configuration;
using Nd.Framework.Core;
using Nd.Framework.Logging;

namespace Nd.Framework.Application
{
    /// <summary>
    /// 应用运行时
    /// </summary>
    public sealed class AppRuntime
    {
        #region 私有字段
        private static readonly AppRuntime instance = new AppRuntime();
        private static readonly object lockObj = new object();

        private IApp currentApplication = null;
        #endregion

        #region 公共属性
        public static AppRuntime Instance
        {
            get { return instance; }
        }

        /// <summary>
        /// 当前应用
        /// </summary>
        public IApp CurrentApplication
        {
            get { return currentApplication; }
        }

        /// <summary>
        /// IOC容器
        /// </summary>
        public INdContainer Container
        {
            get { return this.currentApplication.ObjectContainer; }
        }

        /// <summary>
        /// 日志记录器
        /// </summary>
        public ILogger Logger
        {
            get { return this.currentApplication.Logger; }
        }

        /// <summary>
        /// 缓存服务
        /// </summary>
        public ICache Cache
        {
            get { return this.currentApplication.Cache; }
        }

        /// <summary>
        /// 获取系统平台类型
        /// </summary>
        public Platform Platform
        {
            get { return this.currentApplication.Platform; }
        }
        #endregion

        #region 公共方法
        /// <summary>
        /// 创建一个新的应用
        /// </summary>
        /// <param name="configSource">应用配置</param>
        /// <returns></returns>
        public static IApp Create(IConfigSource configSource)
        {
            lock (lockObj)
            {
                if (instance.currentApplication == null)
                {
                    instance.currentApplication = new App(configSource);
                }
            }
            return instance.currentApplication;
        }
        #endregion

        #region 构造函数
        static AppRuntime() { }
        private AppRuntime() { }
        #endregion
    }
}
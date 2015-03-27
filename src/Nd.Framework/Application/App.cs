using Nd.Framework.Configuration;
using Nd.Framework.Core;
using Nd.Framework.Core.Castle;
using Nd.Framework.Logging;
using System;

namespace Nd.Framework.Application
{
    /// <summary>
    /// 应用组件
    /// </summary>
    public class App : BooleanDisposable, IApp
    {
        #region 私有字段
        private readonly IConfigSource configSource;
        private readonly INdContainer objectContainer;
        #endregion

        #region 构造函数
        /// <summary>
        /// 初始化一个新的<c>App</c>实例
        /// </summary>
        /// <param name="configSource">应用配置</param>
        public App(IConfigSource configSource)
        {
            this.configSource = configSource;
            this.objectContainer = new CastleContainer();
        }
        #endregion

        #region IApp 成员
        public IConfigSource ConfigSource
        {
            get { return this.configSource; }
        }

        public INdContainer ObjectContainer
        {
            get { return this.objectContainer; }
        }

        public ILogger Logger
        {
            get
            {
                if (this.objectContainer.HasRegister<ILogger>())
                {
                    return this.objectContainer.Resolve<ILogger>();
                }
                return new TraceLogger();
            }
        }

        public void Start()
        {
            this.DoInit();
            this.OnStart();
        }

        public event EventHandler<AppInitEventArgs> Initialize;
        #endregion

        #region 受保护方法
        /// <summary>
        /// 启动应用
        /// </summary>
        protected virtual void OnStart() { }

        /// <summary>
        /// 释放资源
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            if (!disposing) return;
            if (this.objectContainer != null)
            {
                this.objectContainer.Dispose();
            }
        }
        #endregion

        #region 私有方法
        /// <summary>
        /// 初始化应用
        /// </summary>
        private void DoInit()
        {
            EventHandler<AppInitEventArgs> handler = this.Initialize;
            if (handler != null)
                handler(this, new AppInitEventArgs(this.configSource, this.objectContainer));
        }
        #endregion
    }
}
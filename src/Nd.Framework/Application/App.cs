﻿using Nd.Framework.Caching;
using Nd.Framework.Configuration;
using Nd.Framework.Core;
using Nd.Framework.Logging;
using System;

namespace Nd.Framework.Application
{
    /// <summary>
    /// 应用组件
    /// </summary>
    public class App : DisposableObject, IApp
    {
        #region 私有字段
        private readonly IConfigSource configSource;
        private readonly INdContainer container;
        #endregion

        #region 构造函数
        /// <summary>
        /// 初始化一个新的<c>App</c>实例
        /// </summary>
        /// <param name="configSource">应用配置</param>
        public App(IConfigSource configSource)
        {
            if (configSource == null)
                throw new ArgumentNullException("配置源不能为空");
            if (configSource.Config == null)
                throw new ConfigurationException("框架配置节未定义");
            if (configSource.Config.ObjectContainers == null)
                throw new ConfigurationException("框架配置节中未找到核心配置节点");

            this.configSource = configSource;
            Type containerType = Type.GetType(configSource.Config.ObjectContainers.Provider);
            this.container = (INdContainer)Activator.CreateInstance(containerType, configSource);
        }
        #endregion

        #region IApp 成员
        public IConfigSource ConfigSource
        {
            get { return this.configSource; }
        }

        public INdContainer ObjectContainer
        {
            get { return this.container; }
        }

        public ILogger Logger
        {
            get
            {
                if (this.container.HasRegister<ILogger>())
                {
                    return this.container.Resolve<ILogger>();
                }
                return new TraceLogger();
            }
        }

        public ICache Cache
        {
            get
            {
                if (this.container.HasRegister<ICache>())
                {
                    return this.container.Resolve<ICache>();
                }
                return null;
            }
        }

        public Platform Platform
        {
            get
            {
                switch (IntPtr.Size)
                {
                    case 4: return Platform.Win32;
                    case 8: return Platform.Win64;
                    default: return Platform.Other;
                }
            }
        }

        public void Start()
        {
            this.DoInit();
            this.OnStart();
        }

        public IApp Register(Action<INdContainer> handler)
        {
            handler(this.container);
            return this;
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
            if (this.container != null)
            {
                this.container.Dispose();
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
                handler(this, new AppInitEventArgs(this.configSource, this.container));
        }
        #endregion
    }
}
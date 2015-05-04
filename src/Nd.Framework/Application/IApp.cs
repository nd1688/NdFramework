using Nd.Framework.Bus;
using Nd.Framework.Caching;
using Nd.Framework.Configuration;
using Nd.Framework.Core;
using Nd.Framework.Logging;
using System;

namespace Nd.Framework.Application
{
    /// <summary>
    /// 应用服务
    /// </summary>
    public interface IApp
    {
        /// <summary>
        /// 获取<see cref="Nd.Framework.Configuration.IConfigSource"/>实例
        /// 应用配置
        /// </summary>
        IConfigSource ConfigSource { get; }

        /// <summary>
        /// 获取<see cref="Nd.Framework.Core.INdContainer"/>实例
        /// IOC容器
        /// </summary>
        INdContainer ObjectContainer { get; }

        /// <summary>
        /// 日志记录器
        /// </summary>
        ILogger Logger { get; }

        /// <summary>
        /// 获取<see cref="Nd.Framework.Caching.ICache"/>实例
        /// </summary>
        ICache Cache { get; }

        /// <summary>
        /// 获取<see cref="Nd.Framework.Bus.IBus"/>实例
        /// </summary>
        IBus Bus { get; }

        /// <summary>
        /// 获取系统平台类型
        /// </summary>
        Platform Platform { get; }

        /// <summary>
        /// 启动应用
        /// </summary>
        void Start();

        /// <summary>
        /// 注册框架组件
        /// </summary>
        IApp Register(Action<INdContainer> handler);

        /// <summary>
        /// 应用初始化事件
        /// </summary>
        event EventHandler<AppInitEventArgs> Initialize;
    }
}
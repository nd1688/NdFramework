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
        /// 启动应用
        /// </summary>
        void Start();

        /// <summary>
        /// 应用初始化事件
        /// </summary>
        event EventHandler<AppInitEventArgs> Initialize;
    }
}
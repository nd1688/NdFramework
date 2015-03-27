using Nd.Framework.Configuration;
using Nd.Framework.Core;
using System;

namespace Nd.Framework.Application
{
    /// <summary>
    /// 应用初始化事件参数
    /// </summary>
    public class AppInitEventArgs : EventArgs
    {
        #region 公共属性
        /// <summary>
        /// 应用配置
        /// </summary>
        public IConfigSource ConfigSource { get; private set; }

        /// <summary>
        /// IOC容器
        /// </summary>
        public INdContainer ObjectContainer { get; private set; }
        #endregion

        #region 构造函数
        /// <summary>
        /// 初始化一个新的<c>AppInitEventArgs</c>实例
        /// </summary>
        public AppInitEventArgs()
            : this(null, null)
        { }

        /// <summary>
        /// 初始化一个新的<c>AppInitEventArgs</c>实例
        /// </summary>
        /// <param name="configSource">应用配置</param>
        /// <param name="objectContainer">IOC容器</param>
        public AppInitEventArgs(IConfigSource configSource, INdContainer objectContainer)
        {
            this.ConfigSource = configSource;
            this.ObjectContainer = objectContainer;
        }
        #endregion
    }
}
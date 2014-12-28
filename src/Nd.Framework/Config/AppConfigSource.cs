using System.Configuration;

namespace Nd.Framework.Config
{
    /// <summary>
    /// Nd.Framework框架的配置源，使用application/web配置文件
    /// </summary>
    public class AppConfigSource : IConfigSource
    {
        #region 私有字段
        private NdFrameworkConfigSection _config;
        #endregion

        #region 构造函数
        /// <summary>
        /// 初始化一个新的<c>AppConfigSource</c>实例
        /// </summary>
        public AppConfigSource()
        {
            this._config = NdFrameworkConfigSection.Instance;
        }
        /// <summary>
        /// 初始化一个新的<c>AppConfigSource</c>实例
        /// </summary>
        /// <param name="configSectionName">配置节点名称</param>
        public AppConfigSource(string configSectionName)
        {
            this._config = (NdFrameworkConfigSection)ConfigurationManager.GetSection(configSectionName);
        }
        #endregion

        #region IConfigSource 成员
        public NdFrameworkConfigSection Config
        {
            get { return this._config; }
        }
        #endregion
    }
}
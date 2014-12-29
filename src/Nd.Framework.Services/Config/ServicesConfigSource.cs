using System.Configuration;

namespace Nd.Framework.Services.Config
{
    /// <summary>
    /// Nd.Framework.Services框架的配置源，使用application/web配置文件
    /// </summary>
    public class ServicesConfigSource : IConfigSource
    {
        #region 私有字段
        private ServicesConfigSection _config;
        #endregion

        #region 构造函数
        /// <summary>
        /// 初始化一个新的<c>AppConfigSource</c>实例
        /// </summary>
        public ServicesConfigSource()
        {
            this._config = ServicesConfigSection.Instance;
        }
        /// <summary>
        /// 初始化一个新的<c>AppConfigSource</c>实例
        /// </summary>
        /// <param name="configSectionName">配置节点名称</param>
        public ServicesConfigSource(string configSectionName)
        {
            this._config = (ServicesConfigSection)ConfigurationManager.GetSection(configSectionName);
        }
        #endregion

        #region IConfigSource 成员
        public ServicesConfigSection Config
        {
            get { return this._config; }
        }
        #endregion
    }
}
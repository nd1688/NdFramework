using System;

namespace Nd.Framework.Configuration
{
    /// <summary>
    /// 表示错误发生在配置里
    /// </summary>
    [Serializable]
    public class ConfigurationException : NdFrameworkException
    {
        #region 构造函数
        public ConfigurationException() : base() { }

        public ConfigurationException(string message) : base(message) { }

        public ConfigurationException(string message, Exception innerException) : base(message, innerException) { }

        public ConfigurationException(string format, params object[] args) : base(string.Format(format, args)) { }
        #endregion
    }
}
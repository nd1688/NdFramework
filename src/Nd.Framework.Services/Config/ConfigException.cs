﻿using System;

namespace Nd.Framework.Services.Config
{
    /// <summary>
    /// 表示错误发生在配置里
    /// </summary>
    [Serializable]
    public class ConfigException : NdException
    {
        #region 构造函数
        public ConfigException() : base() { }

        public ConfigException(string message) : base(message) { }

        public ConfigException(string message, Exception innerException) : base(message, innerException) { }

        public ConfigException(string format, params object[] args) : base(string.Format(format, args)) { }
        #endregion
    }
}
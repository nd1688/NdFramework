using System;

namespace Nd.Framework
{
    /// <summary>
    /// 表示错误发生在Nd.Framework框架里
    /// </summary>
    [Serializable]
    public class NdFrameworkException : Exception
    {
        #region 构造函数
        /// <summary>
        /// 初始化一个新的<c>NdFrameworkException</c>实例
        /// </summary>
        public NdFrameworkException() : base() { }

        /// <summary>
        /// 初始化一个新的<c>NdFrameworkException</c>实例
        /// </summary>
        /// <param name="message">错误信息</param>
        public NdFrameworkException(string message) : base(message) { }

        /// <summary>
        /// 初始化一个新的<c>NdFrameworkException</c>实例
        /// </summary>
        /// <param name="message">错误信息</param>
        /// <param name="innerException">内部异常</param>
        public NdFrameworkException(string message, Exception innerException) : base(message, innerException) { }

        /// <summary>
        /// 初始化一个新的<c>NdFrameworkException</c>实例
        /// </summary>
        /// <param name="format">格式化字符串</param>
        /// <param name="args">格式化参数</param>
        public NdFrameworkException(string format, params object[] args) : base(string.Format(format, args)) { }
        #endregion
    }
}
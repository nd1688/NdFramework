using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nd.Framework.Services
{
    /// <summary>
    /// 表示错误发生在服务里
    /// </summary>
    public class ServiceException : NdException
    {
        #region 构造函数
        public ServiceException() : base() { }

        public ServiceException(string message) : base(message) { }

        public ServiceException(string message, Exception innerException) : base(message, innerException) { }

        public ServiceException(string format, params object[] args) : base(string.Format(format, args)) { }
        #endregion
    }
}
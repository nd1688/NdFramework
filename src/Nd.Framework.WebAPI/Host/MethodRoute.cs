using System;
using System.Collections.Generic;

namespace Nd.Framework.WebAPI.Host
{
    /// <summary>
    /// WebAPI接口方法路由协定实现类
    /// </summary>
    public class MethodRoute : IMethodRoute
    {
        #region 私有字段
        /// <summary>
        /// WebAPI接口方法
        /// </summary>
        private readonly string _methodName;
        /// <summary>
        /// 
        /// </summary>
        private readonly Type _requestType;
        #endregion

        #region 构造函数
        public MethodRoute(Type requestType, string methodName) : this(requestType, methodName, null) { }
        public MethodRoute(Type requestType, string methodName, string httpVerbs)
        {
            _methodName = methodName;
            _requestType = requestType;

            //_typeDeserializer = new StringMapTypeDeserializer(this.RequestType);
        }
        #endregion

        #region IMethodRoute 成员
        public string MethodName
        {
            get { return _methodName; }
        }

        public Type RequestType
        {
            get { return _requestType; }
        }

        public object CreateRequest(Dictionary<string, string> queryStringAndFormData, object requestInstance)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
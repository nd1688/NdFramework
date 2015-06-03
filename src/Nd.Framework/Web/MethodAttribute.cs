using System;

namespace Nd.Framework.Web
{
    /// <summary>
    /// 接口方法特性
    /// </summary>
    public class MethodAttribute : Attribute
    {
        #region 私有字段
        private string methodName;
        #endregion

        #region 构造函数
        public MethodAttribute(string methodName)
        {
            this.methodName = methodName;
        }
        #endregion

        #region 公共属性
        public string MethodName
        {
            get { return this.methodName; }
            set { this.methodName = value; }
        }
        #endregion
    }
}
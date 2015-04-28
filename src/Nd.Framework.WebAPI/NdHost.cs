using System.Reflection;

namespace Nd.Framework.WebAPI
{
    /// <summary>
    /// WebAPI宿主基类
    /// </summary>
    public abstract class NdHost : IAppHost
    {
        #region 公共属性
        public static NdHost Instance { get; protected set; }
        public string ServiceName { get; set; }
        #endregion

        #region 构造函数
        public NdHost(string serviceName, params Assembly[] assembliesWithServices)
        {
            ServiceName = serviceName;
        }
        #endregion

        #region 公共方法
        public virtual NdHost Init()
        {
            Instance = this;
            return this;
        }
        #endregion
    }
}
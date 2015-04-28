using System.Reflection;

namespace Nd.Framework.WebAPI
{
    /// <summary>
    /// 表示用ASP.NET应用程序作为WebAPI宿主
    /// </summary>
    public abstract class AppHostBase : NdHost
    {
        #region 构造函数
        public AppHostBase(string serviceName, params Assembly[] assembliesWithServices)
            : base(serviceName, assembliesWithServices)
        {

        }
        #endregion
    }
}
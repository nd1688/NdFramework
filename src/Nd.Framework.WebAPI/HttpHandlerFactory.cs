using System.Web;

namespace Nd.Framework.WebAPI
{
    /// <summary>
    /// 实现Http请求拦截处理
    /// </summary>
    public class HttpHandlerFactory : IHttpHandlerFactory
    {
        #region IHttpHandlerFactory 成员
        public IHttpHandler GetHandler(HttpContext context, string requestType, string url, string pathTranslated)
        {
            throw new System.NotImplementedException();
        }

        public void ReleaseHandler(IHttpHandler handler)
        {
            throw new System.NotImplementedException();
        }
        #endregion
    }
}
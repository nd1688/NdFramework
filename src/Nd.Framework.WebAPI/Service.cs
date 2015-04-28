using System;

namespace Nd.Framework.WebAPI
{
    /// <summary>
    /// WebAPI服务基类
    /// </summary>
    public abstract class Service : IService, IDisposable
    {
        #region IService 成员

        #endregion

        #region IDisposable 成员
        public void Dispose()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
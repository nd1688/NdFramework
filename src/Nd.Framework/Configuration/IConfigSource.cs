
namespace Nd.Framework.Configuration
{
    /// <summary>
    /// Nd.Framework框架配置源服务
    /// </summary>
    public interface IConfigSource
    {
        /// <summary>
        /// 获取<see cref="Nd.Framework.Configuration.NdFrameworkConfigSection"/>实例
        /// </summary>
        NdFrameworkConfigSection Config { get; }
    }
}
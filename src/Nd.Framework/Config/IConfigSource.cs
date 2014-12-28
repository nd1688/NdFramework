
namespace Nd.Framework.Config
{
    /// <summary>
    /// 表示该实现类为Nd.Framework框架的配置源
    /// </summary>
    public interface IConfigSource
    {
        /// <summary>
        /// 获取<see cref="Nd.Framework.Config.NdFrameworkConfigSection"/>实例
        /// </summary>
        NdFrameworkConfigSection Config { get; }
    }
}
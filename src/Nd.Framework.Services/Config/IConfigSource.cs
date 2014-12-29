
namespace Nd.Framework.Services.Config
{
    /// <summary>
    /// 表示该实现类为Nd.Framework.Services框架的配置源
    /// </summary>
    public interface IConfigSource
    {
        /// <summary>
        /// 获取<see cref="Nd.Framework.Services.Config.ServicesConfigSection"/>实例
        /// </summary>
        ServicesConfigSection Config { get; }
    }
}
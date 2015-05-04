using Nd.Framework.Configuration;
using System;

namespace Nd.Framework.Bus
{
    /// <summary>
    /// 消息总线工厂类
    /// </summary>
    public sealed class BusFactory
    {
        /// <summary>
        /// 创建消息总线
        /// </summary>
        /// <returns></returns>
        public static IBus CreateBus(IConfigSource configSource)
        {
            if (configSource == null)
                throw new ArgumentNullException("配置源不能为空");
            if (configSource.Config == null)
                throw new ConfigurationException("框架配置节未定义");
            if (configSource.Config.Bus == null)
                throw new ConfigurationException("框架配置节中未找到消息总线节");

            Type busType = Type.GetType(configSource.Config.Bus.Provider);
            return (IBus)Activator.CreateInstance(busType, configSource.Config.Bus.Path);
        }
    }
}
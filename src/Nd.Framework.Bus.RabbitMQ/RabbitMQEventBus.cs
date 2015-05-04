
namespace Nd.Framework.Bus.RabbitMQ
{
    public class RabbitMQEventBus : RabbitMQBus
    {
        #region 构造函数
        public RabbitMQEventBus(string hostName)
            : base(hostName)
        { }
        #endregion
    }
}
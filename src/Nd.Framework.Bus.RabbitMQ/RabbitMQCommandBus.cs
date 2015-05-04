
namespace Nd.Framework.Bus.RabbitMQ
{
    public class RabbitMQCommandBus : RabbitMQBus
    {
        #region 构造函数
        public RabbitMQCommandBus(string hostName)
            : base(hostName)
        { }
        #endregion
    }
}
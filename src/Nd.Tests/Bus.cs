using Nd.Framework.Bus;
using Nd.Framework.Bus.RabbitMQ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nd.Tests
{
    public class Bus
    {
        public static void Test()
        {
            IBus bus = new RabbitMQCommandBus("localhost");
            bus.Publish("ddd");
            bus.Commit();
        }
    }
}

namespace Nd.Framework.Services
{
    /// <summary>
    /// 表示该接口实现类为服务处理程序
    /// </summary>
    /// <typeparam name="TService">服务</typeparam>
    public interface IServiceHandler<TService> : IHandler<TService>
        where TService : class,IService
    {
    }
}
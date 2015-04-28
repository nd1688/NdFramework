
namespace Nd.Framework.WebAPI
{
    public interface IResponse
    {
    }

    public interface IResponse<TResponse>
        where TResponse : class,IResponse
    {
    }
}
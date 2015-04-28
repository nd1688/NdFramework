
namespace Nd.Framework.WebAPI
{
    /// <summary>
    /// WebAPI宿主上下文
    /// </summary>
    public static class HostContext
    {
        public static NdHost AppHost
        {
            get { return NdHost.Instance; }
        }
    }
}

namespace Nd.Framework.Core
{
    /// <summary>
    /// 生命周期枚举
    /// </summary>
    public enum NdLifeStyle
    {
        /// <summary>
        /// 单件
        /// </summary>
        Singleton,
        /// <summary>
        /// 线程内单件
        /// </summary>
        Thread,
        /// <summary>
        /// 瞬间
        /// </summary>
        Transient,
        /// <summary>
        /// 作用域
        /// </summary>
        Scoped,
        /// <summary>
        /// 对象池
        /// </summary>
        Pool,
        /// <summary>
        /// 请求
        /// </summary>
        Request
    }
}
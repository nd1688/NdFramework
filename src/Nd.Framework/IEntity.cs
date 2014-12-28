using System;

namespace Nd.Framework
{
    /// <summary>
    /// 表示该接口实现类为领域实体
    /// </summary>
    public interface IEntity
    {
        /// <summary>
        /// 获取或设置该实体唯一编号
        /// </summary>
        Guid Id { get; set; }
    }
}
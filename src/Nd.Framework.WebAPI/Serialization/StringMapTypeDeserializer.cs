using System;
using System.Collections.Generic;

namespace Nd.Framework.WebAPI.Serialization
{
    /// <summary>
    /// 字符串反序列化映射到类型
    /// </summary>
    public class StringMapTypeDeserializer
    {
        /// <summary>
        /// 属性序列化程序入口
        /// </summary>
        internal class PropertySerializerEntry
        {
            #region 公共字段
            public SetPropertyDelegate PropertySetFn;
            public ParseStringDelegate PropertyParseStringFn;
            public Type PropertyType;
            #endregion

            #region 构造函数
            public PropertySerializerEntry(SetPropertyDelegate propertySetFn, ParseStringDelegate propertyParseStringFn)
            {
                PropertySetFn = propertySetFn;
                PropertyParseStringFn = propertyParseStringFn;
            }
            #endregion
        }

        #region 公共委托
        /// <summary>
        /// 设置属性委托
        /// </summary>
        /// <param name="instance">类型实例</param>
        /// <param name="propertyValue">属性值</param>
        public delegate void SetPropertyDelegate(object instance, object propertyValue);
        /// <summary>
        /// 解析字符串委托
        /// </summary>
        /// <param name="stringValue">字符串值</param>
        /// <returns>特定类型值</returns>
        public delegate object ParseStringDelegate(string stringValue);
        #endregion

        #region 私有字段
        /// <summary>
        /// 属性设置程序字典
        /// </summary>
        private readonly Dictionary<string, PropertySerializerEntry> propertySetterMap = new Dictionary<string, PropertySerializerEntry>();
        #endregion
    }
}
using System;
using System.Text;

namespace Nd.Framework
{
    /// <summary>
    /// 工具类
    /// </summary>
    public sealed class Util
    {
        #region 转换类型方法
        public static byte[] ToBytes(object objValue)
        {
            if (objValue == null || objValue is DBNull)
            {
                return null;
            }
            return Encoding.UTF8.GetBytes(objValue.ToString().Trim());
        }
        public static string BytesToString(object objValue)
        {
            if (objValue == null || objValue is DBNull)
            {
                return null;
            }
            byte[] objBytes = (byte[])objValue;
            return Encoding.UTF8.GetString(objBytes);
        }
        public static string ToDateString(object objValue)
        {
            if (objValue == null || objValue is DBNull)
            {
                return null;
            }
            if (String.IsNullOrEmpty(objValue.ToString().Trim()))
            {
                return null;
            }
            return DateTime.Parse(objValue.ToString().Trim()).ToString("yyyy-MM-dd");
        }
        public static string ToDateString(DateTime? dtValue, string strFormat)
        {
            if (dtValue.HasValue)
            {
                return dtValue.Value.ToString(strFormat);
            }
            return String.Empty;
        }
        public static T ConvertTo<T>(object objValue, T objDefault)
        {
            if (objValue == null || objValue is DBNull)
            {
                return objDefault;
            }
            Type type = typeof(T);
            if (type.IsValueType && type.IsGenericType)
            {
                type = Nullable.GetUnderlyingType(type);
            }
            if (objValue is IConvertible)
            {
                return (T)(Convert.ChangeType(objValue, type));
            }
            return (T)objValue;
        }
        public static T ConvertTo<T>(object objValue)
        {
            return ConvertTo<T>(objValue, default(T));
        }
        public static T ConvertTo<T>(object objValue, T objValue1, T objDefault)
        {
            T objResult = ConvertTo<T>(objValue, objDefault);
            if (objResult.Equals(objValue1))
            {
                return objDefault;
            }
            return objResult;
        }
        public static Type GetType(object obj)
        {
            return obj.GetType();
        }
        /// <summary>
        /// 转换为double
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="doubVL"></param>
        /// <returns></returns>
        private static bool ToDouble(object obj, out double doubVL)
        {
            doubVL = 0;
            try
            {
                if (obj == null || string.IsNullOrEmpty(obj.ToString()) == true)
                {
                    return false;
                }
                else
                {
                    // string str = obj.ToString().Replace(",", "");
                    if (obj.ToString().Length > 3 && obj.ToString().Substring(obj.ToString().Length - 3, 1) == ".")
                    {
                        if (double.TryParse(obj.ToString(), out doubVL))
                        {
                            return true;
                        }
                    }
                    else
                    {
                        return false;
                    }


                }
            }
            catch
            {
                return false;
            }
            return false;
        }
        #endregion

        #region 枚举方法
        /// <summary>
        /// 根据枚举值或名字来获取对应的值
        /// </summary>
        /// <typeparam name="T">枚举类型</typeparam>
        /// <param name="strEnum">枚举名称或值</param>
        /// <param name="objDefault">默认值</param>
        /// <returns></returns>
        public static T GetEnumValue<T>(string strEnum, T objDefault) where T : struct
        {
            if (String.IsNullOrEmpty(strEnum))
            {
                return objDefault;
            }
            return Util.ConvertTo<T>(Enum.Parse(typeof(T), strEnum, true), objDefault);
        }
        /// <summary>
        /// 根据枚举值来获取对应的枚举名字
        /// </summary>
        /// <typeparam name="T">枚举类型</typeparam>
        /// <param name="objValue">枚举值</param>
        /// <returns></returns>
        public static string GetEnumName<T>(T objValue) where T : struct
        {
            return Enum.GetName(typeof(T), objValue);
        }
        #endregion
    }
}
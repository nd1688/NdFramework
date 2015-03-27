using System;
using System.Collections.Specialized;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Xml;

namespace Nd.Framework
{
    /// <summary>
    /// 工具类
    /// </summary>
    public sealed class Util
    {
        #region Config方法
        /// <summary>
        /// 获取config文件中ConnectionSettings中的数据。
        /// </summary>
        /// <param name="strConnKey">连接串Key值</param>
        /// <returns>返回Value值</returns>
        public static string GetConnString(string strConnKey)
        {
            #region GetConnString方法
            Util.ArgsNotNull(strConnKey, "strConnKey");
            ConnectionStringSettings connSetting = ConfigurationManager.ConnectionStrings[strConnKey];
            Util.Fail(connSetting == null || String.IsNullOrEmpty(connSetting.ConnectionString), "Config文件中,不存在{0}连接串Key！", strConnKey);
            return connSetting.ConnectionString;
            #endregion
        }
        /// <summary>
        /// 获取Web.config文件中appSettings中的数据。
        /// </summary>
        /// <param name="strKey">Key值</param>
        /// <returns>返回Value值</returns>
        public static string GetAppSettingValue(string strKey)
        {
            string strValue = ConfigurationManager.AppSettings[strKey] as string;
            if (String.IsNullOrEmpty(strValue))
            {
                return String.Empty;
            }
            return strValue;
        }
        public static string GetAppSettingValue(string strKey, string strDefault)
        {
            string strValue = ConfigurationManager.AppSettings[strKey] as string;
            if (String.IsNullOrEmpty(strValue))
            {
                return strDefault;
            }
            return strValue;
        }
        #endregion

        #region XmlNode方法
        /// <summary>
        /// 获取XML节点objNode的InnerText值,并转化为T类型
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="objNode"></param>
        /// <returns></returns>
        public static T GetNodeValue<T>(XmlNode objNode)
        {
            if (String.IsNullOrEmpty(objNode.InnerText))
            {
                return default(T);
            }
            return Util.ConvertTo<T>(objNode.InnerText);
        }
        /// <summary>
        /// 获取XML节点objNode的strAttrName属性Value值,并转化为T类型
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="objNode"></param>
        /// <param name="strAttrName"></param>
        /// <returns></returns>
        public static T GetNodeAttrValue<T>(XmlNode objNode, string strAttrName)
        {
            XmlAttribute attr = objNode.Attributes[strAttrName];
            if (attr == null)
            {
                return default(T);
            }
            string strValue = attr.Value;
            if (String.IsNullOrEmpty(strValue))
            {
                return default(T);
            }
            return Util.ConvertTo<T>(strValue);
        }
        #endregion

        #region web方法
        /// <summary>
        /// 获取HttpRequest的请求参数strParamName的值，并转为T类型,参数默认是加密的
        /// </summary>
        /// <typeparam name="T">返回的值类型</typeparam>
        /// <param name="strParamName">参数名</param>
        /// <param name="objDefault">默认值</param>
        /// <returns>返回参数值</returns>
        //public static T GetRequestParam<T>(string strParamName, T objDefault)
        //{
        //    return Util.GetRequestParam<T>(strParamName, objDefault, true);
        //}
        /// <summary>
        /// 获取HttpRequest的请求参数strParamName的值，并转为T类型,参数默认是加密的
        /// </summary>
        /// <typeparam name="T">返回的值类型</typeparam>
        /// <param name="strParamName">参数名</param>
        /// <returns>返回参数值</returns>
        //public static T GetRequestParam<T>(string strParamName)
        //{
        //    return Util.GetRequestParam<T>(strParamName, default(T));
        //}
        /// <summary>
        /// 获取HttpRequest的请求参数strParamName的值，并转为T类型
        /// </summary>
        /// <typeparam name="T">返回的值类型</typeparam>
        /// <param name="strParamName">参数名</param>
        /// <param name="bEncrypt">是否加密</param>
        /// <returns>返回参数值</returns>
        //public static T GetRequestParam<T>(string strParamName, bool bEncrypt)
        //{
        //    return Util.GetRequestParam<T>(strParamName, default(T), bEncrypt);
        //}
        //public static T GetRequestParam<T>(string strParamName, T objDefault, bool bEncrypt)
        //{
        //    string strValue = HttpContext.Current.Request.Params[strParamName];
        //    if (String.IsNullOrEmpty(strValue))
        //    {
        //        return objDefault;
        //    }
        //    if (bEncrypt)
        //    {
        //        strValue = Util.Decrypt(strValue);
        //    }
        //    return Util.ConvertTo<T>(strValue, objDefault);
        //}
        /// <summary>
        /// 获取HttpRequest的请求参数strParamName的值，参数默认是加密的
        /// </summary>
        /// <typeparam name="T">返回的值类型</typeparam>       
        /// <param name="strParamName">参数名</param>
        /// <param name="strDefault">默认值</param>
        /// <returns>返回参数值</returns>
        //public static string GetRequestParam(string strParamName, string strDefault)
        //{
        //    return Util.GetRequestParam(strParamName, strDefault, true);
        //}
        /// <summary>
        /// 获取HttpRequest的请求参数strParamName的值
        /// </summary>
        /// <typeparam name="T">返回的值类型</typeparam>       
        /// <param name="strParamName">参数名</param>
        /// <param name="bEncrypt">是否加密</param>
        /// <returns>返回参数值</returns>
        //public static string GetRequestParam(string strParamName, bool bEncrypt)
        //{
        //    return Util.GetRequestParam(strParamName, String.Empty, bEncrypt);
        //}
        /// <summary>
        /// 获取HttpRequest的请求参数strParamName的值
        /// </summary>
        /// <param name="strParamName">参数名</param>
        /// <param name="strDefault">默认值</param>
        /// <param name="bEncrypt">是否加密</param>
        /// <returns>返回参数值</returns>
        //public static string GetRequestParam(string strParamName, string strDefault, bool bEncrypt)
        //{
        //    string strValue = HttpContext.Current.Request.Params[strParamName];
        //    if (String.IsNullOrEmpty(strValue))
        //    {
        //        return strDefault;
        //    }
        //    if (bEncrypt)
        //    {
        //        strValue = Util.Decrypt(strValue);
        //    }
        //    return String.IsNullOrEmpty(strValue) ? strDefault : strValue;
        //}
        /// <summary>
        /// 获取HttpRequest的请求参数strParamName的值，参数默认是加密的
        /// </summary>
        /// <param name="strParamName">参数名</param>
        /// <returns>返回参数值</returns>
        //public static string GetRequestParam(string strParamName)
        //{
        //    return Util.GetRequestParam(strParamName, String.Empty, true);
        //}
        /// <summary>
        /// 返回要设置的HttpRequest请求参数strParamName的值，为空时将设置为objDefault
        /// </summary>
        /// <typeparam name="T">返回的值类型</typeparam>       
        /// <param name="strParamName">参数名</param>
        /// <param name="objValue">参数值</param>
        /// <param name="objDefault">默认值</param>
        /// <param name="bEncrypt">是否加密</param>
        /// <returns>返回参数值</returns>
        //public static string SetRequestParam<T>(string strParamName, T objValue, T objDefault, bool bEncrypt)
        //{
        //    string strValue = Util.IsNull(objValue) ? objDefault.ToString() : objValue.ToString();
        //    if (String.IsNullOrEmpty(strValue))
        //    {
        //        return String.Empty;
        //    }
        //    if (bEncrypt)
        //    {
        //        strValue = Util.Decrypt(strValue);
        //    }
        //    return strValue;
        //}
        //public static string SetRequestParam<T>(string strParamName, T objValue, T objDefault)
        //{
        //    return Util.SetRequestParam<T>(strParamName, objValue, objDefault, true);
        //}
        //public static string SetRequestParam<T>(string strParamName, T objValue)
        //{
        //    return Util.SetRequestParam<T>(strParamName, objValue, default(T), true);
        //}
        //public static string SetRequestParam<T>(string strParamName, T objValue, bool bEncrypt)
        //{
        //    return Util.SetRequestParam<T>(strParamName, objValue, default(T), bEncrypt);
        //}
        /// <summary>
        /// POST方式执行web请求
        /// </summary>
        /// <param name="strUrl"></param>
        /// <param name="objParameters"></param>
        /// <returns></returns>
        public static string WebRequestExecute(string strUrl, NameValueCollection objParameters)
        {
            return WebRequestExecute(strUrl, "POST", objParameters);
        }
        /// <summary>
        /// 执行web请求
        /// </summary>
        /// <param name="strUrl"></param>
        /// <param name="strMethod">方法POST或者GET</param>
        /// <param name="objParameters"></param>
        /// <returns></returns>
        public static string WebRequestExecute(string strUrl, string strMethod, NameValueCollection objParameters)
        {
            string strResponse = String.Empty;
            byte[] bPostData = null;
            try
            {

                if (objParameters != null && objParameters.Count > 0)
                {
                    StringBuilder strParameter = new StringBuilder();
                    foreach (string strKey in objParameters.Keys)
                    {
                        if (strParameter.Length > 0)
                        {
                            strParameter.AppendFormat("&");
                        }
                        strParameter.AppendFormat("{0}={1}", strKey, objParameters[strKey]);
                    }
                    bPostData = Encoding.UTF8.GetBytes(strParameter.ToString());
                }

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(strUrl);
                request.ContentType = "application/x-www-form-urlencoded";
                request.Method = strMethod;
                if (bPostData != null)
                {
                    request.ContentLength = bPostData.Length;
                    using (var requestStream = request.GetRequestStream())
                    {
                        requestStream.Write(bPostData, 0, bPostData.Length);
                    }
                }
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    StreamReader redader = new StreamReader(response.GetResponseStream());
                    strResponse = redader.ReadToEnd();
                    redader.Close();
                }
                response.Close();
                request.Abort();
            }
            catch (Exception ex)
            {
                AppRuntime.Current.Logger.ErrorFormat("Util.WebMethodExecute Execute Exception:{0}", ex);
            }
            return strResponse;
        }
        #endregion

        #region 加密与解密方法
        /// <summary>
        /// 根据strEncryptKey加密Key，对strContent进行加密处理，并返回加密后结果字符串。
        /// </summary>
        /// <param name="objContent">需要加密的内容</param>
        /// <returns>并返回加密后结果字符串</returns>
        //public static string Encrypt(object objContent)
        //{
        //    if (Util.GetAppSettingValue(Consts.EncryptEnabledKey, "N") == "Y")
        //    {
        //        if (String.IsNullOrEmpty(Util.GetAppSettingValue(Consts.EncryptKey)))
        //        {
        //            Util.Fail("未在Config文件找到EncryptKey的AppSetting配置项");
        //        }
        //    }
        //    return Util.Encrypt(Util.GetAppSettingValue(Consts.EncryptKey), objContent);
        //}
        /// <summary>
        /// 根据strEncryptKey加密Key，对strContent进行加密处理，并返回加密后结果字符串。
        /// </summary>
        /// <param name="strEncryptKey">加密Key</param>
        /// <param name="objContent">需要加密的内容</param>
        /// <returns>并返回加密后结果字符串</returns>
        public static string Encrypt(string strEncryptKey, object objContent)
        {
            if (objContent == null)
            {
                return String.Empty;
            }
            string strContent = objContent.ToString().Trim();
            if (string.IsNullOrEmpty(strContent))
            {
                return String.Empty;
            }
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            byte[] bValues = Encoding.Default.GetBytes(strContent);
            des.Key = Encoding.Default.GetBytes(strEncryptKey);
            des.IV = Encoding.Default.GetBytes(strEncryptKey);
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write);
            cs.Write(bValues, 0, bValues.Length);
            cs.FlushFinalBlock();
            StringBuilder objResult = new StringBuilder();
            foreach (byte bValue in ms.ToArray())
            {
                objResult.AppendFormat("{0:X2}", bValue);
            }
            return objResult.ToString();
        }
        /// <summary>
        /// 根据CookieEncryptKey加密Key，对objContent进行解密处理，并返回解密后结果字符串。
        /// </summary>
        /// <param name="objContent">需要解密的内容</param>
        /// <returns>并返回解密后结果字符串</returns>
        //public static string Decrypt(string objContent)
        //{
        //    if (Util.GetAppSettingValue(Consts.EncryptEnabledKey, "N") == "Y")
        //    {
        //        if (String.IsNullOrEmpty(Util.GetAppSettingValue(Consts.EncryptKey)))
        //        {
        //            Util.Fail("未在Config文件找到EncryptKey的AppSetting配置项");
        //        }
        //    }
        //    return Util.Decrypt(Util.GetAppSettingValue(Consts.EncryptKey), objContent);
        //}
        /// <summary>
        /// 根据strEncryptKey加密Key，对objContent进行解密处理，并返回解密后结果字符串。
        /// </summary>
        /// <param name="strEncryptKey">加密Key</param>
        /// <param name="objContent">需要解密的内容</param>
        /// <returns>并返回解密后结果字符串</returns>
        public static string Decrypt(string strEncryptKey, object objContent)
        {
            if (objContent == null)
            {
                return String.Empty;
            }
            string strContent = objContent.ToString();
            if (string.IsNullOrEmpty(strContent))
            {
                return String.Empty;
            }
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            byte[] bValues = new byte[strContent.Length / 2];
            for (int i = 0; i < strContent.Length / 2; i++)
            {
                byte bValue = Convert.ToByte(strContent.Substring(i * 2, 2), 16);
                bValues[i] = bValue;
            }
            des.Key = Encoding.Default.GetBytes(strEncryptKey);
            des.IV = Encoding.Default.GetBytes(strEncryptKey);
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write);
            cs.Write(bValues, 0, bValues.Length);
            cs.FlushFinalBlock();
            StringBuilder ret = new StringBuilder();
            return Encoding.Default.GetString(ms.ToArray());
        }
        #endregion

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
            if (objValue is string && type == typeof(Guid))
            {
                return (T)(Activator.CreateInstance(type, objValue));
            }
            if (objValue is string && type == typeof(TimeSpan))
            {
                object objResult = TimeSpan.Parse(objValue.ToString());
                return (T)(objResult);
            }
            if (typeof(IConvertible).IsAssignableFrom(type))
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
        private object ChangeType(object value, Type type)
        {
            if (value == null)
            {
                return null;
            }
            if (value != null && type.IsGenericType)
            {
                return Activator.CreateInstance(type);
            }
            if (type == value.GetType())
            {
                return value;
            }
            if (type.IsEnum)
            {
                if (value is string)
                {
                    return Enum.Parse(type, value as string);
                }
                else
                {
                    return Enum.ToObject(type, value);
                }
            }
            if (!type.IsInterface && type.IsGenericType)
            {
                Type innerType = type.GetGenericArguments()[0];
                object innerValue = ChangeType(value, innerType);
                return Activator.CreateInstance(type, new object[] { innerValue });
            }
            if (value is string && type == typeof(Guid))
            {
                return new Guid(value as string);
            }
            if (value is string && type == typeof(Version))
            {
                return new Version(value as string);
            }
            return value;
        }
        public static PropertyInfo[] GetProperties(object obj)
        {
            Type type = GetType(obj);
            return type.GetProperties();
        }

        public static object GetValue(PropertyInfo p, object entity)
        {
            return p.GetValue(entity, null);
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

        #region 验证类型方法
        public static bool IsNull(object obj)
        {
            return (obj == null);
        }
        /// <summary>
        /// 是否是bool型
        /// </summary>
        /// <param name="strValue"></param>
        /// <returns></returns>
        public static bool IsBoolean(string strValue)
        {
            return (!String.IsNullOrEmpty(strValue)) && (strValue.ToLower() == "true" || strValue.ToLower() == "false");
        }
        /// <summary>
        /// 是否是数字
        /// </summary>
        /// <param name="strValue"></param>
        /// <returns></returns>
        public static bool IsNumber(string strValue)
        {
            Regex reg = new Regex("^(-)?[0-9]+$");
            return reg.Match(strValue.Trim()).Success;
        }
        /// <summary>
        /// 是否是浮点数
        /// </summary>
        /// <param name="strValue"></param>
        /// <returns></returns>
        public static bool IsDecimal(string strValue)
        {
            Regex reg = new Regex("^[-]?(0|[1-9][0-9]{0,2}(\\,?[0-9]{3})*)(\\.[0-9]{2,6})?$");
            return reg.Match(strValue.Trim()).Success;
        }
        /// <summary>
        /// 验证日期
        /// </summary>
        /// <param name="strValue"></param>
        /// <returns></returns>
        public static bool IsDateTime(string strValue)
        {
            Regex reg = new Regex(@"^((((19|20)\d{2})[-./](0?(1|[3-9])|1[012])[-./](0?[1-9]|[12]\d|30))|(((19|20)\d{2})[-./](0?[13578]|1[02])[-./]31)|(((19|20)\d{2})[-./]0?2[-./](0?[1-9]|1\d|2[0-8]))|((((19|20)([13579][26]|[2468][048]|0[48]))|(2000))[-./]0?2[-./]29))(\s((0?[0-9])|(1[0-9])|(2[0-3])):(0?|[1-5])[0-9]:(0?|[1-5])[0-9])?$");
            return reg.Match(strValue.Trim()).Success;
        }
        #endregion

        #region Guard方法
        /// <summary>
        /// 参数不允许为空，空则报ArgumentNullException异常。
        /// </summary>
        /// <param name="objArgsValue"></param>
        /// <param name="objArgsName"></param>
        [DebuggerStepThrough]
        public static void ArgsNotNull(object objArgsValue, string objArgsName)
        {
            if (objArgsValue == null)
            {
                throw new ArgumentNullException(objArgsName);
            }
            if (objArgsValue is string)
            {
                string strArgs = objArgsValue as string;
                if (String.IsNullOrEmpty(strArgs))
                {
                    throw new ArgumentNullException(objArgsName);
                }
            }
        }
        /// <summary>
        /// 抛自定义异常，格式为strFormat，参数为objArgs
        /// </summary>
        /// <param name="strFormat"></param>
        /// <param name="objArgs"></param>
        [DebuggerStepThrough]
        public static void Fail(string strFormat, params object[] objArgs)
        {
            throw new Exception(String.Format(strFormat, objArgs));
        }
        /// <summary>
        /// 当条件bCondition成立时，抛自定义异常，格式为strFormat，参数为objArgs
        /// </summary>
        /// <param name="bCondition">bool表达式</param>
        /// <param name="strFormat"></param>
        /// <param name="objArgs"></param>
        [DebuggerStepThrough]
        public static void Fail(bool bCondition, string strFormat, params object[] objArgs)
        {
            if (bCondition)
            {
                throw new Exception(String.Format(strFormat, objArgs));
            }
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

        #region Web控件方法
        /// <summary>
        /// 设置列表控件选择项
        /// </summary>
        /// <param name="objCtrl">列表控件</param>
        /// <param name="objValue">设置的值</param>
        public static void SelectItem(ListControl objCtrl, object objValue)
        {
            objCtrl.SelectedIndex = -1;
            if (Util.IsNull(objValue))
            {
                return;
            }
            ListItem objItem = objCtrl.Items.FindByValue(objValue.ToString());
            if (objItem != null)
            {
                objItem.Selected = true;
            }
        }
        /// <summary>
        /// 设置列表控件选择项
        /// </summary>
        /// <param name="objCtrl">列表控件</param>
        /// <param name="objValue">设置的值</param>
        /// <param name="iDefaultIndex">默认设置的索引值，如果未找到设置的值，将会选择此索引对应的项</param>
        public static void SelectItem(ListControl objCtrl, object objValue, int iDefaultIndex)
        {
            objCtrl.SelectedIndex = iDefaultIndex;
            if (Util.IsNull(objValue))
            {
                return;
            }
            ListItem objItem = objCtrl.Items.FindByValue(objValue.ToString());
            if (objItem != null)
            {
                objItem.Selected = true;
            }
        }
        /// <summary>
        /// 设置列表控件选择项
        /// </summary>
        /// <param name="objCtrl">列表控件</param>
        /// <param name="objValue">设置的值</param>
        public static void SelectItem(HtmlSelect objCtrl, object objValue)
        {
            objCtrl.SelectedIndex = -1;
            if (Util.IsNull(objValue))
            {
                return;
            }
            ListItem objItem = objCtrl.Items.FindByValue(objValue.ToString());
            if (objItem != null)
            {
                objItem.Selected = true;
            }
        }
        /// <summary>
        /// 设置列表控件选择项
        /// </summary>
        /// <param name="objCtrl">列表控件</param>
        /// <param name="objValue">设置的值</param>
        /// <param name="iDefaultIndex">默认设置的索引值，如果未找到设置的值，将会选择此索引对应的项</param>
        public static void SelectItem(HtmlSelect objCtrl, object objValue, int iDefaultIndex)
        {
            objCtrl.SelectedIndex = iDefaultIndex;
            if (Util.IsNull(objValue))
            {
                return;
            }
            ListItem objItem = objCtrl.Items.FindByValue(objValue.ToString());
            if (objItem != null)
            {
                objItem.Selected = true;
            }
        }
        #endregion

        #region Cookie方法
        public static void AddCookie(string strCookieKey, string strValue)
        {
            HttpContext.Current.Response.Cookies.Add(new HttpCookie(strCookieKey, strValue));
        }
        public static void RemoveCookie(string strCookieKey, string strValue)
        {
            HttpContext.Current.Response.Cookies.Remove(strCookieKey);
        }
        #endregion
    }
}
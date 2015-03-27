using Nd.Framework.Logging;
using ServiceStack.Redis;
using System;
using System.Collections.Generic;

namespace Nd.Framework.Caching.Redis
{
    public class CacheManager : ICache
    {
        private ILogger objLogger = AppRuntime.Current.Logger;
        private RedisClient objRedisClient = null;
        public CacheManager()
        {
            string strUri = Util.GetAppSettingValue("Consts.RedisUriKey");
            Util.Fail(String.IsNullOrEmpty(strUri), "配置文件(App.config或Web.confg)中不包含{0}的配置AppSetting配置项", "Consts.RedisUriKey");
            string[] arr = strUri.Split(new char[] { ':' });
            this.objRedisClient = new RedisClient(arr[0], Util.ConvertTo<int>(arr[1]));
        }

        public void SetConfig(string strConfigItem, string strValue)
        {
            try
            {
                this.objRedisClient.SetConfig(strConfigItem, strValue);
            }
            catch (Exception e)
            {
                this.objLogger.ErrorFormat("Source:Basf.CacheHelper.SetConfig(strConfigItem={0}, strValue={1}),Exception:{2}", strConfigItem, strValue, e.Message);
            }
        }

        public string GetConfig(string strConfigItem)
        {
            try
            {
                return this.objRedisClient.GetConfig(strConfigItem);
            }
            catch (Exception e)
            {
                this.objLogger.ErrorFormat("Source:Basf.CacheHelper.GetConfig(strConfigItem={0}),Exception:{1}", strConfigItem, e.Message);
            }
            return String.Empty;
        }
        /// <summary>
        /// 添加执行类型的数据到缓存中
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="strKey"></param>
        /// <param name="objValue"></param>
        /// <param name="expire"></param>
        public void Add<T>(string strKey, T objValue, TimeSpan expire)
        {
            try
            {
                this.objRedisClient.Add<T>(strKey, objValue, expire);
            }
            catch (Exception e)
            {
                this.objLogger.ErrorFormat("Source:Basf.CacheHelper.Add<{0}>(strKey={1}, objValue={2}, expire={3}),Exception:{4}",
                   typeof(T).FullName, strKey, objValue, expire, e.Message);
            }
        }
        public void Add<T>(string strKey, T objValue)
        {
            try
            {
                this.objRedisClient.Add<T>(strKey, objValue);
            }
            catch (Exception e)
            {
                this.objLogger.ErrorFormat("Source:Basf.CacheHelper.Add<{0}>(strKey={1}, objValue={2}),Exception:{3}",
                   typeof(T).FullName, strKey, objValue, e.Message);
            }
        }
        public void Set<T>(string strKey, T objValue, TimeSpan expire)
        {
            try
            {
                this.objRedisClient.Set<T>(strKey, objValue, expire);
            }
            catch (Exception e)
            {
                this.objLogger.ErrorFormat("Source:Basf.CacheHelper.Set<{0}>(strKey={1}, objValue={2}, expire={3}),Exception:{4}",
                   typeof(T).FullName, strKey, objValue, expire, e.Message);
            }
        }
        public void Set<T>(string strKey, T objValue)
        {
            try
            {
                this.objRedisClient.Set<T>(strKey, objValue);
            }
            catch (Exception e)
            {
                this.objLogger.ErrorFormat("Source:Basf.CacheHelper.Set<{0}>(strKey={1}, objValue={2}),Exception:{3}",
                   typeof(T).FullName, strKey, objValue, e.Message);
            }
        }
        public bool ContainsKey(string strKey)
        {
            try
            {
                return this.objRedisClient.ContainsKey(strKey);
            }
            catch (Exception e)
            {
                this.objLogger.ErrorFormat("Source:Basf.CacheHelper.ContainsKey(strKey={0}),Exception:{1}", strKey, e.Message);
            }
            return false;
        }

        public bool Remove(string strKey)
        {
            try
            {
                return this.objRedisClient.Remove(strKey);
            }
            catch (Exception e)
            {
                this.objLogger.ErrorFormat("Source:Basf.CacheHelper.Remove(strKey={0}),Exception:{1}", strKey, e.Message);
            }
            return false;
        }
        public T Get<T>(string strKey)
        {
            try
            {
                return this.objRedisClient.Get<T>(strKey);
            }
            catch (Exception e)
            {
                this.objLogger.ErrorFormat("Source:Basf.CacheHelper.Get<{0}>(strKey={1}),Exception:{2}",
                   typeof(T).FullName, strKey, e.Message);
            }
            return default(T);
        }
        public void Replace<T>(string strKey, T objValue)
        {
            try
            {
                this.objRedisClient.Replace<T>(strKey, objValue);
            }
            catch (Exception e)
            {
                this.objLogger.ErrorFormat("Source:Basf.CacheHelper.Replace<{0}>(strKey={1}, objValue={2}),Exception:{3}",
                   typeof(T).FullName, strKey, objValue, e.Message);
            }
        }
        public void Replace<T>(string strKey, T objValue, TimeSpan expire)
        {
            try
            {
                this.objRedisClient.Replace<T>(strKey, objValue, expire);
            }
            catch (Exception e)
            {
                this.objLogger.ErrorFormat("Source:Basf.CacheHelper.Replace<{0}>(strKey={1}, objValue={2}, expire={3}),Exception:{4}",
                   typeof(T).FullName, strKey, objValue, expire, e.Message);
            }
        }
        /// <summary>
        /// 设置T类型数据，通常是集合类的数据，例如：从数据库取出来的数据
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="objEntityList">具体数据集合</param>
        public void StoreAll<T>(IEnumerable<T> objEntityList)
        {
            try
            {
                this.objRedisClient.StoreAll<T>(objEntityList);
            }
            catch (Exception e)
            {
                this.objLogger.ErrorFormat("Source:Basf.CacheHelper.StoreAll<{0}>(objEntityList=IEnumerable),Exception:{1}", typeof(T).FullName, e.Message);
            }
        }
        /// <summary>
        /// 获取由StoreAll<T>方法设置的类型数据，通常是集合类的数据，例如：从数据库取出来的数据
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <returns></returns>
        public IList<T> GetAll<T>()
        {
            try
            {
                return this.objRedisClient.GetAll<T>();
            }
            catch (Exception e)
            {
                this.objLogger.ErrorFormat("Source:Basf.CacheHelper.GetAll<{0}>(),Exception:{1}", typeof(T).FullName, e.Message);
            }
            return null;
        }
        public void AddToList(string strListKey, string strValue)
        {
            try
            {
                this.objRedisClient.AddItemToList(strListKey, strValue);
            }
            catch (Exception e)
            {
                this.objLogger.ErrorFormat("Source:Basf.CacheHelper.AddItemToList(strListKey={0},strValue={1}),Exception:{2}", strListKey, strValue, e.Message);
            }
        }
        public void RemoveFromList(string strListKey, string strValue)
        {
            try
            {
                this.objRedisClient.RemoveItemFromList(strListKey, strValue);
            }
            catch (Exception e)
            {
                this.objLogger.ErrorFormat("Source:Basf.CacheHelper.RemoveFromList(strListKey={0},strValue={1}),Exception:{2}", strListKey, strValue, e.Message);
            }
        }
        public void AddRangeToList(string strListKey, List<string> strValues)
        {
            try
            {
                this.objRedisClient.AddRangeToList(strListKey, strValues);
            }
            catch (Exception e)
            {
                this.objLogger.ErrorFormat("Source:Basf.CacheHelper.AddRangeToList(strSetKey={0}, strValues=List[Count={1}]),Exception:{2}", strListKey, strValues.Count, e.Message);
            }
        }
        public List<string> GetAllFromList(string strListKey)
        {
            try
            {
                return this.objRedisClient.GetAllItemsFromList(strListKey);
            }
            catch (Exception e)
            {
                this.objLogger.ErrorFormat("Source:Basf.CacheHelper.GetAllFromList(strListKey={0}),Exception:{1}", strListKey, e.Message);
            }
            return null;
        }
        public void RemoveAllFromList(string strListKey)
        {
            try
            {
                this.objRedisClient.RemoveAllFromList(strListKey);
            }
            catch (Exception e)
            {
                this.objLogger.ErrorFormat("Source:Basf.CacheHelper.RemoveAllFromList(strListKey={0}),Exception:{1}", strListKey, e.Message);
            }
        }
        public void AddToSet(string strSetKey, string strValue)
        {
            try
            {
                this.objRedisClient.AddItemToSet(strSetKey, strValue);
            }
            catch (Exception e)
            {
                this.objLogger.ErrorFormat("Source:Basf.CacheHelper.AddToSet(strSetKey={0},strValue={1}),Exception:{2}", strSetKey, strValue, e.Message);
            }
        }
        public void RemoveFromSet(string strSetKey, string strValue)
        {
            try
            {
                this.objRedisClient.RemoveItemFromSet(strSetKey, strValue);
            }
            catch (Exception e)
            {
                this.objLogger.ErrorFormat("Source:Basf.CacheHelper.RemoveFromSet(strSetKey={0},strValue={1}),Exception:{2}", strSetKey, strValue, e.Message);
            }
        }
        public void AddRangeToSet(string strSetKey, List<string> strValues)
        {
            try
            {
                this.objRedisClient.AddRangeToSet(strSetKey, strValues);
            }
            catch (Exception e)
            {
                this.objLogger.ErrorFormat("Source:Basf.CacheHelper.AddRangeToSet(strSetKey={0}, strValues=List[Count={1}]),Exception:{2}", strSetKey, strValues.Count, e.Message);
            }
        }
        public HashSet<string> GetAllFromSet(string strSetKey)
        {
            try
            {
                this.objRedisClient.GetAllItemsFromSet(strSetKey);
            }
            catch (Exception e)
            {
                this.objLogger.ErrorFormat("Source:Basf.CacheHelper.GetAllFromSet(strSetKey={0}),Exception:{2}", strSetKey, e.Message);
            }
            return null;
        }
        public List<T> GetValues<T>(List<string> objKeys)
        {
            try
            {
                return this.objRedisClient.GetValues<T>(objKeys);
            }
            catch (Exception e)
            {
                this.objLogger.ErrorFormat("Source:Basf.CacheHelper.GetValues<{0}>(objKeys=List[Count={1}]),Exception:{2}",
                    typeof(T).FullName, objKeys.Count, e.Message);
            }
            return null;
        }
        public Dictionary<string, string> GetValuesMap(List<string> objKeys)
        {
            try
            {
                return this.objRedisClient.GetValuesMap(objKeys);
            }
            catch (Exception e)
            {
                this.objLogger.ErrorFormat("Source:Basf.CacheHelper.GetValuesMap(objKeys=List[Count={0}]),Exception:{1}", objKeys.Count, e.Message);
            }
            return null;
        }
        public Dictionary<string, T> GetValuesMap<T>(List<string> objKeys)
        {
            try
            {
                return this.objRedisClient.GetValuesMap<T>(objKeys);
            }
            catch (Exception e)
            {
                this.objLogger.ErrorFormat("Source:Basf.CacheHelper.GetValuesMap<{0}>(objKeys=List[Count={1}]),Exception:{2}",
                    typeof(T).FullName, objKeys.Count, e.Message);
            }
            return null;
        }
        public IEnumerable<string> ScanAllKeys(string strPattern = null, int iPageSize = 1000)
        {
            try
            {
                return this.objRedisClient.ScanAllKeys(strPattern, iPageSize);
            }
            catch (Exception e)
            {
                this.objLogger.ErrorFormat("Source:Basf.CacheHelper.ScanAllKeys(strPattern={0}, iPageSize={1}),Exception:{2}", strPattern, iPageSize, e.Message);
            }
            return null;
        }
        public void RemoveByPattern(string strPattern)
        {
            try
            {
                this.objRedisClient.RemoveByPattern(strPattern);
            }
            catch (Exception e)
            {
                this.objLogger.ErrorFormat("Source:Basf.CacheHelper.RemoveByPattern(strPattern={0}),Exception:{1}", strPattern, e.Message);
            }
        }


        public List<string> SearchKeys(string strPattern)
        {
            try
            {
                return this.objRedisClient.SearchKeys(strPattern);
            }
            catch (Exception e)
            {
                this.objLogger.ErrorFormat("Source:Basf.CacheHelper.SearchKeys(strPattern={0}),Exception:{1}", strPattern, e.Message);
            }
            return null;
        }
    }
}

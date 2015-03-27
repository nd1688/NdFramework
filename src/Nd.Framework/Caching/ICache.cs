using System;
using System.Collections.Generic;

namespace Nd.Framework.Caching
{
    public interface ICache
    {
        /// <summary>
        /// 缓存一个配置项
        /// </summary>
        /// <param name="strConfigItem"></param>
        /// <param name="strValue"></param>
        void SetConfig(string strConfigItem, string strValue);
        string GetConfig(string strConfigItem);
        void Add<T>(string strKey, T objValue, TimeSpan expire);
        void Add<T>(string strKey, T objValue);
        void Set<T>(string strKey, T objValue, TimeSpan expire);
        void Set<T>(string strKey, T objValue);
        bool ContainsKey(string strKey);
        bool Remove(string strKey);
        T Get<T>(string strKey);
        void Replace<T>(string strKey, T objValue);
        void Replace<T>(string strKey, T objValue, TimeSpan expire);
        void StoreAll<T>(IEnumerable<T> objEntityList);
        IList<T> GetAll<T>();
        void AddToList(string strListKey, string strValue);
        void RemoveFromList(string strListKey, string strValue);
        void AddRangeToList(string strListKey, List<string> strValues);
        List<string> GetAllFromList(string strListKey);
        void RemoveAllFromList(string strListKey);
        void AddToSet(string strSetKey, string strValue);
        void RemoveFromSet(string strSetKey, string strValue);
        void AddRangeToSet(string strSetKey, List<string> strValues);
        HashSet<string> GetAllFromSet(string strSetKey);
        List<T> GetValues<T>(List<string> objKeys);
        Dictionary<string, string> GetValuesMap(List<string> objKeys);
        Dictionary<string, T> GetValuesMap<T>(List<string> objKeys);
        IEnumerable<string> ScanAllKeys(string strPattern = null, int iPageSize = 1000);
        void RemoveByPattern(string strPattern);
        List<string> SearchKeys(string strPattern);
    }
}
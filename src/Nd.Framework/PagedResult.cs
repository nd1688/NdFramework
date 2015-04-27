using System.Collections;
using System.Collections.Generic;

namespace Nd.Framework
{
    /// <summary>
    /// 分页数据对象
    /// </summary>
    /// <typeparam name="T">数据对象</typeparam>
    public class PagedResult<T> : ICollection<T>
    {
        #region 构造函数
        /// <summary>
        /// 初始化一个新的<c>PagedResult</c>实例
        /// </summary>
        public PagedResult()
        {
            this.data = new List<T>();
        }
        /// <summary>
        /// 初始化一个新的<c>PagedResult</c>实例
        /// </summary>
        /// <param name="totalRecords">总记录数</param>
        /// <param name="totalPages">总页数</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="pageIndex">当前页码</param>
        /// <param name="data">当前页数据</param>
        public PagedResult(int? totalRecords, int? totalPages, int? pageSize, int? pageIndex, IList<T> data)
        {
            this.totalRecords = totalRecords;
            this.totalPages = totalPages;
            this.pageSize = pageSize;
            this.pageIndex = pageIndex;
            this.data = data;
        }
        #endregion

        #region 私有字段
        private int? totalRecords;
        private int? totalPages;
        private int? pageSize;
        private int? pageIndex;
        private IList<T> data;
        #endregion
        
        #region 公共属性
        
        /// <summary>
        /// 总记录数
        /// </summary>
        public int? TotalRecords
        {
            get { return totalRecords; }
            set { totalRecords = value; }
        }

        /// <summary>
        /// 总页数
        /// </summary>
        public int? TotalPages
        {
            get { return totalPages; }
            set { totalPages = value; }
        }

        /// <summary>
        /// 每页记录数
        /// </summary>
        public int? PageSize
        {
            get { return pageSize; }
            set { pageSize = value; }
        }
        
        /// <summary>
        /// 当前页码
        /// </summary>
        public int? PageIndex
        {
            get { return pageIndex; }
            set { pageIndex = value; }
        }
        
        /// <summary>
        /// 当前页数据
        /// </summary>
        public IEnumerable<T> Data
        {
            get { return data; }
        }
        #endregion

        #region ICollection<T> 成员
        /// <summary>
        /// Adds an item to the System.Collections.Generic.ICollection{T}.
        /// </summary>
        /// <param name="item">The object to add to the System.Collections.Generic.ICollection{T}.</param>
        public void Add(T item)
        {
            data.Add(item);
        }
        /// <summary>
        /// Removes all items from the System.Collections.Generic.ICollection{T}.
        /// </summary>
        public void Clear()
        {
            data.Clear();
        }
        /// <summary>
        /// Determines whether the System.Collections.Generic.ICollection{T} contains
        /// a specific value.
        /// </summary>
        /// <param name="item">The object to locate in the System.Collections.Generic.ICollection{T}.</param>
        /// <returns>true if item is found in the System.Collections.Generic.ICollection{T}; otherwise,
        /// false.</returns>
        public bool Contains(T item)
        {
            return data.Contains(item);
        }
        /// <summary>
        /// Copies the elements of the System.Collections.Generic.ICollection{T} to an
        /// System.Array, starting at a particular System.Array index.
        /// </summary>
        /// <param name="array">The one-dimensional System.Array that is the destination of the elements
        /// copied from System.Collections.Generic.ICollection{T}. The System.Array must
        /// have zero-based indexing.</param>
        /// <param name="arrayIndex">The zero-based index in array at which copying begins.</param>
        public void CopyTo(T[] array, int arrayIndex)
        {
            data.CopyTo(array, arrayIndex);
        }
        /// <summary>
        /// Gets the number of elements contained in the System.Collections.Generic.ICollection{T}.
        /// </summary>
        public int Count
        {
            get { return data.Count; }
        }
        /// <summary>
        /// Gets a value indicating whether the System.Collections.Generic.ICollection{T}
        /// is read-only.
        /// </summary>
        public bool IsReadOnly
        {
            get { return false; }
        }
        /// <summary>
        /// Removes the first occurrence of a specific object from the System.Collections.Generic.ICollection{T}.
        /// </summary>
        /// <param name="item">The object to remove from the System.Collections.Generic.ICollection{T}.</param>
        /// <returns></returns>
        public bool Remove(T item)
        {
            return data.Remove(item);
        }

        #endregion

        #region IEnumerable<T> 成员
        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>A System.Collections.Generic.IEnumerator{T} that can be used to iterate through
        /// the collection.</returns>
        public IEnumerator<T> GetEnumerator()
        {
            return data.GetEnumerator();
        }

        #endregion

        #region IEnumerable 成员
        /// <summary>
        /// Returns an enumerator that iterates through a collection.
        /// </summary>
        /// <returns>An System.Collections.IEnumerator object that can be used to iterate through
        /// the collection.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return data.GetEnumerator();
        }

        #endregion
    }
}
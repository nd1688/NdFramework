using System;
using System.ComponentModel;
using System.Runtime.ConstrainedExecution;
using System.Threading;

namespace Nd.Framework.Core
{
    [Serializable]
    public class DisposableObject : CriticalFinalizerObject, IDisposableObject
    {
        #region 私有字段
        [NonSerialized]
        private int currentDisposedFlag;
        private const int DISPOSED_FLAG = 1;
        #endregion

        #region 析构
        ~DisposableObject()
        {
            this.Dispose(false);
        }
        #endregion

        #region IDisposable 成员
        public void Dispose()
        {
            var disposed = currentDisposedFlag;
            Interlocked.CompareExchange(ref this.currentDisposedFlag, DISPOSED_FLAG, disposed);
            if (disposed == 0)
            {
                this.Dispose(true);
                GC.SuppressFinalize(this);
            }
        }
        #endregion

        #region IDisposableObject 成员
        /// <summary>
        /// 判断当前对象是否释放
        /// </summary>
        [Browsable(false)]
        public bool IsDisposed
        {
            get
            {
                Thread.MemoryBarrier();
                return currentDisposedFlag == DISPOSED_FLAG;
            }
        }
        #endregion

        #region 受保护的方法
        protected virtual void Dispose(bool disposing) { }

        /// <summary>
        /// 检查对象是否还没有被释放
        /// </summary>
        /// <exception cref="ObjectDisposedException">如果对象已经释放则触发该异常</exception>
        protected virtual void CheckNotDisposed()
        {
            if (this.IsDisposed)
            {
                throw new ObjectDisposedException(this.GetType().Name);
            }
        }
        #endregion
    }
}
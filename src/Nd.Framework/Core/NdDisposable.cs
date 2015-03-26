using System;
using System.ComponentModel;
using System.Runtime.ConstrainedExecution;
using System.Threading;

namespace Nd.Framework.Core
{
    [Serializable]
    public class NdDisposable : CriticalFinalizerObject, INdDisposable
    {
        [NonSerialized]
        private int currentDisposedFlag;
        private const int DISPOSED_FLAG = 1;

        ~NdDisposable()
        {
            this.Dispose(false);
        }

        #region IDisposable Members
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
        }

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
    }
}
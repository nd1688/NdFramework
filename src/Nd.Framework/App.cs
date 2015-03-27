﻿using Nd.Framework.Core;
using Nd.Framework.Core.Castle;

namespace Nd.Framework
{
    public class App : BooleanDisposable
    {
        #region Private Field
        private INdContainer container = new CastleContainer();
        #endregion

        #region Public Property
        public INdContainer Container
        {
            get
            {
                return this.container;
            }
        }
        #endregion

        #region Ctor
        public App() { }
        #endregion

        #region Public Method
        public virtual void Init()
        {
        }
        #endregion

        #region Protected Method
        protected override void Dispose(bool disposing)
        {
            if (!disposing) return;
            if (this.Container != null)
            {
                this.Container.Dispose();
            }
        }
        #endregion
    }
}
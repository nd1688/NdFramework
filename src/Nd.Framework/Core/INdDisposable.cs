using System;

namespace Nd.Framework.Core
{
    public interface INdDisposable : IDisposable
    {
        bool IsDisposed { get; }
    }
}
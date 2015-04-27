using System;

namespace Nd.Framework.Core
{
    public interface IDisposableObject : IDisposable
    {
        bool IsDisposed { get; }
    }
}
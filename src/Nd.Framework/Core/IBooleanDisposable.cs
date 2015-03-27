using System;

namespace Nd.Framework.Core
{
    public interface IBooleanDisposable : IDisposable
    {
        bool IsDisposed { get; }
    }
}
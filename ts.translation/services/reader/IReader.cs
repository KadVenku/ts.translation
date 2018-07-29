using System;

namespace ts.translation.services.reader
{
    internal interface IReader<T> : IDisposable
    {
        T Read (string path);
    }
}

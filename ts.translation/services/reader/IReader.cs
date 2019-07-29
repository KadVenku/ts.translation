using System;

namespace ts.translation.services.reader
{
    internal interface IReader<out T> : IDisposable
    {
        T Read(string path);
    }
}
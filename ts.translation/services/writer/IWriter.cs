using System;

namespace ts.translation.services.writer
{
    public interface IWriter<in T> : IDisposable
    {
        void Write(string path, T writable);
    }
}
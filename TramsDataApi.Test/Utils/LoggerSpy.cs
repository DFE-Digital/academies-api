using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace TramsDataApi.Test.Utils
{
    public class LoggerSpy<T> : ILogger<T>, IDisposable
    {
        public List<string> MessageSink = new List<string>();

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            MessageSink.Add(formatter(state, exception));
        }

        public bool IsEnabled(LogLevel logLevel) => true;

        public IDisposable BeginScope<TState>(TState state) => this;

        public void Dispose() { }
    }
}

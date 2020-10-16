using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DotNetCore.CAP;

namespace TT.SoMall
{
    public class MyCapService : ICapPublisher
    {
        public IServiceProvider ServiceProvider { get; }

        public AsyncLocal<ICapTransaction> Transaction { get; }

        public async Task PublishAsync<T>(string name, T contentObj, string callbackName = null,
            CancellationToken cancellationToken = default)
        {
//            throw new NotImplementedException();
            await Task.CompletedTask;
        }

        public Task PublishAsync<T>(string name, T contentObj, IDictionary<string, string> optionHeaders = null,
            CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public void Publish<T>(string name, T contentObj, string callbackName = null)
        {
            throw new NotImplementedException();
        }

        public void Publish<T>(string name, T contentObj, IDictionary<string, string> headers)
        {
            throw new NotImplementedException();
        }
    }
}
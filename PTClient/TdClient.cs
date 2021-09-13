using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Td;
using Telegram.Td.Api;

namespace PTClient
{
    public class TdClient
    {
        private Client client;
        public TdClient(List<IFilter> filters)
        {
            Filtering.Filters = filters ?? throw new Exception("Filters cannot be empty");
        }
        private void RunThread(Client tdClient)
        {
            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;
                tdClient.Run();
            }).Start();
        }
        private Client Create()
        {
            Client.Execute(new SetLogVerbosityLevel(0));
            return Client.Create(new UpdateHandler());
        }
        public void Run()
        {
            client = Create();
            RunThread(client);
        }
        public async Task<BaseObject> ExecuteAsync(Function function)
        {
            TdClientResponse response = new();
            client.Send(function, response);
            return await response.WaitForResponseAsync();
        }
        public void Send(Function function)
        {
            client.Send(function, new UpdateHandler());
        }
        public void AddDisposableFilter(IFilter filter)
        {
            filter.Disposable = true;
            Filtering.Filters.Add(filter);
        }
    }
}

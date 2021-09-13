using System.Threading.Tasks;
using Telegram.Td;
using Telegram.Td.Api;

namespace PTClient
{
    internal class TdClientResponse : ClientResultHandler
    {
        BaseObject baseObject = null;
        void ClientResultHandler.OnResult(BaseObject response)
        {
            baseObject = response;
        }
        internal async Task<BaseObject> WaitForResponseAsync()
        {
            int delay = 100;
            int maxTry = 100;
            int tries = 0;
            while (true)
            {
                if (baseObject != null) return baseObject;
                tries++;
                if (tries >= maxTry) return null;
                await Task.Delay(delay);
            }
        }
    }
}

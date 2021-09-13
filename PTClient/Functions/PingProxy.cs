using System.Threading.Tasks;
using TdApi = Telegram.Td.Api;

namespace PTClient
{
    public static partial class Functions
    {
        public static async Task<TdResult<TdApi.Seconds>> PingProxyAsync(this TdClient tdClient, TdApi.PingProxy pingProxy)
        {
            TdResult<TdApi.Seconds> tdResult = new TdResult<TdApi.Seconds>();
            TdApi.BaseObject baseObject = await tdClient.ExecuteAsync(pingProxy);
            if (baseObject is TdApi.Error)
            {
                tdResult.Successful = false;
                tdResult.Error = baseObject as TdApi.Error;
            }
            else
            {
                tdResult.Successful = true;
                tdResult.Result = baseObject as TdApi.Seconds;
            }
            return tdResult;
        }
    }
}
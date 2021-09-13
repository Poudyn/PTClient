using System.Threading.Tasks;
using TdApi = Telegram.Td.Api;

namespace PTClient
{
    public static partial class Functions
    {
        public static async Task<TdResult<TdApi.Proxy>> AddProxyAsync(this TdClient tdClient, TdApi.AddProxy addProxy)
        {
            TdResult<TdApi.Proxy> tdResult = new TdResult<TdApi.Proxy>();
            TdApi.BaseObject baseObject = await tdClient.ExecuteAsync(addProxy);
            if (baseObject is TdApi.Error)
            {
                tdResult.Successful = false;
                tdResult.Error = baseObject as TdApi.Error;
            }
            else
            {
                tdResult.Successful = true;
                tdResult.Result = baseObject as TdApi.Proxy;
            }
            return tdResult;
        }
    }
}
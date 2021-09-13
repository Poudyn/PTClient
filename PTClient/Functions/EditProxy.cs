using System.Threading.Tasks;
using TdApi = Telegram.Td.Api;

namespace PTClient
{
    public static partial class Functions
    {
        public static async Task<TdResult<TdApi.Proxy>> EditProxyAsync(this TdClient tdClient, TdApi.EditProxy editProxy)
        {
            TdResult<TdApi.Proxy> tdResult = new TdResult<TdApi.Proxy>();
            TdApi.BaseObject baseObject = await tdClient.ExecuteAsync(editProxy);
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
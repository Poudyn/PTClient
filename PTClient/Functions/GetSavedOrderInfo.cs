using System.Threading.Tasks;
using TdApi = Telegram.Td.Api;

namespace PTClient
{
    public static partial class Functions
    {
        public static async Task<TdResult<TdApi.OrderInfo>> GetSavedOrderInfoAsync(this TdClient tdClient, TdApi.GetSavedOrderInfo getSavedOrderInfo)
        {
            TdResult<TdApi.OrderInfo> tdResult = new TdResult<TdApi.OrderInfo>();
            TdApi.BaseObject baseObject = await tdClient.ExecuteAsync(getSavedOrderInfo);
            if (baseObject is TdApi.Error)
            {
                tdResult.Successful = false;
                tdResult.Error = baseObject as TdApi.Error;
            }
            else
            {
                tdResult.Successful = true;
                tdResult.Result = baseObject as TdApi.OrderInfo;
            }
            return tdResult;
        }
    }
}
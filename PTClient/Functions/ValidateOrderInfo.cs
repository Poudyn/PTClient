using System.Threading.Tasks;
using TdApi = Telegram.Td.Api;

namespace PTClient
{
    public static partial class Functions
    {
        public static async Task<TdResult<TdApi.ValidatedOrderInfo>> ValidateOrderInfoAsync(this TdClient tdClient, TdApi.ValidateOrderInfo validateOrderInfo)
        {
            TdResult<TdApi.ValidatedOrderInfo> tdResult = new TdResult<TdApi.ValidatedOrderInfo>();
            TdApi.BaseObject baseObject = await tdClient.ExecuteAsync(validateOrderInfo);
            if (baseObject is TdApi.Error)
            {
                tdResult.Successful = false;
                tdResult.Error = baseObject as TdApi.Error;
            }
            else
            {
                tdResult.Successful = true;
                tdResult.Result = baseObject as TdApi.ValidatedOrderInfo;
            }
            return tdResult;
        }
    }
}
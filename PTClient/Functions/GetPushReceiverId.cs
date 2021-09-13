using System.Threading.Tasks;
using TdApi = Telegram.Td.Api;

namespace PTClient
{
    public static partial class Functions
    {
        public static async Task<TdResult<TdApi.PushReceiverId>> GetPushReceiverIdAsync(this TdClient tdClient, TdApi.GetPushReceiverId getPushReceiverId)
        {
            TdResult<TdApi.PushReceiverId> tdResult = new TdResult<TdApi.PushReceiverId>();
            TdApi.BaseObject baseObject = await tdClient.ExecuteAsync(getPushReceiverId);
            if (baseObject is TdApi.Error)
            {
                tdResult.Successful = false;
                tdResult.Error = baseObject as TdApi.Error;
            }
            else
            {
                tdResult.Successful = true;
                tdResult.Result = baseObject as TdApi.PushReceiverId;
            }
            return tdResult;
        }
    }
}
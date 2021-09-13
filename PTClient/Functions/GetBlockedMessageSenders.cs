using System.Threading.Tasks;
using TdApi = Telegram.Td.Api;

namespace PTClient
{
    public static partial class Functions
    {
        public static async Task<TdResult<TdApi.MessageSenders>> GetBlockedMessageSendersAsync(this TdClient tdClient, TdApi.GetBlockedMessageSenders getBlockedMessageSenders)
        {
            TdResult<TdApi.MessageSenders> tdResult = new TdResult<TdApi.MessageSenders>();
            TdApi.BaseObject baseObject = await tdClient.ExecuteAsync(getBlockedMessageSenders);
            if (baseObject is TdApi.Error)
            {
                tdResult.Successful = false;
                tdResult.Error = baseObject as TdApi.Error;
            }
            else
            {
                tdResult.Successful = true;
                tdResult.Result = baseObject as TdApi.MessageSenders;
            }
            return tdResult;
        }
    }
}
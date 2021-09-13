using System.Threading.Tasks;
using TdApi = Telegram.Td.Api;

namespace PTClient
{
    public static partial class Functions
    {
        public static async Task<TdResult<TdApi.Message>> SendChatSetTtlMessageAsync(this TdClient tdClient, TdApi.SendChatSetTtlMessage sendChatSetTtlMessage)
        {
            TdResult<TdApi.Message> tdResult = new TdResult<TdApi.Message>();
            TdApi.BaseObject baseObject = await tdClient.ExecuteAsync(sendChatSetTtlMessage);
            if (baseObject is TdApi.Error)
            {
                tdResult.Successful = false;
                tdResult.Error = baseObject as TdApi.Error;
            }
            else
            {
                tdResult.Successful = true;
                tdResult.Result = baseObject as TdApi.Message;
            }
            return tdResult;
        }
    }
}
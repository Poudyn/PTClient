using System.Threading.Tasks;
using TdApi = Telegram.Td.Api;

namespace PTClient
{
    public static partial class Functions
    {
        public static async Task<TdResult<TdApi.ChatEvents>> GetChatEventLogAsync(this TdClient tdClient, TdApi.GetChatEventLog getChatEventLog)
        {
            TdResult<TdApi.ChatEvents> tdResult = new TdResult<TdApi.ChatEvents>();
            TdApi.BaseObject baseObject = await tdClient.ExecuteAsync(getChatEventLog);
            if (baseObject is TdApi.Error)
            {
                tdResult.Successful = false;
                tdResult.Error = baseObject as TdApi.Error;
            }
            else
            {
                tdResult.Successful = true;
                tdResult.Result = baseObject as TdApi.ChatEvents;
            }
            return tdResult;
        }
    }
}
using System.Threading.Tasks;
using TdApi = Telegram.Td.Api;

namespace PTClient
{
    public static partial class Functions
    {
        public static async Task<TdResult<TdApi.Messages>> GetChatHistoryAsync(this TdClient tdClient, TdApi.GetChatHistory getChatHistory)
        {
            TdResult<TdApi.Messages> tdResult = new TdResult<TdApi.Messages>();
            TdApi.BaseObject baseObject = await tdClient.ExecuteAsync(getChatHistory);
            if (baseObject is TdApi.Error)
            {
                tdResult.Successful = false;
                tdResult.Error = baseObject as TdApi.Error;
            }
            else
            {
                tdResult.Successful = true;
                tdResult.Result = baseObject as TdApi.Messages;
            }
            return tdResult;
        }
    }
}
using System.Threading.Tasks;
using TdApi = Telegram.Td.Api;

namespace PTClient
{
    public static partial class Functions
    {
        public static async Task<TdResult<TdApi.Ok>> DeleteChatMessagesFromUserAsync(this TdClient tdClient, TdApi.DeleteChatMessagesFromUser deleteChatMessagesFromUser)
        {
            TdResult<TdApi.Ok> tdResult = new TdResult<TdApi.Ok>();
            TdApi.BaseObject baseObject = await tdClient.ExecuteAsync(deleteChatMessagesFromUser);
            if (baseObject is TdApi.Error)
            {
                tdResult.Successful = false;
                tdResult.Error = baseObject as TdApi.Error;
            }
            else
            {
                tdResult.Successful = true;
                tdResult.Result = baseObject as TdApi.Ok;
            }
            return tdResult;
        }
    }
}
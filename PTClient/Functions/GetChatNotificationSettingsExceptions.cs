using System.Threading.Tasks;
using TdApi = Telegram.Td.Api;

namespace PTClient
{
    public static partial class Functions
    {
        public static async Task<TdResult<TdApi.Chats>> GetChatNotificationSettingsExceptionsAsync(this TdClient tdClient, TdApi.GetChatNotificationSettingsExceptions getChatNotificationSettingsExceptions)
        {
            TdResult<TdApi.Chats> tdResult = new TdResult<TdApi.Chats>();
            TdApi.BaseObject baseObject = await tdClient.ExecuteAsync(getChatNotificationSettingsExceptions);
            if (baseObject is TdApi.Error)
            {
                tdResult.Successful = false;
                tdResult.Error = baseObject as TdApi.Error;
            }
            else
            {
                tdResult.Successful = true;
                tdResult.Result = baseObject as TdApi.Chats;
            }
            return tdResult;
        }
    }
}
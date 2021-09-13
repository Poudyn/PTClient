using System.Threading.Tasks;
using TdApi = Telegram.Td.Api;

namespace PTClient
{
    public static partial class Functions
    {
        public static async Task<TdResult<TdApi.ChatLists>> GetChatListsToAddChatAsync(this TdClient tdClient, TdApi.GetChatListsToAddChat getChatListsToAddChat)
        {
            TdResult<TdApi.ChatLists> tdResult = new TdResult<TdApi.ChatLists>();
            TdApi.BaseObject baseObject = await tdClient.ExecuteAsync(getChatListsToAddChat);
            if (baseObject is TdApi.Error)
            {
                tdResult.Successful = false;
                tdResult.Error = baseObject as TdApi.Error;
            }
            else
            {
                tdResult.Successful = true;
                tdResult.Result = baseObject as TdApi.ChatLists;
            }
            return tdResult;
        }
    }
}
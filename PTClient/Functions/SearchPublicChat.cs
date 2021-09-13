using System.Threading.Tasks;
using TdApi = Telegram.Td.Api;

namespace PTClient
{
    public static partial class Functions
    {
        public static async Task<TdResult<TdApi.Chat>> SearchPublicChatAsync(this TdClient tdClient, TdApi.SearchPublicChat searchPublicChat)
        {
            TdResult<TdApi.Chat> tdResult = new TdResult<TdApi.Chat>();
            TdApi.BaseObject baseObject = await tdClient.ExecuteAsync(searchPublicChat);
            if (baseObject is TdApi.Error)
            {
                tdResult.Successful = false;
                tdResult.Error = baseObject as TdApi.Error;
            }
            else
            {
                tdResult.Successful = true;
                tdResult.Result = baseObject as TdApi.Chat;
            }
            return tdResult;
        }
    }
}
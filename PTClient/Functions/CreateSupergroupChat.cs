using System.Threading.Tasks;
using TdApi = Telegram.Td.Api;

namespace PTClient
{
    public static partial class Functions
    {
        public static async Task<TdResult<TdApi.Chat>> CreateSupergroupChatAsync(this TdClient tdClient, TdApi.CreateSupergroupChat createSupergroupChat)
        {
            TdResult<TdApi.Chat> tdResult = new TdResult<TdApi.Chat>();
            TdApi.BaseObject baseObject = await tdClient.ExecuteAsync(createSupergroupChat);
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
using System.Threading.Tasks;
using TdApi = Telegram.Td.Api;

namespace PTClient
{
    public static partial class Functions
    {
        public static async Task<TdResult<TdApi.ChatFilter>> GetChatFilterAsync(this TdClient tdClient, TdApi.GetChatFilter getChatFilter)
        {
            TdResult<TdApi.ChatFilter> tdResult = new TdResult<TdApi.ChatFilter>();
            TdApi.BaseObject baseObject = await tdClient.ExecuteAsync(getChatFilter);
            if (baseObject is TdApi.Error)
            {
                tdResult.Successful = false;
                tdResult.Error = baseObject as TdApi.Error;
            }
            else
            {
                tdResult.Successful = true;
                tdResult.Result = baseObject as TdApi.ChatFilter;
            }
            return tdResult;
        }
    }
}
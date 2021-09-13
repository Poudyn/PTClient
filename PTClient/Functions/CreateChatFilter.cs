using System.Threading.Tasks;
using TdApi = Telegram.Td.Api;

namespace PTClient
{
    public static partial class Functions
    {
        public static async Task<TdResult<TdApi.ChatFilterInfo>> CreateChatFilterAsync(this TdClient tdClient, TdApi.CreateChatFilter createChatFilter)
        {
            TdResult<TdApi.ChatFilterInfo> tdResult = new TdResult<TdApi.ChatFilterInfo>();
            TdApi.BaseObject baseObject = await tdClient.ExecuteAsync(createChatFilter);
            if (baseObject is TdApi.Error)
            {
                tdResult.Successful = false;
                tdResult.Error = baseObject as TdApi.Error;
            }
            else
            {
                tdResult.Successful = true;
                tdResult.Result = baseObject as TdApi.ChatFilterInfo;
            }
            return tdResult;
        }
    }
}
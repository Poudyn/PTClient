using System.Threading.Tasks;
using TdApi = Telegram.Td.Api;

namespace PTClient
{
    public static partial class Functions
    {
        public static async Task<TdResult<TdApi.Count>> GetChatMessageCountAsync(this TdClient tdClient, TdApi.GetChatMessageCount getChatMessageCount)
        {
            TdResult<TdApi.Count> tdResult = new TdResult<TdApi.Count>();
            TdApi.BaseObject baseObject = await tdClient.ExecuteAsync(getChatMessageCount);
            if (baseObject is TdApi.Error)
            {
                tdResult.Successful = false;
                tdResult.Error = baseObject as TdApi.Error;
            }
            else
            {
                tdResult.Successful = true;
                tdResult.Result = baseObject as TdApi.Count;
            }
            return tdResult;
        }
    }
}
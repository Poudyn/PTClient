using System.Threading.Tasks;
using TdApi = Telegram.Td.Api;

namespace PTClient
{
    public static partial class Functions
    {
        public static async Task<TdResult<TdApi.ChatStatistics>> GetChatStatisticsAsync(this TdClient tdClient, TdApi.GetChatStatistics getChatStatistics)
        {
            TdResult<TdApi.ChatStatistics> tdResult = new TdResult<TdApi.ChatStatistics>();
            TdApi.BaseObject baseObject = await tdClient.ExecuteAsync(getChatStatistics);
            if (baseObject is TdApi.Error)
            {
                tdResult.Successful = false;
                tdResult.Error = baseObject as TdApi.Error;
            }
            else
            {
                tdResult.Successful = true;
                tdResult.Result = baseObject as TdApi.ChatStatistics;
            }
            return tdResult;
        }
    }
}
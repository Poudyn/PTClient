using System.Threading.Tasks;
using TdApi = Telegram.Td.Api;

namespace PTClient
{
    public static partial class Functions
    {
        public static async Task<TdResult<TdApi.MessageStatistics>> GetMessageStatisticsAsync(this TdClient tdClient, TdApi.GetMessageStatistics getMessageStatistics)
        {
            TdResult<TdApi.MessageStatistics> tdResult = new TdResult<TdApi.MessageStatistics>();
            TdApi.BaseObject baseObject = await tdClient.ExecuteAsync(getMessageStatistics);
            if (baseObject is TdApi.Error)
            {
                tdResult.Successful = false;
                tdResult.Error = baseObject as TdApi.Error;
            }
            else
            {
                tdResult.Successful = true;
                tdResult.Result = baseObject as TdApi.MessageStatistics;
            }
            return tdResult;
        }
    }
}
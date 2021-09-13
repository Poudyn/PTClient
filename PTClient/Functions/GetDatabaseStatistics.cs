using System.Threading.Tasks;
using TdApi = Telegram.Td.Api;

namespace PTClient
{
    public static partial class Functions
    {
        public static async Task<TdResult<TdApi.DatabaseStatistics>> GetDatabaseStatisticsAsync(this TdClient tdClient, TdApi.GetDatabaseStatistics getDatabaseStatistics)
        {
            TdResult<TdApi.DatabaseStatistics> tdResult = new TdResult<TdApi.DatabaseStatistics>();
            TdApi.BaseObject baseObject = await tdClient.ExecuteAsync(getDatabaseStatistics);
            if (baseObject is TdApi.Error)
            {
                tdResult.Successful = false;
                tdResult.Error = baseObject as TdApi.Error;
            }
            else
            {
                tdResult.Successful = true;
                tdResult.Result = baseObject as TdApi.DatabaseStatistics;
            }
            return tdResult;
        }
    }
}
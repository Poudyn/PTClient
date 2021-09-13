using System.Threading.Tasks;
using TdApi = Telegram.Td.Api;

namespace PTClient
{
    public static partial class Functions
    {
        public static async Task<TdResult<TdApi.NetworkStatistics>> GetNetworkStatisticsAsync(this TdClient tdClient, TdApi.GetNetworkStatistics getNetworkStatistics)
        {
            TdResult<TdApi.NetworkStatistics> tdResult = new TdResult<TdApi.NetworkStatistics>();
            TdApi.BaseObject baseObject = await tdClient.ExecuteAsync(getNetworkStatistics);
            if (baseObject is TdApi.Error)
            {
                tdResult.Successful = false;
                tdResult.Error = baseObject as TdApi.Error;
            }
            else
            {
                tdResult.Successful = true;
                tdResult.Result = baseObject as TdApi.NetworkStatistics;
            }
            return tdResult;
        }
    }
}
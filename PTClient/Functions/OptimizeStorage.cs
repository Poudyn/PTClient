using System.Threading.Tasks;
using TdApi = Telegram.Td.Api;

namespace PTClient
{
    public static partial class Functions
    {
        public static async Task<TdResult<TdApi.StorageStatistics>> OptimizeStorageAsync(this TdClient tdClient, TdApi.OptimizeStorage optimizeStorage)
        {
            TdResult<TdApi.StorageStatistics> tdResult = new TdResult<TdApi.StorageStatistics>();
            TdApi.BaseObject baseObject = await tdClient.ExecuteAsync(optimizeStorage);
            if (baseObject is TdApi.Error)
            {
                tdResult.Successful = false;
                tdResult.Error = baseObject as TdApi.Error;
            }
            else
            {
                tdResult.Successful = true;
                tdResult.Result = baseObject as TdApi.StorageStatistics;
            }
            return tdResult;
        }
    }
}
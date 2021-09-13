using System.Threading.Tasks;
using TdApi = Telegram.Td.Api;

namespace PTClient
{
    public static partial class Functions
    {
        public static async Task<TdResult<TdApi.StorageStatisticsFast>> GetStorageStatisticsFastAsync(this TdClient tdClient, TdApi.GetStorageStatisticsFast getStorageStatisticsFast)
        {
            TdResult<TdApi.StorageStatisticsFast> tdResult = new TdResult<TdApi.StorageStatisticsFast>();
            TdApi.BaseObject baseObject = await tdClient.ExecuteAsync(getStorageStatisticsFast);
            if (baseObject is TdApi.Error)
            {
                tdResult.Successful = false;
                tdResult.Error = baseObject as TdApi.Error;
            }
            else
            {
                tdResult.Successful = true;
                tdResult.Result = baseObject as TdApi.StorageStatisticsFast;
            }
            return tdResult;
        }
    }
}
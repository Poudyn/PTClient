using System.Threading.Tasks;
using TdApi = Telegram.Td.Api;

namespace PTClient
{
    public static partial class Functions
    {
        public static async Task<TdResult<TdApi.BasicGroupFullInfo>> GetBasicGroupFullInfoAsync(this TdClient tdClient, TdApi.GetBasicGroupFullInfo getBasicGroupFullInfo)
        {
            TdResult<TdApi.BasicGroupFullInfo> tdResult = new TdResult<TdApi.BasicGroupFullInfo>();
            TdApi.BaseObject baseObject = await tdClient.ExecuteAsync(getBasicGroupFullInfo);
            if (baseObject is TdApi.Error)
            {
                tdResult.Successful = false;
                tdResult.Error = baseObject as TdApi.Error;
            }
            else
            {
                tdResult.Successful = true;
                tdResult.Result = baseObject as TdApi.BasicGroupFullInfo;
            }
            return tdResult;
        }
    }
}
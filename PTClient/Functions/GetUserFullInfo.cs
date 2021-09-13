using System.Threading.Tasks;
using TdApi = Telegram.Td.Api;

namespace PTClient
{
    public static partial class Functions
    {
        public static async Task<TdResult<TdApi.UserFullInfo>> GetUserFullInfoAsync(this TdClient tdClient, TdApi.GetUserFullInfo getUserFullInfo)
        {
            TdResult<TdApi.UserFullInfo> tdResult = new TdResult<TdApi.UserFullInfo>();
            TdApi.BaseObject baseObject = await tdClient.ExecuteAsync(getUserFullInfo);
            if (baseObject is TdApi.Error)
            {
                tdResult.Successful = false;
                tdResult.Error = baseObject as TdApi.Error;
            }
            else
            {
                tdResult.Successful = true;
                tdResult.Result = baseObject as TdApi.UserFullInfo;
            }
            return tdResult;
        }
    }
}
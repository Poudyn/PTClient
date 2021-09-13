using System.Threading.Tasks;
using TdApi = Telegram.Td.Api;

namespace PTClient
{
    public static partial class Functions
    {
        public static async Task<TdResult<TdApi.SupergroupFullInfo>> GetSupergroupFullInfoAsync(this TdClient tdClient, TdApi.GetSupergroupFullInfo getSupergroupFullInfo)
        {
            TdResult<TdApi.SupergroupFullInfo> tdResult = new TdResult<TdApi.SupergroupFullInfo>();
            TdApi.BaseObject baseObject = await tdClient.ExecuteAsync(getSupergroupFullInfo);
            if (baseObject is TdApi.Error)
            {
                tdResult.Successful = false;
                tdResult.Error = baseObject as TdApi.Error;
            }
            else
            {
                tdResult.Successful = true;
                tdResult.Result = baseObject as TdApi.SupergroupFullInfo;
            }
            return tdResult;
        }
    }
}
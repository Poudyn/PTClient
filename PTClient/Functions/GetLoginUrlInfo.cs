using System.Threading.Tasks;
using TdApi = Telegram.Td.Api;

namespace PTClient
{
    public static partial class Functions
    {
        public static async Task<TdResult<TdApi.LoginUrlInfo>> GetLoginUrlInfoAsync(this TdClient tdClient, TdApi.GetLoginUrlInfo getLoginUrlInfo)
        {
            TdResult<TdApi.LoginUrlInfo> tdResult = new TdResult<TdApi.LoginUrlInfo>();
            TdApi.BaseObject baseObject = await tdClient.ExecuteAsync(getLoginUrlInfo);
            if (baseObject is TdApi.Error)
            {
                tdResult.Successful = false;
                tdResult.Error = baseObject as TdApi.Error;
            }
            else
            {
                tdResult.Successful = true;
                tdResult.Result = baseObject as TdApi.LoginUrlInfo;
            }
            return tdResult;
        }
    }
}
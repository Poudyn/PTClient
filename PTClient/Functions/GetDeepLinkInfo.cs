using System.Threading.Tasks;
using TdApi = Telegram.Td.Api;

namespace PTClient
{
    public static partial class Functions
    {
        public static async Task<TdResult<TdApi.DeepLinkInfo>> GetDeepLinkInfoAsync(this TdClient tdClient, TdApi.GetDeepLinkInfo getDeepLinkInfo)
        {
            TdResult<TdApi.DeepLinkInfo> tdResult = new TdResult<TdApi.DeepLinkInfo>();
            TdApi.BaseObject baseObject = await tdClient.ExecuteAsync(getDeepLinkInfo);
            if (baseObject is TdApi.Error)
            {
                tdResult.Successful = false;
                tdResult.Error = baseObject as TdApi.Error;
            }
            else
            {
                tdResult.Successful = true;
                tdResult.Result = baseObject as TdApi.DeepLinkInfo;
            }
            return tdResult;
        }
    }
}
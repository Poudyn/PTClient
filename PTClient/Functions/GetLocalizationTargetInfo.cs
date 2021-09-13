using System.Threading.Tasks;
using TdApi = Telegram.Td.Api;

namespace PTClient
{
    public static partial class Functions
    {
        public static async Task<TdResult<TdApi.LocalizationTargetInfo>> GetLocalizationTargetInfoAsync(this TdClient tdClient, TdApi.GetLocalizationTargetInfo getLocalizationTargetInfo)
        {
            TdResult<TdApi.LocalizationTargetInfo> tdResult = new TdResult<TdApi.LocalizationTargetInfo>();
            TdApi.BaseObject baseObject = await tdClient.ExecuteAsync(getLocalizationTargetInfo);
            if (baseObject is TdApi.Error)
            {
                tdResult.Successful = false;
                tdResult.Error = baseObject as TdApi.Error;
            }
            else
            {
                tdResult.Successful = true;
                tdResult.Result = baseObject as TdApi.LocalizationTargetInfo;
            }
            return tdResult;
        }
    }
}
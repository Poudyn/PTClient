using System.Threading.Tasks;
using TdApi = Telegram.Td.Api;

namespace PTClient
{
    public static partial class Functions
    {
        public static async Task<TdResult<TdApi.LanguagePackInfo>> GetLanguagePackInfoAsync(this TdClient tdClient, TdApi.GetLanguagePackInfo getLanguagePackInfo)
        {
            TdResult<TdApi.LanguagePackInfo> tdResult = new TdResult<TdApi.LanguagePackInfo>();
            TdApi.BaseObject baseObject = await tdClient.ExecuteAsync(getLanguagePackInfo);
            if (baseObject is TdApi.Error)
            {
                tdResult.Successful = false;
                tdResult.Error = baseObject as TdApi.Error;
            }
            else
            {
                tdResult.Successful = true;
                tdResult.Result = baseObject as TdApi.LanguagePackInfo;
            }
            return tdResult;
        }
    }
}
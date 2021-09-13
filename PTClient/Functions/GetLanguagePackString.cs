using System.Threading.Tasks;
using TdApi = Telegram.Td.Api;

namespace PTClient
{
    public static partial class Functions
    {
        public static async Task<TdResult<TdApi.LanguagePackStringValue>> GetLanguagePackStringAsync(this TdClient tdClient, TdApi.GetLanguagePackString getLanguagePackString)
        {
            TdResult<TdApi.LanguagePackStringValue> tdResult = new TdResult<TdApi.LanguagePackStringValue>();
            TdApi.BaseObject baseObject = await tdClient.ExecuteAsync(getLanguagePackString);
            if (baseObject is TdApi.Error)
            {
                tdResult.Successful = false;
                tdResult.Error = baseObject as TdApi.Error;
            }
            else
            {
                tdResult.Successful = true;
                tdResult.Result = baseObject as TdApi.LanguagePackStringValue;
            }
            return tdResult;
        }
    }
}
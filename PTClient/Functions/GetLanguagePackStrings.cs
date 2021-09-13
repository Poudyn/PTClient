using System.Threading.Tasks;
using TdApi = Telegram.Td.Api;

namespace PTClient
{
    public static partial class Functions
    {
        public static async Task<TdResult<TdApi.LanguagePackStrings>> GetLanguagePackStringsAsync(this TdClient tdClient, TdApi.GetLanguagePackStrings getLanguagePackStrings)
        {
            TdResult<TdApi.LanguagePackStrings> tdResult = new TdResult<TdApi.LanguagePackStrings>();
            TdApi.BaseObject baseObject = await tdClient.ExecuteAsync(getLanguagePackStrings);
            if (baseObject is TdApi.Error)
            {
                tdResult.Successful = false;
                tdResult.Error = baseObject as TdApi.Error;
            }
            else
            {
                tdResult.Successful = true;
                tdResult.Result = baseObject as TdApi.LanguagePackStrings;
            }
            return tdResult;
        }
    }
}
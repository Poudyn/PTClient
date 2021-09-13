using System.Threading.Tasks;
using TdApi = Telegram.Td.Api;

namespace PTClient
{
    public static partial class Functions
    {
        public static async Task<TdResult<TdApi.PassportElementsWithErrors>> GetPassportAuthorizationFormAvailableElementsAsync(this TdClient tdClient, TdApi.GetPassportAuthorizationFormAvailableElements getPassportAuthorizationFormAvailableElements)
        {
            TdResult<TdApi.PassportElementsWithErrors> tdResult = new TdResult<TdApi.PassportElementsWithErrors>();
            TdApi.BaseObject baseObject = await tdClient.ExecuteAsync(getPassportAuthorizationFormAvailableElements);
            if (baseObject is TdApi.Error)
            {
                tdResult.Successful = false;
                tdResult.Error = baseObject as TdApi.Error;
            }
            else
            {
                tdResult.Successful = true;
                tdResult.Result = baseObject as TdApi.PassportElementsWithErrors;
            }
            return tdResult;
        }
    }
}
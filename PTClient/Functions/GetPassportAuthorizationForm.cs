using System.Threading.Tasks;
using TdApi = Telegram.Td.Api;

namespace PTClient
{
    public static partial class Functions
    {
        public static async Task<TdResult<TdApi.PassportAuthorizationForm>> GetPassportAuthorizationFormAsync(this TdClient tdClient, TdApi.GetPassportAuthorizationForm getPassportAuthorizationForm)
        {
            TdResult<TdApi.PassportAuthorizationForm> tdResult = new TdResult<TdApi.PassportAuthorizationForm>();
            TdApi.BaseObject baseObject = await tdClient.ExecuteAsync(getPassportAuthorizationForm);
            if (baseObject is TdApi.Error)
            {
                tdResult.Successful = false;
                tdResult.Error = baseObject as TdApi.Error;
            }
            else
            {
                tdResult.Successful = true;
                tdResult.Result = baseObject as TdApi.PassportAuthorizationForm;
            }
            return tdResult;
        }
    }
}
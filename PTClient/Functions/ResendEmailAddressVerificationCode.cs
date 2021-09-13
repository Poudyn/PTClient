using System.Threading.Tasks;
using TdApi = Telegram.Td.Api;

namespace PTClient
{
    public static partial class Functions
    {
        public static async Task<TdResult<TdApi.EmailAddressAuthenticationCodeInfo>> ResendEmailAddressVerificationCodeAsync(this TdClient tdClient, TdApi.ResendEmailAddressVerificationCode resendEmailAddressVerificationCode)
        {
            TdResult<TdApi.EmailAddressAuthenticationCodeInfo> tdResult = new TdResult<TdApi.EmailAddressAuthenticationCodeInfo>();
            TdApi.BaseObject baseObject = await tdClient.ExecuteAsync(resendEmailAddressVerificationCode);
            if (baseObject is TdApi.Error)
            {
                tdResult.Successful = false;
                tdResult.Error = baseObject as TdApi.Error;
            }
            else
            {
                tdResult.Successful = true;
                tdResult.Result = baseObject as TdApi.EmailAddressAuthenticationCodeInfo;
            }
            return tdResult;
        }
    }
}
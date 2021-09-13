using System.Threading.Tasks;
using TdApi = Telegram.Td.Api;

namespace PTClient
{
    public static partial class Functions
    {
        public static async Task<TdResult<TdApi.AuthenticationCodeInfo>> ResendPhoneNumberConfirmationCodeAsync(this TdClient tdClient, TdApi.ResendPhoneNumberConfirmationCode resendPhoneNumberConfirmationCode)
        {
            TdResult<TdApi.AuthenticationCodeInfo> tdResult = new TdResult<TdApi.AuthenticationCodeInfo>();
            TdApi.BaseObject baseObject = await tdClient.ExecuteAsync(resendPhoneNumberConfirmationCode);
            if (baseObject is TdApi.Error)
            {
                tdResult.Successful = false;
                tdResult.Error = baseObject as TdApi.Error;
            }
            else
            {
                tdResult.Successful = true;
                tdResult.Result = baseObject as TdApi.AuthenticationCodeInfo;
            }
            return tdResult;
        }
    }
}
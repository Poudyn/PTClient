using System.Threading.Tasks;
using TdApi = Telegram.Td.Api;

namespace PTClient
{
    public static partial class Functions
    {
        public static async Task<TdResult<TdApi.PasswordState>> ResendRecoveryEmailAddressCodeAsync(this TdClient tdClient, TdApi.ResendRecoveryEmailAddressCode resendRecoveryEmailAddressCode)
        {
            TdResult<TdApi.PasswordState> tdResult = new TdResult<TdApi.PasswordState>();
            TdApi.BaseObject baseObject = await tdClient.ExecuteAsync(resendRecoveryEmailAddressCode);
            if (baseObject is TdApi.Error)
            {
                tdResult.Successful = false;
                tdResult.Error = baseObject as TdApi.Error;
            }
            else
            {
                tdResult.Successful = true;
                tdResult.Result = baseObject as TdApi.PasswordState;
            }
            return tdResult;
        }
    }
}
using System.Threading.Tasks;
using TdApi = Telegram.Td.Api;

namespace PTClient
{
    public static partial class Functions
    {
        public static async Task<TdResult<TdApi.RecoveryEmailAddress>> GetRecoveryEmailAddressAsync(this TdClient tdClient, TdApi.GetRecoveryEmailAddress getRecoveryEmailAddress)
        {
            TdResult<TdApi.RecoveryEmailAddress> tdResult = new TdResult<TdApi.RecoveryEmailAddress>();
            TdApi.BaseObject baseObject = await tdClient.ExecuteAsync(getRecoveryEmailAddress);
            if (baseObject is TdApi.Error)
            {
                tdResult.Successful = false;
                tdResult.Error = baseObject as TdApi.Error;
            }
            else
            {
                tdResult.Successful = true;
                tdResult.Result = baseObject as TdApi.RecoveryEmailAddress;
            }
            return tdResult;
        }
    }
}
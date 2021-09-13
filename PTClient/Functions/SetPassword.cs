using System.Threading.Tasks;
using TdApi = Telegram.Td.Api;

namespace PTClient
{
    public static partial class Functions
    {
        public static async Task<TdResult<TdApi.PasswordState>> SetPasswordAsync(this TdClient tdClient, TdApi.SetPassword setPassword)
        {
            TdResult<TdApi.PasswordState> tdResult = new TdResult<TdApi.PasswordState>();
            TdApi.BaseObject baseObject = await tdClient.ExecuteAsync(setPassword);
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
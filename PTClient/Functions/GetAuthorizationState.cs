using System.Threading.Tasks;
using TdApi = Telegram.Td.Api;

namespace PTClient
{
    public static partial class Functions
    {
        public static async Task<TdResult<TdApi.AuthorizationState>> GetAuthorizationStateAsync(this TdClient tdClient, TdApi.GetAuthorizationState getAuthorizationState)
        {
            TdResult<TdApi.AuthorizationState> tdResult = new TdResult<TdApi.AuthorizationState>();
            TdApi.BaseObject baseObject = await tdClient.ExecuteAsync(getAuthorizationState);
            if (baseObject is TdApi.Error)
            {
                tdResult.Successful = false;
                tdResult.Error = baseObject as TdApi.Error;
            }
            else
            {
                tdResult.Successful = true;
                tdResult.Result = baseObject as TdApi.AuthorizationState;
            }
            return tdResult;
        }
    }
}
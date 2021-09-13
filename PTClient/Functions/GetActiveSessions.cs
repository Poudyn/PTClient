using System.Threading.Tasks;
using TdApi = Telegram.Td.Api;

namespace PTClient
{
    public static partial class Functions
    {
        public static async Task<TdResult<TdApi.Sessions>> GetActiveSessionsAsync(this TdClient tdClient, TdApi.GetActiveSessions getActiveSessions)
        {
            TdResult<TdApi.Sessions> tdResult = new TdResult<TdApi.Sessions>();
            TdApi.BaseObject baseObject = await tdClient.ExecuteAsync(getActiveSessions);
            if (baseObject is TdApi.Error)
            {
                tdResult.Successful = false;
                tdResult.Error = baseObject as TdApi.Error;
            }
            else
            {
                tdResult.Successful = true;
                tdResult.Result = baseObject as TdApi.Sessions;
            }
            return tdResult;
        }
    }
}
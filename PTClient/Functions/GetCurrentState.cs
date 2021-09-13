using System.Threading.Tasks;
using TdApi = Telegram.Td.Api;

namespace PTClient
{
    public static partial class Functions
    {
        public static async Task<TdResult<TdApi.Updates>> GetCurrentStateAsync(this TdClient tdClient, TdApi.GetCurrentState getCurrentState)
        {
            TdResult<TdApi.Updates> tdResult = new TdResult<TdApi.Updates>();
            TdApi.BaseObject baseObject = await tdClient.ExecuteAsync(getCurrentState);
            if (baseObject is TdApi.Error)
            {
                tdResult.Successful = false;
                tdResult.Error = baseObject as TdApi.Error;
            }
            else
            {
                tdResult.Successful = true;
                tdResult.Result = baseObject as TdApi.Updates;
            }
            return tdResult;
        }
    }
}
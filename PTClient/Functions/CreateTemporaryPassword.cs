using System.Threading.Tasks;
using TdApi = Telegram.Td.Api;

namespace PTClient
{
    public static partial class Functions
    {
        public static async Task<TdResult<TdApi.TemporaryPasswordState>> CreateTemporaryPasswordAsync(this TdClient tdClient, TdApi.CreateTemporaryPassword createTemporaryPassword)
        {
            TdResult<TdApi.TemporaryPasswordState> tdResult = new TdResult<TdApi.TemporaryPasswordState>();
            TdApi.BaseObject baseObject = await tdClient.ExecuteAsync(createTemporaryPassword);
            if (baseObject is TdApi.Error)
            {
                tdResult.Successful = false;
                tdResult.Error = baseObject as TdApi.Error;
            }
            else
            {
                tdResult.Successful = true;
                tdResult.Result = baseObject as TdApi.TemporaryPasswordState;
            }
            return tdResult;
        }
    }
}
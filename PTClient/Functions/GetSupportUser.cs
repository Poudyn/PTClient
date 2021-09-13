using System.Threading.Tasks;
using TdApi = Telegram.Td.Api;

namespace PTClient
{
    public static partial class Functions
    {
        public static async Task<TdResult<TdApi.User>> GetSupportUserAsync(this TdClient tdClient, TdApi.GetSupportUser getSupportUser)
        {
            TdResult<TdApi.User> tdResult = new TdResult<TdApi.User>();
            TdApi.BaseObject baseObject = await tdClient.ExecuteAsync(getSupportUser);
            if (baseObject is TdApi.Error)
            {
                tdResult.Successful = false;
                tdResult.Error = baseObject as TdApi.Error;
            }
            else
            {
                tdResult.Successful = true;
                tdResult.Result = baseObject as TdApi.User;
            }
            return tdResult;
        }
    }
}
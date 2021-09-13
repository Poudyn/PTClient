using System.Threading.Tasks;
using TdApi = Telegram.Td.Api;

namespace PTClient
{
    public static partial class Functions
    {
        public static async Task<TdResult<TdApi.Users>> GetPollVotersAsync(this TdClient tdClient, TdApi.GetPollVoters getPollVoters)
        {
            TdResult<TdApi.Users> tdResult = new TdResult<TdApi.Users>();
            TdApi.BaseObject baseObject = await tdClient.ExecuteAsync(getPollVoters);
            if (baseObject is TdApi.Error)
            {
                tdResult.Successful = false;
                tdResult.Error = baseObject as TdApi.Error;
            }
            else
            {
                tdResult.Successful = true;
                tdResult.Result = baseObject as TdApi.Users;
            }
            return tdResult;
        }
    }
}
using System.Threading.Tasks;
using TdApi = Telegram.Td.Api;

namespace PTClient
{
    public static partial class Functions
    {
        public static async Task<TdResult<TdApi.CallId>> CreateCallAsync(this TdClient tdClient, TdApi.CreateCall createCall)
        {
            TdResult<TdApi.CallId> tdResult = new TdResult<TdApi.CallId>();
            TdApi.BaseObject baseObject = await tdClient.ExecuteAsync(createCall);
            if (baseObject is TdApi.Error)
            {
                tdResult.Successful = false;
                tdResult.Error = baseObject as TdApi.Error;
            }
            else
            {
                tdResult.Successful = true;
                tdResult.Result = baseObject as TdApi.CallId;
            }
            return tdResult;
        }
    }
}
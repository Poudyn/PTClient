using System.Threading.Tasks;
using TdApi = Telegram.Td.Api;

namespace PTClient
{
    public static partial class Functions
    {
        public static async Task<TdResult<TdApi.Error>> TestReturnErrorAsync(this TdClient tdClient, TdApi.TestReturnError testReturnError)
        {
            TdResult<TdApi.Error> tdResult = new TdResult<TdApi.Error>();
            TdApi.BaseObject baseObject = await tdClient.ExecuteAsync(testReturnError);
            if (baseObject is TdApi.Error)
            {
                tdResult.Successful = false;
                tdResult.Error = baseObject as TdApi.Error;
            }
            else
            {
                tdResult.Successful = true;
                tdResult.Result = baseObject as TdApi.Error;
            }
            return tdResult;
        }
    }
}
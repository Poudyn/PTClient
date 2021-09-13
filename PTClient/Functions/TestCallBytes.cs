using System.Threading.Tasks;
using TdApi = Telegram.Td.Api;

namespace PTClient
{
    public static partial class Functions
    {
        public static async Task<TdResult<TdApi.TestBytes>> TestCallBytesAsync(this TdClient tdClient, TdApi.TestCallBytes testCallBytes)
        {
            TdResult<TdApi.TestBytes> tdResult = new TdResult<TdApi.TestBytes>();
            TdApi.BaseObject baseObject = await tdClient.ExecuteAsync(testCallBytes);
            if (baseObject is TdApi.Error)
            {
                tdResult.Successful = false;
                tdResult.Error = baseObject as TdApi.Error;
            }
            else
            {
                tdResult.Successful = true;
                tdResult.Result = baseObject as TdApi.TestBytes;
            }
            return tdResult;
        }
    }
}
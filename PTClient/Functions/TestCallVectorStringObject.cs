using System.Threading.Tasks;
using TdApi = Telegram.Td.Api;

namespace PTClient
{
    public static partial class Functions
    {
        public static async Task<TdResult<TdApi.TestVectorStringObject>> TestCallVectorStringObjectAsync(this TdClient tdClient, TdApi.TestCallVectorStringObject testCallVectorStringObject)
        {
            TdResult<TdApi.TestVectorStringObject> tdResult = new TdResult<TdApi.TestVectorStringObject>();
            TdApi.BaseObject baseObject = await tdClient.ExecuteAsync(testCallVectorStringObject);
            if (baseObject is TdApi.Error)
            {
                tdResult.Successful = false;
                tdResult.Error = baseObject as TdApi.Error;
            }
            else
            {
                tdResult.Successful = true;
                tdResult.Result = baseObject as TdApi.TestVectorStringObject;
            }
            return tdResult;
        }
    }
}
using System.Threading.Tasks;
using TdApi = Telegram.Td.Api;

namespace PTClient
{
    public static partial class Functions
    {
        public static async Task<TdResult<TdApi.TestVectorInt>> TestCallVectorIntAsync(this TdClient tdClient, TdApi.TestCallVectorInt testCallVectorInt)
        {
            TdResult<TdApi.TestVectorInt> tdResult = new TdResult<TdApi.TestVectorInt>();
            TdApi.BaseObject baseObject = await tdClient.ExecuteAsync(testCallVectorInt);
            if (baseObject is TdApi.Error)
            {
                tdResult.Successful = false;
                tdResult.Error = baseObject as TdApi.Error;
            }
            else
            {
                tdResult.Successful = true;
                tdResult.Result = baseObject as TdApi.TestVectorInt;
            }
            return tdResult;
        }
    }
}
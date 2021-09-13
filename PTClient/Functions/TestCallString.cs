using System.Threading.Tasks;
using TdApi = Telegram.Td.Api;

namespace PTClient
{
    public static partial class Functions
    {
        public static async Task<TdResult<TdApi.TestString>> TestCallStringAsync(this TdClient tdClient, TdApi.TestCallString testCallString)
        {
            TdResult<TdApi.TestString> tdResult = new TdResult<TdApi.TestString>();
            TdApi.BaseObject baseObject = await tdClient.ExecuteAsync(testCallString);
            if (baseObject is TdApi.Error)
            {
                tdResult.Successful = false;
                tdResult.Error = baseObject as TdApi.Error;
            }
            else
            {
                tdResult.Successful = true;
                tdResult.Result = baseObject as TdApi.TestString;
            }
            return tdResult;
        }
    }
}
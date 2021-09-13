using System.Threading.Tasks;
using TdApi = Telegram.Td.Api;

namespace PTClient
{
    public static partial class Functions
    {
        public static async Task<TdResult<TdApi.Update>> TestUseUpdateAsync(this TdClient tdClient, TdApi.TestUseUpdate testUseUpdate)
        {
            TdResult<TdApi.Update> tdResult = new TdResult<TdApi.Update>();
            TdApi.BaseObject baseObject = await tdClient.ExecuteAsync(testUseUpdate);
            if (baseObject is TdApi.Error)
            {
                tdResult.Successful = false;
                tdResult.Error = baseObject as TdApi.Error;
            }
            else
            {
                tdResult.Successful = true;
                tdResult.Result = baseObject as TdApi.Update;
            }
            return tdResult;
        }
    }
}
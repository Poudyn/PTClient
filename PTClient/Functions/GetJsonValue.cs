using System.Threading.Tasks;
using TdApi = Telegram.Td.Api;

namespace PTClient
{
    public static partial class Functions
    {
        public static async Task<TdResult<TdApi.JsonValue>> GetJsonValueAsync(this TdClient tdClient, TdApi.GetJsonValue getJsonValue)
        {
            TdResult<TdApi.JsonValue> tdResult = new TdResult<TdApi.JsonValue>();
            TdApi.BaseObject baseObject = await tdClient.ExecuteAsync(getJsonValue);
            if (baseObject is TdApi.Error)
            {
                tdResult.Successful = false;
                tdResult.Error = baseObject as TdApi.Error;
            }
            else
            {
                tdResult.Successful = true;
                tdResult.Result = baseObject as TdApi.JsonValue;
            }
            return tdResult;
        }
    }
}
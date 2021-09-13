using System.Threading.Tasks;
using TdApi = Telegram.Td.Api;

namespace PTClient
{
    public static partial class Functions
    {
        public static async Task<TdResult<TdApi.FoundMessages>> SearchSecretMessagesAsync(this TdClient tdClient, TdApi.SearchSecretMessages searchSecretMessages)
        {
            TdResult<TdApi.FoundMessages> tdResult = new TdResult<TdApi.FoundMessages>();
            TdApi.BaseObject baseObject = await tdClient.ExecuteAsync(searchSecretMessages);
            if (baseObject is TdApi.Error)
            {
                tdResult.Successful = false;
                tdResult.Error = baseObject as TdApi.Error;
            }
            else
            {
                tdResult.Successful = true;
                tdResult.Result = baseObject as TdApi.FoundMessages;
            }
            return tdResult;
        }
    }
}
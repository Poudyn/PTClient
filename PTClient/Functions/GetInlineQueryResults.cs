using System.Threading.Tasks;
using TdApi = Telegram.Td.Api;

namespace PTClient
{
    public static partial class Functions
    {
        public static async Task<TdResult<TdApi.InlineQueryResults>> GetInlineQueryResultsAsync(this TdClient tdClient, TdApi.GetInlineQueryResults getInlineQueryResults)
        {
            TdResult<TdApi.InlineQueryResults> tdResult = new TdResult<TdApi.InlineQueryResults>();
            TdApi.BaseObject baseObject = await tdClient.ExecuteAsync(getInlineQueryResults);
            if (baseObject is TdApi.Error)
            {
                tdResult.Successful = false;
                tdResult.Error = baseObject as TdApi.Error;
            }
            else
            {
                tdResult.Successful = true;
                tdResult.Result = baseObject as TdApi.InlineQueryResults;
            }
            return tdResult;
        }
    }
}
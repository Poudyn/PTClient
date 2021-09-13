using System.Threading.Tasks;
using TdApi = Telegram.Td.Api;

namespace PTClient
{
    public static partial class Functions
    {
        public static async Task<TdResult<TdApi.RecommendedChatFilters>> GetRecommendedChatFiltersAsync(this TdClient tdClient, TdApi.GetRecommendedChatFilters getRecommendedChatFilters)
        {
            TdResult<TdApi.RecommendedChatFilters> tdResult = new TdResult<TdApi.RecommendedChatFilters>();
            TdApi.BaseObject baseObject = await tdClient.ExecuteAsync(getRecommendedChatFilters);
            if (baseObject is TdApi.Error)
            {
                tdResult.Successful = false;
                tdResult.Error = baseObject as TdApi.Error;
            }
            else
            {
                tdResult.Successful = true;
                tdResult.Result = baseObject as TdApi.RecommendedChatFilters;
            }
            return tdResult;
        }
    }
}
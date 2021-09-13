using System.Threading.Tasks;
using TdApi = Telegram.Td.Api;

namespace PTClient
{
    public static partial class Functions
    {
        public static async Task<TdResult<TdApi.StatisticalGraph>> GetStatisticalGraphAsync(this TdClient tdClient, TdApi.GetStatisticalGraph getStatisticalGraph)
        {
            TdResult<TdApi.StatisticalGraph> tdResult = new TdResult<TdApi.StatisticalGraph>();
            TdApi.BaseObject baseObject = await tdClient.ExecuteAsync(getStatisticalGraph);
            if (baseObject is TdApi.Error)
            {
                tdResult.Successful = false;
                tdResult.Error = baseObject as TdApi.Error;
            }
            else
            {
                tdResult.Successful = true;
                tdResult.Result = baseObject as TdApi.StatisticalGraph;
            }
            return tdResult;
        }
    }
}
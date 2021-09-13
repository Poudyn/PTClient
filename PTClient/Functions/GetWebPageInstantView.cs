using System.Threading.Tasks;
using TdApi = Telegram.Td.Api;

namespace PTClient
{
    public static partial class Functions
    {
        public static async Task<TdResult<TdApi.WebPageInstantView>> GetWebPageInstantViewAsync(this TdClient tdClient, TdApi.GetWebPageInstantView getWebPageInstantView)
        {
            TdResult<TdApi.WebPageInstantView> tdResult = new TdResult<TdApi.WebPageInstantView>();
            TdApi.BaseObject baseObject = await tdClient.ExecuteAsync(getWebPageInstantView);
            if (baseObject is TdApi.Error)
            {
                tdResult.Successful = false;
                tdResult.Error = baseObject as TdApi.Error;
            }
            else
            {
                tdResult.Successful = true;
                tdResult.Result = baseObject as TdApi.WebPageInstantView;
            }
            return tdResult;
        }
    }
}
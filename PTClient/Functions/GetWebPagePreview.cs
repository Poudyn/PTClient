using System.Threading.Tasks;
using TdApi = Telegram.Td.Api;

namespace PTClient
{
    public static partial class Functions
    {
        public static async Task<TdResult<TdApi.WebPage>> GetWebPagePreviewAsync(this TdClient tdClient, TdApi.GetWebPagePreview getWebPagePreview)
        {
            TdResult<TdApi.WebPage> tdResult = new TdResult<TdApi.WebPage>();
            TdApi.BaseObject baseObject = await tdClient.ExecuteAsync(getWebPagePreview);
            if (baseObject is TdApi.Error)
            {
                tdResult.Successful = false;
                tdResult.Error = baseObject as TdApi.Error;
            }
            else
            {
                tdResult.Successful = true;
                tdResult.Result = baseObject as TdApi.WebPage;
            }
            return tdResult;
        }
    }
}
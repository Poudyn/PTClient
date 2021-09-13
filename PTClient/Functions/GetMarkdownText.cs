using System.Threading.Tasks;
using TdApi = Telegram.Td.Api;

namespace PTClient
{
    public static partial class Functions
    {
        public static async Task<TdResult<TdApi.FormattedText>> GetMarkdownTextAsync(this TdClient tdClient, TdApi.GetMarkdownText getMarkdownText)
        {
            TdResult<TdApi.FormattedText> tdResult = new TdResult<TdApi.FormattedText>();
            TdApi.BaseObject baseObject = await tdClient.ExecuteAsync(getMarkdownText);
            if (baseObject is TdApi.Error)
            {
                tdResult.Successful = false;
                tdResult.Error = baseObject as TdApi.Error;
            }
            else
            {
                tdResult.Successful = true;
                tdResult.Result = baseObject as TdApi.FormattedText;
            }
            return tdResult;
        }
    }
}
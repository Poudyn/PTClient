using System.Threading.Tasks;
using TdApi = Telegram.Td.Api;

namespace PTClient
{
    public static partial class Functions
    {
        public static async Task<TdResult<TdApi.MessageLink>> GetMessageLinkAsync(this TdClient tdClient, TdApi.GetMessageLink getMessageLink)
        {
            TdResult<TdApi.MessageLink> tdResult = new TdResult<TdApi.MessageLink>();
            TdApi.BaseObject baseObject = await tdClient.ExecuteAsync(getMessageLink);
            if (baseObject is TdApi.Error)
            {
                tdResult.Successful = false;
                tdResult.Error = baseObject as TdApi.Error;
            }
            else
            {
                tdResult.Successful = true;
                tdResult.Result = baseObject as TdApi.MessageLink;
            }
            return tdResult;
        }
    }
}
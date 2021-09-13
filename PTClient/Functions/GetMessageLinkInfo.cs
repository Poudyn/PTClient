using System.Threading.Tasks;
using TdApi = Telegram.Td.Api;

namespace PTClient
{
    public static partial class Functions
    {
        public static async Task<TdResult<TdApi.MessageLinkInfo>> GetMessageLinkInfoAsync(this TdClient tdClient, TdApi.GetMessageLinkInfo getMessageLinkInfo)
        {
            TdResult<TdApi.MessageLinkInfo> tdResult = new TdResult<TdApi.MessageLinkInfo>();
            TdApi.BaseObject baseObject = await tdClient.ExecuteAsync(getMessageLinkInfo);
            if (baseObject is TdApi.Error)
            {
                tdResult.Successful = false;
                tdResult.Error = baseObject as TdApi.Error;
            }
            else
            {
                tdResult.Successful = true;
                tdResult.Result = baseObject as TdApi.MessageLinkInfo;
            }
            return tdResult;
        }
    }
}
using System.Threading.Tasks;
using TdApi = Telegram.Td.Api;

namespace PTClient
{
    public static partial class Functions
    {
        public static async Task<TdResult<TdApi.ChatInviteLinkInfo>> CheckChatInviteLinkAsync(this TdClient tdClient, TdApi.CheckChatInviteLink checkChatInviteLink)
        {
            TdResult<TdApi.ChatInviteLinkInfo> tdResult = new TdResult<TdApi.ChatInviteLinkInfo>();
            TdApi.BaseObject baseObject = await tdClient.ExecuteAsync(checkChatInviteLink);
            if (baseObject is TdApi.Error)
            {
                tdResult.Successful = false;
                tdResult.Error = baseObject as TdApi.Error;
            }
            else
            {
                tdResult.Successful = true;
                tdResult.Result = baseObject as TdApi.ChatInviteLinkInfo;
            }
            return tdResult;
        }
    }
}
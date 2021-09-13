using System.Threading.Tasks;
using TdApi = Telegram.Td.Api;

namespace PTClient
{
    public static partial class Functions
    {
        public static async Task<TdResult<TdApi.ChatInviteLink>> GenerateChatInviteLinkAsync(this TdClient tdClient, TdApi.GenerateChatInviteLink generateChatInviteLink)
        {
            TdResult<TdApi.ChatInviteLink> tdResult = new TdResult<TdApi.ChatInviteLink>();
            TdApi.BaseObject baseObject = await tdClient.ExecuteAsync(generateChatInviteLink);
            if (baseObject is TdApi.Error)
            {
                tdResult.Successful = false;
                tdResult.Error = baseObject as TdApi.Error;
            }
            else
            {
                tdResult.Successful = true;
                tdResult.Result = baseObject as TdApi.ChatInviteLink;
            }
            return tdResult;
        }
    }
}
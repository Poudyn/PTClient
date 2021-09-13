using System.Threading.Tasks;
using TdApi = Telegram.Td.Api;

namespace PTClient
{
    public static partial class Functions
    {
        public static async Task<TdResult<TdApi.ChatMember>> GetChatMemberAsync(this TdClient tdClient, TdApi.GetChatMember getChatMember)
        {
            TdResult<TdApi.ChatMember> tdResult = new TdResult<TdApi.ChatMember>();
            TdApi.BaseObject baseObject = await tdClient.ExecuteAsync(getChatMember);
            if (baseObject is TdApi.Error)
            {
                tdResult.Successful = false;
                tdResult.Error = baseObject as TdApi.Error;
            }
            else
            {
                tdResult.Successful = true;
                tdResult.Result = baseObject as TdApi.ChatMember;
            }
            return tdResult;
        }
    }
}
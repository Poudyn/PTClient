using System.Threading.Tasks;
using TdApi = Telegram.Td.Api;

namespace PTClient
{
    public static partial class Functions
    {
        public static async Task<TdResult<TdApi.ChatMembers>> GetSupergroupMembersAsync(this TdClient tdClient, TdApi.GetSupergroupMembers getSupergroupMembers)
        {
            TdResult<TdApi.ChatMembers> tdResult = new TdResult<TdApi.ChatMembers>();
            TdApi.BaseObject baseObject = await tdClient.ExecuteAsync(getSupergroupMembers);
            if (baseObject is TdApi.Error)
            {
                tdResult.Successful = false;
                tdResult.Error = baseObject as TdApi.Error;
            }
            else
            {
                tdResult.Successful = true;
                tdResult.Result = baseObject as TdApi.ChatMembers;
            }
            return tdResult;
        }
    }
}
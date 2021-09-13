using System.Threading.Tasks;
using TdApi = Telegram.Td.Api;

namespace PTClient
{
    public static partial class Functions
    {
        public static async Task<TdResult<TdApi.Supergroup>> GetSupergroupAsync(this TdClient tdClient, TdApi.GetSupergroup getSupergroup)
        {
            TdResult<TdApi.Supergroup> tdResult = new TdResult<TdApi.Supergroup>();
            TdApi.BaseObject baseObject = await tdClient.ExecuteAsync(getSupergroup);
            if (baseObject is TdApi.Error)
            {
                tdResult.Successful = false;
                tdResult.Error = baseObject as TdApi.Error;
            }
            else
            {
                tdResult.Successful = true;
                tdResult.Result = baseObject as TdApi.Supergroup;
            }
            return tdResult;
        }
    }
}
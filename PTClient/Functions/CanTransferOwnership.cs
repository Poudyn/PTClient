using System.Threading.Tasks;
using TdApi = Telegram.Td.Api;

namespace PTClient
{
    public static partial class Functions
    {
        public static async Task<TdResult<TdApi.CanTransferOwnershipResult>> CanTransferOwnershipAsync(this TdClient tdClient, TdApi.CanTransferOwnership canTransferOwnership)
        {
            TdResult<TdApi.CanTransferOwnershipResult> tdResult = new TdResult<TdApi.CanTransferOwnershipResult>();
            TdApi.BaseObject baseObject = await tdClient.ExecuteAsync(canTransferOwnership);
            if (baseObject is TdApi.Error)
            {
                tdResult.Successful = false;
                tdResult.Error = baseObject as TdApi.Error;
            }
            else
            {
                tdResult.Successful = true;
                tdResult.Result = baseObject as TdApi.CanTransferOwnershipResult;
            }
            return tdResult;
        }
    }
}
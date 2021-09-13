using System.Threading.Tasks;
using TdApi = Telegram.Td.Api;

namespace PTClient
{
    public static partial class Functions
    {
        public static async Task<TdResult<TdApi.ConnectedWebsites>> GetConnectedWebsitesAsync(this TdClient tdClient, TdApi.GetConnectedWebsites getConnectedWebsites)
        {
            TdResult<TdApi.ConnectedWebsites> tdResult = new TdResult<TdApi.ConnectedWebsites>();
            TdApi.BaseObject baseObject = await tdClient.ExecuteAsync(getConnectedWebsites);
            if (baseObject is TdApi.Error)
            {
                tdResult.Successful = false;
                tdResult.Error = baseObject as TdApi.Error;
            }
            else
            {
                tdResult.Successful = true;
                tdResult.Result = baseObject as TdApi.ConnectedWebsites;
            }
            return tdResult;
        }
    }
}
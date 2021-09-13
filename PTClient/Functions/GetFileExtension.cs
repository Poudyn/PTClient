using System.Threading.Tasks;
using TdApi = Telegram.Td.Api;

namespace PTClient
{
    public static partial class Functions
    {
        public static async Task<TdResult<TdApi.Text>> GetFileExtensionAsync(this TdClient tdClient, TdApi.GetFileExtension getFileExtension)
        {
            TdResult<TdApi.Text> tdResult = new TdResult<TdApi.Text>();
            TdApi.BaseObject baseObject = await tdClient.ExecuteAsync(getFileExtension);
            if (baseObject is TdApi.Error)
            {
                tdResult.Successful = false;
                tdResult.Error = baseObject as TdApi.Error;
            }
            else
            {
                tdResult.Successful = true;
                tdResult.Result = baseObject as TdApi.Text;
            }
            return tdResult;
        }
    }
}
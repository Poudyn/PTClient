using System.Threading.Tasks;
using TdApi = Telegram.Td.Api;

namespace PTClient
{
    public static partial class Functions
    {
        public static async Task<TdResult<TdApi.FilePart>> ReadFilePartAsync(this TdClient tdClient, TdApi.ReadFilePart readFilePart)
        {
            TdResult<TdApi.FilePart> tdResult = new TdResult<TdApi.FilePart>();
            TdApi.BaseObject baseObject = await tdClient.ExecuteAsync(readFilePart);
            if (baseObject is TdApi.Error)
            {
                tdResult.Successful = false;
                tdResult.Error = baseObject as TdApi.Error;
            }
            else
            {
                tdResult.Successful = true;
                tdResult.Result = baseObject as TdApi.FilePart;
            }
            return tdResult;
        }
    }
}
using System.Threading.Tasks;
using TdApi = Telegram.Td.Api;

namespace PTClient
{
    public static partial class Functions
    {
        public static async Task<TdResult<TdApi.OptionValue>> GetOptionAsync(this TdClient tdClient, TdApi.GetOption getOption)
        {
            TdResult<TdApi.OptionValue> tdResult = new TdResult<TdApi.OptionValue>();
            TdApi.BaseObject baseObject = await tdClient.ExecuteAsync(getOption);
            if (baseObject is TdApi.Error)
            {
                tdResult.Successful = false;
                tdResult.Error = baseObject as TdApi.Error;
            }
            else
            {
                tdResult.Successful = true;
                tdResult.Result = baseObject as TdApi.OptionValue;
            }
            return tdResult;
        }
    }
}
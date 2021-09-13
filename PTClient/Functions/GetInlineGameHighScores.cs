using System.Threading.Tasks;
using TdApi = Telegram.Td.Api;

namespace PTClient
{
    public static partial class Functions
    {
        public static async Task<TdResult<TdApi.GameHighScores>> GetInlineGameHighScoresAsync(this TdClient tdClient, TdApi.GetInlineGameHighScores getInlineGameHighScores)
        {
            TdResult<TdApi.GameHighScores> tdResult = new TdResult<TdApi.GameHighScores>();
            TdApi.BaseObject baseObject = await tdClient.ExecuteAsync(getInlineGameHighScores);
            if (baseObject is TdApi.Error)
            {
                tdResult.Successful = false;
                tdResult.Error = baseObject as TdApi.Error;
            }
            else
            {
                tdResult.Successful = true;
                tdResult.Result = baseObject as TdApi.GameHighScores;
            }
            return tdResult;
        }
    }
}
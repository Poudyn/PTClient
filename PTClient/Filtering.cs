using System.Collections.Generic;
using System.Linq;
using Telegram.Td.Api;

namespace PTClient
{
    internal static class Filtering
    {
        internal static List<IFilter> Filters;
        internal static List<IFilter> GetFilters(BaseObject baseObject)
        {
            return Filters.Where(x => x.IsMatch(baseObject)).ToList();
        }
        internal static void RemoveUselessFilters(this List<IFilter> filters)
        {
            List<ITransportUpdate> transports = filters.OfType<ITransportUpdate>().ToList();
            if (transports.Exists(x => !x.IsBase && !x.IsUpdate))
            {
                filters.RemoveAll(x => x is ITransportUpdate transport && (transport.IsBase || transport.IsUpdate));
            }
            else if (transports.Exists(x => x.IsUpdate))
            {
                filters.RemoveAll(x => x is ITransportUpdate transport && transport.IsBase);
            }
        }
    }
}

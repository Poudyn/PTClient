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
        internal static bool IsTypeFilteringOnly(this List<IFilter> filters)
        {
            List<ITransportUpdate> updateTransporters = filters.OfType<ITransportUpdate>().ToList();
            return updateTransporters.Count == 1 && updateTransporters.First().OnlyTypeFiltering;
        }
        internal static void RemoveUpdateOnly(this List<IFilter> filters)
        {
            filters.Remove(filters.Find(x => x is ITransportUpdate transportUpdate && transportUpdate.OnlyTypeFiltering));
        }
    }
}

using System.Collections.Generic;
using BitTrade.BLL.Configuration;

namespace BitTrade.BLL.Extensions
{
    public static class AutoMapperExtensions
    {
        
        public static T MapTo<T>(this object ob)
        {
            return AutoMapperConfiguration.Instance.Map<T>(ob);
        }

        public static IEnumerable<T> MapTo<T>(this IEnumerable<object> collection)
        {
            foreach (var ob in collection)
            {
                yield return AutoMapperConfiguration.Instance.Map<T>(ob);
            }
        }

    }
}

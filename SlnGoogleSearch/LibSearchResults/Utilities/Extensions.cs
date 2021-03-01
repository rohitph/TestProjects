using System;
using System.Collections.Generic;
using System.Text;

namespace LibSearchResults.Utilities
{
    public static class Extensions
    {
        public static IEnumerable<int> IndexesWhere<T>(this IEnumerable<T> p_Source, Func<T, bool> p_Predicate)
        {
            int index = 0;
            foreach (T element in p_Source)
            {
                if (p_Predicate(element))
                {
                    yield return index+1;
                }
                index++;
            }
        }
    }
}

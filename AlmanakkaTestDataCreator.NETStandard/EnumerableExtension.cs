using System;
using System.Collections.Generic;

namespace AlmanakkaTestDataCreator.NETStandard
{
    public static class EnumerableExtension
    {
        public static IEnumerable<T> Do<T>(this IEnumerable<T> source, Action<T> action)
        {
            foreach(var element in source)
            {
                action(element);
                yield return element;
            }
        }
    }
}

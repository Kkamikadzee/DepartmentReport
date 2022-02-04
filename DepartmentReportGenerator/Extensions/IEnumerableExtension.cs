using System.Collections.Generic;

namespace DepartmentReportGenerator.Extensions
{
    public static class IEnumerableExtension
    {
        public static IEnumerable<(TFirst, TSecond)> Zip<TFirst, TSecond>(
            this IEnumerable<TFirst> first, IEnumerable<TSecond> second)
        {
            IEnumerator<TFirst> firtsEnumerator = first.GetEnumerator();
            IEnumerator<TSecond> secondEnumerator = second.GetEnumerator();

            while (firtsEnumerator.MoveNext() && secondEnumerator.MoveNext())
            {
                yield return (firtsEnumerator.Current, secondEnumerator.Current);
            }
            
            firtsEnumerator.Dispose();
            secondEnumerator.Dispose();
        }
    }
}
using System.Collections.Generic;

namespace ReportGenerator.Extension
{
    //TODO: Удалить, если по итогу не буду использовать
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
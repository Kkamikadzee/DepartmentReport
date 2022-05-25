using System.Collections.Generic;

namespace ReportGenerator.Extension
{
    public static class IReadOnlyListExtension
    {
        public static int IndexOf<T>(this IReadOnlyList<T> collection, T elementToFind)
        {
            var i = 0;
            foreach (T element in collection)
            {
                if (element.Equals(elementToFind))
                {
                    return i;
                }

                i++;
            }

            return -1;
        }
    }
}
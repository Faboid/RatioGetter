using System;
using System.Collections.Generic;
using System.Text;

namespace RatioGetterLibrary {
    public static class GenExtensions {

        public static void ForEach<T>(this IEnumerable<T> source, Action<T> action) {
            foreach(T item in source) {
                action?.Invoke(item);
            }
        }

    }
}

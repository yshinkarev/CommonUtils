using System;
using System.Collections.Generic;
using System.Linq;

namespace Common
{
    public static class U2
    {
        public static bool IsEmpty<T>(IEnumerable<T> data)
        {
            return data == null || !data.Any();
        }

        public static bool IsNotEmpty<T>(IEnumerable<T> data)
        {
            return !IsEmpty(data);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EydapTickets.Helpers
{
    public static class GenericExtensions
    {
        public static TResult GetSafeValue<T, TResult>(this T @this, Func<T, TResult> getValue, TResult fallbackValue = default(TResult))
        {
            if (@this == null)
            {
                return fallbackValue;
            }

            try
            {
                TResult value = getValue(@this);
                return value != null ? value : fallbackValue;
            }
            catch
            {
                return fallbackValue;
            }
        }
    }
}

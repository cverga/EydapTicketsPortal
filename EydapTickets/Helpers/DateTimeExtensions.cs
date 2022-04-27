using System;

namespace EydapTickets.Helpers
{
    public static class DateTimeExtensions
    {
        public static DateTime StartOfDay(this DateTime @this)
        {
            return @this.Date;
        }

        public static DateTime EndOfDay(this DateTime @this)
        {
            return @this.Date.AddDays(1).AddTicks(-1);
        }
    }
}
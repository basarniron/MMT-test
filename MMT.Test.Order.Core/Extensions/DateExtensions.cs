using System;

namespace MMT.Test.Order.Core.Extensions
{
    public static class DateExtensions
    {
        public static string ToFormattedString(this DateTime date)
        {
            return date.ToString(Constants.DateConstants.OrderDateFormat);
        }
    }
}

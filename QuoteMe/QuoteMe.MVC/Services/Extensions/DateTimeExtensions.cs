using System;

namespace QuoteMe.MVC.Services.Extensions
{
    public static class DateTimeExtensions
    {
        /// <summary>
        /// Find the last date of the current month
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static DateTime GetLastDateOfCurrentMonth(this DateTime dateTime)
        {
            var daysInMonth = DateTime.DaysInMonth(dateTime.Year, dateTime.Month);
            return new DateTime(dateTime.Year, dateTime.Month, daysInMonth);
        }

        /// <summary>
        /// Find the next occurrence of a specific day after the current date
        /// </summary>
        /// <param name="date"></param>
        /// <param name="dayOfWeek"></param>
        /// <returns></returns>
        public static DateTime GetNextOccurenceOfDay(this DateTime date, DayOfWeek dayOfWeek)
        {
            var daysDifference = dayOfWeek - date.DayOfWeek;
            // Offset if we've already passed the required day in the current week.
            if (daysDifference <= 0)
                daysDifference += 7;

            return date.AddDays(daysDifference);
        }
    }
}
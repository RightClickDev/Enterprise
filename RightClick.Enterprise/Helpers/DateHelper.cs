//------------------------------------------------------------------------------------------------- 
// <copyright file="DateHelper.cs" company="Right Click Development">
//  Copyright (c) Right Click Development. All rights reserved.
// </copyright>
//-------------------------------------------------------------------------------------------------

namespace RightClick.Enterprise.Helpers
{
    using System;
    using System.Globalization;
    using System.Threading;

    /// <summary>
    /// Date Helper utility class
    /// </summary>
    /// <remarks>
    /// The methods in here must be able to work across cultures so fixed formats
    /// such as MM/DD/yyyy should never be used unless required internally (in which
    /// case the method name should indicate this).
    /// </remarks>
    public static class DateHelper
    {
        /// <summary>
        /// Format a string representation of a date based on culture and default date
        /// </summary>
        /// <param name="date">The date time format.</param>
        /// <returns>
        /// Date formatted as string based on default format
        /// </returns>
        public static string GetDateAsFormattedString(string date)
        {
            try
            {
                DateTime newdt = Convert.ToDateTime(date);

                return GetDateAsFormattedString(newdt);
            }
            catch
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Format a DateTime object based on default format
        /// </summary>
        /// <param name="dt">The date time format.</param>
        /// <returns>
        /// Date formatted as string based on default format
        /// </returns>
        public static string GetDateAsFormattedString(DateTime dt)
        {
            try
            {
                return dt.ToString(Constants.DefaultDateFormat);
            }
            catch
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Format a string representation of a date based on default format
        /// </summary>
        /// <param name="dt">The date time format.</param>
        /// <returns>
        /// Date formatted as string based on default format
        /// </returns>
        public static string GetDateAndTimeAsFormattedString(string dt)
        {
            try
            {
                DateTime newdt = Convert.ToDateTime(dt);
                return GetDateAndTimeAsFormattedString(newdt);
            }
            catch
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Format a date based on default format
        /// </summary>
        /// <param name="dt">The date time format.</param>
        /// <returns>
        /// Date formatted as string based on default format
        /// </returns>
        public static string GetDateAndTimeAsFormattedString(DateTime dt)
        {
            return dt.ToString(Constants.DefaultDateTimeFormat);
        }

        /// <summary>
        /// Gets the time as formatted string.
        /// </summary>
        /// <param name="dateTime">The date time.</param>
        /// <returns>Returns a Time as formatted string</returns>
        public static string GetTimeAsFormattedString(DateTime dateTime)
        {
            return dateTime.ToString(Constants.DefaultTimeFormat);
        }

        /// <summary>
        /// Gets the day month name year formatted string.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>
        /// Returns Formatted String (01 January 2014)
        /// </returns>
        public static string GetDayMonthNameYearFormattedString(string value)
        {
            DateTime dateTime = DateTime.Parse(value);
            return string.Concat(dateTime.Day, " ", dateTime.ToString("MMMM"), " ", dateTime.Year);
        }

        /// <summary>
        /// Gets the day month name year formatted string.
        /// </summary>
        /// <param name="dateTime">The date time.</param>
        /// <returns>Returns Formatted String (01 January 2014)</returns>
        public static string GetDayMonthNameYearFormattedString(DateTime dateTime)
        {
            return string.Concat(dateTime.Day, " ", dateTime.ToString("MMMM"), " ", dateTime.Year);
        }

        /// <summary>
        /// To the name of the month.
        /// </summary>
        /// <param name="dateTime">The date time.</param>
        /// <returns>Returns Month Name</returns>
        public static string ToMonthName(DateTime dateTime)
        {
            return CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(dateTime.Month);
        }

        /// <summary>
        /// To the short name of the month.
        /// </summary>
        /// <param name="dateTime">The date time.</param>
        /// <returns>Returns Short Month Name</returns>
        public static string ToShortMonthName(DateTime dateTime)
        {
            return CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(dateTime.Month);
        }

        /// <summary>
        /// Adds the working days.
        /// </summary>
        /// <param name="from">From Date.</param>
        /// <param name="days">The days to add / remove.</param>
        /// <returns>Returns Date</returns>
        public static DateTime AddWorkingDays(DateTime from, int days)
        {
            // determine if we are increasing or decreasing the days
            int direction = 1;
            if (days < 0)
            {
                direction = -1;
            }

            // move ahead the day of week
            int weekday = days % 5;
            while (weekday != 0)
            {
                from = from.AddDays(direction);
                if (from.DayOfWeek != DayOfWeek.Saturday && from.DayOfWeek != DayOfWeek.Sunday)
                {
                    weekday -= direction;
                }
            }

            // move ahead the number of weeks
            int dayweek = (days / 5) * 7;
            from = from.AddDays(dayweek);

            return from;
        }
    }
}

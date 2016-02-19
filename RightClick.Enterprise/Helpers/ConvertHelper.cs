//------------------------------------------------------------------------------------------------- 
// <copyright file="ConvertHelper.cs" company="Right Click Development">
//  Copyright (c) Right Click Development. All rights reserved.
// </copyright>
//-------------------------------------------------------------------------------------------------

namespace RightClick.Enterprise.Helpers
{
    using System;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Convert Helper
    /// </summary>
    public class ConvertHelper
    {
        /// <summary>
        /// Converts the bytes to megabytes.
        /// </summary>
        /// <param name="bytes">The bytes.</param>
        /// <returns>Convert Bytes To Megabytes</returns>
        public static double ConvertBytesToMegabytes(int bytes)
        {
            return (bytes / 1024f) / 1024f;
        }

        /// <summary>
        /// Converts the bytes to kilobytes.
        /// </summary>
        /// <param name="bytes">The bytes.</param>
        /// <returns>Convert Bytes To Kilobytes</returns>
        public static double ConvertBytesToKilobytes(int bytes)
        {
            return bytes / 1024f;
        }

        /// <summary>
        /// Converts the bytes to kilobytes as string.
        /// </summary>
        /// <param name="bytes">The bytes.</param>
        /// <returns>Convert Bytes To Kilobytes As String</returns>
        public static string ConvertBytesToKilobytesAsString(int bytes)
        {
            return string.Format("{0:N0}", bytes / 1024f);
        }

        /// <summary>
        /// Gets a from the string provided
        /// </summary>
        /// <param name="value">the as a string</param>
        /// <returns>If we could match it, or .Empty if not</returns>
        public static Guid ConvertToGuid(string value)
        {
            Guid guid = Guid.Empty;

            if (!string.IsNullOrEmpty(value))
            {
                if (Regex.IsMatch(value, Constants.GuidValidationExpression))
                {
                    guid = new Guid(value);
                }
            }

            return guid;
        }

        /// <summary>
        /// Gets an from the sting provided
        /// </summary>
        /// <param name="value">the as a string</param>
        /// <returns>a valid integer, or zero if it could not parse</returns>
        public static int ConvertToInt(string value)
        {
            int intValue = 0;

            int.TryParse(value, out intValue);

            return intValue;
        }

        /// <summary>
        /// Converts to boolean from numeral string.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>the value of the, or false if could not parse</returns>
        public static bool ConvertToBooleanFromNumeralString(string value)
        {
            bool boolValue = false;

            if (!string.IsNullOrEmpty(value))
            {
                if (value == "1")
                {
                    boolValue = true;
                }
            }

            return boolValue;
        }

        /// <summary>
        /// Gets a from the string provided
        /// </summary>
        /// <param name="value">the as a string</param>
        /// <returns>
        /// the value of the, or false if could not parse
        /// </returns>
        public static bool ConvertToBoolean(string value)
        {
            bool boolValue = false;

            bool.TryParse(value, out boolValue);

            return boolValue;
        }

        /// <summary>
        /// Gets the string from
        /// </summary>
        /// <param name="value">The value to covert.</param>
        /// <returns>Convert to String</returns>
        public static string ConvertToString(object value)
        {
            return value != null ? Convert.ToString(value) : null;
        }

        /// <summary>
        /// Converts the minutes to time.
        /// </summary>
        /// <param name="minutes">The minutes.</param>
        /// <returns>Time as string</returns>
        public static string ConvertMinutesToTime(int minutes)
        {
            string output = "0:00";

            if (minutes > 0)
            {
                int hours = (int)decimal.Floor(minutes / 60);
                int mins = minutes % 60;
                output = string.Format("{0}:{1}", hours.ToString(), mins.ToString("00"));
            }
            else if (minutes < 0)
            {
                int hours = (int)decimal.Floor(minutes / 60);
                int mins = minutes % 60;
                output = string.Format("{0}:{1}", hours.ToString(), (mins * -1).ToString("00"));
            }

            return output;
        }
    }
}

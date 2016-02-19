//------------------------------------------------------------------------------------------------- 
// <copyright file="ConvertHelper.cs" company="Right Click Development">
//  Copyright (c) Right Click Development. All rights reserved.
// </copyright>
//-------------------------------------------------------------------------------------------------

namespace RightClick.Enterprise.Helpers
{
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
    }
}

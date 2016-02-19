//------------------------------------------------------------------------------------------------- 
// <copyright file="Constants.cs" company="Right Click Development">
//  Copyright (c) Right Click Development. All rights reserved.
// </copyright>
//-------------------------------------------------------------------------------------------------

namespace RightClick.Enterprise
{
    /// <summary>
    /// Constants Class
    /// </summary>
    public static class Constants
    {
        #region Date Constants

        // ====================================================================== 
        // Default c# specifiers (values shown are for US culture)
        // ======================================================================
        // d  MM/dd/yyyy  
        // D  dddd, MMMM dd, yyyy  
        // f  dddd, MMMM dd, yyyy HH:mm  
        // F  dddd, MMMM dd, yyyy HH:mm:ss  
        // g  MM/dd/yyyy HH:mm  
        // G  MM/dd/yyyy HH:mm:ss  
        // m, M  MMMM dd  
        // r, R  Ddd, dd MMM yyyy HH':'mm':'ss 'GMT'  
        // s  yyyy-MM-dd HH:mm:ss  
        // S  yyyy-MM-dd HH:mm:ss GMT  
        // t  HH:mm  
        // T  HH:mm:ss  
        // u  yyyy-MM-dd HH:mm:ss  
        // U  dddd, MMMM dd, yyyy HH:mm:ss  
        // y, Y  MMMM, yyyy  

        /// <summary>
        /// the default date format to use
        /// </summary>
        public const string DefaultDateFormat = "d";

        /// <summary>
        /// the default date time format to use
        /// </summary>
        public const string DefaultDateTimeFormat = "f";

        /// <summary>
        /// The default time format
        /// </summary>
        public const string DefaultTimeFormat = "HH:mm";

        #endregion // Date Constants

        #region String Constants

        /// <summary>
        /// The Comma constant
        /// </summary>
        public const char Comma = ',';

        /// <summary>
        /// The default merge delimiter
        /// </summary>
        public const string DefaultMergeDelimter = ", ";

        /// <summary>
        /// The separated string format
        /// </summary>
        public const string SeparatedStringFormat = "{0}{1}";

        /// <summary>
        /// The substring format
        /// </summary>
        public const string SubstringFormat = "{0}...";

        /// <summary>
        /// The comma separated number format
        /// </summary>
        public const string CommaSeparatedNumberFormat = "{0:#,###}";

        /// <summary>
        /// Validation regular expression
        /// </summary>
        public const string GuidValidationExpression = @"^(\{){0,1}[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}$";

        #endregion // String Constants

        #region Email Constants

        /// <summary>
        /// the html type
        /// </summary>
        public const string EmailTypeHtml = "text/html";

        /// <summary>
        /// plain type
        /// </summary>
        public const string EmailTypePlain = "text/plain";

        /// <summary>
        /// send failure message
        /// </summary>
        public const string ErrorSendFailure = "The email could not be sent";

        #endregion // Email Constants
    }
}

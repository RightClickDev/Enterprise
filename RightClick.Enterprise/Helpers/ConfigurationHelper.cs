//------------------------------------------------------------------------------------------------- 
// <copyright file="ConfigurationHelper.cs" company="Right Click Development">
//  Copyright (c) Right Click Development. All rights reserved.
// </copyright>
//-------------------------------------------------------------------------------------------------

namespace RightClick.Enterprise.Helpers
{
    using System;

    /// <summary>
    /// Configuration Helper
    /// </summary>
    public class ConfigurationHelper
    {
        /// <summary>
        /// Get config value from the application config file (usually web.config or app.config).
        /// </summary>
        /// <param name="key">Key name in the config file.</param>
        /// <returns>Value as a string.</returns>
        /// <exception cref="NullReferenceException">Thrown if key does not exist.</exception>
        public static string AppSettingString(string key)
        {
            return System.Configuration.ConfigurationManager.AppSettings[key];
        }

        /// <summary>
        /// Get config value from the application config file (usually web.config or app.config).
        /// </summary>
        /// <param name="key">Key name in the config file.</param>
        /// <param name="defaultValue">Default value of the key.</param>
        /// <returns>
        /// Value as a string. Returns the specified default value if key not found.
        /// </returns>
        public static string AppSettingString(string key, string defaultValue)
        {
            if (System.Configuration.ConfigurationManager.AppSettings[key] != null)
            {
                return System.Configuration.ConfigurationManager.AppSettings[key];
            }
            else
            {
                return defaultValue;
            }
        }

        /// <summary>
        /// Gets a value from the config file as a boolean
        /// </summary>
        /// <param name="key">The key for the config file item.</param>
        /// <returns>Returns a object</returns>
        public static bool AppSettingBoolean(string key)
        {
            return ConvertHelper.ConvertToBoolean(AppSettingString(key));
        }

        /// <summary>
        /// Gets a value from the config file as an
        /// </summary>
        /// <param name="key">The key for the config file item.</param>
        /// <returns>Returns value</returns>
        public static int AppSettingInt(string key)
        {
            return ConvertHelper.ConvertToInt(AppSettingString(key));
        }

        /// <summary>
        /// Apps the setting GUID.
        /// </summary>
        /// <param name="key">The key for the config file item.</param>
        /// <returns>Returns a value</returns>
        public static Guid AppSettingGuid(string key)
        {
            return ConvertHelper.ConvertToGuid(AppSettingString(key));
        }

        /// <summary>
        /// Get connection string value from the connection strings config file (usually connectionStrings.config).
        /// </summary>
        /// <param name="key">Key name in the config file.</param>
        /// <returns>Value as a string.</returns>
        /// <exception cref="NullReferenceException">Thrown if key does not exist.</exception>
        public static string ConnectionString(string key)
        {
            return System.Configuration.ConfigurationManager.ConnectionStrings[key].ConnectionString;
        }

        /// <summary>
        /// Gets the cache time stored in a configuration setting. If the setting is not explicitly set, <paramref name="defaultTime"/> is returned.
        /// </summary>
        /// <param name="key">The key of the setting.</param>
        /// <param name="defaultTime">The default time to use if no setting is specified.</param>
        /// <returns>cache time stored in a configuration setting</returns>
        public static TimeSpan GetCacheTimeSetting(string key, TimeSpan defaultTime)
        {
            string settingValue = AppSettingString(key);

            if (string.IsNullOrEmpty(settingValue))
            {
                return defaultTime;
            }
            else
            {
                return TimeSpan.Parse(settingValue);
            }
        }
    }
}

namespace GuiStracini.Mandae.Utils
{
    using System;

    public static class DateExtensions
    {
        /// <summary>
        ///     Converts a DateTime instance to Unix Timestamp (number of seconds that have elapsed since 
        ///     00:00:00 Coordinated Universal Time (UTC), Thursday, 1 January 1970)
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns>The total seconds</returns>
        public static Int32 ToUnixTimeStamp(this DateTime dateTime)
        {
            return (Int32)dateTime.ToUniversalTime().Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
        }

        /// <summary>
        ///     Converts a Unix Timestamp (number of seconds that have elapsed since 00:00:00 Coordinated 
        ///     Universal Time (UTC), Thursday, 1 January 1970) to a DateTime instance
        /// </summary>
        /// <param name="epochTime">The Unix Timestamp</param>
        /// <returns>A DateTime instance of the epochTime</returns>

        public static DateTime FromUnixTimeStamp(this Int32 epochTime)
        {
            return new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)
                   .AddSeconds(Math.Round((Double)epochTime / 1000))
                   .ToLocalTime();
        }
    }
}

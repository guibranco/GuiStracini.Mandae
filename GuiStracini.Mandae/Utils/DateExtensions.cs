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
        public static int ToUnixTimeStamp(this DateTime dateTime)
        {
            return (int)dateTime.ToUniversalTime().Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
        }

        /// <summary>
        ///     Converts a Unix Timestamp (number of seconds that have elapsed since 00:00:00 Coordinated 
        ///     Universal Time (UTC), Thursday, 1 January 1970) to a DateTime instance
        /// </summary>
        /// <param name="epochTime">The Unix Timestamp</param>
        /// <returns>A DateTime instance of the epochTime</returns>

        public static DateTime FromUnixTimeStamp(this int epochTime)
        {
            return new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)
                   .AddSeconds(Math.Round((double)epochTime / 1000))
                   .ToLocalTime();
        }
    }
}

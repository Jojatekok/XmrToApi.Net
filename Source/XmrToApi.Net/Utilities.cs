using System;
using System.Globalization;

namespace Jojatekok.XmrToAPI
{
    static class Utilities
    {
        public const string ApiUrlHttpsBase = "https://xmr.to/api/v1/xmr2btc/";

        public static readonly CultureInfo InvariantCulture = CultureInfo.InvariantCulture;

        public static DateTime Iso8601TimestampToDateTime(string iso8601Timestamp)
        {
            return DateTime.Parse(iso8601Timestamp, InvariantCulture, DateTimeStyles.AssumeUniversal);
        }
    }
}

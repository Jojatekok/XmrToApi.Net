using System;
using System.Globalization;

namespace Jojatekok.XmrToAPI.Demo
{
    class Program
    {
        private static readonly CultureInfo InvariantCulture = CultureInfo.InvariantCulture;

        static void Main()
        {
            var conversionInfo = XmrToClient.QueryConversionInfo();

            Console.Write(
                "Conversion info:{0}" +
                "   Rate: {1}{0}" +
                "   Minimum amount (BTC): {2}{0}" +
                "   Maximum amount (BTC): {3}{0}",
                Environment.NewLine,
                conversionInfo.Rate.ToString(InvariantCulture),
                conversionInfo.BitcoinAmountMinimum.ToString(InvariantCulture),
                conversionInfo.BitcoinAmountMaximum.ToString(InvariantCulture)
            );

            Console.Read();
        }
    }
}

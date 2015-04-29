using Newtonsoft.Json;

namespace Jojatekok.XmrToAPI
{
    public class ConversionInfo
    {
        [JsonProperty("price")]
        public double Rate { get; private set; }

        [JsonProperty("upper_limit")]
        public double BitcoinAmountMaximum { get; private set; }

        [JsonProperty("lower_limit")]
        public double BitcoinAmountMinimum { get; private set; }
    }
}

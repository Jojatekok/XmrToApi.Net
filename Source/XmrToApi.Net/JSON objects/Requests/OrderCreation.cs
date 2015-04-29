using Newtonsoft.Json;

namespace Jojatekok.XmrToAPI
{
    class OrderCreation
    {
        [JsonProperty("btc_dest_address")]
        public string DestinationBitcoinAddress { get; private set; }

        [JsonProperty("btc_amount")]
        public double DestinationBitcoinAmount { get; private set; }

        public OrderCreation(string destinationBitcoinAddress, double destinationBitcoinAmount)
        {
            DestinationBitcoinAddress = destinationBitcoinAddress;
            DestinationBitcoinAmount = destinationBitcoinAmount;
        }
    }
}

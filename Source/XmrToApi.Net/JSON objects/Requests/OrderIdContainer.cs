using Newtonsoft.Json;

namespace Jojatekok.XmrToAPI
{
    class OrderIdContainer
    {
        [JsonProperty("uuid")]
        public string OrderId { get; private set; }

        public OrderIdContainer(string orderId)
        {
            OrderId = orderId;
        }
    }
}

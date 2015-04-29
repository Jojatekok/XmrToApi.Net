using System.Net;
using System.Threading.Tasks;

namespace Jojatekok.XmrToAPI
{
    public static class XmrToClient
    {
        private static IWebProxy _proxy;

        public static IWebProxy Proxy {
            get { return _proxy; }
            set {
                _proxy = value;
                RestWebClient.HttpClientHandler.UseProxy = value != null;
            }
        }

        public static ConversionInfo QueryConversionInfo()
        {
            return RestWebClient.Get<ConversionInfo>("order_parameter_query");
        }

        public static OrderInfo QueryOrderInfo(string orderId)
        {
            return RestWebClient.Post<OrderInfo>("order_status_query", new OrderIdContainer(orderId));
        }

        public static OrderInfo CreateOrder(string destinationBitcoinAddress, double destinationBitcoinAmount)
        {
            return RestWebClient.Post<OrderInfo>("order_create", new OrderCreation(destinationBitcoinAddress, destinationBitcoinAmount));
        }

        public static Task<ConversionInfo> QueryConversionInfoAsync()
        {
            return Task.Factory.StartNew(() => QueryConversionInfo());
        }

        public static Task<OrderInfo> QueryOrderInfoAsync(string orderId)
        {
            return Task.Factory.StartNew(() => QueryOrderInfo(orderId));
        }

        public static Task<OrderInfo> CreateOrderAsync(string destinationBitcoinAddress, double destinationBitcoinAmount)
        {
            return Task.Factory.StartNew(() => CreateOrder(destinationBitcoinAddress, destinationBitcoinAmount));
        }
    }
}

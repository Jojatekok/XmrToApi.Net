using Newtonsoft.Json;
using System;

namespace Jojatekok.XmrToAPI
{
    public class OrderInfo
    {
        [JsonProperty("uuid")]
        public string Id { get; private set; }

        [JsonProperty("state")]
        private string StatusInternal {
            set {
                switch (value) {
                    case "UNPAID":
                        Status = OrderStatus.Unpaid;
                        break;

                    case "PAID_UNCONFIRMED":
                        Status = OrderStatus.PaidUnconfirmed;
                        break;

                    case "PAID":
                        Status = OrderStatus.PaidConfirmed;
                        break;

                    case "BTC_SENT":
                        Status = OrderStatus.Complete;
                        break;

                    case "TIMED_OUT":
                        Status = OrderStatus.TimedOut;
                        break;

                    case "UNDERPAID":
                        Status = OrderStatus.Underpaid;
                        break;

                    default: // case "TO_BE_CREATED":
                        Status = OrderStatus.ToBeCreated;
                        break;
                }
            }
        }

        public OrderStatus Status { get; private set; }

        [JsonProperty("xmr_price_btc")]
        public double ConversionRate { get; private set; }

        [JsonProperty("btc_amount")]
        public double DestinationBitcoinAmount { get; private set; }

        [JsonProperty("btc_dest_address")]
        public string DestinationBitcoinAddress { get; private set; }

        [JsonProperty("btc_num_confirmations_before_purge")]
        public int DestinationBitcoinConfirmationsRequiredBeforePurge { get; private set; }

        [JsonProperty("btc_num_confirmations")]
        public int DestinationBitcoinConfirmationsDone { get; private set; }

        [JsonProperty("btc_transaction_id")]
        public string DestinationBitcoinTransactionId { get; private set; }

        [JsonProperty("xmr_required_amount")]
        public double PaymentMoneroAmountRequired { get; private set; }

        [JsonProperty("xmr_amount_total")]
        public double PaymentMoneroAmountTotal { get; private set; }

        [JsonProperty("xmr_amount_remaining")]
        public double PaymentMoneroAmountRemaining { get; private set; }

        [JsonProperty("xmr_receiving_address")]
        public string PaymentMoneroAddress { get; private set; }

        [JsonProperty("xmr_required_payment_id")]
        public string PaymentMoneroPaymentId { get; private set; }

        [JsonProperty("xmr_num_confirmations_remaining")]
        public int PaymentMoneroConfirmationsRemaining { get; private set; }

        [JsonProperty("created_at")]
        private string TimeCreationInternal {
            set {
                TimeCreation = Utilities.Iso8601TimestampToDateTime(value);
            }
        }

        public DateTime TimeCreation { get; private set; }

        [JsonProperty("expires_at")]
        private string TimeExpirationInternal {
            set {
                TimeExpiration = Utilities.Iso8601TimestampToDateTime(value);
            }
        }

        public DateTime TimeExpiration { get; private set; }

        [JsonProperty("seconds_till_timeout")]
        private int TimeoutIntervalInternal {
            set {
                TimeoutInterval = new TimeSpan(0, 0, value);
            }
        }

        public TimeSpan TimeoutInterval { get; private set; }
    }
}

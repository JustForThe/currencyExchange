using currencyExchangeService.Domain.Enums;
using System.Text.Json.Serialization;

namespace currencyExchangeService.Domain.Entities
{
    public class CurrencyRate
    {
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Currencies FromCurrency { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Currencies ToCurrency { get; set; }

        public decimal  ExchangeRate { get; set; }

        public decimal FinalExchangeRate { get; set; }
    }
}

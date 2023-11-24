namespace Cartesian.CurrencyConverter.Business.Models
{
    public class CurrencyResponse
    {

        /// <summary>
        /// Gets or sets the exchange rate for conversion.
        /// </summary>
        public decimal ExchangeRate { get; set; }

        /// <summary>
        /// Gets or sets the converted amount.
        /// </summary>
        public decimal ConvertedAmount { get; set; }
    }
}

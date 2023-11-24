namespace Cartesian.CurrencyConverter.Business.Models
{
    public class CurrencyRequest
    {
        /// <summary>
        /// Gets or sets the source curren
        /// </summary>
        public required string SourceCurrency { get; set; }

        /// <summary>
        /// Gets or sets the target currency.
        /// </summary>
        public required string TargetCurrency { get; set; }

        /// <summary>
        /// Gets or sets the amount to be converted.
        /// </summary>
        public decimal Amount { get; set; }
    }
}
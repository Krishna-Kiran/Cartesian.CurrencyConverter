namespace Cartesian.CurrencyConverter.Response
{
    public interface IApiResponse
    {
      
        /// <summary>
        /// Gets or sets the response message.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets the status of the request.
        /// </summary>
        public bool IsSuccessful { get; set; }
    }
}

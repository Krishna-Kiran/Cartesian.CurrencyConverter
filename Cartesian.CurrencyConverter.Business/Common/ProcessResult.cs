namespace Cartesian.CurrencyConverter.Business.Common
{
    public class ProcessResult<T>
    {
        /// <summary>
        /// Gets or sets the status
        /// </summary>
        public bool IsSuccessful { get; set; }


        /// <summary>
        /// Gets or sets applicable data to be returned.
        /// </summary>
        public T Data { get; set; }

        /// <summary>
        /// Gets or sets the message while processing action.
        /// </summary>
        public string Message { get; set; }
    }
}

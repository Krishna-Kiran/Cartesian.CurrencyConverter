namespace Cartesian.CurrencyConverter.Response
{
    public class ApiResponse<TData>: IApiResponse
    {
       
        public string Message { get; set; }

         public bool IsSuccessful { get; set; }

        public TData Data { get; set; }
    }
}

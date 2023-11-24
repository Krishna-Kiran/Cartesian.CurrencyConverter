using Ardalis.GuardClauses;
using Cartesian.CurrencyConverter.Business.Common;
using Cartesian.CurrencyConverter.Business.Models;
using Cartesian.CurrencyConverter.Business.Workflow;
using Cartesian.CurrencyConverter.Response;
using Microsoft.AspNetCore.Mvc;

namespace Cartesian.CurrencyConverter.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CurrencyConverterController : ControllerBase
    {

        private readonly ILogger<CurrencyConverterController> _logger;
        private readonly IConverter _currencyConverter;

        public CurrencyConverterController(ILogger<CurrencyConverterController> logger, IConverter currencyConverter)
        {
            _logger = logger;
            _currencyConverter = currencyConverter;
        }

        [HttpGet]
        public ApiResponse<CurrencyResponse> Get(string sourceCurrency, string targetCurrency, decimal amount)
        {
            var response = new ApiResponse<CurrencyResponse>();
            try
            {
                _logger.LogTrace($"Request received for {sourceCurrency} to {targetCurrency}");
               
                var result = _currencyConverter.ConvertCurr(new CurrencyRequest() { SourceCurrency = sourceCurrency, TargetCurrency = targetCurrency, Amount = amount });
                if (!result.IsSuccessful)
                {
                    response.IsSuccessful = false;
                    response.Message = result.Message;
                    _logger.LogError(result.Message);
                    return response;
                }
                response.IsSuccessful = true;
                response.Message = result.Message;
                response.Data = result.Data;

            }
            catch (Exception ex)
            {
                response.IsSuccessful = false;
                response.Message = ex.Message;
                _logger.LogError(ex.Message);
                return response;
            }
            return response;
        }
    }
}
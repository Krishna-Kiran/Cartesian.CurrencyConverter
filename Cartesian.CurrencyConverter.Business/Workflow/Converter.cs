using Ardalis.GuardClauses;
using Cartesian.CurrencyConverter.Business.Common;
using Cartesian.CurrencyConverter.Business.Configuration;
using Cartesian.CurrencyConverter.Business.Models;
using System;

namespace Cartesian.CurrencyConverter.Business.Workflow
{
    public class Converter : IConverter
    {
        
        public ProcessResult<CurrencyResponse> ConvertCurr(CurrencyRequest request)
        {
            var response = new ProcessResult<CurrencyResponse>();
            try
            {
                Guard.Against.NullOrEmpty(request.SourceCurrency, nameof(request.SourceCurrency));
                Guard.Against.NullOrEmpty(request.TargetCurrency, nameof(request.TargetCurrency));
                Guard.Against.Negative(request.Amount, nameof(request.Amount));
                var config = EnvironmentConfiguration.GetEnvironmentConfig();
                var exchangeRateString = config[$"{request.SourceCurrency}_TO_{request.TargetCurrency}"];
                if(string.IsNullOrEmpty(exchangeRateString))
                {
                    response.IsSuccessful = false;
                    response.Message = $"Exchange rate not found for source:{request.SourceCurrency} target:{request.TargetCurrency}";
                    return response;
                }
                var exchangeRate = Convert.ToDecimal(exchangeRateString);
                response.Data = new CurrencyResponse
                {
                    ConvertedAmount = request.Amount * exchangeRate,
                    ExchangeRate = exchangeRate
                };
                response.IsSuccessful = true;   
            }
            catch (Exception ex)
            {
                response.IsSuccessful = false;
                response.Message = ex.Message;
                return response;

            }
            return response;
        }
    }
}

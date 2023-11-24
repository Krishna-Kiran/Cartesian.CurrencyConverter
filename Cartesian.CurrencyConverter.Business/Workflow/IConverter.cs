using Cartesian.CurrencyConverter.Business.Common;
using Cartesian.CurrencyConverter.Business.Models;

namespace Cartesian.CurrencyConverter.Business.Workflow
{
    public interface IConverter
    {
        /// <summary>
        /// Converts currency from source to target based on exchange rate.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
       public ProcessResult<CurrencyResponse> ConvertCurr(CurrencyRequest request);
    }
}

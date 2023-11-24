using Cartesian.CurrencyConverter.Business.Workflow;
using Xunit;
using FluentAssertions;
using System.ComponentModel.DataAnnotations;

namespace Cartesian.CurrencyConverter.Tests.Business
{
    public class CurrencyConverterTests
    {
       
        [Theory]
        [InlineData("IND","USSR")]
        [InlineData("INR", "USR")]
        public void ConvertCurr_Fails_ExchangeNotFound(string sourceCurrency, string targetCurrency)
        {
            Converter currencyConverter = new Converter();
            var result = currencyConverter.ConvertCurr(new CurrencyConverter.Business.Models.CurrencyRequest() { SourceCurrency = sourceCurrency, TargetCurrency = targetCurrency, Amount = 123 });
            result.Should().NotBeNull();
            result.IsSuccessful.Should().BeFalse();
            result.Data.Should().BeNull();
            result.Message.Should().NotBeNullOrEmpty();
        }
        [Theory]
        [InlineData("INR", "USD", -2)]
        [InlineData("", "USD",24)]
        [InlineData("USD", "", 24)]
        public void ConvertCurr_Fails_InvalidInput(string sourceCurrency, string targetCurrency, decimal amount)
        {
            Converter currencyConverter = new Converter();
            var result = currencyConverter.ConvertCurr(new CurrencyConverter.Business.Models.CurrencyRequest() { SourceCurrency = sourceCurrency, TargetCurrency = targetCurrency, Amount = amount });
            result.Should().NotBeNull();
            result.IsSuccessful.Should().BeFalse();
            result.Data.Should().BeNull();
            result.Message.Should().NotBeNullOrEmpty();
        }

        [Theory]
        [InlineData("INR", "USD", 234.6)]
        [InlineData("USD", "INR", 24.7)]
        [InlineData("USD", "EUR", 24.8)]
        [InlineData("EUR", "USD", 24.8)]
        [InlineData("INR", "EUR", 234.6)]
        [InlineData("EUR", "INR", 24.7)]
        [InlineData("EUR", "USD", 24.8)]
        public void ConvertCurr_Succeeds_ValidInput(string sourceCurrency, string targetCurrency, decimal amount)
        {
            Converter currencyConverter = new Converter();
            var result = currencyConverter.ConvertCurr(new CurrencyConverter.Business.Models.CurrencyRequest() { SourceCurrency = sourceCurrency, TargetCurrency = targetCurrency, Amount = amount });
            result.Should().NotBeNull();
            result.IsSuccessful.Should().BeTrue();
            result.Data.Should().NotBeNull();
        }
    }
}
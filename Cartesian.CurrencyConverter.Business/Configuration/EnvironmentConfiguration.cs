using Microsoft.Extensions.Configuration;

namespace Cartesian.CurrencyConverter.Business.Configuration
{
    public static class EnvironmentConfiguration
    {
        public static IConfiguration GetEnvironmentConfig()
        {

            var config = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
      .AddJsonFile("appsettings.json", false, true)
      .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development"}.json", false, true)
      .AddJsonFile("exchangeRates.json", false, true)
      .AddEnvironmentVariables()
      .Build();

            return config;
        }
    }
}

using ExchangeRates.Model;
using Newtonsoft.Json;

namespace NBPClient
{
    public class NBPClient
    {
        public static ICollection<Rate> GetRates( int number=10)
        {
            var httpClient = new HttpClient();
            var baseAdrdess = "http://api.nbp.pl/api/exchangerates/rates/";
            httpClient.BaseAddress = new Uri(baseAdrdess);

            //request to server
            var response = httpClient.GetAsync($"C/USD/Last/{number}?Format=json").Result;
            var contentJson = response.Content.ReadAsStringAsync().Result;
            var series = JsonConvert.DeserializeObject<ExchangeRatesSeries>(contentJson);
            return series.Rates;

            
        }
        public static ICollection<Rate> GetRates(string currency , int number = 10)
        {
            var httpClient = new HttpClient();
            var baseAdrdess = "http://api.nbp.pl/api/exchangerates/rates/";
            httpClient.BaseAddress = new Uri(baseAdrdess);

            //request to server
            var response = httpClient.GetAsync($"C/{currency}/Last/{number}?Format=json").Result;
            var contentJson = response.Content.ReadAsStringAsync().Result;
            var series = JsonConvert.DeserializeObject<ExchangeRatesSeries>(contentJson);
            return series.Rates;


        }
    }
}

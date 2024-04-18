
using Newtonsoft.Json;
using System.Security.AccessControl;

namespace GasStationApp
{
    public static class UTAHttpClient
    {

        readonly static public string url = "https://utapl.azurewebsites.net/api/";
        public static async Task<GasStationResponseDto> GetStationsAsync(string token, int numerStrony, int liczbaStacji, string krajISO)
        {
            var client = new HttpClient();
            Console.WriteLine($"{url}Station?Page={numerStrony}&Size={liczbaStacji}&Country={krajISO}");
            var request = new HttpRequestMessage(HttpMethod.Get, $"{url}Station?Page={numerStrony}&Size={liczbaStacji}&Country={krajISO}");
            request.Headers.Add("Authorization", $"Bearer {token}");
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            string resultContent = await response.Content.ReadAsStringAsync();

            var stacje = JsonConvert.DeserializeObject<GasStationResponseDto>(resultContent);


            return stacje;
        }

        public static async Task<string> AuthenticateAsync(string login, string haslo)
        {
            var httpClient = new HttpClient();
            string payload = $"{{\"userName\": \"{login}\",\"password\": \"{haslo}\"}}";
            var content = new StringContent(payload, null, "application/json");


            try
            {
                var result = await httpClient.PostAsync($"{url}/Authentication/Authenticate", content);
                string resultContent = await result.Content.ReadAsStringAsync();
                return resultContent;
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"Wystąpił błąd podczas wykonywania żądania: {e.Message}");
                return null;
            }
        }

        public static async Task<List<DeliveryDTO>> DostawyAsync(string token, int customerNumber, string synchronizationId)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, $"{url}Customer/{customerNumber}/em-trans-data?synchronizationClientId={synchronizationId}");
            request.Headers.Add("Authorization", $"Bearer {token}");
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            string resultContent = await response.Content.ReadAsStringAsync();

            List<DeliveryDTO> dostawy = JsonConvert.DeserializeObject<List<DeliveryDTO>>(resultContent);


            return dostawy;
        }

        public static async Task<List<DetailTransactionDto>> GetTransactionsAsync(string token, int customerNumber, string synchronizationId , DateTime invoiceDate)
        {
            
            var client = new HttpClient();
            //                      https://utapl.azurewebsites.net/api/Customer/6221850/detail-transactions?synchronizationClientId=8b581f16-a6c1-4500-8d7e-3da2f64f37db&dataFakturowania=2024-02-29
            var request = new HttpRequestMessage(HttpMethod.Get, $"{url}Customer/{customerNumber}/detail-transactions?synchronizationClientId={synchronizationId}&dataFakturowania={invoiceDate:yyyy-MM-dd}");
            request.Headers.Add("Authorization", $"Bearer {token}");
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            string resultContent = await response.Content.ReadAsStringAsync();

            List<DetailTransactionDto> dostawy = JsonConvert.DeserializeObject<List<DetailTransactionDto>>(resultContent);


            return dostawy;
        }
    }
}

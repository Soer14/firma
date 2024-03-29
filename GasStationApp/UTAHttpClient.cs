using Newtonsoft.Json;

namespace GasStationApp
{
    public static class UTAHttpClient
    {

        readonly static public string url = "https://utapl.azurewebsites.net/api/";
        public static async Task<GasStationResponseDto> GetStationsAsync(string token, int odStacji, int liczbaStacji, string krajISO)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, $"{url}Station?Page={odStacji}&Size={liczbaStacji}&Country={krajISO}");
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

        public static async Task<List<Dostawa>> DostawyAsync(string token, int customerNumber, string synchronizationId)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, $"{url}Customer/{customerNumber}/em-trans-data?synchronizationClientId={synchronizationId}");
            request.Headers.Add("Authorization", $"Bearer {token}");
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            string resultContent = await response.Content.ReadAsStringAsync();

            List<Dostawa> dostawy = JsonConvert.DeserializeObject<List<Dostawa>>(resultContent);


            return dostawy;
        }
    }
}

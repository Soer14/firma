using DevExpress.ExpressApp;
using Firma.Module.BusinessObjects;
using Firma.Module.BusinessObjects.Kartoteki;
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
        public static void  ZapiszDane(IObjectSpace objectSpace , string countryISO, GasStationResponseDto stations)
        {
            var country = objectSpace.GetObjectByKey<Country>(countryISO);

            foreach (var station in stations.Data)
            {
                var stacja = objectSpace.GetObjectByKey<GasStation>(station.StationNumber);

                if (stacja is null)
                {
                    stacja = objectSpace.CreateObject<GasStation>();
                    stacja.StationNumber = station.StationNumber;
                    stacja.StationName = station.StationName;
                    stacja.Latitude = station.Latitude;
                    stacja.Longitude = station.Longitude;
                    stacja.Address = station.Address;
                    stacja.City = station.City;
                    stacja.CompanyName = station.CompanyName;
                    stacja.Comments = station.Comments;
                    stacja.ValidFrom = station.ValidFrom;
                    stacja.ValidTo = station.ValidTo;
                    stacja.Country = country;
                    stacja.Currency = country.Currency;
                }

            }
            objectSpace.CommitChanges();
        }
    }
}

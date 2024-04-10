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
        public static void  SaveStationsToDataBase(IObjectSpace objectSpace , string countryISO, GasStationResponseDto stations)
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

        public static void SaveDeliveryToDataBase(IObjectSpace objectSpace, List<DeliveryDTO> transactions)
        {
            foreach (var transaction in transactions)
            {
                var item = objectSpace.GetObjectsQuery<Delivery>().Where(d => d.Identyfikator == transaction.Identyfikator).FirstOrDefault();
                if (item is null)
                {
                     item = objectSpace.CreateObject<Delivery>();
                    item.Identyfikator = transaction.Identyfikator;
                    item.NazwaKlienta = transaction.NazwaKlienta;
                    item.IdDostawcy = transaction.IdDostawcy;
                    item.NazwaDostawcy = transaction.NazwaDostawcy;
                    item.DataDostawy = transaction.DataDostawy;
                    item.CzasDostawy = transaction.CzasDostawy;
                    item.Kraj = transaction.Kraj;
                    item.PunktAkceptacji = transaction.PunktAkceptacji;
                    item.MarkaKoncern = transaction.MarkaKoncern;
                    item.Miejscowosc = transaction.Miejscowosc;
                    item.KodPocztowyStacji = transaction.KodPocztowyStacji;
                    item.StawkaVAT = transaction.StawkaVAT;
                    item.NrRejestr = transaction.NrRejestr;
                    item.StanLicznika = transaction.StanLicznika;
                    item.MiejsceKosztu = transaction.MiejsceKosztu;
                    item.MiejsceKosztu2 = transaction.MiejsceKosztu2;
                    item.KategoriaKarty = transaction.KategoriaKarty;
                    item.NrKarty = transaction.NrKarty;
                    item.PelnyNumerKarty = transaction.PelnyNumerKarty;
                    item.NazwaProduktu = transaction.Produkt;
                    item.KodProduktu = transaction.KodProduktu;
                    var product = objectSpace.GetObjectsQuery<Product>(true).Where(p => p.Symbol == transaction.KodProduktu).FirstOrDefault();
                    if (product is null)
                    {
                        product = objectSpace.CreateObject<Product>();
                        product.ProductName = transaction.Produkt;
                        product.Symbol = transaction.KodProduktu;
                        var vatRate = objectSpace.GetObjectsQuery<VatRate>().Where(p => p.RateValue == transaction.StawkaVAT).FirstOrDefault();
                        product.VatRate = vatRate;
                    }
                    item.Product = product;


                   
                    item.Ilosc = transaction.Ilosc;
                    item.Waluta = transaction.Waluta;
                    item.CenaJednostkowaNetto = transaction.CenaJednostkowaNetto;
                    item.CenaJedn = transaction.CenaJedn;
                    item.WartoscNetto = transaction.WartoscNetto;
                    item.Wartosc = transaction.Wartosc;
                    item.UTAVoucherNumber = transaction.UTAVoucherNumber;
                    item.VoucherNr = transaction.VoucherNr;
                }
            }
            objectSpace.CommitChanges();
        }
    }
}

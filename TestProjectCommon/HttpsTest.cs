using GasStationApp;

namespace TestProjectCommon
{
    internal class HttpsTest
    {
        string login = "UtaPlTest";
        string haslo = "";

        [Test]
        public async Task PobraniadanychOStacjachAsync()
        {
           


            string token = await UTAHttpClient.AuthenticateAsync(login, haslo);


            GasStationResponseDto stations = await UTAHttpClient.GetStationsAsync(token, 1, 100, "POL");

            Assert.IsNotNull(stations.Data);
            Assert.AreEqual(100, stations.Data.Count);


            foreach (var station in stations.Data)
            {
                Console.WriteLine($"Station Number: {station.StationNumber}, Station Name: {station.StationName}, Country: {station.Country}");
            }

        }

        [Test]
        public async Task DostawaTest()

        {

            // https://youtu.be/T8JqkCaYjto?si=K34VXYDDjSSFgSxQ


            string endpoint =
                "https://utapl.azurewebsites.net/api/Customer/6221850/em-trans-data?synchronizationClientId=8b581f16-a6c1-4500-8d7e-3da2f64f37db";

            int customerNumber = 6221850;
            string synchronizationId = "8b581f16-a6c1-4500-8d7e-3da2f64f37db";

            var url =
                $"{UTAHttpClient.url}Customer/{customerNumber}/em-trans-data?synchronizationClientId={synchronizationId}";

            Assert.AreEqual(endpoint, url);

            var token = await UTAHttpClient.AuthenticateAsync(login, haslo);


            List<DeliveryDTO> dostawy = await UTAHttpClient.DostawyAsync(token, customerNumber, synchronizationId);
            Assert.AreEqual(70, dostawy.Count);

            foreach (var dostawa in dostawy)
            {
                Console.WriteLine($"Identyfikator: {dostawa.Identyfikator}, NazwaKlienta: {dostawa.NazwaKlienta}, IdDostawcy: {dostawa.IdDostawcy} {dostawa.PunktAkceptacji} {dostawa.Produkt}");
            
            }
            //UTAHttpClient.SaveDeliveryToDataBase(objectSpace, dostawy);
        }

        [Test]
        public void guidTest()
        {
            Guid guid = Guid.NewGuid();
            Assert.That(guid.ToString(), Is.EqualTo("expected"));
        }
    }
}


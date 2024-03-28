using GasStationApp;

namespace TestProjectCommon
{
    internal class HttpsTest
    {

        [Test]
        public async Task PobraniadanychOStacjachAsync()
        {
            var login = "UtaPlTest";
            var haslo = "xxxxxxx";



            string token = await UTAHttpClient.AuthenticateAsync(login, haslo);


            GasStationResponseDto stations = await UTAHttpClient.GetStationsAsync(token, 1, 100, "POL");

            Assert.IsNotNull(stations.Data);
            Assert.AreEqual(500, stations.Data.Count);


            foreach (var station in stations.Data)
            {
                Console.WriteLine($"Station Number: {station.StationNumber}, Station Name: {station.StationName}, Country: {station.Country}");
            }

        }

        [Test]
        public void DostawaTest()

        {

            // https://youtu.be/T8JqkCaYjto?si=K34VXYDDjSSFgSxQ


            string endpoint =
                "https://utapl.azurewebsites.net/api/Customer/6221850/em-trans-data?synchronizationClientId=8b581f16-a6c1-4500-8d7e-3da2f64f37db";

            int customerNumber = 6221850;
            string synchronizationId = "8b581f16-a6c1-4500-8d7e-3da2f64f37db";

            var url =
                $"{UTAHttpClient.url}Customer/{customerNumber}/em-trans-data?synchronizationClientId={synchronizationId}";

            Assert.AreEqual(endpoint, url);



            //List<Dostawa> dostawy = JsonConvert.DeserializeObject<List<Dostawa>>(responseString);

            //foreach (var dostawa in dostawy)
            //{
            //    Console.WriteLine($"Identyfikator: {dostawa.Identyfikator}, NazwaKlienta: {dostawa.NazwaKlienta}, IdDostawcy: {dostawa.IdDostawcy}");
            //}
        }

    }
}


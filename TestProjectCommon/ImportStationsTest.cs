
using Firma.Module.BusinessObjects;
using Firma.Module.BusinessObjects.Kartoteki;
using GasStationApp;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProjectCommon
{
    public class ImportStationsTest : BaseTestOnDB
    {


        [Test]
        public void ObjectSpaceTest()
        {
            Assert.IsNotNull(objectSpace);
            var countrys = objectSpace.GetObjectsQuery<Country>();
            Assert.AreEqual(245, countrys.Count());
        }
        string login = "UtaPlTest";
        string haslo = "";

        [Test]
        public async System.Threading.Tasks.Task PobraniadanychOStacjachAsync()
        {


            
            string token = await UTAHttpClient.AuthenticateAsync(login, haslo);
            var countryTxt = "DEU";

            GasStationResponseDto stations = await UTAHttpClient.GetStationsAsync(token, 1, 500, countryTxt);

            Assert.IsNotNull(stations.Data);
            Assert.AreEqual(500, stations.Data.Count);
            
            
            var country = objectSpace.GetObjectByKey<Country>(countryTxt);
            //var currency = objectSpace.GetObjectByKey<Currency>("PLN");
            //var currency2 = objectSpace.GetObjectsQuery<Currency>().Where(c => c.Country == country);
            foreach (var station in stations.Data)
            {
                Console.WriteLine($"Station Number: {station.StationNumber}, Station Name: {station.StationName}, Country: {station.Country}");
                var stacja = objectSpace.GetObjectByKey<GasStation>(station.StationNumber);
                // var stacja2 = objectSpace.GetObjectsQuery<GasStation>().Where(s => s.StationNumber == station.StationNumber).FirstOrDefault();
                //  Assert.AreEqual(stacja, stacja2);
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
           // var stacjeWBazie = objectSpace.GetObjectsQuery<GasStation>();
           // Assert.AreEqual(-1, stacjeWBazie.Count());
        }
    }
}

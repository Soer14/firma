
using Azure;
using Firma.Module.BusinessObjects;
using Firma.Module.BusinessObjects.Kartoteki;
using GasStationApp;
using Microsoft.CodeAnalysis.CSharp;
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



        string[] countryCodes =
            {
                "ALB", // Albania
                "AND", // Andorra
                "ARM", // Armenia
                "AUT", // Austria
                "AZE", // Azerbaijan
                "BLR", // Belarus
                "BEL", // Belgium
                "BIH", // Bosnia and Herzegovina
                "BGR", // Bulgaria
                "HRV", // Croatia
                "CYP", // Cyprus
                "CZE", // Czech Republic
                "DNK", // Denmark
                "EST", // Estonia
                "FIN", // Finland
                "FRA", // France
                "GEO", // Georgia
                "DEU", // Germany
                "GRC", // Greece
                "HUN", // Hungary
                "ISL", // Iceland
                "IRL", // Ireland
                "ITA", // Italy
                "LVA", // Latvia
                "LIE", // Liechtenstein
                "LTU", // Lithuania
                "LUX", // Luxembourg
                "MKD", // North Macedonia
                "MLT", // Malta
                "MDA", // Moldova
                "MCO", // Monaco
                "MNE", // Montenegro
                "NLD", // Netherlands
                "NOR", // Norway
                "POL", // Poland
                "PRT", // Portugal
                "ROU", // Romania
                "SMR", // San Marino
                "SRB", // Serbia
                "SVK", // Slovakia
                "SVN", // Slovenia
                "ESP", // Spain
                "SWE", // Sweden
                "CHE", // Switzerland
                "TUR", // Turkey
                "UKR", // Ukraine
                "GBR", // United Kingdom
                "VAT"  // Vatican City
            };

        [Test]
        public async System.Threading.Tasks.Task PobraniadanychOStacjachAsync()
        {



            string token = await UTAHttpClient.AuthenticateAsync(login, haslo);
            var countryTxt = "ITA";

            GasStationResponseDto stations = await UTAHttpClient.GetStationsAsync(token, 1, 500, countryTxt);

            Assert.IsNotNull(stations.Data);
            Assert.AreEqual(500, stations.Data.Count);

          UTAHttpClient.SaveStationsToDataBase(objectSpace,countryTxt, stations);
            // var stacjeWBazie = objectSpace.GetObjectsQuery<GasStation>();
            // Assert.AreEqual(-1, stacjeWBazie.Count());
        }



        [Test]
        public async System.Threading.Tasks.Task ImportWieluStacjiTest()
        {
            var token = await UTAHttpClient.AuthenticateAsync(login, haslo);
            
            var liczbaStacji = 500;

            foreach (var country in countryCodes)
            {

                var odStrony = 1;
                Console.WriteLine(country);
                var liczbaPobranychRekordow = liczbaStacji;

                while (liczbaPobranychRekordow == liczbaStacji)
                {
                    var stacje = await UTAHttpClient.GetStationsAsync(token, odStrony, liczbaStacji, country);
                    Console.WriteLine($"kraj {country} strona {odStrony},liczba rekordów{stacje.Data.Count}, ");
                    odStrony++;
                    liczbaPobranychRekordow = stacje.Data.Count;
                    UTAHttpClient.SaveStationsToDataBase(objectSpace, country, stacje);
                }
            }
        }

    }
}

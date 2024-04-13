
using ApplicationCommon;
using Azure;
using DevExpress.CodeParser;
using Firma.Module.BusinessObjects;
using Firma.Module.BusinessObjects.Kartoteki;
using Firma.Module.Util;
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



            string token = await UTAHttpClient.AuthenticateAsync(CustomerSettings.login, CustomerSettings.haslo);
            var countryTxt = "ITA";

            GasStationResponseDto stations = await UTAHttpClient.GetStationsAsync(token, 1, 500, countryTxt);

            Assert.IsNotNull(stations.Data);
            Assert.AreEqual(500, stations.Data.Count);

            GastStationsImporter.SaveStationsToDataBase(objectSpace, countryTxt, stations);
            // var stacjeWBazie = objectSpace.GetObjectsQuery<GasStation>();
            // Assert.AreEqual(-1, stacjeWBazie.Count());
        }



        [Test]
        public async System.Threading.Tasks.Task ImportWieluStacjiTest()
        {
            var token = await UTAHttpClient.AuthenticateAsync(CustomerSettings.login, CustomerSettings.haslo);

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
                    GastStationsImporter.SaveStationsToDataBase(objectSpace, country, stacje);
                }
            }
        }
        [Test]
        public async Task ImportAssetsTestAsync()
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync("https://gist.githubusercontent.com/kashiash/ee74ce7dda606ccd02fc6ffeb8f8ad7e/raw/fb5a3e1bb6aedd1a5babfdf255f226da142a31ca/gistfile1.txt");
                using (var stream = await response.Content.ReadAsStreamAsync())
                {
                    using (CsvFileReader reader = new CsvFileReader(stream))
                    {
                        int licznik = 0;
                        CsvRow row = new CsvRow();
                        while (reader.ReadRow(row))
                        {
                            licznik++;
                            if (row[3].Contains("Akz") || row.Count < 48) continue;

                            var nrStacji = StringToInt(row[3]);
                            // var station = objectSpace.GetObjectByKey<GasStationAssets>(nrStacji);
                            var station = objectSpace.GetObjectsQuery<GasStationAssets>(true).Where(s => s.AkzNr == nrStacji).FirstOrDefault();
                            Console.WriteLine($"{licznik} {row.Count} {row[0]} {row[1]} {row[2]} {row[3]} {row[4]} {row[5]}");
                            if (station == null)
                            {
                                station = objectSpace.CreateObject<GasStationAssets>();
                            }

                            station.Tankstelle = row[0] == "X" ? true : false;
                            station.Werkstatt = StringToInt(row[1]);
                            station.Reinigung = row[2] == "X" ? true : false; ;

                            //Tankstelle;
                            //Werkstatt;
                            //Reinigung;
                            //Akz Nr.;
                            //[3]
                            station.AkzNr = nrStacji;
                            //Marke;
                            station.Marke = row[4];
                            //Name;
                            station.Name = row[5];
                            //Land;
                            station.Land = row[6];
                            //ZIP;
                            station.ZIP = row[7];
                            //Ort;
                            station.Ort = row[8];
                            //Anschrift;
                            station.Anschrift = row[9];
                            //Telefon Nr;
                            station.TelefonNr = row[10];
                            //SELECT-Station;
                            station.SelectStation = row[11] == "X" ? true : false;
                            //24h Service;
                            station.H24Service = row[12] == "X" ? true : false;
                            //DocStop;
                            station.DocStop = row[13] == "X" ? true : false;
                            //Nähe Autobahn
                            station.NaheAutobahn = row[14] == "X" ? true : false;
                            //;Autobahn TS;
                            station.AutobahnTS = row[15] == "X" ? true : false;
                            //Autohof;
                            station.Autohof = row[16] == "X" ? true : false;
                            //Hochleistungszapfsäule;
                            station.Hochleistungszapfsaule = row[17] == "X" ? true : false;
                            //Sondertankpunkt;
                            station.Sondertankpunkt = row[18] == "X" ? true : false;
                            //Aral Sondertankpunkt;
                            station.AralSondertankpunkt = row[19] == "X" ? true : false;
                            //UTA-Empfehlung;
                            station.UtaEmpfehlung = row[20] == "X" ? true : false;
                            //elektr. Führerscheinkontrolle;
                            station.ElektrFuhrerscheinkontrolle = row[21] == "X" ? true : false;
                            //Parkplatz;
                            station.Parkplatz = row[22] == "X" ? true : false;
                            //Parkplatzbewachung;
                            station.Parkplatzbewachung = row[23] == "X" ? true : false;
                            //Restaurant;
                            station.Restaurant = row[24] == "X" ? true : false;
                            //Imbiss;
                            station.Imbiss = row[25] == "X" ? true : false;
                            //Fahrerwaschraum;
                            station.Fahrerwaschraum = row[26] == "X" ? true : false;
                            //GO Box Vertriebsstelle;
                            station.GoBoxVertriebsstelle = row[27] == "X" ? true : false;
                            //Mautterminal;
                            station.Mautterminal = row[28] == "X" ? true : false;
                            //OBU Einbauservice;
                            station.ObuEinbauservice = row[29] == "X" ? true : false;
                            //Automat ganz;
                            station.AutomatGanz = row[30] == "X" ? true : false;
                            //Automat teilweise;
                            station.AutomatTeilweise = row[31] == "X" ? true : false;
                            //AdBlue Kanister;
                            station.AdBlueKanister = row[32] == "X" ? true : false;
                            //AdBlue Zapfsäule;
                            station.AdBlueZapfsaule = row[33] == "X" ? true : false;
                            //Autogas;
                            station.Autogas = row[34] == "X" ? true : false;
                            //Biodiesel;
                            station.Biodiesel = row[35] == "X" ? true : false;
                            //Erdgas;
                            station.Erdgas = row[36] == "X" ? true : false;
                            //Pflanzenöl;
                            station.Pflanzenol = row[37] == "X" ? true : false;
                            //Flüssigerdgas;
                            station.Flussigerdgas = row[38] == "X" ? true : false;
                            //HVO100;
                            station.HVO100 = row[39] == "X" ? true : false;
                            //LKW Außenreinigung;
                            station.LkwAussenreinigung = row[40] == "X" ? true : false;
                            //Tankwagen Innenreinigung;
                            station.TankwagenInnenreinigung = row[41] == "X" ? true : false;
                            //Silofahrzeug Innenreinigung;
                            station.SilofahrzeugInnenreinigung = row[42] == "X" ? true : false;
                            //Kühlfahrzeug Innenreinigung;
                            station.KuhlfahrzeugInnenreinigung = row[43] == "X" ? true : false;
                            //Lebensmittelfahrzeug Innenreinigung;
                            station.LebensmittelfahrzeugInnenreinigung = row[44] == "X" ? true : false;
                            //Geocodierung;
                            station.Geocodierung = row[45];
                            //Lieferantennr.;
                            station.Lieferantennr = StringToInt(row[46]);
                            //Supplier;
                            station.Supplier = row[47];
                            //Preiszone

                            if (licznik % 1000 == 0)
                            {
                                Console.WriteLine($"licznik = {licznik}");
                                objectSpace.CommitChanges();
                            }



                        }
                        objectSpace.CommitChanges();
                    }



                }

            }
        }
        public static int StringToInt(string str)
        {
            try
            {
                return int.Parse(str);

            }
            catch { return 0; }
        }
        public static int StringToInt2(string str)
        {
            var ok = int.TryParse(str, out int result);
            if (ok == false)
            {
                return 0;
            }
            else
            {
                return result;
            }
        }
        public static int StringToInt3(string str)
        {
            var ok = int.TryParse(str, out int result);

            //if (ok == false)
            //{
            //    return 0;
            //}
            //else
            //{
            //    return result;
            //}

            return ok ? result : 0;

        }
        public static int StringToInt4(string str)
        {


            return int.TryParse(str, out int result) ? result : 0;

        }
    }
}

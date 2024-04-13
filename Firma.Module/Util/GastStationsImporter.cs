using DevExpress.ExpressApp;
using Firma.Module.BusinessObjects.Kartoteki;
using Firma.Module.BusinessObjects;
using GasStationApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma.Module.Util
{
    public  class GastStationsImporter
    {
        public static void SaveStationsToDataBase(IObjectSpace objectSpace, string countryISO, GasStationResponseDto stations)
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

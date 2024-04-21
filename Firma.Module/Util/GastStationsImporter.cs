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
    public class GastStationsImporter
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
                }
                    item.Identyfikator = transaction.Identyfikator;
                    item.NazwaKlienta = transaction.NazwaKlienta;
                    item.IdDostawcy = transaction.IdDostawcy;
                    item.NazwaDostawcy = transaction.NazwaDostawcy;
                    item.DataDostawy = transaction.DataDostawy;
                    item.CzasDostawy = transaction.CzasDostawy;
                    item.Kraj = transaction.Kraj;
                    item.PunktAkceptacji = transaction.PunktAkceptacji;
                    var stacja = objectSpace.GetObjectByKey<GasStation>(item.PunktAkceptacji);
                    item.GasStation = stacja;
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
                    Product product = GetOrAddProduct(objectSpace, item.KodProduktu, item.NazwaProduktu, item.StawkaVAT);
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
            objectSpace.CommitChanges();
        }

        
        private static Product GetOrAddProduct(IObjectSpace objectSpace, string kodProduktu, string nazwaProduktu, decimal stawkaVAT)
        {
            var product = objectSpace.GetObjectsQuery<Product>(true).Where(p => p.Symbol == kodProduktu).FirstOrDefault();
            if (product is null)
            {
                product = objectSpace.CreateObject<Product>();
                product.ProductName = nazwaProduktu;
                product.Symbol = kodProduktu;
                var vatRate = objectSpace.GetObjectsQuery<VatRate>().Where(p => p.RateValue == stawkaVAT).FirstOrDefault();
                product.VatRate = vatRate;
            }

            return product;
        }
        private static Product GetOrAddProduct(IObjectSpace objectSpace, string kodProduktu, string nazwaProduktu, string stawkaVAT)
        {
            var vatRate = StringToDecimal(stawkaVAT);
          
            return GetOrAddProduct(objectSpace,kodProduktu,nazwaProduktu, vatRate);
        }


        
        public static void SaveTransactionsToDataBase(IObjectSpace objectSpace, List<DetailTransactionDto> transactions)
        {
            foreach (var transaction in transactions)
            {
                var item = objectSpace.GetObjectsQuery<DetailTransaction>().Where(d => d.Oid == transaction.Identyfikator).FirstOrDefault();
                if (item is null)
                {
                    item = objectSpace.CreateObject<DetailTransaction>();
                    item.Oid = transaction.Identyfikator;
                }

                item.NrRachunku = transaction.NrRachunku;
                item.DataDostawy = transaction.DataDostawy;
                item.IdPartneraRozliczeniowego = transaction.IdPartneraRozliczeniowego;
                item.DataPrzetworzenia = transaction.DataPrzetworzenia;
                item.PelnyNrKarty = transaction.PelnyNrKarty;
                item.DataTransakcji = transaction.DataTransakcji;
                item.NumerIdStacji = transaction.NumerIdStacji;
                item.LokalizacjaStacji = transaction.LokalizacjaStacji;
               // var stacja = objectSpace.GetObjectsQuery<GasStation>().Where(g => g.StationNumber == item.NumerIdStacji).FirstOrDefault();
                var stacja = objectSpace.GetObjectByKey<GasStation>(item.NumerIdStacji);
                item.GasStation = stacja;
                item.KodKrajuDostawy = transaction.KodKrajuDostawy;
                item.NrPokwitowania = transaction.NrPokwitowania;
                item.StanLicznika = transaction.StanLicznika;
                item.KodProduktu = transaction.KodProduktu;
                item.NazwaProduktu = transaction.NazwaProduktu;
                item.StawkaVat = transaction.StawkaVat;
                Product product = GetOrAddProduct(objectSpace, item.KodProduktu, item.NazwaProduktu, item.StawkaVat);
                item.Product = product;

                item.Ilosc = transaction.Ilosc;
                item.SB_BT = transaction.SB_BT;

                item.WalutaKrajuDostawy = transaction.WalutaKrajuDostawy;
                item.CenaJednostkowaBruttoWKD = transaction.CenaJednostkowaBruttoWKD;
                item.CenaJednostkowaNettoWKD = transaction.CenaJednostkowaNettoWKD;
                item.DoplataWKD = transaction.DoplataWKD;
                item.RabatWKD = transaction.RabatWKD;
                item.LacznaWartoscNettoWKD = transaction.LacznaWartoscNettoWKD;
                item.LacznaWartoscBruttoWKD = transaction.LacznaWartoscBruttoWKD;
                item.WalutaRozliczeniowa = transaction.WalutaRozliczeniowa;
                item.DoplataWR = transaction.DoplataWR;
                item.RabatWR = transaction.RabatWR;
                item.LacznaWartoscNettoWR = transaction.LacznaWartoscNettoWR;
                item.LacznaWartoscVatWR = transaction.LacznaWartoscVatWR;
                item.LacznaWartoscBruttoWR = transaction.LacznaWartoscBruttoWR;
                item.NrRejNaKarcie = transaction.NrRejNaKarcie;
                item.Mpk = transaction.Mpk;
                item.TypKarty = transaction.TypKarty;
                item.StatusCeny = transaction.StatusCeny;
                item.WskaznikCeny = transaction.WskaznikCeny;
                item.OznaczenieNrPojazdu = transaction.OznaczenieNrPojazdu;
                item.Info = transaction.Info;
                item.NrRejestracyjnyPojazdu = transaction.NrRejestracyjnyPojazdu;
                item.BitMap = transaction.BitMap;
                item.CzasTransakcji = transaction.CzasTransakcji;
                item.DataFakturowania = transaction.DataFakturowania;
                item.TypTransakcji = transaction.TypTransakcji;
                item.PowodWpisu = transaction.PowodWpisu;
                item.Wypelnienie43 = transaction.Wypelnienie43;
                item.NotaInformacyjna = transaction.NotaInformacyjna;
                item.ZrodloNoty = transaction.ZrodloNoty;
                item.Wypelnienie46 = transaction.Wypelnienie46;
                item.CenaJednBruttoDostawy = transaction.CenaJednBruttoDostawy;
                item.CenaJednNettoDostawy = transaction.CenaJednNettoDostawy;
                item.StawkaVatInf = transaction.StawkaVatInf;
                item.WartoscVatOdUpustuDostawy = transaction.WartoscVatOdUpustuDostawy;
                item.WartoscVatDoplatySerwisowejDostawy = transaction.WartoscVatDoplatySerwisowejDostawy;
                item.LicznyVatDoplatySerwisowejDostawy = transaction.LicznyVatDoplatySerwisowejDostawy;
                item.DataWymagalnosci = transaction.DataWymagalnosci;
                item.TerminPlatnosci = transaction.TerminPlatnosci;
                item.SposobPlatnosci = transaction.SposobPlatnosci;
                item.TcNumerFaktury = transaction.TcNumerFaktury;
                item.TcDataFaktury = transaction.TcDataFaktury;
                item.KategoriaWartosciPlatnosci = transaction.KategoriaWartosciPlatnosci;
                item.MiejscePowstaniaKosztow2 = transaction.MiejscePowstaniaKosztow2;
                item.NrObcejKarty = transaction.NrObcejKarty;
                item.IdentyfikatorUrzadzeniaOBU = transaction.IdentyfikatorUrzadzeniaOBU;
                item.NrRejPojazduSkompresowany = transaction.NrRejPojazduSkompresowany;
                item.RodzajKarty = transaction.RodzajKarty;
                item.NumerFakturyWgKraju = transaction.NumerFakturyWgKraju;
                item.WjazdNaAutostrade = transaction.WjazdNaAutostrade;
                item.WyjazdZAutostrady = transaction.WyjazdZAutostrady;
                item.WarunkiSpecjalneFRA = transaction.WarunkiSpecjalneFRA;
                item.NumerNotyObciazeniowej = transaction.NumerNotyObciazeniowej;
                item.Przedstawiciel = transaction.Przedstawiciel;
                item.Indeks = transaction.Indeks;
                item.IdentyfikatorSrodkaPlatnosci = transaction.IdentyfikatorSrodkaPlatnosci;
                item.KategoriaPodatkowa = transaction.KategoriaPodatkowa;
                item.NumerPokwitowaniaUTA = transaction.NumerPokwitowaniaUTA;
                item.DodatkowyNumerPokwitowaniaUTA = transaction.DodatkowyNumerPokwitowaniaUTA;
                item.WinietaWaznaOd = transaction.WinietaWaznaOd;
                item.WinietaWaznaDo = transaction.WinietaWaznaDo;
                item.IdentyfikatorWystawcyUzytkownika = transaction.IdentyfikatorWystawcyUzytkownika;
                item.JednostkaMiary = transaction.JednostkaMiary;
                item.KrajMiejscaDostawy = transaction.KrajMiejscaDostawy;
                item.KodPocztowyMiejscaDostawy = transaction.KodPocztowyMiejscaDostawy;
                item.KrajOpodatkowania = transaction.KrajOpodatkowania;
                item.PodatkowaGrupaProduktowa = transaction.PodatkowaGrupaProduktowa;
                item.ZmiennoscMiejscaUslug = transaction.ZmiennoscMiejscaUslug;
                item.TransactionDateAndTime = transaction.TransactionDateAndTime;



            }
            objectSpace.CommitChanges();
        }
        public static int StringToInt(string str)
        {
            try
            {
                return int.Parse(str);

            }
            catch { return 0; }
        }
        public static decimal StringToDecimal(string str)
        {
            try
            {
                return decimal.Parse(str);

            }
            catch { return 0; }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GasStationApp
{
    public class DetailTransactionDto
    {
        public Guid Oid { get; set; }
        public int NrRachunku { get; set; }
        public DateTime DataDostawy { get; set; }
        public int IdPartneraRozliczeniowego { get; set; }
        public DateTime DataPrzetworzenia { get; set; }
        public string PelnyNrKarty { get; set; }
        public DateTime DataTransakcji { get; set; }
        public int NumerIdStacji { get; set; }
        public string LokalizacjaStacji { get; set; }
        public string KodKrajuDostawy { get; set; }
        public string NrPokwitowania { get; set; }
        public string StanLicznika { get; set; }
        public string KodProduktu { get; set; }
        public string NazwaProduktu { get; set; }
        public int Ilosc { get; set; }
        public string SB_BT { get; set; }
        public string StawkaVat { get; set; }
        public string WalutaKrajuDostawy { get; set; }
        public decimal CenaJednostkowaBruttoWKD { get; set; }
        public decimal CenaJednostkowaNettoWKD { get; set; }
        public decimal DoplataWKD { get; set; }
        public decimal RabatWKD { get; set; }
        public decimal LacznaWartoscNettoWKD { get; set; }
        public decimal LacznaWartoscBruttoWKD { get; set; }
        public string WalutaRozliczeniowa { get; set; }
        public decimal DoplataWR { get; set; }
        public decimal RabatWR { get; set; }
        public decimal LacznaWartoscNettoWR { get; set; }
        public decimal LacznaWartoscVatWR { get; set; }
        public decimal LacznaWartoscBruttoWR { get; set; }
        public string NrRejNaKarcie { get; set; }
        public string Mpk { get; set; }
        public string TypKarty { get; set; }
        public decimal StatusCeny { get; set; }
        public string WskaznikCeny { get; set; }
        public string OznaczenieNrPojazdu { get; set; }
        public string Info { get; set; }
        public string NrRejestracyjnyPojazdu { get; set; }
        public string BitMap { get; set; }
        public int CzasTransakcji { get; set; }
        public DateTime DataFakturowania { get; set; }
        public string TypTransakcji { get; set; }
        public string PowodWpisu { get; set; }
        public string Wypelnienie43 { get; set; }
        public string NotaInformacyjna { get; set; }
        public string ZrodloNoty { get; set; }
        public string Wypelnienie46 { get; set; }
        public decimal CenaJednBruttoDostawy { get; set; }
        public decimal CenaJednNettoDostawy { get; set; }
        public string StawkaVatInf { get; set; }
        public decimal WartoscVatOdUpustuDostawy { get; set; }
        public decimal WartoscVatDoplatySerwisowejDostawy { get; set; }
        public string LicznyVatDoplatySerwisowejDostawy { get; set; }
        public DateTime DataWymagalnosci { get; set; }
        public string TerminPlatnosci { get; set; }
        public string SposobPlatnosci { get; set; }
        public string TcNumerFaktury { get; set; }
        public DateTime TcDataFaktury { get; set; }
        public string KategoriaWartosciPlatnosci { get; set; }
        public string MiejscePowstaniaKosztow2 { get; set; }
        public string NrObcejKarty { get; set; }
        public string IdentyfikatorUrzadzeniaOBU { get; set; }
        public string NrRejPojazduSkompresowany { get; set; }
        public string RodzajKarty { get; set; }
        public string NumerFakturyWgKraju { get; set; }
        public string WjazdNaAutostrade { get; set; }
        public string WyjazdZAutostrady { get; set; }
        public string WarunkiSpecjalneFRA { get; set; }
        public string NumerNotyObciazeniowej { get; set; }
        public string Przedstawiciel { get; set; }
        public string Indeks { get; set; }
        public string IdentyfikatorSrodkaPlatnosci { get; set; }
        public string KategoriaPodatkowa { get; set; }
        public int NumerPokwitowaniaUTA { get; set; }
        public int DodatkowyNumerPokwitowaniaUTA { get; set; }
        public DateTime WinietaWaznaOd { get; set; }
        public DateTime WinietaWaznaDo { get; set; }
        public string IdentyfikatorWystawcyUzytkownika { get; set; }
        public string JednostkaMiary { get; set; }
        public string KrajMiejscaDostawy { get; set; }
        public string KodPocztowyMiejscaDostawy { get; set; }
        public string KrajOpodatkowania { get; set; }
        public string PodatkowaGrupaProduktowa { get; set; }
        public string ZmiennoscMiejscaUslug { get; set; }
        public DateTime TransactionDateAndTime { get; set; }
    }
}

using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma.Module.BusinessObjects
{
    [DefaultClassOptions]
    [NavigationItem("Transakcje")]
    public class DetailTransaction : XPCustomObject


    {
        public DetailTransaction(Session session) : base(session)
        { }
        //
        // {
        //   "identyfikator": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
        //   "nrRachunku": 0,

        Guid oid;
        string pelnyNrKarty;
        DateTime winietaWaznaDo;
        DateTime transactionDateAndTime;
        string zmiennoscMiejscaUslug;
        string podatkowaGrupaProduktowa;
        string krajOpodatkowania;
        string kodPocztowyMiejscaDostawy;
        string krajMiejscaDostawy;
        string jednostkaMiary;
        string identyfikatorWystawcyUzytkownika;
        DateTime winietaWaznaOd;
        string dodatkowyNumerPokwitowaniaUTA;
        string numerPokwitowaniaUTA;
        string kategoriaPodatkowa;
        string identyfikatorSrodkaPlatnosci;
        string indeks;
        string przedstawiciel;
        string numerNotyObciazeniowej;
        string warunkiSpecjalneFRA;
        string wyjazdZAutostrady;
        string jazdNaAutostrade;
        string numerFakturyWgKraju;
        string rodzajKarty;
        string nrRejPojazduSkompresowany;
        string identyfikatorUrzadzeniaOBU;
        string nrObcejKarty;
        string miejscePowstaniaKosztow2;
        string kategoriaWartosciPlatnosci;
        DateTime tcDataFaktury;
        string tcNumerFaktury;
        string sposobPlatnosci;
        string terminPlatnosci;
        DateTime dataWymagalnosci;
        string licznyVatDoplatySerwisowejDostawy;
        decimal wartoscVatDoplatySerwisowejDostawy;
        decimal wartoscVatOdUpustuDostawy;
        string stawkaVatInf;
        decimal cenaJednNettoDostawy;
        decimal cenaJednBruttoDostawy;
        string wypelnienie46;
        string zrodloNoty;
        string notaInformacyjna;
        string wypelnienie43;
        string powodWpisu;
        string typTransakcji;
        DateTime dataFakturowania;
        int czasTransakcji;
        string bitMap;
        string nrRejestracyjnyPojazdu;
        string info;
        string oznaczenieNrPojazdu;
        string wskaznikCeny;
        decimal statusCeny;
        string typKarty;
        string mpk;
        string nrRejNaKarcie;
        decimal lacznaWartoscBruttoWR;
        decimal lacznaWartoscVatWR;
        decimal lacznaWartoscNettoWR;
        decimal rabatWR;
        decimal doplataWR;
        string walutaRozliczeniowa;
        decimal lacznaWartoscBruttoWKD;
        decimal lacznaWartoscNettoWKD;
        decimal rabatWKD;
        decimal doplataWKD;
        decimal cenaJednostkowaNettoWKD;
        decimal cenaJednostkowaBruttoWKD;
        string walutaKrajuDostawy;
        string stawkaVat;
        string sB_BT;
        decimal ilosc;
        string nazwaProduktu;
        string kodProduktu;
        string stanLicznika;
        string nrPokwitowania;
        string kodKrajuDostawy;
        string lokalizacjaStacji;
        int numerIdStacji;
        DateTime dataTransakcji;
        string propertyName;
        DateTime dataPrzetworzenia;
        int idPartneraRozliczeniowego;
        DateTime dataDostawy;
        int nrRachunku;





        [VisibleInListView(false)]
        [VisibleInDetailView(false)]
        [VisibleInLookupListView(false)]


        [Key(false)]
        public Guid Oid
        {
            get => oid;
            set => SetPropertyValue(nameof(Oid), ref oid, value);
        }
        public int NrRachunku
        {
            get => nrRachunku;
            set => SetPropertyValue(nameof(NrRachunku), ref nrRachunku, value);
        }
        //   "dataDostawy": "2024-04-15T09:59:24.122Z",

        public DateTime DataDostawy
        {
            get => dataDostawy;
            set => SetPropertyValue(nameof(DataDostawy), ref dataDostawy, value);
        }
        //   "idPartneraRozliczeniowego": 0,
        [VisibleInListView(false)]
        
        [VisibleInLookupListView(false)]
        public int IdPartneraRozliczeniowego
        {
            get => idPartneraRozliczeniowego;
            set => SetPropertyValue(nameof(idPartneraRozliczeniowego), ref idPartneraRozliczeniowego, value);
        }
        //   "dataPrzetworzenia": "2024-04-15T09:59:24.122Z",
        [VisibleInListView(false)]
       
        [VisibleInLookupListView(false)]
        public DateTime DataPrzetworzenia
        {
            get => dataPrzetworzenia;
            set => SetPropertyValue(nameof(DataPrzetworzenia), ref dataPrzetworzenia, value);
        }
        //   "pelnyNrKarty": "string",

        
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string PelnyNrKarty
        {
            get => pelnyNrKarty;
            set => SetPropertyValue(nameof(PelnyNrKarty), ref pelnyNrKarty, value);
        }
        //   "dataTransakcji": "2024-04-15T09:59:24.122Z",

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public DateTime DataTransakcji
        {
            get => dataTransakcji;
            set => SetPropertyValue(nameof(DataTransakcji), ref dataTransakcji, value);
        }
        //   "numerIdStacji": 0,

        public int NumerIdStacji
        {
            get => numerIdStacji;
            set => SetPropertyValue(nameof(numerIdStacji), ref numerIdStacji, value);
        }
        //   "lokalizacjaStacji": "string",

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string LokalizacjaStacji
        {
            get => lokalizacjaStacji;
            set => SetPropertyValue(nameof(LokalizacjaStacji), ref lokalizacjaStacji, value);
        }
        //   "kodKrajuDostawy": "string",

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string KodKrajuDostawy
        {
            get => kodKrajuDostawy;
            set => SetPropertyValue(nameof(kodKrajuDostawy), ref kodKrajuDostawy, value);
        }
        //   "nrPokwitowania": "string",
        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string NrPokwitowania
        {
            get => nrPokwitowania;
            set => SetPropertyValue(nameof(NrPokwitowania), ref nrPokwitowania, value);
        }
        //   "stanLicznika": "string",
        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string StanLicznika
        {
            get => stanLicznika;
            set => SetPropertyValue(nameof(StanLicznika), ref stanLicznika, value);
        }
        //   "kodProduktu": "string",

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string KodProduktu
        {
            get => kodProduktu;
            set => SetPropertyValue(nameof(kodProduktu), ref kodProduktu, value);
        }
        //   "nazwaProduktu": "string",

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string NazwaProduktu
        {
            get => nazwaProduktu;
            set => SetPropertyValue(nameof(NazwaProduktu), ref nazwaProduktu, value);
        }
        //   "ilosc": 0,

        public decimal Ilosc
        {
            get => ilosc;
            set => SetPropertyValue(nameof(ilosc), ref ilosc, value);
        }
        //   "sB_BT": "string",
        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string SB_BT
        {
            get => sB_BT;
            set => SetPropertyValue(nameof(sB_BT), ref sB_BT, value);
        }
        //   "stawkaVat": 0,

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string StawkaVat
        {
            get => stawkaVat;
            set => SetPropertyValue(nameof(stawkaVat), ref stawkaVat, value);
        }
        //   "walutaKrajuDostawy": "string",

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string WalutaKrajuDostawy
        {
            get => walutaKrajuDostawy;
            set => SetPropertyValue(nameof(walutaKrajuDostawy), ref walutaKrajuDostawy, value);
        }
        //   "cenaJednostkowaBruttoWKD": 0,
        [ModelDefault("DisplayFormat", "{0:N2}")]
        [ModelDefault("EditMask", "N2")]
        public decimal CenaJednostkowaBruttoWKD
        {
            get => cenaJednostkowaBruttoWKD;
            set => SetPropertyValue(nameof(cenaJednostkowaBruttoWKD), ref cenaJednostkowaBruttoWKD, value);
        }
        //   "cenaJednostkowaNettoWKD": 0,
        [ModelDefault("DisplayFormat", "{0:N2}")]
        [ModelDefault("EditMask", "N2")]
        public decimal CenaJednostkowaNettoWKD
        {
            get => cenaJednostkowaNettoWKD;
            set => SetPropertyValue(nameof(CenaJednostkowaNettoWKD), ref cenaJednostkowaNettoWKD, value);
        }
        //   "doplataWKD": 0,
        [ModelDefault("DisplayFormat", "{0:N2}")]
        [ModelDefault("EditMask", "N2")]
        public decimal DoplataWKD
        {
            get => doplataWKD;
            set => SetPropertyValue(nameof(DoplataWKD), ref doplataWKD, value);
        }
        //   "rabatWKD": 0,
        [ModelDefault("DisplayFormat", "{0:N2}")]
        [ModelDefault("EditMask", "N2")]
        public decimal RabatWKD
        {
            get => rabatWKD;
            set => SetPropertyValue(nameof(RabatWKD), ref rabatWKD, value);
        }
        //   "lacznaWartoscNettoWKD": 0,
        [ModelDefault("DisplayFormat", "{0:N2}")]
        [ModelDefault("EditMask", "N2")]
        public decimal LacznaWartoscNettoWKD
        {
            get => lacznaWartoscNettoWKD;
            set => SetPropertyValue(nameof(lacznaWartoscNettoWKD), ref lacznaWartoscNettoWKD, value);
        }
        //   "lacznaWartoscBruttoWKD": 0,
        [ModelDefault("DisplayFormat", "{0:N2}")]
        [ModelDefault("EditMask", "N2")]
        public decimal LacznaWartoscBruttoWKD
        {
            get => lacznaWartoscBruttoWKD;
            set => SetPropertyValue(nameof(LacznaWartoscBruttoWKD), ref lacznaWartoscBruttoWKD, value);
        }
        //   "walutaRozliczeniowa": "string",

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string WalutaRozliczeniowa
        {
            get => walutaRozliczeniowa;
            set => SetPropertyValue(nameof(walutaRozliczeniowa), ref walutaRozliczeniowa, value);
        }
        //   "doplataWR": 0,
        [ModelDefault("DisplayFormat", "{0:N2}")]
        [ModelDefault("EditMask", "N2")]
        public decimal DoplataWR
        {
            get => doplataWR;
            set => SetPropertyValue(nameof(DoplataWR), ref doplataWR, value);
        }
        //   "rabatWR": 0,
        [ModelDefault("DisplayFormat", "{0:N2}")]
        [ModelDefault("EditMask", "N2")]
        public decimal RabatWR
        {
            get => rabatWR;
            set => SetPropertyValue(nameof(RabatWR), ref rabatWR, value);
        }
        //   "lacznaWartoscNettoWR": 0,
        [ModelDefault("DisplayFormat", "{0:N2}")]
        [ModelDefault("EditMask", "N2")]
        public decimal LacznaWartoscNettoWR
        {
            get => lacznaWartoscNettoWR;
            set => SetPropertyValue(nameof(LacznaWartoscNettoWR), ref lacznaWartoscNettoWR, value);
        }
        //   "lacznaWartoscVatWR": 0,
        [ModelDefault("DisplayFormat", "{0:N2}")]
        [ModelDefault("EditMask", "N2")]
        public decimal LacznaWartoscVatWR
        {
            get => lacznaWartoscVatWR;
            set => SetPropertyValue(nameof(LacznaWartoscVatWR), ref lacznaWartoscVatWR, value);
        }
        //   "lacznaWartoscBruttoWR": 0,
        [ModelDefault("DisplayFormat", "{0:N2}")]
        [ModelDefault("EditMask", "N2")]
        public decimal LacznaWartoscBruttoWR
        {
            get => lacznaWartoscBruttoWR;
            set => SetPropertyValue(nameof(lacznaWartoscBruttoWR), ref lacznaWartoscBruttoWR, value);
        }
        //   "nrRejNaKarcie": "string",
        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string NrRejNaKarcie
        {
            get => nrRejNaKarcie;
            set => SetPropertyValue(nameof(nrRejNaKarcie), ref nrRejNaKarcie, value);
        }
        //   "mpk": "string",
        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Mpk
        {
            get => mpk;
            set => SetPropertyValue(nameof(Mpk), ref mpk, value);
        }
        //   "typKarty": "string",
        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string TypKarty
        {
            get => typKarty;
            set => SetPropertyValue(nameof(TypKarty), ref typKarty, value);
        }
        //   "statusCeny": 0,
        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        [ModelDefault("DisplayFormat", "{0:N2}")]
        [ModelDefault("EditMask", "N2")]
        public decimal StatusCeny
        {
            get => statusCeny;
            set => SetPropertyValue(nameof(StatusCeny), ref statusCeny, value);
        }
        //   "wskaznikCeny": "string",
        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string WskaznikCeny
        {
            get => wskaznikCeny;
            set => SetPropertyValue(nameof(WskaznikCeny), ref wskaznikCeny, value);
        }
        //   "oznaczenieNrPojazdu": 0,
        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string OznaczenieNrPojazdu
        {
            get => oznaczenieNrPojazdu;
            set => SetPropertyValue(nameof(oznaczenieNrPojazdu), ref oznaczenieNrPojazdu, value);
        }
        //   "info": "string",
        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Info
        {
            get => info;
            set => SetPropertyValue(nameof(Info), ref info, value);
        }
        //   "nrRejestracyjnyPojazdu": "string",

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string NrRejestracyjnyPojazdu
        {
            get => nrRejestracyjnyPojazdu;
            set => SetPropertyValue(nameof(NrRejestracyjnyPojazdu), ref nrRejestracyjnyPojazdu, value);
        }
        //   "bitMap": "string",
        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string BitMap
        {
            get => bitMap;
            set => SetPropertyValue(nameof(BitMap), ref bitMap, value);
        }
        //   "czasTransakcji": 0,
        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        public int CzasTransakcji
        {
            get => czasTransakcji;
            set => SetPropertyValue(nameof(CzasTransakcji), ref czasTransakcji, value);
        }
        //   "dataFakturowania": "2024-04-15T09:59:24.122Z",
        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public DateTime DataFakturowania
        {
            get => dataFakturowania;
            set => SetPropertyValue(nameof(dataFakturowania), ref dataFakturowania, value);
        }
        //   "typTransakcji": "string",
        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string TypTransakcji
        {
            get => typTransakcji;
            set => SetPropertyValue(nameof(TypTransakcji), ref typTransakcji, value);
        }
        //   "powodWpisu": "string",
        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string PowodWpisu
        {
            get => powodWpisu;
            set => SetPropertyValue(nameof(PowodWpisu), ref powodWpisu, value);
        }
        //   "wypelnienie43": "string",
        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Wypelnienie43
        {
            get => wypelnienie43;
            set => SetPropertyValue(nameof(Wypelnienie43), ref wypelnienie43, value);
        }
        //   "notaInformacyjna": "string",
        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string NotaInformacyjna
        {
            get => notaInformacyjna;
            set => SetPropertyValue(nameof(NotaInformacyjna), ref notaInformacyjna, value);
        }
        //   "zrodloNoty": "string",
        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string ZrodloNoty
        {
            get => zrodloNoty;
            set => SetPropertyValue(nameof(ZrodloNoty), ref zrodloNoty, value);
        }
        //   "wypelnienie46": "string",
        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Wypelnienie46
        {
            get => wypelnienie46;
            set => SetPropertyValue(nameof(Wypelnienie46), ref wypelnienie46, value);
        }
        //   "cenaJednBruttoDostawy": 0,
        [ModelDefault("DisplayFormat", "{0:N2}")]
        [ModelDefault("EditMask", "N2")]
        public decimal CenaJednBruttoDostawy
        {
            get => cenaJednBruttoDostawy;
            set => SetPropertyValue(nameof(CenaJednBruttoDostawy), ref cenaJednBruttoDostawy, value);
        }
        //   "cenaJednNettoDostawy": 0,
        [ModelDefault("DisplayFormat", "{0:N2}")]
        [ModelDefault("EditMask", "N2")]
        public decimal CenaJednNettoDostawy
        {
            get => cenaJednNettoDostawy;
            set => SetPropertyValue(nameof(CenaJednNettoDostawy), ref cenaJednNettoDostawy, value);
        }
        //   "stawkaVatInf": 0,
        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string StawkaVatInf
        {
            get => stawkaVatInf;
            set => SetPropertyValue(nameof(StawkaVatInf), ref stawkaVatInf, value);
        }
        //   "wartoscVatOdUpustuDostawy": 0,
        [ModelDefault("DisplayFormat", "{0:N2}")]
        [ModelDefault("EditMask", "N2")]
        public decimal WartoscVatOdUpustuDostawy
        {
            get => wartoscVatOdUpustuDostawy;
            set => SetPropertyValue(nameof(WartoscVatOdUpustuDostawy), ref wartoscVatOdUpustuDostawy, value);
        }
        //   "wartoscVatDoplatySerwisowejDostawy": 0,
        [ModelDefault("DisplayFormat", "{0:N2}")]
        [ModelDefault("EditMask", "N2")]
        public decimal WartoscVatDoplatySerwisowejDostawy
        {
            get => wartoscVatDoplatySerwisowejDostawy;
            set => SetPropertyValue(nameof(WartoscVatDoplatySerwisowejDostawy), ref wartoscVatDoplatySerwisowejDostawy, value);
        }
        //   "licznyVatDoplatySerwisowejDostawy": 0,
        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string LicznyVatDoplatySerwisowejDostawy
        {
            get => licznyVatDoplatySerwisowejDostawy;
            set => SetPropertyValue(nameof(LicznyVatDoplatySerwisowejDostawy), ref licznyVatDoplatySerwisowejDostawy, value);
        }
        //   "dataWymagalnosci": "2024-04-15T09:59:24.122Z",
        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public DateTime DataWymagalnosci
        {
            get => dataWymagalnosci;
            set => SetPropertyValue(nameof(DataWymagalnosci), ref dataWymagalnosci, value);
        }
        //   "terminPlatnosci": 0,
        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string TerminPlatnosci
        {
            get => terminPlatnosci;
            set => SetPropertyValue(nameof(TerminPlatnosci), ref terminPlatnosci, value);
        }
        //   "sposobPlatnosci": "string",
        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string SposobPlatnosci
        {
            get => sposobPlatnosci;
            set => SetPropertyValue(nameof(SposobPlatnosci), ref sposobPlatnosci, value);
        }
        //   "tcNumerFaktury": "string",
        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string TcNumerFaktury
        {
            get => tcNumerFaktury;
            set => SetPropertyValue(nameof(TcNumerFaktury), ref tcNumerFaktury, value);
        }
        //   "tcDataFaktury": "2024-04-15T09:59:24.122Z",

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public DateTime TcDataFaktury
        {
            get => tcDataFaktury;
            set => SetPropertyValue(nameof(TcDataFaktury), ref tcDataFaktury, value);
        }
        //   "kategoriaWartosciPlatnosci": "string",
        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string KategoriaWartosciPlatnosci
        {
            get => kategoriaWartosciPlatnosci;
            set => SetPropertyValue(nameof(KategoriaWartosciPlatnosci), ref kategoriaWartosciPlatnosci, value);
        }
        //   "miejscePowstaniaKosztow2": "string",
        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string MiejscePowstaniaKosztow2
        {
            get => miejscePowstaniaKosztow2;
            set => SetPropertyValue(nameof(MiejscePowstaniaKosztow2), ref miejscePowstaniaKosztow2, value);
        }
        //   "nrObcejKarty": "string",
        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string NrObcejKarty
        {
            get => nrObcejKarty;
            set => SetPropertyValue(nameof(NrObcejKarty), ref nrObcejKarty, value);
        }
        //   "identyfikatorUrzadzeniaOBU": "string",
        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string IdentyfikatorUrzadzeniaOBU
        {
            get => identyfikatorUrzadzeniaOBU;
            set => SetPropertyValue(nameof(IdentyfikatorUrzadzeniaOBU), ref identyfikatorUrzadzeniaOBU, value);
        }
        //   "nrRejPojazduSkompresowany": "string",
        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string NrRejPojazduSkompresowany
        {
            get => nrRejPojazduSkompresowany;
            set => SetPropertyValue(nameof(NrRejPojazduSkompresowany), ref nrRejPojazduSkompresowany, value);
        }
        //   "rodzajKarty": "string",
        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string RodzajKarty
        {
            get => rodzajKarty;
            set => SetPropertyValue(nameof(RodzajKarty), ref rodzajKarty, value);
        }
        //   "numerFakturyWgKraju": "string",
        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string NumerFakturyWgKraju
        {
            get => numerFakturyWgKraju;
            set => SetPropertyValue(nameof(NumerFakturyWgKraju), ref numerFakturyWgKraju, value);
        }
        //   "wjazdNaAutostrade": "string",
        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string WjazdNaAutostrade
        {
            get => jazdNaAutostrade;
            set => SetPropertyValue(nameof(jazdNaAutostrade), ref jazdNaAutostrade, value);
        }
        //   "wyjazdZAutostrady": "string",
        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string WyjazdZAutostrady
        {
            get => wyjazdZAutostrady;
            set => SetPropertyValue(nameof(WyjazdZAutostrady), ref wyjazdZAutostrady, value);
        }
        //   "warunkiSpecjalneFRA": 0,
        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string WarunkiSpecjalneFRA
        {
            get => warunkiSpecjalneFRA;
            set => SetPropertyValue(nameof(WarunkiSpecjalneFRA), ref warunkiSpecjalneFRA, value);
        }
        //   "numerNotyObciazeniowej": "string",
        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string NumerNotyObciazeniowej
        {
            get => numerNotyObciazeniowej;
            set => SetPropertyValue(nameof(NumerNotyObciazeniowej), ref numerNotyObciazeniowej, value);
        }
        //   "przedstawiciel": "string",
        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Przedstawiciel
        {
            get => przedstawiciel;
            set => SetPropertyValue(nameof(Przedstawiciel), ref przedstawiciel, value);
        }
        //   "indeks": "string",
        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Indeks
        {
            get => indeks;
            set => SetPropertyValue(nameof(Indeks), ref indeks, value);
        }
        //   "identyfikatorSrodkaPlatnosci": "string",
        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string IdentyfikatorSrodkaPlatnosci
        {
            get => identyfikatorSrodkaPlatnosci;
            set => SetPropertyValue(nameof(identyfikatorSrodkaPlatnosci), ref identyfikatorSrodkaPlatnosci, value);
        }
        //   "kategoriaPodatkowa": "string",
        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string KategoriaPodatkowa
        {
            get => kategoriaPodatkowa;
            set => SetPropertyValue(nameof(KategoriaPodatkowa), ref kategoriaPodatkowa, value);
        }
        //   "numerPokwitowaniaUTA": "string",
        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string NumerPokwitowaniaUTA
        {
            get => numerPokwitowaniaUTA;
            set => SetPropertyValue(nameof(NumerPokwitowaniaUTA), ref numerPokwitowaniaUTA, value);
        }
        //   "dodatkowyNumerPokwitowaniaUTA": "string",

        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        public string DodatkowyNumerPokwitowaniaUTA
        {
            get => dodatkowyNumerPokwitowaniaUTA;
            set => SetPropertyValue(nameof(DodatkowyNumerPokwitowaniaUTA), ref dodatkowyNumerPokwitowaniaUTA, value);
        }
        //   "winietaWaznaOd": "2024-04-15T09:59:24.122Z",
        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public DateTime WinietaWaznaOd
        {
            get => winietaWaznaOd;
            set => SetPropertyValue(nameof(WinietaWaznaOd), ref winietaWaznaOd, value);
        }
        //   "winietaWaznaDo": "2024-04-15T09:59:24.122Z",
        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        public DateTime WinietaWaznaDo
        {
            get => winietaWaznaDo;
            set => SetPropertyValue(nameof(WinietaWaznaDo), ref winietaWaznaDo, value);
        }

        //   "identyfikatorWystawcyUzytkownika": "string",
        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string IdentyfikatorWystawcyUzytkownika
        {
            get => identyfikatorWystawcyUzytkownika;
            set => SetPropertyValue(nameof(IdentyfikatorWystawcyUzytkownika), ref identyfikatorWystawcyUzytkownika, value);
        }
        //   "jednostkaMiary": "string",
        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string JednostkaMiary
        {
            get => jednostkaMiary;
            set => SetPropertyValue(nameof(JednostkaMiary), ref jednostkaMiary, value);
        }
        //   "krajMiejscaDostawy": "string",
        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string KrajMiejscaDostawy
        {
            get => krajMiejscaDostawy;
            set => SetPropertyValue(nameof(KrajMiejscaDostawy), ref krajMiejscaDostawy, value);
        }
        //   "kodPocztowyMiejscaDostawy": "string",
        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string KodPocztowyMiejscaDostawy
        {
            get => kodPocztowyMiejscaDostawy;
            set => SetPropertyValue(nameof(KodPocztowyMiejscaDostawy), ref kodPocztowyMiejscaDostawy, value);
        }
        //   "krajOpodatkowania": "string",
        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string KrajOpodatkowania
        {
            get => krajOpodatkowania;
            set => SetPropertyValue(nameof(KrajOpodatkowania), ref krajOpodatkowania, value);
        }
        //   "podatkowaGrupaProduktowa": "string",
        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string PodatkowaGrupaProduktowa
        {
            get => podatkowaGrupaProduktowa;
            set => SetPropertyValue(nameof(PodatkowaGrupaProduktowa), ref podatkowaGrupaProduktowa, value);
        }
        //   "zmiennoscMiejscaUslug": 0,
        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string ZmiennoscMiejscaUslug
        {
            get => zmiennoscMiejscaUslug;
            set => SetPropertyValue(nameof(ZmiennoscMiejscaUslug), ref zmiennoscMiejscaUslug, value);
        }
        //   "transactionDateAndTime": "2024-04-15T09:59:24.122Z"

        [ModelDefault("DisplayFormat", "{0:g}")]
        [ModelDefault("EditMask", "g")]
        public DateTime TransactionDateAndTime
        {
            get => transactionDateAndTime;
            set => SetPropertyValue(nameof(TransactionDateAndTime), ref transactionDateAndTime, value);
        }


        // }
        //
    }
}

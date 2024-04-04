using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma.Module.BusinessObjects.Kartoteki
{
    [DefaultClassOptions]
    public class Delivery : XPObject
    {
        public Delivery(Session session) : base(session)
        { }

        string identyfikator;
        string voucherNr;
        string uTAVoucherNumber;
        double wartosc;
        double wartoscNetto;
        double cenaJedn;
        double cenaJednostkowaNetto;
        string waluta;
        double ilosc;
        string kodProduktu;
        string produkt;
        string pelnyNumerKarty;
        double nrKarty;
        string kategoriaKarty;
        string miejsceKosztu2;
        string miejsceKosztu;
        int stanLicznika;
        string nrRejestr;
        double stawkaVAT;
        string kodPocztowyStacji;
        string miejscowosc;
        string markaKoncern;
        int punktAkceptacji;
        string kraj;
        DateTime czasDostawy;
        DateTime dataDostawy;
        string nazwaDostawcy;
        int idDostawcy;
        string nazwaKlienta;



        [VisibleInListView(false)]
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Identyfikator
        {
            get => identyfikator;
            set => SetPropertyValue(nameof(Identyfikator), ref identyfikator, value);
        }

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string NazwaKlienta
        {
            get => nazwaKlienta;
            set => SetPropertyValue(nameof(NazwaKlienta), ref nazwaKlienta, value);
        }
        //public int IdDostawcy { get; set; }
        [VisibleInListView(false)]
        public int IdDostawcy
        {
            get => idDostawcy;
            set => SetPropertyValue(nameof(IdDostawcy), ref idDostawcy, value);
        }
        //public string NazwaDostawcy { get; set; }

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string NazwaDostawcy
        {
            get => nazwaDostawcy;
            set => SetPropertyValue(nameof(NazwaDostawcy), ref nazwaDostawcy, value);
        }
        //public DateTime DataDostawy { get; set; }

        public DateTime DataDostawy
        {
            get => dataDostawy;
            set => SetPropertyValue(nameof(DataDostawy), ref dataDostawy, value);
        }
        //public DateTime CzasDostawy { get; set; }
        [VisibleInListView(false)]
        public DateTime CzasDostawy
        {
            get => czasDostawy;
            set => SetPropertyValue(nameof(CzasDostawy), ref czasDostawy, value);
        }
        //public string Kraj { get; set; }

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Kraj
        {
            get => kraj;
            set => SetPropertyValue(nameof(Kraj), ref kraj, value);
        }
        //public int PunktAkceptacji { get; set; }
        [VisibleInListView(false)]
        public int PunktAkceptacji
        {
            get => punktAkceptacji;
            set => SetPropertyValue(nameof(PunktAkceptacji), ref punktAkceptacji, value);
        }
        //public string MarkaKoncern { get; set; }

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string MarkaKoncern
        {
            get => markaKoncern;
            set => SetPropertyValue(nameof(MarkaKoncern), ref markaKoncern, value);
        }
        //public string Miejscowosc { get; set; }

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Miejscowosc

        {
            get => miejscowosc;
            set => SetPropertyValue(nameof(Miejscowosc), ref miejscowosc, value);
        }
        //public string KodPocztowyStacji { get; set; }

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string KodPocztowyStacji
        {
            get => kodPocztowyStacji;
            set => SetPropertyValue(nameof(KodPocztowyStacji), ref kodPocztowyStacji, value);
        }
        //public double StawkaVAT { get; set; }
        [VisibleInListView(false)]
        public double StawkaVAT
        {
            get => stawkaVAT;
            set => SetPropertyValue(nameof(StawkaVAT), ref stawkaVAT, value);
        }
        //public string NrRejestr { get; set; }

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string NrRejestr
        {
            get => nrRejestr;
            set => SetPropertyValue(nameof(NrRejestr), ref nrRejestr, value);
        }
        //public int StanLicznika { get; set; }
        [VisibleInListView(false)]
        public int StanLicznika
        {
            get => stanLicznika;
            set => SetPropertyValue(nameof(StanLicznika), ref stanLicznika, value);
        }
        //public string MiejsceKosztu { get; set; }
        [VisibleInListView(false)]
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string MiejsceKosztu
        {
            get => miejsceKosztu;
            set => SetPropertyValue(nameof(MiejsceKosztu), ref miejsceKosztu, value);
        }
        //public string MiejsceKosztu2 { get; set; }
        [VisibleInListView(false)]
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string MiejsceKosztu2
        {
            get => miejsceKosztu2;
            set => SetPropertyValue(nameof(MiejsceKosztu2), ref miejsceKosztu2, value);
        }
        //public string KategoriaKarty { get; set; }
        [VisibleInListView(false)]
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string KategoriaKarty
        {
            get => kategoriaKarty;
            set => SetPropertyValue(nameof(KategoriaKarty), ref kategoriaKarty, value);
        }
        //public double NrKarty { get; set; }

        public double NrKarty
        {
            get => nrKarty;
            set => SetPropertyValue(nameof(NrKarty), ref nrKarty, value);
        }
        //public string PelnyNumerKarty { get; set; }
        [VisibleInListView(false)]
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string PelnyNumerKarty
        {
            get => pelnyNumerKarty;
            set => SetPropertyValue(nameof(PelnyNumerKarty), ref pelnyNumerKarty, value);
        }
        //public string Produkt { get; set; }

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Produkt

        {
            get => produkt;
            set => SetPropertyValue(nameof(Produkt), ref produkt, value);
        }
        //public string KodProduktu { get; set; }

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string KodProduktu

        {
            get => kodProduktu;
            set => SetPropertyValue(nameof(KodProduktu), ref kodProduktu, value);
        }
        //public double Ilosc { get; set; }

        public double Ilosc
        {
            get => ilosc;
            set => SetPropertyValue(nameof(Ilosc), ref ilosc, value);
        }
        //public string Waluta { get; set; }

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Waluta
        {
            get => waluta;
            set => SetPropertyValue(nameof(Waluta), ref waluta, value);
        }
        //public double CenaJednostkowaNetto { get; set; }
        [VisibleInListView(false)]
        public double CenaJednostkowaNetto
        {
            get => cenaJednostkowaNetto;
            set => SetPropertyValue(nameof(CenaJednostkowaNetto), ref cenaJednostkowaNetto, value);
        }
        //public double CenaJedn { get; set; }

        public double CenaJedn

        {
            get => cenaJedn;
            set => SetPropertyValue(nameof(CenaJedn), ref cenaJedn, value);
        }
        //public double WartoscNetto { get; set; }
        [VisibleInListView(false)]
        public double WartoscNetto
        {
            get => wartoscNetto;
            set => SetPropertyValue(nameof(WartoscNetto), ref wartoscNetto, value);
        }
        //public double Wartosc { get; set; }
        [XafDisplayName("Wartość brutto")]
        public double Wartosc
        {
            get => wartosc;
            set => SetPropertyValue(nameof(Wartosc), ref wartosc, value);
        }
        //public string UTAVoucherNumber { get; set; }
        [VisibleInListView(false)]
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string UTAVoucherNumber
        {
            get => uTAVoucherNumber;
            set => SetPropertyValue(nameof(UTAVoucherNumber), ref uTAVoucherNumber, value);
        }
        //public string VoucherNr { get; set; }
        [VisibleInListView(false)]
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string VoucherNr
        {
            get => voucherNr;
            set => SetPropertyValue(nameof(VoucherNr), ref voucherNr, value);
        }

    }
}

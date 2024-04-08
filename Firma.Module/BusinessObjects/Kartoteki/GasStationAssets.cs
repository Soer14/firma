using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma.Module.BusinessObjects.Kartoteki
{
    [DefaultClassOptions]
    [XafDefaultProperty(nameof(Name))]
    [NavigationItem("Kartoteki")]
    [XafDisplayName("Wyposażenie stacji paliw")]
    public class GasStationAssets : XPLiteObject
    {
        public GasStationAssets(Session session) : base(session) { }

        private string tankstelle;
        [XafDisplayName("Stacja paliw")]
        public string Tankstelle
        {
            get { return tankstelle; }
            set { SetPropertyValue(nameof(Tankstelle), ref tankstelle, value); }
        }

        private string werkstatt;
        [XafDisplayName("Warsztat")]
        public string Werkstatt
        {
            get { return werkstatt; }
            set { SetPropertyValue(nameof(Werkstatt), ref werkstatt, value); }
        }

        private string reinigung;
        [XafDisplayName("Czyszczenie")]
        public string Reinigung
        {
            get { return reinigung; }
            set { SetPropertyValue(nameof(Reinigung), ref reinigung, value); }
        }

        
        private int akzNr;
        [Key(false)]
        [XafDisplayName("Akz Nr.")]
        public int AkzNr
        {
            get { return akzNr; }
            set { SetPropertyValue(nameof(AkzNr), ref akzNr, value); }
        }

        

        private string marke;
        [XafDisplayName("Marka")]
        public string Marke
        {
            get { return marke; }
            set { SetPropertyValue(nameof(Marke), ref marke, value); }
        }

        private string name;
        [XafDisplayName("Nazwa")]
        public string Name
        {
            get { return name; }
            set { SetPropertyValue(nameof(Name), ref name, value); }
        }

        private string land;
        [XafDisplayName("Kraj")]
        public string Land
        {
            get { return land; }
            set { SetPropertyValue(nameof(Land), ref land, value); }
        }

        private string zip;
        [XafDisplayName("Kod pocztowy")]
        public string ZIP
        {
            get { return zip; }
            set { SetPropertyValue(nameof(ZIP), ref zip, value); }
        }

        private string ort;
        [XafDisplayName("Miejscowość")]
        public string Ort
        {
            get { return ort; }
            set { SetPropertyValue(nameof(Ort), ref ort, value); }
        }

        private string anschrift;
        [XafDisplayName("Adres")]
        public string Anschrift
        {
            get { return anschrift; }
            set { SetPropertyValue(nameof(Anschrift), ref anschrift, value); }
        }

        private string telefonNr;
        [XafDisplayName("Numer telefonu")]
        public string TelefonNr
        {
            get { return telefonNr; }
            set { SetPropertyValue(nameof(TelefonNr), ref telefonNr, value); }
        }

        private string selectStation;
        [XafDisplayName("Stacja wyboru")]
        public string SelectStation
        {
            get { return selectStation; }
            set { SetPropertyValue(nameof(SelectStation), ref selectStation, value); }
        }

        private bool h24Service;
        [XafDisplayName("Usługa 24h")]
        public bool H24Service
        {
            get { return h24Service; }
            set { SetPropertyValue(nameof(H24Service), ref h24Service, value); }
        }

        private bool docStop;
        [XafDisplayName("DocStop")]
        public bool DocStop
        {
            get { return docStop; }
            set { SetPropertyValue(nameof(DocStop), ref docStop, value); }
        }

        private bool naheAutobahn;
        [XafDisplayName("Blisko autostrady")]
        public bool NaheAutobahn
        {
            get { return naheAutobahn; }
            set { SetPropertyValue(nameof(NaheAutobahn), ref naheAutobahn, value); }
        }

        private bool autobahnTS;
        [XafDisplayName("Autostrada TS")]
        public bool AutobahnTS
        {
            get { return autobahnTS; }
            set { SetPropertyValue(nameof(AutobahnTS), ref autobahnTS, value); }
        }

        private string autohof;
        [XafDisplayName("Autohof")]
        public string Autohof
        {
            get { return autohof; }
            set { SetPropertyValue(nameof(Autohof), ref autohof, value); }
        }

        private string hochleistungszapfsaule;
        [XafDisplayName("Stacja wysokowydajna")]
        public string Hochleistungszapfsaule
        {
            get { return hochleistungszapfsaule; }
            set { SetPropertyValue(nameof(Hochleistungszapfsaule), ref hochleistungszapfsaule, value); }
        }

        private string sondertankpunkt;
        [XafDisplayName("Stacja specjalna")]
        public string Sondertankpunkt
        {
            get { return sondertankpunkt; }
            set { SetPropertyValue(nameof(Sondertankpunkt), ref sondertankpunkt, value); }
        }

        private string aralSondertankpunkt;
        [XafDisplayName("Stacja specjalna Aral")]
        public string AralSondertankpunkt
        {
            get { return aralSondertankpunkt; }
            set { SetPropertyValue(nameof(AralSondertankpunkt), ref aralSondertankpunkt, value); }
        }

        private string utaEmpfehlung;
        [XafDisplayName("Rekomendacja UTA")]
        public string UtaEmpfehlung
        {
            get { return utaEmpfehlung; }
            set { SetPropertyValue(nameof(UtaEmpfehlung), ref utaEmpfehlung, value); }
        }

        private string elektrFuhrerscheinkontrolle;
        [XafDisplayName("Kontrola elektroniczna prawa jazdy")]
        public string ElektrFuhrerscheinkontrolle
        {
            get { return elektrFuhrerscheinkontrolle; }
            set { SetPropertyValue(nameof(ElektrFuhrerscheinkontrolle), ref elektrFuhrerscheinkontrolle, value); }
        }

        private string parkplatz;
        [XafDisplayName("Parking")]
        public string Parkplatz
        {
            get { return parkplatz; }
            set { SetPropertyValue(nameof(Parkplatz), ref parkplatz, value); }
        }

        private string parkplatzbewachung;
        [XafDisplayName("Ochrona parkingu")]
        public string Parkplatzbewachung
        {
            get { return parkplatzbewachung; }
            set { SetPropertyValue(nameof(Parkplatzbewachung), ref parkplatzbewachung, value); }
        }

        private string restaurant;
        [XafDisplayName("Restauracja")]
        public string Restaurant
        {
            get { return restaurant; }
            set { SetPropertyValue(nameof(Restaurant), ref restaurant, value); }
        }

        private string imbiss;
        [XafDisplayName("Bufet")]
        public string Imbiss
        {
            get { return imbiss; }
            set { SetPropertyValue(nameof(Imbiss), ref imbiss, value); }
        }

        private string fahrerwaschraum;
        [XafDisplayName("Toaleta dla kierowców")]
        public string Fahrerwaschraum
        {
            get { return fahrerwaschraum; }
            set { SetPropertyValue(nameof(Fahrerwaschraum), ref fahrerwaschraum, value); }
        }

        private string goBoxVertriebsstelle;
        [XafDisplayName("Punkt dystrybucji GO Box")]
        public string GoBoxVertriebsstelle
        {
            get { return goBoxVertriebsstelle; }
            set { SetPropertyValue(nameof(GoBoxVertriebsstelle), ref goBoxVertriebsstelle, value); }
        }

        private string mautterminal;
        [XafDisplayName("Terminal opłat drogowych")]
        public string Mautterminal
        {
            get { return mautterminal; }
            set { SetPropertyValue(nameof(Mautterminal), ref mautterminal, value); }
        }

        private string obuEinbauservice;
        [XafDisplayName("Usługa montażu OBU")]
        public string ObuEinbauservice
        {
            get { return obuEinbauservice; }
            set { SetPropertyValue(nameof(ObuEinbauservice), ref obuEinbauservice, value); }
        }

        private string automatGanz;
        [XafDisplayName("Automat w pełni")]
        public string AutomatGanz
        {
            get { return automatGanz; }
            set { SetPropertyValue(nameof(AutomatGanz), ref automatGanz, value); }
        }

        private string automatTeilweise;
        [XafDisplayName("Automat częściowo")]
        public string AutomatTeilweise
        {
            get { return automatTeilweise; }
            set { SetPropertyValue(nameof(AutomatTeilweise), ref automatTeilweise, value); }
        }

        private string adBlueKanister;
        [XafDisplayName("Kanister AdBlue")]
        public string AdBlueKanister
        {
            get { return adBlueKanister; }
            set { SetPropertyValue(nameof(AdBlueKanister), ref adBlueKanister, value); }
        }

        private string adBlueZapfsaule;
        [XafDisplayName("Stacja tankowania AdBlue")]
        public string AdBlueZapfsaule
        {
            get { return adBlueZapfsaule; }
            set { SetPropertyValue(nameof(AdBlueZapfsaule), ref adBlueZapfsaule, value); }
        }

        private string autogas;
        [XafDisplayName("Gaz samochodowy")]
        public string Autogas
        {
            get { return autogas; }
            set { SetPropertyValue(nameof(Autogas), ref autogas, value); }
        }

        private string biodiesel;
        [XafDisplayName("Biodiesel")]
        public string Biodiesel
        {
            get { return biodiesel; }
            set { SetPropertyValue(nameof(Biodiesel), ref biodiesel, value); }
        }

        private string erdgas;
        [XafDisplayName("Gaz ziemny")]
        public string Erdgas
        {
            get { return erdgas; }
            set { SetPropertyValue(nameof(Erdgas), ref erdgas, value); }
        }

        private string pflanzenol;
        [XafDisplayName("Olej roślinny")]
        public string Pflanzenol
        {
            get { return pflanzenol; }
            set { SetPropertyValue(nameof(Pflanzenol), ref pflanzenol, value); }
        }

        private string flussigerdgas;
        [XafDisplayName("Płynny gaz ziemny")]
        public string Flussigerdgas
        {
            get { return flussigerdgas; }
            set { SetPropertyValue(nameof(Flussigerdgas), ref flussigerdgas, value); }
        }

        private string hvo100;
        [XafDisplayName("HVO100")]
        public string HVO100
        {
            get { return hvo100; }
            set { SetPropertyValue(nameof(HVO100), ref hvo100, value); }
        }

        private string lkwAussenreinigung;
        [XafDisplayName("Myjnia zewnętrzna dla ciężarówek")]
        public string LkwAussenreinigung
        {
            get { return lkwAussenreinigung; }
            set { SetPropertyValue(nameof(LkwAussenreinigung), ref lkwAussenreinigung, value); }
        }

        private string tankwagenInnenreinigung;
        [XafDisplayName("Myjnia wewnętrzna dla cystern")]
        public string TankwagenInnenreinigung
        {
            get { return tankwagenInnenreinigung; }
            set { SetPropertyValue(nameof(TankwagenInnenreinigung), ref tankwagenInnenreinigung, value); }
        }

        private string silofahrzeugInnenreinigung;
        [XafDisplayName("Myjnia wewnętrzna dla cystern siodłowych")]
        public string SilofahrzeugInnenreinigung
        {
            get { return silofahrzeugInnenreinigung; }
            set { SetPropertyValue(nameof(SilofahrzeugInnenreinigung), ref silofahrzeugInnenreinigung, value); }
        }

        private string kuhlfahrzeugInnenreinigung;
        [XafDisplayName("Myjnia wewnętrzna dla pojazdów chłodniczych")]
        public string KuhlfahrzeugInnenreinigung
        {
            get { return kuhlfahrzeugInnenreinigung; }
            set { SetPropertyValue(nameof(KuhlfahrzeugInnenreinigung), ref kuhlfahrzeugInnenreinigung, value); }
        }

        private string lebensmittelfahrzeugInnenreinigung;
        [XafDisplayName("Myjnia wewnętrzna dla pojazdów spożywczych")]
        public string LebensmittelfahrzeugInnenreinigung
        {
            get { return lebensmittelfahrzeugInnenreinigung; }
            set { SetPropertyValue(nameof(LebensmittelfahrzeugInnenreinigung), ref lebensmittelfahrzeugInnenreinigung, value); }
        }

        private string geocodierung;
        [XafDisplayName("Geokodowanie")]
        public string Geocodierung
        {
            get { return geocodierung; }
            set { SetPropertyValue(nameof(Geocodierung), ref geocodierung, value); }
        }

        private string lieferantennr;
        [XafDisplayName("Numer dostawcy")]
        public string Lieferantennr
        {
            get { return lieferantennr; }
            set { SetPropertyValue(nameof(Lieferantennr), ref lieferantennr, value); }
        }

        private string supplier;
        [XafDisplayName("Dostawca")]
        public string Supplier
        {
            get { return supplier; }
            set { SetPropertyValue(nameof(Supplier), ref supplier, value); }
        }

        private string preiszone;
        [XafDisplayName("Strefa cenowa")]
        public string Preiszone
        {
            get { return preiszone; }
            set { SetPropertyValue(nameof(Preiszone), ref preiszone, value); }
        }
    }
}

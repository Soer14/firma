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

        private bool tankstelle;
        [XafDisplayName("Stacja paliw")]
        [VisibleInListView(false)]
        public bool Tankstelle
        {
            get { return tankstelle; }
            set { SetPropertyValue(nameof(Tankstelle), ref tankstelle, value); }
        }

        private int werkstatt;
        [XafDisplayName("Warsztat")]
        [VisibleInListView(false)]
        public int Werkstatt
        {
            get { return werkstatt; }
            set { SetPropertyValue(nameof(Werkstatt), ref werkstatt, value); }
        }

        private bool reinigung;
        [XafDisplayName("Czyszczenie")]
        [VisibleInListView(false)]
        public bool Reinigung
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

        private bool selectStation;
        [XafDisplayName("Stacja Select")]
        [VisibleInListView(false)]
        public bool SelectStation
        {
            get { return selectStation; }
            set { SetPropertyValue(nameof(SelectStation), ref selectStation, value); }
        }

        private bool h24Service;
        [XafDisplayName("Usługa 24h")]
        [VisibleInListView(false)]
        public bool H24Service
        {
            get { return h24Service; }
            set { SetPropertyValue(nameof(H24Service), ref h24Service, value); }
        }

        private bool docStop;
        [XafDisplayName("DocStop")]
        [VisibleInListView(false)]
        public bool DocStop
        {
            get { return docStop; }
            set { SetPropertyValue(nameof(DocStop), ref docStop, value); }
        }

        private bool naheAutobahn;
        [XafDisplayName("Blisko autostrady")]
        [VisibleInListView(false)]
        public bool NaheAutobahn
        {
            get { return naheAutobahn; }
            set { SetPropertyValue(nameof(NaheAutobahn), ref naheAutobahn, value); }
        }

        private bool autobahnTS;
        [XafDisplayName("Autostrada TS")]
        [VisibleInListView(false)]
        public bool AutobahnTS
        {
            get { return autobahnTS; }
            set { SetPropertyValue(nameof(AutobahnTS), ref autobahnTS, value); }
        }

        private bool autohof;
        [XafDisplayName("Autohof")]
        [VisibleInListView(false)]
        public bool Autohof
        {
            get { return autohof; }
            set { SetPropertyValue(nameof(Autohof), ref autohof, value); }
        }

        private bool hochleistungszapfsaule;
        [XafDisplayName("Stacja wysokowydajna")]
        [VisibleInListView(false)]
        public bool Hochleistungszapfsaule
        {
            get { return hochleistungszapfsaule; }
            set { SetPropertyValue(nameof(Hochleistungszapfsaule), ref hochleistungszapfsaule, value); }
        }

        private bool sondertankpunkt;
        [XafDisplayName("Stacja specjalna")]
        [VisibleInListView(false)]
        public bool Sondertankpunkt
        {
            get { return sondertankpunkt; }
            set { SetPropertyValue(nameof(Sondertankpunkt), ref sondertankpunkt, value); }
        }

        private bool aralSondertankpunkt;
        [XafDisplayName("Stacja specjalna Aral")]
        [VisibleInListView(false)]
        public bool AralSondertankpunkt
        {
            get { return aralSondertankpunkt; }
            set { SetPropertyValue(nameof(AralSondertankpunkt), ref aralSondertankpunkt, value); }
        }

        private bool utaEmpfehlung;
        [XafDisplayName("Rekomendacja UTA")]
        [VisibleInListView(false)]
        public bool UtaEmpfehlung
        {
            get { return utaEmpfehlung; }
            set { SetPropertyValue(nameof(UtaEmpfehlung), ref utaEmpfehlung, value); }
        }

        private bool elektrFuhrerscheinkontrolle;
        [XafDisplayName("Kontrola elektroniczna prawa jazdy")]
        [VisibleInListView(false)]
        public bool ElektrFuhrerscheinkontrolle
        {
            get { return elektrFuhrerscheinkontrolle; }
            set { SetPropertyValue(nameof(ElektrFuhrerscheinkontrolle), ref elektrFuhrerscheinkontrolle, value); }
        }

        private bool parkplatz;
        [XafDisplayName("Parking")]
        [VisibleInListView(false)]
        public bool Parkplatz
        {
            get { return parkplatz; }
            set { SetPropertyValue(nameof(Parkplatz), ref parkplatz, value); }
        }

        private bool parkplatzbewachung;
        [XafDisplayName("Ochrona parkingu")]
        [VisibleInListView(false)]
        public bool Parkplatzbewachung
        {
            get { return parkplatzbewachung; }
            set { SetPropertyValue(nameof(Parkplatzbewachung), ref parkplatzbewachung, value); }
        }

        private bool restaurant;
        [XafDisplayName("Restauracja")]
        [VisibleInListView(false)]
        public bool Restaurant
        {
            get { return restaurant; }
            set { SetPropertyValue(nameof(Restaurant), ref restaurant, value); }
        }

        private bool imbiss;
        [XafDisplayName("Bufet")]
        [VisibleInListView(false)]
        public bool Imbiss
        {
            get { return imbiss; }
            set { SetPropertyValue(nameof(Imbiss), ref imbiss, value); }
        }

        private bool fahrerwaschraum;
        [XafDisplayName("Toaleta dla kierowców")]
        [VisibleInListView(false)]
        public bool Fahrerwaschraum
        {
            get { return fahrerwaschraum; }
            set { SetPropertyValue(nameof(Fahrerwaschraum), ref fahrerwaschraum, value); }
        }

        private bool goBoxVertriebsstelle;
        [XafDisplayName("Punkt dystrybucji GO Box")]
        [VisibleInListView(false)]
        public bool GoBoxVertriebsstelle
        {
            get { return goBoxVertriebsstelle; }
            set { SetPropertyValue(nameof(GoBoxVertriebsstelle), ref goBoxVertriebsstelle, value); }
        }

        private bool mautterminal;
        [XafDisplayName("Terminal opłat drogowych")]
        [VisibleInListView(false)]
        public bool Mautterminal
        {
            get { return mautterminal; }
            set { SetPropertyValue(nameof(Mautterminal), ref mautterminal, value); }
        }

        private bool obuEinbauservice;
        [XafDisplayName("Usługa montażu OBU")]
        [VisibleInListView(false)]
        public bool ObuEinbauservice
        {
            get { return obuEinbauservice; }
            set { SetPropertyValue(nameof(ObuEinbauservice), ref obuEinbauservice, value); }
        }

        private bool automatGanz;
        [XafDisplayName("Automat w pełni")]
        [VisibleInListView(false)]
        public bool AutomatGanz
        {
            get { return automatGanz; }
            set { SetPropertyValue(nameof(AutomatGanz), ref automatGanz, value); }
        }

        private bool automatTeilweise;
        [XafDisplayName("Automat częściowo")]
        [VisibleInListView(false)]
        public bool AutomatTeilweise
        {
            get { return automatTeilweise; }
            set { SetPropertyValue(nameof(AutomatTeilweise), ref automatTeilweise, value); }
        }

        private bool adBlueKanister;
        [XafDisplayName("Kanister AdBlue")]
        [VisibleInListView(false)]
        public bool AdBlueKanister
        {
            get { return adBlueKanister; }
            set { SetPropertyValue(nameof(AdBlueKanister), ref adBlueKanister, value); }
        }

        private bool adBlueZapfsaule;
        [XafDisplayName("Stacja tankowania AdBlue")]
        [VisibleInListView(false)]
        public bool AdBlueZapfsaule
        {
            get { return adBlueZapfsaule; }
            set { SetPropertyValue(nameof(AdBlueZapfsaule), ref adBlueZapfsaule, value); }
        }

        private bool autogas;
        [XafDisplayName("Gaz samochodowy")]
        [VisibleInListView(false)]
        public bool Autogas
        {
            get { return autogas; }
            set { SetPropertyValue(nameof(Autogas), ref autogas, value); }
        }

        private bool biodiesel;
        [XafDisplayName("Biodiesel")]
        [VisibleInListView(false)]
        public bool Biodiesel
        {
            get { return biodiesel; }
            set { SetPropertyValue(nameof(Biodiesel), ref biodiesel, value); }
        }

        private bool erdgas;
        [XafDisplayName("Gaz ziemny")]
        [VisibleInListView(false)]
        public bool Erdgas
        {
            get { return erdgas; }
            set { SetPropertyValue(nameof(Erdgas), ref erdgas, value); }
        }

        private bool pflanzenol;
        [XafDisplayName("Olej roślinny")]
        [VisibleInListView(false)]
        public bool Pflanzenol
        {
            get { return pflanzenol; }
            set { SetPropertyValue(nameof(Pflanzenol), ref pflanzenol, value); }
        }

        private bool flussigerdgas;
        [XafDisplayName("Płynny gaz ziemny")]
        [VisibleInListView(false)]
        public bool Flussigerdgas
        {
            get { return flussigerdgas; }
            set { SetPropertyValue(nameof(Flussigerdgas), ref flussigerdgas, value); }
        }

        private bool hvo100;
        [XafDisplayName("HVO100")]
        [VisibleInListView(false)]
        public bool HVO100
        {
            get { return hvo100; }
            set { SetPropertyValue(nameof(HVO100), ref hvo100, value); }
        }

        private bool lkwAussenreinigung;
        [XafDisplayName("Myjnia zewnętrzna dla ciężarówek")]
        [VisibleInListView(false)]
        public bool LkwAussenreinigung
        {
            get { return lkwAussenreinigung; }
            set { SetPropertyValue(nameof(LkwAussenreinigung), ref lkwAussenreinigung, value); }
        }

        private bool tankwagenInnenreinigung;
        [XafDisplayName("Myjnia wewnętrzna dla cystern")]
        [VisibleInListView(false)]
        public bool TankwagenInnenreinigung
        {
            get { return tankwagenInnenreinigung; }
            set { SetPropertyValue(nameof(TankwagenInnenreinigung), ref tankwagenInnenreinigung, value); }
        }

        private bool silofahrzeugInnenreinigung;
        [XafDisplayName("Myjnia wewnętrzna dla cystern siodłowych")]
        [VisibleInListView(false)]
        public bool SilofahrzeugInnenreinigung
        {
            get { return silofahrzeugInnenreinigung; }
            set { SetPropertyValue(nameof(SilofahrzeugInnenreinigung), ref silofahrzeugInnenreinigung, value); }
        }

        private bool kuhlfahrzeugInnenreinigung;
        [XafDisplayName("Myjnia wewnętrzna dla pojazdów chłodniczych")]
        [VisibleInListView(false)]
        public bool KuhlfahrzeugInnenreinigung
        {
            get { return kuhlfahrzeugInnenreinigung; }
            set { SetPropertyValue(nameof(KuhlfahrzeugInnenreinigung), ref kuhlfahrzeugInnenreinigung, value); }
        }

        private bool lebensmittelfahrzeugInnenreinigung;
        [XafDisplayName("Myjnia wewnętrzna dla pojazdów spożywczych")]
        [VisibleInListView(false)]
        public bool LebensmittelfahrzeugInnenreinigung
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

        private int lieferantennr;
        [XafDisplayName("Numer dostawcy")]
        public int Lieferantennr
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

      
    }
}

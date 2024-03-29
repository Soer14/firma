using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma.Module.BusinessObjects.Kartoteki
{
    [DefaultClassOptions]
    [XafDefaultProperty(nameof(StationName))]
    [NavigationItem("Kartoteki")]
    public class GasStation : XPCustomObject
    {
        public GasStation(Session session) : base(session)
        { }

        //public int StationNumber { get; set; }

        string priceZone;
        DateTime validTo;
        DateTime validFrom;
        bool hotSpot;
        bool omrStation;
        string latitude;
        string longitude;
        bool zeroServiceFee;
        double serviceSurcharge;
        string companyName;
        string address;
        string city;
        Currency currency;
        string comments;
        Country country;
        string stationName;
        int stationNumber;
        [Key]
        public int StationNumber
        {
            get => stationNumber;
            set => SetPropertyValue(nameof(StationNumber), ref stationNumber, value);
        }
        //public string StationName { get; set; }

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string StationName
        {
            get => stationName;
            set => SetPropertyValue(nameof(StationName), ref stationName, value);
        }
        //public string Country { get; set; }

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public Country Country
        {
            get => country;
            set => SetPropertyValue(nameof(Country), ref country, value);
        }
        //public string Comments { get; set; }

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Comments
        {
            get => comments;
            set => SetPropertyValue(nameof(Comments), ref comments, value);
        }
        //public string Currency { get; set; }

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public Currency Currency
        {
            get => currency;
            set => SetPropertyValue(nameof(Currency), ref currency, value);
        }
        //public string City { get; set; }

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string City
        {
            get => city;
            set => SetPropertyValue(nameof(City), ref city, value);
        }
        //public string Address { get; set; }

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Address
        {
            get => address;
            set => SetPropertyValue(nameof(Address), ref address, value);
        }
        //public string CompanyName { get; set; }

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string CompanyName
        {
            get => companyName;
            set => SetPropertyValue(nameof(CompanyName), ref companyName, value);
        }
        //public double ServiceSurcharge { get; set; }
        [Browsable(false)]
        public double ServiceSurcharge
        {
            get => serviceSurcharge;
            set => SetPropertyValue(nameof(ServiceSurcharge), ref serviceSurcharge, value);
        }
        //public bool ZeroServiceFee { get; set; }
        [Browsable(false)]
        public bool ZeroServiceFee
        {
            get => zeroServiceFee;
            set => SetPropertyValue(nameof(ZeroServiceFee), ref zeroServiceFee, value);
        }
        //public string Longitude { get; set; }

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Longitude
        {
            get => longitude;
            set => SetPropertyValue(nameof(Longitude), ref longitude, value);
        }
        //public string Latitude { get; set; }

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Latitude
        {
            get => latitude;
            set => SetPropertyValue(nameof(Latitude), ref latitude, value);
        }
        //public bool OmrStation { get; set; }
        [Browsable(false)]
        public bool OmrStation
        {
            get => omrStation;
            set => SetPropertyValue(nameof(OmrStation), ref omrStation, value);
        }
        //public bool HotSpot { get; set; }
        [Browsable(false)]
        public bool HotSpot
        {
            get => hotSpot;
            set => SetPropertyValue(nameof(HotSpot), ref hotSpot, value);
        }
        //public DateTime ValidFrom { get; set; }

        public DateTime ValidFrom
        {
            get => validFrom;
            set => SetPropertyValue(nameof(ValidFrom), ref validFrom, value);
        }
        //public DateTime ValidTo { get; set; }

        public DateTime ValidTo
        {
            get => validTo;
            set => SetPropertyValue(nameof(ValidTo), ref validTo, value);
        }
        //public string PriceZone { get; set; }
        [Browsable(false)]
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string PriceZone
        {
            get => priceZone;
            set => SetPropertyValue(nameof(PriceZone), ref priceZone, value);
        }

    }
}

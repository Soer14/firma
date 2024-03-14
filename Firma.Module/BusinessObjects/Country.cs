using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma.Module.BusinessObjects
{
    [DefaultClassOptions]
    [DefaultProperty(nameof(Symbol))]
    public class Country : XPCustomObject
    {
        public Country(Session session) : base(session)
        { }


        [Size(3)]
        [Key]
        public string Symbol
        {
            get => symbol;
            set => SetPropertyValue(nameof(Symbol), ref symbol, value);
        }

        bool isMetric;
        Currency waluta;
        int geoId;
        string symbol;
        string nazwa;



        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string EnglishName
        {
            get => nazwa;
            set => SetPropertyValue(nameof(EnglishName), ref nazwa, value);
        }

        string lokalnaNazwa;
        string lokalnySymbol;
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string NativeSymbol
        {
            get => lokalnySymbol;
            set => SetPropertyValue(nameof(NativeSymbol), ref lokalnySymbol, value);
        }

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string NativeName
        {
            get => lokalnaNazwa;
            set => SetPropertyValue(nameof(NativeName), ref lokalnaNazwa, value);
        }

        public int GeoId
        {
            get => geoId;
            set => SetPropertyValue(nameof(GeoId), ref geoId, value);
        }


        public Currency Currency
        {
            get => waluta;
            set => SetPropertyValue(nameof(Currency), ref waluta, value);
        }

        public bool IsMetric
        {
            get => isMetric;
            set => SetPropertyValue(nameof(IsMetric), ref isMetric, value);
        }
    }
}

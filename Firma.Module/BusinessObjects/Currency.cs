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
    public class Currency : XPCustomObject
    {
        public Currency(Session session) : base(session)
        { }


        Country kraj;
        string symbol;
        string nazwa;


        [Size(3)]
        [Key]
        public string Symbol
        {
            get => symbol;
            set => SetPropertyValue(nameof(Symbol), ref symbol, value);
        }


        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string EnglishName
        {
            get => nazwa;
            set => SetPropertyValue(nameof(EnglishName), ref nazwa, value);
        }

        public Country Country
        {
            get => kraj;
            set => SetPropertyValue(nameof(Country), ref kraj, value);
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
    }
}

using DevExpress.ExpressApp.DC;
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
    [XafDefaultProperty(nameof(Symbol))]
    public class VatRate : BaseObject
    {
        public VatRate(Session session) : base(session)
        { }


        decimal rateValue;
        string symbol;

        [Size(3)]
        public string Symbol
        {
            get => symbol;
            set => SetPropertyValue(nameof(Symbol), ref symbol, value);
        }
        
        public decimal RateValue
        {
            get => rateValue;
            set => SetPropertyValue(nameof(RateValue), ref rateValue, value);
        }
    }
}

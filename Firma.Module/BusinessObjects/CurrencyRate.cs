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
    public class CurrencyRate : BaseObject
    {
        public CurrencyRate(Session session) : base(session)
        { }

        Currency currency;
        decimal ask;
        decimal bid;
        DateTime effectiveDate;

        public DateTime EffectiveDate
        {
            get => effectiveDate;
            set => SetPropertyValue(nameof(EffectiveDate), ref effectiveDate, value);
        }

        public decimal Bid
        {
            get => bid;
            set => SetPropertyValue(nameof(Bid), ref bid, value);
        }

        public decimal Ask
        {
            get => ask;
            set => SetPropertyValue(nameof(Ask), ref ask, value);
        }
        
        [Association]
        public Currency Currency
        {
            get => currency;
            set => SetPropertyValue(nameof(Currency), ref currency, value);
        }

    }
}

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
    public class CurrencyRate : BaseObject
    {
        public CurrencyRate(Session session) : base(session)
        { }

        decimal mid;
        Currency currency;
        decimal ask;
        decimal bid;
        DateTime effectiveDate;

        public DateTime EffectiveDate
        {
            get => effectiveDate;
            set => SetPropertyValue(nameof(EffectiveDate), ref effectiveDate, value);
        }
        [ModelDefault("DisplayFormat", "{0:N4}")]
        [ModelDefault("EditMask", "N4")]
        public decimal Bid
        {
            get => bid;
            set => SetPropertyValue(nameof(Bid), ref bid, value);
        }
        [ModelDefault("DisplayFormat", "{0:N4}")]
        [ModelDefault("EditMask", "N4")]
        public decimal Ask
        {
            get => ask;
            set => SetPropertyValue(nameof(Ask), ref ask, value);
        }
        [ModelDefault("DisplayFormat", "{0:N4}")]
        [ModelDefault("EditMask", "N4")]
        public decimal Mid
        {
            get => mid;
            set => SetPropertyValue(nameof(Mid), ref mid, value);
        }

        [Association]
        public Currency Currency
        {
            get => currency;
            set => SetPropertyValue(nameof(Currency), ref currency, value);
        }

    }
}

using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using NBPClient;
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
    [NavigationItem("Słowniki")]
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
        [Association]
        public XPCollection<CurrencyRate> CurrencyRates
        {
            get
            {
                return GetCollection<CurrencyRate>(nameof(CurrencyRates));
            }
        }
        [Action(AutoCommit = true, Caption = "Get Rates from A Table", ImageName = "BO_Skull")]
        public void GetRatesA()
        {
            try
            {
                var rates = NBPClient.NBPClient.GetRates("A", Symbol, 50);

                foreach (var rate in rates)
                {
                    var record = CurrencyRates.Where(r => r.EffectiveDate == rate.EffectiveDate).FirstOrDefault();
                    if (record is null)
                    {
                        record = new CurrencyRate(Session);
                        record.Currency = this;
                        record.EffectiveDate = rate.EffectiveDate;
                        CurrencyRates.Add(record);
                    }
                        record.Mid = rate.Mid;
                       
                    
                }
            }
            catch (Exception)
            {

                //throw new FriendlyException();
            }
        }
        [Action(AutoCommit = true, Caption = "Get Rates from B Table", ImageName = "BO_Skull")]
        public void GetRatesB()
        {
            try
            {
                var rates = NBPClient.NBPClient.GetRates("B",Symbol, 50);

                foreach (var rate in rates)
                {
                    var record = CurrencyRates.Where(r => r.EffectiveDate == rate.EffectiveDate).FirstOrDefault();
                    if (record is null)
                    {
                        record = new CurrencyRate(Session);
                        record.Currency = this;
                        record.EffectiveDate = rate.EffectiveDate;
                        CurrencyRates.Add(record);
                    }
                    record.Mid = rate.Mid;
                }
            }
            catch (Exception)
            {
                
                //throw new FriendlyException();
            }
        }
        [Action(AutoCommit = true, Caption = "Get Rates from C Table", ImageName = "BO_Skull")]
        public void GetRatesC()
        {
            try
            {
                var rates = NBPClient.NBPClient.GetRates("C",Symbol, 50);

                foreach (var rate in rates)
                {
                    var record = CurrencyRates.Where(r => r.EffectiveDate == rate.EffectiveDate).FirstOrDefault();
                    if (record is null)
                    {
                        record = new CurrencyRate(Session);
                        record.Currency = this;
                        record.EffectiveDate = rate.EffectiveDate;
                        CurrencyRates.Add(record);
                    }
                    record.Bid = rate.Bid;
                    record.Ask = rate.Ask;
                }
            }
            catch (Exception)
            {

                //throw new FriendlyException();
            }
        }
    }
}

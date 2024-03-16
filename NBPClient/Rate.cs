using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRates.Model
{
    public class Rate
    {
        public string Number { get; set; }
        public DateTime EffectiveDate { get; set; }
        public decimal Bid { get; set; }
        public decimal Ask { get; set; }
        public decimal Mid { get; set; }
        public override string ToString()
        {
            return $"EffectiveDate: {EffectiveDate} Bid: {Bid} ask: {Ask} Mid: {Mid}";
        }
    }
}

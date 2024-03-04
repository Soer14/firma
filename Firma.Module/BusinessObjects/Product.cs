using Bogus.DataSets;
using Bogus.Extensions.UnitedKingdom;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
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
    [DefaultProperty(nameof(Name))]
    public class Product : BaseObject

    {
        public Product(Session session) : base(session)
        { }

        string notes;
        string gTIN;
        string productName;
        string symbol;


        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Symbol
        {
            get => Symbol;
            set => SetPropertyValue(nameof(Symbol), ref symbol, value);

        }

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string ProductName
        {
            get => productName;
            set => SetPropertyValue(nameof(ProductName), ref productName, value);
        }


        [Size(14)]
        public string GTIN
        {
            get => gTIN;
            set => SetPropertyValue(nameof(GTIN), ref gTIN, value);
        }

        [Size(SizeAttribute.Unlimited)]
        public string Notes
        {
            get => notes;
            set => SetPropertyValue(nameof(Notes), ref notes, value);
        }

    }
}   
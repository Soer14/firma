using DevExpress.ExpressApp.DC;
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
    [NavigationItem("Kartoteki")]
    [XafDisplayName("Resource")]
    public class ResourceBase : BaseObject
    {
        public ResourceBase(Session session) : base(session)
        { }

        decimal purchasePrice;
        DateTime purchaseDate;
        string name;
        string serialNumber;
        string symbol;

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Symbol
        {
            get => symbol;
            set => SetPropertyValue(nameof(Symbol), ref symbol, value);
        }


        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string SerialNumber
        {
            get => serialNumber;
            set => SetPropertyValue(nameof(SerialNumber), ref serialNumber, value);
        }


        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Name
        {
            get => name;
            set => SetPropertyValue(nameof(Name), ref name, value);
        }


        public DateTime PurchaseDate
        {
            get => purchaseDate;
            set => SetPropertyValue(nameof(PurchaseDate), ref purchaseDate, value);
        }

        [ModelDefault("DisplayFormat", "{0:N2}")]
        [ModelDefault("EditMask", "N2")]

        public decimal PurchasePrice
        {
            get => purchasePrice;
            set => SetPropertyValue(nameof(PurchasePrice), ref purchasePrice, value);
        }


        
    }
}






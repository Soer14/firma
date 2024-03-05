using DevExpress.DashboardCommon.DataProcessing;
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
    public class InvoiceItem : BaseObject
    {
        public InvoiceItem(Session session) : base(session)
        { }
        decimal gross;
        decimal vat;
        decimal net;
        decimal unitPrice;
        decimal quantity;
        Invoice invoice;
        Product product;


        public Product Product

        {
            get => product;
            set => SetPropertyValue(nameof(Product), ref product, value);
        }

        [Association]
        public Invoice Invoice
        {
            get => invoice;
            set => SetPropertyValue(nameof(Invoice), ref invoice, value);

        }
        public decimal Quantity
        {
            get => quantity;
            set => SetPropertyValue(nameof(Quantity), ref quantity, value);
        }


        public decimal UnitPrice
        {
            get => unitPrice;
            set => SetPropertyValue(nameof(UnitPrice), ref unitPrice, value);
        }

        public decimal Net
        {
            get => net;
            set => SetPropertyValue(nameof(Net), ref net, value);
        }

        public decimal Vat
        {
            get => vat;
            set => SetPropertyValue(nameof(Vat), ref vat, value);
        }
        
        public decimal Gross
        {
            get => gross;
            set => SetPropertyValue(nameof(Gross), ref gross, value);
        }

    }
 }

using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;
using System;
using System.Linq;

namespace Firma.Module.BusinessObjects
{
    [DefaultClassOptions]
    [NavigationItem("Kartoteki")]
    public class SaleInvoiceItem : BaseObject
    {
        public SaleInvoiceItem(Session session) : base(session)
        {
        }
        VatRate vatRate;
        decimal gross;
        decimal vat;
        decimal net;
        decimal unitPrice;
        decimal quantity;
        SaleInvoice invoice;
        Product product;


        public Product Product


        {
            get => product;
            set
            {
                bool modified = SetPropertyValue(nameof(Product), ref product, value);
                if (modified && !IsLoading && !IsSaving && Product != null)
                {
                    if (Product != null)
                    {
                        UnitPrice = Product.Price;
                        VatRate = Product.VatRate;
                    }

                    CalculateItem();
                }
            }
        }


        [Association]
        public SaleInvoice Invoice { get => invoice; set => SetPropertyValue(nameof(Invoice), ref invoice, value); }

        [ModelDefault("DisplayFormat", "{0:N4}")]
        [ModelDefault("EditMask", "N4")]
        [ImmediatePostData]
        public decimal Quantity
        {
            get => quantity;
            set
            {
                var modified = SetPropertyValue(nameof(Quantity), ref quantity, value);
                if (modified && !IsLoading && !IsSaving)
                {
                    CalculateItem();
                }
            }
        }

        private void CalculateItem()
        {
            Gross = Quantity * UnitPrice;

            Net = Gross / (1 + ((VatRate?.RateValue ?? 0) / 100));


            Vat = Gross - Net;


            Invoice?.RecalculateTotals(true);
        }

        [ModelDefault("DisplayFormat", "{0:N2}")]
        [ModelDefault("EditMask", "N2")]
        [ImmediatePostData]
        public decimal UnitPrice
        {
            get => unitPrice;
            set
            {
                var modified = SetPropertyValue(nameof(UnitPrice), ref unitPrice, value);
                if (modified && !IsLoading && !IsSaving)
                {
                    CalculateItem();
                }
            }
        }

        [ImmediatePostData]
        public VatRate VatRate
        {
            get => vatRate;
            set
            {
                var modified = SetPropertyValue(nameof(VatRate), ref vatRate, value);
                if (modified && !IsLoading && !IsSaving)
                {
                    CalculateItem();
                }
            }
        }

        [ModelDefault("DisplayFormat", "{0:N2}")]
        [ModelDefault("EditMask", "N2")]
        [ModelDefault("AllowEdit", "False")]
        public decimal Net { get => net; set => SetPropertyValue(nameof(Net), ref net, value); }

        [ModelDefault("DisplayFormat", "{0:N2}")]
        [ModelDefault("EditMask", "N2")]
        [ModelDefault("AllowEdit", "False")]
        public decimal Vat { get => vat; set => SetPropertyValue(nameof(Vat), ref vat, value); }

        [ModelDefault("DisplayFormat", "{0:N2}")]
        [ModelDefault("EditMask", "N2")]
        [ModelDefault("AllowEdit", "False")]
        public decimal Gross { get => gross; set => SetPropertyValue(nameof(Gross), ref gross, value); }
    }
}

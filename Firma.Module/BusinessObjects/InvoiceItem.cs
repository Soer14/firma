using DevExpress.DashboardCommon.DataProcessing;
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
    public class InvoiceItem : BaseObject
    {
        public InvoiceItem(Session session) : base(session)
        { }
        VatRate vatRate;
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
        public Invoice Invoice
        {
            get => invoice;
            set => SetPropertyValue(nameof(Invoice), ref invoice, value);

        }
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
           if (VatRate != null)
            {
                Net = Gross / (1 + (VatRate?.RateValue ?? 0) / 100);
                    
            }
           else
            {
                Net = Gross;
            }
            Vat = Gross - Net;


                 Invoice?.RecalculateTotals(true);  
        }

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
        [ModelDefault("AllowEdit","False")]
        public decimal Net
        {
            get => net;
            set => SetPropertyValue(nameof(Net), ref net, value);
        }
        [ModelDefault("AllowEdit", "False")]
        public decimal Vat
        {
            get => vat;
            set => SetPropertyValue(nameof(Vat), ref vat, value);
        }
        [ModelDefault("AllowEdit", "False")]
        public decimal Gross
        {
            get => gross;
            set => SetPropertyValue(nameof(Gross), ref gross, value);
        }

    }
 }

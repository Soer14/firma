using Firma.Module.BusinessObjects;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProjectCommon
{
    internal class TestyXPOMem : BaseTestMem
    {
        [Test]
        public void ObjectSpaceTest()
        {
            Assert.IsNotNull(objectSpace);
        }

        [Test]
        public void DodawanieProduktuTest()
    {
            var vatRate = DodajStawkeVAT("23%", 23);
            Assert.IsNotNull(vatRate);

            var product = DodajProdukt("Nuggets 6 sztuk", 100, vatRate);
            Assert.IsNotNull(product);          


            Assert.AreEqual(100, product.Price);


             
            objectSpace.CommitChanges();



            var invoiceItem = objectSpace.CreateObject<SaleInvoiceItem>();
            invoiceItem.Product = product;
            Assert.IsNotNull(invoiceItem.VatRate);
            Assert.AreEqual(100, invoiceItem.UnitPrice);



            invoiceItem.Quantity = 10;
            Assert.AreEqual(1000, invoiceItem.Gross);
        }

        [Test]
        public void InvoiceSumTest()
        {
            /*
           Dodać kilka stawek VAT
           Dodać kilka produktów
           Utworzyć fakturę
           Utworzyć pozycję do faktury
           Dodać pozycję do faktury
           Porównać sumę faktury z wartością pozycji
   */


            // DodajStawkiVAT();objectSpace.CommitChanges();
            //  DodajProdukty();objectSpace.CommitChanges();


            var rate = DodajStawkeVAT("23%", 23);
            var product = DodajProdukt("Nuggetsy", 100, rate);


            var invoice = objectSpace.CreateObject<SaleInvoice>();


            var invoiceItem = objectSpace.CreateObject<SaleInvoiceItem>();
            invoiceItem.Product = product;
            invoiceItem.Invoice= invoice;
            invoice.InvoiceItems.Add(invoiceItem);
            Assert.IsNotNull(invoiceItem.VatRate);
            Assert.AreEqual(100, invoiceItem.UnitPrice);



            invoiceItem.Quantity = 10;
            Assert.AreEqual(1000, invoiceItem.Gross);


            Assert.AreEqual(invoiceItem.Gross, invoice.Gross);

            var invoiceItem2 = objectSpace.CreateObject<SaleInvoiceItem>();
            invoiceItem2.Product = product;
            invoiceItem2.Invoice = invoice;
            invoice.InvoiceItems.Add(invoiceItem2);
            invoiceItem2.Quantity = 5;
            Assert.AreEqual(1500, invoice.Gross);
        }

        private void DodajProdukty()
        {
            var vatRate = objectSpace.GetObjectByKey<VatRate>("23%");
            Assert.IsNotNull(vatRate);
            _ = DodajProdukt("Nuggets 6 sztuk", 100, vatRate);
            _ = DodajProdukt("Pyszny napój", 20, vatRate);
        }

        private Product DodajProdukt(string nazwa, decimal cena, VatRate stawkaVat)
        {
            var product = objectSpace.CreateObject<Product>();
            product.Price = cena;
            product.ProductName = nazwa;
            product.VatRate = stawkaVat;
            return product;
        }

        private void DodajStawkiVAT()
        {
            _ = DodajStawkeVAT("23%", 23m);
            _ = DodajStawkeVAT("7%", 7m);
            _ = DodajStawkeVAT("5%", 5m);
            _ = DodajStawkeVAT("0%", 0m);
            _ = DodajStawkeVAT("ZW", 0m);
            _ = DodajStawkeVAT("NP", 0m);

            objectSpace.CommitChanges();
        }

        private VatRate DodajStawkeVAT(string symbol, decimal rateValue)
        {
            var vatRate = objectSpace.CreateObject<VatRate>();
            vatRate.RateValue = 23;
            vatRate.Symbol = "23%";
            return vatRate;
        }



        
    }
}

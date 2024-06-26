﻿using DevExpress.CodeParser;
using DevExpress.Export.Xl;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.PivotGrid.OLAP.Mdx;
using DevExpress.Spreadsheet;
using DevExpress.Xpo;
using DevExpress.XtraReports.ErrorPanel.Native;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma.Module.BusinessObjects
{
    [DefaultClassOptions]
    [XafDefaultProperty(nameof(InvoiceNumber))]
    [NavigationItem("Kartoteki")]
    public class SaleInvoice : CustomBaseObject

    {
        public SaleInvoice(Session session) : base(session)
        { }

        XPCollection<SaleInvoiceItem> items;
        XPCollection<SaleInvoice> invoices;
        string invoiceNumber;
        decimal gross;
        decimal vat;
        decimal net;
        Customer customer;
        DateTime dueDate;
        DateTime invoiceDate;


        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string InvoiceNumber
        {
            get => invoiceNumber;
            set => SetPropertyValue(nameof(InvoiceNumber), ref invoiceNumber, value);
        }

        public DateTime InvoiceDate
        {
            get => invoiceDate;
            set => SetPropertyValue(nameof(InvoiceDate), ref invoiceDate, value);
        }

        public DateTime DueDate
        {
            get => dueDate;
            set => SetPropertyValue(nameof(DueDate), ref dueDate, value);
        }
        [Association]
        public Customer Customer
        {
            get => customer;
            set => SetPropertyValue(nameof(Customer), ref customer, value);
        }

        [ModelDefault("DisplayFormat", "{0:N2}")]
        [ModelDefault("EditMask", "N2")]
        public decimal Net
        {
            get => net;
            set => SetPropertyValue(nameof(Net), ref net, value);
        }

        [ModelDefault("DisplayFormat", "{0:N2}")]
        [ModelDefault("EditMask", "N2")]
        public decimal Vat
        {
            get => vat;
            set => SetPropertyValue(nameof(Vat), ref vat, value);
        }

        [ModelDefault("DisplayFormat", "{0:N2}")]
        [ModelDefault("EditMask", "N2")]
        public decimal Gross
        {
            get => gross;
            set => SetPropertyValue(nameof(Gross), ref gross, value);
        }



        [Association, DevExpress.Xpo.Aggregated]
        public XPCollection<SaleInvoiceItem> InvoiceItems
        {
            get
            {
                return GetCollection<SaleInvoiceItem>(nameof(InvoiceItems));
                    

            }
        }

        internal void RecalculateTotals(bool forceChangeEvents)
        {
            decimal oldNet = Net;
            decimal? oldVAT = Vat;
            decimal? oldGross = Gross;

            decimal tmpNet = 0m;
            decimal tmpVat = 0m;
            decimal tmpGross = 0m;

            foreach (var rec in InvoiceItems)
            {
                tmpNet += rec.Net;
                tmpVat += rec.Vat;
                tmpGross += rec.Gross;  
            }

            Net = tmpNet;
            Vat = tmpVat;
            Gross = tmpGross;

            if (forceChangeEvents)
            {
                OnChanged(nameof(Net), oldNet, Net);
                OnChanged(nameof(Vat), oldVAT, Vat);
                OnChanged(nameof(Gross), oldGross, Gross);
            }
        }

    }
}

    


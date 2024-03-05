﻿using DevExpress.CodeParser;
using DevExpress.ExpressApp;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.PivotGrid.OLAP.Mdx;
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
    public class Invoice : BaseObject
    {
        public Invoice(Session session) : base(session)
        { }

        XPCollection<InvoiceItem> items;
        XPCollection<Invoice> invoices;
        string invoiceNumber;
        string notes;
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

        [Size(SizeAttribute.Unlimited)]
        public string Notes
        {
            get => notes;
            set => SetPropertyValue(nameof(Notes), ref notes, value);
        }

        [Association, DevExpress.Xpo.Aggregated]
        public XPCollection<InvoiceItem> Items
        {
            get
            {
                return GetCollection<InvoiceItem>(nameof(Items));

            }
        }

    }
}

    


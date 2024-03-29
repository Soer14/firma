﻿using Bogus.DataSets;
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
    [NavigationItem("Kartoteki")]
    [DefaultClassOptions]
    public class Product : CustomBaseObject


    {
        public Product(Session session) : base(session)
        { }

        VatRate vatRate;
        ProductGroup productGroup;
        decimal price;
        string gTIN;
        string productName;
        string symbol;


        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Symbol
        {
            get => symbol;
            set => SetPropertyValue(nameof(Symbol), ref symbol, value);

        }

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string ProductName
        {
            get => productName;
            set => SetPropertyValue(nameof(ProductName), ref productName, value);
        }

        [Association]
        public ProductGroup ProductGroup
        {
            get => productGroup;
            set => SetPropertyValue(nameof(ProductGroup), ref productGroup, value);
        }

        [Size(14)]
        public string GTIN
        {
            get => gTIN;
            set => SetPropertyValue(nameof(GTIN), ref gTIN, value);
        }


        public decimal Price
        {
            get => price;
            set => SetPropertyValue(nameof(Price), ref price, value);
        }
        
        public VatRate VatRate
        {
            get => vatRate;
            set => SetPropertyValue(nameof(VatRate), ref vatRate, value);
        }

        


    }


}
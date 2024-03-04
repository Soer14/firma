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
    public class ProductGroup : BaseObject
    {
        public ProductGroup(Session session) : base(session)
        { }


        string notes;
        string groupName;

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string GroupName
        {
            get => groupName;
            set => SetPropertyValue(nameof(GroupName), ref groupName, value);
        }

        
        [Size(SizeAttribute.Unlimited)]
        public string Notes
        {
            get => notes;
            set => SetPropertyValue(nameof(Notes), ref notes, value);
        }

        [Association]
        public XPCollection<Product> Products
        {
            get
            {
                return GetCollection<Product>(nameof(Products));
            }
        }
    }


}

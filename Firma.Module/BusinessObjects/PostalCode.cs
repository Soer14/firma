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
    [NavigationItem("Słowniki")]
    public class PostalCode : XPObject
    {
        public PostalCode(Session session) : base(session)
        { }


        string numbers;
        string street;
        string city;
        Commune commune;
        string code;

        [Size(6)]
      
        public string Code
        {
            get => code;
            set => SetPropertyValue(nameof(Code), ref code, value);
        }


        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string City
        {
            get => city;
            set => SetPropertyValue(nameof(City), ref city, value);
        }

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Street
        {
            get => street;
            set => SetPropertyValue(nameof(Street), ref street, value);
        }
        
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Numbers
        {
            get => numbers;
            set => SetPropertyValue(nameof(Numbers), ref numbers, value);
        }

        [Association]
        public Commune Commune
        {
            get => commune;
            set => SetPropertyValue(nameof(Commune), ref commune, value);
        }
        
    }
}

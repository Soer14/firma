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
    public class Voivodeship : XPCustomObject
    {
        public Voivodeship(Session session) : base(session)
        { }
        
        [Size(5)]
        [Key]
        public string IsoCode
        {
            get => iSOCode;
            set => SetPropertyValue(nameof(IsoCode), ref iSOCode, value);
        }

        string iSOCode;
        string name;

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Name
        {
            get => name;
            set => SetPropertyValue(nameof(Name), ref name, value);
        }

        [Association]
        public XPCollection<County> Counties
        {
            get
            {
                return GetCollection<County>(nameof(Counties));
            }
        }
    }

}

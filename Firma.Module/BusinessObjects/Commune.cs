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
    public class Commune : BaseObject
    {
        public Commune(Session session) : base(session)
        { }


        County county;
        string name;

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Name
        {
            get => name;
            set => SetPropertyValue(nameof(Name), ref name, value);
        }
        
        [Association]
        public County County
        {
            get => county;
            set => SetPropertyValue(nameof(County), ref county, value);
        }
        [Association]
        public XPCollection<PostalCode> PostalCodes
        {
            get
            {
                return GetCollection<PostalCode>(nameof(PostalCodes));
            }
        }
    }
}

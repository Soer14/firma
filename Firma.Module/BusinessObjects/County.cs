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
    public class County : BaseObject
    {
        public County(Session session) : base(session)
        { }


        Voivodeship voivodeship;
        string name;

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Name
        {
            get => name;
            set => SetPropertyValue(nameof(Name), ref name, value);
        }
        [Association]
        public XPCollection<Commune> Communes
        {
            get
            {
                return GetCollection<Commune>(nameof(Communes));
            }
        }
        
        [Association]
        public Voivodeship Voivodeship
        {
            get => voivodeship;
            set => SetPropertyValue(nameof(Voivodeship), ref voivodeship, value);
        }
    }

}

using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma.Module.BusinessObjects.Kartoteki
{
    [DefaultClassOptions]
    [DefaultProperty(nameof(Title))]
    public class Department : BaseObject
    {
        public Department(Session session) : base(session)
        { }


        string office;
        string title;

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Title
        {
            get => title;
            set => SetPropertyValue(nameof(Title), ref title, value);
        }

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Office
        {
            get => office;
            set => SetPropertyValue(nameof(Office), ref office, value);
        }
        [DevExpress.Xpo.Association]
        public XPCollection<Employee> Employees
        {
            get
            {
                return GetCollection<Employee>(nameof(Employees));
            }
        }
    }
    }
    


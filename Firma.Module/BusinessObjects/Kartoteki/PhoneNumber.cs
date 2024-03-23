using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma.Module.BusinessObjects.Kartoteki
{
    [DefaultClassOptions]
    public class PhoneNumber : BaseObject
    {
        public PhoneNumber(Session session) : base(session)
        { }


        Employee employee;
        string phoneType;
        string number;

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Number
        {
            get => number;
            set => SetPropertyValue(nameof(Number), ref number, value);
        }

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string PhoneType
        {
            get => phoneType;
            set => SetPropertyValue(nameof(PhoneType), ref phoneType, value);
        }
        
        [DevExpress.Xpo.Association]
        public Employee Employee
        {
            get => employee;
            set => SetPropertyValue(nameof(Employee), ref employee, value);
        }
    }
}

using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Filtering;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma.Module.BusinessObjects.Kartoteki
{
    [DefaultClassOptions]
    [NavigationItem("Kartoteki")]
    public class Employee : CustomBaseObject
    {
        public Employee(Session session) : base(session)
        { }


        Department department;
        string webPageAddress;
        string email;
        TitleOfCourtesy titleOfCourtesy;
        DateTime? birthDate;
        string middleName;
        string lastName;
        string firstName;


        [SearchMemberOptions(SearchMemberMode.Exclude)]
        public String FullName
        {
            get { return ObjectFormatter.Format(FullNameFormat, this, EmptyEntriesMode.RemoveDelimiterWhenEntryIsEmpty); }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public String DisplayName
        {
            get { return FullName; }
        }

        public static String FullNameFormat = "{FirstName} {MiddleName} {LastName}";

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string FirstName
        {
            get => firstName;
            set => SetPropertyValue(nameof(FirstName), ref firstName, value);
        }

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string LastName
        {
            get => lastName;
            set => SetPropertyValue(nameof(LastName), ref lastName, value);
        }

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string MiddleName
        {
            get => middleName;
            set => SetPropertyValue(nameof(MiddleName), ref middleName, value);
        }


        public DateTime? BirthDate
        {
            get => birthDate;
            set => SetPropertyValue(nameof(BirthDate), ref birthDate, value);
        }

        public TitleOfCourtesy TitleOfCourtesy
        {
            get => titleOfCourtesy;
            set => SetPropertyValue(nameof(TitleOfCourtesy), ref titleOfCourtesy, value);
        }



        [Size(255)]
        [RuleRegularExpression(@"(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*|""(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21\x23-\x5b\x5d-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])*"")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\[(?:(?:(2(5[0-5]|[0-4][0-9])|1[0-9][0-9]|[1-9]?[0-9]))\.){3}(?:(2(5[0-5]|[0-4][0-9])|1[0-9][0-9]|[1-9]?[0-9])|[a-z0-9-]*[a-z0-9]:(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21-\x5a\x53-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])+)\])", CustomMessageTemplate = @"Invalid ""Email Address"".")]
        public string Email
        {
            get => email;
            set => SetPropertyValue(nameof(Email), ref email, value);
        }

        [Size(255)]
        [RuleRegularExpression(@"(((http|https)\://)[a-zA-Z0-9\-\.]+\.[a-zA-Z]{2,3}(:[a-zA-Z0-9]*)?/?([a-zA-Z0-9\-\._\?\,\'/\\\+&amp;amp;%\$#\=~])*)|([a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,6})", CustomMessageTemplate = @"Invalid ""Web Page Address"".")]
        public string WebPageAddress
        {
            get => webPageAddress;
            set => SetPropertyValue(nameof(WebPageAddress), ref webPageAddress, value);
        }

        
        [DevExpress.Xpo.Association]
        public Department Department
        {
            get => department;
            set => SetPropertyValue(nameof(Department), ref department, value);
        }
        [DevExpress.Xpo.Association]
        public XPCollection<PhoneNumber> PhoneNumbers
        {
            get
            {
                return GetCollection<PhoneNumber>(nameof(PhoneNumbers));
            }
        }



    }
    public enum TitleOfCourtesy
    {
        Dr,
        Miss,
        Mr,
        Mrs,
        Ms
    }
}

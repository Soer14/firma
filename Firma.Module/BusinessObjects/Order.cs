using DevExpress.ExpressApp.DC;
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
    [ImageName("Czerwone Piwerko")]
    [NavigationItem("Kartoteki")]
    public class Order : CustomBaseObject

    {
        public Order(Session session) : base(session)
        { }
        OrderPriority priority;
        string notes;
        string issueDescription;
        DateTime incidentDate;
        int number;
        string resource;




        public int Number
        {
            get => number;
            set => SetPropertyValue(nameof(Number), ref number, value);
        }

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Resource
        {
            get => resource;
            set => SetPropertyValue(nameof(Resource), ref resource, value);
        }


        public DateTime IncidentDate
        {
            get => incidentDate;
            set => SetPropertyValue(nameof(IncidentDate), ref incidentDate, value);
        }

        
        public OrderPriority Priority
        {
            get => priority;
            set => SetPropertyValue(nameof(Priority), ref priority, value);
        }


        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string IssueDescription
        {
            get => issueDescription;
            set => SetPropertyValue(nameof(IssueDescription), ref issueDescription, value);
        }

        
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Notes
        {
            get => notes;
            set => SetPropertyValue(nameof(Notes), ref notes, value);
        }

    }
    public enum OrderPriority
    {
        [ImageName("Warning")]
        Low,
        [ImageName("Security_WarningCircled2")]
        Medium,
        [ImageName("Security_WarningCircled1")]
        High,
        [ImageName("BO_Skull")]
        [XafDisplayName("Zakurwiście Ważne")]
        VeryHigh
    }
}

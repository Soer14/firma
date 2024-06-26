﻿using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using System;
using System.Linq;

namespace Firma.Module.BusinessObjects
{
    [DefaultClassOptions]
    [ImageName("Czerwone Piwerko")]
    [NavigationItem("Kartoteki")]
    public class Order : CustomBaseObject

    {
        DateTime incidentDate;
        string issueDescription;
        int number;
        OrderPriority priority;
        string resource;

        public Order(Session session) : base(session)
        { }


        public DateTime IncidentDate
        {
            get => incidentDate;
            set => SetPropertyValue(nameof(IncidentDate), ref incidentDate, value);
        }

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string IssueDescription
        {
            get => issueDescription;
            set => SetPropertyValue(nameof(IssueDescription), ref issueDescription, value);
        }



      




        public int Number
        {
            get => number;
            set => SetPropertyValue(nameof(Number), ref number, value);
        }


        public OrderPriority Priority
        {
            get => priority;
            set => SetPropertyValue(nameof(Priority), ref priority, value);
        }

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Resource
        {
            get => resource;
            set => SetPropertyValue(nameof(Resource), ref resource, value);
        }
        [Association("Order-Tasks")]
        public XPCollection<UserTask> Tasks => GetCollection<UserTask>(nameof(Tasks));

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

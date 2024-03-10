using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using System;
using System.Linq;

namespace Firma.Module.BusinessObjects
{
    [DefaultClassOptions]
    public class Task : CustomBaseObject
    {
        string description;
        DateTime dueDate;
        string notes;
        string status;


        Order tasks;

        public Task(Session session) : base(session)
        { }

        public string Description
        {
            get => description;
            set => SetPropertyValue(nameof(Description), ref description, value);
        }


        public DateTime DueDate
        {
            get => dueDate;
            set => SetPropertyValue(nameof(DueDate), ref dueDate, value);
        }

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Status
        {
            get => status;
            set => SetPropertyValue(nameof(Status), ref status, value);
        }

        [Association("Order-Tasks")]
        public Order Tasks
        {
            get => tasks;
            set => SetPropertyValue(nameof(Tasks), ref tasks, value);

        }

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Notes
        {
            get => notes;
            set => SetPropertyValue(nameof(Notes), ref notes, value);
        }
    }
}








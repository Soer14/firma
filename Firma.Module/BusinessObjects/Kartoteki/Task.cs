using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl.PermissionPolicy;
using DevExpress.Xpo;
using System;
using System.Linq;

namespace Firma.Module.BusinessObjects
{
    [DefaultClassOptions]
    [NavigationItem("Kartoteki")]
    public class Task : CustomBaseObject
    {
        PermissionPolicyUser executedBy;
        DateTime completionDate;
        PermissionPolicyUser assignedTo;
        string description;
        DateTime dueDate;
        string status;

        Order order;

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

        public PermissionPolicyUser AssignedTo
        {
            get => assignedTo;
            set => SetPropertyValue(nameof(AssignedTo), ref assignedTo, value);
        }

        public DateTime CompletionDate
        {
            get => completionDate;
            set => SetPropertyValue(nameof(CompletionDate), ref completionDate, value);
        }
        
        public PermissionPolicyUser ExecutedBy
        {
            get => executedBy;
            set => SetPropertyValue(nameof(ExecutedBy), ref executedBy, value);
        }
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Status
        {
            get => status;
            set => SetPropertyValue(nameof(Status), ref status, value);
        }

        [Association("Order-Tasks")]
        public Order Order
        {
            get => order;
            set => SetPropertyValue(nameof(Order), ref order, value);

        }

    }
}








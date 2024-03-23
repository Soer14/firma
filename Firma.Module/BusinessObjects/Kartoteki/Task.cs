using DevExpress.ExpressApp.Model;
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
        TaskStatus status;
        int percentCompleted;
        PermissionPolicyUser executedBy;
        DateTime completionDate;
        PermissionPolicyUser assignedTo;
        string description;
        DateTime dueDate;
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
        [ModelDefault("DisplayFormat", "G")]
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

        public int PercentCompleted
        {
            get => percentCompleted;
            set => SetPropertyValue(nameof(PercentCompleted), ref percentCompleted, value);
        }
        
        public TaskStatus Status
        {
            get => status;
            set => SetPropertyValue(nameof(Status), ref status, value);
        }
        [Action(ImageName = "State_Task_Completed")]
        public void MarkCompleted()
        {
            Status = TaskStatus.Completed;
            CompletionDate = DateTime.Now;
        }

        [Association("Order-Tasks")]
        public Order Order
        {
            get => order;
            set => SetPropertyValue(nameof(Order), ref order, value);

        }
        
        

    }
    public enum TaskStatus
    {
        [ImageName("State_Task_NotStarted")]
        NotStarted,
        [ImageName("State_Task_InProgress")]
        InProgress,
        [ImageName("State_Task_WaitingForSomeoneElse")]
        WaitingForSomeoneElse,
        [ImageName("State_Task_Deferred")]
        Deferred,
        [ImageName("State_Task_Completed")]
        Completed
    }
}








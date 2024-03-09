using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp;
using DevExpress.Persistent.BaseImpl.PermissionPolicy;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Persistent.BaseImpl;

namespace Firma.Module.BusinessObjects
{
    [NonPersistent]
    public abstract class CustomBaseObject : BaseObject
    {
        public CustomBaseObject(Session session)
        : base(session)
        { }
        PermissionPolicyUser GetCurrentUser()
        {
            return Session.GetObjectByKey
           <PermissionPolicyUser>(SecuritySystem.CurrentUserId);
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            CreatedOn = DateTime.Now;
            CreatedBy = GetCurrentUser();
        }
        protected override void OnSaving()
        {
            base.OnSaving();
            UpdatedOn = DateTime.Now;
            UpdatedBy = GetCurrentUser();
        }
        PermissionPolicyUser createdBy;
        [ModelDefault("AllowEdit", "False")]
        [DetailViewLayoutAttribute(LayoutColumnPosition.Left
        , "Auditing", 900)]
        public PermissionPolicyUser CreatedBy
        {
            get { return createdBy; }
            set
            {
                SetPropertyValue("CreatedBy",
            ref createdBy, value);
            }
        }
        DateTime createdOn;
        [DetailViewLayoutAttribute(LayoutColumnPosition.Right,
        "Auditing", 900)]
        [ModelDefault("AllowEdit", "False"),
        ModelDefault("DisplayFormat", "G")]
        public DateTime CreatedOn
        {
            get { return createdOn; }
            set
            {
                SetPropertyValue("CreatedOn"
            , ref createdOn, value);
            }
        }
        PermissionPolicyUser updatedBy;
        [DetailViewLayoutAttribute(LayoutColumnPosition.Left,
        "Auditing", 900)]
        [ModelDefault("AllowEdit", "False")]
        public PermissionPolicyUser UpdatedBy
        {
            get { return updatedBy; }
            set
            {
                SetPropertyValue("UpdatedBy"
            , ref updatedBy, value);
            }
        }
        DateTime updatedOn;
        [DetailViewLayoutAttribute(LayoutColumnPosition.Right,
        "Auditing", 900)]
        [ModelDefault("AllowEdit", "False"),
        ModelDefault("DisplayFormat", "G")]
        public DateTime UpdatedOn
        {
            get { return updatedOn; }
            set
            {
                SetPropertyValue("UpdatedOn"
            , ref updatedOn, value);
            }
        }
    }
}

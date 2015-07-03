using System;
using System.Collections;
using System.Collections.Generic;

//TODO: Add other using statements here

namespace com.Sconit.Entity.MRP.TRANS
{
    [Serializable]
    public partial class MrpExPlanMaster : EntityBase, IAuditable
    {
        #region O/R Mapping Properties

        public Int32 Id { get; set; }
        public string DateIndex { get; set; }
        public string ProductLine { get; set; }
        public string Shift { get; set; }
        public DateTime PlanDate { get; set; }
        public DateTime PlanVersion { get; set; }
        public DateTime ReleaseVersion { get; set; }
        public bool IsActive { get; set; }

        public Int32 CreateUserId { get; set; }
        public string CreateUserName { get; set; }
        public DateTime CreateDate { get; set; }
        public Int32 LastModifyUserId { get; set; }
        public string LastModifyUserName { get; set; }
        public DateTime LastModifyDate { get; set; }
        #endregion

    }

}

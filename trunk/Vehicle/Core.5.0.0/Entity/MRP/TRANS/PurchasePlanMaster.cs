using System;
using System.Collections;
using System.Collections.Generic;
using com.Sconit.Entity.SYS;
using System.ComponentModel.DataAnnotations;

//TODO: Add other using statements here

namespace com.Sconit.Entity.MRP.TRANS
{
    public partial class PurchasePlanMaster
    {
        public string PlanVersionShow
        {
            get
            {
                if (this.PlanVersion == DateTime.MinValue)
                {
                    return null;
                }
                else
                {
                    return this.PlanVersion.ToString("yyyy-MM-dd HH:mm:ss");
                }
            }
            set
            {
                this.PlanVersionShow = value;
            }
        }

        [CodeDetailDescriptionAttribute(CodeMaster = com.Sconit.CodeMaster.CodeMaster.TimeUnit, ValueField = "DateType")]
        public string DateTypeDescription { get; set; }

    }

}

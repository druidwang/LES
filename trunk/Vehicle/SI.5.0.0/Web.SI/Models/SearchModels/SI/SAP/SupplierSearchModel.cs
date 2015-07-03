﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace com.Sconit.Web.Models.SearchModels.SI.SAP
{
    public class SupplierSearchModel : SearchModelBase
    {
        //Id, Code, OldSupplierCode, Name, IOStatus, InboundDate, OutBoundDate
        public int Id { get; set; }

        public string Code { get; set; }

        public string OldSupplierCode { get; set; }

        public string Name { get; set; }

        public int? IOStatus { get; set; }


        public DateTime? InboundDateStart { get; set; }

        public DateTime? OutboundDateStart { get; set; }


        public DateTime? EndOutboundDate { get; set; }
        public DateTime? EndInboundDate { get; set; }
    }
}
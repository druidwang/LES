using System;
using System.ComponentModel.DataAnnotations;
//TODO: Add other using statements here

namespace com.Sconit.Entity.SYS
{
    public partial class EntityPreference
    {
        #region Non O/R Mapping Properties

        public enum CodeEnum
        {
            DefaultPageSize = 10001,
            SessionCachedSearchStatementCount = 10002,
            ItemFilterMode = 10003,
            ItemFilterMinimumChars = 10004,
            InProcessIssueWaitingTime = 10005,
            CompleteIssueWaitingTime = 10006,
            //SMTPEmailAddr = 10007,
            //SMTPEmailHost = 10008,
            //SMTPEmailPasswd = 10009,
            IsRecordLocatoinTransactionDetail = 10010,
            DecimalLength = 10011,
            DefaultPickStrategy = 10012,
            SIWebServiceUserName = 10013,
            SIWebServicePassword = 10014,
            SIWebServiceTimeOut = 10015,
            AllowManualCreateProcurementOrder = 10016,
            //WMSAnjiRegion = 10017,
            MaxRowSizeOnPage = 10018,
            DefaultBarCodeTemplate = 10019,
            ExceptionMailTo = 11020,
            IsAllowCreatePurchaseOrderWithNoPrice = 11021,
            IsAllowCreateSalesOrderWithNoPrice = 110210,
            GridDefaultMultiRowsCount = 11022,
            SAPSERVICEUSERNAME = 11001,
            SAPSERVICEPASSWORD = 11002,
            SAPSERVICETIMEOUT = 11003,
            SAPSERVICEIP = 11004,
            SAPSERVICEPORT = 11005,
            ProdLineWarningColors = 20001,
            MiCleanTime = 20002,
            MiFilterCapacity = 20003,
            MiContainerLocations = 20004,
            FordEdiBakFolder = 90001,
            FordEdiErrorFolder = 90002,
            FordEdiFileFolder = 90003,
            MaxRowSize = 90100,
            FordFlow = 90112,
            SystemFlag = 90102,
            SmartDeviceVersion = 90103,
            EKORG = 90105,//采购组织
            BUKRS = 90106,//公司代码
            WERKS = 90107,//工厂
        }

        [Display(Name = "EntityPreference_Desc", ResourceType = typeof(Resources.SYS.EntityPreference))]
        public string EntityPreferenceDesc { get; set; }
        #endregion
    }
}
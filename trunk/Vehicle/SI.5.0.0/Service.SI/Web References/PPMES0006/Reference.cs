﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.18444
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

// 
// 此源代码是由 Microsoft.VSDesigner 4.0.30319.18444 版自动生成。
// 
#pragma warning disable 1591

namespace com.Sconit.Service.SI.PPMES0006 {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;
    using System.ComponentModel;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="ZWS_PPMES0006", Namespace="urn:sap-com:document:sap:soap:functions:mc-style")]
    public partial class ZWS_PPMES0006 : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback ZfunPpmes0006OperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public ZWS_PPMES0006() {
            this.Url = global::com.Sconit.Service.SI.Properties.Settings.Default.com_Sconit_Service_SI_PPMES0006_ZWS_PPMES0006;
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event ZfunPpmes0006CompletedEventHandler ZfunPpmes0006Completed;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("urn:sap-com:document:sap:soap:functions:mc-style:ZWS_PPMES0006:ZfunPpmes0006Reque" +
            "st", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Bare)]
        [return: System.Xml.Serialization.XmlElementAttribute("ZfunPpmes0006Response", Namespace="urn:sap-com:document:sap:soap:functions:mc-style")]
        public ZfunPpmes0006Response ZfunPpmes0006([System.Xml.Serialization.XmlElementAttribute("ZfunPpmes0006", Namespace="urn:sap-com:document:sap:soap:functions:mc-style")] ZfunPpmes0006 ZfunPpmes00061) {
            object[] results = this.Invoke("ZfunPpmes0006", new object[] {
                        ZfunPpmes00061});
            return ((ZfunPpmes0006Response)(results[0]));
        }
        
        /// <remarks/>
        public void ZfunPpmes0006Async(ZfunPpmes0006 ZfunPpmes00061) {
            this.ZfunPpmes0006Async(ZfunPpmes00061, null);
        }
        
        /// <remarks/>
        public void ZfunPpmes0006Async(ZfunPpmes0006 ZfunPpmes00061, object userState) {
            if ((this.ZfunPpmes0006OperationCompleted == null)) {
                this.ZfunPpmes0006OperationCompleted = new System.Threading.SendOrPostCallback(this.OnZfunPpmes0006OperationCompleted);
            }
            this.InvokeAsync("ZfunPpmes0006", new object[] {
                        ZfunPpmes00061}, this.ZfunPpmes0006OperationCompleted, userState);
        }
        
        private void OnZfunPpmes0006OperationCompleted(object arg) {
            if ((this.ZfunPpmes0006Completed != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.ZfunPpmes0006Completed(this, new ZfunPpmes0006CompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.18408")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="urn:sap-com:document:sap:soap:functions:mc-style")]
    public partial class ZfunPpmes0006 {
        
        private ZstrPpmes0006[] itPpmes0006Field;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [System.Xml.Serialization.XmlArrayItemAttribute("item", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=false)]
        public ZstrPpmes0006[] ItPpmes0006 {
            get {
                return this.itPpmes0006Field;
            }
            set {
                this.itPpmes0006Field = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.18408")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="urn:sap-com:document:sap:soap:functions:mc-style")]
    public partial class ZstrPpmes0006 {
        
        private string zmesscField;
        
        private string zmeslnField;
        
        private string zptypeField;
        
        private string mtsnrField;
        
        private string lfsnrField;
        
        private string bldatField;
        
        private string budatField;
        
        private string aufnrField;
        
        private string zcomnumField;
        
        private string lmngaHField;
        
        private string ismField;
        
        private string bwartField;
        
        private string nplnrField;
        
        private string vornrField;
        
        private string rsnumField;
        
        private string rsposField;
        
        private string matnr1Field;
        
        private string werksField;
        
        private string lgortField;
        
        private string epfmgField;
        
        private string erfmeField;
        
        private string zmesguidField;
        
        private string zcsrqsjField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Zmessc {
            get {
                return this.zmesscField;
            }
            set {
                this.zmesscField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Zmesln {
            get {
                return this.zmeslnField;
            }
            set {
                this.zmeslnField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Zptype {
            get {
                return this.zptypeField;
            }
            set {
                this.zptypeField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Mtsnr {
            get {
                return this.mtsnrField;
            }
            set {
                this.mtsnrField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Lfsnr {
            get {
                return this.lfsnrField;
            }
            set {
                this.lfsnrField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Bldat {
            get {
                return this.bldatField;
            }
            set {
                this.bldatField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Budat {
            get {
                return this.budatField;
            }
            set {
                this.budatField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Aufnr {
            get {
                return this.aufnrField;
            }
            set {
                this.aufnrField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Zcomnum {
            get {
                return this.zcomnumField;
            }
            set {
                this.zcomnumField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string LmngaH {
            get {
                return this.lmngaHField;
            }
            set {
                this.lmngaHField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Ism {
            get {
                return this.ismField;
            }
            set {
                this.ismField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Bwart {
            get {
                return this.bwartField;
            }
            set {
                this.bwartField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Nplnr {
            get {
                return this.nplnrField;
            }
            set {
                this.nplnrField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Vornr {
            get {
                return this.vornrField;
            }
            set {
                this.vornrField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Rsnum {
            get {
                return this.rsnumField;
            }
            set {
                this.rsnumField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Rspos {
            get {
                return this.rsposField;
            }
            set {
                this.rsposField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Matnr1 {
            get {
                return this.matnr1Field;
            }
            set {
                this.matnr1Field = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Werks {
            get {
                return this.werksField;
            }
            set {
                this.werksField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Lgort {
            get {
                return this.lgortField;
            }
            set {
                this.lgortField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Epfmg {
            get {
                return this.epfmgField;
            }
            set {
                this.epfmgField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Erfme {
            get {
                return this.erfmeField;
            }
            set {
                this.erfmeField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Zmesguid {
            get {
                return this.zmesguidField;
            }
            set {
                this.zmesguidField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Zcsrqsj {
            get {
                return this.zcsrqsjField;
            }
            set {
                this.zcsrqsjField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.18408")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="urn:sap-com:document:sap:soap:functions:mc-style")]
    public partial class Bapiret2 {
        
        private string typeField;
        
        private string idField;
        
        private string numberField;
        
        private string messageField;
        
        private string logNoField;
        
        private string logMsgNoField;
        
        private string messageV1Field;
        
        private string messageV2Field;
        
        private string messageV3Field;
        
        private string messageV4Field;
        
        private string parameterField;
        
        private int rowField;
        
        private string fieldField;
        
        private string systemField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Type {
            get {
                return this.typeField;
            }
            set {
                this.typeField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Id {
            get {
                return this.idField;
            }
            set {
                this.idField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Number {
            get {
                return this.numberField;
            }
            set {
                this.numberField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Message {
            get {
                return this.messageField;
            }
            set {
                this.messageField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string LogNo {
            get {
                return this.logNoField;
            }
            set {
                this.logNoField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string LogMsgNo {
            get {
                return this.logMsgNoField;
            }
            set {
                this.logMsgNoField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string MessageV1 {
            get {
                return this.messageV1Field;
            }
            set {
                this.messageV1Field = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string MessageV2 {
            get {
                return this.messageV2Field;
            }
            set {
                this.messageV2Field = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string MessageV3 {
            get {
                return this.messageV3Field;
            }
            set {
                this.messageV3Field = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string MessageV4 {
            get {
                return this.messageV4Field;
            }
            set {
                this.messageV4Field = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Parameter {
            get {
                return this.parameterField;
            }
            set {
                this.parameterField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public int Row {
            get {
                return this.rowField;
            }
            set {
                this.rowField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Field {
            get {
                return this.fieldField;
            }
            set {
                this.fieldField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string system {
            get {
                return this.systemField;
            }
            set {
                this.systemField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.18408")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="urn:sap-com:document:sap:soap:functions:mc-style")]
    public partial class ZfunPpmes0006Response {
        
        private Bapiret2[] itReturnField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [System.Xml.Serialization.XmlArrayItemAttribute("item", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=false)]
        public Bapiret2[] ItReturn {
            get {
                return this.itReturnField;
            }
            set {
                this.itReturnField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    public delegate void ZfunPpmes0006CompletedEventHandler(object sender, ZfunPpmes0006CompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class ZfunPpmes0006CompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal ZfunPpmes0006CompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public ZfunPpmes0006Response Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((ZfunPpmes0006Response)(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591
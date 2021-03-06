﻿using System;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;
using com.Sconit.SmartDevice.SmartDeviceRef;
using System.Web.Services.Protocols;
using System.Drawing;
using com.Sconit.SmartDevice.CodeMaster;

namespace com.Sconit.SmartDevice
{
    public partial class UCMaterialIn : UserControl
    {
        public event MainForm.ModuleSelectHandler ModuleSelectionEvent;

        protected DataGridTableStyle ts;
        protected DataGridTextBoxColumn columnHuId;
        private DataGridTextBoxColumn columnCurrentQty;
        private DataGridTextBoxColumn columnItemDescription;
        private DataGridTextBoxColumn columnItemCode;
        private DataGridTextBoxColumn columnReferenceItemCode;
        private DataGridTextBoxColumn columnUnitCount;
        private DataGridTextBoxColumn columnUom;
        private DataGridTextBoxColumn columnCarton;
        protected DataGridTextBoxColumn columnIsOdd;
        protected DataGridTextBoxColumn columnLotNo;

        private User user;
        private OrderMaster orderMaster;
        //private OrderMaster subOrderMaster;
        private List<Hu> hus;
        private bool isMark;
        private bool isCancel;
        private string barCode;
        private string op;
        //private DateTime? effDate;
        private FlowMaster flowMaster;
        private string[][] huDetails;
        //private Location location;
        private MaterialInType materialInType;
        protected bool isForceFeed;
        private bool isReturn;

        private SD_SmartDeviceService smartDeviceService;

        private static UCMaterialIn ucMaterialIn;
        private static object obj = new object();
        private int keyCodeDiff;

        public UCMaterialIn(User user, bool isReturn)
        {
            InitializeComponent();
            this.smartDeviceService = new SD_SmartDeviceService();
            this.user = user;
            this.InitializeDataGrid();
            this.Reset();
            this.isReturn = isReturn;
            if (isReturn)
            {
                this.btnOrder.Text = "退料";
            }
            else
            {
                this.btnOrder.Text = "投料";
            }
        }

        public static UCMaterialIn GetUCMaterialIn(User user, bool isReturn)
        {
            if (ucMaterialIn == null)
            {
                lock (obj)
                {
                    if (ucMaterialIn == null)
                    {
                        ucMaterialIn = new UCMaterialIn(user, isReturn);
                    }
                }
            }
            ucMaterialIn.user = user;
            ucMaterialIn.Reset();
            ucMaterialIn.lblMessage.Text = "请扫描生产单";
            return ucMaterialIn;
        }

        //public UCMaterialIn(User user)
        //{
        //    InitializeComponent();
        //    this.smartDeviceService = new SmartDeviceService();
        //    this.user = user;
        //    this.InitializeDataGrid();
        //    this.Reset();
        //}

        private void tbBarCode_KeyUp(object sender, KeyEventArgs e)
        {
            if (this.isMark)
            {
                this.isMark = false;
                this.tbBarCode.Focus();
                return;
            }
            try
            {
                string barCode = this.tbBarCode.Text.Trim();
                if (sender is Button)
                {
                    if (e == null)
                    {
                        this.DoSubmit();
                    }
                    else
                    {
                        if ((e.KeyData & Keys.KeyCode) == Keys.Enter)
                        {
                            if (this.tbBarCode.Text.Trim() != string.Empty)
                            {
                                this.ScanBarCode();
                            }
                            else
                            {
                                this.DoSubmit();
                            }
                        }
                    }
                }
                else
                {
                    if ((e.KeyData & Keys.KeyCode) == Keys.Enter)
                    {
                        if (barCode != string.Empty)
                        {
                            this.ScanBarCode();
                        }
                        else
                        {
                            this.btnOrder.Focus();
                        }
                    }
                    else if (((e.KeyData & Keys.KeyCode) == Keys.Escape))
                    {
                        if (!string.IsNullOrEmpty(barCode))
                        {
                            this.tbBarCode.Text = string.Empty;
                        }
                        else
                        {
                            this.DoCancel();
                        }
                    }
                    //else if ((e.KeyData & Keys.KeyCode) == Keys.F4)
                    else if (e.KeyValue == 115 + this.keyCodeDiff)
                    {
                        this.ModuleSelectionEvent(CodeMaster.TerminalPermission.M_Switch);
                    }
                    //else if ((e.KeyData & Keys.KeyCode) == Keys.F3)
                    else if (e.KeyValue == 114 + this.keyCodeDiff)
                    {
                        if (this.tabPanel.SelectedIndex == 0)
                        {
                            this.tabPanel.SelectedIndex = 1;
                        }
                        else if (this.tabPanel.SelectedIndex == 1)
                        {
                            this.tabPanel.SelectedIndex = 0;
                        }
                    }
                    //else if ((e.KeyData & Keys.KeyCode) == Keys.F2 || (e.KeyData & Keys.KeyCode) == Keys.F5)
                    else if (e.KeyValue == 113 + this.keyCodeDiff || e.KeyValue == 116 + this.keyCodeDiff)
                    {
                        if (!this.isCancel)
                        {
                            this.isCancel = true;
                            this.lblBarCode.ForeColor = Color.Red;
                            this.lblMessage.Text = "取消模式.";
                        }
                        else
                        {
                            this.isCancel = false;
                            this.lblBarCode.ForeColor = Color.Black;
                            this.lblMessage.Text = "正常模式.";
                        }
                    }
                    else if ((e.KeyData & Keys.KeyCode) == Keys.F1)
                    {
                        //MessageBox.Show("没有任何帮助");
                        //todo Help
                    }
                }
            }
            catch (SoapException ex)
            {
                this.isMark = true;
                this.tbBarCode.Text = string.Empty;
                this.tbBarCode.Focus();
                Utility.ShowMessageBox(ex.Message);
            }
            catch (BusinessException ex)
            {
                this.isMark = true;
                this.tbBarCode.Text = string.Empty;
                this.tbBarCode.Focus();
                Utility.ShowMessageBox(ex);
            }
            catch (Exception ex)
            {
                if ((ex is System.Net.WebException) || (ex is SoapException))
                {
                    Utility.ShowMessageBox(ex);
                }
                else if (ex is BusinessException)
                {
                    Utility.ShowMessageBox(ex.Message);
                }
                else
                {
                    this.Reset();
                    Utility.ShowMessageBox(ex.Message);
                }
                this.isMark = true;
                this.tbBarCode.Text = string.Empty;
                this.tbBarCode.Focus();
            }
        }

        private void DoCancel()
        {
            this.Reset();
            this.lblMessage.Text = "已全部取消";
        }

        private void DoSubmit()
        {
            try
            {
                if (this.orderMaster == null)
                {
                    throw new BusinessException("没有扫描生产单");
                }
                if (this.hus == null || this.hus.Count == 0)
                {
                    throw new BusinessException("没有扫描条码");
                }
                if (isReturn)
                {
                    this.smartDeviceService.CancelItemTrace(this.orderMaster.OrderNo, this.hus.Select(h => h.HuId).ToArray(), this.user.Code);
                }
                else
                {
                    this.smartDeviceService.DoItemTrace(this.orderMaster.OrderNo, this.hus.Select(h => h.HuId).ToArray(), this.user.Code);
                }
                this.Reset();
                if (isReturn)
                {
                    this.lblMessage.Text = "退料成功";
                }
                else
                {
                    this.lblMessage.Text = "投料成功";
                }
            }
            catch (Exception ex)
            {
                this.isMark = true;
                this.tbBarCode.Text = string.Empty;
                this.tbBarCode.Focus();
                Utility.ShowMessageBox(ex.Message);
            }
        }

        private void ScanBarCode()
        {
            this.barCode = this.tbBarCode.Text.Trim();
            this.lblMessage.Text = string.Empty;
            this.tbBarCode.Text = string.Empty;

            if (this.barCode.Length < 3)
            {
                throw new BusinessException("条码格式不合法");
            }
            this.op = Utility.GetBarCodeType(this.user.BarCodeTypes, this.barCode);

            if (this.orderMaster == null && this.flowMaster == null)
            {
                if (this.op == CodeMaster.BarCodeType.ORD.ToString())
                {
                    this.Reset();
                    this.lblSeq.Text = "班次:";
                    this.lblFlow.Text = "产线:";
                    this.lblWo.Text = "工单:";
                    var orderMaster = this.smartDeviceService.GetOrder(this.barCode, true);
                    if (orderMaster.IsPause)
                    {
                        throw new BusinessException("订单已暂停");
                    }

                    //检查订单状态
                    if (orderMaster.Status != OrderStatus.Submit && orderMaster.Status != OrderStatus.InProcess)
                    {
                        throw new BusinessException("不是Submit或InProcess状态不能操作");
                    }

                    if (orderMaster.Type == OrderType.Production)
                    {
                        if (orderMaster.OrderDetails.Length != 1)
                        {
                            throw new BusinessException("只能对一料一单的生产单操作");
                        }

                        OrderDetail orderDetail = orderMaster.OrderDetails[0];

                        this.lblSeqInfo.Text = orderMaster.Shift;
                        this.lblFlowInfo.Text = orderMaster.Flow;
                        this.lblWoInfo.Text = orderMaster.OrderNo;
                        this.lblVANInfo.Text = orderMaster.StartTime.ToString("yyyy-MM-dd HH:mm");
                        this.lblFgInfo.Text = orderDetail.Item;
                        this.lblFgDescInfo.Text = orderDetail.ItemDescription;
                        this.tabPanel.SelectedIndex = 0;
                    }
                    else
                    {
                        throw new BusinessException("订单类型不正确:{0}", orderMaster.Type.ToString());
                    }

                    #region 界面控制
                    this.lblSeq.Visible = true;
                    this.lblFlow.Visible = true;
                    this.lblWo.Visible = true;
                    this.lblVAN.Visible = true;
                    this.lblFg.Visible = true;
                    this.lblFgDescription.Visible = true;
                    #endregion

                    this.orderMaster = orderMaster;
                }
                else if (this.op == CodeMaster.BarCodeType.F.ToString())
                {
                    throw new BusinessException("不支持生产线投料");
                    this.Reset();
                    this.barCode = this.barCode.Substring(2, this.barCode.Length - 2);
                    this.flowMaster = smartDeviceService.GetFlowMaster(this.barCode, false);

                    //检查订单类型
                    if (this.flowMaster.Type != OrderType.Production)
                    {
                        throw new BusinessException("不是生产线不能投料。");
                    }

                    //是否有效
                    if (!this.flowMaster.IsActive)
                    {
                        throw new BusinessException("此生产线无效。");
                    }

                    //检查权限
                    if (!Utility.HasPermission(this.flowMaster, this.user))
                    {
                        throw new BusinessException("没有此生产线的权限");
                    }
                    this.lblMessage.Text = this.flowMaster.Description;
                    //this.gvListDataBind();

                    this.lblSeq.Text = "产线:";
                    this.lblSeq.Visible = true;
                    this.lblSeqInfo.Text = this.flowMaster.Code;
                    this.lblFlow.Text = "描述:";
                    this.lblFlow.Visible = true;
                    this.lblFlowInfo.Text = this.flowMaster.Description;
                    this.lblWo.Text = "区域:";
                    this.lblWo.Visible = true;
                    this.lblWoInfo.Text = this.flowMaster.PartyFrom;

                    this.lblVANInfo.Text = string.Empty;

                    this.lblFgInfo.Text = string.Empty;

                    this.lblFgDescInfo.Text = string.Empty;
                    this.tabPanel.SelectedIndex = 0;
                }
                else
                {
                    throw new BusinessException("请先扫描订单或者生产线");
                }
            }
            else
            {
                if (this.op == CodeMaster.BarCodeType.HU.ToString())
                {
                    if (this.hus == null)
                    {
                        this.hus = new List<Hu>();
                    }
                    if (this.flowMaster == null && this.orderMaster == null)
                    {
                        throw new BusinessException("请先扫描生产单或生产线");
                    }

                    Hu hu = new Hu();
                    try
                    {
                        hu = this.smartDeviceService.GetHu(this.barCode);
                    }
                    catch
                    {
                        if (this.barCode.Length == 17)
                        {
                            hu = this.smartDeviceService.ResolveHu(this.barCode, this.user.Code);
                        }
                    }
                    if (string.IsNullOrEmpty(hu.HuId))
                    {
                        throw new BusinessException("条码不存在");
                    }
                    hu.CurrentQty = hu.Qty;
                    var matchHu = this.hus.Where(h => h.HuId.Equals(hu.HuId, StringComparison.OrdinalIgnoreCase));
                    if (matchHu != null && matchHu.Count() > 0)
                    {
                        throw new BusinessException("条码重复扫描!");
                    }
                    if (hu.IsFreeze)
                    {
                        throw new BusinessException("条码被冻结!");
                    }
                    if (hu.OccupyType != OccupyType.None)
                    {
                        throw new BusinessException("条码被{0}占用!", hu.OccupyReferenceNo);
                    }
                    if (!Utility.HasPermission(user.Permissions, null, true, false, hu.Region, null))
                    {
                        throw new BusinessException("没有此条码的权限");
                    }
                    if (hu.Status != HuStatus.Location)
                    {
                        throw new BusinessException("此条码不在库位中");
                    }

                    if (this.orderMaster != null)
                    {
                        this.hus.Insert(0, hu);
                        this.gvHuListDataBind();
                    }
                    else if (this.flowMaster != null)
                    {
                        this.hus.Insert(0, hu);
                        this.gvHuListDataBind();
                    }
                    else
                    {
                        this.Reset();
                        throw new BusinessException("请先扫描生产单或生产线");
                    }

                    this.tabPanel.SelectedIndex = 1;
                }
                else
                {
                    throw new BusinessException("条码格式不合法。");
                }
            }
        }

        private void gvListDataBind()
        {
            this.tbBarCode.Text = string.Empty;
            this.tbBarCode.Focus();
            //this.dgList.DataSource = details;
            //ts.MappingName = details.GetType().Name;
            this.ts = new DataGridTableStyle();

            this.ts.GridColumnStyles.Add(columnItemCode);
            this.ts.GridColumnStyles.Add(columnCurrentQty);
            this.ts.GridColumnStyles.Add(columnCarton);
            this.ts.GridColumnStyles.Add(columnLotNo);
            this.ts.GridColumnStyles.Add(columnIsOdd);
            this.ts.GridColumnStyles.Add(columnUnitCount);
            this.ts.GridColumnStyles.Add(columnUom);
            this.ts.GridColumnStyles.Add(columnReferenceItemCode);
            this.ts.GridColumnStyles.Add(columnItemDescription);

            this.dgDetail.TableStyles.Clear();
            this.dgDetail.TableStyles.Add(this.ts);

            this.ResumeLayout();
        }

        private void gvHuListDataBind()
        {
            List<Hu> hus = new List<Hu>();
            if (this.hus != null)
            {
                hus = this.hus;
            }

            this.ts = new DataGridTableStyle();
            this.ts.MappingName = hus.GetType().Name;

            this.ts.GridColumnStyles.Add(columnHuId);
            this.ts.GridColumnStyles.Add(columnCurrentQty);
            this.ts.GridColumnStyles.Add(columnLotNo);
            this.ts.GridColumnStyles.Add(columnUnitCount);
            this.ts.GridColumnStyles.Add(columnUom);
            this.ts.GridColumnStyles.Add(columnReferenceItemCode);
            this.ts.GridColumnStyles.Add(columnItemDescription);

            this.dgDetail.TableStyles.Clear();
            this.dgDetail.TableStyles.Add(this.ts);

            this.dgDetail.DataSource = hus;
            this.ResumeLayout();

            this.dgDetail.Visible = true;
            this.tbBarCode.Text = string.Empty;
            this.tbBarCode.Focus();
        }

        private void Reset()
        {
            this.orderMaster = null;
            this.hus = new List<Hu>();
            this.tbBarCode.Text = string.Empty;
            this.tbBarCode.Focus();
            this.lblMessage.Text = string.Empty;

            this.isCancel = false;
            this.tabPanel.SelectedIndex = 0;

            #region tab1
            this.lblSeqInfo.Text = string.Empty;
            this.lblFlowInfo.Text = string.Empty;
            this.lblWoInfo.Text = string.Empty;
            this.lblVANInfo.Text = string.Empty;
            this.lblFgInfo.Text = string.Empty;
            this.lblFgDescInfo.Text = string.Empty;


            this.lblSeq.Visible = false;
            this.lblFlow.Visible = false;
            this.lblWo.Visible = false;
            this.lblVAN.Visible = false;
            this.lblFg.Visible = false;
            this.lblFgDescription.Visible = false;
            #endregion

            #region tab2
            this.lblVANInfo1.Text = string.Empty;
            this.lblSeqInfo1.Text = string.Empty;
            this.lblStationInfo1.Text = string.Empty;
            //this.lblOpInfo1.Text = string.Empty;
            this.lblItemInfo1.Text = string.Empty;
            this.lblLotNoInfo1.Text = string.Empty;
            this.lblItemRefInfo1.Text = string.Empty;
            this.lblMDateInfo1.Text = string.Empty;
            this.lblMPartyInfo1.Text = string.Empty;
            this.lblItemDescInfo1.Text = string.Empty;


            this.lblVAN1.Visible = false;
            this.lblSeq1.Visible = false;
            this.lblStation1.Visible = false;
            //this.lblOpInfo1.Text = string.Empty;
            this.lblItem1.Visible = false;
            this.lblLotNo1.Visible = false;
            this.lblItemRef1.Visible = false;
            this.lblMDate1.Visible = false;
            this.lblMParty1.Visible = false;
            this.lblItemDesc1.Visible = false;
            #endregion

            this.dgDetail.Visible = false;
            //this.lblMessage.Text ="已全部取消";
            this.keyCodeDiff = Utility.GetKeyCodeDiff();
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            this.tbBarCode_KeyUp(sender, null);
        }

        private void tbBarCode_LostFocus(object sender, EventArgs e)
        {
            if (!this.btnOrder.Focused)
            {
                this.tbBarCode.Focus();
            }
        }

        private void btnOrder_KeyUp(object sender, KeyEventArgs e)
        {
            this.tbBarCode_KeyUp(sender, e);
        }

        private void InitializeDataGrid()
        {
            // 
            // columnItemCode
            // 
            this.columnItemCode = new DataGridTextBoxColumn();
            this.columnItemCode.Format = "";
            this.columnItemCode.FormatInfo = null;
            this.columnItemCode.HeaderText = "物料";
            this.columnItemCode.MappingName = "Item";
            this.columnItemCode.Width = 50;
            // 
            // columnLotNo
            // 
            this.columnLotNo = new DataGridTextBoxColumn();
            this.columnLotNo.Format = "";
            this.columnLotNo.FormatInfo = null;
            this.columnLotNo.HeaderText = "批号";
            this.columnLotNo.MappingName = "LotNo";
            this.columnLotNo.Width = 40;
            // 
            // columnCurrentQty
            // 
            this.columnCurrentQty = new DataGridTextBoxColumn();
            this.columnCurrentQty.Format = "0.##";
            this.columnCurrentQty.FormatInfo = null;
            this.columnCurrentQty.HeaderText = "数量";
            this.columnCurrentQty.MappingName = "CurrentQty";
            this.columnCurrentQty.Width = 40;
            // 
            // columnCarton
            // 
            this.columnCarton = new DataGridTextBoxColumn();
            this.columnCarton.Format = "";
            this.columnCarton.FormatInfo = null;
            this.columnCarton.HeaderText = "箱数";
            this.columnCarton.MappingName = "Carton";
            this.columnCarton.Width = 40;
            // 
            // columnUnitCount
            // 
            this.columnUnitCount = new DataGridTextBoxColumn();
            this.columnUnitCount.Format = "0.##";
            this.columnUnitCount.FormatInfo = null;
            this.columnUnitCount.HeaderText = "单包装";
            this.columnUnitCount.MappingName = "UnitCount";
            this.columnUnitCount.Width = 40;
            // 
            // columnUom
            // 
            this.columnUom = new DataGridTextBoxColumn();
            this.columnUom.Format = "";
            this.columnUom.FormatInfo = null;
            this.columnUom.HeaderText = "单位";
            this.columnUom.MappingName = "Uom";
            this.columnUom.Width = 40;
            // 
            // columnIsOdd
            // 
            this.columnIsOdd = new DataGridTextBoxColumn();
            this.columnIsOdd.Format = "";
            this.columnIsOdd.FormatInfo = null;
            this.columnIsOdd.HeaderText = "零头";
            this.columnIsOdd.MappingName = "IsOdd";
            this.columnIsOdd.Width = 40;
            // 
            // columnReferenceItemCode
            // 
            this.columnReferenceItemCode = new DataGridTextBoxColumn();
            this.columnReferenceItemCode.Format = "";
            this.columnReferenceItemCode.FormatInfo = null;
            this.columnReferenceItemCode.HeaderText = "参考物料";
            this.columnReferenceItemCode.MappingName = "ReferenceItemCode";
            this.columnReferenceItemCode.Width = 100;
            // 
            // columnItemDescription
            // 
            this.columnItemDescription = new DataGridTextBoxColumn();
            this.columnItemDescription.Format = "";
            this.columnItemDescription.FormatInfo = null;
            this.columnItemDescription.HeaderText = "描述";
            this.columnItemDescription.MappingName = "ItemDescription";
            this.columnItemDescription.Width = 150;
            // 
            // columnHuId
            // 
            this.columnHuId = new DataGridTextBoxColumn();
            this.columnHuId.Format = "";
            this.columnHuId.FormatInfo = null;
            this.columnHuId.HeaderText = "条码";
            this.columnHuId.MappingName = "HuId";
            this.columnHuId.NullText = "";
            this.columnHuId.Width = 150;

        }
    }
}

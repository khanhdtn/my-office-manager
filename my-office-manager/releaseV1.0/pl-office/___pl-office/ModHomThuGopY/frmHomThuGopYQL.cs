using System;
using System.Data;
using ProtocolVN.Framework.Core;
using ProtocolVN.Framework.Win;
using DAO;
using ProtocolVN.DanhMuc;
using System.Collections.Generic;
using ProtocolVN.App.Office;
using System.Text;
using ProtocolVN.Plugin.TimeSheet;
/*
 * Người đề xuất & thiết kế : Trần Văn Châu
 * Email : chautv@protocolvn.net
 * Người thực hiện : 
 */

namespace office
{
    public partial class frmHomThuGopYQL : PhieuQuanLy10Change, IFormRefresh
    {
    //public partial class frmHomThuGopYQL : XtraFormPL
    //{
        //#region Các biến của form Quan Ly Tuyệt đối không thay đổi
        //protected DevExpress.XtraBars.BarManager barManager1;
        //protected DevExpress.XtraBars.Bar MainBar;
        //protected DevExpress.XtraBars.BarButtonItem barButtonItemAdd;
        //protected DevExpress.XtraBars.BarButtonItem barButtonItemDelete;
        //protected DevExpress.XtraBars.BarButtonItem barButtonItemUpdate;
        //protected DevExpress.XtraBars.BarButtonItem barButtonItemPrint;
        //protected DevExpress.XtraBars.BarButtonItem barButtonItemView;
        //protected DevExpress.XtraBars.BarDockControl barDockControlTop;
        //protected DevExpress.XtraBars.BarDockControl barDockControlBottom;
        //protected DevExpress.XtraBars.BarDockControl barDockControlLeft;
        //protected DevExpress.XtraBars.BarDockControl barDockControlRight;
        //protected DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        //protected DevExpress.XtraGrid.GridControl gridControlMaster;
        //protected DevExpress.XtraGrid.Views.Grid.PLGridView gridViewMaster;
        //protected DevExpress.XtraGrid.GridControl gridControlDetail;
        //protected DevExpress.XtraGrid.Views.Grid.PLGridView gridViewDetail;
        //protected DevExpress.XtraTab.XtraTabControl xtraTabControlDetail;
        //protected DevExpress.XtraTab.XtraTabPage xtraTabPageDetail;
        //protected DevExpress.XtraBars.PopupControlContainer popupControlContainerFilter;
        //protected DevExpress.XtraBars.BarStaticItem barStaticItem1;
        //protected DevExpress.XtraBars.BarButtonItem barButtonItem1;
        //protected DevExpress.XtraBars.BarButtonItem barButtonItem2;
        //protected DevExpress.XtraBars.BarButtonItem barButtonItemCommit;
        //protected DevExpress.XtraBars.BarButtonItem barButtonItemNoCommit;
        //protected DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        //protected DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        //protected DevExpress.XtraBars.BarButtonItem barButtonItemTaoPhieuMuaHang;
        //private System.ComponentModel.IContainer components;
        //private DevExpress.XtraBars.BarSubItem barSubItem1;
        //private DevExpress.XtraBars.BarButtonItem barButtonItemXem;
        //protected DevExpress.XtraBars.BarButtonItem barButtonItemClose;
        //private DevExpress.XtraBars.PopupMenu popupMenuFilter;
        //protected DevExpress.XtraBars.BarCheckItem barCheckItemFilter;
        //private DevExpress.XtraBars.BarButtonItem barButtonItemSearch;
        //private DevExpress.XtraBars.BarButtonItem barButtonItem3;
        //private DevExpress.XtraBars.PopupMenu popupMenu1;
        //private DevExpress.XtraBars.BarButtonItem barButtonItem4;
        //#endregion

        public static string MenuItem(string ParentID, bool IsSep)
        {
            return MenuBuilder.CreateItem(typeof(frmHomThuGopYQL).FullName,
                "Hòm thư góp ý",
                ParentID, true,
                typeof(frmHomThuGopYQL).FullName,
                true, IsSep, "", true, "", "");
        }
        private PhieuQuanLy10Fix that;
        private DataTable dtNguoiNhan = new DataTable();
        private DataSet DsData;
        public frmHomThuGopYQL()
        {
            InitializeComponent();
            IDField = "ID";
            DisplayField = "TIEU_DE";
            this._UsingExportToFileItem = false;
            that = new PhieuQuanLy10Fix(this, this.UpdateRow());
            gridViewMaster.OptionsBehavior.AutoExpandAllGroups = true;
            gridViewMaster.OptionsView.ShowGroupPanel = false;
        }
      
        public override void InitColumnMaster()
        {
            HelpGridColumn.CotTextLeft(colMaster_ID, HomThuGopYFiedls.ID);
            HelpGridColumn.CotTextLeft(colMaster_TieuDe, HomThuGopYFiedls.TIEU_DE);
            AppCtrl.CotRichTextEit(colMaster_NoiDung, "NOI_DUNG_TEXT");
            HelpGridColumn.CotReadOnlyDate(colMaster_NgayGhiNhan, HomThuGopYFiedls.NGAY, PLConst.FORMAT_DATETIME_STRING);
            dtNguoiNhan = HelpDB.getDatabase().LoadDataSet("Select ID, NAME from DM_NHAN_VIEN").Tables[0];
            HelpGridExt1.colMultiline(colMaster_NguoiNhan, "TEN_NGUOI_NHAN");
            HelpGridColumn.CotCombobox(colMaster_NguoiGopY, dtNguoiNhan.DataSet, "ID", "NAME", HomThuGopYFiedls.NGUOI_GOP_Y);
            colMaster_NgayGhiNhan.SortOrder = DevExpress.Data.ColumnSortOrder.Descending;
            chkNguoiGopY.CheckedChanged += new EventHandler(chkNguoiGopY_CheckedChanged);
        }

        void chkNguoiGopY_CheckedChanged(object sender, EventArgs e)
        {
            if (gridControlMaster.DataSource == null) return;
            DataSet dsCopy = DsData.Copy();
            if (chkNguoiGopY.Checked)
            {
                foreach (DataRow row in dsCopy.Tables[0].Rows)
                {
                    row["NOI_DUNG_TEXT"] = HelpByte.BytesToUTF8String((byte[])row[HomThuGopYFiedls.NOI_DUNG]);
                    if (HelpNumber.ParseInt64(row["NGUOI_GOP_Y"]) != FrameworkParams.currentUser.employee_id)
                        row["NGUOI_GOP_Y"] =
                        string.Compare(row["IS_HIEN"].ToString(), "Y") == 0 ? row["NGUOI_GOP_Y"] : -1;
                    row["TEN_NGUOI_NHAN"] = GetNameOfRecipient(row["NGUOI_NHAN_GOP_Y"].ToString());
                    gridViewMaster.RefreshData();
                }
            }
            else
            {
                foreach (DataRow row in dsCopy.Tables[0].Rows)
                {
                    row["NOI_DUNG_TEXT"] = HelpByte.BytesToUTF8String((byte[])row[HomThuGopYFiedls.NOI_DUNG]);
                    row["NGUOI_GOP_Y"] =
                        string.Compare(row["IS_HIEN"].ToString(), "Y") == 0 ? row["NGUOI_GOP_Y"] : -1;
                    row["TEN_NGUOI_NHAN"] = GetNameOfRecipient(row["NGUOI_NHAN_GOP_Y"].ToString());
                    gridViewMaster.RefreshData();
                }
            }
            gridControlMaster.DataSource = dsCopy.Tables[0];
            HookFocusRow();
        }

        public override void InitColumDetail()
        {            
        } 
      
        public override void PLLoadFilterPart()
        {
            this.gridViewMaster.OptionsView.ShowGroupedColumns = false;
            gridViewMaster.OptionsBehavior.Editable = true;
            gridViewDetail.OptionsBehavior.Editable = true;
            HelpControl.RedCheckEdit(this.chkNguoiGopY, false);
            HelpGridExt1.DisableCaptionGroupCol(this.gridViewMaster);
            AppCtrl.InitTreeChonNhanVien_Choice1(nguoiGui, true);
            PLTimeSheetUtil.PermissionForControl(nguoiGui, nguoiGui.Visible == true, false);
            AppCtrl.InitTreeChonNhanVien(NguoiNhan, true,false);
            NguoiNhan._SelectedIDs = new long[] { FrameworkParams.currentUser.employee_id };
            NguoiNhan.Enabled = nguoiGui.Enabled;
        }
        public override QueryBuilder PLBuildQueryFilter()
        {
            FWWaitingMsg msg = new FWWaitingMsg();
            QueryBuilder filter = new QueryBuilder(UpdateRow());
            gridControlMaster.DataSource = null;
            StringBuilder cond = new StringBuilder("");
            if (nguoiGui._getSelectedID() != -1) cond.Append(string.Format("NGUOI_GOP_Y = {0}", nguoiGui._getSelectedID()));
            long[] arrNguoiNhan = NguoiNhan._SelectedIDs;
            if (arrNguoiNhan.Length > 0 && cond.Length > 0) cond.Append(" OR ");
            int temp = arrNguoiNhan.Length;
            foreach (long id in arrNguoiNhan)
            {
                cond.Append(string.Format(@"(NGUOI_NHAN_GOP_Y LIKE '{0},%') 
                        OR (NGUOI_NHAN_GOP_Y LIKE '%,{0},%') OR (NGUOI_NHAN_GOP_Y LIKE '%,{0}')", id)); ;
                temp--;
                if (temp > 0)
                {
                    cond.Append(" OR ");
                }
            }
            if (cond.Length > 0)
            {
                filter.addCondition(cond.ToString());
            }
            filter.addDateFromTo(HomThuGopYFiedls.NGAY, ngayKT.FromDate, ngayKT.ToDate);
            filter.addCondition(" 1=1 ");
            DsData = HelpDB.getDatabase().LoadDataSet(filter);
            if (DsData != null && DsData.Tables[0].Rows.Count > 0)
            {
                DsData.Tables[0].Columns.AddRange(new DataColumn[]{
                    new DataColumn("NOI_DUNG_TEXT",typeof(String))
                    ,new DataColumn("TEN_NGUOI_NHAN",typeof(String))});
                DataSet dsCopy = DsData.Copy();
                if (chkNguoiGopY.Checked)
                {
                    foreach (DataRow row in dsCopy.Tables[0].Rows)
                    {
                        row["NOI_DUNG_TEXT"] = HelpByte.BytesToUTF8String((byte[])row[HomThuGopYFiedls.NOI_DUNG]);
                        if (HelpNumber.ParseInt64(row["NGUOI_GOP_Y"]) != FrameworkParams.currentUser.employee_id)
                            row["NGUOI_GOP_Y"] =
                            string.Compare(row["IS_HIEN"].ToString(), "Y") == 0 ? row["NGUOI_GOP_Y"] : -1;
                        row["TEN_NGUOI_NHAN"] = GetNameOfRecipient(row["NGUOI_NHAN_GOP_Y"].ToString());
                    }
                }
                else {
                    foreach (DataRow row in dsCopy.Tables[0].Rows)
                    {
                        row["NOI_DUNG_TEXT"] = HelpByte.BytesToUTF8String((byte[])row[HomThuGopYFiedls.NOI_DUNG]);
                        row["NGUOI_GOP_Y"] =
                            string.Compare(row["IS_HIEN"].ToString(), "Y") == 0 ? row["NGUOI_GOP_Y"] : -1;
                        row["TEN_NGUOI_NHAN"] = GetNameOfRecipient(row["NGUOI_NHAN_GOP_Y"].ToString());
                    }
                }
                gridControlMaster.DataSource = dsCopy.Tables[0];
            }
            msg.Finish();
            return null;
        }
        public override void ShowViewForm(long id)
        {
            frmHomThuGopY frm = new frmHomThuGopY(id,null);
            HelpProtocolForm.ShowModalDialog(this, frm);
        }

        public override void ShowUpdateForm(long id)
        {
            frmHomThuGopY frm = new frmHomThuGopY(id,false);
            frm.RefreshDataAfterUpdate += new frmHomThuGopY.RefreshThuGopY(frm_RefreshDataAfterUpdate);
            HelpProtocolForm.ShowModalDialog(this, frm);
        }

        void frm_RefreshDataAfterUpdate(DTO.DOHomThuGopY doGopY)
        {
            DataRow row = gridViewMaster.GetDataRow(gridViewMaster.FocusedRowHandle);
            DataRow[] rows = DsData.Tables[0].Select(String.Format("ID = {0}",doGopY.ID));
            row["TIEU_DE"]= rows[0]["TIEU_DE"] = doGopY.TIEU_DE;
            row["NGAY"] =rows[0]["NGAY"] = doGopY.NGAY;
            rows[0]["NGUOI_NHAN_GOP_Y"] = doGopY.NGUOI_NHAN_GOP_Y;
            rows[0]["NOI_DUNG"] = doGopY.NOI_DUNG;
            row["TEN_NGUOI_NHAN"] = rows[0]["TEN_NGUOI_NHAN"] = GetNameOfRecipient(doGopY.NGUOI_NHAN_GOP_Y);
            row["NOI_DUNG_TEXT"] = rows[0]["NOI_DUNG_TEXT"] = HelpByte.BytesToUTF8String(doGopY.NOI_DUNG);
            row["IS_HIEN"] =rows[0]["IS_HIEN"] = doGopY.IS_HIEN;

            if (doGopY.IS_HIEN == "N") row["NGUOI_GOP_Y"] = -1;
            else row["NGUOI_GOP_Y"] = doGopY.NGUOI_GOP_Y;
            gridViewMaster.RefreshData();
        }

        public override long[] ShowAddForm()
        {
            frmHomThuGopY frm = new frmHomThuGopY();
            HelpProtocolForm.ShowModalDialog(this, frm);
            return null;
        }

        public override string UpdateRow()
        {
            return
                @"SELECT HT.ID, TIEU_DE, NGAY, NOI_DUNG, NGUOI_NHAN_GOP_Y, NGUOI_GOP_Y, IS_HIEN 
                    FROM HOM_THU_GOP_Y HT INNER JOIN DM_NHAN_VIEN NV ON  HT.NGUOI_GOP_Y=NV.ID
                    WHERE 1=1";
        }
        public override _Print InAction(long[] ids)
        {
            return null;
        }

        public override _MenuItem GetBusinessMenuList()
        {
            return null;
        }
        

        public override _MenuItem GetMenuAppendGridList()
        {
            return null;
        }

        public override void HookFocusRow()
        {
            DataRow row = gridViewMaster.GetDataRow(gridViewMaster.FocusedRowHandle);
            barButtonItemDelete.Enabled = barButtonItemUpdate.Enabled = !(HelpNumber.ParseInt64(row["NGUOI_GOP_Y"]) != FrameworkParams.currentUser.employee_id);
        }

        #region IDuyetSupport Members
        public bool DuyetAction(long ID, long NguoiDuyetID, DateTime NgayDuyet)
        {
            if (PLGUIUtil.UpdateDuyetPhieu(DAHomThuGopY.TABLE_MAP, "ID", ID, NguoiDuyetID, NgayDuyet, DuyetSupportStatus.Duyet)) return true;
            else return false;
        }
        public bool KhongDuyetAction(long ID, long NguoiDuyetID, DateTime NgayDuyet)
        {
            if (PLGUIUtil.UpdateDuyetPhieu(DAHomThuGopY.TABLE_MAP, "ID", ID, NguoiDuyetID, NgayDuyet, DuyetSupportStatus.KhongDuyet)) return true;
            else return false;
        }
        #endregion


        #region Other
        /// <summary>
        /// Get name of recipients.
        /// </summary>
        /// <param name="RecipientIDs"></param>
        /// <returns></returns>
        private string GetNameOfRecipient(string RecipientIDs) {
            StringBuilder stringName = new StringBuilder();
            DataRow[] rows = dtNguoiNhan.Select(string.Format("ID in ({0})", RecipientIDs));
            foreach (DataRow row in rows) { 
                stringName.Append(row["NAME"].ToString());
                stringName.Append("\n");
            }
            return stringName.ToString().Remove(stringName.ToString().LastIndexOf("\n"));
        }
      
        #endregion

        #region IFormRefresh Members

        public object _RefreshAction(params object[] input)
        {
            return null;
        }
        public override bool XoaAction(long id)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
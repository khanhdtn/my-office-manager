using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ProtocolVN.Framework.Win;
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.XtraGrid.Columns;
using ProtocolVN.Framework.Core;
using System.Data.Common;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.ViewInfo;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using office;
using DAO;
using DTO;
using DevExpress.XtraGrid;
namespace pl.office.form
{
    public partial class frmViewForum : XtraFormPL
    {
        private Int64 IDKey = -2;
        //
        public delegate void Update_IncreaseSoLanTraLoi();
        public Update_IncreaseSoLanTraLoi IncreaseSoLanTraLoiViewForum;

        public delegate void Update_DecreaseSoLanTraLoi();
        public Update_DecreaseSoLanTraLoi DecreaseSoLanTraLoiViewForum;
        //
        public frmViewForum() : this(-2) {
 
        }
        public frmViewForum(Int64 IdKey)
        {
            InitializeComponent();
            this.IDKey = IdKey;
            _Init();
        }

        #region Vùng đặt Static
        public static FormStatus Status = FormStatus.NO_USE;
        public static string MenuItem(string ParentID, bool IsSep)
        {
            return MenuBuilder.CreateItem(typeof(frmViewForum).FullName,
                HelpDebug.UpdateTitle("Diễn đàn thảo luận", Status),
                ParentID, true,
                typeof(frmViewForum).FullName,
                false, IsSep, "", true, "", "");
        }
        #endregion
        private DataSet BaiVietLienQuan(long ID)
        {
            string sql = @"SELECT B.*,LT.NOI_DUNG NOI_DUNG_FILE,LT.TEN_FILE, LT.ID AS TAP_TIN_ID
                                FROM (BAI_VIET B INNER JOIN OBJECT_TAP_TIN B1 ON B.ID=B1.OBJECT_ID)
                                INNER JOIN LUU_TRU_TAP_TIN LT ON LT.ID=B1.TAP_TIN_ID 
                                WHERE (B.ID=@ID OR B.ID_BAI_VIET_PARENT=@ID) AND TYPE_ID = 2 ORDER BY NGAY_GUI ASC";
            DatabaseFB db = DABase.getDatabase();
            DbCommand cmd = db.GetSQLStringCommand(sql);
            db.AddInParameter(cmd, "@ID", DbType.Int64, ID);
            DataSet ds = new DataSet();
            db.LoadDataSet(cmd, ds, "BAI_VIET");
            return ds;
        }

        public void _InitData() {
            DataSet ds = BaiVietLienQuan(this.IDKey);
            ds.Tables[0].Columns.Add("_NOI_DUNG", typeof(System.String));
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                item["_NOI_DUNG"] = DABaiViet.Instance.HTMLtoText(System.Text.UTF8Encoding.UTF8.GetString((byte[])item["NOI_DUNG"]));
            }
            this.gridControlForum.DataSource = ds.Tables[0];
            //Hien chu de
            QueryBuilder query = new QueryBuilder(@"SELECT DD.CHU_DE, NDD.NAME AS NDD_NAME, CM.NAME AS CM_NAME FROM BAI_VIET DD, NHOM_DIEN_DAN NDD, CHUYEN_MUC CM WHERE 1=1");
            query.addCondition("DD.ID_NHOM_DIEN_DAN=NDD.ID");
            query.addCondition("DD.ID_CHUYEN_MUC=CM.ID");
            query.addID("DD.ID", this.IDKey);
            DataSet _ds = HelpDB.getDBService().LoadDataSet(query);
            if (_ds != null && _ds.Tables[0].Rows.Count > 0)
            {
                this.gridViewForum.ViewCaption = _ds.Tables[0].Rows[0]["NDD_NAME"].ToString() + "/" + _ds.Tables[0].Rows[0]["CM_NAME"].ToString() + "/" + _ds.Tables[0].Rows[0]["CHU_DE"].ToString();
            }
            

        }
        public void _Init() {
            //1.Repository cho cột
            HelpBandedGrid.CotCombobox((GridColumn)cotNguoiThaoLuan, HelpDB.LoadTable(new QueryBuilder("SELECT * FROM DM_NHAN_VIEN WHERE 1=1")) , "ID", "NAME", "NGUOI_GUI");
            HelpBandedGrid.CotPLTimeEdit((GridColumn)cotThoiGian, "NGAY_GUI", PLConst.FORMAT_DATETIME_STRING);
            HelpBandedGrid.SetHorzAlignment((GridColumn)cotThoiGian, DevExpress.Utils.HorzAlignment.Near);
            HelpBandedGrid.CotTextLeft((GridColumn)cotFileDK, "TEN_FILE");
            cotFileDK.OptionsColumn.ReadOnly = true;
            this.gridViewForum.OptionsBehavior.Editable = false;
            //
            StyleFormatCondition condition = new StyleFormatCondition();
            condition.Appearance.Options.UseForeColor = true;
            condition.Appearance.ForeColor = Color.Red;
            condition.Appearance.Font = new Font(condition.Appearance.Font, FontStyle.Bold);
            condition.Appearance.Options.UseFont = true;
            condition.Condition = FormatConditionEnum.Expression;
            condition.Expression = "[TEN_FILE] != ''";
            condition.Column = cotFileDK;
            gridViewForum.FormatConditions.Add(condition); 
            //
            HelpBandedGrid.SetHorzAlignment((GridColumn)cotFileDK, DevExpress.Utils.HorzAlignment.Far);
            CotRichTextEdit(cotNoiDung, "_NOI_DUNG");
            CotButton(cotCapNhat, "Cập nhật", Update);
            CotButton(cotXoa, "Xóa", Delete);
            CotButton(cotTraLoi, "Trả lời", ReSend);
            cotXoa.OptionsColumn.ReadOnly = false;
            cotCapNhat.OptionsColumn.ReadOnly = false;
            cotTraLoi.OptionsColumn.ReadOnly = false;
            cotCapNhat.FieldName = "UPDATE";
            cotXoa.FieldName = "DELETE";
            cotTraLoi.FieldName = "RESEND";

            ((GridView)this.gridViewForum).OptionsView.RowAutoHeight = true;
            HelpGrid.ShowNumOfRecord(this.gridControlForum);
            _InitData();
        }

        public void Update(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e) {

            DataRow dr = this.gridViewForum.GetDataRow(this.gridViewForum.FocusedRowHandle);
            //frmBaiViet frm = new frmBaiViet(HelpNumber.ParseInt64(dr["ID"]), HelpNumber.ParseInt64(dr["ID_NHOM_DIEN_DAN"]), HelpNumber.ParseInt64(dr["ID_CHUYEN_MUC"]), false, false, dr["CHU_DE"].ToString());
            //ProtocolForm.ShowModalDialog(this, frm);
            _InitData();
        }
        public void Delete(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            DataRow dr = this.gridViewForum.GetDataRow(this.gridViewForum.FocusedRowHandle);
            if (PLMessageBox.ShowConfirmMessage("Bạn có chắc xóa không?") == System.Windows.Forms.DialogResult.Yes)
            {
                DABaiViet.Instance.Delete(HelpNumber.ParseInt64(dr["ID"]));
                _InitData();
                if (DecreaseSoLanTraLoiViewForum != null) DecreaseSoLanTraLoiViewForum();
            }
        }
        public void ReSend(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            DataRow dr = this.gridViewForum.GetDataRow(this.gridViewForum.FocusedRowHandle);
            //frmAddForum frm = new frmAddForum(this.IDKey, HelpNumber.ParseInt64(dr["ID_NHOM_DIEN_DAN"]), HelpNumber.ParseInt64(dr["ID_CHUYEN_MUC"]), true, false, dr["CHU_DE"].ToString());
            //frmBaiViet frm = new frmBaiViet(this.IDKey, HelpNumber.ParseInt64(dr["ID_NHOM_DIEN_DAN"]), HelpNumber.ParseInt64(dr["ID_CHUYEN_MUC"]), true, false, dr["CHU_DE"].ToString());
            //frm.ChangeFieldSoLanTraLoiBaiViet += new frmBaiViet.Update_SoLanTraLoiBaiViet(CallDelegate);
            //HelpProtocolForm.ShowModalDialog(this, frm);
            _InitData();
        }

        #region Hỗ trợ
        public delegate void ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e);

        public static void CotButton(BandedGridColumn column,string CaptionButton,ButtonClick clickEvent) {
           
            DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit rep = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject = new DevExpress.Utils.SerializableAppearanceObject();
            rep.AutoHeight = false;
            rep.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            serializableAppearanceObject.Options.UseTextOptions = true;
            rep.Buttons.Clear();
            rep.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, CaptionButton, 20, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject, "", null, null, true)});
            rep.Name = "repositoryItemButtonEdit1";
            rep.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            rep.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(clickEvent);
            column.ColumnEdit = rep;
        }

        public static RepositoryItemRichTextEdit CotRichTextEdit(BandedGridColumn column, string ColumnField)
        {
            DevExpress.XtraEditors.Repository.RepositoryItemRichTextEdit rep = new DevExpress.XtraEditors.Repository.RepositoryItemRichTextEdit();
            column.ColumnEdit = rep;
            column.FieldName = ColumnField;
            return rep;
        }
        #endregion

        private void gridViewForum_MeasurePreviewHeight(object sender, RowHeightEventArgs e)
        {
           
        }

        private void gridViewForum_Click(object sender, EventArgs e)
        {
            GridHitInfo gHitInfo = gridViewForum.CalcHitInfo(gridViewForum.GridControl.PointToClient(Control.MousePosition));
            if (gHitInfo.InRowCell)//Nếu vị trí click là cell trong row
            {
                if (gHitInfo.Column.FieldName == "TEN_FILE" && gridViewForum.GetDataRow(gridViewForum.FocusedRowHandle)["TEN_FILE"].ToString().Length > 0)//Nếu cell được click thuộc _columnField
                {
                    WaitingMsg m = new WaitingMsg();
                    frmSaveOpen frm = new frmSaveOpen(DALuuTruTapTin.Instance.Load(HelpNumber.ParseInt64(gridViewForum.GetDataRow(gridViewForum.FocusedRowHandle)["TAP_TIN_ID"])).NOI_DUNG, gridViewForum.GetDataRow(gridViewForum.FocusedRowHandle)["TEN_FILE"].ToString());
                    m.Finish();
                    HelpProtocolForm.ShowModalDialog(this, frm);
                }
                else if (gHitInfo.Column.FieldName == "UPDATE") {
                    Update(null, null);
                }
                else if (gHitInfo.Column.FieldName == "DELETE") {
                    Delete(null, null);
                }
                else if (gHitInfo.Column.FieldName == "RESEND")
                {
                    ReSend(null, null);
                }
            }
        }

        private void gridViewForum_MouseMove(object sender, MouseEventArgs e)
        {
            GridHitInfo gHitInfo = gridViewForum.CalcHitInfo(gridViewForum.GridControl.PointToClient(Control.MousePosition));
            if (gHitInfo.InRowCell)//Nếu vị trí click là cell trong row
            { 
                if (gHitInfo.Column.FieldName == "TEN_FILE" && gridViewForum.GetDataRow(gHitInfo.RowHandle)["TEN_FILE"].ToString().Length > 0)//Nếu cell được click thuộc _columnField
                    this.gridControlForum.Cursor = System.Windows.Forms.Cursors.Hand;
                else
                    this.gridControlForum.Cursor = System.Windows.Forms.Cursors.Default;
            }
        }

        private void frmViewForum_Load(object sender, EventArgs e)
        {
            //HelpXtraForm.SetFix(this);
            HelpXtraForm.SetCloseForm(this, btnClose, null);
        }

        private void CallDelegate() {
            if (IncreaseSoLanTraLoiViewForum != null) IncreaseSoLanTraLoiViewForum();
        }
        
    }
}
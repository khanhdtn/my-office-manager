using System;
using System.Data;
using System.Windows.Forms;
using ProtocolVN.Framework.Core;
using ProtocolVN.Framework.Win;
using DevExpress.XtraEditors.DXErrorProvider;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraTab;
using DAO;
using System.Text.RegularExpressions;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using ProtocolVN.DanhMuc;
using DTO;
using System.Collections.Generic;
using System.Data.Common;
using System.Drawing;
using ProtocolVN.App.Office;
using System.IO;
using DevExpress.XtraGrid.Views.Layout.ViewInfo;
using DevExpress.XtraGrid;

namespace office
{
    public partial class frmTaoKhachHangMoi : XtraFormPL
    {
        #region Vùng đặt Static
        public static FormStatus Status = FormStatus.FIX;
        public static string MenuItem(string ParentID, bool IsSep)
        {
            return MenuBuilder.CreateItem(typeof(frmTaoKhachHangMoi).FullName,
                HelpDebug.UpdateTitle("Tạo mới", Status),
                ParentID, true,
                typeof(frmTaoKhachHangMoi).FullName,
                false, IsSep, "add.png", true, "", "");
        }
        #endregion

        // TRANGDTT NC Độ ưu tiên : 1.Khẩn cấp , 2.Cao , 3.Trung bình , 4.Thấp 
        // Tình trạng : lấy từ bảng DM_TINH_TRANG
        // VULA NC : sửa lại phần Công việc (Độ ưu tiên,Tình trạng)
        private bool? _IsAdd = false;
        private DOKhachHang _KhachHang;
        private DXErrorProvider Error;
        public delegate void RefreshData(DOKhachHang doKhachHang);
        public event RefreshData RefreshUpdate;
        public event RefreshData RefreshInsert;
        #region  Hàm dựng
        public frmTaoKhachHangMoi() : this(-2, true) { }
        public frmTaoKhachHangMoi(long _KH_ID, bool? IsAdd)
        {
            InitializeComponent();
            this._IsAdd = IsAdd;
            if (IsAdd == null)
            {
                cot_suafile.LayoutViewField.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                cot_xoa.LayoutViewField.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                colXoa_DA.LayoutViewField.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                colSua_DA.LayoutViewField.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                colXoa.Visible = colXoaNK.Visible = false;
                btnThem.Visible = false;
            }
            else if (IsAdd == true)
            {
                btnThem.Visible = false;
                tabControlChiTiet.TabPages[1].PageEnabled = tabControlChiTiet.TabPages[2].PageEnabled = false;
            }
            customerTreeNKH.CreateTree();
            InitValidation();
            InitGrid();
            InitData(_KH_ID);
            gridControlDuAn.MouseMove += new MouseEventHandler(gridControlDuAn_MouseMove);
        }


        #endregion
        #region InitForm
        private void InitValidation()
        {
            this.Error = HelpInputData.GetErrorProvider(this);
            HelpInputData.SetMaxLength(
                new object[]{
                        TenKH, 200,
                        DiaChi, 800,
                        ThongTinThem, 1000
                    }
            );
        }
        public void InitGrid()
        {
            InitGridThongTinLienHe();
            InitGridThongTinLienLac();
            InitGridCongViec_QLKH();
            gridViewCongviec.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
            if (this._IsAdd != null)
            {
                XtraGridSupportExt.CloseButton(gridControlThongTinLienLac, gridViewThongtinlienlac).Caption = string.Empty;
                XtraGridSupportExt.CloseButton(gridControlThongTinLienHe, gridViewThongtinlienhe).Caption = string.Empty;
            }
            else
            {
                gridViewThongtinlienhe.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
                foreach (GridColumn cl in gridViewThongtinlienhe.Columns)
                {
                    if (cl.FieldName == "DIA_CHI" || cl.FieldName == "THONG_TIN_KHAC")
                        cl.OptionsColumn.ReadOnly = true;
                    else
                    {
                        cl.OptionsColumn.AllowEdit = false;
                        cl.OptionsColumn.AllowFocus = false;
                    }
                }
                gridViewThongtinlienlac.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
                foreach (GridColumn cl in gridViewThongtinlienlac.Columns)
                {
                    if (cl.FieldName == "DIA_CHI" || cl.FieldName == "THONG_TIN_KHAC")
                        cl.OptionsColumn.ReadOnly = true;
                    else
                    {
                        cl.OptionsColumn.AllowEdit = false;
                        cl.OptionsColumn.AllowFocus = false;
                    }
                }
                this.btnLuu.Visible = false;
            }
        }
        public void InitGridThongTinLienHe()
        {
            HelpGridColumn.CotTextLeft(cot_DB_Ho_Ten, "HO_TEN");
            HelpGridColumn.CotTextLeft(cot_DB_Chuc_Vu, "CHUC_VU");
            HelpGridColumn.CotTextLeft(cot_DB_Bo_Phan, "BO_PHAN");
            HelpGridColumn.CotMemoExEdit(cot_DB_Dia_Chi, "DIA_CHI");
            HelpGridColumn.CotTextLeft(cot_DB_Dien_Thoai, "DIEN_THOAI");
            HelpGridColumn.CotTextLeft(cot_DB_Email, "EMAIL");
            HelpGridColumn.CotMemoExEdit(cot_DB_Thong_Tin_Khac, "THONG_TIN_KHAC");
            HelpGridColumn.CotTextLeft(cot_DB_Fax, "FAX");
        }
        public void InitGridThongTinLienLac()
        {
            HelpGridColumn.CotTextLeft(cot_BP_Bo_phan, "BO_PHAN");
            HelpGridColumn.CotMemoExEdit(cot_BP_Dia_Chi, "DIA_CHI");
            HelpGridColumn.CotTextLeft(cot_BP_Dien_Thoai, "DIEN_THOAI");
            HelpGridColumn.CotTextLeft(cot_BP_Email, "EMAIL");
            HelpGridColumn.CotTextLeft(cot_BP_Fax, "FAX");
            HelpGridColumn.CotMemoExEdit(cot_BP_Thong_Tin_Khac, "THONG_TIN_KHAC");
        }
        public void InitGridCongViec_QLKH()
        {
            #region grid Công việc
            HelpGridColumn.CotTextLeft(CotLoaiCongViec, "LCV_ID");
            HelpGridColumn.CotTextLeft(Congviec, "CONG_VIEC");
            HelpGridColumn.CotTextLeft(Cotnguoigiao, "NGUOI_GIAO");
            HelpGridExt1.colMultiline(CotNguoiThucHien, "NV_THAM_GIA");
            HelpGridColumn.CotTextCenter(CotTienDo, "TONG_TIEN_DO");
            HelpGridColumn.CotDateEdit(Cotbatdau, "NGAY_BAT_DAU");
            HelpGridColumn.CotDateEdit(Cotngayketthuc, "NGAY_KET_THUC");
            HelpGridColumn.CotDateEdit(cotNgayKTTT, "NGAY_KTTT");
            HelpGridColumn.CotDateEdit(CotTGdutinh, "THOI_GIAN_DU_KIEN");
            XtraGridSupportExt.TextLeftColumn(CotDouutien, "TEN_MUC_UU_TIEN");
            XtraGridSupportExt.TextLeftColumn(CotTinhtrang, "TINH_TRANG");
            /////////////////////////////
            StyleFormatCondition conditionBlue = new StyleFormatCondition();
            conditionBlue.Appearance.Options.UseForeColor = true;
            conditionBlue.Appearance.ForeColor = Color.Blue;
            conditionBlue.Condition = FormatConditionEnum.Expression;
            conditionBlue.Expression = "([NGAY_KET_THUC] >= [NGAY_KTTT] and not(IsNull([NGAY_KTTT]))) or(IsNull([NGAY_KET_THUC]) and not(IsNull([NGAY_KTTT]))) ";
            conditionBlue.ApplyToRow = true;

            StyleFormatCondition conditionRed = new StyleFormatCondition();
            conditionRed.Appearance.Options.UseForeColor = true;
            conditionRed.Appearance.ForeColor = Color.Red;
            conditionRed.Condition = FormatConditionEnum.Expression;
            conditionRed.Expression = "[NGAY_KET_THUC] < [NGAY_KTTT] and not(IsNull([NGAY_KET_THUC]))";
            conditionRed.ApplyToRow = true;
            gridViewCongviec.FormatConditions.AddRange(new StyleFormatCondition[] { conditionBlue, conditionRed });
                        
            #endregion

            #region layout Dự án

            XtraGridSupportExt.TextLeftColumn(colTen_DA, "NAME");
            XtraGridSupportExt.TextLeftColumn(colLoaiDA, "TEN_DA");
            XtraGridSupportExt.TextLeftColumn(colNguoi_QL, "TEN_NGUOI_QL");
            XtraGridSupportExt.TextLeftColumn(colT_trang, "TINH_TRANG");
            XtraGridSupportExt.TextLeftColumn(colNgay_BD_DA, "NGAY_BAT_DAU");
            XtraGridSupportExt.TextLeftColumn(colNgayKT, "NGAY_KET_THUC_THUC_TE");
            XtraGridSupportExt.TextLeftColumn(codT_do_DA, "TIEN_DO");
            XtraGridSupportExt.TextLeftColumn(colXem_DA, "XEM_DA");
            XtraGridSupportExt.TextLeftColumn(colTao_CV, "TAO_CV");
            XtraGridSupportExt.TextLeftColumn(colXoa_DA, "XOA_DA");
            XtraGridSupportExt.TextLeftColumn(colSua_DA, "SUA_DA");
            layoutViewDuAn.OptionsHeaderPanel.EnableCustomizeButton = false;
            layoutViewDuAn.OptionsCustomization.AllowSort = false;
            layoutViewDuAn.OptionsCustomization.AllowFilter = false;
            layoutViewDuAn.OptionsBehavior.AllowSwitchViewModes = true;
            layoutViewDuAn.OptionsBehavior.AllowExpandCollapse = true;
            layoutViewDuAn.OptionsView.ShowCardCaption = true;
            layoutViewDuAn.Appearance.CardCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;

            #endregion

            #region layout tài liệu

            XtraGridSupportExt.TextLeftColumn(lvTieuDe, "TIEU_DE");
            XtraGridSupportExt.TextLeftColumn(lvFile_dinh_kem, "TEN_FILE");
            XtraGridSupportExt.TextLeftColumn(lvNguoiCapNhat, "TEN_NGUOI_CN");
            XtraGridSupportExt.TextLeftColumn(lvNgayCapNhat, "NGAY_CAP_NHAT");
            HelpGridColumn.CotMemoExEdit(lvGhi_chu, "GHI_CHU");
            XtraGridSupportExt.TextLeftColumn(cotID, "ID");
            HelpGridColumn.CotTextLeft(lvSize, "SIZE");
            XtraGridSupportExt.TextLeftColumn(cot_xoa, "xoa_file");
            XtraGridSupportExt.TextLeftColumn(cot_luufile, "luu_file");
            XtraGridSupportExt.TextLeftColumn(cot_mofile, "mo_file");
            XtraGridSupportExt.TextLeftColumn(cot_suafile, "sua_file");

            lvGhi_chu.OptionsColumn.ReadOnly = true;
            layoutView1.OptionsCustomization.AllowSort = false;
            layoutView1.OptionsCustomization.AllowFilter = false;
            layoutView1.OptionsBehavior.AllowSwitchViewModes = true;
            layoutView1.OptionsBehavior.AllowExpandCollapse = true;
            layoutView1.OptionsView.ShowCardCaption = true;
            layoutView1.Appearance.CardCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

            #endregion

            #region grid GhiNhatKy
            HelpGridColumn.CotReadOnlyDate(colTGCapNhat, "THOI_GIAN_CAP_NHAT", PLConst.FORMAT_DATETIME_STRING);
            HelpGridColumn.CotTextLeft(colNguoiCapNhat, "NGUOI_THUC_HIEN");
            HelpGridColumn.CotMemoExEdit(colNoiDung, "GHI_CHU");
            gridViewNhatKy.OptionsBehavior.Editable = true;
            colNoiDung.OptionsColumn.AllowEdit = true;
            colNoiDung.OptionsColumn.ReadOnly = true;

            #endregion
        }

        public void InitData(long id)
        {
            this._KhachHang = DAKhachHangX.Instance.LoadAll(id);
            if (_KhachHang.KH_ID == 0)
            {
                _KhachHang.KH_ID = HelpDB.getDatabase().GetID("G_NGHIEP_VU");
                gridControlThongTinLienHe.DataSource = _KhachHang.DetailDataSetTTLH.Tables[0];
                gridControlThongTinLienLac.DataSource = _KhachHang.DetailDataSetTTLL.Tables[0];
            }
            else
            {
                TenKH.EditValue = _KhachHang.TEN_KHACH_HANG;
                DiaChi.EditValue = _KhachHang.DIA_CHI;
                DienThoai.EditValue = _KhachHang.DIEN_THOAI;
                Fax.EditValue = _KhachHang.FAX;
                Email.EditValue = _KhachHang.EMAIL;
                WebSite.EditValue = _KhachHang.WEBSITE;
                customerTreeNKH.SetSelectedID(_KhachHang.NKH_ID);
                LinhVucHoatDong.EditValue = _KhachHang.LINH_VUC_HOAT_DONG;
                ThongTinThem.EditValue = _KhachHang.THONG_TIN_THEM;
                gridControlThongTinLienHe.DataSource = _KhachHang.DetailDataSetTTLH.Tables[0];
                gridControlThongTinLienLac.DataSource = _KhachHang.DetailDataSetTTLL.Tables[0];
            }
        }
        private void frmTaoKhachHangMoi_Load(object sender, EventArgs e)
        {
            layoutView1.OptionsHeaderPanel.EnableCustomizeButton = false;
            HelpDebug.SetTitle(this, Status);
            HelpXtraForm.SetCloseForm(this, btnDong, _IsAdd);
            HelpInputData.SetMaxLength(new object[] {
                TenKH,200,
                DiaChi,7000,
                DienThoai,100,
                Fax,100,
                Email,100,
                WebSite,200,
                LinhVucHoatDong,7000,
                ThongTinThem,2000
            });

            gridViewThongtinlienhe.BestFitColumns();
            gridViewThongtinlienlac.BestFitColumns();
            gridViewThongtinlienhe.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(gridViewThongTinLienHe_ValidateRow);
            gridViewThongtinlienlac.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(gridViewThongTinLienLac_ValidateRow);
            gridViewCongviec.DoubleClick += new EventHandler(gridViewCongviec_DoubleClick);

            HelpXtraForm.SetFix(this);
            
        }

        #endregion

        #region Validate
        public bool ValidateData()
        {
            Error.ClearErrors();
            bool errorCustomer = false;
            if (Email.Text.Length > 0 && !Regex.IsMatch(Email.Text, PLConst.EXPRESSION_EMAIL))
                Error.SetError(Email, "Email không hợp lệ!");
            if (WebSite.Text.Length > 0 && !Regex.IsMatch(WebSite.Text, DAWebsite.RegexWebsite(WebSite.Text)))
                Error.SetError(WebSite, "Website không hợp lệ!");
            if (customerTreeNKH.IsEmptyTree())
            {
                HelpMsgBox.ShowNotificationMessage("Vui lòng vào thông tin \"Nhóm khách hàng\"!");
                errorCustomer = true;
            }
            HelpInputData.ShowRequiredError(Error,
                new object[]{
                        TenKH, "Tên khách hàng",                        
                        DiaChi, "Địa chỉ",
                        LinhVucHoatDong,"Lĩnh vực hoạt động"
                    }
                    );
            return !Error.HasErrors && !errorCustomer;
        }
        public void gridViewCongviec_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            PLGridView grid = ((PLGridView)sender);
            DataRow row = grid.GetDataRow(e.RowHandle);
            if (!DAKhachHangX.Instance.ValidateDetail(row, _KhachHang.DetailDataSetCV.Tables[0].TableName))
            {
                e.Valid = false;
                return;
            }
            if (DAKhachHangX.Instance.CkeckDuplicate(grid, _KhachHang.DetailDataSetCV, "PCCV_ID", "Công việc"))
            {
                e.Valid = false;
                return;
            }
            row["KH_ID"] = _KhachHang.KH_ID;
        }
        public void gridViewThongTinLienLac_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            PLGridView grid = ((PLGridView)sender);
            DataRow row = grid.GetDataRow(e.RowHandle);
            if (row == null) return;
            row.ClearErrors();
            if (!DAKhachHangX.Instance.ValidateDetail(row, _KhachHang.DetailDataSetTTLL.Tables[0].TableName))
            {
                e.Valid = false;
                return;
            }
            if (!Regex.IsMatch(row["EMAIL"].ToString(), PLConst.EXPRESSION_EMAIL) && row["EMAIL"].ToString().Trim() != string.Empty)
            {
                row.SetColumnError("EMAIL", "Email không hợp lệ!");
                e.Valid = false;
                return;
            }
            if (!HelpInputData.ValidateRow(gridViewThongtinlienhe, row, DAKhachHangX.Instance.GetMaxLengthTTLL()))
            {
                e.Valid = false;
                return;
            }
            row["ID"] = HelpDB.getDatabase().GetID("G_NGHIEP_VU");
            row["KH_ID"] = _KhachHang.KH_ID;
        }
        public void gridViewThongTinLienHe_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            PLGridView grid = ((PLGridView)sender);
            DataRow row = grid.GetDataRow(e.RowHandle);
            if (row == null) return;
            row.ClearErrors();
            if (!DAKhachHangX.Instance.ValidateDetail(row, _KhachHang.DetailDataSetTTLH.Tables[0].TableName))
            {
                e.Valid = false;
                return;
            }
            if (!Regex.IsMatch(row["EMAIL"].ToString(), PLConst.EXPRESSION_EMAIL) && row["EMAIL"].ToString().Trim() != string.Empty)
            {
                row.SetColumnError("EMAIL", "Email không hợp lệ!");
                e.Valid = false;
                return;
            }
            if (!HelpInputData.ValidateRow(gridViewThongtinlienhe, row, DAKhachHangX.Instance.GetMaxLengthTTLH()))
            {
                e.Valid = false;
                return;
            }
            row["ID"] = HelpDB.getDatabase().GetID("G_NGHIEP_VU");
            row["KH_ID"] = _KhachHang.KH_ID;
        }
        public void gridViewTaiLieu_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            PLGridView grid = ((PLGridView)sender);
            DataRow row = grid.GetDataRow(e.RowHandle);
            if (!DAKhachHangX.Instance.ValidateDetail(row, _KhachHang.DetailDataSetTL.Tables[0].TableName))
            {
                e.Valid = false;
                return;
            }
            row["KH_ID"] = _KhachHang.KH_ID;
        }
        private void gridViewCongviec_DoubleClick(object sender, EventArgs e)
        {
            PLGridView grid = (PLGridView)sender;
            if (grid.RowCount <= 0) return;
            else if (!grid.IsGroupRow(grid.FocusedRowHandle))
            {
                if (_IsAdd == null)
                {
                    FWWaitingMsg m = new FWWaitingMsg();
                    Congviec obj = new Congviec(HelpNumber.ParseInt64(grid.GetDataRow(grid.FocusedRowHandle)["PCCV_ID"]), null);
                    m.Finish();
                    HelpProtocolForm.ShowModalDialog(this, obj);
                }
                    ////HIEUNT:mới thêm sửa công việc từ khách hàng
                else if (_IsAdd == false)
                {
                    if (HelpNumber.ParseInt64(grid.GetDataRow(grid.FocusedRowHandle)["TINH_TRANG_ID"]) != 4)
                    {
                        FWWaitingMsg m = new FWWaitingMsg();
                        Congviec obj = new Congviec(HelpNumber.ParseInt64(grid.GetDataRow(grid.FocusedRowHandle)["PCCV_ID"]), false);
                        m.Finish();
                        HelpProtocolForm.ShowModalDialog(this, obj);
                        LoadGridViewCongViec();
                    }
                    else
                    {
                        HelpMsgBox.ShowNotificationMessage("Công việc đã hoàn tất không được sửa!");
                    }
                }               
            }
        }
        private void gridViewTaiLieu_DoubleClick(object sender, EventArgs e)
        {
            PLGridView grid = (PLGridView)sender;
            if (grid.RowCount <= 0) return;
            else if (!grid.IsGroupRow(grid.FocusedRowHandle))
            {
                FWWaitingMsg m = new FWWaitingMsg();
                frmThemTaiLieu frm = new frmThemTaiLieu(HelpNumber.ParseInt64(grid.GetDataRow(grid.FocusedRowHandle)["TAP_TIN_ID"]), (_IsAdd == null ? _IsAdd : false), _KhachHang.KH_ID, (long)LoaiTapTin.KhachHangTaptin);
                m.Finish();
                HelpProtocolForm.ShowModalDialog(this, frm);
            }
        }
        private void gridViewTaiLieu_Click(object sender, EventArgs e)
        {
            GridHitInfo gHitInfo = gridViewTaiLieu.CalcHitInfo(gridViewTaiLieu.GridControl.PointToClient(Control.MousePosition));
            if (gHitInfo.InRowCell)//Nếu vị trí click là cell trong row
            {
                if (gHitInfo.Column.FieldName == "TEN_FILE")//Nếu cell được click thuộc _columnField
                {
                    FWWaitingMsg m = new FWWaitingMsg();
                    frmSaveOpen frm = new frmSaveOpen(DALuuTruTapTin.Instance.Load(HelpNumber.ParseInt64(gridViewTaiLieu.GetDataRow(gridViewTaiLieu.FocusedRowHandle)["TAP_TIN_ID"])).NOI_DUNG, gridViewTaiLieu.GetDataRow(gridViewTaiLieu.FocusedRowHandle)["TEN_FILE"].ToString());
                    m.Finish();
                    HelpProtocolForm.ShowModalDialog(this, frm);
                }
            }
        }
        public bool GetData()
        {
            HelpInputData.TrimAllData(new object[]{
                    TenKH,
                    ThongTinThem
                });
            if (ValidateData())
            {
                _KhachHang.TEN_KHACH_HANG = this.TenKH.Text;
                _KhachHang.DIA_CHI = DiaChi.Text;
                _KhachHang.DIEN_THOAI = DienThoai.Text;
                _KhachHang.FAX = Fax.Text;
                _KhachHang.EMAIL = Email.Text;
                _KhachHang.WEBSITE = WebSite.Text;
                _KhachHang.NKH_ID = customerTreeNKH.GetSelectedID();
                _KhachHang.LINH_VUC_HOAT_DONG = LinhVucHoatDong.Text;
                _KhachHang.THONG_TIN_THEM = ThongTinThem.Text;
                return true;
            }
            return false;
        }
        #endregion

        #region Xử lý nút

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (GetData())
            {
                if (DAKhachHangX.Instance.Update(_KhachHang))
                {
                    if (_IsAdd == true)
                    {
                        HelpMsgBox.ShowNotificationMessage("Lưu thông tin thành công!");
                        if (this.RefreshInsert != null) RefreshInsert(_KhachHang);
                        tabControlChiTiet.TabPages[1].PageEnabled = tabControlChiTiet.TabPages[2].PageEnabled = true;
                        btnThem.Visible = true;
                    }
                    else
                    {
                        if (this.RefreshUpdate != null) RefreshUpdate(_KhachHang);
                        HelpXtraForm.CloseFormNoConfirm(this);
                    }
                }
                else ErrorMsg.ErrorSave(this);
            }
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
        }
        #endregion

        #region  Xu li tai lieu
        private void tabControlChiTiet_SelectedPageChanged(object sender, TabPageChangedEventArgs e)
        {
            LoadDataForSelectedTab(true);
        }
        private void LoadCardViewTapTin()
        {
            try
            {                
                string qr = string.Format(@"SELECT LUU_TRU_TAP_TIN.*,
                (SELECT NAME FROM DM_NHAN_VIEN WHERE ID = LUU_TRU_TAP_TIN.NGUOI_CAP_NHAT) TEN_NGUOI_CN 
                FROM LUU_TRU_TAP_TIN 
                WHERE ID IN (SELECT TAP_TIN_ID FROM OBJECT_TAP_TIN WHERE OBJECT_ID={0} AND TYPE_ID=8)", _KhachHang.KH_ID);
                DataSet ds = HelpDB.getDatabase().LoadDataSet(qr);
                ds.Tables[0].Columns.Add("mo_file", typeof(Image));
                ds.Tables[0].Columns.Add("luu_file", typeof(Image));
                ds.Tables[0].Columns.Add("xoa_file", typeof(Image));
                ds.Tables[0].Columns.Add("sua_file", typeof(Image)); 
                ds.Tables[0].Columns.Add("SIZE", typeof(String));
                foreach (DataRow r in ds.Tables[0].Rows)
                {
                    r["mo_file"] = FWImageDic.VIEW_IMAGE20;
                    r["luu_file"] = FWImageDic.SAVE_IMAGE20;
                    r["xoa_file"] = FWImageDic.DELETE_IMAGE20;
                    r["sua_file"] = FWImageDic.EDIT_IMAGE20;

                    byte[] a = r["NOI_DUNG"] as byte[];
                    r["SIZE"] = HelpNumber.RoundDecimal(HelpNumber.ParseDecimal(a.Length) / 1024, 3).ToString();
                }
                gridControlTaiLieu.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                PLException.AddException(ex);
                HelpSysLog.AddException(ex, "");
            }
        }

        private void gridControlTaiLieu_MouseMove(object sender, MouseEventArgs e)
        {
            LayoutViewHitInfo layouthit = layoutView1.CalcHitInfo(layoutView1.GridControl.PointToClient(Control.MousePosition));
            if (layouthit.Column != null)
            {
                if (layouthit.Column.Name == "cot_xoa")
                {
                    toolTip1.Show("Xoá tập tin", this, MousePosition.X - this.Location.X, MousePosition.Y - this.Location.Y + 20, 500);
                }
                if (layouthit.Column.Name == "cot_suafile")
                {
                    toolTip1.Show("Sửa tập tin", this, MousePosition.X - this.Location.X, MousePosition.Y - this.Location.Y + 20, 500);
                }
                if (layouthit.Column.Name == "cot_mofile")
                {
                    toolTip1.Show("Mở tập tin", this, MousePosition.X - this.Location.X, MousePosition.Y - this.Location.Y + 20, 500);
                }
                if (layouthit.Column.Name == "cot_luufile")
                {
                    toolTip1.Show("Lưu tập tin", this, MousePosition.X - this.Location.X, MousePosition.Y - this.Location.Y + 20, 500);
                }
            }
        }
        void gridControlDuAn_MouseMove(object sender, MouseEventArgs e)
        {
            LayoutViewHitInfo layouthit = layoutViewDuAn.CalcHitInfo(layoutViewDuAn.GridControl.PointToClient(Control.MousePosition));
            if (layouthit.Column != null)
            {
                if (layouthit.Column.Name == "colXoa_DA")
                {
                    toolTip1.Show("Xoá dự án", this, MousePosition.X - this.Location.X, MousePosition.Y - this.Location.Y + 20, 500);
                } 
                if (layouthit.Column.Name == "colSua_DA")
                {
                    toolTip1.Show("Sửa dự án", this, MousePosition.X - this.Location.X, MousePosition.Y - this.Location.Y + 20, 500);
                }
                if (layouthit.Column.Name == "colXem_DA")
                {
                    toolTip1.Show("Xem dự án", this, MousePosition.X - this.Location.X, MousePosition.Y - this.Location.Y + 20, 500);
                }
                if (layouthit.Column.Name == "colTao_CV")
                {
                    toolTip1.Show("Tạo công việc", this, MousePosition.X - this.Location.X, MousePosition.Y - this.Location.Y + 20, 500);
                }
            }
        }
        #region Xử lý sự kiện trên layout
        /// <summary>
        /// Mở tập tin.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rep_mofile_Click(object sender, EventArgs e)
        {
            DataRow row = layoutView1.GetDataRow(layoutView1.FocusedRowHandle);
            DOLuuTruTapTin do_tt = DALuuTruTapTin.Instance.Load(HelpNumber.ParseInt64(row["ID"]));
            DADocument.Instance.Open_file_from_byte(do_tt.NOI_DUNG, do_tt.TEN_FILE);
        }
        /// <summary>
        /// Lưu tập tin.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rep_luufile_Click(object sender, EventArgs e)
        {
            DataRow row = layoutView1.GetDataRow(layoutView1.FocusedRowHandle);
            DOLuuTruTapTin do_tt = DALuuTruTapTin.Instance.Load(HelpNumber.ParseInt64(row["ID"]));
            DADocument.Instance.Save_file_from_byte(do_tt.NOI_DUNG, do_tt.TEN_FILE);
        }
        /// <summary>
        /// Xóa tập tin.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rep_xoa_Click(object sender, EventArgs e)
        {
            if (_IsAdd != null)
            {
                DataRow r = layoutView1.GetDataRow(layoutView1.FocusedRowHandle);
                if (r != null)
                {
                    long id_taptin = HelpNumber.ParseInt64(r["ID"]);
                    DAKhachHangX.Xoa_TaiLieuKH(id_taptin);
                    DALuuTruTapTin.Instance.Delete(id_taptin);
                    layoutView1.DeleteSelectedRows();
                }
            }
        }
        /// <summary>
        /// Sửa tập tin.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rep_sua_Click(object sender, EventArgs e)
        {
            if (_IsAdd != null)
            {
                DataRow r = layoutView1.GetDataRow(layoutView1.FocusedRowHandle);
                if (r != null)
                {
                    frmThemTaiLieu frm = new frmThemTaiLieu(HelpNumber.ParseInt64(r["ID"]), false, _KhachHang.KH_ID, (long)LoaiTapTin.KhachHangTaptin);
                    HelpProtocolForm.ShowModalDialog(this, frm);
                    LoadCardViewTapTin();
                }
            }
        }
        /// <summary>
        /// Xem dự án.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void repImage_Click(object sender, EventArgs e)
        {
            DataRow row = layoutViewDuAn.GetDataRow(layoutViewDuAn.FocusedRowHandle);
            if (row != null)
            {
                frmDuAn frm = new frmDuAn(HelpNumber.ParseInt64(row["ID"]), null);
                HelpProtocolForm.ShowDialog(this, frm);
            }
        }
        /// <summary>
        /// Sửa dự án
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void repImageSuaDA_Click(object sender, EventArgs e)
        {
            DataRow row = layoutViewDuAn.GetDataRow(layoutViewDuAn.FocusedRowHandle);
            if (row != null)
            {
                if (HelpNumber.ParseInt32(row["ID_TT"]) != 5)
                {
                    frmDuAn frm = new frmDuAn(HelpNumber.ParseInt64(row["ID"]), false);
                    HelpProtocolForm.ShowModalDialog(this, frm);

                    decimal tiendo = 0;
                    int phanTram = 0;
                    DataTable v = DADuAn.LoadCongViec(HelpNumber.ParseInt64(row["ID"]));
                    foreach (DataRow r in v.Rows)
                    {
                        tiendo += (HelpNumber.ParseDecimal(r["TIEN_DO"]) * HelpNumber.ParseInt32(r["TONG_PHAN_TRAM_CV"]));
                        phanTram += HelpNumber.ParseInt32(r["TONG_PHAN_TRAM_CV"]);
                    }
                    if (phanTram > 0)
                    {
                        tiendo = HelpNumber.RoundDecimal(tiendo /= phanTram, 2);
                    }
                    ////Hieutn: Lưu lại tiến độ khi thay đổi từ form công việc
                    DADuAn.CapNhatTienDoDuAn(HelpNumber.ParseInt64(row["ID"]), tiendo);
                    LoadCardViewDuAn();
                }
                else
                {
                    HelpMsgBox.ShowNotificationMessage("Dự án đã hoàn thành không được sửa!");
                }
            }
        }
        /// <summary>
        /// Tạo mới công việc cho dự án
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void repImageTaoCV_Click(object sender, EventArgs e)
        {
            DataRow row = layoutViewDuAn.GetDataRow(layoutViewDuAn.FocusedRowHandle);
            if (HelpNumber.ParseInt32(row["ID_TT"]) != 5)
            {
                Congviec frm = new Congviec(-2, true, DADuAn.Instance.GetLongNguoiThucHien(row["NGUOI_THUC_HIEN"].ToString()));
                frm.UpdateCongViec_DuAn += new Congviec.UpdateKH_DA_CV(InsertDuAn_CongViec);
                HelpProtocolForm.ShowModalDialog(this, frm);
                decimal tiendo = 0;
                int phanTram = 0;
                DataTable v = DADuAn.LoadCongViec(HelpNumber.ParseInt64(row["ID"]));
                foreach (DataRow r in v.Rows)
                {
                    tiendo += (HelpNumber.ParseDecimal(r["TIEN_DO"]) * HelpNumber.ParseInt32(r["TONG_PHAN_TRAM_CV"]));
                    phanTram += HelpNumber.ParseInt32(r["TONG_PHAN_TRAM_CV"]);
                }
                if (phanTram > 0)
                {
                    tiendo = HelpNumber.RoundDecimal(tiendo /= phanTram, 2);
                }
                ////Hieutn: Lưu lại tiến độ khi thay đổi từ form công việc
                DADuAn.CapNhatTienDoDuAn(HelpNumber.ParseInt64(row["ID"]), tiendo);
                LoadCardViewDuAn();
            }
            else
            {
                HelpMsgBox.ShowNotificationMessage("Dự án đã hoàn thành không được tạo thêm công việc!");
            }
            
        }
        /// <summary>
        /// Xóa dự án.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void repImageXoaDA_Click(object sender, EventArgs e)
        {
            DataRow row = layoutViewDuAn.GetDataRow(layoutViewDuAn.FocusedRowHandle);
            if (DADuAn.exists_ds_congviec(HelpNumber.ParseInt64(row["ID"]))
                || DADuAn.exists_ds_tailieu(HelpNumber.ParseInt64(row["ID"])))
                HelpMsgBox.ShowNotificationMessage("Đã có phân công công việc hay tập tin cho dự án, không cho phép xóa!");
            else DADuAn.Instance.Delete(HelpNumber.ParseInt64(row["ID"]));
        }
        #endregion
        #endregion

        private void btnthemcongviec_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Congviec frm = new Congviec(-2, true);
            frm.UpdateCongViec_KhachHang += new Congviec.UpdateKH_DA_CV(InsertKhachHang_CongViec);
            HelpProtocolForm.ShowModalDialog(this, frm);
            LoadGridViewCongViec();
        }
        private void barButtonItemGhiNK_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmNhatKyKhachHang frm = new frmNhatKyKhachHang(_KhachHang.KH_ID);
            HelpProtocolForm.ShowModalDialog(this, frm);
            LoadNhatKy();
        }
        private void LoadNhatKy()
        {
            DataTable KQ = HelpDB.getDatabase().LoadDataSet(@"SELECT CT.* ,NV.NAME AS NGUOI_THUC_HIEN
                                                FROM NHAT_KY_KH_DA_CV CT 
                                                LEFT JOIN DM_NHAN_VIEN NV ON CT.MA_NV = NV.ID WHERE CT.KH_ID = " + _KhachHang.KH_ID + " AND 1=1").Tables[0];

            gridControlNhatKy.DataSource = KQ;
        }
        long duAn_id;
        private void barButtonItemDuAn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmDuAn frm = new frmDuAn();
            frm.UpdateDuAn_KhachHang += new frmDuAn.UpdateKH_DA_CV(InsertKhachHang_DuAn);
            HelpProtocolForm.ShowModalDialog(this, frm);
            decimal tiendo = 0;
            int phanTram = 0;
            DataTable v = DADuAn.LoadCongViec(duAn_id);
            foreach (DataRow r in v.Rows)
            {
                tiendo += (HelpNumber.ParseDecimal(r["TIEN_DO"]) * HelpNumber.ParseInt32(r["TONG_PHAN_TRAM_CV"]));
                phanTram += HelpNumber.ParseInt32(r["TONG_PHAN_TRAM_CV"]);
            }
            if (phanTram > 0)
            {
                tiendo = HelpNumber.RoundDecimal(tiendo /= phanTram, 2);
            }
            ////Hieutn: Lưu lại tiến độ khi thay đổi từ form công việc
            DADuAn.CapNhatTienDoDuAn(duAn_id, tiendo);

            LoadCardViewDuAn();
        }

        private void InsertKhachHang_DuAn(long duanID)
        {
            duAn_id = duanID;
            DAKhachHangX.InsertKhachHang_DuAn(duanID, _KhachHang.KH_ID);
        }
        private string getTT(long id)
        {
            string[] arr = { "Mới đề xuất", "Đang lập kế hoạch", "Đang xử lý", "Tạm dừng", "Hoàn thành" };
            return arr[id];
        }

        private void btnthemtailieu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmThemTaiLieu frm = new frmThemTaiLieu(-2, true, _KhachHang.KH_ID, (long)LoaiTapTin.KhachHangTaptin);
            HelpProtocolForm.ShowModalDialog(this, frm);
            LoadCardViewTapTin();
        }
        private void LoadGridViewCongViec()
        {
            DataSet dsCongViec = HelpDB.getDatabase().LoadDataSet(@"SELECT DISTINCT PC.PCCV_ID,PC.LCV_ID, PC.CONG_VIEC, PC.CHI_TIET_CONG_VIEC,KH_DA_CV.KH_ID,KH_DA_CV.DU_AN_ID,
                                  PC.NGAY_BAT_DAU, PC.NGAY_KET_THUC_DU_KIEN NGAY_KET_THUC,PC.NGAY_KET_THUC NGAY_KTTT,
                                  IIF(PC.IS_NGAY ='Y',(PC.THOI_GIAN_DU_KIEN * 8) ||' Giờ', PC.THOI_GIAN_DU_KIEN ||' Giờ') THOI_GIAN_DU_KIEN,
                                  PC.MUC_UU_TIEN,
                                  (CASE PC.MUC_UU_TIEN WHEN 1 THEN 'Cao nhất' ELSE (
                                  CASE PC.MUC_UU_TIEN WHEN 2 THEN 'Cao' ELSE (
                                  CASE PC.MUC_UU_TIEN WHEN 3 THEN 'Trung bình' ELSE (
                                  CASE PC.MUC_UU_TIEN WHEN 4 THEN 'Thấp' ELSE(
                                  CASE PC.MUC_UU_TIEN WHEN 5 THEN 'Thấp nhất' ELSE NULL END) END ) END ) END) END) TEN_MUC_UU_TIEN,
                                   '' TONG_TIEN_DO,
                                  PC.NGUOI_GIAO, TT.NAME AS TINH_TRANG,PC.TINH_TRANG AS TINH_TRANG_ID,
                                  IIF(LCV.NAME IS NOT NULL,(SELECT CV.NAME FROM DM_LOAI_CONG_VIECN CV WHERE PC.LCV_ID = CV.ID ),'Loại công việc khác') TEN_LCV,                                     
                                  (SELECT N.NAME FROM DM_NHAN_VIEN N WHERE PC.NGUOI_GIAO = N.ID) TEN_NGUOI_GIAO
                                  FROM  ((PHAN_CONG_CONG_VIEC PC LEFT JOIN DM_TINH_TRANG TT ON PC.TINH_TRANG = TT.ID )
                                  INNER JOIN DM_LOAI_CONG_VIECN LCV ON PC.LCV_ID = LCV.ID) LEFT JOIN CHI_TIET_PHAN_CONG CT ON PC.PCCV_ID = CT.PCCV_ID
                                  LEFT JOIN KH_DA_CV ON KH_DA_CV.PCCV_ID = PC.PCCV_ID
                                  WHERE KH_DA_CV.KH_ID = " + _KhachHang.KH_ID, "CONG_VIEC_KHACH_HANG");
            DAKhachHangX.Instance.GetDetailDataSetCV(dsCongViec);
            gridControlCongviec.DataSource = dsCongViec.Tables[0];
        }
        private void LoadCardViewDuAn()
        {
            DataTable dt = new DataTable();
            string sql = @"SELECT ID,NAME,B.NGUOI_QUAN_LY,B.NGUOI_THUC_HIEN,
                    (SELECT NAME FROM DM_NHAN_VIEN NV WHERE NV.ID=B.NGUOI_QUAN_LY) TEN_NGUOI_QL,
                    (SELECT NAME FROM DM_LOAI_DU_AN DA WHERE DA.ID=B.LOAI_DU_AN) TEN_DA,
                    NGAY_BAT_DAU,NGAY_KET_THUC,NGAY_KET_THUC_THUC_TE NGAY_KTTT,
                    iif(B.TINH_TRANG = 5, NGAY_KET_THUC_THUC_TE,NGAY_KET_THUC) NGAY_KET_THUC_THUC_TE,
                    TIEN_DO || '%' TIEN_DO,B.TINH_TRANG ID_TT,
                  (CASE B.TINH_TRANG WHEN 1 THEN 'Mới đề xuất' ELSE (
                   CASE B.TINH_TRANG WHEN 2 THEN 'Đang lập kế hoạch' ELSE (
                   CASE B.TINH_TRANG WHEN 3 THEN 'Đang xử lý' ELSE (
                   CASE B.TINH_TRANG WHEN 4 THEN 'Tạm dừng' ELSE(
                   CASE B.TINH_TRANG WHEN 5 THEN 'Hoàn thành' ELSE NULL END) END ) END ) END) END) TINH_TRANG
                    FROM DU_AN B 
                        INNER JOIN KH_DA_CV KH ON KH.DU_AN_ID=B.ID
                        WHERE KH.KH_ID=" + _KhachHang.KH_ID + " AND 1=1";
            dt = HelpDB.getDatabase().LoadDataSet(sql).Tables[0];
            dt.Columns.Add("XEM_DA", typeof(Image));
            dt.Columns.Add("TAO_CV", typeof(Image));
            dt.Columns.Add("SUA_DA", typeof(Image));
            dt.Columns.Add("XOA_DA", typeof(Image));
            foreach (DataRow row in dt.Rows)
            {
                row["XEM_DA"] = FWImageDic.VIEW_IMAGE20;
                row["TAO_CV"] = FWImageDic.ADD_IMAGE20;
                row["SUA_DA"] = FWImageDic.EDIT_IMAGE20;
                row["XOA_DA"] = FWImageDic.DELETE_IMAGE20; 
            }
            gridControlDuAn.DataSource = dt;

        }

        private void InsertKhachHang_CongViec(long congviecID)
        {
            DACongViec.InsertKhachHang_CongViec(congviecID, _KhachHang.KH_ID);
        }

        private void InsertDuAn_CongViec(long congviecID)
        {
            DataRow row = layoutViewDuAn.GetDataRow(layoutViewDuAn.FocusedRowHandle);
            DADuAn.InsertDuAn_CongViec(HelpNumber.ParseInt64(row["ID"]), congviecID);
        }
        /// <summary>
        /// Xóa lưới danh sách công việc.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void repButtonEditDelete_Click(object sender, EventArgs e)
        {
            if (HelpMsgBox.ShowConfirmMessage("Bạn có chắc xóa dữ liệu đang chọn không?") == DialogResult.Yes)
            {
                DataRow selectedRow = gridViewCongviec.GetDataRow(gridViewCongviec.FocusedRowHandle);
                if (selectedRow != null)
                {
                    DACongViec.DeleteAction(HelpNumber.ParseInt64(selectedRow["PCCV_ID"]));
                    DACongViec.DeleteCongViec(HelpNumber.ParseInt64(selectedRow["PCCV_ID"]));
                    gridViewCongviec.DeleteSelectedRows();
                }
            }
        }
        /// <summary>
        /// Xóa lưới danh sách nhật ký.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void repButtonEditDeleteNK_Click(object sender, EventArgs e)
        {
            DataRow r = gridViewNhatKy.GetDataRow(gridViewNhatKy.FocusedRowHandle);
            if (r != null)
            {
                if (HelpMsgBox.ShowConfirmMessage("Bạn có chắc muốn xóa dữ liệu đang chọn không? ") == DialogResult.Yes)
                {
                    DACongViec.DeleteNhatKy(HelpNumber.ParseInt64(r["ID"]));
                    gridViewNhatKy.DeleteSelectedRows();
                }
            }
        }

        #region Extensions
        /// <summary>
        /// True: when called in TagPageChanged event, otherwise: false.
        /// </summary>
        /// <param name="isSelectedTab"></param>
        private void LoadDataForSelectedTab(bool isSelectedTab)
        {
            switch (tabControlChiTiet.SelectedTabPageIndex)
            {
                case 1:
                    if (isSelectedTab && gridControlDuAn.DataSource == null){
                        LoadGridViewCongViec();
                        LoadCardViewDuAn();
                    }
                    else if (!isSelectedTab) {
                        LoadGridViewCongViec();
                        LoadCardViewDuAn();
                    } 
                    break;
                case 2:
                    if (isSelectedTab && gridControlNhatKy.DataSource == null){
                        LoadNhatKy();
                        LoadCardViewTapTin();
                    }
                    else if (!isSelectedTab) {
                        LoadCardViewTapTin();
                        LoadNhatKy();
                    } 
                    break;
            }
        }
        #endregion
    }
}

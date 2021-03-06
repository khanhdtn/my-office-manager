using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors.DXErrorProvider;
using System.Data.Common;
using DAO;
using ProtocolVN.Framework.Core;
using ProtocolVN.Framework.Win;
using ProtocolVN.DanhMuc;
using DTO;
using DevExpress.XtraGrid.Views.Layout.ViewInfo;
using System.IO;
using ProtocolVN.Plugin.TimeSheet;
using ProtocolVN.App.Office;


namespace office
{
    public partial class Congviec : XtraFormPL
    {
        #region Vùng đặt Static
        public static FormStatus Status = FormStatus.NO;
        public static string MenuItem(string ParentID, bool IsSep)
        {
            return MenuBuilder.CreateItem(typeof(Congviec).FullName,
                PMSupport.UpdateTitle("Quản trị công việc", Status),
                ParentID, true,
                typeof(Congviec).FullName,
                false, IsSep, "mnbToChuc.png", true, "", "");
        }
        #endregion

        #region biến toàn cục
        private DXErrorProvider err;
        private DataTable dtVSNguoiTGThuc;
        private DataTable dtThongTinCapNhat;
        private bool? IsAdd;
        private long ID;
        private long[] idNguoiThucHien;
        ToolTip toolTip1 = new ToolTip();
        DOPhanCongCongViec phanCongCongViec = new DOPhanCongCongViec();
        DXErrorProvider dxErrorProvider1 = new DXErrorProvider();
        List<DOChiTietPhanCong> cacChiTietPhanCong;
        /// <summary>
        /// Delegate để cập thông tin công việc-khách hàng, công việc-dự án vào bảng KH_DA_CV.
        /// </summary>
        /// <param name="congviecID"></param>
        public delegate void UpdateKH_DA_CV(long congviecID);
        public event UpdateKH_DA_CV UpdateCongViec_DuAn;
        public event UpdateKH_DA_CV UpdateCongViec_KhachHang;
        /// <summary>
        /// Delegate để refresh dữ liệu sau khi thêm mới.
        /// </summary>
        public delegate void RefreshData(DOPhanCongCongViec doPhanCongCV, string nguoiThucHien, string tienDo);
        public event RefreshData RefreshAfterInsert;

        int maxValue = 0;
        #endregion

        #region Hàm dựng
        public Congviec(long ID, bool? IsAdd, params long[] idNguoiThucHien)
        {
            InitializeComponent();
            this.IsAdd = IsAdd;
            if (IsAdd == true)
            {
                this.ID = -2;
                buttonCapNhatTienDo_NhatKy.Visible = false;
            }
            else this.ID = ID;
            this.idNguoiThucHien = idNguoiThucHien;
            err = new DXErrorProvider();
            InitGrid();
            taoBangAoNguoiTGThuc();
            InitControl();
        }

        public Congviec() : this(-2, true) { }
        public Congviec(long ID) : this(ID, false) { }


        #endregion

        #region Init Form
        private void InitGrid()
        {
            #region "grid Người tham gia"
            XtraGridSupportExt.TextLeftColumn(Cotnhanvien, "NAME");
            XtraGridSupportExt.TextLeftColumn(Cotphongban, "TENBP");
            grvwNguoiTGDuBi.OptionsView.ShowGroupPanel = false;
            Cotnhanvien.OptionsColumn.AllowEdit = false;
            grctrlNguoiTGDuBi.DataSource = DACongViec.NhanVienThamGia(idNguoiThucHien);
            #endregion

            #region "grid Thông tin cập nhật"
            HelpGridColumn.CotReadOnlyDate(colThoiGianCapNhat, "THOI_GIAN_CAP_NHAT", PLConst.FORMAT_DATETIME_STRING);
            HelpGridColumn.CotTextLeft(colNguoiThucHien, "NGUOI_THUC_HIEN");
            HelpGridColumn.CotTextRight(colTienDoThucHien, "TIEN_DO");
            HelpGridColumn.CotMemoExEdit(colGhiChu, "GHI_CHU");
            HelpGrid.SetReadOnlyHaveMemoCtrl(gridViewThongTinCapNhat);
            dtThongTinCapNhat = HelpDB.getDatabase().LoadDataSet(@"SELECT CT.* ,NV.NAME AS NGUOI_THUC_HIEN
                                                FROM CHI_TIET_PHAN_CONG CT LEFT JOIN DM_NHAN_VIEN NV ON CT.MA_NV = NV.ID WHERE CT.TIEN_DO>=0 " + " AND CT.PCCV_ID = " + this.ID + " AND 1=1").Tables[0];
            #endregion

            #region Layout tập tin
            XtraGridSupportExt.TextLeftColumn(lvTieuDe, "TIEU_DE");
            XtraGridSupportExt.TextLeftColumn(lvFile_dinh_kem, "TEN_FILE");
            XtraGridSupportExt.TextLeftColumn(lvNguoiCapNhat, "TEN_NGUOI_CN");
            XtraGridSupportExt.TextLeftColumn(lvNgayCapNhat, "NGAY_CAP_NHAT");
            XtraGridSupportExt.TextLeftColumn(lvSize, "SIZE");
            HelpGridColumn.CotMemoExEdit(lvGhi_chu, "GHI_CHU");
            XtraGridSupportExt.TextLeftColumn(cotID, "ID");
            XtraGridSupportExt.TextLeftColumn(cot_xoa, "XOA_FILE");
            XtraGridSupportExt.TextLeftColumn(cot_luufile, "LUU_FILE");
            XtraGridSupportExt.TextLeftColumn(cot_mofile, "MO_FILE");
            XtraGridSupportExt.TextLeftColumn(cot_suafile, "SUA_FILE");
            layoutView1.Appearance.CardCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            lvSize.OptionsColumn.AllowEdit = false;
            lvSize.OptionsColumn.AllowFocus = false;
            lvGhi_chu.OptionsColumn.ReadOnly = true;
            layoutView1.OptionsCustomization.AllowSort = false;
            layoutView1.OptionsCustomization.AllowFilter = false;
            layoutView1.OptionsBehavior.AllowSwitchViewModes = true;
            layoutView1.OptionsBehavior.AllowExpandCollapse = true;
            layoutView1.OptionsView.ShowCardCaption = true;
            gridViewTaiLieu.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
            layoutView1.OptionsHeaderPanel.EnableCustomizeButton = false;
            if (IsAdd == null)
            {
                cot_xoa.LayoutViewField.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                cot_suafile.LayoutViewField.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }
            #endregion

            #region grid chi tiết tiến độ thực hiện
            gridViewCTTD_ThucHien.OptionsSelection.EnableAppearanceFocusedCell = false;
            gridViewCTTD_ThucHien.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
            gridViewCTTD_ThucHien.OptionsBehavior.Editable = false;
            HelpGridColumn.CotTextLeft(colDetailNguoiThucHien, "NGUOI_THUC_HIEN");
            HelpGridColumn.CotTextRight(colDetailMDThamGia, "PHAN_TRAM_THAM_GIA");
            HelpGridColumn.CotTextRight(colDetailTienDo, "TIEN_DO");
            HelpGridColumn.CotPLTimeEdit(colDetailTGCapNhat, "THOI_GIAN_CAP_NHAT");
            #endregion

            #region grid danh sách nhật ký
            HelpGridColumn.CotReadOnlyDate(colTGCapNhat, "THOI_GIAN_CAP_NHAT", PLConst.FORMAT_DATETIME_STRING);
            HelpGridColumn.CotTextLeft(colNguoiCapNhat, "NGUOI_THUC_HIEN");
            HelpGridColumn.CotMemoExEdit(colNoiDung, "GHI_CHU");
            colNoiDung.OptionsColumn.AllowEdit = true;
            colNoiDung.OptionsColumn.ReadOnly = true;

            #endregion
        }

        private void InitControl()
        {
            #region khởi tạo ban đầu của form
            plcboaLoaiCongViec._init(DACongViec.chonLoaiCongViec(true), "NAME", "ID");

            //Khởi tạo danh mục nhân viên
            DataTable dtNV = DACongViec.ChonNhanVien(true);
            AppCtrl.InitTreeChonNhanVien_Choice1(cmbNguoiGiao, IsAdd);
            if (dtNV.Rows.Count > 0)
                cmbNguoiGiao._setSelectedID(FrameworkParams.currentUser.employee_id);
            DMCMucDoUuTien.I.InitCtrl(plcboaMucUuTien, IsAdd, true);

            InitTT(plcboaTinhTrang, IsAdd);
            //khởi tạo đầu tiên là giờ
            cmbNgayGio.SelectedIndex = 1;

            //khởi tạo ngày bắt đầu
            if (deNgayBatDau.Text == "")
                deNgayBatDau.DateTime = HelpDB.getDatabase().GetSystemCurrentDateTime();
            maxValue = HelpNumber.ParseInt32(sePhanTramThamGia.Properties.MaxValue);
            #endregion
            #region khởi tạo giá trị ban đầu nếu là xem hoặc update
            if (IsAdd == false || IsAdd == null)
            {
                decimal tiendo = Capnhattiendo();
                zoombarTienDo.Value = (int)tiendo;
                if (tiendo == 0)
                    sbtnBotNguoiThamGia.Enabled = true;
                labtiendo.Text = "" + tiendo.ToString();
                try
                {
                    phanCongCongViec = DACongViec.LoadPCCV(ID);
                    plcboaLoaiCongViec._setSelectedID(phanCongCongViec.LCV_ID);
                    txtCongViec.Text = phanCongCongViec.CONG_VIEC;
                    plcboaMucUuTien._setSelectedID(phanCongCongViec.MUC_UU_TIEN);
                    plcboaTinhTrang._setSelectedID(phanCongCongViec.TINH_TRANG);
                    cmbNguoiGiao._setSelectedID(phanCongCongViec.NGUOI_GIAO);
                    if (phanCongCongViec.NGAY_BAT_DAU.ToString() != "")
                        deNgayBatDau.DateTime = phanCongCongViec.NGAY_BAT_DAU;
                    string isDay = phanCongCongViec.IS_NGAY;
                    if (isDay == "Y")
                        cmbNgayGio.SelectedIndex = 0;
                    else
                        cmbNgayGio.SelectedIndex = 1;
                    if (phanCongCongViec.NGAY_KET_THUC_DU_KIEN != null)
                        deNgayKetThucDuKien.DateTime = phanCongCongViec.NGAY_KET_THUC_DU_KIEN.Value;
                    else
                    {
                        deNgayKetThucDuKien.EditValue = null;
                    }
                    if (phanCongCongViec.NGAY_KET_THUC != null)
                        deNgayKetThuc.DateTime = phanCongCongViec.NGAY_KET_THUC.Value;
                    else
                    { deNgayKetThuc.EditValue = null; }
                    if (phanCongCongViec.THOI_GIAN_DU_KIEN != null)
                        seTGDuKien.Value = phanCongCongViec.THOI_GIAN_DU_KIEN.Value;

                    if (phanCongCongViec.CHI_TIET_CONG_VIEC.Length > 0)
                        MoTaCongViec._setValue(phanCongCongViec.CHI_TIET_CONG_VIEC);

                    DataTable dtCT_PCCV = HelpDB.getDatabase().LoadDataSet(string.Format(@"
                        SELECT CT.MA_NV ,NV.NAME ,CT.PHAN_TRAM_THAM_GIA, BP.ID AS BP_ID, BP.NAME TENBP
                        FROM CHI_TIET_PHAN_CONG CT ,DM_NHAN_VIEN NV , DEPARTMENT BP
                        WHERE NV.DEPARTMENT_ID = BP.ID AND NV.ID = CT.MA_NV AND PCCV_ID= {0}
                        GROUP BY MA_NV ,NAME ,PHAN_TRAM_THAM_GIA, BP_ID, TENBP", this.ID)).Tables[0];
                    int PhanTramTG = 0;
                    foreach (DataRow rowCT in dtCT_PCCV.Rows)
                    {
                        dtVSNguoiTGThuc.Rows.Add(new string[] { rowCT["MA_NV"].ToString(), rowCT["NAME"].ToString(), rowCT["PHAN_TRAM_THAM_GIA"].ToString(), rowCT["PHAN_TRAM_THAM_GIA"].ToString() + " %", rowCT["bp_ID"].ToString(), rowCT["TENBP"].ToString() });
                        PhanTramTG += HelpNumber.ParseInt32(rowCT["PHAN_TRAM_THAM_GIA"]);
                    }
                    sbtnThemNguoiThamGia.Enabled = !(PhanTramTG == 100);
                    maxValue = HelpNumber.ParseInt32(sePhanTramThamGia.Properties.MaxValue) - PhanTramTG;
                    DACongViec.loadThongTinCapNhat(ref dtThongTinCapNhat, this.ID);
                    DACongViec.loaiNhanVienTrung((grctrlNguoiTGDuBi.DataSource as DataTable), dtVSNguoiTGThuc);
                }
                catch
                {
                    HelpMsgBox.ShowNotificationMessage("Công việc chưa được lưu.");
                }
                LoadDataForSelectedTab(false);
            }
            else
            {
                plcboaTinhTrang._setSelectedID(HelpNumber.ParseInt64(1));
                deNgayKetThucDuKien.EditValue = null;
            }
            #endregion
            if (plcboaTinhTrang._getSelectedID() == 4)
                buttonCapNhatTienDo_NhatKy.Visible = false;
            this.sbtnLuu.Visible = IsAdd != null;
        }

        private void Congviec_Load(object sender, EventArgs e)
        {
            PLTimeSheetUtil.PermissionForControl(cmbNguoiGiao, cmbNguoiGiao.Visible == true, cmbNguoiGiao.Visible == true);
            if (IsAdd == true)
            {
                plcboaTinhTrang._setSelectedID(-1);
                this.labtiendo.Text = "0";
            }
            HelpInputData.SetMaxLength(new object[] { 
                txtCongViec, 150
            });
            this.seTGDuKien.ValueChanged += new EventHandler(seTGDuKien_ValueChanged);
            HelpXtraForm.SetFix(this);
            tabbarCongViec.SelectedTabPageIndex = 0;
            gridViewCTTD_ThucHien.BestFitColumns();
            PLGUIUtil.Customizebar_PLRichTextBox(MoTaCongViec);
            MoTaCongViec.stylesBar1.Visible = MoTaCongViec.headerFooterBar1.Visible =
            MoTaCongViec.headerFooterBar1.Visible = MoTaCongViec.headerFooterToolsDesignCloseBar1.Visible =
            MoTaCongViec.headerFooterToolsDesignCloseBar1.Visible = MoTaCongViec.headerFooterToolsDesignNavigationBar1.Visible =
            MoTaCongViec.headerFooterToolsDesignNavigationBar1.Visible = MoTaCongViec.headerFooterToolsDesignOptionsBar1.Visible =
            MoTaCongViec.headerFooterToolsDesignOptionsBar1.Visible = MoTaCongViec.pageSetupBar1.Visible =
            MoTaCongViec.pageSetupBar1.Visible = false;
        }

        #endregion

        #region Invalidate

        void seTGDuKien_ValueChanged(object sender, EventArgs e)
        {
            if (deNgayBatDau.IsModified || deNgayKetThucDuKien.IsModified) return;
            switch (cmbNgayGio.SelectedIndex)
            {
                case 0://ngày
                    double ngay = HelpNumber.ParseTo<Double>((HelpNumber.RoundUp(seTGDuKien.Value, 0)) - 1);
                    if (ngay >= 0) deNgayKetThucDuKien.EditValue = deNgayBatDau.DateTime.AddDays(ngay);
                    break;
                case 1://giờ 
                    double gio = HelpNumber.ParseTo<Double>((HelpNumber.RoundUp(seTGDuKien.Value / 8, 0)) - 1);
                    if (gio >= 0) deNgayKetThucDuKien.EditValue = deNgayBatDau.DateTime.AddDays(gio);
                    break;
            }
        }

        private void cmbNgayGio_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (deNgayBatDau.IsModified || deNgayKetThucDuKien.IsModified) return;
            switch (cmbNgayGio.SelectedIndex)
            {
                case 0://ngày
                    double ngay = HelpNumber.ParseTo<Double>((HelpNumber.RoundUp(seTGDuKien.Value, 0)) - 1);
                    if (ngay >= 0) deNgayKetThucDuKien.EditValue = deNgayBatDau.DateTime.AddDays(ngay);
                    break;
                case 1://giờ 
                    double gio = HelpNumber.ParseTo<Double>((HelpNumber.RoundUp(seTGDuKien.Value / 8, 0)) - 1);
                    if (gio >= 0) deNgayKetThucDuKien.EditValue = deNgayBatDau.DateTime.AddDays(gio);
                    break;
            }
        }
        private void deNgayBatDau_EditValueChanged(object sender, EventArgs e)
        {
            xemTGDuKien();
        }

        private void deNgayKetThuc_EditValueChanged(object sender, EventArgs e)
        {
            xemTGDuKien();
        }
        private void grvwNguoiTGThuc_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            DataRow row = grvwNguoiTGThuc.GetDataRow(grvwNguoiTGThuc.FocusedRowHandle);
            if (gridCtrlThongTinCapNhat.DataSource == null)
                GetLichSu();
            DataTable dt = (DataTable)gridCtrlThongTinCapNhat.DataSource;
            if (row != null && dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    sbtnBotNguoiThamGia.Enabled = !(HelpNumber.ParseInt64(row["ID_NV"].ToString()) == HelpNumber.ParseInt64(dr["MA_NV"].ToString()));
                }
                if (grvwNguoiTGThuc.DataRowCount > 0)
                {
                    sePhanTramThamGia.Text = grvwNguoiTGThuc.GetDataRow(
                        grvwNguoiTGThuc.FocusedRowHandle)["PHAN_TRAM_THAM_GIA"].ToString();
                }
            }
        }
        #endregion

        #region Validate (Kiểm tra lỗi)
        public bool IsValidate()
        {
            bool flag;
            dxErrorProvider1.ClearErrors();
            err.ClearErrors();
            flag = HelpInputData.ShowRequiredError(dxErrorProvider1,
                   new object[]{
                        plcboaLoaiCongViec, "Loại công việc",                        
                        cmbNguoiGiao,"Người giao",
                        txtCongViec,"Tên công việc",                        
                        deNgayBatDau,"Ngày bắt đầu"
                    }
               );
            GUIValidation.SetMaxLength(new object[] { txtCongViec, 150 });
            if (plcboaTinhTrang._getSelectedID() == -1)
            {
                plcboaTinhTrang.SetError(dxErrorProvider1, "Vui lòng vào thông tin \"Tình trạng công việc\"!");
                flag = false;
            }
            if (plcboaMucUuTien._getSelectedID() == -1)
            {
                plcboaMucUuTien.SetError(dxErrorProvider1, "Vui lòng vào thông tin \"Độ ưu tiên\"!");
                flag = false;
            }
            if (this.grvwNguoiTGThuc.RowCount <= 0)
            {
                HelpMsgBox.ShowNotificationMessage("Vui lòng vào thông tin \"Người thực hiện\"!");
                flag = false;
            }

            if (deNgayKetThucDuKien.DateTime.Year != 1)//Ngay ket thuc khac rong
            {
                TimeSpan t = DateTime.Parse(deNgayKetThucDuKien.DateTime.ToShortDateString()) - DateTime.Parse(deNgayBatDau.DateTime.ToShortDateString());
                double tg = Math.Round((t.TotalDays), 0);
                if (tg < 0)
                {
                    err.SetError(deNgayKetThucDuKien, "Ngày kết thúc dự kiến phải lớn hơn ngày bắt đầu!");
                    flag = false;
                }
                if (getNgayKetThucDK() == DateTime.MaxValue || seTGDuKien.Value < 0)
                {
                    err.SetError(seTGDuKien, "Giá trị thời gian không đúng!");
                    flag = false;
                }
            }
            if (deNgayKetThuc.DateTime.Year != 1)//Ngay ket thuc khac rong
            {
                TimeSpan t = DateTime.Parse(deNgayKetThuc.DateTime.ToShortDateString()) - DateTime.Parse(deNgayBatDau.DateTime.ToShortDateString());
                double tg = Math.Round((t.TotalDays), 0);
                if (tg < 0)
                {
                    err.SetError(deNgayKetThuc, "Ngày kết thúc phải lớn hơn ngày bắt đầu!");
                    flag = false;
                }
                if (getNgayKetThucDK() == DateTime.MaxValue || seTGDuKien.Value < 0)
                {
                    err.SetError(seTGDuKien, "Giá trị thời gian không đúng!");
                    flag = false;
                }
            }
            else if (plcboaTinhTrang._getSelectedID() == 4)
            {
                err.SetError(deNgayKetThuc, "Ngày kết thúc phải khác rỗng!");
                flag = false;
            }
            return flag;
        }
        #endregion

        #region Xử lý nút

        #region Button đóng
        private void sbtnDong_Click(object sender, EventArgs e)
        {
            if (IsAdd == null)
                this.Close();
            else
            {
                PLGUIUtil.DongForm(this);
            }
        }
        #endregion

        #region Button thêm người tham gia
        private void sbtnThemNguoiThamGia_Click(object sender, EventArgs e)
        {
            DataRow addRow = null;
            if (grvwNguoiTGDuBi.RowCount > 0)
            {
                int them = int.Parse(sePhanTramThamGia.Text);
                if (maxValue - them >= 0)
                {
                    if (them > 0)
                    {
                        DataRow row = grvwNguoiTGDuBi.GetDataRow(grvwNguoiTGDuBi.FocusedRowHandle);

                        addRow = dtVSNguoiTGThuc.Rows.Add(new string[] {
                                                    row["ID"].ToString(),
                                                    row["NAME"].ToString(),
                                                    sePhanTramThamGia.Text,sePhanTramThamGia.Text + " %",row["DEPARTMENT_ID"].ToString(),row["TENBP"].ToString()
                                                                });
                        DACongViec.addRowThongTinCapNhat(ref dtThongTinCapNhat, addRow);
                        (grctrlNguoiTGDuBi.DataSource as DataTable).Rows.Remove(row);
                        int PhanTramTG = 0;
                        foreach (DataRow item in dtVSNguoiTGThuc.Rows)
                            PhanTramTG += HelpNumber.ParseInt32(item["PHAN_TRAM_THAM_GIA"]);
                        sbtnBotNguoiThamGia.Enabled = true;
                    }
                    else
                        return;
                    maxValue = maxValue - them;
                    sePhanTramThamGia.Properties.MaxValue = maxValue;
                    sePhanTramThamGia.Text = "0";
                    if (maxValue <= 0)
                    {
                        sePhanTramThamGia.Properties.ReadOnly = true;
                        sbtnThemNguoiThamGia.Enabled = false;
                    }
                }
                else
                {
                    HelpMsgBox.ShowNotificationMessage("Tổng % phân công không được lớn hơn 100%."); return;
                }
            }
        }
        #endregion

        #region Button bớt người tham gia
        private void sbtnBotNguoiThamGia_Click(object sender, EventArgs e)
        {
            if (dtVSNguoiTGThuc.Rows.Count > 0)
            {
                int[] delList = grvwNguoiTGThuc.GetSelectedRows();
                string[] listDelID = new string[delList.Length];
                for (int i = 0; i < delList.Length; i++)
                {
                    listDelID[i] = dtVSNguoiTGThuc.Rows[delList[i]]["ID_NV"].ToString();
                }
                foreach (string ID in listDelID)
                {
                    int rowIndex = DACongViec.kiemTraTonTaiDulieu(dtVSNguoiTGThuc, "ID_NV", ID);
                    if (rowIndex >= 0)
                    {
                        DataRow dr = dtVSNguoiTGThuc.Rows[rowIndex];
                        (grctrlNguoiTGDuBi.DataSource as DataTable).Rows.Add(new String[] { dr["ID_NV"].ToString(), dr["NAME"].ToString(), dr["BP_ID"].ToString(), dr["TEN_BP"].ToString() });
                        DACongViec.xoaNhanVien(ref dtThongTinCapNhat, "MA_NV", long.Parse(dr["ID_NV"].ToString()));
                        sePhanTramThamGia.Properties.ReadOnly = false;
                        maxValue = maxValue + HelpNumber.ParseInt32(dr["PHAN_TRAM_THAM_GIA"].ToString());
                        sePhanTramThamGia.Properties.MaxValue = maxValue;
                        sePhanTramThamGia.Text = "0";
                        dtVSNguoiTGThuc.Rows.RemoveAt(rowIndex);
                        dtVSNguoiTGThuc.AcceptChanges();
                        grvwNguoiTGThuc.SelectRow(rowIndex - 1);
                        sbtnBotNguoiThamGia.Enabled = (dtVSNguoiTGThuc.Rows.Count > 0);
                        sbtnThemNguoiThamGia.Enabled = true;
                    }
                }
            }
        }
        #endregion

        #region Button xóa
        private void sbtnXoa_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region Button cập nhật tiến độ
        private void buttonCapNhatTienDo_NhatKy_Click(object sender, EventArgs e)
        {
            if (buttonCapNhatTienDo_NhatKy.Text.Equals("Cập nhật tiến độ"))
            {
                frmCapNhatTienDo frm = new frmCapNhatTienDo(ID);
                HelpProtocolForm.ShowModalDialog(this, frm);
                labtiendo.Text = Capnhattiendo().ToString();
                string[] temp = labtiendo.Text.Split(',');
                zoombarTienDo.Value = HelpNumber.ParseInt32(temp[0]);
                DACongViec.loadThongTinCapNhat(ref dtThongTinCapNhat, ID);
                this.GetLichSu();
            }
            else if (buttonCapNhatTienDo_NhatKy.Text.Equals("Thêm tập tin"))
            {
                frmThemTaiLieu frm = new frmThemTaiLieu(-2, true, phanCongCongViec.PCCV_ID, (long)LoaiTapTin.TapTinCongViec);
                HelpProtocolForm.ShowModalDialog(this, frm);
                load_TapTin(ID);
            }
            else if (buttonCapNhatTienDo_NhatKy.Text.Equals("Ghi nhật ký"))
            {
                frmNhatKyCongViec frm = new frmNhatKyCongViec(ID);
                HelpProtocolForm.ShowModalDialog(this, frm);
                this.GetNhatKy();
            }
        }
        #endregion

        #region Button lưu
        private void sbtnLuu_Click(object sender, EventArgs e)
        {
            if (IsValidate())
            {
                GetDataPCCV();
                if (DACongViec.LuuCongViec(IsAdd, phanCongCongViec, cacChiTietPhanCong))
                {
                    if (IsAdd == true)
                    {
                        if (UpdateCongViec_DuAn != null) UpdateCongViec_DuAn(phanCongCongViec.PCCV_ID);
                        if (UpdateCongViec_KhachHang != null) UpdateCongViec_KhachHang(phanCongCongViec.PCCV_ID);
                        {
                            HelpMsgBox.ShowNotificationMessage("Lưu thông tin thành công.");
                            IsAdd = false;

                            LoadDataForSelectedTab(false);
                        }
                    }
                    else
                    {
                        if (RefreshAfterInsert != null)
                        {
                            string nguoiTH = "";
                            DataView dt = grvwNguoiTGThuc.DataSource as DataView;
                            foreach (DataRowView row in dt)
                            {
                                int i = dt.Count;
                                nguoiTH += row["NAME"] + "(" + row["PHAN_TRAM_THAM_GIA"] + "%)";
                                if (i > 1)
                                {
                                    nguoiTH += "\n";
                                    i--;
                                }
                            }
                            RefreshAfterInsert(phanCongCongViec, nguoiTH, labtiendo.Text + "%");
                        }
                        HelpXtraForm.CloseFormNoConfirm(this);
                    }
                }
                else
                {
                    HelpMsgBox.ShowErrorMessage("Lưu thông tin không thành công.");
                }
            }
        }
        #endregion

        #endregion

        #region Chuyển mấy hàm này sang DACongViec
        //Hàm này set các giá trị của control, chuyển qua DA thì phải truyền tham số nhiều
        #region hàm chuyển đổi ngày giờ
        // Chuyển đổi thời gian dự kiến từ ngày qua giờ hoặc ngược lại
        private void xemTGDuKien()
        {
            if (seTGDuKien.IsModified || cmbNgayGio.IsModified) return;
            TimeSpan t = (TimeSpan)(DateTime.Parse(deNgayKetThucDuKien.DateTime.ToShortDateString()) - DateTime.Parse(deNgayBatDau.DateTime.ToShortDateString()));
            double tgDK = Math.Round((t.TotalDays), 0);
            switch (cmbNgayGio.SelectedIndex)
            {
                case 0://ngày
                    if (tgDK < 0)
                    {
                        seTGDuKien.Value = 0;
                    }
                    else
                    {
                        seTGDuKien.Value = HelpNumber.ParseDecimal(tgDK + 1);
                    }
                    break;
                case 1://giờ
                    if (tgDK < 0)
                    {
                        seTGDuKien.Value = 0;
                    }
                    else
                    {
                        seTGDuKien.Value = HelpNumber.ParseDecimal(((tgDK + 1) * 8));
                    }
                    break;
            }
        }
        #endregion
        #region tính ngày kết thúc
        private DateTime getNgayKetThucDK()
        {
            DateTime t = new DateTime();
            try
            {
                double tgDK = Math.Round((double)(seTGDuKien.Value), 0);

                switch (cmbNgayGio.SelectedIndex)
                {
                    case 0://ngày
                        t = deNgayBatDau.DateTime.AddDays(tgDK - 1);
                        break;
                    case 1:
                        t = deNgayBatDau.DateTime.AddDays((tgDK - 8) / 8);//duynpn sua ngay luon >1 ngay so voi ngay nhap
                        break;
                }
                if (t < deNgayKetThucDuKien.DateTime) t = deNgayKetThucDuKien.DateTime;
            }
            catch (ArgumentOutOfRangeException)
            {
                t = DateTime.MaxValue;
            }
            return t;
        }
        #endregion

        #endregion

        #region Hàm khởi tạo phục vụ lưu công việc
        public void GetDataPCCV()
        {
            // bool flag = true;
            cacChiTietPhanCong = new List<DOChiTietPhanCong>();
            phanCongCongViec.PCCV_ID = this.ID;
            if (this.IsAdd == true)
                phanCongCongViec.PCCV_ID = this.ID = HelpDB.getDatabase().GetID("G_NGHIEP_VU");
            phanCongCongViec.LCV_ID = plcboaLoaiCongViec._getSelectedID();
            phanCongCongViec.CONG_VIEC = txtCongViec.Text;
            phanCongCongViec.MUC_UU_TIEN = (Int32)plcboaMucUuTien._getSelectedID();
            phanCongCongViec.TINH_TRANG = plcboaTinhTrang._getSelectedID();
            phanCongCongViec.NGAY_BAT_DAU = deNgayBatDau.DateTime;
            if (deNgayKetThucDuKien.EditValue == null) phanCongCongViec.NGAY_KET_THUC_DU_KIEN = null;
            else phanCongCongViec.NGAY_KET_THUC_DU_KIEN = deNgayKetThucDuKien.DateTime;
            phanCongCongViec.THOI_GIAN_DU_KIEN = null;
            if (seTGDuKien.Value > 0)
                phanCongCongViec.THOI_GIAN_DU_KIEN = HelpNumber.ParseDecimal(seTGDuKien.Value);
            phanCongCongViec.IS_CONG_VIEC_KH = "N";
            if (plcboaTinhTrang._getSelectedID() == 4)
            {
                phanCongCongViec.NGAY_KET_THUC = deNgayKetThuc.DateTime;
            }
            else
            {
                phanCongCongViec.NGAY_KET_THUC = null;
            }
            phanCongCongViec.IS_NGAY = DACongViec.getIsDay(seTGDuKien.Text, cmbNgayGio.SelectedIndex);
            phanCongCongViec.NGUOI_GIAO = cmbNguoiGiao._getSelectedID();

            //CHAUTV
            phanCongCongViec.CHI_TIET_CONG_VIEC = MoTaCongViec._getValue();

            foreach (DataRow row in dtThongTinCapNhat.Rows)
            {
                DOChiTietPhanCong chiTietphancong = new DOChiTietPhanCong();
                chiTietphancong.PCCV_ID = phanCongCongViec.PCCV_ID;
                chiTietphancong.MA_NV = HelpNumber.ParseInt64(row["MA_NV"].ToString());
                chiTietphancong.PHAN_TRAM_THAM_GIA = HelpNumber.ParseInt32(row["PHAN_TRAM_THAM_GIA"].ToString());
                chiTietphancong.TIEN_DO = HelpNumber.ParseInt32(row["TIEN_DO"].ToString());
                chiTietphancong.THOI_GIAN_CAP_NHAT = Convert.ToDateTime(row["THOI_GIAN_CAP_NHAT"]);
                chiTietphancong.GHI_CHU = HelpNumber.ParseInt32(row["TIEN_DO"]) == 0 ? PLConst.GHI_CHU_PCCV : row["GHI_CHU"].ToString(); // row["GHI_CHU"].ToString();
                cacChiTietPhanCong.Add(chiTietphancong);
            }
        }
        #endregion

        #region 1 phần của InitGrid (đem vào InitGrid)
        // tạo bảng ảo để lưu danh sách người tham gia thực tế
        private void taoBangAoNguoiTGThuc()
        {
            dtVSNguoiTGThuc = new DataTable();
            dtVSNguoiTGThuc.Columns.Add("ID_NV", Type.GetType("System.Int64"));
            dtVSNguoiTGThuc.Columns.Add("NAME");
            dtVSNguoiTGThuc.Columns.Add("PHAN_TRAM_THAM_GIA", Type.GetType("System.Int32"));
            dtVSNguoiTGThuc.Columns.Add("PHAN_TRAM_THAM_GIA_DISPLAY");
            dtVSNguoiTGThuc.Columns.Add("BP_ID", Type.GetType("System.Int64"));
            dtVSNguoiTGThuc.Columns.Add("TEN_BP");
            HelpGridColumn.CotTextLeft(grcolTenNgTGThuc, "NAME");
            HelpGridColumn.CotTextRight(grcolPhanTramThamGia, "PHAN_TRAM_THAM_GIA_DISPLAY");
            grctrlNguoiTGThuc.DataSource = dtVSNguoiTGThuc;
            grvwNguoiTGThuc.OptionsSelection.MultiSelect = true;
            grvwNguoiTGThuc.OptionsView.ShowGroupPanel = false;
        }

        #endregion

        #region sự kiện
        private void repXoa_Click(object sender, EventArgs e)
        {
            if (IsAdd != null)
            {
                DataRow r = gridViewNhatKyCV.GetDataRow(gridViewNhatKyCV.FocusedRowHandle);
                if (r != null)
                {
                    if (HelpMsgBox.ShowConfirmMessage("Bạn có chắc muốn xóa dữ liệu đang chọn không? ") == DialogResult.Yes)
                    {
                        DACongViec.DeleteNhatKy(HelpNumber.ParseInt64(r["ID"]));
                        gridViewNhatKyCV.DeleteSelectedRows();
                    }
                }
            }
        }

        private void GetLichSu()
        {
            DataTable kq = HelpDB.getDatabase().LoadDataSet(@"select PCCV_ID, ct.MA_NV, PHAN_TRAM_THAM_GIA, TIEN_DO || '%' TIEN_DO, GHI_CHU, THOI_GIAN_CAP_NHAT,NV.NAME AS NGUOI_THUC_HIEN
                                                                 from CHI_TIET_PHAN_CONG CT 
                                                LEFT JOIN DM_NHAN_VIEN NV ON CT.MA_NV = NV.ID WHERE CT.TIEN_DO > 0 AND CT.PCCV_ID = " + this.ID + " AND 1=1").Tables[0];

            gridCtrlThongTinCapNhat.DataSource = kq;
        }
        private void GetNhatKy()
        {
            DataTable KQ = HelpDB.getDatabase().LoadDataSet(@"SELECT CT.* ,NV.NAME AS NGUOI_THUC_HIEN
                                                FROM NHAT_KY_KH_DA_CV CT 
                                                LEFT JOIN DM_NHAN_VIEN NV ON CT.MA_NV = NV.ID WHERE CT.PCCV_ID = " + this.ID + " AND 1=1").Tables[0];

            gridControlNhatKyCV.DataSource = KQ;
        }
        private void LoadCTTD_THUCHIEN(long MasterID)
        {
            string squery = string.Format(@"SELECT NV.ID AS EMP_ID, NV.NAME  NGUOI_THUC_HIEN,CT.THOI_GIAN_CAP_NHAT ,CT.TIEN_DO || '%' TIEN_DO, CT.PHAN_TRAM_THAM_GIA || '%' PHAN_TRAM_THAM_GIA
                                                                                FROM CHI_TIET_PHAN_CONG CT LEFT JOIN DM_NHAN_VIEN NV ON  CT.MA_NV = NV.ID
                                                                                WHERE CT.PCCV_ID={0}
                                                                                AND CT.THOI_GIAN_CAP_NHAT IN
                                                                                (SELECT MAX(CTPC.THOI_GIAN_CAP_NHAT) FROM CHI_TIET_PHAN_CONG CTPC
                                                                                WHERE CTPC.PCCV_ID={1}
                                                                                 GROUP BY CTPC.MA_NV
                                                                                )", MasterID, MasterID);
            gridControlCTTD_ThucHien.DataSource = HelpDB.getDatabase().LoadDataSet(squery).Tables[0];
        }
        private void tabbarCongViec_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            LoadDataForSelectedTab(true);
        }


        private void grctrlNguoiTGDuBi_Click(object sender, EventArgs e)
        {
            DataRow r = grvwNguoiTGDuBi.GetDataRow(grvwNguoiTGDuBi.FocusedRowHandle);
            if (r != null)
            {
                if (grvwNguoiTGDuBi.IsGroupRow(grvwNguoiTGDuBi.FocusedRowHandle))
                    sbtnThemNguoiThamGia.Enabled = false;
                else
                    sbtnThemNguoiThamGia.Enabled = IsAdd == null ? false : true;
            }
        }
        #endregion

        #region initcontrol
        public void InitTT(PLImgCombobox Input, bool? IsAdd)
        {
            bool IsVisible = false;
            if (IsAdd != null && IsAdd == true) IsVisible = true;

            QueryBuilder query = null;
            if (IsVisible)
                query = new QueryBuilder("SELECT * FROM DM_TINH_TRANG where VISIBLE_BIT = 'Y' AND 1=1");
            else
                query = new QueryBuilder("SELECT * FROM DM_TINH_TRANG where 1=1");
            DataSet ds = HelpDB.getDatabase().LoadReadOnlyDataSet(query);
            Input._init(ds.Tables[0], "NAME", "ID");
        }
        private decimal Capnhattiendo()
        {
            string sql = string.Format(@"SELECT C.PCCV_ID,PHAN_TRAM_THAM_GIA,MAX(TIEN_DO) TIEN_DO,T.TONG_PHAN_TRAM
                            FROM CHI_TIET_PHAN_CONG C,
                            (SELECT PCCV_ID,SUM(PHAN_TRAM_THAM_GIA) TONG_PHAN_TRAM
                                FROM CHI_TIET_PHAN_CONG WHERE TIEN_DO = 0 GROUP BY PCCV_ID) T
                                    WHERE TIEN_DO > 0 AND T.PCCV_ID = C.PCCV_ID AND T.PCCV_ID = {0} AND
                                    C.THOI_GIAN_CAP_NHAT IN (SELECT MAX(CT.THOI_GIAN_CAP_NHAT) FROM CHI_TIET_PHAN_CONG CT WHERE CT.PCCV_ID=T.PCCV_ID GROUP BY CT.MA_NV)
                                          GROUP BY C.PCCV_ID,C.MA_NV,PHAN_TRAM_THAM_GIA,T.TONG_PHAN_TRAM", ID);
            DataSet ds = HelpDB.getDatabase().LoadDataSet(sql);
            DataRow[] arrRow = ds.Tables[0].Select("1=1");
            decimal tongTienDo = 0;
            foreach (DataRow row in arrRow)
                tongTienDo += (HelpNumber.ParseInt64(row["TIEN_DO"]) * HelpNumber.ParseInt64(row["PHAN_TRAM_THAM_GIA"]));
            if (arrRow.Length > 0) tongTienDo /= HelpNumber.ParseInt64(arrRow[0]["TONG_PHAN_TRAM"]);
            return HelpNumber.RoundDecimal(tongTienDo, 2);
        }

        private void plcboaTinhTrang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (plcboaTinhTrang._getSelectedID() == 4 && IsAdd == false)
            {
                DataRow row = HelpDB.getDatabase().LoadDataSet("Select pc.* from PHAN_CONG_CONG_VIEC pc where PCCV_ID= " + this.ID).Tables[0].Rows[0];
                if (row["NGUOI_GIAO"].ToString() != FrameworkParams.currentUser.employee_id.ToString() || zoombarTienDo.Value < 100)
                {
                    HelpMsgBox.ShowNotificationMessage("Bạn không có quyền hoàn tất công việc\n hoặc tiến độ chưa đạt 100%");
                    plcboaTinhTrang._setSelectedID(2);
                }
                else
                {
                    if (zoombarTienDo.Value == 100)
                    {
                        deNgayKetThuc.Enabled = true;
                        deNgayKetThuc.DateTime = DateTime.Now.Date;
                    }
                }
            }
            if (IsAdd == true)
            {
                plcboaTinhTrang._setSelectedID(1);
            }
            if (plcboaTinhTrang._getSelectedID() != 4)
            {
                deNgayKetThuc.Enabled = false;
                deNgayKetThuc.EditValue = null;
            }
        }
        #endregion

        #region Sự kiện trong cardView
        private void rep_mofile_Click(object sender, EventArgs e)
        {
            DataRow row = layoutView1.GetDataRow(layoutView1.FocusedRowHandle);
            DOLuuTruTapTin do_tt = DALuuTruTapTin.Instance.Load(HelpNumber.ParseInt64(row["ID"]));
            DADocument.Instance.Open_file_from_byte(do_tt.NOI_DUNG, do_tt.TEN_FILE);
        }

        private void rep_luufile_Click(object sender, EventArgs e)
        {
            DataRow row = layoutView1.GetDataRow(layoutView1.FocusedRowHandle);
            DOLuuTruTapTin do_tt = DALuuTruTapTin.Instance.Load(HelpNumber.ParseInt64(row["ID"]));
            DADocument.Instance.Save_file_from_byte(do_tt.NOI_DUNG, do_tt.TEN_FILE);
        }

        private void rep_xoa_Click(object sender, EventArgs e)
        {
            if (IsAdd != null)
            {
                DataRow r = layoutView1.GetDataRow(layoutView1.FocusedRowHandle);
                if (r != null)
                {
                    if (HelpMsgBox.ShowConfirmMessage("Bạn có chắc muốn xóa dữ liệu đang chọn không?") == DialogResult.Yes)
                    {
                        long id_taptin = HelpNumber.ParseInt64(r["ID"]);
                        DACongViec.DeleteCVTT(id_taptin);
                        DALuuTruTapTin.Instance.Delete(id_taptin);
                        layoutView1.DeleteSelectedRows();
                    }
                }
            }
        }

        private void rep_sua_Click(object sender, EventArgs e)
        {
            if (IsAdd != null)
            {
                DataRow r = layoutView1.GetDataRow(layoutView1.FocusedRowHandle);
                if (r != null)
                {
                    frmThemTaiLieu frm = new frmThemTaiLieu(HelpNumber.ParseInt64(r["ID"]), false, phanCongCongViec.PCCV_ID, (long)LoaiTapTin.TapTinCongViec);
                    HelpProtocolForm.ShowModalDialog(this, frm);
                    load_TapTin(ID);
                }
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
        private void load_TapTin(Int64 ID_CongViec)
        {
            DataSet ds = HelpDB.getDatabase().LoadDataSet(@"SELECT LUU_TRU_TAP_TIN.*,
            (SELECT NAME FROM DM_NHAN_VIEN WHERE ID =LUU_TRU_TAP_TIN.NGUOI_CAP_NHAT) TEN_NGUOI_CN
            FROM LUU_TRU_TAP_TIN 
            WHERE ID IN (SELECT TAP_TIN_ID FROM OBJECT_TAP_TIN WHERE TYPE_ID=5 AND OBJECT_ID='" + ID_CongViec + "')");

            ds.Tables[0].Columns.Add("MO_FILE", typeof(Image));
            ds.Tables[0].Columns.Add("LUU_FILE", typeof(Image));
            ds.Tables[0].Columns.Add("XOA_FILE", typeof(Image));
            ds.Tables[0].Columns.Add("SUA_FILE", typeof(Image));
            ds.Tables[0].Columns.Add("SIZE", typeof(String));

            foreach (DataRow r in ds.Tables[0].Rows)
            {
                r["MO_FILE"] = FWImageDic.VIEW_IMAGE20;
                r["LUU_FILE"] = FWImageDic.SAVE_IMAGE20;
                r["XOA_FILE"] = FWImageDic.DELETE_IMAGE20;
                r["SUA_FILE"] = FWImageDic.EDIT_IMAGE20;
                byte[] a = r["NOI_DUNG"] as byte[];
                r["SIZE"] = (HelpNumber.RoundDecimal((HelpNumber.ParseDecimal(a.Length) / 1024), 3)).ToString();
            }
            gridControlTaiLieu.DataSource = ds.Tables[0];
        }
        #endregion

        #region Extensions

        private void LoadDataForSelectedTab(bool isTabChanged)
        {
            switch (tabbarCongViec.SelectedTabPageIndex)
            {
                case 0:
                    if (isTabChanged && gridControlCTTD_ThucHien.DataSource == null) LoadCTTD_THUCHIEN(ID);
                    if (!isTabChanged) LoadCTTD_THUCHIEN(ID);
                    break;
                case 1:
                    if (isTabChanged && gridCtrlThongTinCapNhat.DataSource == null) GetLichSu();
                    if (!isTabChanged) GetLichSu();
                    buttonCapNhatTienDo_NhatKy.Text = "Cập nhật tiến độ";
                    break;
                case 2:
                    if (isTabChanged && gridControlTaiLieu.DataSource == null) load_TapTin(ID);
                    if (!isTabChanged) load_TapTin(ID);
                    buttonCapNhatTienDo_NhatKy.Text = "Thêm tập tin";
                    break;
                default:
                    if (isTabChanged && gridControlNhatKyCV.DataSource == null) GetNhatKy();
                    if (!isTabChanged) GetNhatKy();

                    buttonCapNhatTienDo_NhatKy.Text = "Ghi nhật ký";
                    break;
            }
            if (IsAdd == null || IsAdd == true)
                buttonCapNhatTienDo_NhatKy.Visible = false;
            else CheckUser();
        }

        private void CheckUser()
        {
            if (gridControlCTTD_ThucHien.DataSource == null)
                LoadCTTD_THUCHIEN(ID);
            DataTable view = (DataTable)gridControlCTTD_ThucHien.DataSource;
            if (tabbarCongViec.SelectedTabPageIndex == 0) goto Nhan;
            foreach (DataRow r in view.Rows)
            {
                if (FrameworkParams.currentUser.employee_id == HelpNumber.ParseInt64(r["EMP_ID"]))
                {
                    buttonCapNhatTienDo_NhatKy.Visible = true;
                    return;
                }
            }
        Nhan:
            buttonCapNhatTienDo_NhatKy.Visible = false;
        }

        private void sePhanTramThamGia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        #endregion
    }
}
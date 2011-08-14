using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraEditors.DXErrorProvider;
using ProtocolVN.Framework.Win;
using ProtocolVN.Framework.Core;
using DAO;
using ProtocolVN.DanhMuc;
using DTO;
using System.Drawing;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Layout.ViewInfo;
using ProtocolVN.App.Office;
using DevExpress.XtraGrid.Views.Grid;
using System.IO;
using System.Data.Common;
using ProtocolVN.Plugin.TimeSheet;

namespace office
{
    public partial class frmDuAn : XtraFormPL
    {
        #region Vùng đặt Static 
        public static FormStatus Status = FormStatus.NO_USE;
        public static string MenuItem(string ParentID, bool IsSep)
        {
            return MenuBuilder.CreateItem(typeof(frmDuAn).FullName,
                PMSupport.UpdateTitle("Tạo mới", Status),
                ParentID, true,
                typeof(frmDuAn).FullName,
                false, IsSep, "add.png", true, "", "");
        }
        #endregion

        #region Các khai báo biến         
        private bool? IsAdd; //true = New, null = View, false = Edit
        private long _ID;
        private DXErrorProvider err;
        Dictionary<DOPhanCongCongViec, List<DOChiTietPhanCong>> dic_Cong_viec = new Dictionary<DOPhanCongCongViec, List<DOChiTietPhanCong>>();
        List<long> mang_ID_PCCV_dang_xoa = new List<long>();
        DODuAn doDuAn = null;
        private DOLuuTruTapTin do_luu_tru_tt = null;
        /// <summary>
        /// Delegate để cập nhật thông tin dự án-khách hàng vào bảng KH_DA_CV.
        /// </summary>
        /// <param name="duanID"></param>
        public delegate void UpdateKH_DA_CV(long duanID);
        public event UpdateKH_DA_CV UpdateDuAn_KhachHang;
        /// <summary>
        /// Delegate để refresh dữ liệu sau khi thêm mới.
        /// </summary>
        public delegate void RefreshData();
        public event RefreshData RefreshAfterInsert;

        #endregion        
             
        #region Hàm dựng 
        public frmDuAn(long ID,bool? IsAdd)
        {
            InitializeComponent();
            err = new DXErrorProvider();
            do_luu_tru_tt = new DOLuuTruTapTin();
            this.IsAdd = IsAdd;
            this._ID = ID;           
            intfrm();
            //PLGUIUtil.setDefaultSize(this);
        }
        public frmDuAn() : this(-2, true) { }
        #endregion

        #region InitForm 
        public void intfrm()
        {
            _InitColumnGridCongViec();
            _InitColumnLayoutTaiLieu();
            _InitControl();
            _LoadDataForm(); 
        }

        private void _InitControl()
        {
            PMSupport.SetTitle(this, Status);
            //DMNhanVienX.I.InitCtrl(nguoiquanly, true, true);
            AppCtrl.InitTreeChonNhanVien_Choice1(NhanVien, true);
            DMLoaiDuAn.I.InitCtrl(LoaiDA, true, true);
            HelpDate.Today(ngaybatdau, ngayKTDK);
            DMCMucDoUuTien.I.InitCtrl(Muc_UT, false, true);
            DMCTinhTrangDuAn.Instance.InitCtrl(tinhtrang, IsAdd, true);
            //nguoiThucHien.CreateDataset(true);
            AppCtrl.InitTreeChonNhanVien(NguoiThucHien, IsAdd,false);
            xtraTabControl1.SelectedPageChanged += new DevExpress.XtraTab.TabPageChangedEventHandler(xtraTabControl1_SelectedPageChanged);
            toolTip1.BackColor = Color.LightYellow;
        }
        private void _LoadDataForm()
        {
            if (IsAdd == true)
            {
                doDuAn = DADuAn.Instance.LoadAll(-2);
                doDuAn.ID = HelpDB.getDatabase().GetID("G_NGHIEP_VU");
                _ID = doDuAn.ID;
                tinhtrang._setSelectedID(1);//Khi thêm tình trạng mặc định là "Mới đề xuất"
                btnThemCV.Visible = false;
                xtraTabControl1.Enabled = false;
            }
            else
            {
                LoadDataCongViec();
                btnThemCV.Visible = false;
                btnSave.Visible = false;
                doDuAn = DADuAn.Instance.Load(_ID);
                txtTen_DA.Text = doDuAn.GetNAME();
                LoaiDA._setSelectedID(doDuAn.LOAI_DU_AN);
                NhanVien._setSelectedID(doDuAn.NGUOI_QUAN_LY);
                Muc_UT._setSelectedID(doDuAn.MUC_UU_TIEN);
                ngaybatdau.DateTime = doDuAn.NGAY_BAT_DAU;
                ngayKTDK.DateTime = doDuAn.NGAY_KET_THUC;
                if (doDuAn.NGAY_KET_THUC_THUC_TE != null)
                    ngayKTTT.DateTime = doDuAn.NGAY_KET_THUC_THUC_TE.Value;
                tinhtrang._setSelectedID(doDuAn.TINH_TRANG);
                //if (doDuAn.NGUOI_THUC_HIEN != null)
                //{
                //    nguoiThucHien._SetDefault(nguoiThucHien.dsSource.Tables[0], 0, nguoiThucHien.GetLongNguoiThucHien(doDuAn.NGUOI_THUC_HIEN));
                //}
                NguoiThucHien._SelectedStrIDs = doDuAn.NGUOI_THUC_HIEN;
               
                zoombarTienDo.Value = (int)lay_tiendo();
                mmTT_Them.Text = doDuAn.THONG_TIN_THEM;
                mmMo_ta.Text = doDuAn.MO_TA;
                cotxoa1.Visible = false;
                cotxoa2.Visible = false;
                cot_suafile.LayoutViewField.Visibility = cot_xoa.LayoutViewField.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;

                if (IsAdd == false)
                {
                    btnSave.Visible = true;
                    cotxoa1.Visible = true;
                    cotxoa2.Visible = true;
                    btnThemCV.Visible = true;
                    cot_suafile.LayoutViewField.Visibility = cot_xoa.LayoutViewField.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                }
            }
            LoadDataForSelectedTab(false);
        }
        private void _InitColumnLayoutTaiLieu()
        {
            XtraGridSupportExt.TextLeftColumn(lvTieuDe, "TIEU_DE");
            XtraGridSupportExt.TextLeftColumn(lvFile_dinh_kem, "TEN_FILE");
            XtraGridSupportExt.TextLeftColumn(lvNguoiCapNhat, "TEN_NGUOI_CN");
            XtraGridSupportExt.TextLeftColumn(lvNgayCapNhat, "NGAY_CAP_NHAT");
            HelpGridColumn.CotMemoExEdit(lvGhi_chu, "GHI_CHU");
            XtraGridSupportExt.TextLeftColumn(cotID, "ID");
            XtraGridSupportExt.TextLeftColumn(cot_xoa, "xoa_file");
            XtraGridSupportExt.TextLeftColumn(cot_luufile, "luu_file");
            XtraGridSupportExt.TextLeftColumn(cot_mofile, "mo_file");
            XtraGridSupportExt.TextLeftColumn(cot_suafile, "sua_file");
            layoutView1.Appearance.CardCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            lvGhi_chu.OptionsColumn.ReadOnly = true;
            layoutView1.OptionsCustomization.AllowSort = false;
            layoutView1.OptionsCustomization.AllowFilter = false;
            layoutView1.OptionsBehavior.AllowSwitchViewModes = true;
            layoutView1.OptionsBehavior.AllowExpandCollapse = true;
            layoutView1.OptionsView.ShowCardCaption = true;
            gridViewTaiLieu.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
            layoutView1.OptionsHeaderPanel.EnableCustomizeButton = false;
        }
        private void _InitColumnGridCongViec()
        {        
            zoombarTienDo.Properties.Maximum = 100;
            zoombarTienDo.Properties.Minimum = 0;
            HelpGridColumn.CotTextLeft(CotCongViec, "CONG_VIEC");
            HelpGridExt1.colMultiline(CotNguoiThucHien, "NV_THAM_GIA");
            HelpGridColumn.CotTextLeft(CotLoaiCongViec, "TEN_LCV");
            HelpGridColumn.CotTextLeft(CotDoUuTien, "TEN_MUC_UU_TIEN");
            HelpGridColumn.CotTextLeft(CotTinhTrang, "TINH_TRANG");
            HelpGridColumn.CotTextCenter(CotTienDo, "TONG_TIEN_DO");
            HelpGridColumn.CotTextLeft(CotNguoiGiao, "TEN_NGUOI_GIAO");
            XtraGridSupportExt.DateTimeGridColumn(CotBatDau, "TU_NGAY");
            XtraGridSupportExt.DateTimeGridColumn(CotNgayKetThuc, "DEN_NGAY");
            XtraGridSupportExt.DateTimeGridColumn(cotNgayKTTT, "NGAY_KET_THUC");
            XtraGridSupportExt.TextCenterColumn(CotTGDuTinh, "THOI_GIAN_DU_KIEN");
            gridViewCongviec.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
            gridViewCongviec.OptionsView.ShowGroupedColumns = false;
            gridViewCongviec.OptionsBehavior.AutoExpandAllGroups = true;
            gridViewCongviec.OptionsView.ColumnAutoWidth = false;
            /////////////////////////////////////////
            StyleFormatCondition conditionBlue = new StyleFormatCondition();
            conditionBlue.Appearance.Options.UseForeColor = true;
            conditionBlue.Appearance.ForeColor = Color.Blue;
            conditionBlue.Condition = FormatConditionEnum.Expression;
            conditionBlue.Expression = "([DEN_NGAY] >= [NGAY_KET_THUC] and not(IsNull([NGAY_KET_THUC]))) or(IsNull([DEN_NGAY]) and not(IsNull([NGAY_KET_THUC]))) ";
            conditionBlue.ApplyToRow = true;

            StyleFormatCondition conditionRed = new StyleFormatCondition();
            conditionRed.Appearance.Options.UseForeColor = true;
            conditionRed.Appearance.ForeColor = Color.Red;
            conditionRed.Condition = FormatConditionEnum.Expression;
            conditionRed.Expression = "[DEN_NGAY] < [NGAY_KET_THUC] and not(IsNull([DEN_NGAY]))";
            conditionRed.ApplyToRow = true;
            gridViewCongviec.FormatConditions.AddRange(new StyleFormatCondition[] { conditionBlue, conditionRed });

            #region grid GhiNhatKy
            HelpGridColumn.CotReadOnlyDate(colTGCapNhat, "THOI_GIAN_CAP_NHAT", PLConst.FORMAT_DATETIME_STRING);
            HelpGridColumn.CotTextLeft(colNguoiCapNhat, "NGUOI_THUC_HIEN");
            HelpGridColumn.CotMemoExEdit(colNoiDung, "GHI_CHU");
            gridViewNhatKy.BestFitColumns();
            colNoiDung.OptionsColumn.AllowEdit = true;
            colNoiDung.OptionsColumn.ReadOnly = true;

            #endregion

        }

        private void frmDuAn_Load(object sender, EventArgs e)
        {
            PLTimeSheetUtil.PermissionForControl(NhanVien, NhanVien.Visible == true, NhanVien.Visible == true);
            HelpInputData.SetMaxLength(new object[]{
                txtTen_DA,200,
                 mmMo_ta, 7000,
                 mmTT_Them, 7000  
            });
            HelpXtraForm.SetFix(this);
            gridViewCongviec.BestFitColumns();
        }

        #endregion             

        #region Validate        
        public bool IsValidate()
        {
            bool flag;
            err.ClearErrors();
            flag = HelpInputData.ShowRequiredError(err,
                   new object[]{
                        LoaiDA, "Loại dự án",
                        txtTen_DA,"Tên Dự án",
                        NhanVien,"Người quản lý"                                          
                    }
               );
            if (tinhtrang._getSelectedID() == -1)
            {
                tinhtrang.SetError(err, "Vui lòng vào thông tin \"Tình trạng\" !");
                flag = false;
            }
            if (Muc_UT._getSelectedID() == -1)
            {
                Muc_UT.SetError(err, "Vui lòng vào thông tin \"Độ ưu tiên\" !");
                flag = false;
            }
            if (NguoiThucHien._CountSelectedIDs == 0)
            {
                NguoiThucHien._SetError(err, "Vui lòng vào thông tin \"Người thực hiện\" !");
            }
            
            if (ngaybatdau.EditValue != null && ngayKTDK.EditValue != null && (DateTime)ngaybatdau.EditValue > (DateTime)ngayKTDK.EditValue)
            {
                err.SetError(ngayKTDK, "Ngày kết thúc phải lớn hơn ngày bắt đầu.");
                err.SetError(ngaybatdau, "Ngày bắt đầu phải nhỏ hơn ngày kết thúc.");
                flag = false;
            }
            if (tinhtrang._getSelectedID() == 5 && (DateTime)ngaybatdau.EditValue > (DateTime)ngayKTTT.EditValue)
            {
                err.SetError(ngayKTTT, "Ngày kết thúc phải lớn hơn ngày bắt đầu.");
            }
            KiemTraNguoiThucHien();
            return !err.HasErrors;
        }
        #endregion

        #region Xử lý nút 
        private void btnThemCV_Click(object sender, EventArgs e)
        {                   
            if (btnThemCV.Tag.Equals("ThemCV"))
            {
                if (NguoiThucHien._CountSelectedIDs == 0)
                {
                    HelpMsgBox.ShowNotificationMessage("Vui lòng chọn \"Người thực hiện\" trước khi thêm công việc!");
                }
                else
                {
                    Congviec frm = new Congviec(-2, true, NguoiThucHien._SelectedIDs);
                    frm.UpdateCongViec_DuAn += new Congviec.UpdateKH_DA_CV(InsertDuAn_CongViec);
                    HelpProtocolForm.ShowModalDialog(this, frm);
                    LoadDataCongViec();
                    zoombarTienDo.Value = (int)lay_tiendo();
                }
            }
            else if (btnThemCV.Tag.Equals("ThemTL"))
            {
                frmThemTaiLieu frm = new frmThemTaiLieu(-2, true, doDuAn.ID, (long)LoaiTapTin.TapTinDuAn);
                HelpProtocolForm.ShowModalDialog(this, frm);
                LoadTapTin(_ID);
            }
            else
            {
                frmNhatKyDuAn frm = new frmNhatKyDuAn(_ID);
                HelpProtocolForm.ShowModalDialog(this, frm);
                this.gridControlNhatKy.DataSource = DADuAn.GetNhatKyDA(this._ID);
                
            }
        }

        private string getMucUuTien(long id)
        {
            string[] arrMUT = {"Cao","Thấp","Cao nhất","Thấp nhất","Trung bình" };
            return arrMUT[id + 1];
        }
        private void LoadDataCongViec()
        {
            DataTable table = DADuAn.LoadCongViec(_ID);
            foreach (KeyValuePair<DOPhanCongCongViec, List<DOChiTietPhanCong>> itemDic in dic_Cong_viec)
            {
                DataRow row = table.NewRow();
                row["PCCV_ID"] = itemDic.Key.PCCV_ID;
                row["CONG_VIEC"] = itemDic.Key.CONG_VIEC;
                foreach (DOChiTietPhanCong dopc in itemDic.Value)
                {
                    row["NV_THAM_GIA"] += DACongViec.getNameNV(dopc.MA_NV) + dopc.PHAN_TRAM_THAM_GIA + "% \n";
                }
                row["TEN_LCV"] = DACongViec.getTenLoaiCV(itemDic.Key.LCV_ID);
                row["TEN_MUC_UU_TIEN"] = getMucUuTien(itemDic.Key.MUC_UU_TIEN); 
                row["TINH_TRANG"] = DACongViec.getTinhTrang(itemDic.Key.TINH_TRANG);
                row["TONG_TIEN_DO"] = itemDic.Value[0].TIEN_DO + "%";
                row["TEN_NGUOI_GIAO"] = DACongViec.getNameNV(itemDic.Key.NGUOI_GIAO);
                row["TU_NGAY"] = itemDic.Key.NGAY_BAT_DAU;
                row["DEN_NGAY"] = itemDic.Key.NGAY_KET_THUC_DU_KIEN;
                row["NGAY_KET_THUC"] = itemDic.Key.NGAY_KET_THUC;
                row["THOI_GIAN_DU_KIEN"] = itemDic.Key.THOI_GIAN_DU_KIEN + " giờ";
                table.Rows.Add(row);
            }
            gridControlCongviec.DataSource = table;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if ((IsAdd == true) || (IsAdd == false))
            {
                #region Kiểm tra dữ liệu
                if (_ID == -2)
                {
                    doDuAn.ID = HelpDB.getDatabase().GetID("G_NGHIEP_VU");
                    _ID = doDuAn.ID;
                }
                doDuAn.NAME = txtTen_DA.Text;
                doDuAn.TINH_TRANG = tinhtrang._getSelectedID();
                doDuAn.LOAI_DU_AN = LoaiDA._getSelectedID();
                doDuAn.NGUOI_QUAN_LY = NhanVien._getSelectedID();
                doDuAn.MUC_UU_TIEN = Muc_UT._getSelectedID();
                doDuAn.NGAY_BAT_DAU = ngaybatdau.DateTime.Date;
                doDuAn.NGAY_KET_THUC = ngayKTDK.DateTime.Date;
                if (tinhtrang._getSelectedID() == 5)
                    doDuAn.NGAY_KET_THUC_THUC_TE = ngayKTTT.DateTime.Date;
                else
                    doDuAn.NGAY_KET_THUC_THUC_TE = null;
                doDuAn.TINH_TRANG = tinhtrang._getSelectedID();
                doDuAn.TIEN_DO = HelpNumber.ParseDecimal(labtiendo.Text);
                doDuAn.MO_TA = mmMo_ta.Text;
                doDuAn.THONG_TIN_THEM = mmTT_Them.Text;
                doDuAn.NGUOI_THUC_HIEN = NguoiThucHien._SelectedStrIDs;
                if (IsValidate())
                {
                    if (DADuAn.Instance.Update(doDuAn))
                    {
                        if (UpdateDuAn_KhachHang != null) UpdateDuAn_KhachHang(doDuAn.ID);
                        if (IsAdd == true)
                        {
                            HelpMsgBox.ShowNotificationMessage("Lưu thông tin thành công!");
                            xtraTabControl1.Enabled = true;
                            IsAdd = false;
                            LoadDataForSelectedTab(false);
                        }
                        else HelpXtraForm.CloseFormNoConfirm(this);
                    }
                    else { HelpMsgBox.ShowNotificationMessage("Lưu thông tin không thành công!"); }
                }
                
            }
        }
                    
                #endregion   
       
        private void btnDong_Click(object sender, EventArgs e)
        {
            if (IsAdd == null)
                this.Close();
            else
            {
                if (HelpMsgBox.ShowConfirmMessage("Bạn có chắc muốn đóng?") == DialogResult.Yes)
                {                   
                    this.Close();
                }                    
            }
        }              
        #endregion                  

        #region sự kiện trên Grid công việc     
        public void InsertDuAn_CongViec(long congviecID)
        {
            DADuAn.InsertDuAn_CongViec(doDuAn.ID, congviecID);
        }
        private void gridControlCongviec_DoubleClick(object sender, EventArgs e)
        {
            DataRow r = gridViewCongviec.GetDataRow(gridViewCongviec.FocusedRowHandle);
            if (r != null)
            {
                if (IsAdd == null)
                {
                    Congviec frm = new Congviec(HelpNumber.ParseInt64(r["pccv_id"]), null,NguoiThucHien._SelectedIDs);
                    HelpProtocolForm.ShowModalDialog(this, frm);
                }
                    ////HIEUNT:mới thêm sửa công việc từ dự án
                else if (IsAdd == false)
                {
                    if (HelpNumber.ParseInt64(r["ID_TT"]) != 4)
                    {
                        Congviec frm = new Congviec(HelpNumber.ParseInt64(r["pccv_id"]), false, NguoiThucHien._SelectedIDs);
                        HelpProtocolForm.ShowModalDialog(this, frm);
                        int temp = gridViewCongviec.FocusedRowHandle;
                        LoadDataCongViec();
                        gridViewCongviec.FocusedRowHandle = temp;
                        gridViewCongviec.SelectRow(temp);
                        zoombarTienDo.Value = (int)lay_tiendo();
                    }
                    else
                    {
                        HelpMsgBox.ShowNotificationMessage("Công việc đã hoàn tất không được sửa!");
                    }
                }
            }
        }
        /// <summary>
        /// Xóa công việc và KH_DA_CV
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void repositoryItemButtonEdit2_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (IsAdd != null)
            {
                if (HelpMsgBox.ShowConfirmMessage("Bạn có chắc xóa dữ liệu đang chọn không?") == DialogResult.Yes)
                {
                    DataRow r = gridViewCongviec.GetDataRow(gridViewCongviec.FocusedRowHandle);
                    if (r != null)
                    {
                        Int64 id_congviec = HelpNumber.ParseInt64(r["pccv_id"]);
                        DACongViec.DeleteAction(id_congviec);
                        DACongViec.DeleteCongViec(id_congviec);              
                        gridViewCongviec.DeleteSelectedRows();
                    }
                }
            }
        }
        #endregion 

        #region sự kiện trong cardView
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
                    if (HelpMsgBox.ShowConfirmMessage("Bạn có muốn xóa tài liệu \"" + r["TEN_FILE"].ToString() + "\" này không!") == DialogResult.Yes)
                    {
                        long id_taptin = HelpNumber.ParseInt64(r["ID"]);
                        DADuAn.Instance.DeleteDATT(id_taptin);
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
                    frmThemTaiLieu frm = new frmThemTaiLieu(HelpNumber.ParseInt64(r["ID"]), false, doDuAn.ID, (long)LoaiTapTin.TapTinDuAn);
                    HelpProtocolForm.ShowModalDialog(this, frm);
                    LoadTapTin(_ID);
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
        private void LoadTapTin(Int64 ID_TaiLieu)
        {
            DataSet ds = HelpDB.getDatabase().LoadDataSet(@"SELECT LUU_TRU_TAP_TIN.*,
            (SELECT NAME FROM DM_NHAN_VIEN WHERE ID = LUU_TRU_TAP_TIN.NGUOI_CAP_NHAT) TEN_NGUOI_CN 
            FROM LUU_TRU_TAP_TIN 
            WHERE ID IN (SELECT TAP_TIN_ID FROM OBJECT_TAP_TIN WHERE TYPE_ID=7 AND OBJECT_ID='" + ID_TaiLieu + "')");
           
            ds.Tables[0].Columns.Add("mo_file", typeof(Image));
            ds.Tables[0].Columns.Add("luu_file", typeof(Image));
            ds.Tables[0].Columns.Add("xoa_file", typeof(Image));
            ds.Tables[0].Columns.Add("sua_file", typeof(Image));
            ds.Tables[0].Columns.Add("SIZE", typeof(String));
            HelpGridColumn.CotTextLeft(lvSize, "SIZE");
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
        #endregion

        #region Các hàm xử lý khác 
        public decimal lay_tiendo()
        {////Hieunt:
            decimal tiendo = 0;
            int phanTram = 0;
            DataView v = (DataView)gridViewCongviec.DataSource;
            foreach (DataRow r in v.Table.Rows)
            {
                tiendo += (HelpNumber.ParseDecimal(r["TIEN_DO"]) * HelpNumber.ParseInt32(r["TONG_PHAN_TRAM_CV"]));
                phanTram += HelpNumber.ParseInt32(r["TONG_PHAN_TRAM_CV"]);
            }
            if (phanTram > 0)
            {
                tiendo = HelpNumber.RoundDecimal(tiendo /= phanTram, 2);
            }   
            labtiendo.Text = tiendo.ToString();
            return tiendo;
        }       
        private void tinhtrang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tinhtrang._getSelectedID() == 5 && IsAdd == false)
            {
                DataView v = (DataView)gridViewCongviec.DataSource;
                foreach (DataRow r in v.Table.Rows)
                {
                    long id = HelpNumber.ParseInt64(r["ID_TT"]);
                    if (id != 4)
                    {
                        HelpMsgBox.ShowNotificationMessage("Công việc chưa hoàn thành không được kết thúc dự án.");
                        tinhtrang._setSelectedID(3);
                        break;
                    }
                }
                DataRow row = HelpDB.getDatabase().LoadDataSet("Select pc.* from DU_AN pc where ID= " + _ID).Tables[0].Rows[0];
                if (row["NGUOI_QUAN_LY"].ToString() != FrameworkParams.currentUser.employee_id.ToString() || zoombarTienDo.Value < 100)
                {
                    HelpMsgBox.ShowNotificationMessage("Bạn không có quyền hoàn tất công việc\n hoặc tiến độ chưa đạt 100%");
                    tinhtrang._setSelectedID(2);
                }
                else
                {
                    if (zoombarTienDo.Value == 100)
                    {
                        ngayKTTT.Enabled = true;
                        ngayKTTT.DateTime = DateTime.Now.Date;
                    }
                }

            }
            if (IsAdd == true)
            {
                tinhtrang._setSelectedID(1);
            }
            if (tinhtrang._getSelectedID() != 5)
            {
                ngayKTTT.Enabled = false;
                ngayKTTT.EditValue = null;
            }
        }
        private void KiemTraNguoiThucHien()
        {
            bool kq = false;
            string ten = "";
            if (IsAdd == false)
            {
                string id_NTH = NguoiThucHien._SelectedStrIDs;
                string[] arr = id_NTH.Split(',');
                /////////
                string qr = @"SELECT DISTINCT CT.MA_NV FROM CHI_TIET_PHAN_CONG CT
                                INNER JOIN PHAN_CONG_CONG_VIEC PC ON PC.PCCV_ID=CT.PCCV_ID
                                INNER JOIN KH_DA_CV CV ON PC.PCCV_ID=CV.PCCV_ID
                                INNER JOIN DU_AN DA ON DA.ID=CV.DU_AN_ID
                                WHERE DA.ID=" + _ID + " AND CT.TIEN_DO > 0 ";
                DataTable dt = HelpDB.getDatabase().LoadDataSet(qr).Tables[0];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    for (int j = 0; j < arr.Length; j++)
                    {
                        if (dt.Rows[i][0].ToString() == arr[j].ToString())
                        {
                            kq = true;
                        }
                    }
                    if (kq == false)
                    {
                        ten = ten + "\n" + NguoiThucHien._GetDisplayTextByID(HelpNumber.ParseInt64(dt.Rows[i][0]));
                    }
                }
                if (ten != "")
                {
                    NguoiThucHien._SetError(err, "Không được bỏ chọn: " + ten);
                }

            }

        }
        
        void xtraTabControl1_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            LoadDataForSelectedTab(true);
        }
        
        #endregion      

        private void repXoa_Click(object sender, EventArgs e)
        {
            if (IsAdd != null)
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

        }

        #region Extension

        private void LoadDataForSelectedTab(bool isTabChanged)
        {
            switch (xtraTabControl1.SelectedTabPageIndex)
            {
                case 0:
                    if (isTabChanged && gridControlCongviec.DataSource == null) LoadDataCongViec();
                    if (!isTabChanged) LoadDataCongViec();
                    btnThemCV.Text = "Thêm công việc";
                    btnThemCV.Tag = "ThemCV";
                    break;
                case 1:
                    if (isTabChanged && gridControlTaiLieu.DataSource == null) LoadTapTin(_ID);
                    if (!isTabChanged) LoadTapTin(_ID);
                    btnThemCV.Tag = "ThemTL";
                    btnThemCV.Text = "Thêm tài liệu";
                    break;
                default:
                    if (isTabChanged && gridControlNhatKy.DataSource == null) gridControlNhatKy.DataSource = DADuAn.GetNhatKyDA(_ID);
                    if (!isTabChanged) gridControlCongviec.DataSource = DADuAn.GetNhatKyDA(_ID);
                    btnThemCV.Tag = "GhiNK";
                    btnThemCV.Text = "Ghi nhật ký";
                    break;
            }

            if (IsAdd == null || IsAdd == true)
                btnThemCV.Visible = false;
            else CheckUser();
        }

        private void CheckUser()
        {
            bool isPermission = false;
            string[] arrNguoiThucHien = doDuAn.NGUOI_THUC_HIEN.Split(',');
            for (int i = 0; i < arrNguoiThucHien.Length; i++)
            {
                if (arrNguoiThucHien[i] == FrameworkParams.currentUser.employee_id.ToString())
                {
                    isPermission = true;
                    break;
                }
            }
            if (doDuAn.NGUOI_QUAN_LY == FrameworkParams.currentUser.employee_id)
                isPermission = true;
            btnThemCV.Visible = isPermission;
        }
        #endregion

    }
}
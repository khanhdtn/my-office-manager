using ProtocolVN.Framework.Win;
using System.Data;
using System;
using System.Drawing;
using System.Windows.Forms;
using ProtocolVN.Framework.Core;
using DevExpress.XtraEditors.DXErrorProvider;
using ProtocolVN.DanhMuc;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid;
using System.Threading;
using System.IO;
using DevExpress.XtraGrid.Views.Base;
using DTO;
using DAO;
using pl.office;

namespace office
{
    public partial class frmBangTheoDoi : DevExpress.XtraEditors.XtraForm
    {
        private bool? IsAdd; //true = New, null = View, false = Edit
        private long _ID;
        private string tableName;
        private DOBangTheoDoi doBangTheoDoi;
        private DataSet GridDataSet;
        private DXErrorProvider Error;

        #region Hàm dựng
        public frmBangTheoDoi(long ID,bool? IsAdd)
        {
            InitializeComponent();
            this.IsAdd = IsAdd;
            this._ID = ID;
            this.Tag = true;
            InitControl();
            InitValidation();
            InitDOData(this._ID);
            this.Error = GUIValidation.GetErrorProvider(this);

            this.LoaiCongViec.SelectedIndexChanged += new EventHandler(LoaiCongViec_SelectedIndexChanged);
            this.btnTaiLieuDinhKem.Click += new EventHandler(btnTaiLieuDinhKem_Click);
            this.FormClosing += delegate(object abc, System.Windows.Forms.FormClosingEventArgs eabc)
            {
                DABangTheoDoi.ColseForm(this, IsAdd, eabc);
            };
            this.btnDong.Click += new EventHandler(btnDong_Click);
            this.btnLuu.Click += new EventHandler(btnLuu_Click);
            this.btnXoa.Click += new EventHandler(btnXoa_Click);
        }
        public frmBangTheoDoi() : this(-2, true) { }
        #endregion

        #region Init Form
        public void InitControl()
        {
            this.btnLuu.Image = FWImageDic.SAVE_ALL_IMAGE16;
            this.btnXoa.Image = FWImageDic.DELETE_IMAGE16;
            this.btnDong.Image = FWImageDic.EXIT_IMAGE16;

            this.NgayLap.DateTime = DateTime.Now;
            this.NgayKy.DateTime = DateTime.Now;
            this.NgayHieuLuc.DateTime = DateTime.Now;

            this.Tag = true;
            this.TagControl1.SelectedTabPageIndex = 0;

            DMFWNhanVien.I.InitCtrl(NguoiLap, true, true);
            DMFWNhanVien.I.InitCtrl(NguoiKy, true, true);
            DMFWNhanVien.I.InitCtrl(NguoiQuanLy, true, true);
            DMLoaiCongViec.I.InitCtrl(LoaiCongViec, true, true);
            DMTinhTrangCongViec.I.InitCtrl(TinhTrang, true, true);

            this.toolStripMenuItemXem.Click += new EventHandler(toolStripMenuItemXem_Click);
        }
        public void InitValidation()
        {
            this.Error = GUIValidation.GetErrorProvider(this);
            GUIValidation.SetMaxLength(
                new object[]{
                        SoPhieu, 100,
                        GhiChu, 1000
                    }
            );
        }
        public void InitDOData(object id)
        {
            this.tableName = DMDiemTheoDoi.I.getTableName(this.LoaiCongViec._getSelectedID());
            doBangTheoDoi = DABangTheoDoi.Instance.LoadAll(HelpNumber.ParseInt64(id), this.tableName);
            if (this.IsAdd == true)
            {
                this.doBangTheoDoi.BTD_ID = HelpDB.getDatabase().GetID("G_NGHIEP_VU");
                this.SoPhieu.Text = DatabaseFB.getSoPhieu("BANG_THEO_DOI", "MA_BTD", DatabaseFB.GetThamSo("MA_BTD"));
            }
            else
            {
                if (doBangTheoDoi.DetailDataSet != null)
                {
                    if (doBangTheoDoi.DetailDataSet.Tables[0].Rows.Count > 0)
                    {
                        this.LoaiCongViec._setSelectedID(HelpNumber.ParseInt64(doBangTheoDoi.DetailDataSet.Tables[0].Rows[0]["LCV_ID"].ToString()));
                        this.tableName = DMDiemTheoDoi.I.getTableName(this.LoaiCongViec._getSelectedID());
                    }
                }
                this.SoPhieu.Text = doBangTheoDoi.MA_BTD;
                this.txt_Name.Text = doBangTheoDoi.NAME;
                this.NgayLap.DateTime = Convert.ToDateTime(doBangTheoDoi.NGAY_LAP);
                this.NguoiLap._setSelectedID(doBangTheoDoi.NGUOI_LAP);
                this.NgayKy.DateTime = Convert.ToDateTime(doBangTheoDoi.NGAY_KY);
                this.NguoiKy._setSelectedID(doBangTheoDoi.NGUOI_KY);
                this.NgayHieuLuc.DateTime = Convert.ToDateTime(doBangTheoDoi.NGAY_HIEU_LUC);
                this.NguoiQuanLy._setSelectedID(doBangTheoDoi.NGUOI_QUAN_LY);
                this.txtTenTaiLieu.Text = this.doBangTheoDoi.TEN_TAI_LIEU;
                this.TinhTrang._setSelectedID(doBangTheoDoi.TINH_TRANG);
                if (doBangTheoDoi.HINH_THUC_THONG_BAO == 1) this.chkMail.Checked = true;
                else if (doBangTheoDoi.HINH_THUC_THONG_BAO == 2) this.chkDienThoai.Checked = true;
                else if (doBangTheoDoi.HINH_THUC_THONG_BAO == 3) this.chkGap.Checked = true;
                this.GhiChu.Text = doBangTheoDoi.GHI_CHU;
            }
            InitGrid();
        }
        public void InitGrid()
        {
            GridView view = null;
            GridControl grid = null;
            foreach (Control ctrl in TagControl1.SelectedTabPage.Controls)
            {
                if (ctrl.Name == gridControlDanhSach.Name) { grid = gridControlDanhSach; view = gridViewDanhSach; break; }
                else if (ctrl.Name == gridControlThoiHan.Name) { grid = gridControlThoiHan; view = gridViewThoiHan; break; }
                else if (ctrl.Name == gridControlTuan.Name) { grid = gridControlTuan; view = gridViewTuan; break; }
                else if (ctrl.Name == gridControlDiemTheoDoi.Name) { grid = gridControlDiemTheoDoi; view = gridViewDiemTheoDoi; break; }
            }
            InitGrid(grid, view);
        }
        public void InitGrid(GridControl grid, GridView view)
        {
            DMDiemTheoDoi.I.InitColumns(CotNhanSu, this.tableName, view);
            LoadGridDataSet(grid);

            view.Click += new EventHandler(gridView_Click);
            view.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(gridView_ValidateRow);
            view.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(gridView_InvalidRowException);
            if (this.IsAdd != null)
                XtraGridSupportExt.CloseButton(grid, view);
            else if (this.IsAdd == null)
            {
                view.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
                view.OptionsBehavior.Editable = false;
                this.btnThongBao.Visible = false;
                this.btnLuu.Visible = false;
                this.btnXoa.Visible = false;
            }
        }
        public void LoadGridDataSet(GridControl grid)
        {
            this.GridDataSet = this.doBangTheoDoi.DetailDataSet.Copy();
            grid.DataSource = this.GridDataSet.Tables[0];
        }
        #endregion

        #region Xử lý sự kiện
        public void gridView_Click(object sender, EventArgs e)
        {
            //GridView view = (GridView)sender;
            ////Lấy ra vị trí click của Muose trên gridview
            //GridHitInfo gHitInfo = view.CalcHitInfo(view.GridControl.PointToClient(Control.MousePosition));
            //if (gHitInfo.InRowCell)//Nếu vị trí click là cell trong row
            //    DABangTheoDoi.Instance.gridView_Click(gHitInfo, view, this.IsAdd, this.GridDataSet, this.tableName);
        }     
        public void LoaiCongViec_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.tableName = DMDiemTheoDoi.I.getTableName(this.LoaiCongViec._getSelectedID());
            if (tableName == null)
            {
                HelpMsgBox.ShowNotificationMessage("Công việc này chưa hỗ trợ, xin vui lòng liên hệ với PROTOCOL!");
                return;
            }
            doBangTheoDoi.DetailDataSet = FWDBService.LoadDataSet(tableName, "BTD_ID", doBangTheoDoi.BTD_ID);
            GridView view = null;
            GridControl grid = null;
            foreach (Control ctrl in TagControl1.SelectedTabPage.Controls)
            {
                if (ctrl.Name == gridControlDanhSach.Name) { grid = gridControlDanhSach; view = gridViewDanhSach; break; }
                else if (ctrl.Name == gridControlThoiHan.Name) { grid = gridControlThoiHan; view = gridViewThoiHan; break; }
                else if (ctrl.Name == gridControlTuan.Name) { grid = gridControlTuan; view = gridViewTuan; break; }
                else if (ctrl.Name == gridControlDiemTheoDoi.Name) { grid = gridControlDiemTheoDoi; view = gridViewDiemTheoDoi; break; }
            }
            InitGrid(grid, view);
        }
        public void btnTaiLieuDinhKem_TextChanged(object sender, System.EventArgs e)
        {
            if (this.btnTaiLieuDinhKem.Text != "")
            {
                ToolTip toolTip = new ToolTip();
                toolTip.ShowAlways = true;
                toolTip.SetToolTip(this.btnTaiLieuDinhKem, this.btnTaiLieuDinhKem.Text.ToString());
            }
        }
        #endregion

        #region Xử lý nút
        public void btnXoa_Click(object sender, EventArgs e)
        {
            if (HelpMsgBox.ShowConfirmMessage("Bạn có chắc muốn xóa?") == DialogResult.Yes)
            {
                if (DABangTheoDoi.Instance.Delete(doBangTheoDoi.BTD_ID))
                    DABangTheoDoi.ColseForm(this, true);
                else ErrorMsg.ErrorDelete(this);
            }
        }
        public void btnLuu_Click(object sender, EventArgs e)
        {
            if (GetData() == true && this.GridDataSet != null)
            {
                bool? tf = DABangTheoDoi.Instance.saveData(this.GridDataSet, doBangTheoDoi, this.IsAdd);
                if (tf == true)
                    DABangTheoDoi.ColseForm(this, true);
                else if (tf == false)
                    HelpMsgBox.ShowNotificationMessage("Lưu thông tin không thành công. Xin vui lòng kiểm tra lại số liệu.");
            }
        }
        public void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void btnTaiLieuDinhKem_Click(object sender, EventArgs e)
        {
            if (this.IsAdd == null) return;
            string path = null;
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Title = "Chọn tài liệu đính kèm:";
            DialogResult value = openFile.ShowDialog();
            if (value == DialogResult.OK)
            {
                path = openFile.FileName;
                //Kiểm tra độ lớn của file
                if (!HelpFile.CheckFileSize(path, 100))
                {
                    //Độ lớn của file lớn hơn độ lớn qui định
                    HelpMsgBox.ShowNotificationMessage("Bạn không được chọn file lớn hơn 100 MB.");
                    path = null;
                    btnTaiLieuDinhKem_Click(sender, e);
                }
            }
            else if (value == DialogResult.Cancel)
            {
                path = null;
                return;
            }

            Thread.Sleep(200);
            if (path != null)
            {
                //Chuyển file sang byte[]
                byte[] bytes = HelpFile.FileToBytes(path);
                this.doBangTheoDoi.TAI_LIEU = bytes;
                this.txtTenTaiLieu.Text = Path.GetFileName(path);
                this.doBangTheoDoi.TEN_TAI_LIEU = Path.GetFileName(path);
            }
        }
        public void toolStripMenuItemXem_Click(object sender, EventArgs e)
        {
            if(txtTenTaiLieu.Text == "" || doBangTheoDoi.TAI_LIEU == null) return;
            string path = FrameworkParams.TEMP_FOLDER + @"\" + txtTenTaiLieu.Text;
            HelpFile.BytesToFile(doBangTheoDoi.TAI_LIEU, path);
            HelpFile.OpenFile(path);
        }
        private void btnTaiLieuDinhKem_ArrowButtonClick(object sender, EventArgs e)
        {
            ctMenuTaiLieu.Show(new Point(MousePosition.X, MousePosition.Y));
        }
        #endregion

        #region Validate
        public bool ValidateData()
        {
            bool flag = true;
            Error.ClearErrors();
            flag = GUIValidation.ShowRequiredError(Error,
                new object[]{
                        txt_Name, "Tên bảng theo dõi",
                        NgayLap, "Ngày lập",
                        NgayKy, "Ngày ký",
                        NgayHieuLuc, "Ngày hiệu lực",
                        NguoiLap, "Người lập",
                        NguoiKy, "Người ký",
                        NguoiQuanLy, "Người quản lý",
                        LoaiCongViec, "Loại công việc",
                        TinhTrang, "Tình trạng"
                    }
            );
            return flag;
        }
        public void gridView_ValidateRow(object sender, ValidateRowEventArgs e)
        {
            GridView grid = ((GridView)sender);
            DataRow row = grid.GetDataRow(e.RowHandle);
            grid.ClearColumnErrors();
            if (this.tableName == null)
            {
                Error.ClearErrors();
                GUIValidation.ShowRequiredError(Error,
                    new object[]{
                        LoaiCongViec, "Loại công việc",
                    }
                );
                e.Valid = false;
                this.Tag = false;
                return;
            }
            else if (!DABangTheoDoi.Instance.ValidateDetail(row, tableName))
            {
                e.Valid = false;
                this.Tag = false;
                return;
            }
            PLValidation.CheckDuplicate(grid, this.GridDataSet, e, this.tableName);
            if (!e.Valid)
            {
                e.Valid = false;
                this.Tag = false;
                return;
            }
            e.Valid = true;
            this.Tag = true;
            if (row["DTD_ID"].ToString() == "")
                row["DTD_ID"] = HelpDB.getDatabase().GetID("G_NGHIEP_VU");
            row["BTD_ID"] = this.doBangTheoDoi.BTD_ID;
            row["LCV_ID"] = this.LoaiCongViec._getSelectedID();
            row["NGUOI_CAP_NHAT"] = FrameworkParams.currentUser.employee_id;
            row["NGAY_CAP_NHAT"] = DateTime.Now;
        }
        public void gridView_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
        }
        public bool GetData()
        {
            GUIValidation.TrimAllData(new object[]{
                    SoPhieu,
                    GhiChu
                });
            if (ValidateData() && (bool)this.Tag != false)
            {
                doBangTheoDoi.MA_BTD = this.SoPhieu.Text;
                doBangTheoDoi.NAME = this.txt_Name.Text;
                doBangTheoDoi.NGAY_LAP = this.NgayLap.DateTime;
                doBangTheoDoi.NGUOI_LAP = NguoiLap._getSelectedID();
                doBangTheoDoi.NGAY_KY = this.NgayKy.DateTime;
                doBangTheoDoi.NGUOI_KY = this.NguoiKy._getSelectedID();
                doBangTheoDoi.NGAY_HIEU_LUC = this.NgayHieuLuc.DateTime;
                doBangTheoDoi.NGUOI_QUAN_LY = this.NguoiQuanLy._getSelectedID();
                doBangTheoDoi.TINH_TRANG = this.TinhTrang._getSelectedID();
                if (chkMail.Checked) doBangTheoDoi.HINH_THUC_THONG_BAO = 1;
                else if (chkDienThoai.Checked) doBangTheoDoi.HINH_THUC_THONG_BAO = 2;
                else if (chkGap.Checked) doBangTheoDoi.HINH_THUC_THONG_BAO = 3;
                doBangTheoDoi.GHI_CHU = this.GhiChu.Text;
                doBangTheoDoi.NGUOI_CAP_NHAT = FrameworkParams.currentUser.employee_id;
                doBangTheoDoi.NGAY_CAP_NHAT = DateTime.Now;
                return true;
            }
            return false;
        }
        #endregion
    }
}
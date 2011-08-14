using System;
using System.Data;
using DAO;
using ProtocolVN.Framework.Core;
using ProtocolVN.Framework.Win;

using DevExpress.XtraEditors.DXErrorProvider;

namespace office
{
    public partial class frmCapNhatTienDo : XtraFormPL
    {
        #region biến toàn cục
        Int64 PCCV_ID;
        Int64 NV_ID;
        DXErrorProvider Error;
        public delegate void RefreshPhanCongCV();
        public  RefreshPhanCongCV RefreshData;
        #endregion

        #region hàm khởi tạo        
        public frmCapNhatTienDo(Int64 pccv_id)
        {
            InitializeComponent();
            this.PCCV_ID = pccv_id;
            this.NV_ID = FrameworkParams.currentUser.employee_id;
            Error = new DXErrorProvider();
            initForm();
            HelpGrid.SetUpperTitle(this.gridViewTienDoThuHien, "LỊCH SỬ THỰC HIỆN");
            HelpGridExt1.DisableCaptionGroupCol(this.gridViewTienDoThuHien);
        }
        #endregion

        #region khởi tạo thuộc tính ban đầu
        private void frmCapNhatTienDo_Load(object sender, EventArgs e)
        {
            HelpControl .setEnterAsTab(this);
            HelpGrid.ShowNumOfRecord(gridCtrlTienDoThucHien);
            if (HelpNumber.ParseInt32(colTienDoThuHien.SummaryItem.SummaryValue) > 0) {
                ztbarTienDoThucHien.Properties.Maximum = (int)100 - HelpNumber.ParseInt32(colTienDoThuHien.SummaryItem.SummaryValue);
                ztbarTienDoThucHien.Value = 0;
                lblTienDo.Text =  "0";
            }            
        }
        private void initForm()
        {
            DOPhanCongCongViec do_pccv=new DOPhanCongCongViec();
            do_pccv = DACongViec.LoadPCCV(PCCV_ID);
            txtNguoiCapNhat.Text = DACongViec.getNameNV(NV_ID);
            txtTenDuAn.Text = do_pccv.CONG_VIEC;
            txtThoiGianCapNhat.Text = HelpDB.getDatabase().GetSystemCurrentDateTime().ToString(PLConst.FORMAT_DATETIME_STRING);
            ztbarTienDoThucHien.Value = DACongViec.tienDoCuoi(NV_ID, PCCV_ID);
            lblTienDo.Text = ztbarTienDoThucHien.Value.ToString() ;
            gridViewTienDoThuHien.OptionsBehavior.AutoExpandAllGroups = true;
            initGrid();
        }
        private void initGrid()
        {
           String sqlString = @"select ct.thoi_gian_cap_nhat,ct.tien_do,ct.GHI_CHU
                            from chi_tiet_phan_cong ct left join dm_nhan_vien nv on ct.ma_nv = nv.id
                            where ct.ma_nv = " + FrameworkParams.currentUser.employee_id + @"
                            and ct.tien_do > 0 and ct.pccv_id = " +PCCV_ID + "order by thoi_gian_cap_nhat desc";
           DataTable dt = HelpDB.getDatabase().LoadDataSet(sqlString).Tables[0];
           dt.Columns.Add("TIEN_DO_%");
           foreach (DataRow row in dt.Rows)
           {
               row["TIEN_DO_%"] = row["TIEN_DO"]+"%";
           }
           HelpGridColumn.CotPLTimeEdit(colNgayCapNhat, "THOI_GIAN_CAP_NHAT", PLConst.FORMAT_DATETIME_STRING);    
           HelpGridColumn.CotTextRight(colTienDoThuHien,"TIEN_DO_%");
           HelpGridColumn.CotTextLeft(colGhiChu,"GHI_CHU");
           gridCtrlTienDoThucHien.DataSource = dt;
        }
        #endregion

        #region xử lý nút
        private void buttonThoat_Click(object sender, EventArgs e)
        {
            this.Close();            
        }

        private void buttonLuu_Click(object sender, EventArgs e)
        {            
            if (HelpNumber.ParseInt32(colTienDoThuHien.SummaryItem.SummaryValue) == 100) {
                HelpMsgBox.ShowNotificationMessage("Công việc đã hoàn thành.Không thể cập nhật thêm tiến độ!");
                this.Close();
                return;
            }
            if (ztbarTienDoThucHien.Value == 0) {
                Error.SetError(ztbarTienDoThucHien, "Tiến độ phải lớn hơn 0!");
                return;
            }
            DOChiTietPhanCong chiTietPhanCong = new DOChiTietPhanCong(PCCV_ID, NV_ID, DACongViec.getPhanTramThamGia(NV_ID, PCCV_ID), HelpNumber.ParseInt32(colTienDoThuHien.SummaryItem.SummaryValue) + ztbarTienDoThucHien.Value, HelpDB.getDatabase().GetSystemCurrentDateTime(), memoGhiChu.Text);
            if (DACongViec.luuCapNhatTienDo(chiTietPhanCong))
            {
                if (RefreshData != null) RefreshData();
                this.Close();
            }
            else
                HelpMsgBox.ShowNotificationMessage("Lưu không thành công.");            
        }
        #endregion

        #region sự kiện
        private void ztbarTienDoThucHien_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            lblTienDo.Text = ztbarTienDoThucHien.Value.ToString();
        }
        private void ztbarTienDoThucHien_EditValueChanged(object sender, EventArgs e)
        {
            lblTienDo.Text = ztbarTienDoThucHien.Value.ToString();           
        }
        #endregion                
    }
}
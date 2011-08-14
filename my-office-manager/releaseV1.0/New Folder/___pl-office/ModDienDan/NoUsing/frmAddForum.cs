using System;
using System.Data;
using System.Windows.Forms;
using ProtocolVN.Framework.Core;
using ProtocolVN.Framework.Win;
using DevExpress.XtraEditors.DXErrorProvider;
using DAO;
using DTO;
using ProtocolVN.DanhMuc;


namespace office
{
    
    public partial class frmAddForum : XtraFormPL
    {
        #region Vùng đặt Static
        public static FormStatus Status = FormStatus.NO_USE;
        public static string MenuItem(string ParentID, bool IsSep)
        {
            return MenuBuilder.CreateItem(typeof(frmAddForum).FullName,
                PMSupport.UpdateTitle("Bài viết", Status),
                ParentID, true,
                typeof(frmAddForum).FullName,
                false, IsSep, "", true, "", "");
        }
        #endregion

        #region Các khai báo biến
        public delegate void Update_Data(DataRow row);
        public Update_Data Refresh_Data_Row;
        public delegate void Update_Bai_Viet();
        public Update_Bai_Viet Refresh_BV;
        private bool? IsAdd; //true:new,false:edit,null:view        
        private DOBaiViet doBaiViet = null;
        private DOLuuTruTapTin do_luu_tru_tt = null;
        private Int64 _maxFileSize = 20;
        private long _ID=0;
        long _Nhom_DD_ID;
        private long _Chuyen_muc_ID;
        private DXErrorProvider Error;
        private string pathSource = string.Empty;
        private string pathNew = string.Empty;       
        #endregion
       
        #region Các hàm khởi tạo
        public frmAddForum(long ID,long Nhom_DD_ID,long Chuyen_muc_ID,bool? _isAdd,bool IsBaiVietGoc,string TieuDe)
        {
            InitializeComponent();
            Error = new DXErrorProvider();
            this._ID = ID;
            this.IsAdd = _isAdd;
            this._Nhom_DD_ID=Nhom_DD_ID;
            this._Chuyen_muc_ID = Chuyen_muc_ID;
            PLDienDan.InitChonDienDan(PLNhomDienDan,true);
            txtTieude.Text = TieuDe;
            PLNhomDienDan.ToolTip = "";
            PLChuyenMuc.ToolTip = "";
            if (IsAdd == false && IsBaiVietGoc == false) {
                PLNhomDienDan.Enabled = PLChuyenMuc.Enabled = txtTieude.Enabled=false;
            }
            InitData(_ID);
            Init_State(IsAdd);
        }

        public frmAddForum() : this(-2, -2, -2, true, true, string.Empty) { }

        #endregion

        #region Khởi tạo Data
        /// <summary>
        /// Khởi tạo dữ liệu 
        /// </summary>
        /// <param name="ID"></param>
        private void InitData(long ID)
        {
            if (this.IsAdd == true)
            {
                if (ID > 0)                                    
                {                    
                    PLNhomDienDan._setSelectedID(_Nhom_DD_ID);
                    PLNhomDienDan.Enabled = false;
                    PLChuyenMuc._setSelectedID(_Chuyen_muc_ID);
                    PLChuyenMuc.Enabled = false;
                    txtTieude.Enabled = false;
                    doBaiViet = null;
                }
                doBaiViet = DABaiViet.Instance.LoadAll(-2);
                do_luu_tru_tt = DALuuTruTapTin.Instance.LoadAll(-2);
                lblNguoiCapNhat.Text = DMNhanVienX.I.GetEmployeeFullName(FrameworkParams.currentUser.employee_id);
                lblThoiGianCapNhat.Text = DABase.getDatabase().GetSystemCurrentDateTime().ToString(PLConst.FORMAT_DATETIME_STRING);
            }
            else
            {
                doBaiViet = DABaiViet.Instance.LoadAll(ID);
                do_luu_tru_tt = DALuuTruTapTin.Instance.LoadAll(DABaiViet.Instance.get_TapTin(ID).ID);
                if (DABaiViet.Instance.Da_tra_loi(ID))
                {
                    PLNhomDienDan.Enabled = false;                    
                    PLChuyenMuc.Enabled = false;
                    txtTieude.Enabled = false;
                }
                lblNguoiCapNhat.Text = DMFWNhanVien.GetFullName(doBaiViet.NGUOI_GUI);
                lblThoiGianCapNhat.Text = doBaiViet.NGAY_GUI.ToString(PLConst.FORMAT_DATETIME_STRING);
                txtTieude.Text = doBaiViet.CHU_DE;
                PLNhomDienDan._setSelectedID(doBaiViet.ID_NHOM_DIEN_DAN);
                PLChuyenMuc._setSelectedID(_Chuyen_muc_ID);
                NoiDung._setValue(doBaiViet.NOI_DUNG);
                //CHAUTV: Áp dụng control mới
                this.fileDinhKem._setFileName(do_luu_tru_tt.TEN_FILE, do_luu_tru_tt.NOI_DUNG);
                if (this.IsAdd == null)
                    this.fileDinhKem.ReadOnly(true);
            }            
        }
        /// <summary>
        /// Khởi tạo trạng thái cho các nút
        /// </summary>
        /// <param name="IsAdd"></param>
        private void Init_State(bool? IsAdd)
        {
            if (IsAdd == null)
            {
                btnLuu.Enabled = false;
                btnClose.Enabled = true;
                btnXoa.Enabled = false;
            }
            else if (IsAdd == false)
            {
                btnXoa.Enabled = true;
                btnLuu.Enabled = true;
                btnClose.Enabled = true;
            }
            else
            {
                btnLuu.Enabled = true;
                btnClose.Enabled = true;
                btnXoa.Enabled = false;             
            }            
        }        
        #endregion

        #region InitForm
        private void frmTinTuc_Load(object sender, EventArgs e)
        {
            HelpControl .setEnterAsTab(this);
            btnClose.Image = FWImageDic.CLOSE_IMAGE16;
            btnLuu.Image = FWImageDic.SAVE_IMAGE16;
            GUIValidation.SetMaxLength(new object[]{
                txtTieude,200});                                                                                                            
            PMSupport.SetTitle(this, Status);            

            if (IsAdd == true)
            {
                PLDienDan.InitChonDienDan(PLNhomDienDan,true);                
            }
            HelpXtraForm.SetFix(this);
        }
        #endregion
      
        #region Validate(ktra lỗi)

        public bool IsValidate()
        {
            Error.ClearErrors();
            bool bFlag= GUIValidation.ShowRequiredError(Error,
                   new object[]{
                        PLNhomDienDan, "Nhóm diễn đàn",
                        PLChuyenMuc,"Chuyên mục",
                        txtTieude,"Chủ đề"
                   }
            );
            //if (PLNoidung.BodyText != null || PLNoidung.Document.Images.Count > 0)
            //    return !Error.HasErrors;
            //else
            //{
            //    PLMessageBox.ShowNotificationMessage("Vui lòng vào thông tin \"Nội dung\"!");
            //    return false;
            //}
            return bFlag;
        }
        #endregion

        #region Xử lý nút
        
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (IsValidate())
            {
                    Get_Data();
                    if (DABaiViet.Instance.Update(doBaiViet) && DALuuTruTapTin.Instance.Update(do_luu_tru_tt))
                    {                        
                        try
                        {
                            if (IsAdd == true) DABaiViet.Instance.INSERT_BAI_VIET_TAP_TIN(doBaiViet.ID, do_luu_tru_tt.ID);
                            //if (IsAdd == false && doBaiViet.ID_BAI_VIET_PARENT > 0) Refresh_BV();
                        }
                        catch (Exception ex) { PLMessageBox.ShowConfirmMessage(ex.ToString()); }
                        finally
                        {
                            this.Close();
                        }
                    }
                    else
                        PLMessageBox.ShowNotificationMessage("Lưu không thành công !");
            }
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (PLMessageBox.ShowConfirmMessage("Bạn có muốn xóa không!") == DialogResult.Yes)
            {
                DABaiViet.Instance.Delete(doBaiViet.ID);
                this.Close();
            }
        }        
        private void btnClose_Click(object sender, EventArgs e)
        {
            if (PLMessageBox.ShowConfirmMessage("Bạn có muốn đóng ?") == DialogResult.Yes)
                this.Close();
        }

        #endregion  
           
        #region Các hàm chức năng 
        /// <summary>
        /// Lấy dữ liệu để cập nhật
        /// </summary>
        private void Get_Data()
        {
            //Get data cho BAI_VIET
            doBaiViet.ID_NHOM_DIEN_DAN = PLNhomDienDan._getSelectedID();
            doBaiViet.ID_CHUYEN_MUC = PLChuyenMuc._getSelectedID();
            doBaiViet.NOI_DUNG = NoiDung._getValue();
            doBaiViet.NGAY_GUI = DABase.getDatabase().GetSystemCurrentDateTime();
            doBaiViet.NGUOI_GUI = FrameworkParams.currentUser.employee_id;
            doBaiViet.CHU_DE = txtTieude.Text;
            if (IsAdd == true && _ID > 0)
            {
                doBaiViet.ID_BAI_VIET_PARENT = _ID;
                //Call function update answer times
                //Refresh_Data_Row(DABaiViet.Instance.Get_Updated_Row(_ID));                
               // DABaiViet.Instance.Update_SO_LAN_TRA_LOI(_ID, "SO_LAN_TRA_LOI");                
            }

            //Get data cho LUU_TRU_TAP_TIN
            if (pathSource.IndexOf(@"\") > 0)
                do_luu_tru_tt.NOI_DUNG = HelpByte.FileToBytes(pathSource);
            do_luu_tru_tt.NGAY_CAP_NHAT = doBaiViet.NGAY_GUI;
            do_luu_tru_tt.NGUOI_CAP_NHAT = doBaiViet.NGUOI_GUI;
            do_luu_tru_tt.TIEU_DE = doBaiViet.CHU_DE;

            //CHAUTV: Áp dụng control mới
            do_luu_tru_tt.TEN_FILE = this.fileDinhKem._getFileName();
            do_luu_tru_tt.NOI_DUNG = this.fileDinhKem._getFileToBytes();
        }
        private void PLNhomDienDan_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                PLDienDan.InitChonChuyenMuc(PLChuyenMuc, PLNhomDienDan._getSelectedID());
                if ((PLChuyenMuc.DataSource as DataTable).Rows.Count < 1)
                    PLChuyenMuc.Text = string.Empty;
                PLChuyenMuc.Enabled = PLNhomDienDan._getSelectedID() != -1 ? true : false;
            }
            catch (Exception ex)
            {
                PLException.AddException(ex);
            }
        }
        private void btnTaptin_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }   
        #endregion        
       
       
    }
}
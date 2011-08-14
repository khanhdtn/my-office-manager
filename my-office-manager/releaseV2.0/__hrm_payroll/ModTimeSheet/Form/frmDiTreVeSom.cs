using System;
using System.Windows.Forms;
using DevExpress.XtraEditors.DXErrorProvider;
using ProtocolVN.Framework.Win;
using ProtocolVN.Framework.Core;
using DAO;
using DTO;
using ProtocolVN.DanhMuc;
using System.Collections.Generic;
using ProtocolVN.Framework.Dev.Open;

namespace pl.office.form
{
    public partial class frmDiTreVeSom : XtraFormPL
    {
        #region Vùng đặt Static 
        public static FormStatus Status = FormStatus.NO_USE;
        public static string MenuItem(string ParentID, bool IsSep)
        {
            return MenuBuilder.CreateItem(typeof(frmNghiPhep).FullName,
                PMSupport.UpdateTitle("Đi trễ về sớm", Status),
                ParentID, true,
                typeof(frmNghiPhep).FullName,
                false, IsSep, "mnbCHinhHeThong.png", true, "", "");
        }
        #endregion

        #region Các khai báo biến 
        private DOTimeInOut Phieu = null;
        private bool? IsAdd; //true = New, null = View, false = Edit
        private long _ID;
        private DXErrorProvider Error;   
        #endregion        

        #region Hàm dựng 
        public frmDiTreVeSom(long ID,bool? IsAdd)
        {
            InitializeComponent();
            Error = new DXErrorProvider();
            this.IsAdd = IsAdd;
            this._ID = ID;
            Duyet._init(true);
            DMNhanVienX.I.InitCtrl(PLNguoiLQ, true, true);            
            Phieu = DATimeInOut.Instance.LoadAll(ID);
            Uncategory.setEnterAsTab(this);
            btnDong.Image = FWImageDic.CLOSE_IMAGE16;
            btnSave.Image = FWImageDic.SAVE_IMAGE16;
            DATimeInOut.Instance.ChonLoaiDiTreVeSom(PLMulDT_VS, true, false); 
        }
        public frmDiTreVeSom() : this(-2, true) { }
        #endregion

        #region InitForm  
        private void frmHotroSupport_Load(object sender, EventArgs e)
        {
            PMSupport.SetTitle(this, Status);
            HelpXtraForm.SetFix(this);
            GUIValidation.SetMaxLength(new object[] { rtxNoi_dung, 200 });
            #region Init control             
            if (Phieu.NGAY_LAM_VIEC.ToString() != "01/01/0001 12:00:00 AM")
            {
                Ngay_lien_quan.DateTime = Phieu.NGAY_LAM_VIEC;               
                txtTG_GhiNhan.Text = Phieu.THOI_GIAN_GHI_NHAN.ToString();
                txtNguoiGhiNhan.Text = DAChiTietCongViec.Instance.GetTen_NV(Phieu.NGUOI_GHI_NHAN).Tables[0].Rows[0]["TEN_NV"].ToString();
                PLMulDT_VS._setSelectedIDs(new long[] {Phieu.LOAI_DI_TRE_VE_SOM});
            }
            else
            {
                txtTG_GhiNhan.Text = DABase.getDatabase().GetSystemCurrentDateTime().ToString("dd/MM/yyyy HH:mm");
                Ngay_lien_quan.DateTime = System.Convert.ToDateTime(txtTG_GhiNhan.Text);
                txtNguoiGhiNhan.Text = DAChiTietCongViec.Instance.GetTen_NV(FrameworkParams.currentUser.employee_id).Tables[0].Rows[0]["TEN_NV"].ToString();                               
            }            
            btnSave.Visible = IsAdd == null ? false : true;
            if(Phieu.NV_ID!=0)
                PLNguoiLQ._setSelectedID(Phieu.NV_ID);
            rtxNoi_dung.Text = Phieu.NOI_DUNG;
            if (Phieu.DUYET == null)
                Phieu.DUYET = "1";
            Duyet.SetDuyet(Phieu);
            CapNhat_TT.Text = Phieu.NGUOI_DUYET == 0 ? "" : DAChiTietCongViec.Instance.GetTen_NV(Phieu.NGUOI_DUYET).Tables[0].Rows[0]["TEN_NV"].ToString();
            #endregion
        }                
        #endregion             

        #region Xử lý nút 
        private void btnSave_Click(object sender, EventArgs e)   
        {
            Error.ClearErrors();
            #region Kiểm tra dữ liệu 
            if (!GUIValidation.ShowRequiredError(Error, new object[] 
            { PLNguoiLQ, "Người liên quan"})) return;
            if (PLMulDT_VS._getSelectedIDs().Length == 0) {
                Error.SetError(PLMulDT_VS, "Vui lòng chọn hình thức đi trễ về sớm!");                
            }            
            if (rtxNoi_dung.Text == string.Empty)
            {
                Error.SetError(rtxNoi_dung, "Vui lòng vào thông tin \"Nội dung\" !");
            }
            if (PLMulDT_VS._getSelectedIDs().Length == 0 || rtxNoi_dung.Text.Length == 0) return;
            if (IsAdd == false && PLMulDT_VS._getSelectedIDs().Length > 1)
            {
                Error.SetError(PLMulDT_VS, "Không cho phép chọn nhiều hơn 1 loại!");
                return;
            }
            #endregion

            #region Lưu dữ liệu             
            long[] SelectedID = PLMulDT_VS._getSelectedIDs();
            foreach (long item in SelectedID)
            {
                if (IsAdd == true) Phieu.ID = DABase.getDatabase().GetID("G_NGHIEP_VU");
                Phieu.LOAI_DI_TRE_VE_SOM = (int)item;
                GetData();
                if (DATimeInOut.Instance.CheckExistDT_VS(Phieu.NV_ID, Phieu.NGAY_LAM_VIEC, Phieu.LOAI_DI_TRE_VE_SOM) && IsAdd == true) {
                    PLMessageBox.ShowNotificationMessage("Loại đi trễ về sớm của nhân viên này đã có trong ngày!");
                    return;
                }
            }            
            if (DATimeInOut.Instance.UpdatePhieu(Phieu))
                this.Close();
            else
                PLMessageBox.ShowConfirmMessage("Lưu không thành công!");
            #endregion
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (PLMessageBox.ShowConfirmMessage("Bạn có muốn xóa thông tin đi sớm về trễ của nhân viên này?") == DialogResult.Yes)
            {
                DATimeInOut.Instance.Delete(_ID);
                this.Close();
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            if (IsAdd == null)
                this.Close();
            else
            {
                if (PLMessageBox.ShowConfirmMessage("Bạn có muốn đóng?") == DialogResult.Yes)
                    this.Close();
            }
        }                
        #endregion                                   

        #region Khác
        public void GetData()
        {
            try{           
            Phieu.NV_ID = PLNguoiLQ._getSelectedID();
            Phieu.NGAY_LAM_VIEC = System.Convert.ToDateTime(Ngay_lien_quan.EditValue);
            Phieu.NOI_DUNG = rtxNoi_dung.Text;            
            Phieu.NV_ID = PLNguoiLQ._getSelectedID();
            Phieu.THOI_GIAN_GHI_NHAN = System.Convert.ToDateTime(txtTG_GhiNhan.Text);
            Phieu.NGUOI_GHI_NHAN = FrameworkParams.currentUser.employee_id;            
            Phieu.LOAI = 3;
            DATimeInOut.Instance.Update(Phieu);            
            }
            catch(Exception ex){
                PLException.AddException(ex);             
            }            
        }
        #endregion
    }
}
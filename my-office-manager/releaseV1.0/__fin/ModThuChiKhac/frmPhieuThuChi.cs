using System;
using System.Windows.Forms;
using DAO;
using DevExpress.XtraEditors;
using DTO;
using office;
using ProtocolVN.Framework.Core;
using ProtocolVN.Framework.Win;
using ProtocolVN.DanhMuc;

using DevExpress.XtraEditors.DXErrorProvider;

namespace office
{
    public partial class frmPhieuThuChi : XtraFormPL
    {
        //Delegate cho việc refresh dữ liệu
        public delegate void RefreshDataQL();
        public RefreshDataQL RefreshData;
        //----------------------------------
        long PhieuID = 0;
        private bool? IsAdd = null;
        
        public frmPhieuThuChi(bool? isAdd,long id)
        {
            InitializeComponent();
            IsAdd = isAdd;
            PhieuID = id;
            this.errorProvider = new DXErrorProvider();
        }
        public frmPhieuThuChi(bool? isAdd) : this(true, -2) { }
        public frmPhieuThuChi() : this(true, -2) { }
        private void InitForm()
        {
            DMLoaiChiPhi.I.InitCtrl(Filter_LoaiChiPhi, true, true);
            DMNhanVienX.I.InitCtrl(Filter_NguoiLienQuan, true, true);
            radio_Thu_Chi.SelectedIndex = 0;
            btnSave.Image = FWImageDic.ADD_IMAGE20;
            btnDong.Image = FWImageDic.CLOSE_IMAGE20;
            //Format SoTien với 2 số thập phân sau dấu phẩy.
            ApplyFormatAction.applyElement(SoTien.Properties, 2);
            SoTien.Properties.Precision = 2;
            //----------------------
            if (IsAdd == null)
            {
                btnSave.Visible = false;
            }
            if (IsAdd == null || IsAdd == false)
            {
                DOPhieuThuChi Phieu = DAPhieuThuChi.GetPhieu(PhieuID);
                if (Phieu == null)
                    return;
                MaPhieu.Text = Phieu.MA_PHIEU.ToString();
                DonViLienQuan.Text = Phieu.DON_VI_LIEN_QUAN;
                Filter_LoaiChiPhi._setSelectedID(Phieu.LCP_ID);
                memo_DienGiaiChiPhi.Text = Phieu.DIEN_GIAI;
                if (Phieu.IS_THU_CHI == "Y")
                    radio_Thu_Chi.SelectedIndex = 0;
                else
                    radio_Thu_Chi.SelectedIndex = 1;
                SoTien.Value = Phieu.SO_TIEN;
                Filter_NguoiLienQuan._setSelectedID(Phieu.NV_ID);
                NgayPhatSinh.EditValue = Phieu.NGAY_PHAT_SINH;
            }
            //if (IsAdd == true)
            //    MaPhieu.Text = DAPhieuThuChi.TaoMaPhieu();
            MaPhieu.Enabled = false;
            this.btnDong.Image = FWImageDic.CLOSE_IMAGE16;
            btnSave.Image = FWImageDic.SAVE_IMAGE16;
            if (this.IsAdd == false)
            {
                this.radio_Thu_Chi.Enabled = false;
            }
        }
        
        private void frmPhieuThuChi_Load(object sender, EventArgs e)
        {
            InitForm();
            HelpXtraForm.SetFix(this);
            HelpXtraForm.SetCloseForm(this, btnDong, IsAdd);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            
            string LoaiPhieu = "Y";
            if (radio_Thu_Chi.SelectedIndex==0)
                LoaiPhieu = "Y";
            else
                LoaiPhieu = "N";

            DOPhieuThuChi Phieu = null;
            if (IsAdd==true)
            {
                if (IsValidate())
                {
                    Phieu = new DOPhieuThuChi(
                        (int)HelpDB.getDatabase().GetID("GEN_QL_THU_CHI_ID"),
                        //DAPhieuThuChi.TaoMaPhieu(),
                        DAPhieuThuChi.GetCodePhieu(LoaiPhieu=="Y"),
                        NgayPhatSinh.DateTime,
                        DateTime.Now,
                        FrameworkParams.currentUser.employee_id,
                        (int)Filter_NguoiLienQuan._getSelectedID(),
                        memo_DienGiaiChiPhi.Text,
                        LoaiPhieu,
                        SoTien.Value,
                        (int)Filter_LoaiChiPhi._getSelectedID(),
                        DonViLienQuan.Text
                    );
                    if (!DAPhieuThuChi.ChotPhieu(Phieu.NGAY_PHAT_SINH))
                    {
                        if (DAPhieuThuChi.Insert(Phieu))
                        {
                            PLGUIUtil.ClosePhieu(this, true);
                            if (RefreshData != null) RefreshData();
                        }
                        else {
                            XtraMessageBox.Show("Kỳ kinh doanh không hợp lệ\nBạn không thể thêm phiếu mới vào kỳ nhỏ hơn \"" + TKThongKeThuChi.GetMinKKD().ToString(PLConst.FORMAT_DATE_STRING) + "\"", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                        XtraMessageBox.Show("Kỳ kinh doanh đã chốt\nBạn không thể thêm phiếu mới vào kỳ này ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else //Sua
            {
                if (IsValidate())
                {
                    Phieu = new DOPhieuThuChi(
                        PhieuID,
                        DAPhieuThuChi.TaoMaPhieu(),
                        NgayPhatSinh.DateTime,
                        DateTime.Now,
                        FrameworkParams.currentUser.employee_id,
                        (int)Filter_NguoiLienQuan._getSelectedID(),
                        memo_DienGiaiChiPhi.Text,
                        LoaiPhieu,
                        SoTien.Value,
                        (int)Filter_LoaiChiPhi._getSelectedID(),
                        DonViLienQuan.Text
                    );
                    if (DAPhieuThuChi.ChotPhieu(Phieu.ID)!=1)
                    {
                        if (DAPhieuThuChi.Update(Phieu))
                            PLGUIUtil.ClosePhieu(this, true);
                    }
                    else
                    {
                        XtraMessageBox.Show("Kỳ kinh doanh đã chốt\nBạn không thể chỉnh sửa phiếu mới vào kỳ này ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
        }
        public DXErrorProvider errorProvider;
        private bool IsValidate()
        {
            this.errorProvider.ClearErrors();
            bool bFlag = true;
            if (Filter_NguoiLienQuan._getSelectedID() == -1)
            {
                this.Filter_NguoiLienQuan.SetError(this.errorProvider, "Người liên quan");
                bFlag = false;
            }
            if(Filter_LoaiChiPhi._getSelectedID() == -1){
                this.Filter_LoaiChiPhi.SetError(this.errorProvider, "Loại chi phí");
                bFlag = false;
            }
            bFlag = GUIValidation.ShowRequiredError(this.errorProvider,new object[]{
                this.NgayPhatSinh,"Ngày phát sinh",
                this.DonViLienQuan,"Đơn vị liên quan"
            });
            if (SoTien.Value < 1 || SoTien.Value > 99999999999999) //Max dưới db decimal 15
            {
                bFlag = false;
                errorProvider.SetError(SoTien, "Vui lòng nhập vào thông tin \"Số tiền\" từ 1 đến 99.999.999.999.999!");
            }
            return bFlag;
        }
    }
}
using System;
using System.Data;
using DAO;
using ProtocolVN.Framework.Core;
using ProtocolVN.Framework.Win;

using DevExpress.XtraEditors.DXErrorProvider;

namespace office
{
    public partial class frmNhatKyCongViec : XtraFormPL
    {
        #region biến toàn cục
        Int64 PCCV_ID;
        Int64 NV_ID;
        DXErrorProvider Error;
        public delegate void RefreshPhanCongCV();
        public RefreshPhanCongCV RefreshData;
        #endregion

        #region hàm khởi tạo
        public frmNhatKyCongViec(Int64 pccv_id)
        {
            InitializeComponent();
            this.PCCV_ID = pccv_id;
            this.NV_ID = FrameworkParams.currentUser.employee_id;
            Error = new DXErrorProvider();
            initForm();
        }
        #endregion

        #region khởi tạo thuộc tính ban đầu
        private void frmNhatKyCongViec_Load(object sender, EventArgs e)
        {
            HelpInputData.SetMaxLength(new object[] { memoGhiChu, 400 });
        }
        #endregion
        private void initForm()
        {
            DOPhanCongCongViec do_pccv = new DOPhanCongCongViec();
            do_pccv = DACongViec.LoadPCCV(PCCV_ID);
            txtNguoiCapNhat.Text = DACongViec.getNameNV(NV_ID);
            txtTenDuAn.Text = do_pccv.CONG_VIEC;
            txtThoiGianCapNhat.Text = HelpDB.getDatabase().GetSystemCurrentDateTime().ToString(PLConst.FORMAT_DATETIME_STRING);
            
        }
        #region xử lý nút
        private void buttonThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonLuu_Click(object sender, EventArgs e)
        {
            if (!HelpInputData.ShowRequiredError(Error, new object[] { memoGhiChu, "Nội dung" })) return;
            DONhatKyCongViec nhatKycongViec = new DONhatKyCongViec(HelpDB.getDatabase().GetID("GEN_ID_NHAT_KY"), PCCV_ID, NV_ID, HelpDB.getDatabase().GetSystemCurrentDateTime(), memoGhiChu.Text);
            if (DACongViec.luuNhatKyCongViec(nhatKycongViec))
            {
                if (RefreshData != null) RefreshData();
                this.Close();
            }
            else
                HelpMsgBox.ShowNotificationMessage("Lưu không thành công.");
        }
        #endregion      
    }
}




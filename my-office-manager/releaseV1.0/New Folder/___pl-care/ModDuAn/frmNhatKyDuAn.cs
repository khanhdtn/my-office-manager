using System;
using System.Data;
using DAO;
using ProtocolVN.Framework.Core;
using ProtocolVN.Framework.Win;

using DevExpress.XtraEditors.DXErrorProvider;
using DTO;

namespace office
{
    public partial class frmNhatKyDuAn : XtraFormPL
    {
        #region biến toàn cục
        Int64 DA_ID;
        Int64 NV_ID;
        DXErrorProvider Error;
        #endregion

        #region hàm khởi tạo
        public frmNhatKyDuAn(Int64 da_id)
        {
            InitializeComponent();
            this.DA_ID = da_id;
            this.NV_ID = FrameworkParams.currentUser.employee_id;
            Error = new DXErrorProvider();
            initForm();
        }

        #endregion

        #region khởi tạo thuộc tính ban đầu
        private void frmNhatKyDuAn_Load(object sender, EventArgs e)
        {
            HelpInputData.SetMaxLength(new object[] { memoGhiChu, 400 });
        }
        #endregion
        private void initForm()
        {
            string qr = "SELECT NAME FROM DU_AN WHERE ID=" + this.DA_ID + "";
            DataTable dt = HelpDB.getDatabase().LoadDataSet(qr).Tables[0];          
            txtNguoiCapNhat.Text = DACongViec.getNameNV(NV_ID);
            txtTenDuAn.Text = dt.Rows[0]["NAME"].ToString();
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
            DONhatKyDuAn nhatKyDA = new DONhatKyDuAn(HelpDB.getDatabase().GetID("GEN_ID_NHAT_KY"), DA_ID, NV_ID, HelpDB.getDatabase().GetSystemCurrentDateTime(), memoGhiChu.Text);
            if (DADuAn.luuNhatKyDA(nhatKyDA))
            {
                this.Close();
            }
            else
                HelpMsgBox.ShowNotificationMessage("Lưu thông tin không thành công!");
        }
        #endregion     
    }
}




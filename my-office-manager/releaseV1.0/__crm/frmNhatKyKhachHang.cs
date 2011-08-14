using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.DXErrorProvider;
using ProtocolVN.Framework.Win;
using DAO;
using DTO;
using ProtocolVN.Framework.Core;
using office;
using System.Data.Common;

namespace office
{
    public partial class frmNhatKyKhachHang : XtraFormPL
    {
        Int64 KH_ID;
        Int64 NV_ID;
        DXErrorProvider Error;
        public frmNhatKyKhachHang(Int64 kh_id)
        {
            InitializeComponent();
            this.KH_ID = kh_id;
            this.NV_ID = FrameworkParams.currentUser.employee_id;
            Error = new DXErrorProvider();
            initForm();
            HelpXtraForm.SetCloseForm(this, buttonThoat, null);
        }
        private void initForm()
        {
            string qr = "SELECT TEN_KHACH_HANG FROM KHACH_HANG WHERE KH_ID=" + this.KH_ID + "";
            DataTable dt = HelpDB.getDatabase().LoadDataSet(qr).Tables[0];
            txtNguoiCapNhat.Text = DACongViec.getNameNV(NV_ID);
            txtTenDuAn.Text = dt.Rows[0]["TEN_KHACH_HANG"].ToString();
            txtThoiGianCapNhat.Text = HelpDB.getDatabase().GetSystemCurrentDateTime().ToString(PLConst.FORMAT_DATETIME_STRING);

        }
        private void buttonLuu_Click(object sender, EventArgs e)
        {
            bool kq = false;
            if (!HelpInputData.ShowRequiredError(Error, new object[] { memoGhiChu, "Nội dung" })) return;

            string str = "INSERT INTO NHAT_KY_KH_DA_CV(ID,KH_ID,MA_NV,GHI_CHU,THOI_GIAN_CAP_NHAT) values" +
                                                                   "(" +
                                                                 "@ID," +
                                                                 "@KH_ID," +
                                                                 "@MANV," +
                                                                 "@GHI_CHU," +
                                                                 "@THOI_GIAN_CAP_NHAT" +
                                                               ")";
            DatabaseFB db = HelpDB.getDatabase();
            DbTransaction tran = db.BeginTransaction(db.OpenConnection());
            try
            {
                DbCommand cmd = db.GetSQLStringCommand(str);
                db.AddInParameter(cmd, "@ID", DbType.Int64, HelpDB.getDatabase().GetID("GEN_ID_NHAT_KY"));
                db.AddInParameter(cmd, "@KH_ID", DbType.Int64, KH_ID);
                db.AddInParameter(cmd, "@MANV", DbType.Int64, NV_ID);
                db.AddInParameter(cmd, "@THOI_GIAN_CAP_NHAT", DbType.DateTime, HelpDB.getDatabase().GetSystemCurrentDateTime());
                db.AddInParameter(cmd, "GHI_CHU", DbType.String, memoGhiChu.Text);
                db.ExecuteNonQuery(cmd, tran);
                kq = true;
            }
            catch (Exception ex)
            {
                PLException.AddException(ex);
                tran.Rollback();
                kq = false;
            }
            finally
            {
                tran.Commit();
            }

            this.Close();
            if (!kq)
            {
                HelpMsgBox.ShowNotificationMessage("Lưu thông tin không thành công!");
            }
        }
    }
}
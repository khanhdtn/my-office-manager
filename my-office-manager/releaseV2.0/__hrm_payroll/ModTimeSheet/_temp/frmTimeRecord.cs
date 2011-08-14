using System;
using System.Data;
using System.Windows.Forms;
using ProtocolVN.Framework.Core;
using ProtocolVN.Framework.Win;
using pl.office;
namespace ProtocolVN.Plugin.TimeSheet
{
    
    public partial class frmTimeRecord : XtraFormPL
    {
        private bool test = false;

        public frmTimeRecord()
        {
            InitializeComponent();
            HelpXtraForm.SetFix(this);
            HelpXtraForm.SetCloseForm(this, btnClose, true);
        }

        #region Xử lý database
        public static void loadduan(PLCombobox input)
        {

            string sql = "select * from DU_AN";
            DataSet ds = HelpDB.getDatabase().LoadDataSet(sql);
            input.DataSource = ds.Tables[0];
            input.DisplayField = "name";
            input.ValueField = "ID";
            input._setSelectedID(-1);
            input._init();

        }
        public static long ID_LDA(long ID)
        {
            string sql = "select LOAI_DU_AN from DU_AN where ID="+ID;
            DataSet ds = new DataSet();
            DatabaseFB db = HelpDB.getDatabase();
            ds = db.LoadDataSet(sql, "DA");
            if (ds.Tables[0].Rows.Count > 0)
                return HelpNumber.ParseInt64(ds.Tables[0].Rows[0]["LOAI_DU_AN"].ToString());
            else
                return -1;

        }
        public static void loadcongviec(PLCombobox input,long id)
        {

            string sql = "select * from cong_viec where loai_du_an="+id;
            DataSet ds = HelpDB.getDatabase().LoadDataSet(sql);
            input.DataSource = ds.Tables[0];
            input.DisplayField = "NAME";
            input.ValueField = "ID";
            input._setSelectedID(-1);
            input._init();

        }
        public static long GetNVID(long usercat)
        {
            string sql = "select EMPLOYEE_ID from USER_CAT where USERID=" + usercat;
            DataSet ds = new DataSet();
            DatabaseFB db = HelpDB.getDatabase();
            System.Data.Common.DbCommand cmd = db.GetSQLStringCommand(sql);
            db.LoadDataSet(cmd, ds, "USER");
            if (ds.Tables[0].Rows.Count > 0)
                return HelpNumber.ParseInt64(ds.Tables[0].Rows[0][0].ToString());
            else
                return -1;
        }
        public static DataSet GetData(DateTime ngaylamviec, long nv_id)
        {
            DataSet ds = new DataSet();
            string sql = "select CTCCV_ID,DA_ID,CV_ID,NV_ID,MO_TA,BAT_DAU,KET_THUC,THOI_GIAN_THUC_HIEN,NGAY_LAM_VIEC,NGAY_CAP_NHAT,DUYET  from CHI_TIET_CONG_VIEC where NGAY_LAM_VIEC='" + ngaylamviec.ToString("MM/dd/yyyy") + "'and NV_ID=" + nv_id;
            DatabaseFB db = HelpDB.getDatabase();
            System.Data.Common.DbCommand cmd = db.GetSQLStringCommand(sql);
            db.LoadDataSet(cmd, ds, "CTCV");
            return ds;
        }
        public static void themchitietcv(long id_da, long id_cv, long id_user, string mota, DateTime batdau, DateTime ketthuc, string thoigianthuchien)
        {
            string sql = "insert into chi_tiet_cong_viec (ctccv_id,da_id, cv_id, nv_id,mo_ta,bat_dau,ket_thuc,thoi_gian_thuc_hien,ngay_lam_viec,ngay_cap_nhat,duyet,nguoi_cap_nhat ) values(@ctccv_id,@id_da, @id_cv, @id_user, @mo_ta, @bat_dau, @ket_thuc, @thoi_gian_thuc_hien,@ngay_lam_viec,@ngay_cap_nhat,@duyet,@nguoi_cap_nhat)";
            DatabaseFB db = HelpDB.getDatabase();
            
            System.Data.Common.DbCommand insert = db.GetSQLStringCommand(sql);
            db.AddInParameter(insert, "@ctccv_id", DbType.UInt64, HelpDB.getDatabase().GetID("G_NGHIEP_VU"));
            db.AddInParameter(insert, "@id_da", DbType.UInt64, id_da);
            db.AddInParameter(insert, "@id_cv", DbType.UInt64, id_cv);
            db.AddInParameter(insert, "@id_user", DbType.UInt64, id_user);
            db.AddInParameter(insert, "@mo_ta", DbType.String, mota);
            db.AddInParameter(insert, "@bat_dau", DbType.DateTime, batdau);
            db.AddInParameter(insert, "@ket_thuc", DbType.DateTime, ketthuc);
            db.AddInParameter(insert, "@thoi_gian_thuc_hien", DbType.String, thoigianthuchien);
            db.AddInParameter(insert,"@ngay_lam_viec",DbType.DateTime,HelpDB.getDatabase().GetSystemCurrentDateTime());
            db.AddInParameter(insert, "@ngay_cap_nhat", DbType.DateTime, HelpDB.getDatabase().GetSystemCurrentDateTime());
            db.AddInParameter(insert, "@duyet", DbType.String,"1");
            db.AddInParameter(insert, "@nguoi_cap_nhat", DbType.UInt64, GetNVID(HelpNumber.ParseInt64(FrameworkParams.currentUser.id)));
            db.ExecuteNonQuery(insert);
        }
        #endregion
        private void frmDemo_Load(object sender, EventArgs e)
        {
            

            loadduan(PLcbdu_an);
            if (PLcbdu_an._getSelectedID() != -1)
            {
                loadcongviec(Plcb_congviec,ID_LDA(PLcbdu_an._getSelectedID()));
            }
            icontimesheet.DoubleClick += new EventHandler(icontimesheet_DoubleClick);
            new frmTimeRecord().Text ="Time Sheet của " + HelpDB.getDatabase().LoadDataSet("select nv.name from user_cat u,dm_nhan_vien nv where u.employee_id=nv.id and u.userid="+FrameworkParams.currentUser.id);
        }
        #region Xử lý sự kiện và Nút
        void icontimesheet_DoubleClick(object sender, EventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
            //frmDemo.
        }
        int i = 0;
        DateTime bd;
        DateTime tgth;
        private void gio_Tick(object sender, EventArgs e)
        {
            i++;
            int h = 0, m = 0, s = 0;
            h = i / 3600;
            m = (i - h * 3600) / 60;
            s = i - h * 3600 - m * 60;
            lblTime.Text = h < 10 ? "0" + h.ToString() : h.ToString();
            lblTime.Text += ":";
            lblTime.Text += m < 10 ? "0" + m.ToString() : m.ToString();
            lblTime.Text += ":";
            lblTime.Text += s < 10 ? "0" + s.ToString() : s.ToString();
        }
        private void btnBatDau_Click_1(object sender, EventArgs e)
        {
            if (Plcb_congviec._getSelectedID() > -1 && PLcbdu_an._getSelectedID() > -1 && memoEdit1.Text != "")
            {
                gio.Start();
                bd = HelpDB.getDatabase().GetSystemCurrentDateTime();
                btnKetThuc.Enabled = true;
            }
            else
            {
                HelpMsgBox.ShowNotificationMessage("Vui lòng nhập vào đầy đủ thông tin trước khi bắt đầu thực hiện công việc.");
            }
        }
        private void btnKetThuc_Click_1(object sender, EventArgs e)
        {
            DataSet ds = GetData(HelpDB.getDatabase().GetSystemCurrentDateTime(), GetNVID(HelpNumber.ParseInt64(FrameworkParams.currentUser.id)));
            bool flag = true;
            foreach (DataRow r in ds.Tables[0].Rows)
            {
                if (r["DUYET"].ToString() == "2")
                    flag = false;
            }
            if (flag == true)
            {
                gio.Stop();
                i = 0;
                //Luu
                themchitietcv(HelpNumber.ParseInt64(PLcbdu_an._getSelectedID().ToString()), HelpNumber.ParseInt64(Plcb_congviec._getSelectedID().ToString()), GetNVID(HelpNumber.ParseInt64(FrameworkParams.currentUser.id)), memoEdit1.Text, bd, HelpDB.getDatabase().GetSystemCurrentDateTime(), lblTime.Text);
                HelpMsgBox.ShowNotificationMessage("Đã lưu TimeSheet thành công!");
                // Controls
                btnBatDau.Enabled = true;
                btnKetThuc.Enabled = false;
                memoEdit1.Text = "";
                PLcbdu_an._setSelectedID(-1);
                Plcb_congviec._setSelectedID(-1);
                Plcb_congviec.Enabled = true;
                PLcbdu_an.Enabled = true;
                memoEdit1.Enabled = true;
                lblTime.Text = "00:00:00";
                icontimesheet.Visible = false;
            }
            else
            {
                HelpMsgBox.ShowNotificationMessage("Lưu không thành công.Công việc của bạn đã được duyệt!");
                gio.Stop();
                i = 0;
                btnBatDau.Enabled = true;
                btnKetThuc.Enabled = false;
                memoEdit1.Text = "";
                PLcbdu_an._setSelectedID(-1);
                Plcb_congviec._setSelectedID(-1);
                Plcb_congviec.Enabled = true;
                PLcbdu_an.Enabled = true;
                memoEdit1.Enabled = true;
                lblTime.Text = "00:00:00";
                icontimesheet.Visible = false;
            }
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Hide();
            icontimesheet.Visible = true;
        }
       
        private void frmDemo_FormClosing(object sender, FormClosingEventArgs e)
        {   
        }
        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
            icontimesheet.Visible = true;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (HelpMsgBox.ShowConfirmMessage("Bạn có chắc muốn đóng?") == DialogResult.Yes)
            {
                icontimesheet.Visible = false;
                this.Close();  
            }  
        }
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Hide();
            icontimesheet.Visible = true;
        }
        private void PLcbdu_an_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (PLcbdu_an._getSelectedID() != -1)
            {
                loadcongviec(Plcb_congviec, ID_LDA(PLcbdu_an._getSelectedID()));
            }
        } 
        #endregion
    }
}
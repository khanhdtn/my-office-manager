using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ProtocolVN.Framework.Core;
using ProtocolVN.Framework.Win;


namespace pl.khachhang.form
{
    public partial class frmUser : DevExpress.XtraEditors.XtraForm
    {
        public frmUser()
        {
            InitializeComponent();
        }
        #region 1. Kiểm tra trên LDAP 
        public bool KiemTraDangNhapTrenLDAP(string user, string pass,string pathLDAP)
        {
            return HelpLDAP.Verify(user, pass,pathLDAP);
        }
        #endregion 

        #region 2. Nếu OK -> Kiểm tra trên DB 
        
        // Kiểm tra User có tồn tại trong bảng USER_CAT hay không ?, nếu có trả về EMPLOYEE_ID tương ứng
        public long KiemTraUserTrongDBUSerCat(string user)
        {
            long blResult = -1;
            string query = "Select * from USER_CAT where USERNAME ='"+user+"'";
            DataTable dttUSER_CAT = DABase.getDatabase().LoadDataSet(query).Tables[0];
            if (dttUSER_CAT.Rows.Count > 0)
            {
                foreach (DataRow dtr in dttUSER_CAT.Rows)
                {
                    try
                    {
                        blResult = long.Parse(dtr["EMPLOYEE_ID"].ToString());
                        break;
                    }
                    catch (Exception) { };
                }
            }
            else { };            
            return blResult;
        }
        public bool KiemTraUserTrongBangDBNhanVien(long id)
        {
            bool blResult = false;
            string query = "Select * from DM_NHAN_VIEN where ID =" + id.ToString();
            DataTable dttUSER_CAT = DABase.getDatabase().LoadDataSet(query).Tables[0];
            if (dttUSER_CAT.Rows.Count > 0)
            {
                blResult = true;
            }
            else { };
            return blResult;
        }
        #endregion 

        #region 3. Nếu trong DB có thì Update lại thông tin -2 bảng USET_CAT và DM_NHAN_VIEN
        
        // --------Bảng USER_CAT chỉ update Column LASTACCESS
        public bool UpdateUserTrongDBUserCat(string username)
        {
            bool blReSult = false;
            DateTime dttLastAccess = DateTime.Now;
            string sql = "update USER_CAT set LASTACCESS = @LASTACCESS where USERNAME = @USERNAME";
            DatabaseFB db = DABase.getDatabase();
            DbCommand cmd = db.GetSQLStringCommand(sql);
            db.AddInParameter(cmd, "@LASTACCESS", DbType.DateTime,dttLastAccess);
            db.AddInParameter(cmd, "@USERNAME", DbType.String,username);
            if (db.ExecuteNonQuery(cmd) > 0)
            {
                blReSult = true;
            }
            return blReSult;
        }
        public bool UpdateUserTrongDBNhanVien(long id, string tenNhanVien, string email)
        {
            bool blReSult = false;
            DateTime dttLastAccess = DateTime.Now;
            string sql = "update DM_NHAN_VIEN set TEN_NV = @TEN_NV, EMAIL = @EMAIL where ID = @ID";
            DatabaseFB db = DABase.getDatabase();
            DbCommand cmd = db.GetSQLStringCommand(sql);
            db.AddInParameter(cmd, "@TEN_NV", DbType.String, tenNhanVien);
            db.AddInParameter(cmd, "@EMAIL", DbType.String, email);
            db.AddInParameter(cmd, "@ID", DbType.Int64, id);
            if (db.ExecuteNonQuery(cmd) > 0)
            {
                blReSult = true;
            }
            return blReSult;
        }
        #endregion 

        #region 4. Nếu trong DB không có thì thêm vào DB - Thêm vào 2 bảng USER_CAT và DM_NHAN_VIEN
        public long ThemUserTrongDBNhanVien(string name, string email)
        {
            long blResult = -1;
            DatabaseFB db = DABase.getDatabase();
            DbTransaction dbTrans = db.BeginTransaction(db.OpenConnection());
            long getIDUser = DABase.getDatabase().GetID("G_NHAN_VIEN");
            string strsql = "Insert into DM_NHAN_VIEN(ID,TEN_NV,EMAIL) values(@ID,@NAME,@EMAIL)";
            DbCommand cmdLuuKhachHang = db.GetSQLStringCommand(strsql);
            db.AddInParameter(cmdLuuKhachHang, "@ID", DbType.Int64, getIDUser);
            db.AddInParameter(cmdLuuKhachHang, "@NAME", DbType.String, name);
            db.AddInParameter(cmdLuuKhachHang, "@EMAIL", DbType.String, email);
            if (db.ExecuteNonQuery(cmdLuuKhachHang, dbTrans) > 0)
            {
                db.CommitTransaction(dbTrans);
                blResult = getIDUser;
            }
            else { };
            return blResult;
        }
        public long ThemUserTrongDBNhanVien(long id, string name, string email)
        {
            long blResult = -1;
            DatabaseFB db = DABase.getDatabase();
            DbTransaction dbTrans = db.BeginTransaction(db.OpenConnection());
            long getIDUser = id;
            string strsql = "Insert into DM_NHAN_VIEN(ID,TEN_NV,EMAIL) values(@ID,@NAME,@EMAIL)";
            DbCommand cmdLuuKhachHang = db.GetSQLStringCommand(strsql);
            db.AddInParameter(cmdLuuKhachHang, "@ID", DbType.Int64, getIDUser);
            db.AddInParameter(cmdLuuKhachHang, "@NAME", DbType.String, name);
            db.AddInParameter(cmdLuuKhachHang, "@EMAIL", DbType.String, email);
            if (db.ExecuteNonQuery(cmdLuuKhachHang, dbTrans) > 0)
            {
                db.CommitTransaction(dbTrans);
                blResult = getIDUser;
            }
            else { };
            return blResult;
        }
        // Nếu User đó chưa có thì thêm vào bảng USER_CAT - trả về true nếu thành công
        public bool ThemUserTrongDBUserCat(string user, string pass, long employee_ID)
        {
            bool blResult = false;
            DateTime lastAccess = DateTime.Now;
            DatabaseFB db = DABase.getDatabase();
            DbTransaction dbTrans = db.BeginTransaction(db.OpenConnection());
            long getIDUser = DABase.getDatabase().GetID("G_USER_CAT");
            string strsql = "Insert into USER_CAT(USERID,USERNAME,PWD,LASTACCESS,ISCHANGEPWD_BIT,ISACTIVE_BIT,EMPLOYEE_ID) values(@USERID,@USERNAME,@PWD,@LASTACCESS,@ISCHANGEPWD_BIT,@ISACTIVE_BIT,@EMPLOYEE_ID)";
            DbCommand cmdLuuKhachHang = db.GetSQLStringCommand(strsql);
            db.AddInParameter(cmdLuuKhachHang, "@USERID", DbType.Int64, getIDUser);
            db.AddInParameter(cmdLuuKhachHang, "@USERNAME", DbType.String, user);
            db.AddInParameter(cmdLuuKhachHang, "@PWD", DbType.String,pass);
            db.AddInParameter(cmdLuuKhachHang, "@LASTACCESS", DbType.DateTime, lastAccess);
            db.AddInParameter(cmdLuuKhachHang, "@ISCHANGEPWD_BIT", DbType.String, "Y");
            db.AddInParameter(cmdLuuKhachHang, "@ISACTIVE_BIT", DbType.String, "Y");
            db.AddInParameter(cmdLuuKhachHang, "@EMPLOYEE_ID", DbType.String, employee_ID);
            if (db.ExecuteNonQuery(cmdLuuKhachHang, dbTrans) > 0)
            {
                db.CommitTransaction(dbTrans);
                blResult = true;
            }
            else { };
            return blResult;
        }
        #endregion 
        
        #region Xử lý các sự kiện nút
        private void btDangNhap_Click(object sender, EventArgs e)
        {
            string strUser = "";
            string strPass = "";
            strUser = txtTenDangNhap.Text;
            strPass = txtPassword.Text;
            HelpLDAP.Login(strUser, strPass, @"LDAP://protocolvn.info");
            return;

            bool IsVeryfy = false;
            if (!(strUser.Equals("") || strPass.Equals("")))
            {
                // Kiểm tra trên LDAP
                IsVeryfy = KiemTraDangNhapTrenLDAP(strUser, strPass,"");
            }
            else { return; }
            // Nếu có thì Kiểm Tra trên DB
            if (IsVeryfy == true)
            {
                long longKiemTraTrenDB = -1;
                longKiemTraTrenDB = KiemTraUserTrongDBUSerCat(strUser);
                string fullName = HelpLDAP.getInfo(strUser, strPass,"", "CN");
                string email = HelpLDAP.getInfo(strUser, strPass,"", "mail");
                // Nếu không có thì chèn trong bảng DM_NHAN_VIEN và USER_CAT 
                if (longKiemTraTrenDB == -1)
                {
                    // Chèn trong bảng DM_NHAN_VIEN trước 
                    long longIDNhanVien = -1;
                    longIDNhanVien =  ThemUserTrongDBNhanVien(fullName, email);
                    // Nếu thêm thnahf công thì thêm tiếp bên USER_CAT
                    if (longIDNhanVien != -1)
                    {
                        ThemUserTrongDBUserCat(strUser, strPass, longIDNhanVien);
                    }
                    else { };
                }
                // Nếu có cập nhật bên 2 bảng USER_CAT
                else 
                {
                    UpdateUserTrongDBUserCat(strUser);
                    // Kiểm Tra bên DM_NHAN_VIEN có nhân viên hay không,nếu không có thì thêm, có rồi thì cập nhập
                    if (KiemTraUserTrongBangDBNhanVien(longKiemTraTrenDB))
                    {
                        UpdateUserTrongDBNhanVien(longKiemTraTrenDB, fullName, email);
                    }
                    else
                    {
                        ThemUserTrongDBNhanVien(longKiemTraTrenDB,fullName, email);
                    }
                }
            }
        }  
        #endregion 
    }
}
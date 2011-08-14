using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ProtocolVN.Framework.Win;
using ProtocolVN.DanhMuc;
using ProtocolVN.Framework.Core;
using System.Data.Common;
using DevExpress.XtraEditors.DXErrorProvider;
 

namespace ProtocolVN.Framework.Win
{
    public partial class frmBroadCast :XtraFormPL
    {
        public static string MenuItem(string ParentID, bool IsSep)
        {
            return MenuBuilder.CreateItem(typeof(frmBroadCast).FullName,
                "Gửi thông báo nội bộ",
                ParentID, true,
                typeof(frmBroadCast).FullName,
                false, IsSep, "broadcast.png", true, "", "");
        }
        private DXErrorProvider Error;
        public frmBroadCast()
        {
            InitializeComponent();
            Init();
            InitData();
            NgayNhap.Text = HelpDB.getDatabase().GetSystemCurrentDateTime().ToString(FrameworkParams.option.DateTimeFomat);
        }
        void Init()
        {                       
            this.Error = HelpInputData.GetErrorProvider(this);
            HelpInputData.SetMaxLength(
                new object[]{
                    ChuDe, 200
                }
            );

          
        }
        void InitData()
        {
            ProtocolVN.App.Office.AppCtrl.InitTreeChonNhanVien(pldmTreeMultiChoice1, true,false);
            pldmTreeMultiChoice1.treeList.OptionsView.ShowColumns = false;
            NguoiNhap.Text = DMFWNhanVien.GetFullName(FrameworkParams.currentUser.employee_id);
        }
      
        private bool ValidateOnForm()
        {
            bool flag = true;
            Error.ClearErrors();
            flag = HelpInputData.ShowRequiredError(Error,
                    new object[]{                       
                        ChuDe, "Chủ đề",                                           
                    }
                );
            if (flag && NoiDung.Text.Trim()=="")
            {
                Error.SetError(NoiDung, "Vui lòng nhập nội dung!");
                flag = false;
            }
            if (pldmTreeMultiChoice1._CountSelectedIDs == 0)
            {
                pldmTreeMultiChoice1._SetError(Error, "Vui lòng chọn người nhận!");
                flag = false;
            }
            if (flag == false)
            {
                HelpMsgBox.ShowErrorMessage("Dữ liệu nhập không hợp lệ. Vui lòng nhập lại theo hướng dẫn.");
                return flag;
            }
            return flag;
        }
        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (ValidateOnForm())
            {
                if (!SaveBroadCast())
                {
                    HelpMsgBox.ShowNotificationMessage("Lưu thông báo không thành công");
                }
                else this.Close();
            }
        }
        bool SaveBroadCast()
        {
            try
            {
                FWDBService db = HelpDB.getDBService();
                long ID = db.GetID("G_FW_ID");
                string str = @"insert into FW_BROADCAST 
                           values(@id,@nguoi_nhap,@ngay_nhap,@chu_de,@noi_dung,@NKCB,@nguoi_nhan) ";
                DbCommand cmd = db.GetSQLStringCommand(str);
                db.AddInParameter(cmd, "@ID", DbType.Int64, ID);
                db.AddInParameter(cmd, "@NGUOI_NHAP", DbType.Int64, FrameworkParams.currentUser.employee_id);
                db.AddInParameter(cmd, "@NGAY_NHAP", DbType.DateTime, HelpDB.getDatabase().GetSystemCurrentDateTime());
                db.AddInParameter(cmd, "@CHU_DE", DbType.String, ChuDe.Text);
                db.AddInParameter(cmd, "@NOI_DUNG", DbType.Binary, HelpByte.UTF8StringToBytes(NoiDung.Text));
                db.AddInParameter(cmd, "@NKCB", DbType.String, "-1");
                db.AddInParameter(cmd, "@NGUOI_NHAN", DbType.String, pldmTreeMultiChoice1._SelectedStrIDs);
                if (db.ExecuteNonQuery(cmd) > 0) return true;
                else return false;
            }
            catch { return false; }
        }
    }   
}
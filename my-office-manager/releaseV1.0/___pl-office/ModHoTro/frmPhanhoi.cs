using System;
using System.Data;
using System.Windows.Forms;
using ProtocolVN.Framework.Win;
using ProtocolVN.Framework.Core;
using DAO;

using System.Collections.Generic;
using ProtocolVN.DanhMuc;
using ProtocolVN.App.Office;
using LumiSoft.Net.Mime;
using System.Text;
using System.Data.Common;
namespace office
{
    public partial class frmPhanhoi : XtraFormPL
    {
        #region Vùng đặt Static
        //TRANGDTT NC Chưa thực hiện phần gửi mail phần này FW sẽ hỗ trợ 
        //PHUOCNT NC Anh P làm phần dùm em phần gửi mail
        public static FormStatus Status = FormStatus.NO_USE;
        public static string MenuItem(string ParentID, bool IsSep)
        {
            return MenuBuilder.CreateItem(typeof(frmPhanhoi).FullName,
                PMSupport.UpdateTitle("Phản hồi yêu cầu hỗ trợ", Status),
                ParentID, true,
                typeof(frmPhanhoi).FullName,
                false, IsSep, "mnbCHinhHeThong.png", true, "", "");
        }
        #endregion

        #region Các khai báo biến 
        private long _YEU_CAU_ID;
        private long _NGUOI_GUI_ID;
        private long _NGUOI_NHAN_ID;
        private long _TINH_TRANG;
        private DateTime _NGAY_GUI;
        private bool? _IsAdd;
        public delegate void gridViewPhanhoiUpdateHandler(object sender, DOPhanHoi e);
        public event gridViewPhanhoiUpdateHandler gridViewUpdate;
        #endregion
        
        #region Hàm dựng 
        
            public frmPhanhoi()
            {
                InitializeComponent();
            }

            /// <summary>
            /// Gọi frmPhanhoi khi thêm mới.
            /// </summary>
            public frmPhanhoi(long YeuCauId,long NguoiGuiId, long NguoiNhanId, long tinhTrang)
            {
                InitializeComponent();
                this._YEU_CAU_ID = YeuCauId;
                this._NGUOI_NHAN_ID = NguoiNhanId;
                this._NGUOI_GUI_ID = NguoiGuiId;
                this._TINH_TRANG = tinhTrang;
                this._IsAdd = true;
                if (NguoiGuiId > 0)
                    Nguoi_gui.Text = DMFWNhanVien.GetFullName(NguoiGuiId);
                else
                    Nguoi_gui.Text = string.Empty;
                Ngay_gui.Text = HelpDB.getDatabase().GetSystemCurrentDateTime().ToString(PLConst.FORMAT_DATETIME_STRING);
            }

            /// <summary>
            /// Gọi frmPhanhoi khi sửa hoặc xóa.
            /// </summary>
            public frmPhanhoi(long IdYeuCau, long NguoiGuiId, long NguoiNhanId, DateTime NgayGui,long tinhTrang)
            {
                InitializeComponent();
                this._YEU_CAU_ID = IdYeuCau;
                this._NGUOI_GUI_ID = NguoiGuiId;
                this._NGUOI_NHAN_ID = NguoiNhanId;
                this._NGAY_GUI = NgayGui;
                this._TINH_TRANG = tinhTrang;
                this._IsAdd = false;
                Nguoi_gui.Text = DMFWNhanVien.GetFullName(_NGUOI_GUI_ID);
                Ngay_gui.Text = NgayGui.ToString(PLConst.FORMAT_DATETIME_STRING);
                this.NoiDung._setValue(DAPhanHoi.getYeuCauTraLoi(IdYeuCau, this._NGUOI_GUI_ID, NgayGui));
            }

        #endregion

        #region InitForm 
        private void frmPhanhoi_Load(object sender, EventArgs e)
        {
            HelpDebug.SetTitle(this, Status); 
            HelpXtraForm.SetFix(this);
            HelpDanhMuc.ChonTinhTrangXuLy(PLTinhtrang);
            PLTinhtrang._setSelectedID(this._TINH_TRANG);
            nguoiNhanMail.CreateDataset(0, _NGUOI_GUI_ID, _NGUOI_NHAN_ID);
            PLGUIUtil.Customizebar_PLRichTextBox(NoiDung);
        }
        #endregion
       
        #region Xử lý nút 
           
            private void btnClose_Click(object sender, EventArgs e)
            {
                this.Close();
            }

            private void btnLuu_Click(object sender, EventArgs e)
            {
//                #region NoUsing
//                bool Result=true;
//                List<long> lstUser = new List<long>();
//                DataTable dt = new DataTable();
//                dt = ((DataTable)nguoiNhanMail.gridControlNguoiTheoDoi.DataSource).Copy();
//                foreach (DataRow item in dt.Rows)
//                {
//                    if (item["CHON"].ToString() == "Y")
//                        lstUser.Add(HelpNumber.ParseInt64(item["ID"]));
//                }
//                if (NoiDung._getValue().Length > 0)
//                {
//                    if (_IsAdd == true)
//                    {
//                        DOPhanHoi doPhanhoi = new DOPhanHoi(this._YEU_CAU_ID, this._NGUOI_GUI_ID, DAPhanHoi.getEmailNhanVien(FrameworkParams.currentUser.employee_id)["EMAIL"].ToString(), this._NGUOI_NHAN_ID, DAPhanHoi.getEmailNhanVien(this._NGUOI_NHAN_ID)["EMAIL"].ToString(), DABase.getDatabase().GetSystemCurrentDateTime(),NoiDung._getValue(), lstUser.Count > 0 ? "Y" : "N", FrameworkParams.currentUser.employee_id, System.Convert.ToDateTime(Ngay_gui.Text));
//                        if (!DAPhanHoi.Insert(doPhanhoi))
//                        {
//                            HelpMsgBox.ShowErrorMessage("Không lưu được phản hồi này!");
//                            Result=false;
//                        }
//                        else
//                        {                            
//                                this.gridViewUpdate(this, doPhanhoi);                         
//                                this.btnClose_Click(sender, e);                        
//                        }
//                    }
//                    else if (_IsAdd == false)
//                    {
//                        DOPhanHoi doPhanHoi = new DOPhanHoi(this._YEU_CAU_ID, this._NGUOI_GUI_ID, DAPhanHoi.getEmailNhanVien(this._NGUOI_GUI_ID)["EMAIL"].ToString(), this._NGUOI_NHAN_ID, DAPhanHoi.getEmailNhanVien(this._NGUOI_NHAN_ID)["EMAIL"].ToString(), this._NGAY_GUI, NoiDung._getValue(), lstUser.Count > 0 ? "Y" : "N", FrameworkParams.currentUser.employee_id, System.Convert.ToDateTime(Ngay_gui.Text));
//                        if (!DAPhanHoi.Update(doPhanHoi))
//                        {
//                            HelpMsgBox.ShowErrorMessage("Không cập nhật được phản hồi này!");                                   
//                            Result=false;
//                        }                        
//                        else
//                        {
//                            this.gridViewUpdate(this, doPhanHoi);
//                            this.btnClose_Click(sender, e);
//                        }
//                    }
//                    if(Result)
//                    {
//                        //Gửi mail
                        
//                        if (lstUser.Count > 0)
//                        {
//                            AddressList To = new AddressList();
//                            string title = "Có phản hồi yêu cầu hỗ trợ mới được cập nhật";
//                            title = HelpStringBuilder.GetTitleMailNewPageper(title);
//                            StringBuilder Subject = new StringBuilder();
//                            DataSet ds = DABase.getDatabase().LoadDataSet(string.Format("SELECT * FROM YEU_CAU WHERE ID = {0}",_YEU_CAU_ID));
//                            if(ds == null || ds.Tables[0].Rows.Count == 0) return;
//                            IDataReader reader = FWDBService.LoadRecord("DM_LOAI_YEU_CAU", "ID", HelpNumber.ParseInt64(ds.Tables[0].Rows[0]["LOAI_YEU_CAU_ID"]));
//                            using (reader)
//                            {
//                                if (reader.Read())
//                                {
//                                    Subject.Append(string.Format(PLConst.DES_MAIL_YCHT_PH, ds.Tables[0].Rows[0]["CHU_DE"].ToString(), reader["NAME"].ToString(),Nguoi_gui.Text, HelpByte.BytesToUTF8String(NoiDung._getValue())));
//                                }
//                            }
//                            To = HelpZPLOEmail.GetAddressList(lstUser.ToArray());
//                            HelpZPLOEmail.SendSmartHost(title, null, To, null, null, Subject.ToString(), "");
//                        }
//                        //-----------------------------------------
//                        //Cập nhật lại tình trạng của yêu cầu hỗ trợ nếu có thay đổi
//                        DatabaseFB db = HelpDB.getDatabase();
//                        string SQL = string.Format(@"UPDATE YEU_CAU
//                                         SET    TINH_TRANG = @TINH_TRANG
//                                        WHERE   ID = {0}", _YEU_CAU_ID);
//                        DbCommand cmd = db.GetSQLStringCommand(SQL);
//                        db.AddInParameter(cmd, "@TINH_TRANG", DbType.Int64, PLTinhtrang._getSelectedID());
//                        try
//                        {
//                            db.ExecuteNonQuery(cmd);
//                        }
//                        catch (Exception ex)
//                        {
//                            PLException.AddException(ex);
//                            HelpSysLog.AddException(ex, "Cập nhật trạng thái của yêu cầu hỗ trợ: " + _YEU_CAU_ID);
//                        }
//                        //----------------------------------------------------------
//                    }
                    
//                }
//                else
//                    HelpMsgBox.ShowNotificationMessage("Vui lòng nhập vào nội dung phản hồi !");
//                #endregion
            }

            private void btnXoa_Click(object sender, EventArgs e)
            {
                if (HelpMsgBox.ShowConfirmMessage("Bạn có chắc chắn muốn xóa phản hồi này không ? ") == DialogResult.Yes)
                {
                    if (!DAPhanHoi.Delete(this._YEU_CAU_ID, this._NGUOI_GUI_ID, this._NGAY_GUI))
                        HelpMsgBox.ShowErrorMessage("Không xóa được phản hồi này!");
                    else
                    {
                        DOPhanHoi doPhanhoi = null;
                        this.gridViewUpdate(this, doPhanhoi);
                        this.btnClose_Click(sender, e);
                    }
                }
            }
        
        #endregion                          
    }
}
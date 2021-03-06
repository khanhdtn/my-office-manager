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
using DTO;
using DAO;
using ProtocolVN.Framework.Core;
using DevExpress.XtraEditors.DXErrorProvider;
using ProtocolVN.App.Office;
using LumiSoft.Net.Mime;

/*
 * LƯU Ý KHI THỰC HIỆN CODE (Đây là nội dung tham khảo, người viết có thể tùy biến sao cho phù hợp hơn)
 * 1.Viết code gọn gàng, dễ hiểu, tận dụng tối đa thư viện của FW
 * 2.Những xử lý phức tạp nên có comment lại theo mẫu : //[Tên tài khoản đăng nhập]: [Nội dung]
 * VD : CHAUTV : Khởi tạo dữ liệu hiển thị trong trường hợp thêm mới.
 * 3.Các nhóm xử lý hiện tại thông thường bào gồm
 * -Field (Bao gồm các biến khai báo sử dụng)
 * -Khởi tạo MenuItem
 * -Khởi tạo dữ liệu (InitDataControl)
 * -Hiển thị dữ liệu lên màn hình (InitData)
 * -Kiểm tra validate (IsValidate)
 * -Lấy đối tượng có kèm theo dữ liệu nhập từ giao diện (GetDOData)
 * -Sự kiện (Event)
 */
namespace office
{
    public partial class frmHomThuGopY : XtraFormPL,IFormRefresh
    {
        #region Fields
        /// <summary>
        /// True : Add new
        /// False: Update
        /// Null : View
        /// </summary>
        private bool? IsAdd = true;
        private DOHomThuGopY Data_Obj = null;
        private DXErrorProvider Error;
        /// <summary>
        /// Delegate dùng cho việc refresh dữ liệu khi thêm mới hoặc chỉnh sửa
        /// </summary>
        /// <returns></returns>
        public delegate void RefreshThuGopY(DOHomThuGopY doGopY);
        public event RefreshThuGopY RefreshDataAfterUpdate;
        #endregion
        public frmHomThuGopY() : this("-2", true) { }
        public frmHomThuGopY(object Id, bool? IsAdd)
        {
            InitializeComponent();
            this.IsAdd = IsAdd;
            InitDataControl();
            InitData(Id);
            PLGUIUtil.Customizebar_PLRichTextBox(NoiDung);
        }       

        public static string MenuItem(string ParentID, bool IsSep)
        {
            return MenuBuilder.CreateItem(typeof(frmHomThuGopY).FullName,
                "Tạo mới",
                ParentID, true,
                typeof(frmHomThuGopY).FullName,
                false, IsSep, "add.png", true, "", "");
        }

        #region Initiate data
        public void InitDataControl()
        {
            Error = new DXErrorProvider();
            btnSave.Visible = !(IsAdd == null);
            HelpControl.RedCheckEdit(chkAnHien, false);
            chkAnHien.Checked = true;
            chkAnHien.CheckedChanged += new EventHandler(chkAnHien_CheckedChanged);
            AppCtrl.InitTreeChonNhanVien(NguoiNhan, true,false);
            AppCtrl.InitTreeChonNhanVien(NguoiNhanMail, true);
            NguoiNhan._AfterSelected += new ProtocolVN.App.Office.ApplicationCore.PLDMTreeMultiChoice.AfterSelected(NguoiNhan__AfterSelected);
        }

        void NguoiNhan__AfterSelected(object sender, EventArgs e)
        {
            NguoiNhanMail._SelectedIDs = NguoiNhan._SelectedIDs;
        }      

        void chkAnHien_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAnHien.Checked) chkAnHien.Text = "Hiện tên người góp ý: ";
            else chkAnHien.Text = "Ẩn tên người góp ý";
            lblNguoiCapNhat.Visible = chkAnHien.Checked;
        }
        #endregion
        #region Display data
        
        public void InitData(object id)
        {
            Data_Obj = DAHomThuGopY.I.LoadAll(HelpNumber.ParseInt64(id));
            if (Data_Obj != null && Data_Obj.MasterDataSet.Tables[0].Rows.Count > 0)
            {
                txtTieude.Text = Data_Obj.TIEU_DE;
                NoiDung._setValue(Data_Obj.NOI_DUNG);
                NguoiNhan._SelectedStrIDs = Data_Obj.NGUOI_NHAN_GOP_Y;
                NguoiNhanMail._SelectedStrIDs = Data_Obj.NGUOI_NHAN_GOP_Y;
                chkAnHien.Checked = Data_Obj.IS_HIEN == "Y" ? true : false;
            }
            else
            {
                Data_Obj.NGUOI_GOP_Y = FrameworkParams.currentUser.employee_id;
                Data_Obj.NGAY = HelpDB.getDatabase().GetSystemCurrentDateTime();
            }
            if (Data_Obj.NGUOI_GOP_Y > 0)
                lblNguoiCapNhat.Text = DMNhanVienX.I.GetEmployeeFullName(Data_Obj.NGUOI_GOP_Y);
            else lblNguoiCapNhat.Text = DMNhanVienX.I.GetEmployeeFullName(FrameworkParams.currentUser.employee_id);
            lblThoiGianCapNhat.Text = Data_Obj.NGAY.ToString(PLConst.FORMAT_DATETIME_STRING);
            
        }
        #endregion
        #region Kiểm tra dữ liệu
        public bool Error_Data()
        {
            Error.ClearErrors();
            HelpInputData.ShowRequiredError(Error, new object[]{
                txtTieude,"Tiêu đề"
            });
            if (NguoiNhan._CountSelectedIDs==0)
                NguoiNhan._SetError(Error, "Vui lòng vào thông tin \"Người nhận\" !");
            if (NoiDung._getValue().Length < 0 || NoiDung.richEditControl.Text.Trim() == "")
            {
                HelpMsgBox.ShowNotificationMessage("Vui lòng vào thông tin \"Nội dung\"!");
                return true;
            }
            return Error.HasErrors;
        }
        #endregion
        #region Get data
        public void GetDOData()
        {
            Data_Obj.TIEU_DE = txtTieude.Text.Trim();
            Data_Obj.NOI_DUNG = NoiDung._getValue();
            Data_Obj.NGUOI_NHAN_GOP_Y = NguoiNhan._SelectedStrIDs;
            Data_Obj.IS_HIEN = chkAnHien.Checked ? "Y" : "N";
            Data_Obj.NGAY = HelpDB.getDatabase().GetSystemCurrentDateTime();
        }
        #endregion
        #region Các xử lý sự kiện
        private void btnSave_Click(object sender, EventArgs e)
        {
            List<long> lstUser = new List<long>(NguoiNhanMail._SelectedIDs);
            string title = "";
            //Thêm người hỗ trợ vào danh sách gửi mail trong trường hợp ko chọn
            foreach (long id in NguoiNhan._SelectedIDs)
                if (!lstUser.Contains(id))
                    lstUser.Add(id);
            if (!Error_Data()) {
                GetDOData();
                if (DAHomThuGopY.I.Update(Data_Obj)){
                    title = "Có thư góp ý mới vừa được cập nhật";
                    HelpXtraForm.CloseFormNoConfirm(this);
                    if (RefreshDataAfterUpdate != null) RefreshDataAfterUpdate(Data_Obj);

                    /////////gửi mail
                    if (lstUser.Count > 0)
                    {
                        AddressList To = new AddressList();

                        title = HelpStringBuilder.GetTitleMailNewPageper(title);
                        StringBuilder Subject = new StringBuilder();
                        IDataReader reader = FWDBService.LoadRecord("HOM_THU_GOP_Y", "ID", Data_Obj.ID);
                        using (reader)
                        {
                            if (reader.Read())
                            {
                                Subject.Append(string.Format(PLConst.DES_MAIL_HTGY, txtTieude.Text, lblNguoiCapNhat.Text, NoiDung.richEditControl.HtmlText));
                            }
                        }
                        if (!lstUser.Contains(FrameworkParams.currentUser.employee_id))
                            lstUser.Add(FrameworkParams.currentUser.employee_id);
                        To = HelpZPLOEmail.GetAddressList(lstUser.ToArray());
                        HelpZPLOEmail.SendSmartHost(
                            HelpAutoOpenForm.GeneratingCodeFromForm(this, Data_Obj.ID),
                            title, null, To, null, null, Subject.ToString(), "");
                    }
                } 
                else ErrorMsg.ErrorSave(this);
            }
        }
        
        private void frmHomThuGopY_Load(object sender, EventArgs e)
        {
            HelpXtraForm.SetCloseForm(this, this.btnDong, this.IsAdd);
            GUIValidation.SetMaxLength(new object[] {txtTieude,200});
            HelpXtraForm.SetFix(this);
        }
        #endregion
        #region IFormRefresh Members

        public object _RefreshAction(params object[] input)
        {
            return null;
        }

        #endregion
    }
}
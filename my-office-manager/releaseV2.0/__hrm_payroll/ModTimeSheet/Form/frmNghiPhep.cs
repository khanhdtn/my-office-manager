using System;
using System.Windows.Forms;
using DevExpress.XtraEditors.DXErrorProvider;
using ProtocolVN.Framework.Win;
using ProtocolVN.Framework.Core;
using DAO;
using DTO;
using ProtocolVN.DanhMuc;
using ProtocolVN.Framework.Dev.Open;
using System.Data;
using LumiSoft.Net.Mime;
using LumiSoft.Net.SMTP.Client;
using System.Collections.Generic;
using DevExpress.XtraEditors;
namespace pl.office.form
{
    public partial class frmNghiPhep : XtraFormPL
    {
        #region Vùng đặt Static 
        public static FormStatus Status = FormStatus.NO_USE;
        public static string MenuItem(string ParentID, bool IsSep)
        {
            return MenuBuilder.CreateItem(typeof(frmNghiPhep).FullName,
                PMSupport.UpdateTitle("Nghỉ phép", Status),
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
        public delegate void RefreshNghiPHep();
        public RefreshNghiPHep RefreshData;
        #endregion        

        #region Hàm dựng 
        public frmNghiPhep(long ID,bool? IsAdd)
        {
            InitializeComponent();
            Error = new DXErrorProvider();
            this.IsAdd = IsAdd;
            this._ID = ID;
            Duyet._init(true);
            DMNhanVienX.I.InitCtrl(NguoiNghiPhep, true);   
            Phieu = DATimeInOut.Instance.LoadAll(ID);
            Uncategory.setEnterAsTab(this);
            this.btnSave.Image = FWImageDic.SAVE_IMAGE16;
            btnDong.Image = FWImageDic.CLOSE_IMAGE16;
            HelpXtraForm.SetCloseForm(this, this.btnDong, IsAdd);
        }
        public frmNghiPhep() : this(-2,true) { }
        #endregion

        #region InitForm 
        private void InitGridColumns() {
            HelpGridColumn.CotTextLeft(colHoTen, "NAME");
            HelpGridColumn.CotCombobox(colPhongBan, "DEPARTMENT", "ID", "NAME", "DEPARTMENT_ID");
            HelpGridColumn.CotTextLeft(colEmail, "EMAIL");
            HelpGridColumn.CotCheckEdit(colChon, "CHON");
        }

        private void InitData() {
            DMNhanVienX.I.InitCtrl(cmbNguoiDuyet, false);
            if (Phieu.NGUOI_DUYET != 0)
                this.cmbNguoiDuyet._setSelectedID(Phieu.NGUOI_DUYET);
            QueryBuilder query = new QueryBuilder(@"SELECT * FROM DM_NHAN_VIEN WHERE 1=1");
            query.addBoolean("VISIBLE_BIT", true);
            DataSet dsSource = DABase.getDatabase().LoadDataSet(query);
            dsSource.Tables[0].Columns.Add("CHON", typeof(System.String));
            foreach (DataRow row in dsSource.Tables[0].Rows)
            {
                row["CHON"] = "N";
            }
            this.gridControlNguoiTheoDoi.DataSource = _SetDefault(dsSource.Tables[0]);

            if (this.IsAdd == true) checkSendMail.Checked = true;
            else checkSendMail.Checked = false;
        }

        private void frmHotroSupport_Load(object sender, EventArgs e)
        {
            PMSupport.SetTitle(this, Status);
            GUIValidation.SetMaxLength(new object[] { meNoi_dung, 200 }); 
            #region Init control      
 
            #region CHAUTV
            this.InitGridColumns();
            this.InitData();
            #endregion

            if (Phieu.NGAY_LAM_VIEC.ToString() != "01/01/0001 12:00:00 AM")
            {
                NgayNghiPhep.DateTime = Phieu.NGAY_LAM_VIEC;               
                btnSave.Visible = IsAdd == null ? false : true;
                lblThoiGianCapNhat.Text = Phieu.THOI_GIAN_GHI_NHAN.ToString();       
            }
            else
            {
                lblThoiGianCapNhat.Text = DABase.getDatabase().GetSystemCurrentDateTime().ToString("dd/MM/yyyy HH:mm");
                NgayNghiPhep.DateTime = System.Convert.ToDateTime(lblThoiGianCapNhat.Text);
            }
            if (Phieu.NV_ID != 0)
                NguoiNghiPhep._setSelectedID(Phieu.NV_ID);
            else
                NguoiNghiPhep._setSelectedID(FrameworkParams.currentUser.employee_id);
            if (Phieu.NGHI_BUOI_SANG == "Y")
                chkNghi_BS.Checked = true;
            if (Phieu.NGHI_BUOI_CHIEU == "Y")
                checkNghi_BC.Checked = true;
            if (Phieu.NGHI_PHEP_NAM == "Y")
                radioGroup.SelectedIndex = 0;
            if (Phieu.NGHI_KHONG_LUONG == "Y")
                radioGroup.SelectedIndex = 1;
            meNoi_dung.Text = Phieu.NOI_DUNG;
            if (Phieu.DUYET == null)
                Phieu.DUYET = "1";            
            Duyet.SetDuyet(Phieu);
            #endregion
        }
        
        #endregion             

        #region Xử lý nút 
        private void btnSave_Click(object sender, EventArgs e)
        {
            Error.ClearErrors();
            #region Kiểm tra dữ liệu 
            bool IsValid = true;
            IsValid =  GUIValidation.ShowRequiredError(Error, new object[] { 
                NguoiNghiPhep, "Người nghỉ phép",
                this.cmbNguoiDuyet,"Người duyệt",
                this.meNoi_dung,"Lý do nghỉ",
                this.NgayNghiPhep,"Ngày nghỉ"
            });
            if (chkNghi_BS.Checked == false && checkNghi_BC.Checked == false)
            {
                Error.SetError(chkNghi_BS, "Vui lòng chọn thời gian nghỉ phép (Sáng,chiều)");
                Error.SetError(checkNghi_BC, "Vui lòng chọn thời gian nghỉ phép (Sáng,chiều)");
                IsValid = false;
            }            
            #endregion
            if (!IsValid) return;
            #region Lưu dữ liệu 
            if(IsAdd == true) Phieu.ID = DABase.getDatabase().GetID("G_NGHIEP_VU");
            Phieu.NV_ID = NguoiNghiPhep._getSelectedID();
            Phieu.NGAY_LAM_VIEC = System.Convert.ToDateTime(NgayNghiPhep.EditValue);
            if (chkNghi_BS.Checked)
            {
                Phieu.THOI_GIAN_SANG = "N";
                Phieu.NGHI_BUOI_SANG = "Y";
            }
            else
            {
                Phieu.NGHI_BUOI_SANG = string.Empty;
                Phieu.THOI_GIAN_SANG = string.Empty;
            }
            if (checkNghi_BC.Checked)
            {
                Phieu.THOI_GIAN_CHIEU = "N";
                Phieu.NGHI_BUOI_CHIEU = "Y";
            }
            else
            {
                Phieu.NGHI_BUOI_CHIEU = string.Empty;
                Phieu.THOI_GIAN_CHIEU = string.Empty;
            }
            if (radioGroup.SelectedIndex == 0)
                Phieu.NGHI_PHEP_NAM = "Y";
            else
                Phieu.NGHI_PHEP_NAM = string.Empty;
            if (radioGroup.SelectedIndex == 1)
                Phieu.NGHI_KHONG_LUONG = "Y";
            else
                Phieu.NGHI_KHONG_LUONG = string.Empty;
            Phieu.NOI_DUNG = meNoi_dung.Text;            
            Phieu.NV_ID = NguoiNghiPhep._getSelectedID();
            Phieu.THOI_GIAN_GHI_NHAN = System.Convert.ToDateTime(lblThoiGianCapNhat.Text);
            Phieu.NGUOI_GHI_NHAN = this.cmbNguoiDuyet._getSelectedID();
            Phieu.NGUOI_DUYET = this.cmbNguoiDuyet._getSelectedID();
            Phieu.LOAI = 2;
            
            DATimeInOut.Instance.Update(Phieu);
            if (DATimeInOut.Instance.UpdatePhieu(Phieu))
            {
                try
                {
                    if (this.checkSendMail.Checked)
                        this._SendThongBao(Phieu);
                    if(RefreshData != null)RefreshData();
                    PLGUIUtil.ClosePhieu(this, true);
                }
                catch (Exception ex)
                {
                    HelpSysLog.AddException(ex, "Lỗi thực hiện refresh dữ liệu.");
                }
            }
            else
                ErrorMsg.ErrorSave("Lưu không thành công.Vui lòng kiểm tra lại dữ liệu");
            #endregion
        }
        #endregion                                                  
        
        #region Hỗ trợ gửi mail
        
        private long[] GetEmployee() {
            DataTable tb = (this.gridControlNguoiTheoDoi.DataSource as DataTable);
            List<long> arr = new List<long>();
            foreach (DataRow item in tb.Rows)
            {
                if (item["CHON"].Equals("Y"))
                    arr.Add(HelpNumber.ParseInt64(item["ID"]));
            }
            return arr.ToArray();
        }

        private DataTable _SetDefault(DataTable table) {
            foreach (DataRow row in table.Rows)
            {
                if (row["EMAIL"] != null && (row["EMAIL"].ToString().Contains("phuocnt")
                    || row["EMAIL"].ToString().Contains("locltt")
                    || row["EMAIL"].ToString().Contains("aintt")
                    || row["EMAIL"].ToString().Contains("officer")))
                    row["CHON"] = "Y";
            }
            return table;
        }

        private bool _SendThongBao(DOTimeInOut Phieu)
        {
            ///Thông tin SMTP
            DOServerMail serverMail = DAServerMail.Instance.LoadAll(1);
            ///1.Nội dung
            string Title = "[PL-Office] Thông báo";
            string Subject = "Trên hệ thống PL-OFFICE có nhận được một phiếu XIN NGHỈ PHÉP : "
            + @"-Người xin nghỉ phép: " + ""
            + @"-Ngày nghỉ: " + Phieu.NGAY_LAM_VIEC.ToShortDateString()
            + @"-Loại nghỉ phép: " + ((Phieu.NGHI_KHONG_LUONG == "Y") ? "Không lương" : "Phép năm")
            + @"-Buổi: " + "Sáng: " + Phieu.NGHI_BUOI_SANG + ". Chiều: " + Phieu.NGHI_BUOI_CHIEU
            + @"-Lý do: " + Phieu.NOI_DUNG;
            ///2.Thông tin người nhận && CC
            AddressList To = PLHelpMail.GetAddressList(new long[] { this.cmbNguoiDuyet._getSelectedID()});
            AddressList CC = PLHelpMail.GetAddressList(this.GetEmployee());
            ///3.Gửi mail
            return PLHelpMail._SendMail(serverMail.SMTP, 25, "", Title, serverMail.NAME, serverMail.EMAIL, serverMail.PASS, To, null, null, Subject, "");
        }
        #endregion

        private void checkSendMail_CheckedChanged(object sender, EventArgs e)
        {
            tabMailInfo.PageVisible = checkSendMail.Checked;
        }
    }
}
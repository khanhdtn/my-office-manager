using System;
using System.Windows.Forms;
using ProtocolVN.Framework.Core;
using ProtocolVN.Framework.Win;
using DevExpress.XtraEditors.DXErrorProvider;
using DAO;
using DTO;
using System.Data;
using System.Collections.Generic;
using System.IO;
using ProtocolVN.Framework.Dev.Open;
using ProtocolVN.DanhMuc;
namespace pl.office.form
{
    
    public partial class frmNewsPaper : XtraFormPL
    {
        #region Vùng đặt Static
        public static FormStatus Status = FormStatus.NO_USE;
        public static string MenuItem(string ParentID, bool IsSep)
        {
            return MenuBuilder.CreateItem(typeof(frmNewsPaper).FullName,
                PMSupport.UpdateTitle("Quản lý tin tức", Status),
                ParentID, true,
                typeof(frmNewsPaper).FullName,
                false, IsSep, "mnbCHinhHeThong.png", true, "", "");
        }
        #endregion

        #region Các khai báo biến
        public delegate void Update_Data(DOTinTuc doTinTuc, DOLuuTruTapTin doLuuTru);
        public Update_Data Refresh_Data;
        private bool? IsAdd; //true:new,false:edit,null:view        
        private DOTinTuc doTinTuc = null;
        private DOLuuTruTapTin do_luu_tru_tt = null;
        private Int64 _maxFileSize = 20;
        private long _ID;
        private DXErrorProvider Error;
        private string pathSource = string.Empty;
        private string pathNew = string.Empty;
        public delegate void gridControlMasterUpdateHandler(object sender, DOTinTuc e);
        #endregion
       
        #region Các hàm khởi tạo
        public frmNewsPaper(long ID,bool? _isAdd)
        {
            InitializeComponent();
            Error = new DXErrorProvider();
            this._ID = ID;
            this.IsAdd = _isAdd;
            PLTinTuc.ChonNhomTin(PLNhomTT, IsAdd);
            Duyet._init(true);           
            InitData(_ID);
            Init_State(IsAdd);
            PLNhomTT.ToolTip = string.Empty;
            HelpControl .setEnterAsTab(this);
            this.btnSave.Image = FWImageDic.SAVE_IMAGE16;
            
            btnDong.Image = FWImageDic.CLOSE_IMAGE16;
            PLGUIUtil.setDefaultSize(this);
            HelpXtraForm.SetCloseForm(this, this.btnDong, this.IsAdd);
        }

        public frmNewsPaper() : this(-2,true) { }
        
        #endregion

        #region Khởi tạo Data
        /// <summary>
        /// Khởi tạo dữ liệu 
        /// </summary>
        /// <param name="ID"></param>
        private void InitData(long ID)
        {
            try
            {
                if (this.IsAdd == true)
                {
                    doTinTuc = DATinTuc.Instance.LoadAll(-2);
                    do_luu_tru_tt = DALuuTruTapTin.Instance.LoadAll(-2);
                    lblNguoiCapNhat.Text = DMFWNhanVien.GetFullName(FrameworkParams.currentUser.employee_id);
                    lblThoiGianCapNhat.Text = DABase.getDatabase().GetSystemCurrentDateTime().ToString(PLConst.FORMAT_DATETIME_STRING);
                    doTinTuc.DUYET = "1";
                }
                else
                {
                    doTinTuc = DATinTuc.Instance.LoadAll(ID);
                    do_luu_tru_tt = DALuuTruTapTin.Instance.LoadAll(DATinTuc.Instance.get_TapTin(ID).ID);
                    lblNguoiCapNhat.Text = DMFWNhanVien.GetFullName(doTinTuc.NGUOI_CAP_NHAT);
                    lblThoiGianCapNhat.Text = doTinTuc.NGAY_CAP_NHAT.ToString(PLConst.FORMAT_DATETIME_STRING);
                    PLNhomTT._setSelectedID(doTinTuc.NHOM_TIN);
                    checkTin_noi_bat.Checked = (doTinTuc.PRIOR == "Y");
                    txtTieude.Text = doTinTuc.TIEU_DE;
                    PLNoidung._setHTMLText(HelpByte.BytesToUTF8String(doTinTuc.NOI_DUNG));
                    btnTaptin.Text = do_luu_tru_tt.TEN_FILE;
                }
                Duyet.SetDuyet(doTinTuc);
            }
            catch (Exception ex)
            {
                PLException.AddException(ex);
            }
        }
        /// <summary>
        /// Khởi tạo trạng thái cho các nút
        /// </summary>
        /// <param name="IsAdd"></param>
        private void Init_State(bool? IsAdd)
        {
            if (IsAdd == null)
            {
                btnSave.Visible = false;
                
                btnDong.Visible = true;
                
            }
            else if (IsAdd == false)
            {
                
                btnSave.Visible = true;
                btnDong.Visible = true;
            }
            else
            {
                btnSave.Visible = true;
                btnDong.Visible = true;
                
            }            
        }        
        #endregion

        #region InitForm
        private void frmTinTuc_Load(object sender, EventArgs e)
        {
            try
            {
                QueryBuilder query = new QueryBuilder(@"SELECT * FROM DM_NHAN_VIEN WHERE 1=1");
                query.addBoolean("VISIBLE_BIT", true);
                DataSet Employs = DABase.getDatabase().LoadDataSet(query);                
                List<long> IDs = new List<long>();
                foreach (DataRow row in Employs.Tables[0].Rows)
                {
                    IDs.Add(HelpNumber.ParseInt64(row["ID"]));
                }                
                GUIValidation.SetMaxLength(new object[] { 
                    txtTieude,200
                });
                PMSupport.SetTitle(this, Status);

                if (IsAdd == true)
                {
                    PLTinTuc.ChonNhomTin(PLNhomTT, IsAdd);
                }
                if (do_luu_tru_tt.TEN_FILE != null && do_luu_tru_tt.TEN_FILE!=string.Empty)
                {
                    checkXoa_TT_DK.Visible = IsAdd == false ? true : false;
                    HelpControl.RedCheckEdit(checkXoa_TT_DK);
                }
                if (this.btnSave.Visible == true) {
                    if (DATinTuc.Instance.getNguoiDuyet(143).Contains(FrameworkParams.currentUser.employee_id))
                        this.Duyet.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                PLException.AddException(ex);
            }
        }       
        #endregion
      
        #region Validate(ktra lỗi)

        public bool IsValidate()
        {
           
            Error.ClearErrors();
            GUIValidation.ShowRequiredError(Error,
                   new object[]{
                        PLNhomTT, "Nhóm tin tức",
                        txtTieude,"Chủ đề"
                   }
            );
            if (PLNoidung.BodyText != null || PLNoidung.Document.Images.Count > 0)
                return !Error.HasErrors;
            else
            {
                PLMessageBox.ShowNotificationMessage("Vui lòng vào thông tin \"Nội dung\"!");
                return false;
            }
        }
        #endregion

        #region Xử lý nút
        private void btnTaptin_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsAdd == true || IsAdd == false)
                {
                    openFile.Title = "Chọn tập tin";
                    if (openFile.ShowDialog() == DialogResult.OK)
                    {
                        pathSource = openFile.FileName;
                        int i = pathSource.LastIndexOf(@"\");
                        pathNew = PLFile.Directory_folder + pathSource.Substring(i, pathSource.Length - i);
                        string[] str = new string[pathSource.Split(new char[] { '\\' }, StringSplitOptions.RemoveEmptyEntries).Length];
                        str = pathSource.Split(new char[] { '\\' }, StringSplitOptions.RemoveEmptyEntries);
                        btnTaptin.Text = str[str.Length - 1];
                        //Kiểm tra độ lớn của file
                        if (!HelpFile.CheckFileSize(pathSource, _maxFileSize))
                        {
                            //vuot qua kich thuoc quy dinh
                            PLMessageBox.ShowNotificationMessage("Kích thước file không được vượt quá" + _maxFileSize.ToString() + "MB");
                            pathSource = null;
                            btnTaptin_Click(sender, e);
                        }
                    }
                    else// if (openFile.ShowDialog() == DialogResult.Cancel)
                    {
                        pathSource = string.Empty;
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                HelpSysLog.AddException(ex);
            }
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (IsValidate())
            {
                    if(!Get_Data()) return ;                   
                    if (DATinTuc.Instance.Update(doTinTuc) && DALuuTruTapTin.Instance.Update(do_luu_tru_tt))
                    {                                 
                        try
                        {
                            if (IsAdd == true)
                            {
                                DATinTuc.Instance.INSERT_TIN_TUC_TAP_TIN(doTinTuc.ID, do_luu_tru_tt.ID);
                                
                            }
                            else
                            {
                                
                                Refresh_Data(doTinTuc, do_luu_tru_tt);
                            }
                            
                        }
                        catch { }
                        finally
                        {
                            PLGUIUtil.ClosePhieu(this, true);
                        }                                                                       
                    }
                    else
                        PLMessageBox.ShowNotificationMessage("Lưu không thành công !");
                    if (IsAdd == true)
                    {
                        if (doTinTuc.DUYET == ((Int32)DuyetSupportStatus.Duyet).ToString())
                            DATinTuc.Instance._SendThongBao(doTinTuc, "DUYET");
                        if (doTinTuc.DUYET == ((Int32)DuyetSupportStatus.ChoDuyet).ToString())
                            DATinTuc.Instance._SendThongBao(doTinTuc, "ADD");
                        if (doTinTuc.DUYET == ((Int32)DuyetSupportStatus.KhongDuyet).ToString())
                            DATinTuc.Instance._SendThongBao(doTinTuc, "KHONG_DUYET");
                    }
                    else {
                        if (doTinTuc.DUYET == ((Int32)DuyetSupportStatus.Duyet).ToString())
                            DATinTuc.Instance._SendThongBao(doTinTuc, "DUYET");
                        if (doTinTuc.DUYET == ((Int32)DuyetSupportStatus.ChoDuyet).ToString())
                            DATinTuc.Instance._SendThongBao(doTinTuc, "EDIT");
                        if (doTinTuc.DUYET == ((Int32)DuyetSupportStatus.KhongDuyet).ToString())
                            DATinTuc.Instance._SendThongBao(doTinTuc, "KHONG_DUYET");
                    }
            }
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (PLMessageBox.ShowConfirmMessage("Bạn có muốn xóa không!") == DialogResult.Yes)
            {
                DATinTuc.Instance.Delete(doTinTuc.ID);
                this.Close();
            }
        }        

        #endregion  
           
        #region Các hàm chức năng 
        /// <summary>
        /// Lấy dữ liệu để cập nhật
        /// </summary>
        private bool Get_Data()
        {
            //Get data cho TIN_TUC
            doTinTuc.NHOM_TIN = PLNhomTT._getSelectedID();
            doTinTuc.TIEU_DE = txtTieude.Text;
            doTinTuc.NOI_DUNG = HelpByte.UTF8StringToBytes(PLNoidung._getHTMLText());
            doTinTuc.NGAY_CAP_NHAT = DABase.getDatabase().GetSystemCurrentDateTime();
            doTinTuc.NGUOI_CAP_NHAT = FrameworkParams.currentUser.employee_id;
            doTinTuc.PRIOR = (checkTin_noi_bat.Checked == true ? "Y" : "N");
            if (doTinTuc.DUYET == null)
                doTinTuc.DUYET = "1";
            //Get data cho LUU_TRU_TAP_TIN
            Duyet.GetDuyet(doTinTuc);
            if (pathSource.IndexOf(@"\") > 0) {
                FileStream fs=null;
                try
                {
                    fs = new FileStream(pathSource, FileMode.Open, FileAccess.Read);
                }
                catch (IOException ex) {
                    if (ex.Message.ToString().IndexOf("The process cannot access the file") >= 0)
                        PLMessageBox.ShowNotificationMessage("Vui lòng đóng các ứng dụng đang truy cập đến tập tin này trước!");
                    else
                    {
                        if (fs != null) fs.Close();
                    }
                    return false;
                }                
                do_luu_tru_tt.NOI_DUNG = HelpByte.FileToBytes(pathSource);
            }                
            if (checkXoa_TT_DK.Checked)
            {
                do_luu_tru_tt.NOI_DUNG = null;
                do_luu_tru_tt.TEN_FILE = string.Empty;
            }
            else
                do_luu_tru_tt.TEN_FILE = btnTaptin.Text;
            do_luu_tru_tt.NGAY_CAP_NHAT = doTinTuc.NGAY_CAP_NHAT;
            do_luu_tru_tt.NGUOI_CAP_NHAT = doTinTuc.NGUOI_CAP_NHAT;
            do_luu_tru_tt.TIEU_DE = doTinTuc.TIEU_DE;            
            return true;
        }                        
                            
        #endregion

        private void btnTaptin_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }

    }
}
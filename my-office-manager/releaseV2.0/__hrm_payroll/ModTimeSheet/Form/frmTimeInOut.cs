using System;
using System.Data;
using System.Data.Common;
using DevExpress.XtraEditors.DXErrorProvider;
using pl.office;
using DTO;
using DAO;
using ProtocolVN.Framework.Core;
using ProtocolVN.Framework.Win;
using System.Net;
using ProtocolVN.Framework.Dev.Open;

namespace ProtocolVN.Plugin.TimeSheet
{
    public partial class frmTimeInOut : XtraFormPL
    {
        #region Danh sách biến
        public delegate void RefreshGird();
        public RefreshGird ReFindData;
        private DOTimeInOut phieu = null;
        private bool? IsAdd = false;
        private DXErrorProvider Error = null;
        private DateTime DateTimeServer;
        private long NV_ID;
        private DateTime NgayLamViec;
        private DOSystemParams TimeSystem;
        #endregion

        #region Hàm dựng
        public frmTimeInOut(object id, DateTime Ngay, bool? IsAdd)
        {
            this.IsAdd = IsAdd;
            if (this.IsAdd == true) NV_ID = this.GetNVID(FrameworkParams.currentUser.id);
            else if (this.IsAdd == false || this.IsAdd == null) NV_ID = HelpNumber.ParseInt64(id);
            InitializeComponent();
            if (this.IsAdd == false)
                HelpXtraForm.SetCloseForm(this, btnClose, true);
            else
            {
                this.btnClose.Click += delegate(object sender, EventArgs e)
                {
                    this.Close();
                };
            }
            this.NgayLamViec = Ngay;
            DateTimeServer = Ngay;
            InitAdd();
            InitGrid();
            if (IsAdd != null) InitValidation();
            if (!InitDOData(id, Ngay)) PLCtrl.HuyForm(this);
            InitGridData(id);
            InitControlState();
            Error = new DXErrorProvider(this);
            TimeSystem = DASystemParams.Instance.LoadAll(1);
            Uncategory.setEnterAsTab(this);
            btnStart.Image = FWImageDic.SAVE_IMAGE16;
            this.btnEnd.Image = FWImageDic.SAVE_IMAGE16;
            btnClose.Image = FWImageDic.CLOSE_IMAGE16;
        }

        public frmTimeInOut() : this("-2", DABase.getDatabase().GetSystemCurrentDateTime(), true) { } //Thêm mới
        public frmTimeInOut(object id, DateTime Ngay) : this(id, Ngay, false) { }
        #endregion

        #region Hàm khởi tạo
        private void InitAdd()
        {
            if (this.IsAdd == true)
            {
                txtNgayLamViec.Text = DABase.getDatabase().GetSystemCurrentDateTime().ToShortDateString();
                txtNhanVien.Text = this.GetTenNhanVien(NV_ID);
                timeEditBatDau.EditValue = NgayLamViec;
                timeEditKetThuc.EditValue = null;
            }

        }
        private void InitGrid()
        {
            //NOOP
        }
        private bool InitDOData(object id, DateTime Ngay)
        {
            phieu = DATimeInOut.Instance.LoadAll(NV_ID, Ngay, 1);//Chi lay nhung dong la ngay lam viec->*1*
            return true;
        }
        private void InitGridData(object id)
        {
        }
        private void InitControlState()
        {
            //1.Lấy Record có giờ kết thúc là null của nhân viên đang đăng nhập
            DataSet recordNULL = this.GetRecordGioKetThucNULL(GetNVID(FrameworkParams.currentUser.id), DateTimeServer);
            //2.Nếu tồn tại thì update cho record đó với giờ kết thúc bằng giờ bắt đầu
            if (recordNULL.Tables[0].Rows.Count >= 1)
            {
                this.UpdateGioKetThucNULL(HelpNumber.ParseInt64(recordNULL.Tables[0].Rows[0]["NV_ID"]),
                    (DateTime)recordNULL.Tables[0].Rows[0]["NGAY_LAM_VIEC"],
                    (DateTime)recordNULL.Tables[0].Rows[0]["GIO_BAT_DAU"], true);
            }
            else { }

            if (this.IsAdd == true)
            {

                timeEditBatDau.Enabled = false;
                timeEditKetThuc.Enabled = false;

                btnEnd.Tag = "KetThuc";
                btnEnd.Text = "Kết thúc";

                //3.Kiem tra ngay hom nay cua nhan vien nay da ton tai chua
                //Chon dong co loai=1(lam viec)
                if (phieu.DetailDataSet.Tables[0].Select("LOAI=1").Length == 1) //Ton tai
                {

                    if (phieu.GIO_KET_THUC != null)
                    {
                        btnStart.Enabled = false;
                        btnEnd.Enabled = false;

                        this.timeEditBatDau.EditValue = phieu.GIO_BAT_DAU;
                        this.timeEditKetThuc.EditValue = phieu.GIO_KET_THUC;
                    }
                    else
                    {
                        btnStart.Enabled = false;
                        btnEnd.Enabled = true;
                        this.timeEditBatDau.EditValue = phieu.GIO_BAT_DAU;
                        this.timeEditKetThuc.EditValue = DateTimeServer;
                    }
                }
                else
                {
                    this.timeEditBatDau.EditValue = DateTimeServer;
                    this.timeEditKetThuc.EditValue = null;
                    btnEnd.Enabled = false;
                }
            }
            else if (this.IsAdd == false || this.IsAdd == null)
            {
                txtNhanVien.Text = this.GetTenNhanVien(this.NV_ID);
                txtNgayLamViec.Text = phieu.NGAY_LAM_VIEC.ToShortDateString();
                timeEditBatDau.EditValue = phieu.GIO_BAT_DAU;
                timeEditKetThuc.EditValue = phieu.GIO_KET_THUC;
                btnStart.Visible = false;
                btnEnd.Enabled = true;

                btnEnd.Text = "Lưu";
                btnEnd.Tag = "Luu";
                btnEnd.Visible = IsAdd == null ? false : true;
            }
            if (this.IsAdd == null)
            {
                timeEditBatDau.Enabled = false;
                timeEditKetThuc.Enabled = false;
            }
        }
        public bool GetData()
        {
            return true;
        }
        #endregion

        #region Hàm hỗ trợ xử lý DB
        public DataSet GetRecordGioKetThucNULL(long IDNhanVien, DateTime NgayHienTai)
        {
            string sql = @"select * from CAPNHAT_NGAYLAMVIEC where GIO_KET_THUC is null and NV_ID = " + IDNhanVien.ToString() +
                           " and NGAY_LAM_VIEC = (select max(t.NGAY_LAM_VIEC) from CAPNHAT_NGAYLAMVIEC t where NV_ID= " + IDNhanVien.ToString() + ") "
                          + " and NGAY_LAM_VIEC < @NGAY_HIEN_TAI and LOAI=" + 1;
            DataSet ds = new DataSet("CAPNHAT_NGAYLAMVIEC");
            DatabaseFB db = DABase.getDatabase();
            DbCommand cmd = db.GetSQLStringCommand(sql);
            db.AddInParameter(cmd, "@NGAY_HIEN_TAI", DbType.DateTime, NgayHienTai);
            db.LoadDataSet(cmd, ds, "CAPNHAT_NGAYLAMVIEC");
            return ds;
        }
        private long GetNVID(long usercat)
        {
            string sql = "select EMPLOYEE_ID from USER_CAT where USERID=" + usercat;
            DataSet ds = new DataSet();
            DatabaseFB db = DABase.getDatabase();
            System.Data.Common.DbCommand cmd = db.GetSQLStringCommand(sql);
            db.LoadDataSet(cmd, ds, "USER");
            if (ds.Tables[0].Rows.Count > 0)
                return HelpNumber.ParseInt64(ds.Tables[0].Rows[0][0].ToString());
            else
                return -1;
        }
        private string GetTenNhanVien(long nvid)
        {
            string sql = "select TEN_NV from DM_NHAN_VIEN where ID=" + nvid;
            DataSet ds = new DataSet();
            DatabaseFB db = DABase.getDatabase();
            System.Data.Common.DbCommand cmd = db.GetSQLStringCommand(sql);
            db.LoadDataSet(cmd, ds, "DM_NHAN_VIEN");
            if (ds.Tables[0].Rows.Count > 0)
                return ds.Tables[0].Rows[0]["TEN_NV"].ToString();
            else
                return "";
        }
        public void UpdateGioKetThucNULL(long IDNhanVien, DateTime Ngay, DateTime value, bool AutoTheEnd)
        {
            string sql = sql = @"Update CAPNHAT_NGAYLAMVIEC set GIO_KET_THUC ='" + value.ToString("HH:mm:ss") + "',THOI_GIAN_LAM_VIEC='00:00:00'" +
                            " where NV_ID =" + IDNhanVien + " and NGAY_LAM_VIEC='" + Ngay.ToString("MM/dd/yyyy") + "'";
            DatabaseFB db = DABase.getDatabase();
            DbCommand cmd = db.GetSQLStringCommand(sql);
            db.ExecuteNonQuery(cmd);
        }
        #endregion

        #region Sự kiện
        private void frmNgaylamviec_Load(object sender, EventArgs e)
        {
            HelpXtraForm.SetFix(this);
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            string UserName = FrameworkParams.currentUser.username.ToUpper();
            HelpSysLog.log.Info(string.Format(Environment.NewLine + UserName + "-[BEGIN LOG START GHI THOI GIAN]. Nguoi dung :{0}, Time :{1}", FrameworkParams.currentUser.username.ToUpper(), DABase.getDatabase().GetSystemCurrentDateTime().ToString()));
            phieu.ID = DABase.getDatabase().GetID(PLDBUtil.G_NGHIEP_VU);
            phieu.NV_ID = this.NV_ID;
            phieu.NGAY_LAM_VIEC = this.DateTimeServer;
            phieu.GIO_BAT_DAU = DABase.getDatabase().GetSystemCurrentDateTime();
            phieu.GIO_KET_THUC = null;
            phieu.THOI_GIAN_LAM_VIEC = null;
            phieu.THOI_GIAN_SANG = null;
            phieu.THOI_GIAN_CHIEU = null;
            phieu.IS_CHAM_CONG = "";
            phieu.IP_ADDRESS = Get_IPAddress();
            phieu.LOAI = 1;
            DATimeInOut.Instance.Update(phieu);
            if (DATimeInOut.Instance.UpdatePhieu(phieu))
            {
                HelpSysLog.log.Info(Environment.NewLine + UserName + "-[END LOG START GHI THOI GIAN.Ket qua: THANH CONG.]");
                this.btnStart.Enabled = false;
                this.btnEnd.Enabled = true;
                this.timeEditBatDau.EditValue = phieu.GetGIO_BAT_DAU();
                try
                {
                    if (ReFindData != null)
                        ReFindData();
                }
                catch (Exception ex)
                {
                    HelpSysLog.AddException(ex, "EXCEPTION OF START");
                }
            }
            else
            {
                HelpSysLog.log.Info(Environment.NewLine + UserName + "-[END LOG START GHI THOI GIAN.Ket qua: KHONG THANH CONG.]");
                PLMessageBox.ShowErrorMessage("Thực hiện không thành công");
            }
        }
        private void btnEnd_Click(object sender, EventArgs e)
        {
            if (btnEnd.Tag.Equals("KetThuc"))
            {
                string UserName = FrameworkParams.currentUser.username.ToUpper();
                HelpSysLog.log.Info(Environment.NewLine + string.Format(UserName + "-[BEGIN LOG FINISH GHI THOI GIAN]. Nguoi dung {0}, Time {1}", FrameworkParams.currentUser.username.ToUpper(), DABase.getDatabase().GetSystemCurrentDateTime().ToString()));
                if (PLMessageBox.ShowConfirmMessage("Bạn có chắc muốn kết thúc ngày làm việc không?") == System.Windows.Forms.DialogResult.Yes)
                {
                    HelpSysLog.log.Info(Environment.NewLine + UserName + "[LOG FINISH GHI THOI GIAN : DONG Y THUC HIEN]");

                    phieu.NV_ID = this.NV_ID;
                    //timeEditKetThuc.EditValue = DABase.getDatabase().GetSystemCurrentDateTime();
                    phieu.GIO_KET_THUC = System.Convert.ToDateTime(timeEditKetThuc.EditValue.ToString());
                    TimeSpan? Tglv = new TimeSpan(0, 0, 0);
                    TimeSpan? TG_Sang = new TimeSpan(0, 0, 0);
                    TimeSpan? TG_Chieu = new TimeSpan(0, 0, 0);
                    if (Tglv != null)
                    {
                        if (phieu.GIO_BAT_DAU.Value.TimeOfDay < TimeSystem.GIO_KET_THUC_SANG.TimeOfDay)
                        {                            
                            TimeSpan? TG_Tre_Sang ;
                            if (phieu.GIO_KET_THUC.Value.TimeOfDay < TimeSystem.GIO_BAT_DAU_CHIEU.TimeOfDay)
                                TG_Sang = HelpDateExt.getThoiGianLamViec(timeEditBatDau.EditValue, phieu.GIO_KET_THUC);
                            else
                                TG_Sang = HelpDateExt.getThoiGianLamViec(timeEditBatDau.EditValue, TimeSystem.GIO_KET_THUC_SANG);
                            //Nếu thời gian bắt đầu lớn hơn thời gian đi trễ cho phép
                            if (Convert.ToDateTime(timeEditBatDau.EditValue).TimeOfDay > TimeSystem.GIO_BAT_DAU_SANG.AddMinutes((double)TimeSystem.THOI_GIAN_CHO_PHEP_TRE).TimeOfDay)
                            {
                                TG_Tre_Sang = HelpDateExt.getThoiGianLamViec(TimeSystem.GIO_BAT_DAU_SANG, timeEditBatDau.EditValue);
                                //Thời gian sáng = thời gian sáng - (HE_SO_TRU_LUONG * thời gian đi trễ)
                                for (int i = 0; i < TimeSystem.HE_SO_TRU_LUONG; i++)
                                    TG_Sang -= TG_Tre_Sang;
                            }
                            if (TG_Sang.Value.TotalSeconds >= 0)//Nếu chưa bị trừ hết thời gian sáng
                            {
                                phieu.THOI_GIAN_SANG = new DateTime(1970, 1, 1, TG_Sang.Value.Hours, TG_Sang.Value.Minutes, TG_Sang.Value.Seconds).TimeOfDay.ToString().Substring(0, 5);
                                Tglv = new TimeSpan(TG_Sang.Value.Hours, TG_Sang.Value.Minutes, TG_Sang.Value.Seconds);
                            }
                            //Ngược lại thì thời gian sáng bị âm
                            else
                            {
                                phieu.THOI_GIAN_SANG = new DateTime(1970, 1, 1, 0, 0, 0).TimeOfDay.ToString().Substring(0, 5);                             
                            }
                        }                                                
                        else //Không làm việc buổi sáng                        
                            phieu.THOI_GIAN_SANG = string.Empty;
                        ///Tính thời gian buổi chiều
                        phieu.THOI_GIAN_CHIEU = string.Empty;
                        TimeSpan? TG_Tre_Chieu;
                        //Nếu nhân viên bắt đầu ngày làm việc từ buổi chiều
                        if (phieu.GIO_BAT_DAU != null && phieu.GIO_BAT_DAU.Value.TimeOfDay >= TimeSystem.GIO_BAT_DAU_CHIEU.TimeOfDay)
                        {
                            if (phieu.GIO_KET_THUC != null)
                            {
                                TG_Chieu = HelpDateExt.getThoiGianLamViec(phieu.GIO_BAT_DAU, phieu.GIO_KET_THUC);
                                //Nếu thời gian bắt đầu lớn hơn thời gian đi trễ cho phép
                                if (phieu.GIO_BAT_DAU > TimeSystem.GIO_BAT_DAU_CHIEU.AddMinutes((double)TimeSystem.THOI_GIAN_CHO_PHEP_TRE))
                                {
                                    TG_Tre_Chieu = HelpDateExt.getThoiGianLamViec(TimeSystem.GIO_BAT_DAU_CHIEU, phieu.GIO_BAT_DAU);
                                    //Thời gian chiều = Thời gian chiều - (HE_SO_TRU_LUONG * thời gian đi trễ)
                                    for (int i = 0; i < TimeSystem.HE_SO_TRU_LUONG; i++)
                                        TG_Chieu -= TG_Tre_Chieu;
                                }         
                            }
                        }
                        else // Đã làm việc từ buổi sáng
                        {
                            if (phieu.GIO_KET_THUC != null)
                                TG_Chieu = HelpDateExt.getThoiGianLamViec(TimeSystem.GIO_BAT_DAU_CHIEU, phieu.GIO_KET_THUC);
                        }    
                        //Nếu thời gian buổi chiều vẫn còn(sau khi trừ thời gian đi trễ buổi chiều)
                        if (TG_Chieu.Value.TotalSeconds >= 0){
                            phieu.THOI_GIAN_CHIEU = new DateTime(1970, 1, 1, TG_Chieu.Value.Hours, TG_Chieu.Value.Minutes, TG_Chieu.Value.Seconds).TimeOfDay.ToString().Substring(0, 5);
                            Tglv += TG_Chieu;
                        }
                        else phieu.THOI_GIAN_CHIEU = new DateTime(1970, 1, 1, 0, 0, 0).TimeOfDay.ToString().Substring(0, 5);
                        phieu.THOI_GIAN_LAM_VIEC = new DateTime(1970, 1, 1, Tglv.Value.Hours, Tglv.Value.Minutes, Tglv.Value.Seconds);
                    }
                    phieu.IS_CHAM_CONG = "N";
                    phieu.IP_ADDRESS = Get_IPAddress();

                    if (phieu.GIO_KET_THUC == null)
                    {
                        phieu.THOI_GIAN_SANG = string.Empty;
                        phieu.THOI_GIAN_CHIEU = string.Empty;
                        phieu.THOI_GIAN_LAM_VIEC = null;
                    }
                    if (phieu.GIO_BAT_DAU != null && phieu.GIO_BAT_DAU.Value.TimeOfDay > TimeSystem.GIO_KET_THUC_SANG.TimeOfDay)
                        phieu.THOI_GIAN_SANG = string.Empty;
                    if (phieu.GIO_KET_THUC != null && phieu.GIO_KET_THUC.Value.TimeOfDay < TimeSystem.GIO_BAT_DAU_CHIEU.TimeOfDay)
                        phieu.THOI_GIAN_CHIEU = string.Empty;

                    DATimeInOut.Instance.Update(phieu);
                    if (DATimeInOut.Instance.UpdatePhieu(phieu))
                    {
                        HelpSysLog.log.Info(Environment.NewLine + UserName + "-[END LOG FINISH GHI THOI GIAN : Ket qua : THANH CONG]");
                        btnEnd.Enabled = false;
                        try
                        {
                            if(ReFindData != null) ReFindData();
                        }
                        catch { }
                    }
                    else
                    {
                        HelpSysLog.log.Info(Environment.NewLine + UserName + "-[END LOG FINISH GHI THOI GIAN. Ket qua: KHONG THANH CONG]");
                        PLMessageBox.ShowErrorMessage("Thực hiện không thành công");
                    }
                }
                else
                {
                    HelpSysLog.log.Info(Environment.NewLine + UserName + "-[LOG FINISH GHI THOI GIAN : KHONG DONG Y THUC HIEN]");
                }
            }
            else
            {
                if (this.ValidateInputTime())
                {
                    phieu.GIO_BAT_DAU = Convert.ToDateTime(timeEditBatDau.EditValue);
                    if (timeEditKetThuc.EditValue != null)
                        phieu.GIO_KET_THUC = Convert.ToDateTime(timeEditKetThuc.EditValue);
                    phieu.NGAY_LAM_VIEC = Convert.ToDateTime(this.txtNgayLamViec.Text);
                    TimeSpan? Tglv = new TimeSpan(0, 0, 0);
                    TimeSpan? TG_Sang = new TimeSpan(0, 0, 0);
                    TimeSpan? TG_Chieu = new TimeSpan(0, 0, 0);
                    if (Tglv != null)
                    {
                        if (phieu.GIO_BAT_DAU.Value.TimeOfDay < TimeSystem.GIO_KET_THUC_SANG.TimeOfDay)//Nếu có làm việc buổi sáng
                        {
                            TimeSpan? TG_Tre_Sang;
                            if (phieu.GIO_KET_THUC != null && phieu.GIO_KET_THUC.Value.TimeOfDay < TimeSystem.GIO_BAT_DAU_CHIEU.TimeOfDay)
                                TG_Sang = HelpDateExt.getThoiGianLamViec(timeEditBatDau.EditValue, phieu.GIO_KET_THUC);
                            else
                                TG_Sang = HelpDateExt.getThoiGianLamViec(timeEditBatDau.EditValue, TimeSystem.GIO_KET_THUC_SANG);
                            //Nếu thời gian bắt đầu lớn hơn thời gian đi trễ cho phép
                            if (Convert.ToDateTime(timeEditBatDau.EditValue).TimeOfDay > TimeSystem.GIO_BAT_DAU_SANG.AddMinutes((double)TimeSystem.THOI_GIAN_CHO_PHEP_TRE).TimeOfDay)
                            {
                                TG_Tre_Sang = HelpDateExt.getThoiGianLamViec(TimeSystem.GIO_BAT_DAU_SANG, timeEditBatDau.EditValue);
                                //Thời gian sáng = thời gian sáng - (HE_SO_TRU_LUONG * thời gian đi trễ)
                                for (int i = 0; i < TimeSystem.HE_SO_TRU_LUONG; i++)
                                    TG_Sang -= TG_Tre_Sang;
                            }
                            if (TG_Sang.Value.TotalSeconds >= 0)//Nếu chưa bị trừ hết thời gian sáng
                            {
                                phieu.THOI_GIAN_SANG = new DateTime(1970, 1, 1, TG_Sang.Value.Hours, TG_Sang.Value.Minutes, TG_Sang.Value.Seconds).TimeOfDay.ToString().Substring(0, 5);
                                Tglv = new TimeSpan(TG_Sang.Value.Hours, TG_Sang.Value.Minutes, TG_Sang.Value.Seconds);
                            }
                            //Ngược lại thì thời gian sáng bị âm
                            else
                            {
                                phieu.THOI_GIAN_SANG = new DateTime(1970, 1, 1, 0, 0, 0).TimeOfDay.ToString().Substring(0, 5);
                            }
                        }
                        else //Không làm việc buổi sáng                        
                            phieu.THOI_GIAN_SANG = string.Empty;
                        ///Tính thời gian buổi chiều
                        phieu.THOI_GIAN_CHIEU = string.Empty;
                        TimeSpan? TG_Tre_Chieu;
                        //Nếu nhân viên bắt đầu ngày làm việc từ buổi chiều
                        if (phieu.GIO_BAT_DAU != null && phieu.GIO_BAT_DAU.Value.TimeOfDay >= TimeSystem.GIO_BAT_DAU_CHIEU.TimeOfDay)
                        {
                            if (phieu.GIO_KET_THUC != null)
                            {
                                TG_Chieu = HelpDateExt.getThoiGianLamViec(phieu.GIO_BAT_DAU, phieu.GIO_KET_THUC);
                                //Nếu thời gian bắt đầu lớn hơn thời gian đi trễ cho phép
                                if (phieu.GIO_BAT_DAU > TimeSystem.GIO_BAT_DAU_CHIEU.AddMinutes((double)TimeSystem.THOI_GIAN_CHO_PHEP_TRE))
                                {
                                    TG_Tre_Chieu = HelpDateExt.getThoiGianLamViec(TimeSystem.GIO_BAT_DAU_CHIEU, phieu.GIO_BAT_DAU);
                                    //Thời gian chiều = Thời gian chiều - (HE_SO_TRU_LUONG * thời gian đi trễ)
                                    for (int i = 0; i < TimeSystem.HE_SO_TRU_LUONG; i++)
                                        TG_Chieu -= TG_Tre_Chieu;
                                }
                            }
                        }
                        else // Đã làm việc từ buổi sáng
                        {
                            if (phieu.GIO_KET_THUC != null)
                                TG_Chieu = HelpDateExt.getThoiGianLamViec(TimeSystem.GIO_BAT_DAU_CHIEU, phieu.GIO_KET_THUC);
                        }
                        //Nếu thời gian buổi chiều vẫn còn(sau khi trừ thời gian đi trễ buổi chiều)
                        if (TG_Chieu.Value.TotalSeconds >= 0)
                        {
                            phieu.THOI_GIAN_CHIEU = new DateTime(1970, 1, 1, TG_Chieu.Value.Hours, TG_Chieu.Value.Minutes, TG_Chieu.Value.Seconds).TimeOfDay.ToString().Substring(0, 5);
                            Tglv += TG_Chieu;
                        }
                        else phieu.THOI_GIAN_CHIEU = new DateTime(1970, 1, 1, 0, 0, 0).TimeOfDay.ToString().Substring(0, 5);
                        phieu.THOI_GIAN_LAM_VIEC = new DateTime(1970, 1, 1, Tglv.Value.Hours, Tglv.Value.Minutes, Tglv.Value.Seconds);
                    }
                    if (phieu.GIO_KET_THUC == null)
                    {
                        phieu.THOI_GIAN_SANG = string.Empty;
                        phieu.THOI_GIAN_CHIEU = string.Empty;
                        phieu.THOI_GIAN_LAM_VIEC = null;
                    }
                    if (phieu.GIO_BAT_DAU != null && phieu.GIO_BAT_DAU.Value.TimeOfDay > TimeSystem.GIO_KET_THUC_SANG.TimeOfDay)
                        phieu.THOI_GIAN_SANG = string.Empty;
                    if (phieu.GIO_KET_THUC != null && phieu.GIO_KET_THUC.Value.TimeOfDay < TimeSystem.GIO_BAT_DAU_CHIEU.TimeOfDay)
                        phieu.THOI_GIAN_CHIEU = string.Empty;
                    if (phieu.IS_CHAM_CONG == "Y") phieu.IS_CHAM_CONG = "N";
                    DATimeInOut.Instance.Update(phieu);
                    if (DATimeInOut.Instance.UpdatePhieu(phieu))
                    {
                        try
                        {
                            if (ReFindData != null) ReFindData();
                            PLGUIUtil.ClosePhieu(this, true);
                        }
                        catch { }
                    }
                    else
                        PLMessageBox.ShowErrorMessage("Thực hiện không thành công");
                }
            }
        }
        #endregion

        #region Validate
        private bool ValidateData()
        {
            return true;
        }
        private void InitValidation()
        {
            //NOOP
        }
        public bool CalTime(object gioStart, object gioEnd)
        {
            try
            {
                if (gioEnd != null)
                {

                    TimeSpan timeOfDay = Convert.ToDateTime(gioStart).TimeOfDay;
                    TimeSpan span2 = Convert.ToDateTime(gioEnd).TimeOfDay;
                    if (timeOfDay.Hours == span2.Hours
                        && timeOfDay.Minutes == span2.Minutes
                        && (int)timeOfDay.Seconds == (int)span2.Seconds)
                        return true;
                    TimeSpan span3 = span2 - timeOfDay;
                    if (span3.ToString().Contains("-"))
                        return false;
                }
            }
            catch
            {
            }
            return true;
        }
        private bool ValidateInputTime()
        {
            bool flag = true;
            Error.ClearErrors();
            bool time = this.CalTime(timeEditBatDau.EditValue, timeEditKetThuc.EditValue);
            if (time == false)
            {
                Error.SetError(timeEditBatDau, "Thời gian kết thúc nhỏ hơn thời gian bắt đầu!");
                Error.SetError(this.timeEditKetThuc, "Thời gian kết thúc nhỏ hơn thời gian bắt đầu!");
                flag = false;
            }
            return flag;
        }
        private string Get_IPAddress()
        {
            string hostName = Dns.GetHostName();
            string ip = "";
            IPAddress[] ip_add = null;
            IPHostEntry local = Dns.GetHostByName(hostName);
            if (local != null)
            {
                ip_add = local.AddressList;
                ip = ip_add[0].ToString();
            }
            return ip;
        }
        #endregion
    }
}
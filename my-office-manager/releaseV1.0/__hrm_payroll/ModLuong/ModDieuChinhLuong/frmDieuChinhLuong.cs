using System;
using System.Data;
using System.Windows.Forms;
using DAO;
using DTO;
using ProtocolVN.Framework.Core;
using ProtocolVN.Framework.Win;
using ProtocolVN.DanhMuc;
using DevExpress.XtraEditors.DXErrorProvider;
using ProtocolVN.App.Office;



namespace office
{
    public partial class frmDieuChinhLuong : XtraFormPL ,IFormChild
    {
        #region Các khai báo biến 
       
        private DXErrorProvider Error = null;
        private bool? IsAdd;
        private bool _IsNangLuong;
        private long IDKey;
        private DateTime TuNgay;
        private DODieuChinhLuong dto;

        public delegate void AfterUpdateSuccessfully(DODieuChinhLuong doLuong);
        public event AfterUpdateSuccessfully _AfterUpdateSuccessfully;

        #endregion

        #region Các hàm khởi tạo    

        public frmDieuChinhLuong(object ID, DateTime Tungay,bool ? IsAdd,bool IsNangLuong)
        {
            InitializeComponent();
            this.IsAdd = IsAdd;
            this._IsNangLuong = IsNangLuong;
            this.TuNgay = Tungay;
            if(ID.ToString()!="-2")
                this.IDKey = HelpNumber.ParseInt64(ID);
            InitControl();
            InitData();
            InitEnabledControl();
            InitNghiepVu();
            InitButtonImage();
            HelpXtraForm.SetFix(this);
            btLuu.Image = FWImageDic.SAVE_IMAGE16;
            btDong.Image = FWImageDic.CLOSE_IMAGE16;
        }

        public frmDieuChinhLuong() : this("-2", DateTime.Now, true,false) { }

        private void frmDieuChinhLuong_Load(object sender, EventArgs e)
        {
            Error = new DXErrorProvider();
            //
            ApplyFormatAction.applyElement(clLuongCT.Properties, 0);
            //clLuongCT.Properties.Precision = 0;
            //
            ApplyFormatAction.applyElement(clPhanTram.Properties, 0);
            //clPhanTram.Properties.Precision = 0;
            //
            ApplyFormatAction.applyElement(clLuongTV.Properties, 0);
            //clLuongTV.Properties.Precision = 0;
            //    
            ApplyFormatAction.applyElement(clLuongBTG.Properties, 0);
            //clLuongBTG.Properties.Precision = 0;
            //
            ApplyFormatAction.applyElement(clLuongTC.Properties, 0);
            //clLuongTC.Properties.Precision = 0;
            HelpXtraForm.SetCloseForm(this, btDong, IsAdd);
            HelpXtraForm.SetFix(this);
        }

        #region IFormChild Members

        public void InitControl()
        {
            bool? Visible = true;
            if (this.IsAdd==true) Visible = true;
            else if (this.IsAdd==false) Visible = false;
            else Visible = null;
            AppCtrl.InitTreeChonNhanVien_Choice1(TenNhanVien, IsAdd);
        }

        public void InitData()
        {
            switch (this.IsAdd)
            {
                case true:
                    rdToanThoiGian.Checked = true;
                    rdChinhThuc.Checked = true;
                    HelpDate.SetDateEdit(this.DateTuNgay, HelpDB.getDatabase().GetSystemCurrentDateTime());
                    break;
                case null:
                case false :
                    TenNhanVien._setSelectedID(IDKey);
                    DateTuNgay.DateTime = this.TuNgay;
                    DataSet ThongTin = DADieuChinhLuong.Ins.IsTonTai(IDKey, this.TuNgay);
                    dto = new DODieuChinhLuong();
                    dto.HINH_THUC = ThongTin.Tables[0].Rows[0]["HINH_THUC"].ToString();
                    dto.NV_ID = IDKey;
                    dto.TU_NGAY = this.TuNgay;
                    dto.IS_THU_VIEC = ThongTin.Tables[0].Rows[0]["IS_THU_VIEC"].ToString();
                    dto.PHAN_TRAM = (int) PhanTram_ThuViec(ThongTin.Tables[0].Rows[0]["PHAN_TRAM"], dto.IS_THU_VIEC);
                    if (isNumber(ThongTin.Tables[0].Rows[0]["MUC_LUONG"].ToString()))
                        dto.MUC_LUONG = HelpNumber.ParseDecimal(ThongTin.Tables[0].Rows[0]["MUC_LUONG"].ToString());
                    BatTatRadio(dto, int.Parse(dto.HINH_THUC), dto.IS_THU_VIEC);
                    break;
            }
            //if (this._IsNangLuong)
                //HelpDate.SetDateEdit(this.DateTuNgay, HelpDB.getDatabase().GetSystemCurrentDateTime());
        }

        public void InitEnabledControl()
        {
            switch (this.IsAdd)
            {
                case true: 
                    break;
                case null: 
                    btLuu.Visible = false;
                    break;
                case false:
                    this.DateTuNgay.Enabled = false;
                    this.TenNhanVien.Enabled = false;
                    break;
            }
            if (this._IsNangLuong)
                this.DateTuNgay.Enabled = true;
        }

        public void InitNghiepVu()
        {

        }

        public void InitButtonImage()
        {
            btLuu.Image = FWImageDic.ADD_IMAGE20;
            btDong.Image = FWImageDic.CLOSE_IMAGE20;
        }
        #endregion

        #endregion

        #region Các hàm xử lý nút 

        private void btLuu_Click(object sender, EventArgs e)
        {
            DODieuChinhLuong dto = new DODieuChinhLuong();
            dto.NV_ID = TenNhanVien._getSelectedID();
            dto.IS_THU_VIEC = "N";
            if (this.IsValidate())
            {
                dto.TU_NGAY = DateTuNgay.DateTime;
                dto.HINH_THUC = getHinhThuc();
                dto.IS_THU_VIEC = (rdChinhThuc.Checked) ? "N" : "Y";
                dto.PHAN_TRAM = (rdThuViec.Checked) ? (int)clPhanTram.Value : 1;
                dto.MUC_LUONG = getLuongCoBan();
                try
                {
                    if(this._IsNangLuong)
                    {
                        DADieuChinhLuong.Ins.ThemDong(dto);
                        HelpXtraForm.CloseFormNoConfirm(this);
                        return;
                    }
                    switch(this.IsAdd)
                    {
                        case true :
                            if (DADieuChinhLuong.Ins.ThemDong(dto))HelpXtraForm.CloseFormNoConfirm(this);   
                            break;
                        case false :
                            if (DADieuChinhLuong.Ins.CapNhatDong(dto)) {
                                if (_AfterUpdateSuccessfully != null) _AfterUpdateSuccessfully(dto);
                                HelpXtraForm.CloseFormNoConfirm(this);
                            } 
                            break;
                    }
                }
                catch (Exception ex)
                {

                    PLException.AddException(ex);
                }
            }
        }
        
        #endregion

        #region Phần mở rộng 
        private bool isNumber(string str)
        {
            string er = string.Empty;
            decimal Kq = 0;
            try{
                Kq = HelpNumber.ParseDecimal(str.ToString());
            }
            catch (Exception ex)
            {
                er = ex.Message;
            }
            if (er == string.Empty)
                return true;
            return false;
        }
        private decimal PhanTram_ThuViec(object obj, string IsThuViec)
        {
            decimal Kq = 0;
            if (IsThuViec == "N")
                Kq = -1;
            else Kq = 1;

            string er = string.Empty;
            try
            {
                Kq = HelpNumber.ParseDecimal(obj.ToString());
            }
            catch (Exception ex)
            {
                er = ex.Message;
            }
            return Kq;
        }
        public void BatTatRadio(DODieuChinhLuong dto, int HinhThuc, string IsThuViec)
        {
            if (HinhThuc == 0)
            {
                rdToanThoiGian.Checked = true;
                if (IsThuViec == "Y")
                {
                    rdThuViec.Checked = true;
                    clLuongTV.Value = dto.MUC_LUONG;
                    clPhanTram.Value = dto.PHAN_TRAM;
                }
                else
                {
                    rdChinhThuc.Checked = true;
                    clLuongCT.Value = dto.MUC_LUONG;
                }
            }
            else if (HinhThuc == 1)
            {
                rdBanThoiGian.Checked = true;
                clLuongBTG.Value = dto.MUC_LUONG;
            }
            else if (HinhThuc == 2)
            {
                rdKhongLuong.Checked = true;
            }
            else
            {
                rdTroCap.Checked = true;
                clLuongTC.Value = dto.MUC_LUONG;
            }
        }
        #endregion

        #region Phần giữ chỗ 

        #region Xu ly radio 
        private void rdThuViec_CheckedChanged(object sender, EventArgs e)
        {
            if (rdThuViec.CheckState == CheckState.Checked)
            {
                rdChinhThuc.Checked = false;
                clPhanTram.Enabled = true;
                clLuongTV.Enabled = true;
                clLuongCT.EditValue = null;
                clLuongCT.Enabled = false;
                if (dto != null && dto.MUC_LUONG != null
                    && int.Parse(dto.HINH_THUC) == 0 && dto.IS_THU_VIEC == "Y" && dto.PHAN_TRAM != null)
                {
                    clLuongTV.Value = dto.MUC_LUONG;
                    clPhanTram.Value = dto.PHAN_TRAM;
                }
            }
        }
        private void rdChinhThuc_CheckedChanged(object sender, EventArgs e)
        {
            if (rdChinhThuc.CheckState == CheckState.Checked)
            {
                rdThuViec.Checked = false;
                clLuongTV.EditValue = null;
                clPhanTram.EditValue = null;
                clLuongTV.Enabled = false;
                clPhanTram.Enabled = false;
                clLuongCT.Enabled = true;
                if (dto != null && int.Parse(dto.HINH_THUC) == 0 
                    && dto.IS_THU_VIEC != "Y" && dto.MUC_LUONG != null) clLuongCT.Value = dto.MUC_LUONG;
            }
            if(!rdChinhThuc.Enabled)
                clLuongCT.Enabled= false;
        }
        private void rdToanThoiGian_CheckedChanged(object sender, EventArgs e)
        {
            if (rdToanThoiGian.CheckState== CheckState.Checked)
            {
                InitEnableRadioControl(true, false, false, false);
                clPhanTram.Enabled = false;
                clLuongTV.Enabled = false;
                rdBanThoiGian.TabStop = rdTroCap.TabStop = rdKhongLuong.TabStop = false;
                rdChinhThuc.TabStop = true;
            }
        }
        private void rdTroCap_CheckedChanged(object sender, EventArgs e)
        {
            if (rdTroCap.CheckState == CheckState.Checked)
            {
                InitEnableRadioControl(false, false, true, false);
                rdChinhThuc.Checked = false;
                if (dto != null && int.Parse(dto.HINH_THUC) == 3 && dto.MUC_LUONG != null) clLuongTC.Value = dto.MUC_LUONG;
                rdToanThoiGian.TabStop = rdBanThoiGian.TabStop = rdKhongLuong.TabStop = false;
            }
        }
        private void rdBanThoiGian_CheckedChanged(object sender, EventArgs e)
        {
            if (rdBanThoiGian.CheckState == CheckState.Checked)
            {
                InitEnableRadioControl(false, true, false, false);
                rdChinhThuc.Checked = false;
                if (dto != null && int.Parse(dto.HINH_THUC) == 1 && dto.MUC_LUONG != null) clLuongBTG.Value = dto.MUC_LUONG;
                rdToanThoiGian.TabStop = rdTroCap.TabStop = rdKhongLuong.TabStop = false;
            }
        }
        private void rdKhongLuong_CheckedChanged(object sender, EventArgs e)
        {
            if (rdKhongLuong.CheckState == CheckState.Checked)
            {
                InitEnableRadioControl(false, false, false, true);
                rdChinhThuc.Checked = false;
                rdToanThoiGian.TabStop = rdBanThoiGian.TabStop = rdTroCap.TabStop = false;
            }
        }
        private void InitEnableRadioControl(bool ToanThoiGian, bool BanThoiGian, bool TroCap, bool KhongLuong)
        {
            rdToanThoiGian.Checked = ToanThoiGian;
            rdBanThoiGian.Checked = BanThoiGian;
            rdKhongLuong.Checked = KhongLuong;
            rdTroCap.Checked = TroCap;
            EnableToanThoiGian(ToanThoiGian);
            EnableBanThoiGian(BanThoiGian);
            EnableTroCap(TroCap);
            EnableKhongLuong(KhongLuong);
        }
        private void EnableToanThoiGian(bool IsCheck)
        {
            rdChinhThuc.Enabled = IsCheck;
            rdThuViec.Enabled = IsCheck;
            clLuongCT.Enabled = IsCheck;
            clLuongTV.Enabled = IsCheck;
            clPhanTram.Enabled = IsCheck;
            if (!IsCheck)
            {
                rdChinhThuc.Checked = true;
                clLuongCT.EditValue = null;
                clLuongTV.EditValue = null;
                clPhanTram.EditValue = null;
            }
        }
        private void EnableBanThoiGian(bool IsCheck)
        {
            clLuongBTG.Enabled = IsCheck;
            if (!IsCheck)
            {
                clLuongBTG.EditValue = null;
            }
        }
        private void EnableTroCap(bool IsCheck)
        {
            clLuongTC.Enabled = IsCheck;
            clLuongTC.EditValue = null;
        }
        private void EnableKhongLuong(bool IsCheck)
        {

        }
        private string getHinhThuc()
        {
            if (rdToanThoiGian.Checked)
                return "0";
            if (rdBanThoiGian.Checked)
                return "1";
            if (rdKhongLuong.Checked)
                return "2";
            return "3";
        }
        private string getThuViec()
        {
            if (rdChinhThuc.Checked)
                return "N";
            return "Y";
        }
        private decimal getLuongCoBan()
        {
            if (rdToanThoiGian .Checked && rdChinhThuc.Checked) return clLuongCT.Value;
            if (rdToanThoiGian.Checked&& rdThuViec.Checked) return clLuongTV.Value;
            if (rdBanThoiGian.Checked) return clLuongBTG.Value;
            if (rdTroCap.Checked) return clLuongTC.Value;
            return 0;
        }
        #endregion

        #endregion

        #region Phần xử lý Validation 

        public bool IsValidate()
        {
            Error.ClearErrors();
            HelpInputData.ShowRequiredError(Error, new object[] {
                TenNhanVien,"Tên nhân viên",
                DateTuNgay,"Từ ngày",
            });        
            if (clLuongCT.Enabled == true && (clLuongCT.Value < 1 || clLuongCT.Value > 99999999999999)) //Max dưới db decimal 15
                Error.SetError(clLuongCT, "Vui lòng vào thông tin \"Lương\" từ 1 đến 99.999.999.999.999!");
            if (clPhanTram.Enabled == true)
            {
                if(clPhanTram.Value < 1 || clPhanTram.Value > 100){
                    Error.SetError(clPhanTram, "Vui lòng vào thông tin \"Phần trăm\" từ 1 đến 100!");
                }
                if (clLuongTV.Value < 1 || clLuongTV.Value > 99999999999999) //Max dưới db decimal 15
                    Error.SetError(clLuongTV, "Vui lòng vào thông tin \"Lương\" từ 1 đến 99.999.999.999.999!");
            }
            if (clLuongBTG.Enabled &&
                (clLuongBTG.Value < 1 || clLuongBTG.Value > 99999999999999))//Max dưới db decimal 15
                Error.SetError(clLuongBTG, "Vui lòng vào thông tin \"Lương\" từ 1 đến 99.999.999.999.999!");
            if (clLuongTC.Enabled &&
                clLuongTC.Value < 1 || clLuongTC.Value > 99999999999999)//Max dưới db decimal 15
                Error.SetError(clLuongTC, "Vui lòng vào thông tin \"Mức trợ cấp\" từ 1 đến 99.999.999.999.999!");
            if (_IsNangLuong && DateTuNgay.DateTime <= TuNgay)
                Error.SetError(DateTuNgay, "Ngày điều chỉnh lương mới phải lớn hơn ngày điều chỉnh lương hiện tại!");
            return !Error.HasErrors ;
        }

        #endregion        
        
    }
}
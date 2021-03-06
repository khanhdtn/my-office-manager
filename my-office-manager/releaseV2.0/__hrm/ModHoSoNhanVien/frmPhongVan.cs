using System;
using System.Windows.Forms;
using DAO;
using DevExpress.XtraEditors;
using DTO;
using ProtocolVN.Framework.Core;
using ProtocolVN.Framework.Win;
using DA;
using ProtocolVN.Framework.Dev.Open;


namespace pl.office.form
{
    public partial class frmPhongVan : XtraFormPL
    {
        #region 0.0.Phần khai báo các khởi tạo của form
        public frmPhongVan()
        {
            InitializeComponent();
        }
        public frmPhongVan(long ID, long DTD_ID, TrangThaiForm TTForm)
        {
            InitializeComponent();
            this.IDKey = ID;
            this.DTD_ID = DTD_ID;
            this.TForm = TTForm;
            this.InitControl();
            this.InitData();
            this.InitEnabledControl();
            this.InitNghiepVu();
            this.InitButtonImage();
        }
        #endregion

        #region 1.0.Danh sách biến toàn cục
        private TrangThaiForm TForm = TrangThaiForm.Add;
        private long IDKey;
        private long DTD_ID; 
        DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider err = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider();

        #endregion

        #region 2.0.Hàm khởi tạo
        private void InitControl()
        {
            PLTinhTrangHoSo._init("DM_TINH_TRANG_HO_SO", "NAME", "ID");
            this.InitNgayKetThuc();
            Uncategory.setEnterAsTab(this);
        }
        private void InitData()
        {
            if (TForm == TrangThaiForm.Add)
            {
                //
            }
            else if (TForm == TrangThaiForm.Update)
            {
                setThongTinHenPhongVan(DAHenPhongVan.getHenPhongVan_NOTD( this.IDKey));
            }
            else if (TForm == TrangThaiForm.Show)
            {
                btn_Luu.Enabled = false;
                setThongTinHenPhongVan(DAHenPhongVan.getHenPhongVan_NOTD( this.IDKey));
            }
            else //Other
            {
                HoTen.Text = DAResume.getNameUngVien(IDKey);
            }

            if (TForm == TrangThaiForm.Update || TForm == TrangThaiForm.Show)
            {
                //
            }
        }
        private void InitEnabledControl()
        {
            if (TForm == TrangThaiForm.Add)
            {
                chk_Cho.Checked = true;
                KQ_ChoGhiChu.Text = "";
            }
            else if (TForm == TrangThaiForm.Update)
            {
                HoTen.Properties.ReadOnly = false;
            }
            else if (TForm == TrangThaiForm.Show)
            {
                btn_Luu.Enabled = false;
            }
            else //Other
            {
                HoTen.Text = DAResume.getNameUngVien(IDKey);
                chk_Cho.Checked = true;
                KQ_ChoGhiChu.Text = "";
            }

            PLTinhTrangHoSo._setSelectedID(DAResume.getTinhTrangHoSo(IDKey));

        }
        private void InitNghiepVu()
        {

        }
        private void InitButtonImage()
        {
            btn_Luu.Image = FWImageDic.SAVE_IMAGE16;
            btnDong.Image = FWImageDic.CLOSE_IMAGE16;
        }
        #endregion

        #region 3.0.Xử lý sự kiện (Lưu,Thêm,Load Form,Dong Form)
        private void btn_Luu_Click(object sender, EventArgs e)
        {
            if (IsValidate())
            {
                #region Xử lý phần Hẹn phỏng vấn
                DOHenPhongVan HenPhongVan = this.getThongTinHenPhongVan();
                if (TForm == TrangThaiForm.Add || TForm == TrangThaiForm.Other)
                {
                    if (DAHenPhongVan.ExistRecord(HenPhongVan.R_ID)) //Ton tai
                    {
                        PLMessageBox.ShowNotificationMessage("Nhân viên này đã được hẹn phỏng vấn !!!!");
                        return;
                    }
                    //Không tồn tại
                    if (KQ_KetQuaDat.CheckState == CheckState.Checked)
                    {
                        DAHenPhongVan.InsertDat(HenPhongVan);
                    }
                    else if (KQ_KetQuaKhongDat.CheckState == CheckState.Checked)
                        DAHenPhongVan.InsertKhongDat(HenPhongVan);
                    else
                    {
                        DAHenPhongVan.InsertChoKetQua(HenPhongVan);
                    }
                }
                else //Đã tồn tại cần update
                {
                    DAHenPhongVan.Update(HenPhongVan);
                }
                #endregion

                #region Xử lý cập nhật ngày cập nhật cho bảng RESUME
                DAResume.Update(IDKey, PLTinhTrangHoSo._getSelectedID(), DateTime.Today);
                #endregion

                this.Close();
            }
        }
        private void btnDong_Click(object sender, EventArgs e)
        {
            PLCtrl.DongForm(this);
        }
        private void frmPhongVan_Load(object sender, EventArgs e)
        {
            HelpXtraForm.SetFix(this);
        }
        #endregion

        #region 4.0.Phần mở rộng

        private string getUngVienXacNhan()
        {
            if (HPV_RThamDu.CheckState == CheckState.Checked)
                return "1";
            if (HPV_RKhongThamDu.CheckState == CheckState.Checked)
                return "2";
            if (HPV_RChuaXacNhan.CheckState == CheckState.Checked)
                return "3";
            if (HPV_RXinChuyenNgayXN.CheckState == CheckState.Checked)
                return "4";
            return "";
        }
        private string getUngVienThamDu()
        {
            if (HPV_RCoMat.CheckState == CheckState.Checked)
                return "1";
            if (HPV_RVangMat.CheckState == CheckState.Checked)
                return "2";
            return "";

        }
        private DOHenPhongVan getThongTinHenPhongVan()
        {
            long Id = (TForm == TrangThaiForm.Update || TForm == TrangThaiForm.Other) ? IDKey : -1;
            DOHenPhongVan HenPhongVan = new DOHenPhongVan();
            HenPhongVan.ID = Id;
            HenPhongVan.NGAY_GIO_PHONG_VAN = new DateTime(HPV_NgayPV.DateTime.Year, HPV_NgayPV.DateTime.Month, HPV_NgayPV.DateTime.Day,
                                HPV_GioPV.Time.Hour, HPV_GioPV.Time.Minute, HPV_GioPV.Time.Second
                            );
            HenPhongVan.VONG_PHONG_VAN = (int)HPV_VongPV.Value;
            HenPhongVan.LAN_MOI_PHONG_VAN = (int)HPV_LanPV.Value;
            HenPhongVan.MOI_PHONG_VAN = (HPV_MoiPV.CheckState == CheckState.Checked) ? "Y" : "N";
            HenPhongVan.UNG_VIEN_XAC_NHAN = getUngVienXacNhan();
            HenPhongVan.UNG_VIEN_XAC_NHAN_GHI_CHU = HPV_UVXNGhiChu.Text.Trim();
            HenPhongVan.THAM_DU = getUngVienThamDu();
            HenPhongVan.THAM_DU_GHI_CHU = HPV_ThamDuGhiChu.Text;
            HenPhongVan.KET_QUA = getKetQua();
            HenPhongVan.KET_QUA_GHI_CHU = getKetQuaGhiChu();
            HenPhongVan.UNG_VIEN_DA_CHAP_NHAN = (KQ_DaChapNhan.CheckState == CheckState.Checked) ? "Y" : "N";
            HenPhongVan.THOI_GIAN_LAM_VIEC = getThoiGianLamViec();
            HenPhongVan.THONG_BAO_KET_QUA = getThongBaoKetQua();
            if (KQ_NgayBatDau.DateTime.Equals("") == false)
                HenPhongVan.NGAY_BAT_DAU = KQ_NgayBatDau.DateTime;
            else
                HenPhongVan.NGAY_BAT_DAU = new DateTime(1900, 1, 1);
            HenPhongVan.MUC_LUONG = KQ_MucLuong.Value;
            HenPhongVan.R_ID = IDKey;
            HenPhongVan.THONG_TIN_KHAC = ThongTinKhac.Text;

            //Them
            //HenPhongVan.ISHL_TV_TT = "";
            //HenPhongVan.SO_NGAY = (long) KQ_SoNgay.Value;
            //HenPhongVan.DEN_NGAY = KQ_NgayBatDau.DateTime.AddDays(17);
            return HenPhongVan;

        }

        private void setThongTinHenPhongVan(DOHenPhongVan HenPhongVan)
        {
            //Page 1
            HoTen.Text = DAResume.getNameUngVien(IDKey);
            //Page 2
            HPV_NgayPV.DateTime = HenPhongVan.NGAY_GIO_PHONG_VAN.Date;
            HPV_GioPV.Time = new DateTime(
                HenPhongVan.NGAY_GIO_PHONG_VAN.Date.Year,
                HenPhongVan.NGAY_GIO_PHONG_VAN.Date.Month,
                HenPhongVan.NGAY_GIO_PHONG_VAN.Date.Day,
                HenPhongVan.NGAY_GIO_PHONG_VAN.Hour,
                HenPhongVan.NGAY_GIO_PHONG_VAN.Minute,
                HenPhongVan.NGAY_GIO_PHONG_VAN.Second
            );
            HPV_VongPV.Value = (decimal)HenPhongVan.VONG_PHONG_VAN;
            HPV_LanPV.Value = (decimal)HenPhongVan.LAN_MOI_PHONG_VAN;
            HPV_MoiPV.CheckState = (HenPhongVan.MOI_PHONG_VAN == "Y") ? CheckState.Checked : CheckState.Unchecked;
            HPV_UVXNGhiChu.Text = HenPhongVan.UNG_VIEN_XAC_NHAN_GHI_CHU;
            HPV_ThamDuGhiChu.Text = HenPhongVan.THAM_DU_GHI_CHU;
            this.setNhomUngVienXacNhan(HenPhongVan.UNG_VIEN_XAC_NHAN);
            this.setNhomThamDu(HenPhongVan.THAM_DU);

            //Page 3
            if (HenPhongVan.KET_QUA == "1")
            {
                KQ_KetQuaDat.CheckState = CheckState.Checked;
                KQ_KetQuaDat.Focus();
                KQ_NgayBatDau.DateTime = (DateTime)HenPhongVan.NGAY_BAT_DAU;
                KQ_MucLuong.Value = HenPhongVan.MUC_LUONG;
                if (HenPhongVan.THOI_GIAN_LAM_VIEC == "Y")
                    KQ_ToanThoiGian.CheckState = CheckState.Checked;
                if (HenPhongVan.THOI_GIAN_LAM_VIEC == "N")
                    KQ_BanThoiGian.CheckState = CheckState.Checked;
                KQ_GhiChuDat.Text = HenPhongVan.KET_QUA_GHI_CHU;
                KQ_DaThongBaoDat.CheckState = (HenPhongVan.THONG_BAO_KET_QUA == "Y") ? CheckState.Checked : CheckState.Unchecked;
                KQ_DaChapNhan.CheckState = (HenPhongVan.UNG_VIEN_DA_CHAP_NHAN == "Y") ? CheckState.Checked : CheckState.Unchecked;
                //KQ_SoNgay.EditValue = HenPhongVan.SO_NGAY;
                //if(HenPhongVan.DEN_NGAY.Equals(new DateTime(1900,1,1)))
                //    KQ_NgayKetThuc.EditValue = null;
                //else KQ_NgayKetThuc.EditValue =  HenPhongVan.DEN_NGAY ;
            }
            else
            {
                KQ_KetQuaKhongDat.CheckState = CheckState.Checked;
                KQ_DaThongBaoKhongDat.CheckState = (HenPhongVan.THONG_BAO_KET_QUA == "Y") ? CheckState.Checked : CheckState.Unchecked;
                KQ_GhiChuKhongDat.Text = HenPhongVan.KET_QUA_GHI_CHU;
            }
            PLTinhTrangHoSo._setSelectedID(DAResume.getTinhTrangHoSo(IDKey));
            ThongTinKhac.Text = HenPhongVan.THONG_TIN_KHAC;
        }
        private void setNhomUngVienXacNhan(string value)
        {
            switch (value)
            {
                case "1": HPV_RThamDu.CheckState = CheckState.Checked; break;
                case "2": HPV_RKhongThamDu.CheckState = CheckState.Checked; break;
                case "3": HPV_RChuaXacNhan.CheckState = CheckState.Checked; break;
                case "4": HPV_RXinChuyenNgayXN.CheckState = CheckState.Checked; break;
            }
        }
        private void setNhomThamDu(string value)
        {
            switch (value)
            {
                case "1": HPV_RCoMat.CheckState = CheckState.Checked; break;
                case "2": HPV_RVangMat.CheckState = CheckState.Checked; break;
            }
        }
        private string getThoiGianLamViec()
        {
            if (KQ_KetQuaDat.Checked && KQ_ToanThoiGian.Checked)
                return "Y";
            if (KQ_KetQuaDat.Checked && KQ_BanThoiGian.Checked)
                return "N";
            return "";
        }
        private string getKetQua()
        {
            if (KQ_KetQuaDat.Checked)
                return "1";
            else if (KQ_KetQuaKhongDat.Checked)
                return "2";
            else return "3";
        }
        private string getKetQuaGhiChu()
        {
            if (KQ_KetQuaDat.Checked)
                return KQ_GhiChuDat.Text.Trim();
            else if (KQ_KetQuaKhongDat.Checked)
                return KQ_GhiChuKhongDat.Text.Trim();
            else return KQ_ChoGhiChu.Text.Trim();
        }
        private string getThongBaoKetQua()
        {
            if (KQ_KetQuaDat.Checked)
            {
                return (KQ_DaThongBaoDat.Checked) ? "Y" : "N";
            }
            else if (KQ_KetQuaKhongDat.Checked)
            {
                return (KQ_DaThongBaoKhongDat.Checked) ? "Y" : "N";
            }
            else return "";
        }
        #endregion

        #region 5.0.Phần giữ chỗ
        #region 5.0.1.Xử lý radio lựa chọn
        private void KQ_KetQuaDat_CheckedChanged(object sender, EventArgs e)
        {
            if (KQ_KetQuaDat.CheckState == CheckState.Checked)
            {
                KQ_KetQuaKhongDat.Checked = false;
                chk_Cho.Checked = false;
            }

            this.EnabledDat(true);
            this.EnabledKhongDat(false);
            this.EnabledCho(false);
        }
        private void KQ_KetQuaKhongDat_CheckedChanged(object sender, EventArgs e)
        {
            if (KQ_KetQuaKhongDat.CheckState == CheckState.Checked)
            {
                KQ_KetQuaDat.Checked = false;
                chk_Cho.Checked = false;
            }
            this.EnabledDat(false);
            this.EnabledKhongDat(true);
            this.EnabledCho(false);

        }
        private void KQ_KetQuaCho_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_Cho.CheckState == CheckState.Checked)
            {
                KQ_KetQuaDat.Checked = false;
                KQ_KetQuaKhongDat.Checked = false;
            }
            this.EnabledDat(false);
            this.EnabledKhongDat(false);
            this.EnabledCho(true);

        }

        private void KQ_BanThoiGian_CheckedChanged(object sender, EventArgs e)
        {
            if (KQ_BanThoiGian.CheckState == CheckState.Checked)
                KQ_ToanThoiGian.Checked = false;
            else
                KQ_ToanThoiGian.Checked = true;

        }
        private void KQ_ToanThoiGian_CheckedChanged(object sender, EventArgs e)
        {
            if (KQ_ToanThoiGian.CheckState == CheckState.Checked)
                KQ_BanThoiGian.Checked = false;
            else
                KQ_BanThoiGian.Checked = true;
        }
        private void HPV_RThamDu_CheckedChanged(object sender, EventArgs e)
        {
            ProtocolVN.Framework.Win.PLCheckEdit radio = (PLCheckEdit)sender;
            if (radio.CheckState == CheckState.Checked)
            {

                if (radio == HPV_RThamDu)
                {
                    HPV_RKhongThamDu.Checked = HPV_RChuaXacNhan.Checked = HPV_RXinChuyenNgayXN.Checked = false;
                }
                else if (radio == HPV_RKhongThamDu)
                {

                    HPV_RThamDu.Checked = HPV_RChuaXacNhan.Checked = HPV_RXinChuyenNgayXN.Checked = false;
                }
                else if (radio == HPV_RChuaXacNhan)
                {

                    HPV_RKhongThamDu.Checked = HPV_RThamDu.Checked = HPV_RXinChuyenNgayXN.Checked = false;
                }
                else
                {
                    HPV_RKhongThamDu.Checked = HPV_RChuaXacNhan.Checked = HPV_RThamDu.Checked = false;
                }

            }

        }
        private void HPV_RCoMat_CheckedChanged(object sender, EventArgs e)
        {
            if (HPV_RCoMat.CheckState == CheckState.Checked)
            {
                HPV_RVangMat.Checked = false;
            }
        }
        private void HPV_RVangMat_CheckedChanged(object sender, EventArgs e)
        {
            if (HPV_RVangMat.CheckState == CheckState.Checked)
            {
                HPV_RCoMat.Checked = false;

            }
        }
        private void GioPhongVan_Click(object sender, EventArgs e)
        {
            this.HPV_GioPV.Properties.Mask.EditMask = "HH:mm ";
        }
        private void GioPhongVan_KeyUp(object sender, KeyEventArgs e)
        {
            int temp = e.KeyValue;
            if (temp == 46 || temp == 110)
                HPV_GioPV.Properties.Mask.EditMask = "\"\"";
            else
                HPV_GioPV.Properties.Mask.EditMask = "HH:mm ";
        }

        private void EnabledDat(bool Check)
        {
            KQ_NgayBatDau.Enabled = Check;
            KQ_MucLuong.Enabled = Check;
            KQ_GhiChuDat.Enabled = Check;
            KQ_ToanThoiGian.Enabled = Check;
            KQ_BanThoiGian.Enabled = Check;
            KQ_DaThongBaoDat.Enabled = Check;
            KQ_DaChapNhan.Enabled = Check;
            KQ_SoNgay.Enabled = Check;
            KQ_NgayKetThuc.Enabled = Check;
            KQ_ToanThoiGian.Checked = true;
            if (!Check)
            {
                KQ_SoNgay.EditValue = null;
                KQ_NgayKetThuc.EditValue = null;
                KQ_NgayBatDau.EditValue = null;
                KQ_MucLuong.EditValue = null;
                KQ_DaChapNhan.Checked = false;
                KQ_DaThongBaoDat.Checked = false;
                KQ_GhiChuDat.Text = "";
            }
        }
        private void EnabledKhongDat(bool Check)
        {
            KQ_DaThongBaoKhongDat.Enabled = Check;
            KQ_GhiChuKhongDat.Enabled = Check;
            if (!Check)
            {
                KQ_GhiChuKhongDat.Text = "";
                KQ_DaThongBaoKhongDat.Checked = false;
            }
        }
        private void EnabledCho(bool Check)
        {
            KQ_ChoGhiChu.Enabled = Check;
            KQ_ChoGhiChu.Text = "";
        }

        #endregion
        #region 5.0.2.RefeshForm
        private void RefeshForm()
        {
            PLTinhTrangHoSo._setSelectedID(-1);
            HPV_GioPV.EditValue = null;
            HPV_LanPV.EditValue = 1;
            HPV_NgayPV.EditValue = null;
            HPV_MoiPV.Checked = false;
            HPV_ThamDuGhiChu.Text = "";
            HPV_UVXNGhiChu.Text = "";
            HPV_RThamDu.Checked = true;
            chk_Cho.Checked = true;
            KQ_ChoGhiChu.Text = "";
            ThongTinKhac.Text = "";
        }
        #endregion
        #endregion

        #region 6.0.Kiểm tra hợp lệ khi lưu
        public bool IsValidate()
        {
            err.ClearErrors();
            bool flag = true;
            if (HPV_LanPV.Value <= 0)
            {
                err.SetError(HPV_LanPV, "Vui lòng chọn lại lần phỏng vấn !");
                flag = false;
            }
            if (HPV_VongPV.Value <= 0)
            {
                err.SetError(HPV_VongPV, "Vui lòng chọn lại vòng phỏng vấn !");
                flag = false;
            }
            if (HPV_NgayPV.EditValue == null)
            {
                err.SetError(HPV_NgayPV, "Vui lòng nhập thông tin ngày phỏng vấn !");
                flag = false;
            }
            if (HPV_GioPV.Time.Hour < 8 || HPV_GioPV.Time.Hour > 17)
            {
                err.SetError(HPV_GioPV, "Vui lòng nhập thông tin giờ phỏng vấn từ 8h-17h !");
                flag = false;
            }
            if (PLTinhTrangHoSo._getSelectedID() == -1)
            {
                PLTinhTrangHoSo.SetError(err, "Vui lòng chọn tình trạng hồ sơ !");
                flag = false;
            }
            return flag;
        }
        #endregion

        #region Xu ly So ngay, ngay bat dau, ngay ket thuc
        public double GetSoNgayNghi(DateTime TuNgay, double SoNgay)
        {
            double Kq = 0;
            DateTime DenNgay = TuNgay.AddDays(SoNgay);
            //Dựa vào bảng chấm công để tính
            return Kq;
        }
        public void InitNgayKetThuc()
        {
            KQ_SoNgay.ValueChanged += delegate(object sender, EventArgs e)
            {
                TaoNgayKetThuc((double)KQ_SoNgay.Value, KQ_ToanThoiGian.CheckState == CheckState.Checked ? true : false); 
            };
            KQ_NgayBatDau.EditValueChanged += delegate(object sender1, EventArgs e1)
            {
                TaoNgayKetThuc((double)KQ_SoNgay.Value,KQ_ToanThoiGian.CheckState== CheckState.Checked ? true : false); 
            };
            KQ_ToanThoiGian.EditValueChanged += delegate(object sender2, EventArgs e2)
            {
                TaoNgayKetThuc((double)KQ_SoNgay.Value, KQ_ToanThoiGian.CheckState == CheckState.Checked ? true : false); 
            };
            KQ_BanThoiGian.EditValueChanged += delegate(object sender4, EventArgs e4)
            {
                TaoNgayKetThuc((double)KQ_SoNgay.Value, KQ_ToanThoiGian.CheckState == CheckState.Checked ? true : false); 
            };

        }
        public void TaoNgayKetThuc(double SoNgayQD,bool fulltime)
        {
            DateTime? Ngay = HelpDate.GetDateEdit(KQ_NgayBatDau);
            DateTime NgayKetThucChuan = HelpDateExt.getNgayKetThuc(KQ_NgayBatDau.DateTime, (int)SoNgayQD,
               fulltime==true ? true : false
               );
            double SoNgayNghi = 0;
            if (TForm == TrangThaiForm.Add)
                SoNgayNghi = 0;
            else
                SoNgayNghi = SoNgayQD - XL_LUONG.Ins.SoNgayLamViec_NhanVien(KQ_NgayBatDau.DateTime,NgayKetThucChuan,this.IDKey);
            DateTime KetThuc = HelpDateExt.getNgayKetThuc(KQ_NgayBatDau.DateTime, SoNgayQD +  SoNgayNghi,
               (fulltime == true) ? true : false
               );
            if (Ngay != null)
            {
                double SN = 0;
                if (KQ_SoNgay.EditValue==null)
                    SN = 0;
                else
                    SN = (double)KQ_SoNgay.Value;
                KQ_NgayKetThuc.DateTime = KetThuc;
            }
            else
                KQ_NgayKetThuc.EditValue = null;
        }
        
        #endregion
    }

}
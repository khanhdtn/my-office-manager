using System;
using System.Collections;
using System.Data;
using System.Windows.Forms;
using DAO;
using DevExpress.XtraEditors.DXErrorProvider;
using DTO;
using ProtocolVN.Framework.Core;
using ProtocolVN.Framework.Win;
using ProtocolVN.DanhMuc;

using System.Text.RegularExpressions;


namespace office
{
    public partial class frmHoSoUngVien : XtraFormPL,IFormChild
    {
        #region Vùng đặt Static
        public static FormStatus Status = FormStatus.OK_TEST;
        public static string MenuItem(string ParentID, bool IsSep)
        {
            return MenuBuilder.CreateItem(typeof(frmHoSoUngVien).FullName,
                HelpDebug.UpdateTitle("Hồ sơ ứng viên", Status),
                ParentID, true,
                typeof(frmHoSoUngVien).FullName,
                false, IsSep, "add.png", true, "", "");
        }
        #endregion

        private long Id;
        private bool? IsAdd; 
        private DXErrorProvider err = null;
        private bool CapNhatTTHS = false;
        public frmHoSoUngVien() : this("-2", true, false) { }
        public frmHoSoUngVien(object Id, bool? IsAdd,bool CapNhatTTHS)
        {
            PermissionStore.ToSQL();
            InitializeComponent();
            HelpDebug.SetTitle(this, Status);
            
            err = new DXErrorProvider();
            if(Id.ToString()!="-2")
                this.Id = Int64.Parse(Id.ToString());
            this.IsAdd = IsAdd;
            this.CapNhatTTHS = CapNhatTTHS;
            InitControl();
            InitData();
            InitButtonImage();
            InitForm();
            if (IsAdd == true)
                this.MaPhieu.Text = FWDBService.getSoPhieu("RESUME", "MA_HO_SO", DatabaseFB.GetThamSo("MA_PUV"));
            HelpXtraForm.SetCloseForm(this, btnClose, IsAdd);
            this.Load += delegate(object sender, EventArgs e) {
                HelpXtraForm.SetFix(this);
            };
        }
        public frmHoSoUngVien(bool? IsAdd) : this("-2", true,false) { } 
        
        private void InitForm()
        {
            if (this.IsAdd==false || this.IsAdd==null) 
            {
                EnabledControl();
                HienThiThong_Xem_Sua_CapNhatTTHS();
            }
            else
            {
                NgayCapNhatHS.DateTime = DateTime.Today;
            }
        }
        
        private void EnabledControl()
        {
            if (IsAdd == null)
                btnSave.Visible = false;
            if (CapNhatTTHS == true)
            {
                HoTen.Enabled = false;
                PLLoaiHoSo.Enabled = false;
                GTNam.Enabled = false;
                GTNu.Enabled = false;
                DiaChi.Enabled = false;
                Email.Enabled = false;
                PLLoaiHoSo.Enabled = false;
                DanhSachViTriUngTuyen.Enabled = false;
                LuongMongDoi.Enabled = false;
                LuongMongDoi.Enabled = false;
                LoaiTien.Enabled = false;
                QuaTrinhCongTac.Enabled = false;
                QuaTrinhDaoTao.Enabled = false;
                ThongTinKhac.Enabled = false;
                TrinhDoChuyenMon.Enabled = false;
                TrinhDoNgoaiNgu.Enabled = false;
                NgaySinh.Enabled = false;
                DienThoai.Enabled = false;
                TinhTrangHonNhan.Enabled = false;
            }
        }

        #region IFormChild Members

        public void InitControl()
        {
            DMTinhTrangHoSo.I.InitCtrl(PLTinhTrangHoSo, false, true);
            DMCTinhTrangHonNhan.InitCtrl(TinhTrangHonNhan, true);
            DMViTriUngTuyen.I.InitCtrl(DanhSachViTriUngTuyen,this.IsAdd);
            DMCLoaiHoSo.InitCtrl(PLLoaiHoSo, true);
            //Format SoTien với 2 số thập phân sau dấu phẩy.
            ApplyFormatAction.applyElement(LuongMongDoi.Properties, 2);
            LuongMongDoi.Properties.Precision = 2;
        }

        public void InitButtonImage()
        {
        }

        public bool IsValidate()
        {
            bool flag = true;
            err.ClearErrors();
            flag = HelpInputData.ShowRequiredError(err, new object[] 
                {   HoTen , "Họ tên"
                });
            if (PLLoaiHoSo._getSelectedID() == -1)
                PLLoaiHoSo.SetError(err, "Vui lòng vào thông tin \"Loại hồ sơ\"!");
            if (PLTinhTrangHoSo._getSelectedID() == -1)
                PLTinhTrangHoSo.SetError(err, "Vui lòng vào thông tin \"Tình trạng hồ sơ\"!");
            if (NgaySinh.EditValue == null)
                err.SetError(NgaySinh, "Vui lòng vào thông tin \"Ngày sinh\"!");
            if (TinhTrangHonNhan._getSelectedID().ToString() == "-1")
                TinhTrangHonNhan.SetError(err, "Vui lòng vào thông tin \"Tình trạng hôn nhân\"!");
            if (Email.Text.Trim().Length == 0)
                err.SetError(Email, "Vui lòng vào thông tin \"Email\"!");
            if (DienThoai.Text.Trim().Length == 0)
                err.SetError(DienThoai, "Vui lòng vào thông tin \"Điện thoại\"!");
            if (Email.Text.Trim().Length > 0 && !Regex.IsMatch(Email.Text, PLConst.EXPRESSION_EMAIL))
                err.SetError(Email, "Thông tin \"Email\" không hợp lệ!");
            if (LuongMongDoi.EditValue != null && (LuongMongDoi.Value < 1 || LuongMongDoi.Value > 99999999999999)) //Max dưới db decimal 15
            {
                if (HelpNumber.ParseInt64(LuongMongDoi.EditValue) != 0)
                    err.SetError(LuongMongDoi, "Vui lòng vào thông tin \"Lương mong đợi\" từ 1 đến 99.999.999.999.999!");
            }
            return !err.HasErrors;
        }
            


        #endregion

        #region 3.0.Sự kiện

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.IsAdd != null || CapNhatTTHS == true)
            {
                if (this.IsValidate())
                {
                    if (UncheckAllVTUT())
                    {
                        HelpMsgBox.ShowNotificationMessage("Vui lòng chọn \"Vị trí tuyển dụng\"!");
                        return;
                    }

                    DateTime? NSinh = null;
                    if (NgaySinh.Text.Equals("") == true)
                        NSinh = null;
                    else
                        NSinh = (DateTime?)NgaySinh.EditValue;
                    long IDUngVien = (this.IsAdd == true) ? (int)HelpDB.getDatabase().GetID("GEN_RESUME_ID") : this.Id;
                    DOResume UngVien = new DOResume(IDUngVien, MaPhieu.Text,
                        HoTen.Text,
                        NSinh,
                        DiaChi.Text,
                        DienThoai.Text,
                        Email.Text,
                        (GTNam.Checked == true) ? "Y" : "N",
                        TrinhDoChuyenMon._getHTMLText(),
                        QuaTrinhCongTac._getHTMLText(),
                        QuaTrinhDaoTao._getHTMLText(),
                        TinhTrangHonNhan._getSelectedID().ToString(),
                        (LuongMongDoi.Value > 0) ? (LuongMongDoi.Value.ToString("#,###") + " " + LoaiTien.Text) : "",
                        TrinhDoNgoaiNgu._getHTMLText(),
                        ThongTinKhac._getHTMLText(),
                        DateTime.Now,
                        PLLoaiHoSo._getSelectedID().ToString(),
                        PLTinhTrangHoSo._getSelectedID()
                    );
                    if (this.IsAdd == true)
                    {
                        if (DAResume.Insert(UngVien))
                        {
                            ArrayList arrVTTuyen = getDanhSachUngTuyen(true);
                            for (int i = 0; i < arrVTTuyen.Count; i++)
                            {
                                DOUngTuyen UngTuyen = new DOUngTuyen(UngVien.ID, (long)arrVTTuyen[i]);
                                DAUngTuyen.Insert(UngTuyen);
                            }
                        }
                    }
                    else
                    {
                        if (CapNhatTTHS)
                        {
                            DAResume.Update(UngVien.ID, UngVien.TINH_TRANG_HO_SO, UngVien.NGAY_CAP_NHAT_HO_SO);
                        }
                        else
                        {
                            if (DAResume.Update(UngVien))
                            {
                                ArrayList arrVTTuyen = getDanhSachUngTuyen(false);
                                for (int i = 0; i < arrVTTuyen.Count; i++)
                                {
                                    DOUngTuyen UngTuyen = new DOUngTuyen(UngVien.ID, (long)arrVTTuyen[i]);
                                    if (DAUngTuyen.ExistsRow(UngTuyen))
                                    {
                                        if (DanhSachViTriUngTuyen.GetItemCheckState(i) == CheckState.Unchecked)
                                            DAUngTuyen.Delete(UngTuyen);
                                    }
                                    else
                                    {
                                        if (DanhSachViTriUngTuyen.GetItemCheckState(i) == CheckState.Checked)
                                            DAUngTuyen.Insert(UngTuyen);
                                    }
                                }
                            }
                        }
                    }
                    HelpXtraForm.CloseFormNoConfirm(this);
                }

            }

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (HelpMsgBox.ShowConfirmMessage("Bạn có chắc chắn muốn làm lại hồ sơ không ? ") == DialogResult.Yes)
                this.RefreshForm();
        }

        #endregion

        #region 4.0.Phần giữ chỗ
        private void HienThiThong_Xem_Sua_CapNhatTTHS()
        {
            #region Hien thi thong tin
            DOResume UngVien = DAResume.getUngVien(this.Id);
            MaPhieu.Text = UngVien.MA_HO_SO;
            HoTen.Text = UngVien.TEN;
            Email.Text = UngVien.EMAIL;
            DiaChi.Text = UngVien.DIA_CHI;
            DienThoai.Text = UngVien.DIEN_THOAI;
            TinhTrangHonNhan._setSelectedID(int.Parse(UngVien.TINH_TRANG_HON_NHAN));
            NgayCapNhatHS.DateTime = UngVien.NGAY_CAP_NHAT_HO_SO;
            PLTinhTrangHoSo._setSelectedID(UngVien.TINH_TRANG_HO_SO);
            if (UngVien.NGAY_SINH != null)
                NgaySinh.DateTime = UngVien.NGAY_SINH.Value;
            try
            {
                PLLoaiHoSo._setSelectedID(int.Parse(UngVien.LOAI_HO_SO));
                string[] M = UngVien.LUONG_MONG_DOI.ToString().Split(' ');
                if (M.Length > 1)
                {
                    LuongMongDoi.Value = HelpNumber.ParseDecimal(M[0]);
                    LoaiTien.Text = M[1];
                }
            }
            catch (Exception)
            {
            }

            if (UngVien.GIOI_TINH == "Y")
            {
                GTNam.Checked = true;
                GTNu.Checked = false;
            }
            else
            {
                GTNu.Checked = true;
                GTNam.Checked = false;
            }
            #endregion
            #region Duyệt các vị trí ứng tuyển
            DataTable AllViTriUngTuyen = DAViTriUngTuyen.getAllTable();
            DataTable dsVTUT = DAUngTuyen.getVTUngTuyenUngVien(this.Id);
            DanhSachViTriUngTuyen.DataSource = AllViTriUngTuyen;
            DanhSachViTriUngTuyen.ValueMember = "ID";
            DanhSachViTriUngTuyen.DisplayMember = "NAME";
            for (int i = 0; i < dsVTUT.Rows.Count; i++)
            {
                for (int j = 0; j < AllViTriUngTuyen.Rows.Count; j++)
                {
                    string str = DanhSachViTriUngTuyen.GetItemValue(i).ToString();
                    if (dsVTUT.Rows[i]["VTUT_ID"].ToString() == DanhSachViTriUngTuyen.GetItemValue(j).ToString())
                    {
                        DanhSachViTriUngTuyen.SetItemCheckState(j, CheckState.Checked);
                        break;
                    }
                }
            }
            #endregion
            #region Hiển thị lên các thông tin liên quan
            
            QuaTrinhDaoTao._setHTMLText(UngVien.QUA_TRINH_DAO_TAO);
            QuaTrinhCongTac._setHTMLText(UngVien.QUA_TRINH_CONG_TAC);
            ThongTinKhac._setHTMLText(UngVien.THONG_TIN_KHAC);
            TrinhDoChuyenMon._setHTMLText(UngVien.TRINH_DO_CHUYEN_MON);
            TrinhDoNgoaiNgu._setHTMLText(UngVien.TRINH_DO_NGOAI_NGU);

            //QuaTrinhDaoTao.DocumentText = UngVien.QUA_TRINH_DAO_TAO;
            //QuaTrinhCongTac.DocumentText = UngVien.QUA_TRINH_CONG_TAC;
            //ThongTinKhac.DocumentText = UngVien.THONG_TIN_KHAC;
            //TrinhDoChuyenMon.DocumentText = UngVien.TRINH_DO_CHUYEN_MON;
            //TrinhDoNgoaiNgu.DocumentText = UngVien.TRINH_DO_NGOAI_NGU;
            #endregion
        }
        private bool UncheckAllVTUT()
        {
            int iCountItem = HelpDB.getDatabase().LoadTable("DM_VI_TRI_UNG_TUYEN").Tables[0].Rows.Count;
            for (int i = 0; i < iCountItem; i++)
            {
                if (DanhSachViTriUngTuyen.GetItemCheckState(i) == CheckState.Checked)
                    return false;
            }
            return true;

        }
        private ArrayList getDanhSachUngTuyen(bool b_All)
        {
            ArrayList arr = new ArrayList();
            int iCountItem = HelpDB.getDatabase().LoadTable("DM_VI_TRI_UNG_TUYEN").Tables[0].Rows.Count;
            for (int i = 0; i < iCountItem; i++)
            {
                if (b_All && DanhSachViTriUngTuyen.GetItemCheckState(i) == CheckState.Checked)
                    arr.Add(DanhSachViTriUngTuyen.GetItemValue(i));
                else if (b_All == false)
                    arr.Add(DanhSachViTriUngTuyen.GetItemValue(i));
            }
            return arr;
        }
        
        private void RefreshForm()
        {
            PLLoaiHoSo._setSelectedID(0);
            MaPhieu.Text = "";
            MaPhieu.Text = DAPhieuThuChi.getMaHoSO();
            HoTen.Text = "";
            GTNam.Checked = true;
            DienThoai.Text = "";
            Email.Text = "";
            DiaChi.Text = "";
            LuongMongDoi.Value = 0;
            NgaySinh.EditValue = null;
            NgayCapNhatHS.DateTime = DateTime.Today;
            TinhTrangHonNhan._setSelectedID(-1);
            TrinhDoChuyenMon._setHTMLText("");
            TrinhDoNgoaiNgu._setHTMLText("");
            QuaTrinhCongTac._setHTMLText("");
            QuaTrinhDaoTao._setHTMLText("");
            ThongTinKhac._setHTMLText("");
           
            for (int j = 0; j < (DanhSachViTriUngTuyen.DataSource as DataTable).Rows.Count; j++)
            {
                DanhSachViTriUngTuyen.SetItemCheckState(j, CheckState.Unchecked);
            }
            LoaiTien.Text = "VND";
        }
        #endregion

        #region IFormChild Members


        public void InitData()
        {
        }

        public void InitEnabledControl()
        {
        }

        public void InitNghiepVu()
        {
        }

        #endregion
    }
}
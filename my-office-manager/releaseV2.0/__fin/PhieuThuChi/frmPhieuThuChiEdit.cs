using System;
using DAO;
using DTO;
using ProtocolVN.Framework.Core;
using ProtocolVN.Framework.Win;
using ProtocolVN.DanhMuc;
using DevExpress.XtraEditors.DXErrorProvider;
using System.Data.Common;
using System.Data;

namespace office
{
    public partial class frmPhieuThuChiEdit : XtraFormPL
    {
        #region Fields
        public DXErrorProvider errorProvider;
        private bool? _IsAdd = null;
        private bool? _type = null; //Thu = True, Chi = false
        private Int64 _Id = -1;
        private DOPhieuThuChiExt ObjDO = null;
        #endregion

        public frmPhieuThuChiEdit(object Id, bool? IsAdd, bool? type)
        {
            InitializeComponent();
            this._IsAdd = IsAdd;
            this._type = type;
            this._Id = HelpNumber.ParseInt64(Id);
            if (type == null && IsAdd==false)
            {
                DOPhieuThuChiExt obj = DAPhieuThuChiExt.Instance.LoadAll(this._Id);
                this._type = (obj.THU_CHI_BIT == "Y") ? true : false;
            }
            else if (type == null && IsAdd == true) { 
                //NOOP
            }
            InitForm();
            this.InitDOData();
        }

        public frmPhieuThuChiEdit(bool? type) : this("-2", true, type) { }

        public frmPhieuThuChiEdit(object Id, bool? IsAdd) : this(Id, IsAdd, null) { }

        private void InitForm()
        {
            errorProvider = new DXErrorProvider();
            DMLoaiChiPhi.I.InitCtrl(cmbLcp, true, this._IsAdd);
            DMNhanVienX.I.InitCtrl(cmbEmp, true, this._IsAdd);
            btnSave.Image = FWImageDic.SAVE_IMAGE16;
            btnDong.Image = FWImageDic.CLOSE_IMAGE16;
            ApplyFormatAction.applyElement(SoTien.Properties, 2);
            SoTien.Properties.Precision = 2;
            //if(this._IsAdd!=true)
            this.radioLoaiPhieu.Enabled = false;
            this.MaPhieu.Enabled = false;
        }

        private void InitDOData()
        {
            this.ObjDO = DAPhieuThuChiExt.Instance.LoadAll(this._Id);
            if (this._IsAdd != true)
            {
                this.MaPhieu.Text = this.ObjDO.CODE;
                this.radioLoaiPhieu.SelectedIndex = (this.ObjDO.THU_CHI_BIT == "Y") ? 0 : 1;
                this.cmbEmp._setSelectedID(this.ObjDO.EMP_ID);
                this.cmbLcp._setSelectedID(this.ObjDO.LCP_ID);
                HelpDate.SetDateEdit(this.NgayPhatSinh, this.ObjDO.NGAY_PHAT_SINH);
                this.memDienGiai.Text = this.ObjDO.DIEN_GIAI;
                this.txtDonViLienQuan.Text = this.ObjDO.DON_VI_LIEN_QUAN;
                if (this._type == true)
                    this.SoTien.Value = this.ObjDO.SO_TIEN_THU;
                else this.SoTien.Value = this.ObjDO.SO_TIEN_CHI;
            }
            else {
                radioLoaiPhieu.SelectedIndex = (this._type==true)? 0:1;
            }
            PLGUIUtil.InitBtnPhieu(this, this._IsAdd, null, null, null, this.btnSave, null, this.btnDong);
        }

        private void GetDOData() {

            this.ObjDO.EMP_ID = this.cmbEmp._getSelectedID();
            this.ObjDO.LCP_ID = this.cmbLcp._getSelectedID();
            this.ObjDO.NGAY_PHAT_SINH = this.NgayPhatSinh.DateTime;
            this.ObjDO.DIEN_GIAI = this.memDienGiai.Text;
            this.ObjDO.DON_VI_LIEN_QUAN = this.txtDonViLienQuan.Text;
            this.ObjDO.KKD_ID = DAKyKinhDoanhPTC.Instance.getKyKinhDoanh(this.NgayPhatSinh.DateTime).KKD_ID;
            this.ObjDO.THU_CHI_BIT = (this._type == true) ? "Y" : "N";
            if (this._type == true) this.ObjDO.SO_TIEN_THU = this.SoTien.Value;
            else this.ObjDO.SO_TIEN_CHI = this.SoTien.Value;

            if (this._IsAdd == true)
            {
                this.ObjDO.CODE = DAPhieuThuChiExt.Instance.GetCodePhieu((bool)this._type); 
                this.ObjDO.NGAY_TAO_PHIEU = DABase.getDatabase().GetSystemCurrentDateTime();
                this.ObjDO.NGUOI_TAO_PHIEU = FrameworkParams.currentUser.employee_id;
            }
        }

        private void frmPhieuThuChi_Load(object sender, EventArgs e)
        {
            HelpXtraForm.SetFix(this);
            HelpXtraForm.SetCloseForm(this, btnDong, this._IsAdd);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(this.IsValidate()){
                DOPhieuThuChiExt temp = DAPhieuThuChiExt.Instance.LoadAll(this.ObjDO.KKD_ID);
                this.GetDOData();
                if (this.ObjDO.KKD_ID == 0)
                {
                    errorProvider.SetError(this.NgayPhatSinh, "Chưa có kỳ kinh doanh nào. Vui lòng kiểm tra lại ngày phát sinh");
                    return;
                }
                if (DAKyKinhDoanhPTC.Instance.LoadAll(this.ObjDO.KKD_ID).KHOA_SO_BIT.Equals("Y"))
                {
                    HelpMsgBox.ShowErrorMessage("Kỳ kinh doanh này đã bị khóa sổ.");
                    return;
                }
                if (!DAPhieuThuChiExt.Instance.Update(this.ObjDO))
                    ErrorMsg.ErrorSave("");
                else
                {
                    //Cập nhật dữ liệu cho các kỳ sau tiền phát sinh tăng, phát sinh giảm
                    string querySQL = string.Format(@"update tm_ky_kinh_doanh_ptc tm
                                set tm.phat_sinh_tang = (SELECT SUM(ptc.SO_TIEN_THU) FROM PHIEU_THU_CHI ptc WHERE ptc.kkd_id = tm.kkd_id),
                                tm.phat_sinh_giam = (SELECT SUM(ptc.so_tien_chi) FROM PHIEU_THU_CHI ptc WHERE ptc.kkd_id = tm.kkd_id)
                                Where tm.kkd_id = {0}",this.ObjDO.KKD_ID);
                    DatabaseFB db = DABase.getDatabase();
                    DbCommand cmd = db.GetSQLStringCommand(querySQL);
                    if (db.ExecuteNonQuery(cmd) > 0)
                    {
                        decimal deltaThu = this.ObjDO.SO_TIEN_THU - temp.SO_TIEN_THU;
                        decimal deltaChi = this.ObjDO.SO_TIEN_CHI - temp.SO_TIEN_CHI;
                        decimal deltaChange = deltaThu - deltaChi;
                        string sql = string.Format(@"
                                        UPDATE tm_ky_kinh_doanh_ptc tm 
                                        SET tm.tm_dau_ky = tm.tm_dau_ky + {0},
                                            tm_cuoi_ky = tm.tm_dau_ky + {1}
                                        WHERE tm.KKD_ID = {2}", deltaChange, deltaChange, GetKKDByNgayPhatSinh(NgayPhatSinh.DateTime));
                        db = DABase.getDatabase();
                        cmd = db.GetSQLStringCommand(sql);
                        HelpXtraForm.CloseFormNoConfirm(this);
                    }
                    else ErrorMsg.ErrorSave("");
                }
            }
        }
        
        private bool IsValidate()
        {
            errorProvider.ClearErrors();
            GUIValidation.TrimAllData(new object[] { txtDonViLienQuan });
            GUIValidation.ShowRequiredError(errorProvider,new object[]{
                NgayPhatSinh,"Ngày phát sinh",
                cmbLcp,"Loại chi phí",
                cmbEmp,"Người liên quan",
                txtDonViLienQuan,"Đơn vị liên quan",
            });
            if (SoTien.Value < 1 || SoTien.Value > 99999999999999) //Max dưới db decimal 15
                errorProvider.SetError(SoTien, "Vui lòng nhập vào thông tin \"Số tiền\" từ 1 đến 99.999.999.999.999!");
            return !errorProvider.HasErrors;
        }

        private void radioLoaiPhieu_SelectedIndexChanged(object sender, EventArgs e)
        {
            this._type = (radioLoaiPhieu.SelectedIndex == 0) ? true : false;
        }
        private long GetKKDByNgayPhatSinh(DateTime ngayphatsinh)
        {
            DatabaseFB db = HelpDB.getDatabase();
            DbCommand cmd = db.GetStoredProcCommand("GET_KKD_BY_DATE");
            db.AddInParameter(cmd, "@NGAY_PHAT_SINH", DbType.DateTime, ngayphatsinh);
            db.AddOutParameter(cmd, "@KKD_ID", DbType.Int64, 2);
            if ((long)db.ExecuteScalar(cmd) > 0)
            {
                return (long)db.GetParameterValue(cmd, "@KKD_ID");
            }
            return -1;
        }
    }
}
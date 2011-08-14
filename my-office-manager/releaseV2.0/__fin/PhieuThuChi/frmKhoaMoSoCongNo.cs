using System;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraEditors.DXErrorProvider;
using DevExpress.XtraGrid.Views.Grid;
using ProtocolVN.Framework.Core;
using ProtocolVN.Framework.Win;
using DAO;
using DTO;
using System.Data.Common;

namespace office
{
    public partial class frmKhoaMoSoCongNo : XtraFormPL
    {
        private DXErrorProvider Error=new DXErrorProvider();
        public static FormStatus Status = FormStatus.NC;

        public static string MenuItem(string ParentID, bool IsSep)
        {
            return MenuBuilder.CreateItem(typeof(frmKhoaMoSoCongNo).FullName,
                PMSupport.UpdateTitle("Khóa sổ/Mở sổ công nợ", Status),
                ParentID, true,
                typeof(frmKhoaMoSoCongNo).FullName,
                true, IsSep, "mnsKhoaMoSo.png", true, "", "");
        }
        public frmKhoaMoSoCongNo()
        {
            InitializeComponent();
            this.InitControls();
        }

        private void InitControls() {

            #region Cấu hình cột trong lưới hiển thị
            HelpGridColumn.CotTextLeft(colMasterCode, PhieuThuChiExtFields.CODE);
            HelpGridColumn.CotCombobox(colMasterLcp, "DM_LOAI_CHI_PHI", "ID", "NAME", PhieuThuChiExtFields.LCP_ID);
            HelpGridColumn.CotDateEdit(cplMasterNgayPs, PhieuThuChiExtFields.NGAY_PHAT_SINH);
            HelpGridColumn.CotDateEdit(colMasterNgayTao, PhieuThuChiExtFields.NGAY_TAO_PHIEU);
            HelpGridColumn.CotCombobox(colMasterNguoiTao, "DM_NHAN_VIEN", "ID", "NAME", PhieuThuChiExtFields.NGUOI_TAO_PHIEU);
            HelpGridColumn.CotCombobox(colMasterEmp, "DM_NHAN_VIEN", "ID", "NAME", PhieuThuChiExtFields.EMP_ID);
            HelpGridColumn.CotTextLeft(colMasterDonVi, PhieuThuChiExtFields.DON_VI_LIEN_QUAN);
            HelpGridColumn.CotCalcEdit(colMasterTienThu, PhieuThuChiExtFields.SO_TIEN_THU, 0);
            HelpGridColumn.CotCalcEdit(colMasterTienChi, PhieuThuChiExtFields.SO_TIEN_CHI, 0);
            HelpGridColumn.CotTextLeft(colMasterDienGiai, PhieuThuChiExtFields.DIEN_GIAI);
            HelpGridColumn.CotPLImageCheck(colMasterThuChiBit, PhieuThuChiExtFields.THU_CHI_BIT); 
            #endregion

            #region Một số cài đặt cho lưới
            this.gridViewMaster.OptionsView.ShowFooter = true;
            this.gridViewMaster.OptionsBehavior.Editable = false;
            this.gridViewMaster.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridViewMaster.FocusRectStyle = DrawFocusRectStyle.RowFocus;
            this.gridViewMaster.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
            this.gridViewMaster.OptionsBehavior.AutoExpandAllGroups = true;
            this.gridViewMaster.OptionsView.ShowGroupedColumns = false;
            this.colMasterTienChi.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.colMasterTienThu.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.gridViewMaster.OptionsView.ColumnAutoWidth = true;
            #endregion

            DAKyKinhDoanhPTC.Instance.InitKyKinhDoanhPTC(this.KyKinhDoanh);
            //Mặc định luôn có 1 dòng trống trong PLCombobox
            if ((KyKinhDoanh.DataSource as DataTable).Rows.Count == 1)
            {
                TuNgay.Enabled = true;
                DenNgay.Enabled = false;
            }
            else TuNgay.Enabled = false;
            DataSet dsKKDMax = DABase.getDatabase().LoadDataSet(
                new QueryBuilder(@"SELECT KKD.KKD_ID, KKD.TU_NGAY FROM KY_KINH_DOANH_PTC KKD
                            WHERE KKD.TU_NGAY IN (SELECT MAX(T.TU_NGAY) FROM KY_KINH_DOANH_PTC T) AND 1=1")
                );
            if (dsKKDMax != null && dsKKDMax.Tables[0].Rows.Count == 1)
            {
                DOKyKinhDoanhPTC kkd = DAKyKinhDoanhPTC.Instance.LoadAll(HelpNumber.ParseInt64(dsKKDMax.Tables[0].Rows[0]["KKD_ID"]));
                this.KyKinhDoanh._setSelectedID(kkd.KKD_ID);
            }
        }

        #region Invalidate
        private void KyKinhDoanh_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Error.ClearErrors();
            if (KyKinhDoanh._getSelectedID() == -1)
            {
                TuNgay.Enabled = DenNgay.Enabled = false;
                TuNgay.EditValue = DenNgay.EditValue = null;
                gridControlMaster.DataSource = null;
            }
            else
            {
                DOKyKinhDoanhPTC KyKD = DAKyKinhDoanhPTC.Instance.LoadAll(this.KyKinhDoanh._getSelectedID());
                if (KyKD.DEN_NGAY == null)
                    this.DenNgay.Enabled = true;
                else
                {
                    this.DenNgay.Enabled = false;
                    this.TuNgay.Enabled = false;
                }
                if (KyKD.KHOA_SO_BIT == "Y")
                {
                    this.DaKetChuyen.Checked = true;
                    this.btnKhoa.Visible = false;
                    this.btnMoKhoa.Visible = true;
                }
                else
                {
                    this.DaKetChuyen.Checked = false;
                    this.btnKhoa.Visible = true;
                    this.btnMoKhoa.Visible = false;
                }

                HelpDate.SetDateEdit(this.TuNgay, KyKD.TU_NGAY);
                this.DenNgay.EditValue = KyKD.DEN_NGAY;
                QueryBuilder query = query = new QueryBuilder(
                    "SELECT * " +
                    "FROM PHIEU_THU_CHI " +
                    "WHERE 1=1"
                );
                query.addDateFromTo(PhieuThuChiExtFields.NGAY_PHAT_SINH, this.TuNgay.DateTime, this.DenNgay.DateTime);
                this.gridControlMaster.DataSource = DABase.getDatabase().LoadDataSet(query).Tables[0];
            }
        }
      
        #endregion

        private void Khoa_Click(object sender, EventArgs e)
        {
            Error.ClearErrors();
            if (DenNgay.DateTime <= TuNgay.DateTime) {
                Error.SetError(DenNgay, "Ngày kết thúc phải lớn hơn ngày bắt đầu!");
                return;
            }
            if (GUIValidation.ShowRequiredError(this.Error, new object[]{
                this.DenNgay,"Ngày kết thúc kỳ kinh doanh"
            })) { 
                ///Thuật toán khóa kỳ kinh doanh
                ///1.Ngày kết thúc kỳ kinh doanh >= ngày đầu kỳ
                ///2.Các kỳ trước đó đã được khóa
                ///3.Dữ liệu thay đổi 
                ///         -Cuối kỳ luôn được tính bằng ĐẦU KỲ + Phát sinh tăng - Phát sinh giảm
                ///         -Tạo một kỳ mới có ngày bắt đầu kế tiếp ngày kết thúc kỳ hiện tại
                ///          và phát sinh tăng = 0, giảm = 0, đầu kỳ = cuối kỳ hiện tại, cuối kỳ = đầu kỳ + tăng - giảm
                DOKyKinhDoanhPTC kyKD = DAKyKinhDoanhPTC.Instance.LoadAll(this.KyKinhDoanh._getSelectedID());
                kyKD.DEN_NGAY = HelpDate.GetDateEdit(this.DenNgay);
                if (DAKyKinhDoanhPTC.Instance.KhoaMoKKD(kyKD, null, true))
                {
                    DAKyKinhDoanhPTC.Instance.InitKyKinhDoanhPTC(this.KyKinhDoanh);
                    DaKetChuyen.Checked = true;
                    btnMoKhoa.Visible = true;
                    btnKhoa.Visible = false;
                    DenNgay.Enabled = false;
                    HelpMsgBox.ShowNotificationMessage("Khóa kỳ kinh doanh thành công!");
//                    DataSet dsKKDMax = DABase.getDatabase().LoadDataSet(
//                        new QueryBuilder(@"SELECT KKD.KKD_ID, KKD.TU_NGAY FROM KY_KINH_DOANH_PTC KKD
//                            WHERE KKD.TU_NGAY IN (SELECT MAX(T.TU_NGAY) FROM KY_KINH_DOANH_PTC T) AND 1=1")
//                        );
//                    if (dsKKDMax != null && dsKKDMax.Tables[0].Rows.Count == 1)
//                    {
//                        DOKyKinhDoanhPTC kkd = DAKyKinhDoanhPTC.Instance.LoadAll(HelpNumber.ParseInt64(dsKKDMax.Tables[0].Rows[0]["KKD_ID"]));
//                        this.KyKinhDoanh._setSelectedID(kkd.KKD_ID);
//                    }
                }
                else {
                    ErrorMsg.ErrorSave("");
                }

            }                                 
        }

        private void MoKhoa_Click(object sender, EventArgs e)
        {
            ///Thuật toán mở kỳ kinh doanh
            ///1.TH1 : Mở không xóa các kỳ sau
            ///     -Mở kỳ KHOA_SO_BIT = 'N'
            ///     -Điều kiện mở : Kỳ đó đã đóng (KHOA_SO_BIT='Y')
            ///     -Lưu ý: Khi mở kỳ kinh doanh thì khi sửa không cho phép đổi ngày Khóa sổ
            ///     
            if ((KyKinhDoanh.DataSource as DataTable).Rows.Count > 1)
            {
                DatabaseFB db = DABase.getDatabase();
                DbCommand cmd = db.GetStoredProcCommand("FUNC_MO_KHOA");
                db.AddInParameter(cmd, "@KKD_ID", DbType.Int64, KyKinhDoanh._getSelectedID());
                db.AddInParameter(cmd, "@NGUOI_MO_KHOA", DbType.Int64, FrameworkParams.currentUser.employee_id);
                if ((int)db.ExecuteScalar(cmd) > 0)
                {
                    btnMoKhoa.Visible = false;
                    btnKhoa.Visible = true;
                    DaKetChuyen.Checked = false;
                    btnKhoa.Visible = true;
                    btnMoKhoa.Visible = false;
                    HelpMsgBox.ShowNotificationMessage("Mở kỳ kinh doanh thành công!");
                }
                else HelpMsgBox.ShowDBErrorMessage("Mở kỳ kinh doanh không thành công!");
            }
            else DAKyKinhDoanhPTC.Instance.KhoaMoKKD(null, TuNgay.DateTime, false);
            ///2.TH2: Mở và có xóa các kỳ sau (Không làm)
            ///     - Mở kỳ KHOA_SO_BIT = 'N' và chuyển toàn bộ dữ liệu các kỳ sau cho kỳ hiện tại
            ///     - Xóa kỳ sau (trong bảng KY_KINH_DOANH_PTC)
            ///   
            
        }

        private void Dong_Click(object sender, EventArgs e)
        {
            if (HelpMsgBox.ShowConfirmMessage("Bạn có chắc muốn đóng?") == DialogResult.Yes)
                HelpXtraForm.CloseFormHasConfirm(this);
        }
        
    }
}
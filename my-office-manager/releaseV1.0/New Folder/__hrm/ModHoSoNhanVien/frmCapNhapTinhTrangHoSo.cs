using System;
using System.Data;
using ProtocolVN.Framework.Win;
using ProtocolVN.Framework.Core;
using DAO;
using DevExpress.XtraGrid.Columns;

namespace office
{
    public partial class frmCapNhatTinhTrangHoSo : XtraFormPL,IFormChild
    {
        #region 1.0.Danh sách biến toàn cục

        #endregion

        #region 2.0.Hàm khởi tạo
           
        public frmCapNhatTinhTrangHoSo(DataTable Input)
        {
            InitializeComponent();
            InitGrid();
            InitButtonImage();
            gridControlMaster.DataSource = Input;
            HelpXtraForm.SetFix(this);
        }
        public frmCapNhatTinhTrangHoSo() : this(null) { }
        public void InitControl()
        {
            HelpGrid.SetTitle(this.gridViewMaster, "DANH SÁCH ỨNG VIÊN");
            
        }
        
        public void InitData()
        {
            
        }

        public void InitEnabledControl()
        {
           
        }

        public void InitNghiepVu()
        {
            
        }

        public void InitButtonImage()
        {
            btn_DongY.Image = FWImageDic.SAVE_IMAGE16;
            btn_Dong.Image = FWImageDic.CLOSE_IMAGE16;
        }

        public void InitGrid()
        {
            XtraGridSupportExt.TextLeftColumn(CotHoTen, "HO_TEN");
            XtraGridSupportExt.ComboboxGridColumn(CotTinhTrangHS, "DM_TINH_TRANG_HO_SO", "ID", "NAME", "TTHS_ID");
            this.gridViewMaster.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
            GridColumn xoaCol = XtraGridSupportExt.CloseButton(gridControlMaster, gridViewMaster);
            this.gridViewMaster.RowCountChanged += delegate(object grid, EventArgs deleteRow)
            {
                xoaCol.Visible = (gridViewMaster.RowCount > 1);
            };
            
        }
        #endregion

        #region 3.0.Xử lý sự kiện (Lưu,Thêm,...)
        private void btn_DongY_Click(object sender, EventArgs e)
        {
            bool flag = false;
            DataTable dsCapNhatHS = gridControlMaster.DataSource as DataTable;
            dsCapNhatHS.AcceptChanges();

            if (dsCapNhatHS.Rows.Count > 0)
            {
                try
                {
                    FrameworkParams.wait = new WaitingMsg();

                    foreach (DataRow item in dsCapNhatHS.Rows)
                    {
                        if (item.RowState != DataRowState.Deleted)
                        {
                            DAResume.Update(HelpNumber.ParseInt64(item["ID"]), HelpNumber.ParseInt64(item["TTHS_ID"]), DateTime.Today);
                        }
                    }
                    flag = true;
                }
                catch (Exception ex)
                {
                    HelpMsgBox.ShowErrorMessage(ex.Message);
                    flag = false;
                }
                finally
                {
                    if (FrameworkParams.wait != null) FrameworkParams.wait.Finish();
                    if (flag)
                        this.Close();
                }
            }
        }

        private void btn_Dong_Click(object sender, EventArgs e)
        {
            PLGUIUtil.DongForm(this);
        }
        #endregion

        #region 4.0.Phần mở rộng

        #endregion

        #region 5.0.Phần giữ chỗ
        public DataTable ThongTinGuiPhongVan(DataRow dr)
        {
            DataTable dt = new DataTable("PhongVan");
            dt.Columns.Add("DIA_CHI");
            dt.Columns.Add("DIEN_THOAI");
            dt.Columns.Add("EMAIL");
            dt.Columns.Add("ID");
            dt.Columns.Add("LOAI_HO_SO");
            dt.Columns.Add("GIOI_TINH");
            dt.Columns.Add("LUONG_MONG_DOI");
            dt.Columns.Add("NGAY_CAP_NHAT_HO_SO");
            dt.Columns.Add("NGAY_SINH");
            dt.Columns.Add("QUA_TRINH_CONG_TAC");
            dt.Columns.Add("QUA_TRINH_DAO_TAO");
            dt.Columns.Add("TEN");
            dt.Columns.Add("THONG_TIN_KHAC");
            dt.Columns.Add("TINH_TRANG_HON_NHAN");
            dt.Columns.Add("TRINH_DO_CHUYEN_MON");
            dt.Columns.Add("TRINH_DO_NGOAI_NGU");
            dt.Columns.Add("NGAY_PHONG_VAN",Type.GetType("System.DateTime"));
            dt.Columns.Add("GIO_PHONG_VAN");

            DataRow row = dt.NewRow();
            
            DateTime? NgaySinh = null;
            if(dr["NGAY_SINH"].ToString().Length >0)
                NgaySinh = (DateTime?)dr["NGAY_SINH"] ;
            row["ID"] = HelpNumber.ParseInt64(dr["ID"]);
            row["NGAY_SINH"] = NgaySinh;
            row["DIA_CHI"] = dr["DIA_CHI"];
            row["DIEN_THOAI"]= dr["DIEN_THOAI"].ToString();
            row["EMAIL"] =dr["EMAIL"].ToString();
            row["GIOI_TINH"] = (dr["GIOI_TINH"].ToString() =="Y") ? "Anh" : "Chị";
            row["QUA_TRINH_CONG_TAC"] = HelpByte.BytesToUTF8String((byte[])dr["QUA_TRINH_CONG_TAC"]);
            row["QUA_TRINH_DAO_TAO"] = HelpByte.BytesToUTF8String((byte[])dr["QUA_TRINH_DAO_TAO"]);
            row["TEN"] = dr["HO_TEN"].ToString();
            row["THONG_TIN_KHAC"] = HelpByte.BytesToUTF8String((byte[])dr["THONG_TIN_KHAC"]);
            row["TINH_TRANG_HON_NHAN"]=dr["TINH_TRANG_HON_NHAN"].ToString();
            row["TRINH_DO_CHUYEN_MON"] = HelpByte.BytesToUTF8String((byte[])dr["TRINH_DO_CHUYEN_MON"]);
            row["TRINH_DO_NGOAI_NGU"] = HelpByte.BytesToUTF8String((byte[])dr["TRINH_DO_NGOAI_NGU"]);
            row["GIO_PHONG_VAN"] = dr["GIO_PHONG_VAN"].ToString();
            dt.Rows.Add(row);
            return dt;
        }

        #endregion

        #region 6.0.Phần xử lý Validation
        public bool IsValidate()
        {
            return true;
        }
        #endregion

        private void frmCapNhatTinhTrangHoSo_Load(object sender, EventArgs e)
        {
            this.InitControl();
            
        }

        
        
    }
}
using System;
using System.Collections.Generic;
using System.Data;
using ProtocolVN.Framework.Win;
using ProtocolVN.Framework.Core;
using DTO;
using DevExpress.XtraGrid.Columns;

namespace office
{
    public partial class frmGuiThuHenPhongVan : XtraFormPL,IFormChild
    {
        #region 1.0.Danh sách biến toàn cục

        #endregion

        #region 2.0.Hàm khởi tạo
        public frmGuiThuHenPhongVan(DataTable Input)
        {
            InitializeComponent();
            Input.Columns.Add("GIO_PHONG_VAN", Type.GetType("System.String")); 
            InitGrid();
            gridControlMaster.DataSource = Input;
            HelpXtraForm.SetFix(this);
            btn_DongY.Image = FWImageDic.SAVE_IMAGE16;
            btn_Dong.Image = FWImageDic.CLOSE_IMAGE16;
        }

        public void InitControl()
        {
            
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

        public void InitGrid()
        {
            XtraGridSupportExt.TextLeftColumn(CotHoTen, "HO_TEN");
            XtraGridSupportExt.TextLeftColumn(CotEmail, "EMAIL");
            GridColumn xoaCol = XtraGridSupportExt.CloseButton(gridControlMaster, gridViewMaster);
            this.gridViewMaster.RowCountChanged += delegate(object grid, EventArgs deleteRow) {
                xoaCol.Visible = (gridViewMaster.RowCount > 1);
            };
            CotEmail.FieldName = "EMAIL";
            CotGioPhongVan.FieldName = "GIO_PHONG_VAN";
        }
        #endregion

        #region 3.0.Xử lý sự kiện (Lưu,Thêm,...)
        private void btn_DongY_Click(object sender, EventArgs e)
        {
            DataTable dsGuiPhongVan = gridControlMaster.DataSource as DataTable;
            for (int i = 0; i < dsGuiPhongVan.Rows.Count; i++)
            {
                if (dsGuiPhongVan.Rows[i].RowState == DataRowState.Deleted) continue;
                dsGuiPhongVan.Rows[i].ClearErrors();
            }
            for (int i = 0; i < dsGuiPhongVan.Rows.Count;i++ )
            {
                if (dsGuiPhongVan.Rows[i].RowState == DataRowState.Deleted) continue;
                if (string.Compare(dsGuiPhongVan.Rows[i]["GIO_PHONG_VAN"].ToString(), string.Empty) == 0)
                    dsGuiPhongVan.Rows[i].SetColumnError("GIO_PHONG_VAN", "Vui lòng chọn \"Ngày/giờ phỏng vấn\"!");
            }
            if (dsGuiPhongVan.HasErrors) return;
            dsGuiPhongVan.AcceptChanges();
            List<DOResume> dsGuiKhongDuoc = new List<DOResume>();
            if (dsGuiPhongVan.Rows.Count > 0)
            {
                try
                {
                    System.Windows.Forms.Application.DoEvents();
                    FrameworkParams.wait = new WaitingMsg();

                    foreach (DataRow item in dsGuiPhongVan.Rows)
                    {
                        if (item.RowState != DataRowState.Deleted)
                        {
                            DataSet ds = new DataSet();
                            ds.Tables.Add(ThongTinGuiPhongVan(item));
                            List<String> mailaddress = new List<string>();
                            mailaddress.Add(item["EMAIL"].ToString());
                            if (!HelpEmail.SentMessageTemplateHTMLOutside(mailaddress, ds, "Thư mời phỏng vấn", FrameworkParams.TEMPLETE_FOLDER + "\\ThuPhongVan.doc", null))
                            {
                                DOResume resume = new DOResume
                                {
                                    TEN = item["TEN"].ToString(),
                                    EMAIL = item["EMAIL"].ToString()
                                };
                                dsGuiKhongDuoc.Add(resume);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    PLException.AddException(ex);
                }
                finally
                {
                    if (FrameworkParams.wait != null) FrameworkParams.wait.Finish();
                    if (dsGuiKhongDuoc.Count == 0)
                    {
                        HelpMsgBox.ShowNotificationMessage("Thực hiện gửi mail thành công"); this.Close();
                    }
                    else
                        HelpMsgBox.ShowNotificationMessage("Có " + dsGuiKhongDuoc.Count.ToString() + " email gửi không thành công.");
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
            dt.Columns.Add("NGAY_PHONG_VAN");
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
            string []time = dr["GIO_PHONG_VAN"].ToString().Split(' ');
            row["GIO_PHONG_VAN"] = Convert.ToDateTime(dr["GIO_PHONG_VAN"].ToString()).ToString("HH:mm");
            row["NGAY_PHONG_VAN"] = Convert.ToDateTime(dr["GIO_PHONG_VAN"].ToString()).ToString("dd/MM/yyyy");
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




        #region IFormChild Members


        public void InitButtonImage()
        {
            
        }

        #endregion
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using DAO;
using DTO;
using pl.hrm.form;

using ProtocolVN.DanhMuc;
using ProtocolVN.Framework.Core;
using ProtocolVN.Framework.Win;

using DevExpress.XtraGrid.Columns;
using System.Text;
using ProtocolVN.App.Office;

namespace office
{
    public partial class frmHoSoQL : PhieuQuanLyChange,IFormRefresh
    {
        #region Vùng đặt Static
        public static FormStatus Status = FormStatus.OK_TEST;

        public static string MenuItem(string ParentID, bool IsSep)
        {
            return MenuBuilder.CreateItem(typeof(frmHoSoQL).FullName,
                "Hồ sơ ứng viên",
                ParentID, true,
                typeof(frmHoSoQL).FullName,true,
                IsSep, "mnbHSoUngVien.png", true, "", "");
        }
        #endregion

        //#region Các biến của form Quan Ly Tuyệt đối không thay đổi
        //protected DevExpress.XtraBars.BarManager barManager1;
        //protected DevExpress.XtraBars.Bar MainBar;
        //protected DevExpress.XtraBars.BarButtonItem barButtonItemAdd;
        //protected DevExpress.XtraBars.BarButtonItem barButtonItemDelete;
        //protected DevExpress.XtraBars.BarButtonItem barButtonItemUpdate;
        //protected DevExpress.XtraBars.BarButtonItem barButtonItemPrint;
        //protected DevExpress.XtraBars.BarDockControl barDockControlTop;
        //protected DevExpress.XtraBars.BarDockControl barDockControlBottom;
        //protected DevExpress.XtraBars.BarDockControl barDockControlLeft;
        //protected DevExpress.XtraBars.BarDockControl barDockControlRight;
        //protected DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        //protected DevExpress.XtraGrid.GridControl gridControlMaster;
        //protected DevExpress.XtraGrid.Views.Grid.PLGridView gridViewMaster;
        //protected DevExpress.XtraTab.XtraTabControl xtraTabControlDetail;
        //protected DevExpress.XtraTab.XtraTabPage xtraTabPageDetail;
        //protected DevExpress.XtraBars.PopupControlContainer popupControlContainerFilter;
        //protected DevExpress.XtraBars.BarStaticItem barStaticItem1;
        //protected DevExpress.XtraGrid.GridControl gridControlDetail;
        //protected DevExpress.XtraGrid.Views.Grid.PLGridView gridViewDetail;
        //protected DevExpress.XtraBars.BarButtonItem barButtonItem1;
        //protected DevExpress.XtraBars.BarButtonItem barButtonItem2;
        //protected DevExpress.XtraBars.BarButtonItem barButtonItemCommit;
        //protected DevExpress.XtraBars.BarButtonItem barButtonItemNoCommit;
        //protected DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        //protected DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        //protected DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        //private System.ComponentModel.IContainer components;
        //private DevExpress.XtraBars.BarSubItem barSubItem1;
        //private DevExpress.XtraBars.BarButtonItem barButtonItemXem;
        //protected DevExpress.XtraBars.BarButtonItem barButtonItemClose;
        //private DevExpress.XtraBars.PopupMenu popupMenuFilter;
        //protected DevExpress.XtraBars.BarCheckItem barCheckItemFilter;
        //private DevExpress.XtraBars.BarButtonItem barButtonItemSearch;
        //private DevExpress.XtraBars.BarButtonItem barButtonItem3;
        //private DevExpress.XtraBars.PopupMenu popupMenu1;
        //private DevExpress.XtraBars.BarButtonItem barButtonItem4;
        //#endregion

        #region 1.Phần chỉ thay đổi code bên trong hàm không thay đổi tên phương thức
        PhieuQuanLyFix that;
        ProtocolVN.Framework.Win.PagerInfo pg;

        public frmHoSoQL()
        {
            InitializeComponent();
            HelpDebug.SetTitle(this, Status);

            this.IDField = "ID";
            DisplayField = "HO_TEN";
            that = new PhieuQuanLyFix(this, typeof(frmHoSoQL).FullName,UpdateRow());
            this.gridViewMaster.RowCountChanged += new EventHandler(gridViewMaster_RowCountChanged);
            
        }
        
        public override void InitColumnMaster()
        {
            Cot_ID.FieldName = "ID";
            Cot_ID.VisibleIndex = -1;
            Cot_ViTriTuyenDung.FieldName = "VT_TUYEN_DUNG";
            XtraGridSupportExt.TextLeftColumn(Cot_ViTriTuyenDung, "VT_TUYEN_DUNG");
            HelpGridColumn.CotTextLeft(CotMaHoSo, "MA_HO_SO");
            XtraGridSupportExt.TextLeftColumn(Cot_Ten, "HO_TEN");
            XtraGridSupportExt.TextCenterColumn(Cot_NgaySinh, "NGAY_SINH");
            XtraGridSupportExt.TextLeftColumn(Cot_GioiTinh, "SEX");
            XtraGridSupportExt.TextRightColumn(Cot_LuongMongDoi, "LUONG_MONG_DOI");
            XtraGridSupportExt.TextLeftColumn(Cot_TinhTrangHS, "TINH_TRANG_HO_SO");
            XtraGridSupportExt.TextLeftColumn(Cot_LoaiHoSo, "TEN_LOAI_HO_SO");
            XtraGridSupportExt.TextLeftColumn(Cot_Mail, "EMAIL");
            XtraGridSupportExt.TextLeftColumn(Cot_DienThoai, "DIEN_THOAI");
            XtraGridSupportExt.TextLeftColumn(Cot_DiaChi, "DIA_CHI");
            HelpGridColumn.CotDateEdit(CotNgayCapNhat, "NGAY_CAP_NHAT_HO_SO");
            GridColumn ColIsEmp = HelpGridColumn.ThemCot(this.gridViewMaster, "Chuyển tới nhân viên", 12,10);
            HelpGridColumn.CotPLImageCheck(ColIsEmp, "IS_EMPLOYEE");
            Cot_DiaChi.Visible = false;
        }

        public override void InitColumDetail()
        {

        }

        public override void PLLoadFilterPart()
        {
            DMTinhTrangHoSo.I.InitCtrl(Filter_TinhTrangHoSo, true, true);
            InitVTUT(Filter_VTUngTuyen, false);
            InitLoaiHoSo(PLLoaiHoSo);
            HelpGridExt1.DisableCaptionGroupCol(this.gridViewMaster);
            this.gridViewMaster.OptionsView.ShowGroupPanel = false;
            HelpControl.RedCheckEdit(chkQTCT, false);
            HelpControl.RedCheckEdit(chkQTDT, false);
            HelpControl.RedCheckEdit(chkTDCM, false);
            HelpControl.RedCheckEdit(chkTDNN, false);
            HelpControl.RedCheckEdit(chkTTK, false);
            ngayCapNhat.DateTime = HelpDB.getDatabase().GetSystemCurrentDateTime().AddDays(-7);
            Filter_GTNam.Checked = true;
            Filter_GTNu.Checked = true;
            Filter_GTNam.CheckedChanged += delegate(object check, EventArgs checkedChanged) {
                if (Filter_GTNam.CheckState == CheckState.Unchecked
                    && Filter_GTNu.CheckState == CheckState.Unchecked) Filter_GTNam.Checked = true;
            };
            Filter_GTNu.CheckStateChanged += delegate(object check, EventArgs checkedChanged) {
                if (Filter_GTNu.CheckState == CheckState.Unchecked
                    && Filter_GTNam.CheckState == CheckState.Unchecked) Filter_GTNu.Checked = true;
            };
        }
        public static string HTMLtoText(string HTML)
        {
            System.Text.RegularExpressions.Regex reg = new System.Text.RegularExpressions.Regex("<[^>]*>");
            string s = reg.Replace(HTML, "");
            return s.Replace("&nbsp;", " ");
        }
        public override QueryBuilder PLBuildQueryFilter()
        {
            #region dathq
            QueryBuilder filter = new QueryBuilder(UpdateRow());
            filter.addSoPhieu("UPPER(MA_HO_SO)", txtMaHoSo.Text.Trim().ToUpper());
            filter.addLike("UPPER(HO_TEN)", Filter_Ten.Text.Trim().ToUpper());
            filter.addLike("UPPER(EMAIL)", Filter_Email.Text.Trim().ToUpper());
            filter.addID("TTHS_ID", Filter_TinhTrangHoSo._getSelectedID());
            filter.addID("LOAI_HO_SO", PLLoaiHoSo._getSelectedID());
            filter.addCondition(" EXTRACT(YEAR FROM NGAY_SINH) BETWEEN " + Filter_NamSinhTu.Value + " AND " + Filter_NamSinhDen.Value);
            if (Filter_GTNam.Checked && Filter_GTNu.Checked) filter.addCondition("GIOI_TINH IN ('Y','N')");
            else
            {
                if (Filter_GTNam.Checked) filter.addCondition("GIOI_TINH ='Y'");
                else if (Filter_GTNu.Checked) filter.addCondition("GIOI_TINH ='N'");
            }

            StringBuilder textTuKhoa = FilterCheckBox();
            filter.addCondition(textTuKhoa.ToString());
            filter.addCondition(string.Format("NGAY_CAP_NHAT_HO_SO >= '{0}'", ngayCapNhat.DateTime.ToString("MM/dd/yyyy")));
            long[] IDs = Filter_VTUngTuyen._getSelectedIDs();
            if (IDs.Length > 0 && IDs.Length < Filter_VTUngTuyen.Properties.GetItems().Count)
            {
                string cond = "(";
                foreach (long id in IDs)
                {
                    cond += "VT_ID" + " like '%," + id + "' or " + "VT_ID" + " like '" + id + ",%' or " + "VT_ID" + " like '%," + id + ",%' or ";
                }
                cond = cond.TrimEnd(' ', 'r', 'o');
                cond = cond += ")";
                filter.addCondition(cond);
            }
            filter.addCondition("TTHS_ID IN (SELECT ID FROM DM_TINH_TRANG_HO_SO WHERE VISIBLE_BIT = 'Y')");
            filter.addCondition(" 1=1 ");
            FrameworkParams.wait = new WaitingMsg();

            DataTable Resume = HelpDB.getDatabase().LoadDataSet(filter).Tables[0];

            if (Resume != null)
            {
                //DataTable Resume_Ung_Tuyen = DABase.getDatabase().LoadDataSet(
                //@"SELECT REUT.R_ID,REUT.VTUT_ID,NAME FROM RESUME_UNG_TUYEN REUT INNER JOIN DM_VI_TRI_UNG_TUYEN VT ON REUT.VTUT_ID=VT.ID").Tables[0];
                //StringBuilder Str = new StringBuilder("");
                //for (int i = 0; i < Filter_VTUngTuyen.ItemCount; i++)
                //{
                //    if (Filter_VTUngTuyen.GetItemCheckState(i) == CheckState.Checked)
                //        Str.Append(Filter_VTUngTuyen.GetItemValue(i) + ",");
                //    Application.DoEvents();
                //}
                //if (Str.Length > 0) Str.Remove(Str.Length - 1, 1);
                //for (int i = Resume.Rows.Count - 1; i >= 0; i--)
                //{
                //    StringBuilder Str_cond = new StringBuilder("R_ID = " + HelpNumber.ParseInt64(Resume.Rows[i]["ID"]));
                //    if (Str.Length > 0)
                //        Str_cond.Append(" and VTUT_ID in (" + Str + ")");
                //    DataRow[] Arr_row = Resume_Ung_Tuyen.Select(Str_cond.ToString());
                //    if (Arr_row.Length > 0)
                //    {
                //        StringBuilder Str_Name = new StringBuilder("");
                //        foreach (DataRow row_InArr in Arr_row)
                //        {
                //            Str_Name.Append(row_InArr["NAME"] + ",");
                //        }
                //        if (Str_Name.Length > 0) Str_Name.Remove(Str_Name.Length - 1, 1);
                //        Resume.Rows[i]["VT_TUYEN_DUNG"] = Str_Name.ToString();
                //    }
                //    else Resume.Rows.RemoveAt(i);
                //    Application.DoEvents();
                //}
                //gridControlMaster.DataSource = Resume;
                gridViewMaster.OptionsBehavior.Editable = true;
                //pager = new PagerGrid(gridControlMaster, this.gridViewMaster, 5);
                //New update for get detail of Ung Vien
                //pager.DetailOfFirtsRows += new PagerGrid.GetDetail(PLLoadDataDetailPart);
                //------------------------
                //pg = new ProtocolVN.Framework.Win.PagerInfo();
                this.splitContainerControl1.SplitterPosition = 200;
                Cot_Ten.SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;
                if (FrameworkParams.wait != null) FrameworkParams.wait.Finish();
            }
            #endregion

            return filter;
        }

        private StringBuilder FilterCheckBox()
        {
            StringBuilder textTuKhoa = new StringBuilder();
            if (chkQTDT.Checked == true)
            {
                textTuKhoa.Append(" UPPER(CAST(QUA_TRINH_DAO_TAO AS TEXT))LIKE '%" + tukhoa.Text.ToUpper() + "%' or ");
            }
            if (chkQTCT.Checked == true)
            {
                textTuKhoa.Append(" UPPER(CAST(QUA_TRINH_CONG_TAC AS TEXT))LIKE '%" + tukhoa.Text.ToUpper() + "%' or ");
            }
            if (chkTDCM.Checked == true)
            {
                textTuKhoa.Append(" UPPER(CAST (TRINH_DO_CHUYEN_MON AS TEXT))LIKE '%" + tukhoa.Text.ToUpper() + "%' or ");
            }
            if (chkTDNN.Checked == true)
            {
                textTuKhoa.Append(" UPPER(CAST(TRINH_DO_NGOAI_NGU AS TEXT))LIKE '%" + tukhoa.Text.ToUpper() + "%' or ");
            }
            if (chkTTK.Checked == true)
            {
                textTuKhoa.Append(" UPPER(CAST(THONG_TIN_KHAC AS TEXT))LIKE '%" + tukhoa.Text.ToUpper() + "%' or ");
            }
            if (textTuKhoa.ToString().Equals(""))
            {
                textTuKhoa.Append("1=1");
            }
            else
            {
                textTuKhoa.Append("1=2");
            }
            return textTuKhoa;
        }

        public override DataTable PLLoadDataDetailPart(long MasterID)
        {
            try
            {
                QueryBuilder query = new QueryBuilder("select * from RESUME where 1=1");
                query.add("ID", Operator.Equal, MasterID, DbType.Int32);
                DataTable dt = HelpDB.getDatabase().LoadDataSet(query, "DETAIL").Tables[0];
                this.Web_TrinhDoChuyenMon.DocumentText = HelpByte.BytesToUTF8String((Byte[])dt.Rows[0]["TRINH_DO_CHUYEN_MON"]);
                this.Web_TrinhDoNgoaiNgu.DocumentText = HelpByte.BytesToUTF8String((Byte[])dt.Rows[0]["TRINH_DO_NGOAI_NGU"]);
                this.Web_ThongTinKhac.DocumentText = HelpByte.BytesToUTF8String((Byte[])dt.Rows[0]["THONG_TIN_KHAC"]);
                this.Web_QuaTrinhCongTac.DocumentText = HelpByte.BytesToUTF8String((Byte[])dt.Rows[0]["QUA_TRINH_CONG_TAC"]);
                this.Web_QuaTrinhDaoTao.DocumentText = HelpByte.BytesToUTF8String((Byte[])dt.Rows[0]["QUA_TRINH_DAO_TAO"]);
                return dt;
            }
            catch (Exception)
            {
                return null;
            }
        }
        
        public override void ShowViewForm(long id)
        {
            //frmHoSoUngVien PhieuHoSo = new frmHoSoUngVien(id, null,false);
            //HelpProtocolForm.ShowModalDialog(this, PhieuHoSo);
            frmThongTinUngVien frm = new frmThongTinUngVien(id);
            HelpProtocolForm.ShowDialog(this, frm);
        }

        public override void ShowUpdateForm(long id)
        {
            frmHoSoUngVien PhieuHoSo = new frmHoSoUngVien(id, false, false);
            //Current_page = pager.Get_Current_page();            
            HelpProtocolForm.ShowModalDialog(this, PhieuHoSo);         
           
        }

        public override long[] ShowAddForm()
        {
            frmHoSoUngVien PhieuHoSo = new frmHoSoUngVien(true);
            HelpProtocolForm.ShowModalDialog(this, PhieuHoSo);
            return null;
        }

        public override bool XoaAction(long id)
        {
            return DAResume.Delete(id);
        }
      
        public override _MenuItem GetBusinessMenuList()
        {
            _MenuItem mnu = new _MenuItem(
               new string[] { "Tuyển dụng", "Gửi thư mời phỏng vấn", "Cập nhật tình trạng hồ sơ", "Xem nhanh thông tin", "Chuyển tới danh sách nhân viên" },
               new string[] { "add.png", "mnbmessage.gif", "fwExit.png", "fwView.png", "add.png" },
               "ID",
               new DelegationLib.CallFunction_MulIn_NoOut[]{    
                    ChonPhongVan,GuiThuPhongVan,CapNhatHoSo,XemNhanhThongTin,ChuyenHoSoVaoDmNhanVien
                }, null);
            return mnu;
        }

        
        private void ChuyenHoSoVaoDmNhanVien(List<object> ids)
        {
            if (ids != null && ids.Count > 0)
            {
                DataTable dt = gridControlMaster.DataSource as DataTable;
                //Adds PrimaryKey for using Find method in DataTable.
                dt.PrimaryKey = new DataColumn[] { dt.Columns["ID"] };
                for (int i = ids.Count - 1; i >= 0; i--)
                {
                    DataRow row = dt.Rows.Find(ids[i]);
                    if (string.Compare(row["IS_EMPLOYEE"].ToString(), "Y") == 0)
                    {
                        HelpMsgBox.ShowNotificationMessage(string.Format("Ứng viên \"{0}\" đã được chuyển tới danh sách nhân viên!", row["HO_TEN"].ToString()));
                        ids.RemoveAt(i);
                    }
                }
                if (ids.Count == 0) return;
                frmAddEmployee form =  new frmAddEmployee(ids);
                form._Refresh += new frmAddEmployee.RefreshParrentForm(that.PLRefresh);
                HelpProtocolForm.ShowModalDialog(this, form);
            }
        }
        private void XemNhanhThongTin(List<object> ids)
        {
            if (ids != null && ids.Count > 0)
            {
                frmThongTinUngVien frm = new frmThongTinUngVien(ids[0]);
                HelpProtocolForm.ShowDialog(this, frm);
            }
        }

        private void CapNhatHoSo(List<object> ids)
        {
            if (ids != null && ids.Count > 0)
            {
                frmCapNhatTinhTrangHoSo frm = new frmCapNhatTinhTrangHoSo(DAResume.GuiThuPhongVan(ids));
                HelpProtocolForm.ShowModalDialog(this, frm);
                PLBuildQueryFilter();
            }
        }

        private void ChonPhongVan(List<object> ids)
        {
            if (ids != null && ids.Count > 0)
            {
                if (DAHenPhongVan.ExistRecord((long)ids[0]))
                {
                    HelpMsgBox.ShowNotificationMessage("Nhân viên này đã được hẹn phỏng vấn !");
                    return;
                }
                frmPhongVan PhongVan = new frmPhongVan(long.Parse(ids[0].ToString()),-1, true);
                HelpProtocolForm.ShowModalDialog(this, PhongVan);
            }
        }

        private void GuiThuPhongVan(List<object> ids)
        {
            if (ids != null && ids.Count > 0)
            {
                frmGuiThuHenPhongVan frm = new frmGuiThuHenPhongVan(DAResume.GuiThuPhongVan(ids));
                HelpProtocolForm.ShowDialog(this, frm);
            }
        }

        private void GuiThuMoiPhongVan(List<object> ids)
        {
            if (ids != null && ids.Count > 0)
            {
                List<DOResume> dsKhongGuiDuoc = new List<DOResume>();
                try
                {
                    FrameworkParams.wait = new FWWaitingMsg();
                    List<DOResume> dsChon = DAResume.GuiThuChonPhongVan(ids);
                    for (int i = 0; i < dsChon.Count; i++)
                    {
                        DOResume Resume = dsChon[i];
                        DataTable dt = CoverDataTable(Resume);
                        DataSet ds = new DataSet();
                        ds.Tables.Add(dt);
                        List<String> mailaddress = new List<string>();
                        mailaddress.Add(Resume.EMAIL);
                        if (!HelpEmail.SentMessageTemplateHTMLOutside(mailaddress, ds, "Thư mời phỏng vấn", "Report\\ThuPhongVan.doc", null))
                            dsKhongGuiDuoc.Add(Resume);
                    }                    
                }
                catch (Exception ex)
                {
                    HelpMsgBox.ShowErrorMessage(ex.Message);
                }
                finally
                {
                    if (FrameworkParams.wait != null) FrameworkParams.wait.Finish();
                    if (dsKhongGuiDuoc.Count == 0)
                        HelpMsgBox.ShowNotificationMessage("Thực hiện gửi mail thành công");
                    else
                        HelpMsgBox.ShowNotificationMessage("Có " + dsKhongGuiDuoc.Count.ToString() + " email gửi không thành công.");
                }
            }
        }

        public override _MenuItem GetMenuAppendGridList()
        {
            return null;
        }

        public override _Print InAction(long[] ids)
        {
            if (ids.Length > 1)
            {
                HelpMsgBox.ShowNotificationMessage("Không được phép chọn nhiều hơn 1 ứng viên!");
                return null;
            }
            else
                return DAResume.GetPrintObj(this, ids[0]);
        }

        public override string UpdateRow()
        {
            //PLBuildQueryFilter();
            //pager.Set_Current_page(Current_page);
            return @"SELECT * FROM QL_UNGVIEN WHERE 1=1";
//            return @"SELECT ID
//                ,(SELECT LIST (NAME)
//                    FROM RESUME_UNG_TUYEN REUT INNER JOIN DM_VI_TRI_UNG_TUYEN VT ON REUT.VTUT_ID=VT.ID
//                    WHERE REUT.R_ID=RE.ID) VT_TUYEN_DUNG,
//                 RE.MA_HO_SO
//                ,RE.HO_TEN,RE.NGAY_SINH,CASE RE.GIOI_TINH WHEN 'Y' THEN 'Nam' ELSE 'N?' END GIOI_TINH
//                ,RE.LUONG_MONG_DOI,RE.EMAIL,RE.DIA_CHI,RE.DIEN_THOAI,RE.NGAY_CAP_NHAT_HO_SO,RE.IS_EMPLOYEE
//                ,RE.TRINH_DO_CHUYEN_MON,RE.TRINH_DO_NGOAI_NGU,RE.THONG_TIN_KHAC,RE.QUA_TRINH_CONG_TAC,RE.QUA_TRINH_DAO_TAO
//                ,(SELECT NAME FROM DM_TINH_TRANG_HO_SO WHERE ID= RE.TTHS_ID) TINH_TRANG_HO_SO    
//                , CASE RE.LOAI_HO_SO WHEN 0 THEN '?ng viên'
//                                     WHEN 1 THEN 'Nhân viên'
//                                     WHEN 2 THEN 'C?ng tác viên'
//                                     WHEN 3 THEN 'Th?c t?p'
//                                     ELSE 'Bán th?i gian' END LOAI_HO_SO
//            FROM RESUME RE WHERE 1=1";
        }
        #endregion

        #region 2.Phần mở rộng
        void gridViewMaster_RowCountChanged(object sender, EventArgs e)
        {
            if (gridViewMaster.RowCount > 0)
            {
                barSubItem1.Enabled = true;
            }
            
        }
        private ArrayList getDanhSachUngTuyen()
        {
            ArrayList arr = new ArrayList();
            //int iCountItem = HelpDB.getDatabase().LoadTable("DM_VI_TRI_UNG_TUYEN").Tables[0].Rows.Count;
            //for (int i = 0; i < iCountItem; i++)
            //{
            //    if (Filter_VTUngTuyen.GetItemCheckState(i) == CheckState.Checked)
            //        arr.Add(Filter_VTUngTuyen.GetItemValue(i));
            //}
            return arr;
        }
        private string getViTriUngTuyen()
        {
            ArrayList ar = this.getDanhSachUngTuyen();
            string Kq = "";
            for (int i = 0; i < ar.Count; i++)
            {
                Kq += ar[i].ToString();
                if (i < ar.Count - 1)
                    Kq += ",";
            }
            if (Kq.Length > 0)
                return Kq;
            return "";
        }
        private string getGioiTinh()
        {
            if ((Filter_GTNam.Checked == false && Filter_GTNu.Checked == false)
                || (Filter_GTNam.Checked == true && Filter_GTNu.Checked == true)
             ) return "A";
            if (Filter_GTNam.Checked == true && Filter_GTNu.Checked == false)
                return "Y";
            if (Filter_GTNam.Checked == false && Filter_GTNu.Checked == true)
                return "N";
            return "A";
        }
        public bool CheckAllNamNu()
        {
            if (this.Filter_GTNam.Checked == false)
                return false;
            if (this.Filter_GTNu.Checked == false)
                return false;
            return true;
        }
        private void ThongKeViTriUngTuyen()
        {
            DataTable tb = (DataTable)gridControlMaster.DataSource;
            for (int i = 0; i < tb.Rows.Count; i++)
            {
                string ID = tb.Rows[i]["ID"].ToString();
                string chuoi = DAViTriUngTuyen.DanhSachVTUT(int.Parse(ID));
                gridViewMaster.SetRowCellValue(i, "VI_TRI_TUYEN_DUNG", (object)chuoi);
            }

        }
        //Ho tro Email cho Trung
        private DataTable CoverDataTable(DOResume item)
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
            DataRow dr = dt.NewRow();
            dr["DIA_CHI"] = item.DIA_CHI;
            dr["DIEN_THOAI"] = item.DIEN_THOAI;
            dr["ID"] = item.ID;
            dr["EMAIL"] = item.EMAIL;
            dr["LOAI_HO_SO"] = item.LOAI_HO_SO;
            dr["GIOI_TINH"] = (item.GIOI_TINH == "Y") ? "Anh" : "Chị";
            dr["LUONG_MONG_DOI"] = item.LUONG_MONG_DOI;
            dr["NGAY_CAP_NHAT_HO_SO"] = item.NGAY_CAP_NHAT_HO_SO;
            dr["NGAY_SINH"] = item.NGAY_SINH;
            dr["QUA_TRINH_CONG_TAC"] = item.QUA_TRINH_CONG_TAC;
            dr["QUA_TRINH_DAO_TAO"] = item.QUA_TRINH_DAO_TAO;
            dr["TEN"] = item.TEN;
            dr["THONG_TIN_KHAC"] = item.THONG_TIN_KHAC;
            dr["TINH_TRANG_HON_NHAN"] = item.TINH_TRANG_HON_NHAN;
            dr["TRINH_DO_CHUYEN_MON"] = item.TRINH_DO_CHUYEN_MON;
            dr["TRINH_DO_NGOAI_NGU"] = item.TRINH_DO_NGOAI_NGU;
            dt.Rows.Add(dr);
            return dt;

        }
        private void frmTestPhieuQuanLy_Load(object sender, EventArgs e)
        {

        }

        private void InitLoaiHoSo(PLImgCombobox Input)
        {
            DataTable dt = new DataTable("LOAI_HO_SO");
            dt.Columns.AddRange(new DataColumn[] { 
                new DataColumn("ID",Type.GetType("System.Int32")),
                new DataColumn("NAME",Type.GetType("System.String"))
            });
            DataRow row = dt.NewRow();
            row["ID"] = 0;
            row["NAME"] = "Ứng viên";
            dt.Rows.Add(row);
            DataRow row1 = dt.NewRow();
            row1["ID"] = 1;
            row1["NAME"] = "Nhân viên";
            dt.Rows.Add(row1);
            DataRow row2 = dt.NewRow();
            row2["ID"] = 2;
            row2["NAME"] = "Cộng tác viên";
            dt.Rows.Add(row2);
            DataRow row3 = dt.NewRow();
            row3["ID"] = 3;
            row3["NAME"] = "Thực tập viên";
            dt.Rows.Add(row3);
            DataRow row4 = dt.NewRow();
            row4["ID"] = 4;
            row4["NAME"] = "Bán thời gian";
            dt.Rows.Add(row4);
            DataSet ds = new DataSet();
            ds.Tables.Add(dt);
            Input._init(ds.Tables[0], "NAME", "ID");
        }

        private void InitVTUT(PLMultiCombobox Input, bool? IsAdd) 
        {
            bool IsVisible = false;
            if (IsAdd == true) IsVisible = true;
            QueryBuilder query = null;
            if (IsVisible)
                query = new QueryBuilder("SELECT * FROM DM_VI_TRI_UNG_TUYEN where VISIBLE_BIT = 'Y' AND 1=1");
            else
                query = new QueryBuilder("SELECT * FROM DM_VI_TRI_UNG_TUYEN where 1=1");
            query.setAscOrderBy("NAME");
            DataSet ds = HelpDB.getDatabase().LoadReadOnlyDataSet(query);
            Input._init(ds.Tables[0], "NAME", "ID");
        }

        #endregion

        #region IFormRefresh Members

        public object _RefreshAction(params object[] input)
        {
            //this.PLLoadFilterPart();
            return null;
        }

        #endregion

    }
}
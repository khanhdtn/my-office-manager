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
using ProtocolVN.Framework.Dev.Open;
using DevExpress.XtraGrid.Columns;

namespace pl.office.form
{
    public partial class frmHoSoUngVienQL :PhieuQuanLyChange
    {
        #region Vùng đặt Static
        public static FormStatus Status = FormStatus.OK_TEST;

        public static string MenuItem(string ParentID, bool IsSep)
        {
            return MenuBuilder.CreateItem(typeof(frmHoSoUngVienQL).FullName,
                "Hồ sơ ứng viên",
                ParentID, true,
                typeof(frmHoSoUngVienQL).FullName, true,
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
        PagerGrid pager;
        ProtocolVN.Framework.Win.PagerInfo pg;
        int Current_page;


        public frmHoSoUngVienQL()
        {
            InitializeComponent();
            PMSupport.SetTitle(this, Status);

            this.IDField = "ID";
            DisplayField = "O_HO_TEN";
            that = new PhieuQuanLyFix(this);
            this.gridViewMaster.RowCountChanged += new EventHandler(gridViewMaster_RowCountChanged);
            Uncategory.setEnterAsTab(this);
        }
        
        public override void InitColumnMaster()
        {
            Cot_ID.FieldName = "ID";
            Cot_ID.VisibleIndex = -1;
            Cot_ViTriTuyenDung.FieldName = "O_VI_TRI_TUYEN_DUNG";
            XtraGridSupportExt.TextLeftColumn(Cot_ViTriTuyenDung, "O_VI_TRI_UNG_TUYEN");
            HelpGridColumn.CotTextLeft(CotMaHoSo, "O_MA_HO_SO");
            XtraGridSupportExt.TextLeftColumn(Cot_Ten, "O_HO_TEN");
            XtraGridSupportExt.TextCenterColumn(Cot_NgaySinh, "O_NGAY_SINH");
            XtraGridSupportExt.TextLeftColumn(Cot_GioiTinh, "O_GIOI_TINH");
            XtraGridSupportExt.TextRightColumn(Cot_LuongMongDoi, "O_LUONG_MONG_MUON");
            XtraGridSupportExt.TextLeftColumn(Cot_TinhTrangHonNhan, "O_TINH_TRANG_HON_NHAN");
            XtraGridSupportExt.TextLeftColumn(Cot_TinhTrangHS, "O_TINH_TRANG_HO_SO");
            XtraGridSupportExt.TextLeftColumn(Cot_Mail, "O_EMAIL");
            XtraGridSupportExt.TextLeftColumn(Cot_DienThoai, "O_DIEN_THOAI");
            XtraGridSupportExt.TextLeftColumn(Cot_DiaChi, "O_DIA_CHI");
            HelpGridColumn.CotDateEdit(CotNgayCapNhat, "O_NGAY_CAP_NHAT");
            GridColumn ColIsEmp = HelpGridColumn.ThemCot(this.gridViewMaster, "Chuyển tới nhân viên", 12,10);
            HelpGridColumn.CotPLImageCheck(ColIsEmp, "O_IS_EMPLOYEE");
            Cot_DiaChi.Visible = false;
        }

        public override void InitColumDetail()
        {

        }

        public override void PLLoadFilterPart()
        {
            DMTinhTrangHoSo.I.InitCtrl(Filter_TinhTrangHoSo, true, null);
            Filter_DotPhongVan._init("DM_DOT_TUYEN_DUNG", "NAME", "ID");
            DMViTriUngTuyen.I.InitCtrl(Filter_VTUngTuyen,true);
            Filter_GTNam.Checked = true;
            Filter_GTNu.Checked = true;
            DMCLoaiHoSo.InitCtrl(PLLoaiHoSo, true);
        }

        public override QueryBuilder PLBuildQueryFilter()
        {
            DataTable KQ = DAResume.ThongKe(textEdit1.Text.Trim().ToUpper(), Filter_Ten.Text, Filter_Email.Text, this.getGioiTinh(), (int)Filter_NamSinhTu.Value, (int)Filter_NamSinhDen.Value,
                (int)Filter_DotPhongVan._getSelectedID(), Filter_TinhTrangHoSo._getSelectedID(),
                this.getViTriUngTuyen(), this.PLLoaiHoSo._getSelectedID().ToString()
            );
            if (KQ != null)
            {
                #region Delete duplicate row
                int[] index = new int[KQ.Rows.Count];
                for(int i=0;i<KQ.Rows.Count-1;i++)
                {
                    for (int j=i+1; j < KQ.Rows.Count; j++) 
                    {
                        if (KQ.Rows[i]["ID"].ToString() == KQ.Rows[j]["ID"].ToString())
                        {
                            index[j] = KQ.Rows.IndexOf(KQ.Rows[j]);
                        }
                    }
                }
                foreach (int del_index in index)
                {
                    if (index[del_index] > 0)
                        KQ.Rows.RemoveAt(index[del_index]);
                }
                #endregion  
                gridControlMaster.DataSource = KQ;
            }
            pager = new PagerGrid(gridControlMaster,this.gridViewMaster, 5);
            pg = new ProtocolVN.Framework.Win.PagerInfo();
            this.splitContainerControl1.SplitterPosition = 200;
            Cot_Ten.SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;
            return null;
        }

        public override DataTable PLLoadDataDetailPart(long MasterID)
        {
            try
            {
                QueryBuilder query = new QueryBuilder("select * from RESUME where 1=1");
                query.add("ID", Operator.Equal, MasterID, DbType.Int32);
                DataTable dt = DABase.getDatabase().LoadDataSet(query, "DETAIL").Tables[0];
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
            frmHoSoUngVien PhieuHoSo = new frmHoSoUngVien(id, null,false);
            ProtocolForm.ShowModalDialog(this, PhieuHoSo);
        }

        public override void ShowUpdateForm(long id)
        {
            frmHoSoUngVien PhieuHoSo = new frmHoSoUngVien(id, false,false);            
            Current_page = pager.Get_Current_page();            
            ProtocolForm.ShowModalDialog(this, PhieuHoSo);            
        }

        public override long[] ShowAddForm()
        {
            frmHoSoUngVien PhieuHoSo = new frmHoSoUngVien(true);
            ProtocolForm.ShowModalDialog(this, PhieuHoSo);
            return null;
        }

        public override bool XoaAction(long id)
        {
            return DAResume.Delete(id);
        }
      
        public override _MenuItem GetBusinessMenuList()
        {
            _MenuItem mnu = new _MenuItem(
               new string[] { "Tuyển dụng", "Gửi thư mời phỏng vấn", "Cập nhật tình trạng hồ sơ", "Xem nhanh thông tin","Chuyển tới danh sách nhân viên" },
               new string[] { "NghiepVuChonPhongVan", "NghiepVuGuiThuMoiPhongVan", "CapNhatHoSo", "NghiepVuXemNhanhThongTin","ChuyenHoSoVaoDmNhanVien" },
               "ID",
               new DelegationLib.CallFunction_MulIn_NoOut[]{    
                    ChonPhongVan,GuiThuPhongVan,CapNhatHoSo,XemNhanhThongTin,ChuyenHoSoVaoDmNhanVien
                },
               new PermissionItem[]{
                    PLPermission.OPhongVan.GetPermissionItem(PermissionType.VIEW_HIDE),
                    PLPermission.FGuiThuMoiPhongVan.GetPermissionItem(PermissionType.VIEW_HIDE),
                    PLPermission.OHoSoUngVien.GetPermissionItem(PermissionType.EDIT),
                    PLPermission.OHoSoUngVien.GetPermissionItem(PermissionType.VIEW_HIDE),
                    PLPermission.FChuyenUngVienToiNhanVien.GetPermissionItem(PermissionType.VIEW_HIDE)
               });
            return mnu;
        }
        private void ChuyenHoSoVaoDmNhanVien(List<object> ids)
        {
            if (ids != null && ids.Count > 0)
            {
                frmAddEmployee form =  new frmAddEmployee(ids);
                form._Refresh += new frmAddEmployee.RefreshParrentForm(that.PLRefresh);
                ProtocolForm.ShowModalDialog(this,form);
            }
        }
        private void XemNhanhThongTin(List<object> ids)
        {
            if (ids != null && ids.Count > 0)
            {
                frmThongTinUngVien frm = new frmThongTinUngVien(ids[0]);
                ProtocolForm.ShowDialog(this, frm);
            }
        }

        private void CapNhatHoSo(List<object> ids)
        {
            if (ids != null && ids.Count > 0)
            {
                frmCapNhatTinhTrangHoSo frm = new frmCapNhatTinhTrangHoSo(DAResume.GuiThuPhongVan(ids));
                ProtocolForm.ShowModalDialog(this, frm);
                PLBuildQueryFilter();
            }
        }

        private void ChonPhongVan(List<object> ids)
        {
            if (ids != null && ids.Count > 0)
            {
                if (DAHenPhongVan.ExistRecord((long)ids[0]))
                {
                    PLMessageBox.ShowNotificationMessage("Nhân viên này đã được hẹn phỏng vấn !");
                    return;
                }
                frmPhongVan PhongVan = new frmPhongVan(long.Parse(ids[0].ToString()),-1, TrangThaiForm.Other);
                ProtocolForm.ShowModalDialog(this, PhongVan);
            }
        }

        private void GuiThuPhongVan(List<object> ids)
        {
            if (ids != null && ids.Count > 0)
            {
                frmGuiThuHenPhongVan frm = new frmGuiThuHenPhongVan(DAResume.GuiThuPhongVan(ids));
                ProtocolForm.ShowDialog(this, frm);
            }
        }

        private void GuiThuMoiPhongVan(List<object> ids)
        {
            if (ids != null && ids.Count > 0)
            {
                List<DOResume> dsKhongGuiDuoc = new List<DOResume>();
                try
                {
                    FrameworkParams.wait = new WaitingMsg();
                    List<DOResume> dsChon = DAResume.GuiThuChonPhongVan(ids);
                    for (int i = 0; i < dsChon.Count; i++)
                    {
                        DOResume Resume = dsChon[i];
                        DataTable dt = CoverDataTable(Resume);
                        DataSet ds = new DataSet();
                        ds.Tables.Add(dt);
                        List<String> mailaddress = new List<string>();
                        mailaddress.Add(Resume.EMAIL);
                        if (!ProtocolVN.Framework.Win.Message.SentMessageTemplateHTMLOutside(mailaddress, ds, "Thư mời phỏng vấn", "Report\\ThuPhongVan.doc", null))
                            dsKhongGuiDuoc.Add(Resume);
                    }                    
                }
                catch (Exception ex)
                {
                    PLMessageBox.ShowErrorMessage(ex.Message);
                }
                finally
                {
                    if (FrameworkParams.wait != null) FrameworkParams.wait.Finish();
                    if (dsKhongGuiDuoc.Count == 0)
                        PLMessageBox.ShowNotificationMessage("Thực hiện gửi mail thành công");
                    else
                        PLMessageBox.ShowNotificationMessage("Có " + dsKhongGuiDuoc.Count.ToString() + " email gửi không thành công.");
                }
            }
        }

        public override _MenuItem GetMenuAppendGridList()
        {
            return null;
        }

        public override _Print InAction(long[] ids)
        {
            return null;
        }

        public override string UpdateRow()
        {
            PLBuildQueryFilter();
            pager.Set_Current_page(Current_page);
            return "";
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
            int iCountItem = DABase.getDatabase().LoadTable("DM_VI_TRI_UNG_TUYEN").Tables[0].Rows.Count;
            for (int i = 0; i < iCountItem; i++)
            {
                if (Filter_VTUngTuyen.GetItemCheckState(i) == CheckState.Checked)
                    arr.Add(Filter_VTUngTuyen.GetItemValue(i));
            }
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
        #endregion
    }
}
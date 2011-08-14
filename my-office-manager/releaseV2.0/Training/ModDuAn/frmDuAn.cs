using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraEditors.DXErrorProvider;
using ProtocolVN.Framework.Win;
using ProtocolVN.Framework.Core;
using DAO;
using ProtocolVN.DanhMuc;
using DTO;
using System.Drawing;
using DevExpress.XtraGrid.Views.Layout.ViewInfo;
using ProtocolVN.Framework.Dev.Open;

namespace pl.office.form
{
    public partial class frmDuAn : XtraFormPL
    {
        #region Vùng đặt Static 
        public static FormStatus Status = FormStatus.NO_USE;
        public static string MenuItem(string ParentID, bool IsSep)
        {
            return MenuBuilder.CreateItem(typeof(frmDuAn).FullName,
                PMSupport.UpdateTitle("Thêm mới", Status),
                ParentID, true,
                typeof(frmDuAn).FullName,
                false, IsSep, "add.png", true, "", "");
        }
        #endregion

        #region Các khai báo biến         
        private bool? IsAdd; //true = New, null = View, false = Edit
        private long _ID;
        private DXErrorProvider err;
        List<DOLuuTruTapTin> list_do_tap_tin = new List<DOLuuTruTapTin>();
        List<long> list_id_pccv = new List<long>(); 
        List<long> mang_ID_taptin_dang_xoa = new List<long>();
        List<long> mang_ID_PCCV_dang_xoa = new List<long>();
        DODuAn DO = null;
        public delegate void refreshfrm();
        public event refreshfrm refreshfrda;
        private DOLuuTruTapTin do_luu_tru_tt = null;
        

        #endregion        
             
        #region Hàm dựng 
        public frmDuAn(long ID,bool? IsAdd)
        {
            InitializeComponent();
            err = new DXErrorProvider();
            this.IsAdd = IsAdd;
            this._ID = ID;           
            intfrm();
            PLGUIUtil.setDefaultSize(this);
        }
        public frmDuAn() : this(-2, true) { }
        #endregion

        #region InitForm 
        public void intfrm()
        {            
            #region xac dinh cot trong girdview            
            zoombarTienDo.Properties.Maximum = 100;
            zoombarTienDo.Properties.Minimum = 0;           
            HelpGridColumn.CotTextLeft(CotCongViec, "CONG_VIEC");           
            DACongViec.colMultiline(CotNguoiThucHien, "NV_THAM_GIA");
            HelpGridColumn.CotTextLeft(CotLoaiCongViec, "TEN_LCV");
            HelpGridColumn.CotTextLeft(CotDoUuTien, "TEN_MUC_UU_TIEN");
            HelpGridColumn.CotTextLeft(CotTinhTrang, "TINH_TRANG");
            HelpGridColumn.CotTextCenter(CotTienDo, "TIEN_DO_THUC_HIEN");
            HelpGridColumn.CotTextLeft(CotNguoiGiao, "TEN_NGUOI_GIAO");
            XtraGridSupportExt.DateTimeGridColumn(CotBatDau, "TU_NGAY");
            XtraGridSupportExt.DateTimeGridColumn(CotNgayKetThuc, "DEN_NGAY");
            XtraGridSupportExt.TextCenterColumn(CotTGDuTinh, "THOI_GIAN_DU_KIEN");
            PMSupport.SetTitle(this, Status);
            DMNhanVienX.I.ChonNhanVienLamViec(nguoiquanly, IsAdd);
            PLCtrl.ChonLoaiDuAn(LoaiDA);
            HelpDate.OneWeekAgo(ngaybatdau, ngayketthuc);                     
            DMCMucDoUuTien.I.InitCtrl(Muc_UT,false, true);
            PLCtrl.ChonTinhTrangDuAn(tinhtrang, true, true);
            tinhtrang._setSelectedID(-1);
            LoaiDA.ToolTip = nguoiquanly.ToolTip = string.Empty;
            xtraTabControl1.SelectedPageChanged += new DevExpress.XtraTab.TabPageChangedEventHandler(xtraTabControl1_SelectedPageChanged);
            #endregion          
            gridViewCongviec.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
            gridViewTaiLieu.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
            XtraGridSupportExt.TextLeftColumn(cot_xoa, "xoa_file");
            XtraGridSupportExt.TextLeftColumn(cot_luufile, "luu_file");
            XtraGridSupportExt.TextLeftColumn(cot_mofile, "mo_file");
            XtraGridSupportExt.TextLeftColumn(cot_suafile, "sua_file");
            toolTip1.BackColor = Color.LightYellow;
            layoutView1.OptionsCustomization.AllowSort = false;
            layoutView1.OptionsCustomization.AllowFilter = false;
            
            if (IsAdd == true)
            {                
                btnXoa.Visible = false;
                DO = DADuAn.Instance.LoadAll(-2);                
                DO.ID = DABase.getDatabase().GetID("G_NGHIEP_VU");
                _ID = DO.ID;
                   
               
            }
            //xem
            else
            {
                
                loadDetail(_ID);
                load_TapTin(_ID);
                btnThemCV.Visible = false;
                btnXoa.Visible = false;
                btnSave.Visible = false;

                DO = DADuAn.Instance.Load(_ID);
                txtTen_DA.Text = DO.GetNAME();
                LoaiDA._setSelectedID(DO.LOAI_DU_AN);
                nguoiquanly._setSelectedID(DO.NGUOI_QUAN_LY);
                Muc_UT._setSelectedID(DO.MUC_UU_TIEN);
                ngaybatdau.DateTime = DO.NGAY_BAT_DAU;
                ngayketthuc.DateTime = DO.NGAY_KET_THUC;
                tinhtrang._setSelectedID(DO.TINH_TRANG);


                zoombarTienDo.Value = (int)lay_tiendo();
                mmTT_Them.Text = DO.THONG_TIN_THEM;
                mmMo_ta.Text = DO.MO_TA;                
                cotxoa1.Visible = false;
                cotxoa2.Visible = false;            
                if (IsAdd == false)
                {
                    if(DADuAn.exists_ds_congviec(_ID)||DADuAn.exists_ds_tailieu(_ID))
                          btnXoa.Enabled = false;
                    if (DADuAn.check_TrinhTrang_isHoanThanh(_ID))
                        btnXoa.Enabled = true;
                    btnXoa.Visible = true;
                    btnSave.Visible = true;
                    btnThemCV.Visible = true;
                   
                    cotxoa1.Visible = true;
                    cotxoa2.Visible = true;
                  
                }
                if (IsAdd == null)
                {
                    txtTen_DA.Enabled = false;
                    LoaiDA.Enabled = false;
                    nguoiquanly.Enabled = false;
                    Muc_UT.Enabled = false;
                    ngaybatdau.Enabled = false;
                    ngayketthuc.Enabled = false;
                    tinhtrang.Enabled = false;
                    zoombarTienDo.Enabled = false;
                    mmTT_Them.Enabled = false;
                    mmMo_ta.Enabled = false;
                                                                        
                }
            }                    
        }
        public decimal lay_tiendo()
        {
            decimal tiendo = 0;
            DataView v=(DataView) gridViewCongviec.DataSource;
            foreach (DataRow r in v.Table.Rows)
            {
                tiendo+= HelpNumber.ParseDecimal(r["TIEN_DO_THUC_HIEN"]);
            }
            if(v.Table.Rows.Count>0)
                tiendo /= v.Table.Rows.Count;
            labtiendo.Text = "("+((int)tiendo).ToString()+"%)";
            return tiendo;
        }       
        public void loadDetail(long ID)
        {
            DataSet ds = new DataSet();
            QueryBuilder query = new QueryBuilder(
               @"SELECT distinct pc.pccv_id,pc.LCV_ID, pc.CONG_VIEC,DU_AN_ID,
                                   pc.ngay_bat_dau TU_NGAY, pc.ngay_ket_thuc_du_kien DEN_NGAY,
                                   iif(pc.is_ngay ='Y',pc.thoi_gian_du_kien ||' ngày', pc.thoi_gian_du_kien ||' giờ') THOI_GIAN_DU_KIEN,
                                   pc.muc_uu_tien,
                                   (case pc.muc_uu_tien when 3 then 'Cao nhất' else (
                                   case pc.muc_uu_tien when 1 then 'Cao' else (
                                   case pc.muc_uu_tien when 5 then 'Trung bình' else (
                                   case pc.muc_uu_tien when 2 then 'Thấp' else(
                                   case pc.muc_uu_tien when 4 then 'Thấp nhất' else null end) end ) end ) end) end) ten_muc_uu_tien,
                                   (select  iif(sum(cp.phan_tram_tham_gia)=0,0,cast((100 * sum(cast((cp.phan_tram_tham_gia * cp.tien_do) as numeric(15,1)) /cast(100 as numeric(15,1)))) as numeric(15,1))/ cast(sum(cp.phan_tram_tham_gia) as numeric(15,1)))
                                    from   chi_tiet_phan_cong cp
                                    where  cp.pccv_id = pc.pccv_id
                                    ) TIEN_DO_THUC_HIEN,
                                    pc.nguoi_giao, tt.NAME as TINH_TRANG,
                                    iif(LCV.NAME is not null,(select CV.name from DM_LOAI_CONG_VIECN CV where pc.LCV_ID = CV.ID ),'Loại công việc khác') TEN_LCV,                                     
                                    (select n.TEN_NV from dm_nhan_vien n where pc.nguoi_giao = n.id) ten_nguoi_giao
                            FROM  (((phan_cong_cong_viec pc LEFT JOIN dm_tinh_trang tt on pc.tinh_trang = tt.id )
                                  INNER JOIN DM_LOAI_CONG_VIECN LCV ON pc.LCV_ID = LCV.ID) left join chi_tiet_phan_cong ct on pc.pccv_id = ct.pccv_id)INNER JOIN CONG_VIEC_DU_AN on CONG_VIEC_DU_AN.PCCV_ID=pc.PCCV_ID
                            WHERE 1=1");          
            query.addID("DU_AN_ID", ID);
            ds = DABase.getDatabase().LoadDataSet(query);
            ds.Tables[0].Columns.Add("NV_THAM_GIA");
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                String ten = "";
                String sqlString = "select ct.ma_nv, nv.ten_nv, ct.phan_tram_tham_gia from chi_tiet_phan_cong ct, dm_nhan_vien nv where ct.ma_nv = nv.id and ct.pccv_id = " + dr["PCCV_ID"].ToString() + " group by ma_nv,ten_nv, phan_tram_tham_gia";
                DataTable dt = DABase.getDatabase().LoadDataSet(sqlString).Tables[0];
                foreach (DataRow row in dt.Rows)
                {
                    if (ten == "")
                        ten = ten + row["TEN_NV"].ToString() + " (" + row["PHAN_TRAM_THAM_GIA"].ToString() + "%)";
                    else
                        ten = ten + "\n" + row["TEN_NV"].ToString() + " (" + row["PHAN_TRAM_THAM_GIA"].ToString() + "%)";
                }
                dr["NV_THAM_GIA"] = ten;
            }

            foreach (long id_PCCV in mang_ID_PCCV_dang_xoa)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    if (HelpNumber.ParseInt64(row["pccv_id"]) == id_PCCV)
                    {
                        ds.Tables[0].Rows.Remove(row);
                        break;
                    }
                }
            }
            gridControlCongviec.DataSource = ds.Tables[0];
        }
        
        private void frmHotroSupport_Load(object sender, EventArgs e)
        {
            Uncategory.setEnterAsTab(this);
            btnDong.Image = FWImageDic.CLOSE_IMAGE16;
            btnSave.Image = FWImageDic.SAVE_IMAGE16;
            btnThemCV.Image = FWImageDic.ADD_IMAGE16;
            GUIValidation.SetMaxLength(new object[]{
                txtTen_DA,200,
                 mmMo_ta, 7000,
                 mmTT_Them, 7000  
            });
            gridControlCongviec.Load += new EventHandler(gridControlCongviec_Load);
            gridControlTaiLieu.Load += new EventHandler(gridControlTaiLieu_Load);
        }

        void gridControlTaiLieu_Load(object sender, EventArgs e)
        {
            gridViewCongviec.BestFitColumns();
        }

        void gridControlCongviec_Load(object sender, EventArgs e)
        {
            gridViewCongviec.BestFitColumns();
        }

        public void loadLoaiDA(PLComboboxAdd Input)
        {
            QueryBuilder query = null;
            query = new QueryBuilder("SELECT * FROM DM_LOAI_DU_AN where 1=1");
            query.setAscOrderBy("lower(ID)");
            DataSet ds = DABase.getDatabase().LoadReadOnlyDataSet(query);
            Input._init(ds.Tables[0], "NAME", "ID");
        }


        void xtraTabControl1_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if (xtraTabControl1.SelectedTabPageIndex == 0)
            {
                
                btnThemCV.Tag = "ThemCV";
                btnThemCV.Text = "Thêm công việc";
                if (IsAdd == true)
                    btnThemCV.Visible = true;

            }
            else
            {
                btnThemCV.Tag = "ThemTL";
                btnThemCV.Text = "Thêm tài liệu";
                if (IsAdd == true)
                    btnThemCV.Visible = true;
            }
        }                     
        #endregion             

        #region validate        
        public bool IsValidate()
        {
            bool flag;
            err.ClearErrors();
            flag = GUIValidation.ShowRequiredError(err,
                   new object[]{
                        LoaiDA, "Tên dự án",
                        txtTen_DA,"Tên Dự án",
                        nguoiquanly,"Người quản lý"                                          
                    }
               );
            if (tinhtrang._getSelectedID() == -1)
            {
                tinhtrang.SetError(err, "Vui lòng vào thông tin \"Tình trạng\" !");
                flag = false;
            }
            if (Muc_UT._getSelectedID() == -1)
            {
                Muc_UT.SetError(err, "Vui lòng vào thông tin \"Độ ưu tiên\" !");
                flag = false;
            }
            if (mmMo_ta.Text == "")
            {
                err.SetError(mmMo_ta, "Vui lòng vào thông tin \"Mô tả\"!");
                flag = false;
            }
            if (mmTT_Them.Text == "")
            {
                err.SetError(mmTT_Them, "Vui lòng vào thông tin \"Thông tin thêm\"!");
                flag = false;
            }
            if (ngaybatdau.EditValue != null && ngayketthuc.EditValue != null && (DateTime)ngaybatdau.EditValue > (DateTime)ngayketthuc.EditValue)
            {
                err.SetError(ngayketthuc, "Ngày kết thúc phải lớn hơn ngày bắt đầu.");
                err.SetError(ngaybatdau, "Ngày bắt đầu phải nhỏ hơn ngày kết thúc.");
                flag = false;
            }           
            return (flag && tinhtrang._getSelectedID()!=-1 && Muc_UT._getSelectedID()!=-1);
        }
        #endregion

        #region Xử lý nút 
        private void btnThemCV_Click(object sender, EventArgs e)
        {                   
            if (btnThemCV.Tag.Equals("ThemCV"))
            {
                Congviec frm = new Congviec(-2, true);
                frm.UpdateCongViec += new Congviec.UpdateCongViecHandler(frm_UpdateCongViec);
                ProtocolForm.ShowModalDialog(this, frm);
                
                loadDetail(_ID);
                zoombarTienDo.Value = (int)lay_tiendo();
            }
            else
            {
                frmThemTaiLieu frm = new frmThemTaiLieu(-2, true);
                frm.UpdateTapTin += new frmThemTaiLieu.UpdateTapTinHandler(frm_UpdateTapTin);
                ProtocolForm.ShowModalDialog(this, frm);
                load_TapTin(_ID);
            }
        }
        private void btnSave_Click(object sender, EventArgs e)   
        {
            if ((IsAdd == true) || (IsAdd == false))
            {
                #region Kiểm tra dữ liệu
                if (_ID == -2)
                {
                    DO.ID = DABase.getDatabase().GetID("G_NGHIEP_VU");
                    _ID = DO.ID;
                }
                DO.NAME = txtTen_DA.Text;
                DO.LOAI_DU_AN = LoaiDA._getSelectedID();
                DO.NGUOI_QUAN_LY = nguoiquanly._getSelectedID();
                DO.MUC_UU_TIEN = Muc_UT._getSelectedID();
                DO.NGAY_BAT_DAU = System.Convert.ToDateTime(ngaybatdau.Text);
                DO.NGAY_KET_THUC = System.Convert.ToDateTime(ngayketthuc.Text);
                DO.TINH_TRANG = tinhtrang._getSelectedID();
                DO.TIEN_DO = zoombarTienDo.Value;
                DO.MO_TA = mmMo_ta.Text;
                DO.THONG_TIN_THEM = mmTT_Them.Text;                              
                if (IsValidate())
                {                   
                    if (DADuAn.Instance.Update(DO))
                    {
                        try
                        {

                            foreach (DOLuuTruTapTin do_taptin in list_do_tap_tin)
                            {
                                if (!DADuAn.exists_DATT(do_taptin.ID))
                                    DADuAn.Instance.UpdateDATT(DO.ID, do_taptin.ID);
                            }
                            foreach (long id_taptin in mang_ID_taptin_dang_xoa)
                            {
                                DADuAn.Instance.DeleteDATT(id_taptin);
                            }
                            foreach (long id_pccv in mang_ID_PCCV_dang_xoa)
                            {
                                DACongViec.DeleteAction(id_pccv);
                            }
                        }
                        catch (Exception ex)
                        {
                            PLException.AddException(ex);
                        }
                        list_id_pccv.Clear();
                        list_do_tap_tin.Clear();
                        //PLMessageBox.ShowNotificationMessage("Lưu thành công!");
                        
                        btnThemCV.Visible = true;                        
                        if (refreshfrda != null)
                         this.refreshfrda();
                        HelpXtraForm.CloseFormNoConfirm(this);
                        //if (IsAdd == false)
                        //{

                        //    if (DADuAn.exists_ds_congviec(_ID) ||DADuAn.exists_ds_tailieu(_ID))
                        //        btnXoa.Visible = false;
                        //    else
                        //        btnXoa.Visible = true;
                        //    if (DADuAn.check_TrinhTrang_isHoanThanh(_ID))
                        //        btnXoa.Visible = true;
                        //}
                    }
                    else { PLMessageBox.ShowNotificationMessage("Lưu không thành công!"); }                    
                }
            }                      
                #endregion                                     
            
            
        }       
        private void repositoryItemButtonEdit2_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (IsAdd != null)
            {
                DataRow r = gridViewCongviec.GetDataRow(gridViewCongviec.FocusedRowHandle);
                Int64 id_congviec = 0;

                if (r != null)
                {
                    id_congviec = HelpNumber.ParseInt64(r["pccv_id"]);

                    if (PLMessageBox.ShowConfirmMessage("Xóa công việc này") == DialogResult.Yes)
                    {                      
                        mang_ID_PCCV_dang_xoa.Add(id_congviec);
                        gridViewCongviec.DeleteSelectedRows();                        
                    }
                }
            }
        }
        private void repositoryItemButtonEdit3_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (IsAdd != null)
            {
                DataRow r = gridViewTaiLieu.GetDataRow(gridViewTaiLieu.FocusedRowHandle);
                Int64 ma_tap_tin = 0;

                if (r != null)
                {
                    ma_tap_tin = HelpNumber.ParseInt64(r["ID"]);
                    if (PLMessageBox.ShowConfirmMessage("Xóa tập tin này") == DialogResult.Yes)
                    {
                        mang_ID_taptin_dang_xoa.Add(ma_tap_tin);
                        foreach (DOLuuTruTapTin do_taptin in list_do_tap_tin)
                        {
                            if (do_taptin.ID == ma_tap_tin)
                            {
                                list_do_tap_tin.Remove(do_taptin);
                                break;
                            }                            

                        }
                        gridViewTaiLieu.DeleteRow(gridViewTaiLieu.FocusedRowHandle);
                    }
                }
            }
        }
        
        private void btnXoa_Click(object sender, EventArgs e)
        {
            //Xóa dữ liệu và đóng form nếu xóa thành công   
            if (PLMessageBox.ShowConfirmMessage("bạn muốn xóa dự án này?") == DialogResult.Yes)
            {
                if (DADuAn.Instance.Delete(_ID))
                {
                    PLMessageBox.ShowNotificationMessage("Đã Xóa thành công");
                    this.Close();
                }
                else
                    PLMessageBox.ShowErrorMessage("Không xóa được");
            }
          
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            if (IsAdd == null)
                this.Close();
            else
            {
                if (PLMessageBox.ShowConfirmMessage("Bạn có chắc muốn đóng?") == DialogResult.Yes)
                {                   
                    this.Close();
                }
                    
            }
        }              
        #endregion                  

        #region su kien
        public void frm_UpdateTapTin(object sender, DOLuuTruTapTin doLuuTruTapTin)
        {
            list_do_tap_tin.Add(doLuuTruTapTin);

        }
        public void frm_UpdateCongViec(object sender,long id_pccv)
        {
            list_id_pccv.Add(id_pccv);
            DADuAn.luu_duan_congviec(DO.ID, id_pccv);
        }
        public void frm_UpdateCongViec1(object sender, long pccv_id)
        {
           
        }
        private void gridControlCongviec_DoubleClick(object sender, EventArgs e)
        {
            DataRow r = gridViewCongviec.GetDataRow(gridViewCongviec.FocusedRowHandle);
            if (r != null)
            {
                if (IsAdd == false)
                {
                    Congviec frm = new Congviec(HelpNumber.ParseInt64(r["pccv_id"]), false);
                    frm.UpdateCongViec += new Congviec.UpdateCongViecHandler(frm_UpdateCongViec1);                    
                    ProtocolForm.ShowModalDialog(this, frm);
                    loadDetail(_ID);
                    zoombarTienDo.Value = (int)lay_tiendo();
                }

            }

        }
        
        #endregion   
            
        #region khac
        
        private void load_TapTin(Int64 ID_TaiLieu)
        {
            DataSet ds = DABase.getDatabase().LoadDataSet("select * from LUU_TRU_TAP_TIN where ID IN (select TAP_TIN_ID from DU_AN_TAP_TIN where DU_AN_ID='" + ID_TaiLieu + "')");
            XtraGridSupportExt.TextLeftColumn(CotTieuDe, "TIEU_DE");
            HelpGridColumn.CotMemoExEdit(CotGhiChu, "GHI_CHU");
            XtraGridSupportExt.TextLeftColumn(CotFile, "TEN_FILE");
            XtraGridSupportExt.TextLeftColumn(cotID, "ID");
            ds.Tables[0].Columns.Add("mo_file", typeof(Image));
            ds.Tables[0].Columns.Add("luu_file", typeof(Image));
            ds.Tables[0].Columns.Add("xoa_file", typeof(Image));
            ds.Tables[0].Columns.Add("sua_file", typeof(Image));
            foreach (DataRow r in ds.Tables[0].Rows)
            {
                r["NOI_DUNG"] = DADuAn.ImageToByteArray(lay_anh(r["TEN_FILE"].ToString()));
                r["mo_file"] = imageList_layout.Images[0];
                r["luu_file"] = imageList_layout.Images[1];
                r["xoa_file"] = imageList_layout.Images[2];
                r["sua_file"] = imageList_layout.Images[3];
            }
            foreach (DOLuuTruTapTin do_tt in list_do_tap_tin)
            {
                DataRow r = ds.Tables[0].NewRow();
                r["TIEU_DE"] = do_tt.TIEU_DE;
                r["TEN_FILE"] = do_tt.TEN_FILE;
                r["NOI_DUNG"] = DADuAn.ImageToByteArray(lay_anh(r["TEN_FILE"].ToString()));//do_tt.NOI_DUNG;
                r["GHI_CHU"] = do_tt.GHI_CHU;
                r["ID"] = do_tt.ID;
                r["mo_file"] = imageList_layout.Images[0];
                r["luu_file"] = imageList_layout.Images[1];
                r["xoa_file"] = imageList_layout.Images[2];
                r["sua_file"] = imageList_layout.Images[3];
                ds.Tables[0].Rows.Add(r);
            }
            foreach (long id_taptin in mang_ID_taptin_dang_xoa)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    if (HelpNumber.ParseInt64(row["ID"]) == id_taptin)
                    {
                        ds.Tables[0].Rows.Remove(row);
                        break;
                    }

                }
            }

            gridControlTaiLieu.DataSource = ds.Tables[0];
        }
        #endregion      
       
        #region su kien
       
        private Image lay_anh(string tenfile)
        {
            string[] duoi = tenfile.Split('.');
            duoi[duoi.Length - 1] = duoi[duoi.Length - 1].ToLower();
            if (duoi[duoi.Length - 1] == "doc" || duoi[duoi.Length - 1] == "docx" || duoi[duoi.Length - 1] == "dotx" || duoi[duoi.Length - 1] == "dot" || duoi[duoi.Length - 1] == "dotm" || duoi[duoi.Length - 1] == "docm")
                return imageList3.Images[0];
            if (duoi[duoi.Length - 1] == "xls" || duoi[duoi.Length - 1] == "xlsx")
                return imageList3.Images[1];
            if (duoi[duoi.Length - 1] == "GDB" || duoi[duoi.Length - 1] == "mdb" || duoi[duoi.Length - 1] == "mdf" || duoi[duoi.Length - 1] == "accdb")
                return imageList3.Images[2];
            if (duoi[duoi.Length - 1] == "bmp" || duoi[duoi.Length - 1] == "jpg" || duoi[duoi.Length - 1] == "png" || duoi[duoi.Length - 1] == "gif")
                return imageList3.Images[4];
            if (duoi[duoi.Length - 1] == "zip" || duoi[duoi.Length - 1] == "rar" || duoi[duoi.Length - 1] == "7z")
                return imageList3.Images[3];
            if (duoi[duoi.Length - 1] == "pdf" || duoi[duoi.Length - 1] == "chm")
                return imageList3.Images[6];
            if (duoi[duoi.Length - 1] == "txt")
                return imageList3.Images[5];
            return imageList3.Images[7];
        }
        private void gridControlTaiLieu_MouseMove(object sender, MouseEventArgs e)
        {

            LayoutViewHitInfo layouthit = layoutView1.CalcHitInfo(layoutView1.GridControl.PointToClient(Control.MousePosition));
            if (layouthit.Column != null)
            {
                if (layouthit.Column.Name == "cot_xoa")
                {
                    toolTip1.Show("Xoá tập tin", this, MousePosition.X - this.Location.X, MousePosition.Y - this.Location.Y + 20, 500);
                }
                if (layouthit.Column.Name == "cot_suafile")
                {
                    toolTip1.Show("Sửa tập tin", this, MousePosition.X - this.Location.X, MousePosition.Y - this.Location.Y + 20, 500);
                }
                if (layouthit.Column.Name == "cot_mofile")
                {
                    toolTip1.Show("Mở tập tin", this, MousePosition.X - this.Location.X, MousePosition.Y - this.Location.Y + 20, 500);
                }
                if (layouthit.Column.Name == "cot_luufile")
                {
                    toolTip1.Show("Lưu tập tin", this, MousePosition.X - this.Location.X, MousePosition.Y - this.Location.Y + 20, 500);
                }

            }
        }
        private void frmDuAn_FormClosed(object sender, FormClosedEventArgs e)
        {
            //xóa những tập tin chưa được lưu
            foreach (DOLuuTruTapTin doluutrutt in list_do_tap_tin)
            {
                DALuuTruTapTin.Instance.Delete(doluutrutt.ID);

            }
            //xóa các phân công công việc chưa được lưu
            foreach (long id_pccv in list_id_pccv)
            {
                DACongViec.DeleteAction(id_pccv);

            }
        }
        #endregion

        #region xuly imageedit
        private void rep_mofile_Click(object sender, EventArgs e)
        {
            DataRow row = layoutView1.GetDataRow(layoutView1.FocusedRowHandle);
            DOLuuTruTapTin do_tt = DALuuTruTapTin.Instance.Load(HelpNumber.ParseInt64(row["ID"]));
            DADocument.Instance.Open_file_from_byte(do_tt.NOI_DUNG, do_tt.TEN_FILE);
        }

        private void rep_luufile_Click(object sender, EventArgs e)
        {
            DataRow row = layoutView1.GetDataRow(layoutView1.FocusedRowHandle);
            DOLuuTruTapTin do_tt = DALuuTruTapTin.Instance.Load(HelpNumber.ParseInt64(row["ID"]));
            DADocument.Instance.Save_file_from_byte(do_tt.NOI_DUNG, do_tt.TEN_FILE);
        }

        private void rep_xoa_Click(object sender, EventArgs e)
        {
            if (IsAdd != null)
            {
                DataRow r = layoutView1.GetDataRow(layoutView1.FocusedRowHandle);
                if (r != null)
                {
                    if (PLMessageBox.ShowConfirmMessage("Bạn có muốn xóa tài liệu \"" + r["TEN_FILE"].ToString() + "\" này không!") == DialogResult.Yes)
                    {
                        long id_taptin = HelpNumber.ParseInt64(r["ID"]);
                        DALuuTruTapTin.Instance.Delete(id_taptin);
                        foreach (DOLuuTruTapTin do_tt in list_do_tap_tin)
                        {
                            if (do_tt.ID == id_taptin)
                            {
                                list_do_tap_tin.Remove(do_tt);
                                break;
                            }
                        }
                        mang_ID_taptin_dang_xoa.Add(id_taptin);
                        layoutView1.DeleteSelectedRows();
                    }
                }
            }
        }

        private void rep_sua_Click(object sender, EventArgs e)
        {
            if (IsAdd != null)
            {
                DataRow r = layoutView1.GetDataRow(layoutView1.FocusedRowHandle);
                if (r != null)
                {
                    frmThemTaiLieu frm = new frmThemTaiLieu(HelpNumber.ParseInt64(r["ID"]), false);
                    frm.UpdateTapTin += new frmThemTaiLieu.UpdateTapTinHandler(frm_UpdateTapTin1);
                    ProtocolForm.ShowModalDialog(this, frm);
                    load_TapTin(_ID);
                }
            }
        }
        public void frm_UpdateTapTin1(object sender, DOLuuTruTapTin doLuuTruTapTin)
        {
            foreach (DOLuuTruTapTin do_lttt in list_do_tap_tin)
            {
                if (do_lttt.ID == doLuuTruTapTin.ID)
                {
                    do_lttt.TIEU_DE = doLuuTruTapTin.TIEU_DE;
                    do_lttt.NOI_DUNG = doLuuTruTapTin.NOI_DUNG;
                    do_lttt.GHI_CHU = doLuuTruTapTin.GHI_CHU;
                    do_lttt.TEN_FILE = doLuuTruTapTin.TEN_FILE;
                }
            }
        }
        #endregion

        
    }
}
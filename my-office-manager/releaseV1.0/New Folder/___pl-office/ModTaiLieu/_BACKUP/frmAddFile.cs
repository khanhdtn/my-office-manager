using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using ProtocolVN.Framework.Win;
using ProtocolVN.Framework.Core;
using DAO;
using DevExpress.XtraEditors.DXErrorProvider;
using DevExpress.XtraEditors.Controls;
using DTO;
using ProtocolVN.DanhMuc;
using DevExpress.XtraGrid.Views.Layout.ViewInfo;
using ProtocolVN.Framework.Dev.Open;
using ProtocolVN.App.Office;

namespace pl.office.form
{
    public partial class frmAddFile : XtraFormPL
    {
        #region Vùng đặt Static
        public static FormStatus Status = FormStatus.NO_USE;
        public static string MenuItem(string ParentID, bool IsSep)
        {
            return MenuBuilder.CreateItem(typeof(frmAddFile).FullName,
                PMSupport.UpdateTitle("Thêm tài liệu", Status),
                ParentID, true,
                typeof(frmAddFile).FullName,
                false, IsSep, "mnbCHinhHeThong.png", true, "", "");
        }
        #endregion

        #region Các khai báo biến
        private DXErrorProvider Error;
        private bool? IsAdd; //true = New, null = View, false = Edit
        private long _ID;
        DODocument do_tl;
        bool themtt = false;
        private DOLuuTruTapTin do_luu_tru_tt = null;
        private List<DOLuuTruTapTin> list_do_taptin = new List<DOLuuTruTapTin>();
        List<long> ID_taptin_dangxoa = new List<long>();



        #endregion

        #region Hàm dựng
        public frmAddFile(long ID, bool? IsAdd)
        {
            InitializeComponent();
            Error = new DXErrorProvider();
            Duyet._init(true);
            this.IsAdd = IsAdd;
            this._ID = ID;
            initform();
            HelpControl.setEnterAsTab(this);
            btnSave.Image = FWImageDic.SAVE_IMAGE16;
            btnDong.Image = FWImageDic.CLOSE_IMAGE16;
            btnThemTL.Image = FWImageDic.ADD_IMAGE16;
        }

        public frmAddFile()
            : this(-2, true)
        {
        }

        #endregion

        #region InitForm
        private void initform()
        {
            XtraGridSupportExt.TextLeftColumn(cot_xoa, "xoa_file");
            XtraGridSupportExt.TextLeftColumn(cot_luufile, "luu_file");
            XtraGridSupportExt.TextLeftColumn(cot_mofile, "mo_file");
            XtraGridSupportExt.TextLeftColumn(cot_suafile, "sua_file");
            toolTip1.BackColor = Color.LightYellow;
            layoutView1.OptionsCustomization.AllowSort = false;
            layoutView1.OptionsCustomization.AllowFilter = false;
            repositoryItemButtonEdit2.ButtonClick += new ButtonPressedEventHandler(repositoryItemButtonEdit2_ButtonClick);
            repositoryItemPictureEdit1.SizeMode = PictureSizeMode.Squeeze;
            DMLoaiTaiLieu.I.InitCtrl(LoaiTL, true, true);
            LoaiTL.ToolTip = string.Empty;
            lblNguoiCapNhat.Text = DMFWNhanVien.GetFullName(FrameworkParams.currentUser.employee_id);
            TxtTg_cap_nhat.Text = DABase.getDatabase().GetSystemCurrentDateTime().ToString(PLConst.FORMAT_DATETIME_STRING);


            if (IsAdd == true)
            {
                do_tl = DADocument.Instance.Load(-2);
                do_tl.ID = DABase.getDatabase().GetID(PLDBUtil.G_NGHIEP_VU);
                _ID = do_tl.ID;

                do_luu_tru_tt = DALuuTruTapTin.Instance.LoadAll(-2);
                TenTL.Enabled = true;
                btnSave.Visible = true;
                themtt = true;
                do_tl.DUYET = "1";
            }
            else
            {

                do_tl = DADocument.Instance.Load(_ID);
                do_luu_tru_tt = DADocument.Instance.load_DOTapTin(_ID);
                TenTL.Text = do_tl.TEN_TAI_LIEU;
                LoaiTL._setSelectedID(HelpNumber.ParseInt64(do_tl.LOAI_TAI_LIEU_ID));
                Phien_ban.Text = do_tl.PHIEN_BAN;
                Noidung.DocumentText = do_tl.MO_TA;
                load_TapTin(_ID);
                if (do_tl.ID == 0)
                {
                    PLMessageBox.ShowErrorMessage("Dữ liệu đã bị mất.....");
                    if (PLMessageBox.ShowConfirmMessage("Bạn có muốn thêm dữ liệu.") == DialogResult.No)
                        return;
                    else
                    {
                        do_tl = DADocument.Instance.Load(-2);
                        TenTL.Enabled = true;
                        btnSave.Visible = true;
                        IsAdd = true;
                        return;
                    }
                }

                if (IsAdd == false)
                {

                    TenTL.Enabled = true;
                    btnSave.Visible = true;
                    if (DADocument.check_exists_taptin_in_tailieu(_ID))
                    {
                        ///
                    }

                    themtt = true;

                }
            }
            Duyet.SetDuyet(do_tl);
        }
        private void frmThem_TL_Load(object sender, EventArgs e)
        {
            GUIValidation.SetMaxLength(new object[]{
                TenTL,100,
                Phien_ban,100
            });
        }
        private void load_TapTin(Int64 ID_TaiLieu)
        {
            DataSet ds = DABase.getDatabase().LoadDataSet("select * from LUU_TRU_TAP_TIN where ID IN (select TAP_TIN_ID from TAI_LIEU_TAP_TIN where TAI_LIEU_ID='" + ID_TaiLieu + "')");
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
                r["NOI_DUNG"] = HelpFile.ImageToByteArray(AppCtrl.mapToImage(r["TEN_FILE"].ToString()));
                r["mo_file"] = imageList_layout.Images[0];
                r["luu_file"] = imageList_layout.Images[1];
                r["xoa_file"] = imageList_layout.Images[2];
                r["sua_file"] = imageList_layout.Images[3];
            }
            //thêm vào lưới những cột chưa được lưu vào csdl
            foreach (DOLuuTruTapTin do_tt in list_do_taptin)
            {
                DataRow r = ds.Tables[0].NewRow();
                r["TIEU_DE"] = do_tt.TIEU_DE;
                r["TEN_FILE"] = do_tt.TEN_FILE;
                r["NOI_DUNG"] = HelpFile.ImageToByteArray(AppCtrl.mapToImage(r["TEN_FILE"].ToString()));
                r["GHI_CHU"] = do_tt.GHI_CHU;
                r["ID"] = do_tt.ID;
                r["mo_file"] = imageList_layout.Images[0];
                r["luu_file"] = imageList_layout.Images[1];
                r["xoa_file"] = imageList_layout.Images[2];
                r["sua_file"] = imageList_layout.Images[3];
                ds.Tables[0].Rows.Add(r);
            }           
            foreach (long id_taptin in ID_taptin_dangxoa)
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
        private void frmPhanhoi_Load(object sender, EventArgs e)
        {

        }
        #endregion

        #region Xử lý nút

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (IsAdd == null)
            {
                this.Close();
            }
            else
                if (PLMessageBox.ShowConfirmMessage("Bạn có chắc muốn đóng ?") == DialogResult.Yes)
                {
                    
                    this.Close();
                }


        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            do_tl.TEN_TAI_LIEU = TenTL.Text;
            do_tl.LOAI_TAI_LIEU_ID = LoaiTL._getSelectedID();
            do_tl.MO_TA = Noidung._getHTMLText();
            do_tl.PHIEN_BAN = Phien_ban.Text;
            do_tl.NGAY_CAP_NHAT = DABase.getDatabase().GetSystemCurrentDateTime();
            do_tl.NGUOI_CAP_NHAT = FrameworkParams.currentUser.employee_id;
            do_tl.VISIBLE_BIT = "Y";
            if (do_tl.ID == 0)
            {
                do_tl.ID = DABase.getDatabase().GetID("G_NGHIEP_VU");
                _ID = do_tl.ID;
            }
            if (IsValidate())
            {
                if (do_tl.MO_TA.Length > 7000)
                    PLMessageBox.ShowErrorMessage("Vui lòng nhập 'Nội dung' không quá 7000 ký tự");
                else
                {
                    if (DADocument.Instance.Update(do_tl))
                    {
                        foreach (DOLuuTruTapTin do_tt in list_do_taptin)
                        {
                            DADocument.Luu_TaiLieu_TapTin(do_tl.ID, do_tt.ID);
                        }
                        foreach (long id_tailieu in ID_taptin_dangxoa)
                        {
                            DADocument.Xoa_taiieu_taptin(id_tailieu);
                            DALuuTruTapTin.Instance.Delete(id_tailieu);

                        }                        
                        this.Close();
                    }
                    else
                        PLMessageBox.ShowNotificationMessage("Lưu không thành công !");
                }
            }


        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (PLMessageBox.ShowConfirmMessage("Bạn có muốn xóa tài liệu \"" + do_tl.TEN_TAI_LIEU.ToString() + "\" này không!") == DialogResult.Yes)
            {
                DADocument.Instance.Xoa_DM_TAI_LIEU(do_tl.ID);
                DADocument.Instance.Xoa_all_taptin_tailieu(do_tl.ID);
                this.Close();
            }
        }

        private void btnThemCV_Click(object sender, EventArgs e)
        {
            frmThemTaiLieu frm = new frmThemTaiLieu(-2, true);
            frm.UpdateTapTin += new frmThemTaiLieu.UpdateTapTinHandler(frm_UpdateTapTin);
            ProtocolForm.ShowModalDialog(this, frm);
            load_TapTin(_ID);
        }
        public void frm_UpdateTapTin(object sender, DOLuuTruTapTin doLuuTruTapTin)
        {
            list_do_taptin.Add(doLuuTruTapTin);            
        }

        #endregion

        #region Validate
        /// <summary>
        /// Kiểm tra dữ liệu có được nhập đầy đủ
        /// </summary>
        /// <returns></returns>
        private bool IsValidate()
        {
            bool flag;
            Error.ClearErrors();
            flag = GUIValidation.ShowRequiredError(Error,
                   new object[]{
                        TenTL, "Tên tài liệu",
                        LoaiTL,"Loại tài liệu"                                                                                                                     
                    }
               );

            return flag;
        }

        #endregion

        #region Sự kiện
        private void repositoryItemButtonEdit2_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            DataRow row = layoutView1.GetDataRow(layoutView1.FocusedRowHandle);
            DOLuuTruTapTin do_tt = DALuuTruTapTin.Instance.Load(HelpNumber.ParseInt64(row["ID"]));

            try
            {
                WaitingMsg m = new WaitingMsg();
                frmSaveOpen frm = new frmSaveOpen(do_tt.NOI_DUNG, do_tt.TEN_FILE);
                m.Finish();
                ProtocolForm.ShowModalDialog(this, frm);
            }
            catch (Exception ex)
            {
                PLException.AddException(ex);
                HelpSysLog.AddException(ex, ""); 

            }
        }
        private void rep_mofile_Click(object sender, EventArgs e)
        {
            DataRow row = layoutView1.GetDataRow(layoutView1.FocusedRowHandle);
            try
            {
                DOLuuTruTapTin do_tt = DALuuTruTapTin.Instance.Load(HelpNumber.ParseInt64(row["ID"]));
                DADocument.Instance.Open_file_from_byte(do_tt.NOI_DUNG, do_tt.TEN_FILE);
            }
            catch (Exception ex)
            {
                PLException.AddException(ex);
                HelpSysLog.AddException(ex, ""); 
            }
        }

        private void rep_luufile_Click(object sender, EventArgs e)
        {
            DataRow row = layoutView1.GetDataRow(layoutView1.FocusedRowHandle);
            try
            {
                DOLuuTruTapTin do_tt = DALuuTruTapTin.Instance.Load(HelpNumber.ParseInt64(row["ID"]));
                DADocument.Instance.Save_file_from_byte(do_tt.NOI_DUNG, do_tt.TEN_FILE);
            }
            catch (Exception ex)
            {
                PLException.AddException(ex);
                HelpSysLog.AddException(ex, ""); 
            }
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
                        try
                        {
                            long id_taptin = HelpNumber.ParseInt64(r["ID"]);
                            DALuuTruTapTin.Instance.Delete(id_taptin);
                            foreach (DOLuuTruTapTin do_tt in list_do_taptin)
                            {
                                if (do_tt.ID == id_taptin)
                                {
                                    list_do_taptin.Remove(do_tt);
                                    break;
                                }
                            }
                            ID_taptin_dangxoa.Add(id_taptin);
                            layoutView1.DeleteSelectedRows();
                        }
                        catch (Exception ex)
                        {
                            PLException.AddException(ex);
                            HelpSysLog.AddException(ex, ""); 
                        }
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
                    try
                    {
                        frm.UpdateTapTin += new frmThemTaiLieu.UpdateTapTinHandler(frm_UpdateTapTin1);
                        ProtocolForm.ShowModalDialog(this, frm);
                        load_TapTin(_ID);
                    }
                    catch (Exception ex)
                    {
                        PLException.AddException(ex);
                        HelpSysLog.AddException(ex, ""); 
                    }
                }
            }

        }
        public void frm_UpdateTapTin1(object sender, DOLuuTruTapTin doLuuTruTapTin)
        {
            //edit lại list_do_taptin khi sửa 1 tập tin vừa mới thêm vào
            foreach (DOLuuTruTapTin do_lttt in list_do_taptin)
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
        void xtraTabControl1_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if (xtraTabControl1.SelectedTabPageIndex == 1)
            {

                if (themtt)
                {
                    btnThemTL.Visible = true;
                }
            }
            else
            {
                btnThemTL.Visible = false;
            }
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
        private void frmThemTL_FormClosed(object sender, FormClosedEventArgs e)
        {
            //xóa những tập tin ko cần thiết
            try
            {
                foreach (DOLuuTruTapTin do_tt in list_do_taptin)
                    DALuuTruTapTin.Instance.Delete(do_tt.ID);
            }
            catch (Exception ex)
            {
                PLException.AddException(ex);
                HelpSysLog.AddException(ex, ""); 
            }
        }
        #endregion
    }
}
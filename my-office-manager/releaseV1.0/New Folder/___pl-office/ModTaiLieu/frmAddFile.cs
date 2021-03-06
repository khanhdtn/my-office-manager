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

using ProtocolVN.App.Office;
using DevExpress.XtraGrid.Columns;
using System.IO;

namespace office
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
        DataSet cardViewDS = new DataSet();
        public delegate void RefreshData(DODocument doDocument);
        public event RefreshData RefreshUpdate;

        #endregion

        #region Hàm dựng
        public frmAddFile(long ID, bool? IsAdd)
        {
            InitializeComponent();
            TaiLieuPermission.I.Init();
            Error = new DXErrorProvider();
            Duyet._init(true);
            this.IsAdd = IsAdd;
            this._ID = ID;
            initform();
        }

        public frmAddFile()
            : this(-2, true)
        {
        }

        #endregion

        #region InitForm
        private void initform()
        {
            #region cardView tài liệu
            XtraGridSupportExt.TextLeftColumn(lvTieuDe, "TIEU_DE");
            XtraGridSupportExt.TextLeftColumn(lvFile_dinh_kem, "TEN_FILE");
            XtraGridSupportExt.TextLeftColumn(lvNguoiCapNhat, "TEN_NGUOI_CN");
            XtraGridSupportExt.TextLeftColumn(lvNgayCapNhat, "NGAY_CAP_NHAT");
            HelpGridColumn.CotMemoExEdit(lvGhi_chu, "GHI_CHU");
            HelpGridColumn.CotTextLeft(lvSize, "SIZE");
            XtraGridSupportExt.TextLeftColumn(cotID, "ID");
            XtraGridSupportExt.TextLeftColumn(cot_xoa, "xoa_file");
            XtraGridSupportExt.TextLeftColumn(cot_luufile, "luu_file");
            XtraGridSupportExt.TextLeftColumn(cot_mofile, "mo_file");
            XtraGridSupportExt.TextLeftColumn(cot_suafile, "sua_file");
            toolTip1.BackColor = Color.LightYellow;
            layoutView1.Appearance.CardCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            layoutView1.OptionsCustomization.AllowSort = false;
            layoutView1.OptionsCustomization.AllowFilter = false;
            lvSize.OptionsColumn.AllowEdit = false;
            lvSize.OptionsColumn.AllowFocus = false;
            lvGhi_chu.OptionsColumn.ReadOnly = true; 
            layoutView1.OptionsBehavior.AllowSwitchViewModes = true;
            layoutView1.OptionsBehavior.AllowExpandCollapse = true;
            layoutView1.OptionsView.ShowCardCaption = true;
            layoutView1.OptionsHeaderPanel.EnableCustomizeButton = false;
            #endregion
            repositoryItemButtonEdit2.ButtonClick += new ButtonPressedEventHandler(repositoryItemButtonEdit2_ButtonClick);
            repositoryItemPictureEdit1.SizeMode = PictureSizeMode.Squeeze;
            DADocument.InitCtrl(LoaiTL, true);
       
            lblNguoiCapNhat.Text = DMFWNhanVien.GetFullName(FrameworkParams.currentUser.employee_id);
            TxtTg_cap_nhat.Text = HelpDB.getDatabase().GetSystemCurrentDateTime().ToString(PLConst.FORMAT_DATETIME_STRING);
            if (IsAdd == true)
            {
                do_tl = DADocument.Instance.Load(-2);
                do_tl.ID = HelpDB.getDatabase().GetID(PLConst.G_NGHIEP_VU);
                _ID = do_tl.ID;
                do_luu_tru_tt = DALuuTruTapTin.Instance.LoadAll(-2);
                TenTL.Enabled = true;
                btnSave.Visible = true;
                xtraTabControl1.TabPages[1].PageEnabled = false;
            }
            else
            {
                if (IsAdd == false)
                {
                    if (TaiLieuPermission.I._checkPermissionRes(_ID, PermissionOfResource.RES_PERMISSION_TYPE.UPDATE) == false)
                    {
                        HelpMsgBox.ShowNotificationMessage("Bạn không có quyền sửa tài liệu này!");
                        HelpXtraForm.CloseFormNoConfirm(this);
                        return;
                    }
                }
                do_tl = DADocument.Instance.Load(_ID);
                do_luu_tru_tt = DADocument.Instance.load_DOTapTin(_ID);
                TenTL.Text = do_tl.NAME;
                LoaiTL._setSelectedID(HelpNumber.ParseInt64(do_tl.LOAI_TAI_LIEU_ID));
                Phien_ban.Text = do_tl.PHIEN_BAN;
                Noidung.DocumentText = do_tl.MO_TA;
                Load_TapTin(_ID);
            
                if (do_tl.ID == 0)
                {
                    HelpMsgBox.ShowErrorMessage("Dữ liệu đã bị mất.....");
                    if (HelpMsgBox.ShowConfirmMessage("Bạn có muốn thêm dữ liệu.") == DialogResult.No)
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
                    themtt = true;
                }
                else
                {                    
                    cot_suafile.LayoutViewField.Visibility = cot_xoa.LayoutViewField.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                }
            }
        }
        private void frmThem_TL_Load(object sender, EventArgs e)
        {
            HelpInputData.SetMaxLength(new object[]{
                TenTL,100,
                Phien_ban,100
            });
            HelpXtraForm.SetCloseForm(this, btnDong, IsAdd);
            HelpXtraForm.SetFix(this);
        }        
        private void Load_TapTin(Int64 ID_TaiLieu)
        {
            cardViewDS = HelpDB.getDatabase().LoadDataSet(string.Format(@"SELECT LUU_TRU_TAP_TIN.*,
            (SELECT NAME FROM DM_NHAN_VIEN WHERE ID = LUU_TRU_TAP_TIN.NGUOI_CAP_NHAT) TEN_NGUOI_CN
            FROM LUU_TRU_TAP_TIN WHERE ID IN (
            SELECT TAP_TIN_ID FROM OBJECT_TAP_TIN WHERE OBJECT_ID={0} AND TYPE_ID=3)", ID_TaiLieu));
            
            cardViewDS.Tables[0].Columns.Add("mo_file", typeof(Image));
            cardViewDS.Tables[0].Columns.Add("luu_file", typeof(Image));
            cardViewDS.Tables[0].Columns.Add("xoa_file", typeof(Image));
            cardViewDS.Tables[0].Columns.Add("sua_file", typeof(Image));
            cardViewDS.Tables[0].Columns.Add("SIZE", typeof(String));
            
            foreach (DataRow r in cardViewDS.Tables[0].Rows)
            {
                r["mo_file"] = FWImageDic.VIEW_IMAGE20;
                r["luu_file"] = FWImageDic.SAVE_IMAGE20;
                r["xoa_file"] = FWImageDic.DELETE_IMAGE20;
                r["sua_file"] = FWImageDic.EDIT_IMAGE20;
                byte[] a = r["NOI_DUNG"] as byte[];
                r["SIZE"] = HelpNumber.RoundDecimal(HelpNumber.ParseDecimal(a.Length) / 1024,3).ToString();
            }
            gridControlTaiLieu.DataSource = cardViewDS.Tables[0];
        }
        private void frmPhanhoi_Load(object sender, EventArgs e)
        {

        }
        #endregion

        #region Xử lý nút

        private void btnLuu_Click(object sender, EventArgs e)
        {
            do_tl.NAME = TenTL.Text;
            do_tl.LOAI_TAI_LIEU_ID = LoaiTL._getSelectedID();
            do_tl.MO_TA = Noidung._getHTMLText();
            do_tl.PHIEN_BAN = Phien_ban.Text;
            do_tl.NGAY_CAP_NHAT = HelpDB.getDatabase().GetSystemCurrentDateTime();
            do_tl.NGUOI_CAP_NHAT = FrameworkParams.currentUser.employee_id;
            do_tl.VISIBLE_BIT = "Y";
            if (do_tl.ID == 0)
            {
                do_tl.ID = HelpDB.getDatabase().GetID("G_NGHIEP_VU");
                _ID = do_tl.ID;
            }
            if (IsValidate())
            {
                if (TaiLieuPermission.I._checkPermissionResGroup(do_tl.LOAI_TAI_LIEU_ID, PermissionOfResource.RES_PERMISSION_TYPE.CREATE) == false)
                {
                    HelpMsgBox.ShowNotificationMessage(string.Format("Bạn không có quyền {0} tài liệu vào loại tài liệu đang chọn!", IsAdd == true ? "thêm" : "chuyển"));
                    return;
                }              
                if (do_tl.MO_TA.Length > 7000)
                    HelpMsgBox.ShowErrorMessage("Vui lòng nhập \"Nội dung\" không quá 7000 ký tự");
                else
                {
                    if (DADocument.Instance.Update(do_tl))
                    {
                        if (IsAdd == false)
                        {
                            if (this.RefreshUpdate != null) RefreshUpdate(do_tl);
                            HelpXtraForm.CloseFormNoConfirm(this);
                        }
                        else
                        {
                            themtt = true;
                            xtraTabControl1.TabPages[1].PageEnabled = true;
                            TaiLieuPermission.I.InsertPermis(_ID, false, -1, do_tl.NGUOI_CAP_NHAT,
                                true, TaiLieuPermission.I.Is_ResUseCreate, true, true);
                            HelpMsgBox.ShowNotificationMessage("Lưu thành công.");
                        }
                    }
                    else
                        HelpMsgBox.ShowNotificationMessage("Lưu không thành công !");
                }
            }
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (HelpMsgBox.ShowConfirmMessage("Bạn có chắc muốn xóa dữ liệu đang chọn không?") == DialogResult.Yes)
            {
                DADocument.Instance.Xoa_DM_TAI_LIEU(do_tl.ID);
                DADocument.Instance.Xoa_all_taptin_tailieu(do_tl.ID);
                TaiLieuPermission.I.DeletePermis(do_tl.ID, false);
                this.Close();
            }
        }

        private void btnThemTL_Click(object sender, EventArgs e)
        {
            frmThemTaiLieu frm = new frmThemTaiLieu(-2, true, do_tl.ID, (long)LoaiTapTin.TapTinTaiLieu);
            HelpProtocolForm.ShowModalDialog(this, frm);
            Load_TapTin(_ID);
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
            flag = HelpInputData.ShowRequiredError(Error,
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
                FWWaitingMsg m = new FWWaitingMsg();
                frmSaveOpen frm = new frmSaveOpen(do_tt.NOI_DUNG, do_tt.TEN_FILE);
                m.Finish();
                HelpProtocolForm.ShowModalDialog(this, frm);
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
            if (IsAdd == false && layoutView1.RowCount == 1) {
                HelpMsgBox.ShowErrorMessage("Phải có ít nhất 1 tập tin đính kèm với tài liệu!");
                return;
            }
            if (IsAdd != null)
            {
                DataRow r = layoutView1.GetDataRow(layoutView1.FocusedRowHandle);
                if (r != null)
                {
                    if (HelpMsgBox.ShowConfirmMessage("Bạn có chắc muốn xóa dữ liệu đang chọn không?") == DialogResult.Yes)
                    {
                        try
                        {
                            long id_taptin = HelpNumber.ParseInt64(r["ID"]);
                            DADocument.Xoa_tailieu_taptin(id_taptin);
                            DALuuTruTapTin.Instance.Delete(id_taptin);
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
                    frmThemTaiLieu frm = new frmThemTaiLieu(HelpNumber.ParseInt64(r["ID"]), false, do_tl.ID, (long)LoaiTapTin.TapTinTaiLieu);
                    try
                    {
                        HelpProtocolForm.ShowModalDialog(this, frm);
                        Load_TapTin(_ID);
                    }
                    catch (Exception ex)
                    {
                        PLException.AddException(ex);
                        HelpSysLog.AddException(ex, ""); 
                    }
                }
            }
        }
        void xtraTabControl1_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if (xtraTabControl1.SelectedTabPageIndex == 1 && IsAdd != null)
            {
                if (themtt)
                {
                    btnThemTL.Visible = true;
                }
                else
                {
                    btnThemTL.Visible = false;
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
        #endregion
    }
}
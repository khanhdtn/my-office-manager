using System;
using DevExpress.XtraEditors.DXErrorProvider;
using ProtocolVN.Framework.Win;
using ProtocolVN.Framework.Core;
using DAO;
using DTO;
using ProtocolVN.DanhMuc;

using System.Data;
using System.Collections.Generic;
using ProtocolVN.Plugin.TimeSheet;
using ProtocolVN.App.Office;
namespace office
{
    public partial class frmNghiPhep : XtraFormPL
    {
        #region Vùng đặt Static 
        public static string MenuItem(string ParentID, bool IsSep)
        {
            return MenuBuilder.CreateItem(typeof(frmNghiPhep).FullName,
                "Nghỉ phép",
                ParentID, true,
                typeof(frmNghiPhep).FullName,
                false, IsSep, "mnbCHinhHeThong.png", true, "", "");
        }
        #endregion

        #region Các khai báo biến 
        private DOTimeInOut Phieu = null;
        private bool? IsAdd; //true = New, null = View, false = Edit
        private long _ID;
        private DXErrorProvider Error;
        public delegate void RefreshAfterUpdateData(DOTimeInOut doNghiPhep);
        public event RefreshAfterUpdateData _RefreshAfterUpdateData;
        #endregion        

        #region Hàm dựng 
        public frmNghiPhep(long ID,bool? IsAdd)
        {
            InitializeComponent();
            Error = new DXErrorProvider();
            this.IsAdd = IsAdd;
            this._ID = ID;
            Duyet._init(true);
            Phieu = DATimeInOut.Instance.LoadAll(ID);
            HelpXtraForm.SetCloseForm(this, this.btnDong, IsAdd);
        }
        public frmNghiPhep() : this(-2,true) { }
        public frmNghiPhep(object Id)
            : this(HelpNumber.ParseInt64(Id), null)
        {
        }
        #endregion

        #region InitForm 
        private void InitGridColumns() {
            
        }

        private void InitData() {
           // DMNhanVienX.I.InitCtrl(NguoiNghiPhep, true, this.IsAdd);
            AppCtrl.InitTreeChonNhanVien_Choice1(NhanVien, IsAdd);
            AppCtrl.InitTreeChonNhanVien(NguoiNhanEmail, true);
            ngayNP.CreateDataset(IsAdd);
            NhanVien.popupContainerEdit1.CloseUp+=delegate(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
            {
                //nguoiNhanMail._SetDefault(nguoiNhanMail.dsSource.Tables[0], PLConst.QUYEN_DUYET_NGHI_PHEP, NguoiNghiPhep._getSelectedID());
                NguoiNhanEmail._SelectedIDs = PLTimeSheetUtil.GetNguoiNhanMail(
                    PLConst.QUYEN_DUYET_NGHI_PHEP, NhanVien._getSelectedID());
               
            };
            
        }
        private void frmNghiPhep_Load(object sender, EventArgs e)
        {
            HelpInputData.SetMaxLength(new object[] { meNoi_dung, 200 });
            HelpXtraForm.SetFix(this);
            #region Init control

            #region CHAUTV
            this.InitGridColumns();
            this.InitData();
            DataRow row = null;
            #endregion

            if (Phieu.NGAY_LAM_VIEC.ToString() != "01/01/0001 12:00:00 AM")
            {
                row = ngayNP.GetDataSet.Tables[0].NewRow();
                ngayNP.ngayNPUpdate = Phieu.NGAY_LAM_VIEC;
                row["NGAY"] = ngayNP.ngayNPUpdate;
                btnSave.Visible = IsAdd == null ? false : true;
                lblThoiGianCapNhat.Text = Phieu.THOI_GIAN_GHI_NHAN.ToString();
                lblNguoiCapNhat.Text = DMNhanVienX.I.GetEmployeeFullName(Phieu.NGUOI_GHI_NHAN);
                meNoi_dung.Text = Phieu.LY_DO;
                ngayNP.gridViewNgayNghiPhep.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
            }
            else
            {
                lblThoiGianCapNhat.Text = DABase.getDatabase().GetSystemCurrentDateTime().ToString(PLConst.FORMAT_DATETIME_STRING);
                lblNguoiCapNhat.Text = DMNhanVienX.I.GetEmployeeFullName(FrameworkParams.currentUser.employee_id);
            }
            if (Phieu.NV_ID != 0)
            {
                NhanVien._setSelectedID(Phieu.NV_ID);
                ngayNP.nvNghiPhep = Phieu.NV_ID;
            }
            else
            {
                ngayNP.nvNghiPhep = FrameworkParams.currentUser.employee_id;
                NhanVien._setSelectedID(FrameworkParams.currentUser.employee_id);
            }
            PLDataTree tree = AppCtrl.GetTreeList(NhanVien);
            if (tree != null)
            {
                tree.FocusedNodeChanged += delegate(object senderr, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs ee)
                {
                    ngayNP.nvNghiPhep = HelpNumber.ParseInt64(ee.Node["ID"]);
                    ngayNP.popupContainerEdit1.Text = string.Empty;
                    ngayNP.GetDataSet.Clear();
                };
            }           

            if (Phieu.NGHI_BUOI_SANG == "Y")
                row["SANG"] = "Y";
            if (Phieu.NGHI_BUOI_CHIEU == "Y")
                row["CHIEU"] = "Y";
            if (Phieu.NGHI_PHEP_NAM == "Y")
                radioGroup.SelectedIndex = 1;
            if (Phieu.NGHI_KHONG_LUONG == "Y")
                radioGroup.SelectedIndex = 0;
            meNoi_dung.Text = Phieu.LY_DO;
            if (Phieu.DUYET == null)
                Phieu.DUYET = "1";
            Duyet.SetDuyet(Phieu);
            if (row != null)
            {
                ngayNP.GetDataSet.Tables[0].Rows.Add(row);
                ngayNP.popupContainerEdit1.Text = Convert.ToDateTime(row["NGAY"]).ToString("dd/MM/yyyy");
            }
            #endregion
            //nguoiNhanMail.CreateDataset(PLConst.QUYEN_DUYET_NGHI_PHEP, NguoiNghiPhep._getSelectedID());
            NguoiNhanEmail._SelectedIDs = PLTimeSheetUtil.GetNguoiNhanMail(PLConst.QUYEN_DUYET_NGHI_PHEP, NhanVien._getSelectedID());
            PLTimeSheetUtil.PermissionForControl(NhanVien, NhanVien.Visible == true, NhanVien.Visible == true);
        }


        #endregion             

        #region Xử lý nút 
        private void btnSave_Click(object sender, EventArgs e)
        {
            Error.ClearErrors();
            #region Kiểm tra dữ liệu 
            bool IsValid = true;
            HelpInputData.TrimAllData(new object[] { 
                this.meNoi_dung
            });
            IsValid =  HelpInputData.ShowRequiredError(Error, new object[] { 
                NhanVien, "Người nghỉ phép",
                this.meNoi_dung,"Lý do nghỉ"
            });
            if (ngayNP.GetDataSet.Tables[0].Rows.Count < 1 || ngayNP.gridViewNgayNghiPhep.HasColumnErrors)
            {
                HelpMsgBox.ShowNotificationMessage("Vui lòng vào thông tin \"Ngày nghỉ phép\"!");
                IsValid = false;
            }            
            #endregion
            if (!IsValid) return;
            #region Lưu dữ liệu 
            foreach (DataRow row in ngayNP.GetDataSet.Tables[0].Rows)
            {
                if (IsAdd == true)
                {
                    Phieu.ID = HelpDB.getDatabase().GetID("G_NGHIEP_VU");
                    Phieu.THOI_GIAN_GHI_NHAN = HelpDB.getDBService().GetSystemCurrentDateTime();
                }
                Phieu.NV_ID = NhanVien._getSelectedID();
                Phieu.NGAY_LAM_VIEC = System.Convert.ToDateTime(row["NGAY"]);
                if (string.Compare(row["SANG"].ToString(),"Y") == 0)
                {
                    Phieu.THOI_GIAN_SANG = "N";
                    Phieu.NGHI_BUOI_SANG = "Y";
                }
                else
                {
                    Phieu.NGHI_BUOI_SANG = string.Empty;
                    Phieu.THOI_GIAN_SANG = string.Empty;
                }
                if (string.Compare(row["CHIEU"].ToString(), "Y") == 0)
                {
                    Phieu.THOI_GIAN_CHIEU = "N";
                    Phieu.NGHI_BUOI_CHIEU = "Y";
                }
                else
                {
                    Phieu.NGHI_BUOI_CHIEU = string.Empty;
                    Phieu.THOI_GIAN_CHIEU = string.Empty;
                }
                if (radioGroup.SelectedIndex == 1)
                    Phieu.NGHI_PHEP_NAM = "Y";
                else
                    Phieu.NGHI_PHEP_NAM = string.Empty;
                if (radioGroup.SelectedIndex == 0)
                    Phieu.NGHI_KHONG_LUONG = "Y";
                else
                    Phieu.NGHI_KHONG_LUONG = string.Empty;
                Phieu.NOI_DUNG = "Nghỉ phép: " + meNoi_dung.Text;
                Phieu.LY_DO = meNoi_dung.Text;
                Phieu.NV_ID = NhanVien._getSelectedID();

                Phieu.NGUOI_GHI_NHAN = FrameworkParams.currentUser.employee_id;
                Phieu.LOAI = 2;//2 : Loai nghi phep

                DATimeInOut.Instance.Update(Phieu);
                if (DATimeInOut.Instance.UpdatePhieu(Phieu))
                {
                    try
                    {
                        PLTimeSheetUtil._SendThongBao(NguoiNhanEmail._SelectedIDs, Phieu, PLConst.CHO_DUYET, LoaiPhieu.PhieuXinNghiPhep);
                        if (IsAdd == true) Phieu.DetailDataSet.Clear();
                    }
                    catch (Exception ex)
                    {
                        HelpSysLog.AddException(ex, "Lỗi thực hiện refresh dữ liệu.");
                        break;
                    }
                }
                else
                {
                    ErrorMsg.ErrorSave("Lưu không thành công. Vui lòng kiểm tra lại dữ liệu");
                    break;
                }
            }
            if (_RefreshAfterUpdateData != null) _RefreshAfterUpdateData(Phieu);
            HelpXtraForm.CloseFormNoConfirm(this);
            #endregion
        }
        #endregion                                                  
        
        #region Hỗ trợ gửi mail

        

        //private long[] GetEmployee() {
            //DataTable tb = (ngu.gridControlNguoiTheoDoi.DataSource as DataTable);
            //List<long> arr = new List<long>();
            //foreach (DataRow item in tb.Rows)
            //{
            //    if (item["CHON"].Equals("Y"))
            //        arr.Add(HelpNumber.ParseInt64(item["ID"]));
            //}
            //return arr.ToArray();
        //}

        private DataTable _SetDefault(DataTable table) {
            List<long> lstUser = PLTimeSheetUtil.getQuyen(PLConst.QUYEN_DUYET_NGHI_PHEP);
            foreach (DataRow row in table.Rows)
                if (lstUser.Contains(HelpNumber.ParseInt64(row["ID"])))
                    row["CHON"] = "Y";
            return table;
        }

       
        #endregion

       

    }
}
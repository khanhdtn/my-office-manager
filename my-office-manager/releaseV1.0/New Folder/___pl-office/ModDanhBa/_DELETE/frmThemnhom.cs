using System;
using System.Data;
using System.Windows.Forms;
using ProtocolVN.Framework.Win;
using ProtocolVN.Framework.Core;
using DevExpress.XtraEditors.DXErrorProvider;
using System.Collections.Generic;
using DevExpress.XtraNavBar;
using DTO;
using DAO;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;


namespace office
{
    public partial class frmThemNhom : XtraFormPL
    {
        public delegate void Refresh_Nhom_Danh_Ba(long ID,string Name);
        public Refresh_Nhom_Danh_Ba Add_Danh_Ba;
        public delegate void Refresh_Sua_Nhom();
        public Refresh_Sua_Nhom Sua_Nhom;

        #region Vùng đặt Static
        public static FormStatus Status = FormStatus.NO;
        public static string MenuItem(string ParentID, bool IsSep)
        {
            return MenuBuilder.CreateItem(typeof(frmThemNhom).FullName,
                PMSupport.UpdateTitle("Quản lý danh bạ", Status),
                ParentID, true,
                typeof(frmThemNhom).FullName,
                false, IsSep, "mnbQLyNguoiDung.png", true, "", "");
        }
        #endregion

        #region Declare variable(s)
        private DOLoaiDanhBa Data_Danh_Ba;
        private DXErrorProvider error;
        private List<NavBarItem> _ListItem;
        private NavBarItem _CurrentBarItem;
        private DataRow[] _RowFiledNames;
        #endregion

        #region Hàm dựng
        public frmThemNhom(List<NavBarItem> ListItem)
        {
            InitializeComponent();
            error = new DXErrorProvider();
            this._ListItem = ListItem;
        }
        public frmThemNhom(NavBarItem CurrentBarItem,DataRow[] RowField,List<NavBarItem> ListItem,bool IsSuaNhom)
        {
            InitializeComponent();
            error = new DXErrorProvider();
            _CurrentBarItem = CurrentBarItem;
            _ListItem = ListItem;
            this._RowFiledNames = RowField;
            if (IsSuaNhom) this.Text = "Sửa thông tin nhóm";
        }
        #endregion
        
        private DataTable Load_Cau_Hinh_Danh_Ba()
        {
            DOCauHinhDanhBa data= DACauHinhDanhBa.Instance.LoadAll(1);
            return data.DetailDataSet.Tables[0];
        }
        #region Init Form
        private void frmThemnhom_Load(object sender, EventArgs e)
        {
            btnDongy.Image = FWImageDic.SAVE_IMAGE16;
            btnDong.Image = FWImageDic.CLOSE_IMAGE16;
            HelpXtraForm.SetFix(this);
            GUIValidation.SetMaxLength(new object[] { 
                this.txtTen_Loai,100
            });
            PMSupport.SetTitle(this, Status);
            this.checklistField_Name.DataSource = Load_Cau_Hinh_Danh_Ba();            
            this.checklistField_Name.DisplayMember = "MO_TA";
            this.checklistField_Name.ValueMember = "FIELD_NAME";            
            checklistField_Name.SetItemChecked(0, true);
            checklistField_Name.ItemCheck += new DevExpress.XtraEditors.Controls.ItemCheckEventHandler(checklistField_Name_ItemCheck);
            if (_RowFiledNames == null)
            {
                Data_Danh_Ba = DALoaiDanhBa.Instance.LoadAll(-2);
                txtTen_Loai.Focus();
            }
            else
            {
                txtTen_Loai.Text = _CurrentBarItem.Caption;
                txtTen_Loai.Enabled = false;
                SetFieldNameChecked(_RowFiledNames);
            }
        }

        void checklistField_Name_ItemCheck(object sender, DevExpress.XtraEditors.Controls.ItemCheckEventArgs e)
        {
            if(e.Index == 0)
                checklistField_Name.SetItemChecked(0, true);
        }
        #endregion

        #region Xử lý nút
        private void btnDong_Click(object sender, EventArgs e)
        {
            if (PLMessageBox.ShowConfirmMessage("Đóng \"Thêm mới nhóm\" ?") == DialogResult.Yes)
                this.Close();            
        }

        private void btnDongy_Click(object sender, EventArgs e)
        {                       
            GUIValidation.TrimAllData(new object[] { txtTen_Loai });            
            if (!Validate_Data()) return;            
            try
            {
                if (_RowFiledNames == null)
                {
                    if (DALoaiDanhBa.Instance.isDuplicateNameDirectory(this._ListItem, txtTen_Loai.Text))
                    {
                        error.SetError(txtTen_Loai, "Tên nhóm bị trùng.Vui lòng kiểm tra lại!");
                        return;
                    }
                    error.ClearErrors();
                    if (DALoaiDanhBa.Instance.InsertLoaiDanhBa(Data_Danh_Ba, txtTen_Loai.Text) && DACauHinhDanhBa.Instance.InsertDanhBaFields(Data_Danh_Ba.ID, checklistField_Name))
                    {                      
                        if(Add_Danh_Ba !=null ) Add_Danh_Ba(Data_Danh_Ba.ID, txtTen_Loai.Text);
                        HelpXtraForm.CloseFormNoConfirm(this);
                    }
                    else
                        PLMessageBox.ShowNotificationMessage("Thêm nhóm không thành công!");
                }
                else
                {
                    if (XoaThongTinCu() && ThemThongTinMoi()){
                        HelpXtraForm.CloseFormNoConfirm(this);
                        if (Sua_Nhom != null) Sua_Nhom();
                    }
                    else
                        PLMessageBox.ShowNotificationMessage("Sửa nhóm không thành công!");
                }

            }
            catch (Exception ex)
            {
                PLException.AddException(ex);
            }
        }
        private bool Validate_Data()
        {            
            bool Is_error = true ;
            Is_error=GUIValidation.ShowRequiredError(error,new object[]{txtTen_Loai,"Tên nhóm"});
            if (!Is_error)                          
                return Is_error;
           
            if (checklistField_Name.CheckedItems.Count == 0)
            {
                PLMessageBox.ShowNotificationMessage("Vui lòng chọn các thông tin của nhóm!");
                Is_error = false;
            }
            return Is_error;            
        }
        private void SetFieldNameChecked(DataRow[] FieldNames)
        {
            try
            {
                DataSet ds = (checklistField_Name.DataSource as DataTable).DataSet;
                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    foreach (DataRow row in FieldNames)
                    {
                        if (item["FIELD_NAME"].ToString() == row["FIELD_NAME"].ToString())
                        {
                            checklistField_Name.SetItemChecked(ds.Tables[0].Rows.IndexOf(item), true);
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                PLException.AddException(ex);
            }
        }
        /// <summary>
        /// Xóa các thông tin trước đó
        /// </summary>
        private bool XoaThongTinCu()
        {
            try
            {
                BaseCheckedListBoxControl.CheckedItemCollection Checked_List = checklistField_Name.CheckedItems;
                bool IsDelete = true;
                List<string> List_FieldName = new List<string>();
                foreach (DataRow row in _RowFiledNames)
                {
                    IsDelete = true;
                    for (int i = 0; i < Checked_List.Count; i++)
                    {
                        if (row["FIELD_NAME"].ToString() == Checked_List[i].ToString())
                        {
                            IsDelete = false;
                            break;
                        }
                    }
                    if (IsDelete)
                        List_FieldName.Add(row["FIELD_NAME"].ToString());
                }
                return DACauHinhDanhBa.Instance.DeleteDanhBaFields(HelpNumber.ParseInt64(_CurrentBarItem.Name), List_FieldName);
            }
            catch (Exception ex)
            {
                PLException.AddException(ex);
                return false;
            }
        }
        private bool ThemThongTinMoi()
        {
            try
            {
                BaseCheckedListBoxControl.CheckedItemCollection Checked_List = checklistField_Name.CheckedItems;
                bool IsInsert = true;
                List<string> List_FieldName = new List<string>();
                for (int i = 0; i < Checked_List.Count; i++)
                {
                    IsInsert = true;
                    foreach (DataRow row in _RowFiledNames)
                    {
                        if (Checked_List[i].ToString() == row["FIELD_NAME"].ToString())
                        {
                            IsInsert = false;
                            break;
                        }
                    }
                    if (IsInsert)
                        List_FieldName.Add(Checked_List[i].ToString());
                }
                return DACauHinhDanhBa.Instance.AddDanhBaFields(HelpNumber.ParseInt64(_CurrentBarItem.Name), List_FieldName);
            }
            catch (Exception ex)
            {
                PLException.AddException(ex);
                return false;
            }
        }
        #endregion
    }
}
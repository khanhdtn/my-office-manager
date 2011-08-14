using System;
using System.Data;
using System.Windows.Forms;
using ProtocolVN.Framework.Core;
using ProtocolVN.Framework.Win;
using ProtocolVN.Plugin.TimeSheet.bo;
using DevExpress.XtraEditors.DXErrorProvider;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;
using DAO;
using pl.office;


namespace ProtocolVN.Plugin.TimeSheet
{
    public partial class frmTimeTable : XtraFormPL
    {       
        private DXErrorProvider Error;
        private DOChiTietCongViec chitietcongviec;        
        private bool IsUpdate;
        private bool Is_Add=false;
        private long NV_ID;

        #region Hàm dựng và Form Load

        public frmTimeTable()
        {
            InitializeComponent();
            Error = new DXErrorProvider();            
            InitGrid();            
            Duyet._init(true);
            this.Is_Add = true;
            this.NV_ID = DAChiTietCongViec.Instance.GetNVID(HelpNumber.ParseInt64(FrameworkParams.currentUser.id));
            InitControl();            
            btnDuyet.Enabled = false;
            gridViewDSCongviec.OptionsView.ColumnAutoWidth = true;
            this.gridDSCongviec.DataSource = DAChiTietCongViec.Instance.GetData(NgayNhap.DateTime,-1).Tables[0];
            gridViewDSCongviec.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom;            
        }        

        public frmTimeTable(DateTime Ngaylamviec, long ID_NV,long CTCV_ID,bool is_update)
        {
            InitializeComponent();            
            Error = new DXErrorProvider();
            this.Is_Add = false;
            this.IsUpdate = is_update;
            this.NV_ID = ID_NV;
            InitGrid();
            Duyet._init(true);
            InitControl();                       
            InnitDodata(Ngaylamviec, ID_NV, CTCV_ID);            
            gridViewDSCongviec.OptionsView.NewItemRowPosition = (is_update==true?  NewItemRowPosition.Bottom : NewItemRowPosition.None );
            gridViewDSCongviec.OptionsBehavior.Editable = is_update;
            btnSave.Visible = is_update;
            btnDuyet.Enabled = is_update;             
            NgayNhap.Enabled = is_update;
            gridViewDSCongviec.OptionsView.ColumnAutoWidth = true;
            gridViewDSCongviec.OptionsBehavior.Editable = is_update;
            if(this.Is_Add!=true)
                btnDuyet.Enabled = true;             
        }
        
        #endregion

        #region Xu ly khoi tao
        public static void CloseDong(GridControl gridcontrol, GridView Gridview,bool? isadd)
        {
            GridColumn column = XtraGridSupportExt.CloseButton(gridcontrol,Gridview);
            if (isadd == null)
                column.Visible = false;
           
        }

        public void InitControl()
        {
            NgayNhap.DateTime = DABase.getDatabase().GetSystemCurrentDateTime();
            lblThoiGianCapNhat.Text = DABase.getDatabase().GetSystemCurrentDateTime().ToString("dd/MM/yyyy HH:mm");
            DataTable dt=DAChiTietCongViec.Instance.GetTen_NV(this.NV_ID).Tables[0];
            if (dt.Rows.Count > 0)
                lblNhanVien.Text = dt.Rows[0]["TEN_NV"].ToString();
            else
                lblNhanVien.Text = string.Empty;
            btnClose.Image = FWImageDic.CLOSE_IMAGE16;
            btnSave.Image = FWImageDic.SAVE_IMAGE16;
        }

        public void InitGrid()
        {
            XtraGridSupportExt.ComboboxGridColumn(Cotloai_cv, "v_dm_loai_cong_viec", "ID", "NAME", "LCV_ID");            
            XtraGridSupportExt.TextLeftColumn(Cotmota,"MO_TA");                        
            HelpGridColumn.CotPLTimeEdit(CotTGTH,"THOI_GIAN_THUC_HIEN","HH:mm");    
       
        }
        
        public void InnitDodata(DateTime ngaylamviec,long ID_NV,long CTCCV_ID)

        {
            DataSet ds = new DataSet();
            if (CTCCV_ID != -1)
            {
                chitietcongviec = DAChiTietCongViec.Instance.GetCTCV(ngaylamviec, ID_NV, CTCCV_ID);
                ds = DAChiTietCongViec.Instance.GetData_Update(CTCCV_ID);
            }
            else if (ngaylamviec.ToString() != "" && ID_NV.ToString() != "")
            {
                chitietcongviec = DAChiTietCongViec.Instance.GetCTCV(ngaylamviec,ID_NV,-1);
                ds= DAChiTietCongViec.Instance.GetData(ngaylamviec,ID_NV);
            }
            NgayNhap.DateTime = ngaylamviec;
            lblThoiGianCapNhat.Text = System.Convert.ToDateTime(chitietcongviec.NGAY_CAP_NHAT).ToString("dd/MM/yyyy HH:mm");
            this.gridDSCongviec.DataSource = ds.Tables[0];
            if (ds.Tables[0].Rows.Count > 0)
            {
                Info.Enabled = true;

                PLTimeSheetUtil.UpdateInfo_Duyet(Info, chitietcongviec);
                foreach (DataRow r in ds.Tables[0].Rows)
                {
                    if (r["DUYET"].ToString() == "1")
                    {
                        chitietcongviec._DUYET = "1";
                        Duyet.SetDuyet(chitietcongviec);
                        Allow(true, gridViewDSCongviec);
                        btnDuyet.Text = "Duyệt";
                        break;
                    }
                    else if (r["DUYET"].ToString() == "2")
                    {

                        Duyet.SetDuyet(chitietcongviec);
                        Allow(false, gridViewDSCongviec);
                        btnDuyet.Text = "Không Duyệt";
                        break;
                    }
                    else if (r["DUYET"].ToString() == "3")
                    {

                        Duyet.SetDuyet(chitietcongviec);
                        Allow(true, gridViewDSCongviec);
                        btnDuyet.Text = "Duyệt";
                        break;
                    }

                }
                btnDuyet.Enabled = true;

            }
            else
            {
                Info.Enabled = false;
                chitietcongviec._DUYET = "1";
                Duyet.SetDuyet(chitietcongviec);
                Allow(true, gridViewDSCongviec);
                btnDuyet.Enabled = false;
            }
        }

        #endregion
      
        #region Xử lý nút

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(gridViewDSCongviec.RowCount==1 && Is_Add)
                PLMessageBox.ShowErrorMessage("Vui lòng nhập dữ liệu vào lưới!");
            else 
            {
                bool flag = false;
                flag = DAChiTietCongViec.Instance.Update_CTCV(((DataView)gridViewDSCongviec.DataSource).Table.DataSet, this.NV_ID, NgayNhap.DateTime, chitietcongviec, IsUpdate);
                if (flag != true)
                    PLMessageBox.ShowErrorMessage("Lưu không thành công. Vui lòng kiểm tra số liệu!");
                else
                {
                    this.Close();
                }
            }                                       
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (IsUpdate == false)
                this.Close();
            else
            {
                if (PLMessageBox.ShowConfirmMessage("Bạn có chắc muốn đóng ?") == DialogResult.Yes)
                {
                    this.Close();
                }
            }
        }
        
        private void btnDuyet_Click(object sender, EventArgs e)
        {            
            if (btnDuyet.Text == "Duyệt")
            {
                btnDuyet.Text = "Không Duyệt";               
                chitietcongviec._DUYET = "2";
                Duyet.SetDuyet(chitietcongviec);                
            }
            else
            {
                btnDuyet.Text = "Duyệt";
                chitietcongviec._DUYET = "3";
                Duyet.SetDuyet(chitietcongviec);                               
            }
           
        }

        private void rep_Xoa_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            DataRow row = gridViewDSCongviec.GetDataRow(gridViewDSCongviec.FocusedRowHandle);
            if (row != null)
            {
                if (row["DUYET"].ToString() == "2")
                    PLMessageBox.ShowNotificationMessage("Xóa không thành công.Công việc của bạn đã được duyệt!");
                else if (PLMessageBox.ShowConfirmMessage("Bạn có muốn xóa dòng này không ?") == System.Windows.Forms.DialogResult.Yes)
                    gridViewDSCongviec.DeleteRow(gridViewDSCongviec.FocusedRowHandle);
            }
        }
        #endregion

        #region Validate  
        private FieldNameCheck[] GetMaxLength()
        {
            return new FieldNameCheck[]{
                new FieldNameCheck("MO_TA",new CheckType[]{CheckType.OptionMaxLength},new string []{ErrorMsgLib.errorMaxLength("Công việc")},new object[]{200})
            };
        }
        private void gridViewDSCongviec_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            DataSet ds1 = (gridDSCongviec.DataSource as DataTable).DataSet;
            GridView grid = (GridView)sender;
            DataRow row = grid.GetDataRow(e.RowHandle);
            bool flag=true;            
            row.ClearErrors();
            if (row["LCV_ID"].ToString() == "")
            {
                row.SetColumnError("LCV_ID", "Mời nhập loại công việc!");
                e.Valid = false;                
                return;
            }
            if (row["MO_TA"].ToString() == "")
            {
                row.SetColumnError("MO_TA", "Mời nhập mô tả công việc!");
                e.Valid = false;                
                return;
            }
            DateTime dt;
            if (row["THOI_GIAN_THUC_HIEN"].ToString() != "")
            {
                dt = System.Convert.ToDateTime(row["THOI_GIAN_THUC_HIEN"]);
                if (dt.Hour == 0 && dt.Minute == 0)
                {
                    row.SetColumnError("THOI_GIAN_THUC_HIEN", "Mời nhập thời gian thực hiện!");
                    e.Valid = false;                    
                    return;
                }
            }
            if (row["THOI_GIAN_THUC_HIEN"].ToString() == "")
            {
                row.SetColumnError("THOI_GIAN_THUC_HIEN", "Mời nhập thời gian thực hiện!");
                e.Valid = false;                
                return;
            }
            if(!GUIValidation.ValidateRow(gridViewDSCongviec,row,GetMaxLength()))
            {
                e.Valid=false;
                return;
            }
            //Kiểm tra trùng lặp dữ liệu trên lưới
            DataSet ds = DAChiTietCongViec.Instance.CheckDuplicate(NgayNhap.DateTime,this.NV_ID);
            flag = Kiem_tra_dl(ds,row);//Kiểm tra dl dưới DB
            if (flag == false)
            {
                e.Valid = false;
                return;
            }
            ds.Clear();
            ds = (gridDSCongviec.DataSource as DataTable).DataSet;//Kiểm tra dl trên lưới
            flag = Kiem_tra_dl(ds,row);
            if (flag == false)
            {
                e.Valid = false;                
                return;
            }
        }
        bool Kiem_tra_dl(DataSet ds,DataRow row)
        {
            if (ds != null)
            {
                foreach (DataRow r in ds.Tables[0].Rows)
                {
                    if (r.RowState != DataRowState.Deleted)
                    {
                        if (r["CTCCV_ID"].ToString() != row["CTCCV_ID"].ToString())
                        {

                            if (row["LCV_ID"].ToString() == r["LCV_ID"].ToString() && row["MO_TA"].ToString().ToLower() == r["MO_TA"].ToString().ToLower())
                            {
                                row.SetColumnError("LCV_ID", "Công việc và mô tả công việc nhập bị trùng lặp!");
                                return false ;
                            }
                        }
                    }
                }                
            }
            return true;
        }
        void Allow(bool flag, PLGridView gridView)
        {
            if (flag == false)
            {
                Duyet.Enabled = false;
                gridView.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
                gridView.OptionsBehavior.Editable = false;
                btnSave.Enabled = false;
            }
            else
            {
                Duyet.Enabled = false;
                gridView.OptionsView.NewItemRowPosition = NewItemRowPosition.None  ;
                gridView.OptionsBehavior.Editable = true;
                btnSave.Enabled = true;
            }
        }

        Int64 i = 0;
        private void gridViewDSCongviec_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {            
                DataRow row = gridViewDSCongviec.GetDataRow(gridViewDSCongviec.FocusedRowHandle);
                if (row["CTCCV_ID"].ToString() == "")
                    row["CTCCV_ID"] = i++;           
        }

        private void gridViewDSCongviec_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow row = gridViewDSCongviec.GetDataRow(gridViewDSCongviec.FocusedRowHandle);            
            if (row != null)
            {
                if (row.RowState == DataRowState.Added)
                    btnDuyet.Enabled = false;
                else                
                btnDuyet.Enabled = true;
            }           
        }
       
        #endregion                         
    }
}
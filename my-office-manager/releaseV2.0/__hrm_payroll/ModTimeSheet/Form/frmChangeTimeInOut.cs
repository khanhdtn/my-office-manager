using System;
using System.Data;
using System.Windows.Forms;
using ProtocolVN.Framework.Win;
using ProtocolVN.Framework.Core;
using DevExpress.XtraGrid.Views.Base;
using DTO;
using DAO;
using DevExpress.XtraEditors.DXErrorProvider;
using ProtocolVN.Framework.Dev.Open;
using pl.office;

namespace ProtocolVN.Plugin.TimeSheet
{
    public partial class frmChangeTimeInOut : XtraFormPL
    {
        #region Các khai báo biến 
        private DataSet ds;
        private DataSet ds_updated;
        private DXErrorProvider Error;  
        private DOTimeInOut do_InOut = null;       
        #endregion

        #region Các hàm khởi tạo 
        public frmChangeTimeInOut()
        {
            InitializeComponent();
            Error = new DXErrorProvider();
            Init();
            do_InOut = DATimeInOut.Instance.LoadAll(-2);
            State_button(false, true);
        }
        private void Init()
        {                       
            #region Init ds 
            XtraGridSupportExt.TextLeftColumn(colPb, "PHONG_BAN");
            XtraGridSupportExt.TextLeftColumn(colHo_ten, "TEN_NV");            
            #endregion
            #region Init ds_updated
            XtraGridSupportExt.TextLeftColumn(colPB_DC, "PHONG_BAN");
            XtraGridSupportExt.TextLeftColumn(colHT_DC, "TEN_NV");
            XtraGridSupportExt.TextLeftColumn(colTGDC, "TGDC_1");
            #endregion

        }
        private void Load_Data(DateTime Ngay_lam_viec)
        {
            string sql = @"Select CN.ID,D.NAME as PHONG_BAN,NV.ID as NV_ID,NV.NAME as TEN_NV,NGAY_LAM_VIEC,GIO_BAT_DAU,GIO_KET_THUC,THOI_GIAN_LAM_VIEC,THOI_GIAN_SANG,THOI_GIAN_CHIEU
                            from (DM_NHAN_VIEN NV inner join CAPNHAT_NGAYLAMVIEC CN on NV.ID=CN.NV_ID) left join DEPARTMENT D on D.ID=NV.DEPARTMENT_ID where CN.LOAI=1 and 1=1";           
            QueryBuilder query = new QueryBuilder(sql);            
            query.addDateFromTo("NGAY_LAM_VIEC", dateNgay_LV.DateTime, dateNgay_LV.DateTime);            
            ds = DABase.getDatabase().LoadDataSet(query);
            ds.Tables[0].Columns.Add("TGDC_1", Type.GetType("System.DateTime"));
            ds_updated = ds.Clone();            
            gridControlSource.DataSource = ds.Tables[0];
        }
        private void frmThayDoi_GBD_GKT_Load(object sender, EventArgs e)
        {
            Uncategory.setEnterAsTab(this);
            btnDong.Image = FWImageDic.CLOSE_IMAGE16;            
            btnLuu.Image = FWImageDic.SAVE_IMAGE16;
            gridViewSource.OptionsBehavior.AutoExpandAllGroups = true;
            gridViewDestination.OptionsBehavior.AutoExpandAllGroups = true;
            HelpXtraForm.SetFix(this);           
        }

        #endregion

        #region Các xử lý sự kiện

        private void btnDong_Click(object sender, EventArgs e)
        {
            if (PLMessageBox.ShowConfirmMessage("Bạn có muốn thoát?") == DialogResult.Yes)
                this.Close();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            TimeSpan Ts = Convert.ToDateTime(TG_ThayDoi.Time).TimeOfDay;
            if (Ts.Hours == 0 && Ts.Minutes == 0)
            {
                Error.SetError(TG_ThayDoi, "Vui lòng chọn thời gian để điều chỉnh!");
                return;
            }
            if (ds_updated.Tables[0].Rows.Count <= 0)
            {
                PLMessageBox.ShowNotificationMessage("Vui lòng chọn nhân viên để điều chỉnh!");
                return;
            }
            if (radioGroup.SelectedIndex == 0)
            {
                foreach (DataRow row in ds_updated.Tables[0].Rows)
                {
                    if (row.RowState != DataRowState.Deleted)
                    {
                        try
                        {
                            row["GIO_BAT_DAU"] = Get_GBD(TG_ThayDoi.Time, row["GIO_BAT_DAU"], true);
                        }
                        catch
                        {
                            Error.SetError(TG_ThayDoi, "Số giờ giảm không được lớn hơn số giờ của giờ bắt đầu!");
                            return;
                        }                        
                        if (row["THOI_GIAN_LAM_VIEC"] != DBNull.Value)
                        {
                            TimeSpan? Tglv = HelpDateExt.getThoiGianLamViec(row["GIO_BAT_DAU"], row["GIO_KET_THUC"]);
                            if (Tglv != null)
                                row["THOI_GIAN_LAM_VIEC"] = new DateTime(1970, 1, 1, Tglv.Value.Hours, Tglv.Value.Minutes, Tglv.Value.Seconds);
                        }
                    }
                }
            }
            else
            {
                foreach (DataRow row in ds_updated.Tables[0].Rows)
                {
                    if (row.RowState != DataRowState.Deleted)
                    {
                        if (row["GIO_KET_THUC"] != DBNull.Value)
                        {
                            DateTime dt = System.Convert.ToDateTime(row["GIO_KET_THUC"]);
                            row["GIO_KET_THUC"] = Get_GKT(TG_ThayDoi.Time, row["GIO_KET_THUC"], true);
                            if (System.Convert.ToDateTime(row["GIO_KET_THUC"]).TimeOfDay <= dt.TimeOfDay)
                            {
                                Error.SetError(TG_ThayDoi, "Số giờ tăng không được làm cho giờ kết thúc vượt quá 24 giờ!");
                                return;
                            }
                        }
                        else {
                            PLMessageBox.ShowNotificationMessage("Nhân viên '" + row["TEN_NV"].ToString() + "' chưa có giờ kết thúc.");
                            return;
                        }
                        if (row["THOI_GIAN_LAM_VIEC"] != DBNull.Value)
                        {
                            TimeSpan? Tglv = HelpDateExt.getThoiGianLamViec(row["GIO_BAT_DAU"], row["GIO_KET_THUC"]);
                            if (Tglv != null)
                                row["THOI_GIAN_LAM_VIEC"] = new DateTime(1970, 1, 1, Tglv.Value.Hours, Tglv.Value.Minutes, Tglv.Value.Seconds);
                        }
                    }
                }
            }
            #region Tính thời gian sáng và chiều
            foreach (DataRow row in ds_updated.Tables[0].Rows)
            {
                if (row["THOI_GIAN_LAM_VIEC"] != DBNull.Value)
                {
                    DateTime GioBatDau = System.Convert.ToDateTime(row["GIO_BAT_DAU"]);
                    DateTime GioKetThuc = System.Convert.ToDateTime(row["GIO_KET_THUC"]);
                    if (GioBatDau.TimeOfDay < PLOptions.GIO_NGHI_TRUA.TimeOfDay)
                    {
                        TimeSpan? TG_Sang;
                        if (GioKetThuc.TimeOfDay < PLOptions.GIO_BD_CHIEU.TimeOfDay)
                            TG_Sang = HelpDateExt.getThoiGianLamViec(GioBatDau, GioKetThuc);
                        else
                            TG_Sang = HelpDateExt.getThoiGianLamViec(GioBatDau, PLOptions.GIO_NGHI_TRUA);
                        row["THOI_GIAN_SANG"] = new DateTime(1970, 1, 1, TG_Sang.Value.Hours, TG_Sang.Value.Minutes, TG_Sang.Value.Seconds).TimeOfDay.ToString().Substring(0, 5);
                    }
                    row["THOI_GIAN_CHIEU"] = string.Empty;
                    if (GioBatDau != null && GioBatDau.TimeOfDay >= PLOptions.GIO_BD_CHIEU.TimeOfDay)
                    {
                        if (GioKetThuc != null)
                        {
                            TimeSpan? TG_Chieu = HelpDateExt.getThoiGianLamViec(GioBatDau, GioKetThuc);
                            row["THOI_GIAN_CHIEU"] = new DateTime(1970, 1, 1, TG_Chieu.Value.Hours, TG_Chieu.Value.Minutes, TG_Chieu.Value.Seconds).TimeOfDay.ToString().Substring(0, 5);
                        }
                    }
                    else
                    {
                        if (GioKetThuc != null)
                        {
                            TimeSpan? Temp = HelpDateExt.getThoiGianLamViec(PLOptions.GIO_BD_CHIEU, GioKetThuc);
                            row["THOI_GIAN_CHIEU"] = new DateTime(1970, 1, 1, Temp.Value.Hours, Temp.Value.Minutes, Temp.Value.Seconds).TimeOfDay.ToString().Substring(0, 5);
                        }
                    }
                }                    
            }
            #endregion
            HelpDataSet.MergeDataSet(new string[] {"ID"}, do_InOut.DetailDataSet, ds_updated);
            if (DATimeInOut.Instance.UpdatePhieu(do_InOut))
                this.Close();
            else
                PLMessageBox.ShowNotificationMessage("Cập nhật dữ liệu không thành công!");
        }
       
        private void btnAdd_1_Click(object sender, EventArgs e)
        {
            if (gridViewSource.GetSelectedRows().Length > 0)
            {
                if (!gridViewSource.IsGroupRow(gridViewSource.FocusedRowHandle))
                {
                    Error.SetError(TG_ThayDoi, "");
                    int[] Selected_rows = gridViewSource.GetSelectedRows();
                    int j = 0;
                    foreach (int i in Selected_rows)
                    {
                        if (gridViewSource.IsGroupRow(i)) continue;
                        DataRow row = gridViewSource.GetDataRow(i);
                        ds_updated.Tables[0].ImportRow(gridViewSource.GetDataRow(i));
                        j++;
                    }
                    for (int i = Selected_rows.Length - 1; i >= 0; i--)
                    {
                        if (!gridViewSource.IsGroupRow(Selected_rows[i]))
                            gridViewSource.DeleteRow(Selected_rows[i]);
                    }
                    gridViewSource.RefreshData();
                    gridControlDestination.DataSource = ds_updated.Tables[0];
                }
            }
            else {
                PLMessageBox.ShowNotificationMessage("Vui lòng chọn dữ liệu chuyển.");
            }
        }
        
        private void btnAdd_all_Click(object sender, EventArgs e)
        {         
            Error.SetError(TG_ThayDoi,"");
            HelpDataSet.MergeDataSet(new string[] { "ID" }, ds_updated, ds);
            ds.Clear();            
            gridControlSource.DataSource = ds.Tables[0];
            gridControlDestination.DataSource = ds_updated.Tables[0];                           
        }

        private void btnSub_1_Click(object sender, EventArgs e)
        {
            int[] Selected_rows = gridViewDestination.GetSelectedRows();
            if (Selected_rows.Length == 0) {
                PLMessageBox.ShowNotificationMessage("Vui lòng chọn dữ liệu chuyển.");
                return; 
            }
            int j = 0;
            if (radioGroup.SelectedIndex == 0)
            {
                foreach (int i in Selected_rows)
                {                                                           
                    ds.Tables[0].ImportRow(gridViewDestination.GetDataRow(i));                    
                    j++;
                }
            }
            for (int i = Selected_rows.Length - 1; i >= 0; i--)
            {
                if (!gridViewDestination.IsGroupRow(Selected_rows[i]))
                    gridViewDestination.DeleteRow(Selected_rows[i]);
            }            
            gridViewDestination.RefreshData();
            gridControlSource.DataSource = ds.Tables[0];
        }

        private void btnSub_all_Click(object sender, EventArgs e)
        {      
            HelpDataSet.MergeDataSet(new string[] { "ID" }, ds, ds_updated);
            ds_updated.Clear();            
            gridControlSource.DataSource = ds.Tables[0];
            gridControlDestination.DataSource = ds_updated.Tables[0];
        }

        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (radioGroup.SelectedIndex == 0)
                labelControl2.Text = "Giảm";
            else
                labelControl2.Text = "Tăng";        
        }

        private void dateNgay_LV_EditValueChanged(object sender, EventArgs e)
        {
            do_InOut.DetailDataSet = DATimeInOut.Instance.Load_detailDs(dateNgay_LV.DateTime);
            Load_Data(dateNgay_LV.DateTime);
            State_button(true, false);
        }
        #endregion

        #region Các hàm chức năng
        private DateTime Get_GBD(object Time_sub, object GDB, bool Is_add)
        {
            TimeSpan TimetoSub = Convert.ToDateTime(Time_sub).TimeOfDay;
            TimeSpan TimeStart = System.Convert.ToDateTime(GDB).TimeOfDay;
            if (Is_add)
                return new DateTime(1970, 1, 1,(TimeStart - TimetoSub).Hours, (TimeStart - TimetoSub).Minutes, TimeStart.Seconds);
            else
                return new DateTime(1970, 1, 1, (TimeStart + TimetoSub).Hours, (TimeStart + TimetoSub).Minutes, TimeStart.Seconds);

        }
        private DateTime Get_GKT(object Time_add, object GKT, bool Is_add)
        {
            TimeSpan TimetoAdd = Convert.ToDateTime(Time_add).TimeOfDay;
            TimeSpan TimeEnd = System.Convert.ToDateTime(GKT).TimeOfDay;
            if (Is_add)
                return new DateTime(1970, 1, 1, (TimeEnd + TimetoAdd).Hours, (TimeEnd + TimetoAdd).Minutes, TimeEnd.Seconds);
            else
                return new DateTime(1970, 1, 1, (TimeEnd - TimetoAdd).Hours, (TimeEnd - TimetoAdd).Minutes, TimeEnd.Seconds);
        }
        #endregion

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            btnAdd_1_Click(sender, e);
        }
        private void gridView4_DoubleClick(object sender, EventArgs e)
        {
            btnSub_1_Click(sender, e);
        }
        private void gridView4_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            //Is_first_time++;
            //if (Is_first_time == 1) return;
            //DataRow row = gridView4.GetDataRow(gridView4.FocusedRowHandle);
            //if (row != null)
            //{
            //    if (!gridView4.IsGroupRow(gridView4.FocusedRowHandle))
            //        TG_ThayDoi.Time = System.Convert.ToDateTime(row["TGDC_1"]);
            //    else
            //        TG_ThayDoi.Time = System.Convert.ToDateTime("26/04/2008 12:00:00 AM");
            //}
        }
        private void State_button(bool state,bool Is_load)
        {
            btnAdd_1.Enabled = state;
            btnAdd_all.Enabled = state;
            btnSub_1.Enabled = state;
            btnSub_all.Enabled = state;
            btnLuu.Enabled = state;
            if (Is_load)
                btnDong.Enabled = !state;
            else
                btnDong.Enabled = state;
        }       
    }
}
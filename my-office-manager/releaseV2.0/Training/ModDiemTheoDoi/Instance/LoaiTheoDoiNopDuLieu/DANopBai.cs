using System;
using System.Collections.Generic;
using System.Text;
using ProtocolVN.Framework.Core;
using System.Data;
using System.Data.Common;
using ProtocolVN.Framework.Win;
using System.Windows.Forms;
using System.Threading;
using DevExpress.XtraGrid.Views.Grid;
using System.IO;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraEditors;
using System.Drawing;

namespace office.model
{
    public class DANopBai
    {
        public static string[] PK_FIELD_NAME = new string[] { "DTD_ID" };
        public static string[] FK_FIELD_NAME = new string[] { "BTD_ID", "LCV_ID" };
        public static string TABLE_NAME = "DIEM_THEO_DOI_NOP_BAI";
        object[] FIELD_MAP = new object[] {             
				"DTD_ID", new IDConverter(),	
				"HAN_NOP", null,	
				"NGAY_NOP", null,
                "NOI_DUNG", new IDConverter(),	
                "TEN_TAI_LIEU", null,
				"NHAN_SU", new IDConverter(),	
                "NGUOI_GIAO", new IDConverter(),
                "NGAY_GIAO", null,
                "NGUOI_CAP_NHAT", new IDConverter(),
                "NGAY_CAP_NHAT", null,
				"GHI_CHU", null,
                "THONG_BAO", null,
                "LCV_ID", new IDConverter(),	
                "BTD_ID", new IDConverter(),	
        };
        public static DANopBai Instance = new DANopBai();
        private DANopBai() : base() { }
        public void CheckDuplicateDIEM_THEO_DOI_NOP_BAI(GridView grid, DataSet GridDataSet, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            DataRow row = grid.GetDataRow(e.RowHandle);
            int count = 0;
            foreach (DataRow r in GridDataSet.Tables[0].Rows)
            {
                if (r.RowState != DataRowState.Deleted)
                {
                    if (r["NHAN_SU"].ToString() == row["NHAN_SU"].ToString() && r["NGUOI_GIAO"].ToString() == row["NGUOI_GIAO"].ToString() && r["NGAY_GIAO"].ToString() == row["NGAY_GIAO"].ToString())
                    {
                        if (grid.IsNewItemRow(grid.FocusedRowHandle))
                        {
                            r.RowError = "Dữ liệu bị trùng, xin vui lòng kiểm tra lại.";
                            grid.SetColumnError(grid.Columns["NHAN_SU"], "Nhân sự, người giao và ngày giao bị trùng, xin vui lòng kiểm tra lại.");
                            e.Valid = false;
                            return;
                        }
                        else
                        {
                            count++;
                            if (count == 2)
                            {
                                r.RowError = "Dữ liệu bị trùng, xin vui lòng kiểm tra lại.";
                                grid.SetColumnError(grid.Columns["NHAN_SU"], "Nhân sự, người giao và ngày giao bị trùng, xin vui lòng kiểm tra lại.");
                                e.Valid = false;
                                return;
                            }
                        }
                    }
                }
            }
        }
        public FieldNameCheck[] DIEM_THEO_DOI_NOP_BAI()
        {
            return new FieldNameCheck[] { 
                    new FieldNameCheck("NHAN_SU",
                        new CheckType[]{ CheckType.RequiredID },
                        new string[]{ ErrorMsgLib.errorRequired("Nhân sự")}, 
                        new object[]{ }),
                    new FieldNameCheck("HAN_NOP",
                        new CheckType[]{ CheckType.RequireDate },
                        new string[]{ ErrorMsgLib.errorRequired("Hạn nộp")}, 
                        new object[]{ }),
                    new FieldNameCheck("NGUOI_GIAO",
                        new CheckType[]{ CheckType.RequiredID },
                        new string[]{ ErrorMsgLib.errorRequired("Người giao")}, 
                        new object[]{ }),
                    new FieldNameCheck("NGAY_GIAO",
                        new CheckType[]{ CheckType.RequireDate },
                        new string[]{ ErrorMsgLib.errorRequired("Ngày giao")}, 
                        new object[]{ })
                };
        }
        public GridColumn[] InitColumnsNOP_BAI(GridView view)
        {
            GridColumn CotDTDNB_ID = XtraGridSupportExt.CreateGridColumn(view, "Điểm theo dõi ID", -1, 100);
            GridColumn CotHanNop = XtraGridSupportExt.CreateGridColumn(view, "Hạn nộp", 2, 100);

            GridColumn CotNgayNop = XtraGridSupportExt.CreateGridColumn(view, "Ngày nộp", 3, 100);
            CotNgayNop.OptionsColumn.AllowEdit = false;
            //cột file
            GridColumn CotTenTaiLieu = XtraGridSupportExt.CreateGridColumn(view, "Tài liệu", 4, 100);
            DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btnUpDown = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            CotTenTaiLieu.ColumnEdit =  btnUpDown;
            btnUpDown.MouseDown += new MouseEventHandler(btnUpDown_MouseDown);
            ContextMenu ctMenu = new ContextMenu();
            btnUpDown.ContextMenu = ctMenu;
            MenuItem ChonTaiLieu = new MenuItem("Chọn tài liệu", new EventHandler(MenuItemChon_Click), Shortcut.CtrlShiftC);
            ChonTaiLieu.Tag = view;
            MenuItem XemTaiLieu = new MenuItem("Xem tài liệu", new EventHandler(MenuItemXem_Click), Shortcut.CtrlShiftX);
            XemTaiLieu.Tag = view;
            btnUpDown.ContextMenu.MenuItems.Add(ChonTaiLieu);
            btnUpDown.ContextMenu.MenuItems.Add(XemTaiLieu);

            GridColumn CotNguoiGiao = XtraGridSupportExt.CreateGridColumn(view, "Người giao", 5, 100);
            GridColumn CotNgayGiao = XtraGridSupportExt.CreateGridColumn(view, "Ngày giao", 6, 100);
            GridColumn CotNguoiCapNhat = XtraGridSupportExt.CreateGridColumn(view, "Người cập nhật", 7, 100);
            CotNguoiCapNhat.OptionsColumn.AllowEdit = false;

            GridColumn CotNgayCapNhat = XtraGridSupportExt.CreateGridColumn(view, "Ngày cập nhật", 8, 100);
            CotNgayCapNhat.OptionsColumn.AllowEdit = false;

            GridColumn CotGhiChu = XtraGridSupportExt.CreateGridColumn(view, "Ghi chú", 9, 100);
            GridColumn CotThongBao = XtraGridSupportExt.CreateGridColumn(view, "Thông báo", 10, 100);

            XtraGridSupportExt.DateTimeGridColumn(CotHanNop, "HAN_NOP");
            XtraGridSupportExt.DateTimeGridColumn(CotNgayNop, "NGAY_NOP");

            //cột file
            XtraGridSupportExt.TextLeftColumn(CotTenTaiLieu, "TEN_TAI_LIEU");

            XtraGridSupportExt.IDGridColumn(CotNguoiGiao, "ID", "TEN_NV", "DM_NHAN_VIEN", "NGUOI_GIAO");
            XtraGridSupportExt.DateTimeGridColumn(CotNgayGiao, "NGAY_GIAO");
            XtraGridSupportExt.IDGridColumn(CotNguoiCapNhat, "ID", "TEN_NV", "DM_NHAN_VIEN", "NGUOI_CAP_NHAT");
            XtraGridSupportExt.DateTimeGridColumn(CotNgayCapNhat, "NGAY_CAP_NHAT");
            HelpGridColumn.CotMemoEdit(view, CotGhiChu, "GHI_CHU");
            HelpGridColumn.CotPLHienThi(CotThongBao, "THONG_BAO");

            view.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            view.Click += new EventHandler(view_Click);
            return null;
        }
        public void view_Click(object sender, EventArgs e)
        {
            GridView view = ((GridView)sender);
            //Lấy ra vị trí click của Muose trên gridview
            GridHitInfo gHitInfo = view.CalcHitInfo(view.GridControl.PointToClient(Control.MousePosition));
            if (gHitInfo.InRowCell || !view.OptionsBehavior.Editable)//Nếu vị trí click là cell trong row
            {
                if (gHitInfo.Column.FieldName == "TEN_TAI_LIEU")
                {
                    DataSet ds = HelpDB.getDatabase().LoadDataSet("select NOI_DUNG from DIEM_THEO_DOI_NOP_BAI where DTD_ID = " + HelpNumber.DecimalToInt64(view.GetDataRow(gHitInfo.RowHandle)["DTD_ID"].ToString()));
                    if(ds.Tables.Count <= 0) return;
                    object o = ds.Tables[0].Rows[0]["NOI_DUNG"];
                    if (o != null)
                        if( o != System.DBNull.Value)
                            DANopBai.Instance.openSaveFile(gHitInfo, view, null, (byte[])o);
                }
            }
        }
        public void btnUpDown_MouseDown(object sender, MouseEventArgs e)
        {
            ((ButtonEdit)sender).ContextMenu.Show(((ButtonEdit)sender), new Point(e.X, e.Y));
        }
        public void MenuItemChon_Click(object sender, EventArgs e)
        {
            GridView view = (GridView)((MenuItem)sender).Tag;
            DANopBai.Instance.UpData(view);
        }
        public void MenuItemXem_Click(object sender, EventArgs e)
        {
            GridView view = (GridView)((MenuItem)sender).Tag;
            if (view.IsNewItemRow(view.FocusedRowHandle)) return;
            string fileName = view.GetRowCellValue(view.FocusedRowHandle, view.Columns["TEN_TAI_LIEU"]).ToString();
            if(fileName == "") return;
            HelpFile.OpenFile(FrameworkParams.TEMP_FOLDER + @"\" + fileName);
        }
        public void processTEN_TAI_LIEU(GridHitInfo gHitInfo, GridView view, bool? IsAdd, DataSet GridDataSet)
        {
            if (gHitInfo.Column.FieldName == "TEN_TAI_LIEU")
            {
                if (IsAdd != null)
                {
                    if (view.IsNewItemRow(view.FocusedRowHandle))
                        DANopBai.Instance.UpData(view);
                    else DANopBai.Instance.UpdateData(view);
                }
                else
                {
                    object o = HelpDB.getDatabase().LoadDataSet("select NOI_DUNG from " + GridDataSet.Tables[0].TableName.Trim() + " where DTD_ID = " + HelpNumber.ParseInt64(view.GetDataRow(view.FocusedRowHandle)["DTD_ID"].ToString())).Tables[0].Rows[0]["NOI_DUNG"];
                    DANopBai.Instance.openSaveFile(gHitInfo, view, null, (o == System.DBNull.Value ? null : (byte[])o));
                }
            }
        }
        //Nghiên cứu
        public void UpData(GridView view)
        {
            string path = null;
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Title = "Chọn file để cập nhật tài liệu:";
            DialogResult value = openFile.ShowDialog();
            if (value == DialogResult.OK)
            {
                path = openFile.FileName;
                //Kiểm tra độ lớn của file
                if (!HelpFile.CheckFileSize(path, 20))
                {
                    //Độ lớn của file lớn hơn độ lớn qui định
                    HelpMsgBox.ShowNotificationMessage("Bạn không được chọn file lớn hơn 20 MB.");
                    path = null;
                    UpData(view);
                }
            }
            else if (value == DialogResult.Cancel)
            {
                path = null;
                return;
            }

            Thread.Sleep(200);
            if (path != null)
            {
                byte[] bytes = null;
                bytes = HelpFile.FileToBytes(path);
                DataRow row = view.GetDataRow(view.FocusedRowHandle);
                if (row == null) HelpMsgBox.ShowNotificationMessage("Bạn chưa chọn nhân sự, vui lòng vào thông tin nhân sự!");
                else
                {
                    row["TEN_TAI_LIEU"] = Path.GetFileName(path);
                    row["NOI_DUNG"] = bytes;
                    row["NGAY_NOP"] = DateTime.Now;
                }
            }
        }
        public void UpdateData(GridView view)
        {
            if (HelpMsgBox.ShowConfirmMessage("Bạn có muốn cập nhật lại tài liệu không?") == DialogResult.Yes)
                UpData(view);
            else return;
        }
        public void openSaveFile(GridHitInfo gHitInfo, GridView view, string path, byte[] bytes)
        {
            if (HelpMsgBox.ShowConfirmMessage("Bạn có muốn lưu lại tài liệu không?") == DialogResult.Yes)
            {
                SaveFileDialog saveFile = new SaveFileDialog();
                //Cấu hình các thuộc tính cho saveFile
                saveFile.InitialDirectory = FrameworkParams.TEMP_FOLDER;
                saveFile.Title = "Chọn thư mục để lưu file:";
                //Lấy kiểu file
                string[] typeFile = Path.GetFileName(view.GetRowCellValue(gHitInfo.RowHandle, gHitInfo.Column).ToString()).Split(new char[] { '.' });
                saveFile.Filter = "File type " + typeFile.GetValue(typeFile.Length - 1).ToString()
                    + "(*." + typeFile.GetValue(typeFile.Length - 1).ToString() + ")" + "|*."
                    + typeFile.GetValue(typeFile.Length - 1).ToString();
                saveFile.FileName = FrameworkParams.TEMP_FOLDER + @"\" + typeFile.GetValue(typeFile.Length - 2).ToString();
                if (saveFile.ShowDialog() == DialogResult.OK)
                {
                    path = saveFile.FileName;
                }
                Thread.Sleep(200);
            }
            if (path != null)
            {
                if (!HelpFile.BytesToFile(bytes, path))
                {
                    if (HelpFile.BytesToFile(bytes, FrameworkParams.TEMP_FOLDER + @"\" + view.GetRowCellValue(gHitInfo.RowHandle, gHitInfo.Column).ToString()))
                        HelpFile.OpenFile(FrameworkParams.TEMP_FOLDER + @"\" + view.GetRowCellValue(gHitInfo.RowHandle, gHitInfo.Column).ToString());
                    HelpMsgBox.ShowNotificationMessage("Không lưu được file.");
                }
                else
                    HelpFile.OpenFile(path);
            }
            else
            {
                if (HelpFile.BytesToFile(bytes, FrameworkParams.TEMP_FOLDER + @"\" + view.GetRowCellValue(gHitInfo.RowHandle, gHitInfo.Column).ToString()))
                    HelpFile.OpenFile(FrameworkParams.TEMP_FOLDER + @"\" + view.GetRowCellValue(gHitInfo.RowHandle, gHitInfo.Column).ToString());
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ProtocolVN.Framework.Win;
using System.IO;
using ProtocolVN.Framework.Core;
using DAO;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.Utils;

namespace office
{
    public partial class PLMultiChoiceFiles : DevExpress.XtraEditors.XtraUserControl
    {
        private bool? IsAdd;
        private bool IsShowImageFax = false;
        private OpenFileDialog ChoiceFileDialog;
        private int MaxFileSize;
        string FieldTenFile;
        string FieldNoiDung;
        public delegate void EventButtonAddClick(object sender, EventArgs e);
        public event EventButtonAddClick ButtonAddClick;
        
        //string FieldNguoiCapNhat;
        //string FieldNgayCapNhat;
        //string FieldGhiChu;
        public PLMultiChoiceFiles()
        {
            InitializeComponent();
        }
        //public void _Init(bool? IsAdd,  string FieldTenFile, string FieldNoiDung, string FieldNguoiCapNhat, string FieldNgayCapNhat, string FieldGhiChu, int MaxFileSize)
        private GridColumn CotPLDong(DevExpress.XtraGrid.GridControl GridCtrl,
            DevExpress.XtraGrid.Views.Grid.GridView Grid)
        {
            RepositoryItemButtonEdit edit = new RepositoryItemButtonEdit();
            edit.AutoHeight = false;
            edit.BorderStyle = BorderStyles.Default;
            edit.Buttons.AddRange(new EditorButton[] { 
                new EditorButton(ButtonPredefines.Delete, "", 10, true, true, false,HorzAlignment.Center, null,
                    new KeyShortcut(Keys.Control | Keys.Delete)) });
            edit.Name = "repositoryItemButtonEditDEL";
            edit.TextEditStyle = TextEditStyles.HideTextEditor;
            edit.Click += delegate(object sender, EventArgs e)
            {
                XtraMessageBoxForm frm = new XtraMessageBoxForm();
                DialogResult dr = frm.ShowMessageBoxDialog(new XtraMessageBoxArgs(null,
                        popupContainerControl1, "Bạn có chấp nhận xóa dòng này không?", "Xác nhận",
                        new DialogResult[] { DialogResult.Yes, DialogResult.No },
                   SystemIcons.Question, 1));
                if (dr == DialogResult.Yes)
                {
                    Grid.DeleteRow(Grid.FocusedRowHandle);
                }
            };
            GridCtrl.RepositoryItems.Add(edit);
            DevExpress.XtraGrid.Columns.GridColumn column = new GridColumn();
            column.AppearanceHeader.Options.UseTextOptions = true;
            column.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            column.AppearanceCell.Options.UseTextOptions = true;
            column.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            column.Caption = "    ";
            column.ColumnEdit = edit;
            column.Name = "CotXoa";
            column.OptionsColumn.AllowSize = false;
            column.OptionsColumn.FixedWidth = true;
            column.Visible = true;
            column.VisibleIndex = 50;
            column.Width = 25;
            Grid.Columns.Add(column);
            return column;
        }

 

        public void _Init(bool? IsAdd, string FieldTenFile, string FieldNoiDung, int MaxFileSize, params bool[] ShowImageFax)
        {
            this.IsAdd = IsAdd;
            this.MaxFileSize = MaxFileSize;

            this.FieldTenFile = FieldTenFile;
            this.FieldNoiDung = FieldNoiDung;
            //this.FieldNguoiCapNhat = (FieldNguoiCapNhat == null ? "" : FieldNguoiCapNhat);
            //this.FieldNgayCapNhat = (FieldNgayCapNhat == null ? "" : FieldNgayCapNhat);
            //this.FieldGhiChu = (FieldGhiChu == null ? "" : FieldGhiChu);


            ChoiceFileDialog = new OpenFileDialog();
            ChoiceFileDialog.Filter = "Tất cả tập tin (*.*)|*.*";
            ChoiceFileDialog.Title = "Chọn tập tin đính kèm";
            ChoiceFileDialog.Multiselect = true;



            if (IsAdd != null)
            {
                CotPLDong(gridControlListFiles, gridViewListFiles);
            }
            else
            {
                ColFileName.OptionsColumn.AllowEdit = false;
                foreach (EditorButton b in popupContainerEdit1.Properties.Buttons)
                {
                    if (b.Tag == null) continue;
                    if (b.Tag.ToString() == "ADD_FILE")
                    {
                        b.Visible = false;
                        break;
                    }
                }
            }
            //In case show image fax.
            if (ShowImageFax.Length > 0) {
                IsShowImageFax = true;
                ColFax.Visible = true;
            }
                
                
            //----------------------------------------------------------

            //if (FieldNguoiCapNhat == "" || FieldNguoiCapNhat == null)
            //{
            //    ColNguoiCapNhat.Visible = false;
            //    ColNguoiCapNhat.OptionsColumn.AllowShowHide = false;
            //}
            //else ProtocolVN.DanhMuc.DMFWNhanVien.I.InitCot(ColNguoiCapNhat, FieldNguoiCapNhat);

            //if (FieldNgayCapNhat == "" || FieldNgayCapNhat == null)
            //{
            //    ColNgayCapNhat.Visible = false;
            //    ColNgayCapNhat.OptionsColumn.AllowSize = false;

            //}
            //else HelpGridColumn.CotDateEdit(ColNgayCapNhat, FieldNgayCapNhat, FrameworkParams.option.DateTimeFomat);

            //if (FieldGhiChu == "" || FieldGhiChu == null)
            //{
            //    ColGhiChu.Visible = false;
            //    ColGhiChu.OptionsColumn.AllowShowHide = false;
            //}
            //else HelpGridColumn.CotMemoExEdit(ColGhiChu, FieldGhiChu);

            HelpGridColumn.CotDBFile(ColFileName, FieldTenFile, FieldNoiDung, ChoiceFileDialog.Filter, ChoiceFileDialog.Title, MaxFileSize);
            gridViewListFiles.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
            gridViewListFiles.OptionsView.ShowIndicator = false;
            gridViewListFiles.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(gridViewListFiles_CellValueChanged);
            gridViewListFiles.RowCountChanged += new EventHandler(gridViewListFiles_RowCountChanged);
            gridViewListFiles.OptionsView.ColumnAutoWidth = true;
        }

        private void gridViewListFiles_RowCountChanged(object sender, EventArgs e)
        {
            UpdateText();
        }

        private void gridViewListFiles_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.Name == ColFileName.Name)
            {
                UpdateText();
                //if (FieldNguoiCapNhat != "")
                //    gridViewListFiles.SetRowCellValue(e.RowHandle, ColNguoiCapNhat, FrameworkParams.currentUser.employee_id);
                //if (FieldNgayCapNhat != "")
                //    gridViewListFiles.SetRowCellValue(e.RowHandle, ColNgayCapNhat, HelpDB.getDatabase().GetSystemCurrentDateTime());
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="IsAdd"></param>
        /// <param name="ShowImageFax">Shows an image fax for each row.</param>
        public void _Init(bool? IsAdd,params bool[] ShowImageFax)
        {
            //_Init(IsAdd, "TEN_FILE", "NOI_DUNG", "NGUOI_CAP_NHAT", "NGAY_CAP_NHAT", "GHI_CHU", -1);
            _Init(IsAdd, "TEN_FILE", "NOI_DUNG", -1, ShowImageFax);
        }
        public void _Init(bool? IsAdd, int MaxFileSize)
        {
            //_Init(IsAdd, "TEN_FILE", "NOI_DUNG", "NGUOI_CAP_NHAT", "NGAY_CAP_NHAT", "GHI_CHU", MaxFileSize);
            _Init(IsAdd, "TEN_FILE", "NOI_DUNG", MaxFileSize);
        }
        //public void _Init(bool? IsAdd, string FieldTenFile, string FieldNoiDung, int MaxFileSize)
        //{
        //    _Init(IsAdd, FieldTenFile, FieldNoiDung, "", "", "", MaxFileSize);
        //}
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DataSet _DataSource
        {
            get
            {
                DataTable dt = this.gridControlListFiles.DataSource as DataTable;
                if (dt == null) return null;
                if (dt.DataSet != null) return dt.DataSet;
                else
                {
                    DataSet ds = new DataSet();
                    ds.Tables.Add(dt);
                    return ds;
                }
            }
            set
            {
                if (value != null && value.Tables.Count > 0) {
                    this.gridControlListFiles.DataSource = value.Tables[0];
                }
                    
            }
        }

        private void popupContainerEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Tag.ToString() == "ADD_FILE")
            {
                if (ButtonAddClick == null)
                {
                    bool showPopup = popupContainerEdit1.IsPopupOpen;
                    popupContainerEdit1.ClosePopup();
                    DialogResult dr = ChoiceFileDialog.ShowDialog(this);
                    if (showPopup)
                    {
                        popupContainerEdit1.ShowPopup();
                    }
                    if (dr == DialogResult.Cancel)
                    {
                        return;
                    }

                    DataTable dtSource = gridControlListFiles.DataSource as DataTable;
                    if (IsShowImageFax && !dtSource.Columns.Contains("IMAGE"))
                    {
                        dtSource.Columns.Add("IMAGE", typeof(Image));
                        ColFax.VisibleIndex = 0;
                    }
                    DateTime crTime = HelpDB.getDatabase().GetSystemCurrentDateTime();

                    List<DataRow> rows = new List<DataRow>();
                    foreach (string fName in ChoiceFileDialog.FileNames)
                    {
                        if (MaxFileSize > 0 && HelpFile.CheckFileSize(fName, MaxFileSize) == false)
                        {
                            HelpMsgBox.ShowNotificationMessage(string.Format("Kích thước tập tin không được vược quá {0} MB!", MaxFileSize));
                            break;
                        }
                        else
                        {
                            DataRow row = dtSource.NewRow();
                            row[FieldTenFile] = Path.GetFileName(fName);
                            row[FieldNoiDung] = HelpFile.FileToBytes(fName);
                            if (IsShowImageFax) row["IMAGE"] = FWImageDic.PRINT_IMAGE20;
                            //if (FieldNguoiCapNhat != "")
                            //    row[FieldNguoiCapNhat] = FrameworkParams.currentUser.employee_id;
                            //if (FieldNgayCapNhat != "")
                            //    row[FieldNgayCapNhat] = crTime;
                            rows.Add(row);
                        }
                    }
                    foreach (DataRow r in rows)
                    {
                        dtSource.Rows.Add(r);
                    }
                    // if (showPopup) popupContainerEdit1.ShowPopup();
                }
                else
                {
                    ButtonAddClick(e, new EventArgs());
                }
            }
            else if (e.Button.Tag.ToString() == "SHOW_POPUP")
            {
                gridViewListFiles.OptionsView.ColumnAutoWidth = true;
                if (popupContainerEdit1.IsPopupOpen)
                    popupContainerEdit1.ClosePopup();
                else popupContainerEdit1.ShowPopup();
                if (IsShowImageFax) {
                    DataTable dtSource = this.gridControlListFiles.DataSource as DataTable;
                    ColFax.MaxWidth = 45;
                    if (!dtSource.Columns.Contains("IMAGE")) {
                        dtSource.Columns.Add("IMAGE", typeof(Image));
                        foreach (DataRow row in dtSource.Rows) row["IMAGE"] = FWImageDic.PRINT_IMAGE20;
                    }
                }
            }
        }

        private void UpdateText()
        {
            DataTable dt = gridControlListFiles.DataSource as DataTable;
            string fNs = "";
            foreach (DataRow row in dt.Rows)
            {
                if (row.RowState == DataRowState.Deleted || row.RowState == DataRowState.Detached) continue;
                fNs += row[FieldTenFile].ToString() + "; ";
            }
            popupContainerEdit1.Text = fNs.TrimEnd(' ', ';');
        }
    }
}

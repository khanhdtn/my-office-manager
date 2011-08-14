using System;
using System.Windows.Forms;
using ProtocolVN.Framework.Win;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraTreeList;
using DAO;
using ProtocolVN.Framework.Core;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraEditors.Controls;
using pl.office.DanhMuc;

namespace pl.office.form
{
    public partial class frmDocument : XtraFormPL
    {
        #region Vùng đặt Static
        public static FormStatus Status = FormStatus.NC;
        public static string MenuItem(string ParentID, bool IsSep)
        {
            return MenuBuilder.CreateItem(typeof(frmDocument).FullName,
                PMSupport.UpdateTitle("Quản lý tài liệu", Status),
                ParentID, true,
                typeof(frmDocument).FullName,
                true, IsSep, "mnbHSoUngVien.png", true, "", "");
        }
        #endregion

        #region Khai báo biến
        private bool? _IsAdd;        
        private CotFile cotFile;
        #endregion

        #region Hàm dựng

        public frmDocument()
        {
            InitializeComponent();
            barButtonItemThem.Glyph = FWImageDic.ADD_IMAGE20;
            barButtonItemSua.Glyph = FWImageDic.EDIT_IMAGE20;
            barButtonItemXoa.Glyph = FWImageDic.DELETE_IMAGE20;
            barButtonItemLuu.Glyph = FWImageDic.SAVE_IMAGE20;
            barButtonItemKLuu.Glyph = FWImageDic.UNCOMMIT_IMAGE20;
            #region Khai báo sự kiện trên lưới
            this.grdThongtinTL.btnAdd.Click += new System.EventHandler(btnAdd_Click);
            this.grdThongtinTL.btnAdd.MouseDown += new System.Windows.Forms.MouseEventHandler(btnAdd_MouseDown);
            this.grdThongtinTL.btnDel.MouseDown += new System.Windows.Forms.MouseEventHandler(btnDel_MouseDown);
            this.grdThongtinTL.btnUpdate.MouseDown += new System.Windows.Forms.MouseEventHandler(btnUpdate_MouseDown);
            this.grdThongtinTL.btnSave.Click += new EventHandler(btnSave_Click);
            this.grdThongtinTL.btnNoSave.Click += new EventHandler(btnNoSave_Click);
            this.grdThongtinTL.btnNoSave.EnabledChanged += new EventHandler(btnNoSave_EnabledChanged);
            this.LoaiTaiLieu.TreeList_1.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(TreeList_1_FocusedNodeChanged);
            grdThongtinTL.Grid.LostFocus += new EventHandler(Grid_LostFocus);
            grdThongtinTL.Grid.DoubleClick += new EventHandler(Grid_DoubleClick);
            grdThongtinTL.Grid.ValidateRow += new ValidateRowEventHandler(Grid_ValidateRow);
            grdThongtinTL.Grid.InvalidRowException += new InvalidRowExceptionEventHandler(Grid_InvalidRowException);
            #endregion
            grdThongtinTL._init(GroupElementType.ONLY_INPUT,
                "DM_TAI_LIEU", "ID", "TEN_TAI_LIEU", new string[] { "TEN_TAI_LIEU" }, new string[] { "Tên tài liệu" },
                DMTaiLieu.CreateDM_TAI_LIEU,null, null, null);
            grdThongtinTL.btnClose.Visible = false;
            
            cotFile = CotFile.Init(grdThongtinTL.Grid,
                XtraGridSupportExt.CreateGridColumn(grdThongtinTL.Grid, "Tên file", 1, 150), "DM_NOI_DUNG_TAI_LIEU", "DATA_ID", 20);
            
            
        }

        #endregion

        #region InitForm

        private void frmTailieu_Load(object sender, EventArgs e)
        {
            PMSupport.SetTitle(this, Status);
            ChonLoaiTaiLieu(LoaiTaiLieu);
        }

        #endregion

        #region Invalidate

        public void ChonLoaiTaiLieu(DMTreeGroup Input)
        {
            Input.Init(GroupElementType.ONLY_INPUT, "DM_LOAI_TAI_LIEU", "ID", "PARENT_ID",
                              new string[] { "NAME" }, new string[] { "Loại tài liệu" }, null, null, null
                             );
            Input.btnClose.Visible = false;
        }
        
        #endregion

        #region Validate

        private void Grid_ValidateRow(object sender, ValidateRowEventArgs e)
        {
            ColumnView clview = (ColumnView)sender;
            GridColumn clTentailieu = clview.Columns["TEN_TAI_LIEU"];
            GridColumn clTenfile = clview.Columns["DATA_ID"];
            e.Valid = true;
            if (clview.GetRowCellValue(e.RowHandle, clTentailieu).ToString() == "")
            {
                e.Valid = false;
                clview.SetColumnError(clTentailieu, "Vui lòng vào thông tin 'Tên tài liệu'.");
            }
            if (clview.GetRowCellValue(e.RowHandle, clTenfile).ToString() == "")
            {
                e.Valid = false;
                clview.SetColumnError(clTenfile, "Vui lòng chọn 'Tên file'.");
            }
            if (this.cotFile._currentDONoiDungTaiLieu == null)
            {
                e.Valid = false;
                clview.SetColumnError(clTenfile, "Vui lòng chọn 'Tên file'.");
            }
            if (e.Valid == true)
            {
                //DOTaiLieu _doTailieu = null;
                //if (this._IsAdd == true)
                //{
                //    _doTailieu = new DOTaiLieu(HelpNumber.ParseInt64(grdThongtinTL.Grid.GetRowCellValue(grdThongtinTL.Grid.FocusedRowHandle, grdThongtinTL.Grid.Columns["ID"]).ToString()),
                //                                    grdThongtinTL.Grid.GetRowCellValue(grdThongtinTL.Grid.FocusedRowHandle, grdThongtinTL.Grid.Columns["TEN_TAI_LIEU"]).ToString(),
                //                                    grdThongtinTL.Grid.GetRowCellValue(grdThongtinTL.Grid.FocusedRowHandle, grdThongtinTL.Grid.Columns["PHIEN_BAN"]).ToString(),
                //                                    grdThongtinTL.Grid.GetRowCellValue(grdThongtinTL.Grid.FocusedRowHandle, grdThongtinTL.Grid.Columns["MO_TA"]).ToString(),
                //                                    HelpNumber.ParseInt64(grdThongtinTL.Grid.GetRowCellValue(grdThongtinTL.Grid.FocusedRowHandle, grdThongtinTL.Grid.Columns["LOAI_TAI_LIEU_ID"]).ToString()),
                //                                    "Y",
                //                                    FrameworkParams.currentUser.employee_id, DateTime.Now, FrameworkParams.currentUser.employee_id, DateTime.Now, this.cotFile._currentDONoiDungTaiLieu.ID);
                //    DMTaiLieu.setRowCellDefaultValue(grdThongtinTL.Grid.GetDataRow(grdThongtinTL.Grid.FocusedRowHandle), _doTailieu);
                //    cotFile.Insert();
                //}
                //else if (this._IsAdd == false)
                //{
                //    _doTailieu = new DOTaiLieu(HelpNumber.ParseInt64(grdThongtinTL.Grid.GetRowCellValue(grdThongtinTL.Grid.FocusedRowHandle, grdThongtinTL.Grid.Columns["ID"]).ToString()),
                //                                    grdThongtinTL.Grid.GetRowCellValue(grdThongtinTL.Grid.FocusedRowHandle, grdThongtinTL.Grid.Columns["TEN_TAI_LIEU"]).ToString(),
                //                                    grdThongtinTL.Grid.GetRowCellValue(grdThongtinTL.Grid.FocusedRowHandle, grdThongtinTL.Grid.Columns["PHIEN_BAN"]).ToString(),
                //                                    grdThongtinTL.Grid.GetRowCellValue(grdThongtinTL.Grid.FocusedRowHandle, grdThongtinTL.Grid.Columns["MO_TA"]).ToString(),
                //                                    HelpNumber.ParseInt64(grdThongtinTL.Grid.GetRowCellValue(grdThongtinTL.Grid.FocusedRowHandle, grdThongtinTL.Grid.Columns["LOAI_TAI_LIEU_ID"]).ToString()),
                //                                    "Y",
                //                                    HelpNumber.ParseInt64(grdThongtinTL.Grid.GetRowCellValue(grdThongtinTL.Grid.FocusedRowHandle, grdThongtinTL.Grid.Columns["NGUOI_GUI"]).ToString()),
                //                                    Convert.ToDateTime(grdThongtinTL.Grid.GetRowCellValue(grdThongtinTL.Grid.FocusedRowHandle, grdThongtinTL.Grid.Columns["NGAY_GUI"]).ToString()),
                //                                    FrameworkParams.currentUser.employee_id, DateTime.Now, this.cotFile._currentDONoiDungTaiLieu.ID);
                //    DMTaiLieu.setRowCellDefaultValue(grdThongtinTL.Grid.GetDataRow(grdThongtinTL.Grid.FocusedRowHandle), _doTailieu);
                //    cotFile.Update();
                //}
            }
        }

        private void Grid_InvalidRowException(object sender, InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.ThrowException;
        }

        #endregion

        #region Xử lý nút

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (LoaiTaiLieu.TreeList_1.Nodes.Count == 0)
            {
                grdThongtinTL.Grid.CancelUpdateCurrentRow();
                PLMessageBox.ShowNotificationMessage("Bạn cần phải thêm loại tài liệu trước.");
            }
            else
            {
                DMTaiLieu.addChildRow(grdThongtinTL.Grid, HelpNumber.ParseInt32(LoaiTaiLieu.TreeList_1.FocusedNode.GetValue(0)));
            }
        }

        private void btnAdd_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this._IsAdd = true;
                this.grdThongtinTL.btnAdd.Click += new EventHandler(btnAdd_Click);
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            cotFile.Delete();
        }

        private void btnDel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (grdThongtinTL.Grid.RowCount == 0)
                {
                    PLMessageBox.ShowNotificationMessage("Không có tài liệu để xóa, xin vui lòng chọn lại.");
                    this.grdThongtinTL.btnDel.Click -= new System.EventHandler(btnDel_Click);
                }
                else if (grdThongtinTL.Grid.IsGroupRow(grdThongtinTL.Grid.FocusedRowHandle))
                {
                    PLMessageBox.ShowNotificationMessage("Bạn chưa chọn tài liệu để xóa, xin vui lòng chọn lại.");
                    this.grdThongtinTL.btnDel.Click -= new System.EventHandler(btnDel_Click);
                }
                else
                {
                    this.grdThongtinTL.btnDel.Click += new System.EventHandler(btnDel_Click);
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e){}

        private void btnUpdate_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (grdThongtinTL.Grid.RowCount == 0)
                {
                    PLMessageBox.ShowNotificationMessage("Không có tài liệu để cập nhật, xin vui lòng chọn lại.");
                    this.grdThongtinTL.btnUpdate.Click -= new System.EventHandler(btnUpdate_Click);
                }
                else if (grdThongtinTL.Grid.IsGroupRow(grdThongtinTL.Grid.FocusedRowHandle))
                {
                    PLMessageBox.ShowNotificationMessage("Bạn chưa chọn tài liệu cập nhật, xin vui lòng chọn lại.");
                    this.grdThongtinTL.btnUpdate.Click -= new System.EventHandler(btnUpdate_Click);
                }
                else
                {
                    this._IsAdd = false;
                    this.grdThongtinTL.btnUpdate.Click += new System.EventHandler(btnUpdate_Click);
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DMTaiLieu.returnRowUpdate(grdThongtinTL.Grid, grdThongtinTL.Grid.GetRow(grdThongtinTL.Grid.FocusedRowHandle));
        }

        private void btnNoSave_Click(object sender, EventArgs e)
        {
            #region Ẩn hiện cột
            this.grdThongtinTL.btnAdd.Enabled = true;
            this.grdThongtinTL.btnDel.Enabled = true;
            this.grdThongtinTL.btnUpdate.Enabled = true;
            this.grdThongtinTL.btnSave.Enabled = false;
            this.grdThongtinTL.btnNoSave.Enabled = false;
            #endregion
        }

        private void btnNoSave_EnabledChanged(object sender, EventArgs e)
        {
            if (grdThongtinTL.btnNoSave.Enabled == false && grdThongtinTL.Grid.IsNewItemRow(grdThongtinTL.Grid.FocusedRowHandle))
            {
                grdThongtinTL.Grid.CancelUpdateCurrentRow();
            }
        }

        #endregion

        #region DataProcess
        private void TreeList_1_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {
            if (e.Node == null)
            {
                return;
            }
            else if (e.Node.ParentNode == null)
                grdThongtinTL.Grid.GridControl.DataSource = DADocument.getDM_TAI_LIEU();
            else
                grdThongtinTL.Grid.GridControl.DataSource = DADocument.getDM_TAI_LIEU(HelpNumber.ParseInt64(e.Node.GetValue(0)));

            if (grdThongtinTL.Grid.RowCount > 0)
                grdThongtinTL.Grid.ExpandAllGroups();
        }

        private void Grid_DoubleClick(object sender, EventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.GridView view = (DevExpress.XtraGrid.Views.Grid.GridView)sender;
            if (view.IsGroupRow(view.FocusedRowHandle))
                btnNoSave_Click(sender, e);
            else
            {
                this._IsAdd = false;
            }
        }

        private void Grid_LostFocus(object sender, EventArgs e)
        {
            if (grdThongtinTL.Grid.IsNewItemRow(grdThongtinTL.Grid.FocusedRowHandle))
            {
                //show thông báo thì không lỗi
                //cần suy nghĩ tiếp
            }
        }

        #endregion
       
    }
}
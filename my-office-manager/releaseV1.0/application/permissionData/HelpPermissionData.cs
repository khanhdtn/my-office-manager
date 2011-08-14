using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ProtocolVN.Framework.Core;
using ProtocolVN.Framework.Win;
using System.Windows.Forms;
using DevExpress.XtraTreeList.Nodes;

namespace PermissionOfResource.Running
{
    /// <summary>
    /// Khanhdtn: Lớp thực thi phân quyền trên tài nguyên (cập nhật theo PL-Office)
    /// </summary>
    public class HelpPermissionData
    {

        #region Check Permission

        /// <summary>
        /// Kiểm tra người dùng hiện hành có quyền trên 1 tài nguyên cụ thể hay không.
        /// </summary>
        /// <param name="ResID">ID tài nguyên</param>
        /// <param name="per_type">Loại quyền</param>
        /// <returns></returns>
        public static bool CheckPermissionRes(long ResourceTypeID, long ResID, RES_PERMISSION_TYPE per_type)
        {
            DataPermission data = GetDataPermission(ResourceTypeID);
            return data._checkPermissionRes(ResID, per_type);
        }

        /// <summary>
        /// Kiểm tra người dùng chỉ định có quyền trên 1 tài nguyên cụ thể hay không.
        /// </summary>
        /// <param name="UserID">ID người dùng</param>
        /// <param name="ResID">ID tài nguyên</param>
        /// <param name="per_type">Loại quyền</param>
        /// <returns></returns>
        public static bool CheckPermissionRes(long ResourceTypeID, long Employee_ID, long ResID, RES_PERMISSION_TYPE per_type)
        {
            DataPermission data = GetDataPermission(ResourceTypeID);
            return data._checkPermissionRes(Employee_ID, ResID, per_type);
        }

        /// <summary>
        /// Kiểm tra người dùng hiện hành có quyền trên 1 nhóm tài nguyên cụ thể hay không.
        /// </summary>
        /// <param name="ResGroupID">ID nhóm tài nguyên</param>
        /// <param name="per_type">Loại quyền</param>
        /// <returns></returns>
        public static bool CheckPermissionResGroup(long ResourceTypeID, long ResGroupID, RES_PERMISSION_TYPE per_type)
        {
            DataPermission data = GetDataPermission(ResourceTypeID);
            return data._checkPermissionResGroup(ResGroupID, per_type);
        }

        /// <summary>
        /// Kiểm tra người dùng chỉ định có quyền trên 1 nhóm tài nguyên cụ thể hay không.
        /// </summary>
        /// <param name="UserID">ID người dùng</param>
        /// <param name="ResGroupID">ID nhóm tài nguyên</param>
        /// <param name="per_type">Loại quyền</param>
        /// <returns></returns>
        public static bool CheckPermissionResGroup(long ResourceTypeID, long Employee_ID, long ResGroupID, RES_PERMISSION_TYPE per_type)
        {
            DataPermission data = GetDataPermission(ResourceTypeID);
            return data._checkPermissionResGroup(Employee_ID, ResGroupID, per_type);
        }
        #endregion

        #region Get Permission IDs

        /// <summary>
        /// Trả về danh sách tài nguyên theo ID mà người dùng hiện hành có quyền.
        /// </summary>
        /// <param name="per_type">Loại quyền</param>
        /// <returns></returns>
        public static long[] GetPermissionResIDs(long ResourceTypeID, RES_PERMISSION_TYPE per_type)
        {
            DataPermission data = GetDataPermission(ResourceTypeID);
            return data._getPermissionResIDs(per_type);
        }

        /// <summary>
        /// Trả về chuỗi danh sách tài nguyên theo ID mà người dùng hiện hành có quyền.
        /// </summary>
        /// <param name="per_type">Loại quyền</param>
        /// <returns></returns>
        public static string GetPermissionResStrIDs(long ResourceTypeID, RES_PERMISSION_TYPE per_type)
        {
            DataPermission data = GetDataPermission(ResourceTypeID);
            return data._getPermissionResStrIDs(per_type);
        }

        /// <summary>
        /// Trả về danh sách tài nguyên theo ID mà người dùng chỉ định có quyền.
        /// </summary>
        /// <param name="UserID">ID người dùng</param>
        /// <param name="per_type">Loại quyền</param>
        /// <returns></returns>
        public static long[] GetPermissionResIDs(long ResourceTypeID, long Employee_ID, RES_PERMISSION_TYPE per_type)
        {
            DataPermission data = GetDataPermission(ResourceTypeID);
            return data._getPermissionResIDs(Employee_ID, per_type);
        }

        /// <summary>
        /// Trả về chuỗi danh sách tài nguyên theo ID mà người dùng chỉ định có quyền.
        /// </summary>
        /// <param name="UserID">ID người dùng</param>
        /// <param name="per_type">Loại quyền</param>
        /// <returns></returns>
        public string GetPermissionResStrIDs(long ResourceTypeID, long Employee_ID, RES_PERMISSION_TYPE per_type)
        {
            DataPermission data = GetDataPermission(ResourceTypeID);
            return data._getPermissionResStrIDs(Employee_ID, per_type);
        }

        /// <summary>
        /// Trả về danh sách nhóm tài nguyên theo ID mà người dùng hiện hành có quyền.
        /// </summary>
        /// <param name="per_type">Loại quyền</param>
        /// <returns></returns>
        public static long[] GetPermissionResGroupIDs(long ResourceTypeID, RES_PERMISSION_TYPE per_type)
        {
            DataPermission data = GetDataPermission(ResourceTypeID);
            return data._getPermissionResGroupIDs(per_type);
        }

        /// <summary>
        /// Trả về chuỗi danh sách nhóm tài nguyên theo ID mà người dùng hiện hành có quyền.
        /// </summary>
        /// <param name="per_type">Loại quyền</param>
        /// <returns></returns>
        public static string GetPermissionResGroupStrIDs(long ResourceTypeID, RES_PERMISSION_TYPE per_type)
        {
            DataPermission data = GetDataPermission(ResourceTypeID);
            return data._getPermissionResGroupStrIDs(per_type);
        }

        /// <summary>
        /// Trả về danh sách nhóm tài nguyên theo ID mà người dùng chỉ định có quyền.
        /// </summary>
        /// <param name="UserID">ID người dùng</param>
        /// <param name="per_type">Loại quyền</param>
        /// <returns></returns>
        public static long[] GetPermissionResGroupIDs(long ResourceTypeID, long Employee_ID, RES_PERMISSION_TYPE per_type)
        {
            DataPermission data = GetDataPermission(ResourceTypeID);
            return data._getPermissionResGroupIDs(Employee_ID, per_type);
        }

        /// <summary>
        /// Trả về chuỗi danh sách nhóm tài nguyên theo ID mà người dùng chỉ định có quyền.
        /// </summary>
        /// <param name="UserID">ID người dùng</param>
        /// <param name="per_type">Loại quyền</param>
        /// <returns></returns>
        public static string GetPermissionResGroupStrIDs(long ResourceTypeID, long Employee_ID, RES_PERMISSION_TYPE per_type)
        {
            DataPermission data = GetDataPermission(ResourceTypeID);
            return data._getPermissionResGroupStrIDs(Employee_ID, per_type);
        }
        #endregion

        #region Load dataset

        #region Res

        public static DataSet LoadDataSetWithResPermission(long ResourceTypeID, QueryBuilder query, string tableName, string KeyFieldRes)
        {
            DataPermission data = GetDataPermission(ResourceTypeID);
            return data._LoadDataSetWithResPermission(query,tableName,KeyFieldRes);
        }
        public static DataSet LoadDataSetWithResPermission(long ResourceTypeID, QueryBuilder query, string KeyFieldRes)
        {
            DataPermission data = GetDataPermission(ResourceTypeID);
            return data._LoadDataSetWithResPermission(query,KeyFieldRes);
        }
        public static DataSet LoadDataSetWithResPermission(long ResourceTypeID, QueryBuilder query, string tableName, string KeyFieldRes, long ResID)
        {
            DataPermission data = GetDataPermission(ResourceTypeID);
            return data._LoadDataSetWithResPermission(query,tableName, KeyFieldRes,ResID);
        }
        public static DataSet LoadDataSetWithResPermission(long ResourceTypeID, QueryBuilder query, string KeyFieldRes, long ResID)
        {
            DataPermission data = GetDataPermission(ResourceTypeID);
            return data._LoadDataSetWithResPermission(query, KeyFieldRes,ResID);
        }

        public static DataSet LoadDataSetWithResPermission(long ResourceTypeID, string queryStr, string tableName, string KeyFieldRes)
        {
            DataPermission data = GetDataPermission(ResourceTypeID);
            return data._LoadDataSetWithResPermission(queryStr,tableName, KeyFieldRes);
        }
        public static DataSet LoadDataSetWithResPermission(long ResourceTypeID, string queryStr, string KeyFieldRes)
        {
            DataPermission data = GetDataPermission(ResourceTypeID);
            return data._LoadDataSetWithResPermission(queryStr, KeyFieldRes);
        }
        public static DataSet LoadDataSetWithResPermission(long ResourceTypeID, string queryStr, string tableName, string KeyFieldRes, long ResID)
        {
            DataPermission data = GetDataPermission(ResourceTypeID);
            return data._LoadDataSetWithResPermission(queryStr,tableName, KeyFieldRes,ResID);
        }
        public DataSet LoadDataSetWithResPermission(long ResourceTypeID, string queryStr, string KeyFieldRes, long ResID)
        {
            DataPermission data = GetDataPermission(ResourceTypeID);
            return data._LoadDataSetWithResPermission(queryStr, KeyFieldRes,ResID);
        }
        public static bool LoadDataSetWithResPermission(long ResourceTypeID, DataSet ds, string tableName,
            string KeyFieldRes, long ResID)
        {
            DataPermission data = GetDataPermission(ResourceTypeID);
            return data._LoadDataSetWithResPermission(ds,tableName,KeyFieldRes,ResID);
        }

        public static bool LoadResDataSetWithPermission(long ResourceTypeID, DataSet ds, string KeyFieldRes, long ResID)
        {
            DataPermission data = GetDataPermission(ResourceTypeID);
            return data._LoadResDataSetWithPermission(ds, KeyFieldRes, ResID);
        }
        public static DataSet LoadResDataSetWithPermission(long ResourceTypeID,string KeyFieldRes, long ResID)
        {
            DataPermission data = GetDataPermission(ResourceTypeID);
            return data._LoadResDataSetWithPermission(KeyFieldRes, ResID);
        }
        #endregion

        #region Res Group

        public static DataSet LoadDataSetWithResGroupPermission(long ResourceTypeID, QueryBuilder query, string tableName, string KeyFieldResGroup)
        {
            DataPermission data = GetDataPermission(ResourceTypeID);
            return data._LoadDataSetWithResGroupPermission(query, tableName, KeyFieldResGroup);
        }
        public static DataSet LoadDataSetWithResGroupPermission(long ResourceTypeID, QueryBuilder query, string KeyFieldResGroup)
        {
            DataPermission data = GetDataPermission(ResourceTypeID);
            return data._LoadDataSetWithResGroupPermission(query, KeyFieldResGroup);
        }
        public static DataSet LoadDataSetWithResGroupPermission(long ResourceTypeID, QueryBuilder query, string tableName, string KeyFieldResGroup, long ResGroupID)
        {
            DataPermission data = GetDataPermission(ResourceTypeID);
            return data._LoadDataSetWithResGroupPermission(query, tableName, KeyFieldResGroup,ResGroupID);
        }
        public static DataSet LoadDataSetWithResGroupPermission(long ResourceTypeID, QueryBuilder query, string KeyFieldResGroup, long ResGroupID)
        {
            DataPermission data = GetDataPermission(ResourceTypeID);
            return data._LoadDataSetWithResGroupPermission(query, KeyFieldResGroup, ResGroupID);
        }

        public static DataSet LoadDataSetWithResGroupPermission(long ResourceTypeID, string queryStr, string tableName, string KeyFieldResGroup)
        {
            DataPermission data = GetDataPermission(ResourceTypeID);
            return data._LoadDataSetWithResGroupPermission(queryStr, tableName, KeyFieldResGroup);
        }
        public static DataSet LoadDataSetWithResGroupPermission(long ResourceTypeID, string queryStr, string KeyFieldResGroup)
        {
            DataPermission data = GetDataPermission(ResourceTypeID);
            return data._LoadDataSetWithResGroupPermission(queryStr, KeyFieldResGroup);
        }
        public static DataSet LoadDataSetWithResGroupPermission(long ResourceTypeID, string queryStr, string tableName, string KeyFieldResGroup, long ResGroupID)
        {
            DataPermission data = GetDataPermission(ResourceTypeID);
            return data._LoadDataSetWithResGroupPermission(queryStr, tableName, KeyFieldResGroup,ResGroupID);
        }
        public static DataSet LoadDataSetWithResGroupPermission(long ResourceTypeID, string queryStr, string KeyFieldResGroup, long ResGroupID)
        {
            DataPermission data = GetDataPermission(ResourceTypeID);
            return data._LoadDataSetWithResGroupPermission(queryStr, KeyFieldResGroup,ResGroupID);
        }
        public static bool LoadDataSetWithResGroupPermission(long ResourceTypeID, DataSet ds, string tableName, string KeyFieldRes, long ResGroupID)
        {
            DataPermission data = GetDataPermission(ResourceTypeID);
            return data._LoadDataSetWithResGroupPermission(ds, tableName, KeyFieldRes,ResGroupID);
        }

        public static bool LoadResGroupDataSetWithPermission(long ResourceTypeID, DataSet ds, string KeyFieldRes, long ResGroupID)
        {
            DataPermission data = GetDataPermission(ResourceTypeID);
            return data._LoadResGroupDataSetWithPermission(ds, KeyFieldRes, ResGroupID);
        }
        public static DataSet LoadResGroupDataSetWithPermission(long ResourceTypeID, string KeyFieldRes, long ResGroupID)
        {
            DataPermission data = GetDataPermission(ResourceTypeID);
            return data._LoadResGroupDataSetWithPermission(KeyFieldRes, ResGroupID);
        }
        #endregion

        #endregion


        public static DataPermission GetDataPermission(long ResourceTypeID)
        {
            IPermissionData iper = FrameworkParams.iPermissionData;
            if (iper == null) return null;
            DataPermission[] dataPers = iper.getObjectResources();
            if (dataPers == null) return null;
            foreach (DataPermission data in dataPers)
            {
                if (data.Resource_Type_ID == ResourceTypeID)
                    return data;
            }
            return null;
        }

        private static void CreateItemOnDMTreeGroupElement(DMTreeGroupElement control)
        {

            string TableName = "";
            DataTable dt = control.gridView_1.GridControl.DataSource as DataTable;
            if (dt != null)
            {
                TableName = dt.TableName;

            }
            else return;
            IPermissionData perRes = FrameworkParams.iPermissionData;
            DataPermission[] tainguyenLst = perRes.getObjectResources();
            if (tainguyenLst == null) return;
            bool Is_Group = false;
            DataPermission DataPer = null;
            foreach (DataPermission data in tainguyenLst)
            {
                if (data.DMTableName_Res == TableName)
                {
                    DataPer = data;
                    Is_Group = false;
                }
                else if (data.DMTableName_ResGroup == TableName)
                {
                    DataPer = data;
                    Is_Group = true;
                    break;
                }
            }
            if (DataPer == null) return;
            DataPer.Init();
            
            ToolStripButton btnPhanQuyen = new ToolStripButton("Phân quyền", HelpImage.getImage2020("mnbPhieuPhanHoiKH.png"));
            control.btnAdd.Owner.Items.Add(btnPhanQuyen);
            control.btnAdd.Owner.Items.Add(new ToolStripSeparator());
            btnPhanQuyen.Click += delegate(object sender, EventArgs e)
            {
                int rowHandle = control.gridView_1.FocusedRowHandle;
                if (rowHandle < 0 && control.gridView_1.SelectedRowsCount > 0)
                {
                    rowHandle = control.gridView_1.GetSelectedRows()[0];
                }

                DataRow focusRow = control.gridView_1.GetDataRow(rowHandle);
                if (control.gridView_1.IsDataRow(rowHandle) == false || focusRow == null)
                {
                    HelpMsgBox.ShowNotificationMessage("Bạn chưa chọn dữ liệu. Vui lòng chọn dữ liệu để phân quyền!");
                    return;
                }
                DOResource resource = null;
                if (Is_Group)
                {
                    resource = new DOResource(-1, HelpNumber.ParseInt64(focusRow["ID"]), -1, null);
                }
                else
                {
                    resource = new DOResource(
                        HelpNumber.ParseInt64(focusRow["ID"]),
                      dt.Columns.Contains(DataPer.RefFieldNameDM_Res_ResGroup) ?
                       HelpNumber.ParseInt64(focusRow[DataPer.RefFieldNameDM_Res_ResGroup]) : -1,
                       -1, null);
                }

                frmPermissionDataPopUp frm = new frmPermissionDataPopUp(DataPer, resource);
                HelpProtocolForm.ShowModalDialog(ProtocolVN.Framework.Win.FrameworkParams.MainForm, frm);

            };
            if (DataPer.IsPermission == false) return;

            bool AddPermis = control.btnAdd.Visible;
            bool UpdatePermis = control.btnUpdate.Visible;
            bool DeletePermis = control.btnDel.Visible;

            TreeListNode n = control.TreeList_1.FocusedNode;
            long fParentID = -2;

            if (n != null)
            {
                fParentID = HelpNumber.ParseInt64(n["ID"]);
            }

            DataRow r = control.gridView_1.GetFocusedDataRow();
            long fID = -2;
            if (r != null)
            {
                fID = HelpNumber.ParseInt64(r["ID"]);
            }
            ApplyPermissionOnDMTreeGroupElement(control, Is_Group, AddPermis, UpdatePermis, DeletePermis, DataPer, fID, fParentID, false);

            control.gridView_1.FocusedRowChanged += delegate(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
            {
                DataRow row = control.gridView_1.GetDataRow(e.FocusedRowHandle);
                if (row == null) return;
                long ID = HelpNumber.ParseInt64(row["ID"]);
                TreeListNode node = control.TreeList_1.FocusedNode;
                long ParentID = -2;
                if (node != null)
                {
                    ParentID = HelpNumber.ParseInt64(node["ID"]);
                }
                ApplyPermissionOnDMTreeGroupElement(control, Is_Group, AddPermis, UpdatePermis, DeletePermis, DataPer, ID, ParentID, true);
            };
            control.TreeList_1.FocusedNodeChanged += delegate(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
            {
                TreeListNode node = e.Node;
                if (node == null) return;
                long ParentID = HelpNumber.ParseInt64(node["ID"]);

                DataRow row = control.gridView_1.GetFocusedDataRow();
                long ID = -2;
                if (row != null)
                {
                    ID = HelpNumber.ParseInt64(row["ID"]);
                }
                ApplyPermissionOnDMTreeGroupElement(control, Is_Group, AddPermis, UpdatePermis, DeletePermis, DataPer, ID, ParentID, false);
            };

            control.gridView_1.RowUpdated += delegate(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
            {
                if (e.Row == null) return;
                DataRow dr = ((DataRowView)e.Row).Row;
                DataPer.InsertPermis(HelpNumber.ParseInt64(dr["ID"]), Is_Group, -1,
                     ProtocolVN.Framework.Win.FrameworkParams.currentUser.employee_id, true, true, true, true);


            };
            long deleteID = -1;
            control._BeforeDelEvent += delegate(DMTreeGroupElement sender)
            {
                int[] selectedRows = sender.gridView_1.GetSelectedRows();
                if (selectedRows != null && selectedRows.Length > 0)
                {
                    DataRow dlr = sender.gridView_1.GetDataRow(selectedRows[0]);
                    if (dlr != null) deleteID = HelpNumber.ParseInt64(dlr["ID"]);
                }

            };
            control._AfterDelSuccEvent += delegate(DMTreeGroupElement sender)
            {
                if (deleteID != -1)
                {
                    DataPer.DeletePermis(deleteID, Is_Group);
                    deleteID = -1;
                }
            };

        }

      
       

       

        private static void ApplyPermissionOnDMTreeGroupElement(DMTreeGroupElement control, bool Is_Group, bool AddPermis,
        bool UpdatePermis, bool DeletePermis, DataPermission DataPer, long ID, long ParentID, bool IsFocusGrid)
        {
            if (Is_Group)
            {
                if (IsFocusGrid == false && AddPermis && DataPer.DMTableName_ResGroup != "")
                {
                    control.btnAdd.Visible = DataPer._checkPermissionResGroup(ParentID, RES_PERMISSION_TYPE.CREATE);
                }
                if (UpdatePermis)
                {
                    control.btnUpdate.Visible = DataPer._checkPermissionResGroup(ID, RES_PERMISSION_TYPE.UPDATE);
                }
                if (DeletePermis)
                {
                    control.btnDel.Visible = DataPer._checkPermissionResGroup(ID, RES_PERMISSION_TYPE.DELETE);
                }
            }
            else
            {
                if (IsFocusGrid == false && AddPermis && DataPer.DMTableName_ResGroup != "")
                {
                    control.btnAdd.Visible = DataPer._checkPermissionResGroup(ParentID, RES_PERMISSION_TYPE.CREATE);
                }
                if (UpdatePermis)
                {
                    control.btnUpdate.Visible = DataPer._checkPermissionRes(ID, RES_PERMISSION_TYPE.UPDATE);
                }
                if (DeletePermis)
                {
                    control.btnDel.Visible = DataPer._checkPermissionRes(ID, RES_PERMISSION_TYPE.DELETE);
                }
            }
        }


        private static void CreateItemOnDMTreeGroup(DMTreeGroup control)
        {

            string TableName = "";
            DataTable dt = control.TreeList_1.DataSource as DataTable;
            if (dt != null)
            {
                TableName = dt.TableName;

            }
            else return;
            IPermissionData perRes = FrameworkParams.iPermissionData;
            DataPermission[] tainguyenLst = perRes.getObjectResources();
            if (tainguyenLst == null) return;
            bool Is_Group = false;
            DataPermission DataPer = null;
            foreach (DataPermission data in tainguyenLst)
            {
                if (data.DMTableName_Res == TableName)
                {
                    DataPer = data;
                    Is_Group = false;
                }
                else if (data.DMTableName_ResGroup == TableName)
                {
                    DataPer = data;
                    Is_Group = true;
                    break;
                }
            }
            if (DataPer == null) return;
            DataPer.Init();
            ToolStripButton btnPhanQuyen = new ToolStripButton("Phân quyền", HelpImage.getImage2020("mnbPhieuPhanHoiKH.png"));
            int index = control.btnAdd.Owner.Items.IndexOf(control.btnKhongLuu);
            control.btnAdd.Owner.Items.Insert(index + 2, btnPhanQuyen);
            control.btnAdd.Owner.Items.Insert(index + 3, (new ToolStripSeparator()));
            btnPhanQuyen.Click += delegate(object sender, EventArgs e)
            {
                TreeListNode focusNode = control.TreeList_1.FocusedNode;
                if (focusNode == null && control.TreeList_1.Selection.Count > 0)
                {
                    focusNode = control.TreeList_1.Selection[0];
                }
                if (focusNode == null)
                {
                    HelpMsgBox.ShowNotificationMessage("Bạn chưa chọn dữ liệu. Vui lòng chọn dữ liệu để phân quyền!");
                    return;
                }
                DOResource resource = null;
                if (Is_Group)
                {
                    resource = new DOResource(-1, HelpNumber.ParseInt64(focusNode[control.TreeList_1.KeyFieldName]), -1, null);

                }
                else
                {
                    resource = new DOResource(
                        HelpNumber.ParseInt64(focusNode[control.TreeList_1.KeyFieldName]),
                      dt.Columns.Contains(DataPer.RefFieldNameDM_Res_ResGroup) ?
                       HelpNumber.ParseInt64(focusNode[DataPer.RefFieldNameDM_Res_ResGroup]) : -1,
                       -1, null);
                }

                frmPermissionDataPopUp frm = new frmPermissionDataPopUp(DataPer, resource);
                HelpProtocolForm.ShowModalDialog(ProtocolVN.Framework.Win.FrameworkParams.MainForm, frm);

            };
            if (DataPer.IsPermission == false) return;
            bool AddPermis = control.btnAdd.Visible;
            bool UpdatePermis = control.btnUpdate.Visible;
            bool DeletePermis = control.btnDel.Visible;
            TreeListNode n = control.TreeList_1.FocusedNode;
            if (n != null)
            {
                ApplyPermissionOnDMTreeGroup(control,
                                   Is_Group, AddPermis,
                                   UpdatePermis, DeletePermis,
                                   DataPer, HelpNumber.ParseInt64(n[control.TreeList_1.KeyFieldName]),
                                   HelpNumber.ParseInt64(n[control.TreeList_1.ParentFieldName]));
            }

            control.TreeList_1.FocusedNodeChanged += delegate(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
            {
                TreeListNode node = e.Node;
                if (node == null) return;
                long ID = HelpNumber.ParseInt64(node[control.TreeList_1.KeyFieldName]);
                long ParentID = HelpNumber.ParseInt64(node[control.TreeList_1.ParentFieldName]);
                ApplyPermissionOnDMTreeGroup(control,
                    Is_Group, AddPermis,
                    UpdatePermis, DeletePermis,
                    DataPer, ID, ParentID);
            };
            control._AfterSaveSuccEvent += delegate(DMTreeGroup sender)
            {
                TreeListNode fNode = sender.TreeList_1.FocusedNode;
                if (fNode == null) return;
                DataPer.InsertPermis(HelpNumber.ParseInt64(fNode["ID"]), Is_Group, -1,
                     ProtocolVN.Framework.Win.FrameworkParams.currentUser.employee_id, true, Is_Group || DataPer.Is_ResUseCreate, true, true);
                
            };
            long deleteID = -1;
            control._BeforeDelEvent += delegate(DMTreeGroup sender)
            {
               
                if (sender.TreeList_1.FocusedNode!=null)
                {
                    deleteID = HelpNumber.ParseInt64(sender.TreeList_1.FocusedNode["ID"]);
                }

            };
            control._AfterDelSuccEvent += delegate(DMTreeGroup sender)
            {
                if (deleteID != -1)
                {
                    DataPer.DeletePermis(deleteID, Is_Group);
                    deleteID = -1;
                }
            };


        }

     
        private static void ApplyPermissionOnDMTreeGroup(DMTreeGroup control, bool Is_Group, bool AddPermis,
          bool UpdatePermis, bool DeletePermis, DataPermission DataPer, long ID,long ParentID)
        {


            if (Is_Group)
            {
                if (AddPermis)
                {
                    control.addSameLevel.Visible = DataPer._checkPermissionResGroup(ParentID, RES_PERMISSION_TYPE.CREATE);
                    control.btnAdd.Visible = DataPer._checkPermissionResGroup(ID, RES_PERMISSION_TYPE.CREATE);
                }
                if (UpdatePermis)
                {
                    control.btnUpdate.Visible = DataPer._checkPermissionResGroup(ID, RES_PERMISSION_TYPE.UPDATE);

                }
                if (DeletePermis)
                {
                    control.btnDel.Visible = DataPer._checkPermissionResGroup(ID, RES_PERMISSION_TYPE.DELETE);
                }
            }
            else
            {
                if (AddPermis)
                {
                    control.addSameLevel.Visible = DataPer._checkPermissionRes(ParentID, RES_PERMISSION_TYPE.CREATE);
                    control.btnAdd.Visible = DataPer._checkPermissionRes(ID, RES_PERMISSION_TYPE.CREATE);
                }
                if (UpdatePermis)
                {
                    control.btnUpdate.Visible = DataPer._checkPermissionRes(ID, RES_PERMISSION_TYPE.UPDATE);

                }
                if (DeletePermis)
                {
                    control.btnDel.Visible = DataPer._checkPermissionRes(ID, RES_PERMISSION_TYPE.DELETE);
                }
            }
        }

        private static void CreateItemOnDMGrid(DMGrid control)
        {

            string TableName = "";
            DataTable dt = control.Grid.GridControl.DataSource as DataTable;
            if (dt != null) TableName = dt.TableName;
            else return;
            IPermissionData perRes = FrameworkParams.iPermissionData;
            DataPermission[] tainguyenLst = perRes.getObjectResources();
            if (tainguyenLst == null) return;
            bool Is_Group = false;
            DataPermission DataPer = null;
            foreach (DataPermission data in tainguyenLst)
            {
                if (data.DMTableName_Res == TableName)
                {
                    DataPer = data;
                    Is_Group = false;
                }
                else if (data.DMTableName_ResGroup == TableName)
                {
                    DataPer = data;
                    Is_Group = true;
                    break;
                }
            }
            if (DataPer == null) return;
            DataPer.Init();
            ToolStripButton btnPhanQuyen = new ToolStripButton("Phân quyền", HelpImage.getImage2020("mnbPhieuPhanHoiKH.png"));
            control.btnAdd.Owner.Items.Add(btnPhanQuyen);
            control.btnAdd.Owner.Items.Add(new ToolStripSeparator());
            btnPhanQuyen.Click += delegate(object sender, EventArgs e)
            {
                int rowHandle = control.Grid.FocusedRowHandle;
                if (rowHandle < 0 && control.Grid.SelectedRowsCount > 0)
                {
                    rowHandle = control.Grid.GetSelectedRows()[0];
                }

                DataRow focusRow = control.Grid.GetDataRow(rowHandle);
                if (control.Grid.IsDataRow(rowHandle) == false || focusRow == null)
                {
                    HelpMsgBox.ShowNotificationMessage("Bạn chưa chọn dữ liệu. Vui lòng chọn dữ liệu để phân quyền!");
                    return;
                }
                DOResource resource = null;
                if (Is_Group)
                {
                    resource = new DOResource(-1, HelpNumber.ParseInt64(focusRow["ID"]), -1, null);

                }
                else
                {
                    resource = new DOResource(
                        HelpNumber.ParseInt64(focusRow["ID"]),
                      dt.Columns.Contains(DataPer.RefFieldNameDM_Res_ResGroup) ?
                       HelpNumber.ParseInt64(focusRow[DataPer.RefFieldNameDM_Res_ResGroup]) : -1,
                       -1, null);
                }

                frmPermissionDataPopUp frm = new frmPermissionDataPopUp(DataPer, resource);
                HelpProtocolForm.ShowModalDialog(ProtocolVN.Framework.Win.FrameworkParams.MainForm, frm);

            };
            if (DataPer.IsPermission == false) return;

            bool UpdatePermis = control.btnUpdate.Visible;
            bool DeletePermis = control.btnDel.Visible;


            DataRow r = control.Grid.GetFocusedDataRow();
            if (r != null)
            {
                ApplyPermissionOnDMGrid(control, Is_Group,
                        UpdatePermis, DeletePermis, DataPer, HelpNumber.ParseInt64(r["ID"]));
            }
            control.Grid.FocusedRowChanged += delegate(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
            {
                DevExpress.XtraGrid.Views.Grid.GridView grid = sender as DevExpress.XtraGrid.Views.Grid.GridView;
                DataRow row = grid.GetDataRow(e.FocusedRowHandle);
                if (row != null)
                {
                    ApplyPermissionOnDMGrid(control, Is_Group,
                        UpdatePermis, DeletePermis, DataPer, HelpNumber.ParseInt64(row["ID"]));
                }

            };
            control._DMCore._AfterSaveSuccEvent += delegate(DMBasicGrid sender)
            {              
                DataTable dtSource = sender.Grid.GridControl.DataSource as DataTable;
                DataRow[] rows = dtSource.Select("", "", DataViewRowState.Added);
                if (rows.Length > 0)
                {
                    DataRow rr = rows[0];
                    DataPer.InsertPermis(HelpNumber.ParseInt64(rr["ID"]), Is_Group, -1,
                         ProtocolVN.Framework.Win.FrameworkParams.currentUser.employee_id, true, true, true, true);
                   
                    rr.AcceptChanges();
                }
            };
            long deleteID = -1;
            control._DMCore._BeforeDelEvent += delegate(DMBasicGrid sender)
            {

                DataRow dlr = sender.Grid.GetFocusedDataRow();
                if (dlr != null) deleteID = HelpNumber.ParseInt64(dlr["ID"]);

            };
            control._DMCore._AfterDelSuccEvent += delegate(DMBasicGrid sender)
            {
                if (deleteID != -1)
                {
                    DataPer.DeletePermis(deleteID, Is_Group);
                    deleteID = -1;
                }
            };
        }        
        private static void ApplyPermissionOnDMGrid(DMGrid control,bool Is_Group,
            bool UpdatePermis,bool DeletePermis,DataPermission DataPer, long ID)
        {         
        
            if (Is_Group)
            {
                if (UpdatePermis)
                {
                    control.btnUpdate.Visible = DataPer._checkPermissionResGroup(ID, RES_PERMISSION_TYPE.UPDATE);
                    control._DMCore.SupportDoubleClick = control.btnUpdate.Visible;                   
                }
                if (DeletePermis)
                {
                    control.btnDel.Visible = DataPer._checkPermissionResGroup(ID, RES_PERMISSION_TYPE.DELETE);
                }
            }
            else
            {
                if (UpdatePermis)
                {
                    control.btnUpdate.Visible = DataPer._checkPermissionRes(ID, RES_PERMISSION_TYPE.UPDATE);
                }
                if (DeletePermis)
                {
                    control.btnDel.Visible = DataPer._checkPermissionRes(ID, RES_PERMISSION_TYPE.DELETE);
                }
            }
        }

        public static void CreateItemOnDM(Control controlDM)
        {
            if (controlDM is DMGrid)
            {
                CreateItemOnDMGrid((DMGrid)controlDM);
            }
            else if (controlDM is DMTreeGroup)
            {
                CreateItemOnDMTreeGroup((DMTreeGroup)controlDM);
            }
            else if (controlDM is DMTreeGroupElement)
            {
                CreateItemOnDMTreeGroupElement((DMTreeGroupElement)controlDM);
            }
        }


    }
   
    public interface IPermissionData
    {
        DataPermission[] getObjectResources();
    }
  
    public static class FrameworkParams
    {
        public static IPermissionData iPermissionData;
    }
    
}

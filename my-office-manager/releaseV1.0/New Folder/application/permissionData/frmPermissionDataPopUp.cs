using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ProtocolVN.Framework.Win;
using ProtocolVN.Framework.Core;
using System.Data.Common;
using DevExpress.XtraTreeList.StyleFormatConditions;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Columns;
using DevExpress.XtraTreeList.Nodes;

namespace PermissionOfResource
{
    /// <summary>
    ///Khanhdtn: Form cấu hình phân quyền một tài nguyên (Xây dựng theo PL-Office)
    /// </summary>
    public partial class frmPermissionDataPopUp : XtraFormPL
    {
        protected DataPermission ResourcePer;
        protected DOResource doResource;
        protected bool Is_Group;
        public frmPermissionDataPopUp(DataPermission resourcePer, DOResource doResource)
        {
            InitializeComponent();
            this.ResourcePer = resourcePer;
            this.doResource = doResource;
            Is_Group = doResource.ID <= -1;

            if (doResource.Creater_ID > -1 && FrameworkParams.currentUser.username != "admin" && doResource.Creater_ID != FrameworkParams.currentUser.employee_id)
            {
                HelpXtraForm.CloseFormNoConfirm(this);
                HelpMsgBox.ShowNotificationMessage(string.Format("Bạn không có quyền phân quyền trên {0} này!", resourcePer.ResName));
                return;
            }
            InitControl();
            UpdateData();

        }

        private void InitControl()
        {
            if (Is_Group)
            {
                this.lblCaptionResource.Text = ResourcePer.ResGroupName;
                this.lblCaptionResourceGroup.Visible = false;
                this.lblResourceGroup.Visible = false;
                this.Text = "Phân quyền nhân viên - " + ResourcePer.ResGroupName.ToLower();

            }
            else
            {

                this.lblCaptionResource.Text = ResourcePer.ResName;
                this.lblCaptionResourceGroup.Text = ResourcePer.ResGroupName;
                this.Text = "Phân quyền nhân viên - " + ResourcePer.ResName.ToLower();
            }
            HelpXtraForm.SetCloseForm(this, btnClose, true);

            HelpTreeList.CotTextLeft(ColEmpName, "NAME");
            HelpTreeList.CotCheckEdit(ColFullPermission, "ISFULL_BIT");
            HelpTreeList.CotCheckEdit(ColIsRead, "ISREAD_BIT");
            HelpTreeList.CotCheckEdit(ColIsCreate, "ISCREATE_BIT");
            HelpTreeList.CotCheckEdit(ColIsUpdate, "ISUPDATE_BIT");
            HelpTreeList.CotCheckEdit(ColIsDelete, "ISDELETE_BIT");
            HelpTreeList.CotCheckEdit(ColIsDepartment, "IS_DEPARTMENT");
            treeListPermission.ParentFieldName = "PARENT_ID";
            treeListPermission.KeyFieldName = "DEP_EMP_ID";
            ColID.FieldName = "DEP_EMP_ID";
            if (Is_Group == false && ResourcePer.Is_ResUseCreate == false)
            {

                ColIsCreate.Visible = false;
                ColIsCreate.OptionsColumn.ShowInCustomizationForm = false;
            }
        }
        private void UpdateData()
        {

            if (doResource.Created_date != null) lblCreatedDate.Text = doResource.Created_date.Value.ToString();
            else
            {
                lblCaptionCreatedDate.Visible = false;
                lblCreatedDate.Visible = false;
            }
            if (doResource.Creater_ID <= -1)
            {
                lblCaptionCreater.Visible = false;
                lblCreater.Visible = false;
            }
            else
            {
                FWDBService dbEmp = HelpDB.getDBService();
                DbCommand cmdEmp = dbEmp.GetSQLStringCommand(string.Format(
                              @"select name from dm_nhan_vien where id ={0}", doResource.Creater_ID));
                object creater = dbEmp.ExecuteScalar(cmdEmp);
                if (creater != null) lblCreater.Text = creater.ToString();
            }
            if (ResourcePer.DMTableName_Res != "")
            {
                FWDBService dbRes = HelpDB.getDBService();
                DbCommand cmdRes = dbRes.GetSQLStringCommand(string.Format(
                    @"select name from {0} where id ={1}", ResourcePer.DMTableName_Res, doResource.ID));
                object resourceName = dbRes.ExecuteScalar(cmdRes);
                if (resourceName != null)
                {
                    lblResource.Text = resourceName.ToString();
                }
                else if (Is_Group == false)
                {
                    HelpMsgBox.ShowNotificationMessage(string.Format("Không thể phân quyền vì {0} đang chọn không còn tồn tại trong dữ liệu!", ResourcePer.ResName.ToLower()));
                    HelpXtraForm.CloseFormNoConfirm(this);
                    return;
                }
            }
            if (doResource.Group_ID <= -1)
            {
                lblCaptionResourceGroup.Visible = false;
                lblResourceGroup.Visible = false;
            }
            else
            {
                FWDBService dbResGroup = HelpDB.getDBService();
                DbCommand cmdResGroupp = dbResGroup.GetSQLStringCommand(string.Format(
                              @"select name from {0} where id ={1}", ResourcePer.DMTableName_ResGroup, doResource.Group_ID));
                object resourceGroupName = dbResGroup.ExecuteScalar(cmdResGroupp);
                if (resourceGroupName != null)
                {
                    if (Is_Group)
                    {
                        lblResource.Text = resourceGroupName.ToString();
                    }
                    else
                    {
                        lblResourceGroup.Text = resourceGroupName.ToString();
                    }
                }
            }

            string condDepRes = @"dep_res.isread_bit='Y' and
                        dep_res.isupdate_bit ='Y' and dep_res.isdelete_bit='Y'";
            string condEmpRes = @"emp_res.isread_bit='Y' and
                        emp_res.isupdate_bit ='Y' and emp_res.isdelete_bit='Y'";
            if (Is_Group == true || ResourcePer.Is_ResUseCreate)
            {
                condDepRes += " and dep_res.iscreate_bit='Y'";
                condEmpRes += " and emp_res.iscreate_bit='Y'";
            }

            string sql = string.Format(@"select * from (select dp.id dep_emp_id,dp.parent_id,dp.name,'Y' is_department, dp.id_root,
                        {0} resource_id,iif(dep_res.iscreate_bit='Y','Y','N') iscreate_bit,iif(dep_res.isread_bit='Y','Y','N') isread_bit,iif(dep_res.isupdate_bit='Y','Y','N') isupdate_bit,iif(dep_res.isdelete_bit='Y','Y','N') isdelete_bit,
                        iif(" + condDepRes + @", 'Y','N') ISFULL_BIT,
                        dp.id department_id,null employee_id,dep_res.ID,{1} resource_type, '{2}' IS_GROUP
                        from (department dp
                        left join per_resource dep_res on dep_res.department_id=dp.id
                        and dep_res.resource_id={0} and dep_res.resource_type={1} and dep_res.is_group='{2}')
                                                         
                        union

                        select nv.id dep_emp_id, nv.department_id parent_id,nv.name,'N' is_department,
                        (select dep.id_root from department dep where dep.id=nv.department_id) id_root,
                        {0} resource_id, iif(emp_res.iscreate_bit='Y','Y','N') iscreate_bit,iif(emp_res.isread_bit='Y','Y','N') isread_bit,iif(emp_res.isupdate_bit='Y','Y','N') isupdate_bit,iif(emp_res.isdelete_bit='Y','Y','N') isdelete_bit,
                        iif(" + condEmpRes + @" , 'Y','N') ISFULL_BIT,
                        null department_id,nv.id employee_id,emp_res.ID,{1} resource_type,'{2}' IS_GROUP
                        from (dm_nhan_vien nv
                        left join per_resource emp_res on emp_res.employee_id=nv.id and emp_res.resource_id={0} and emp_res.resource_type={1} and emp_res.is_group='{2}' )
                        where nv.department_id is not null) order by is_department desc, name asc",
                                                                                                  Is_Group ? doResource.Group_ID : doResource.ID, ResourcePer.Resource_Type_ID, Is_Group ? "Y" : "N");
            DataSet ds = HelpDB.getDBService().LoadDataSet(sql, "PER_RESOURCE");
            treeListPermission.DataSource = ds.Tables[0];
            treeListPermission.BestFitColumns();

        }
        private void SetEnable()
        {
            TreeListNode focusNode = treeListPermission.FocusedNode;
            TreeListColumn focusColumn = treeListPermission.FocusedColumn;
            if (focusNode == null) return;
            if (focusColumn == null) return;

            bool parentCheck = IsParentChecked(focusNode, focusColumn.FieldName);
            focusColumn.OptionsColumn.AllowEdit = !parentCheck;

        }

        private bool IsParentChecked(TreeListNode node, string FieldName)
        {
            if (node.ParentNode == null) return false;
            if (node.ParentNode[FieldName].ToString() == "Y") return true;
            return IsParentChecked(node.ParentNode, FieldName);
        }

        private void treeListPermission_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {
            SetEnable();

        }

        private void treeListPermission_FocusedColumnChanged(object sender, FocusedColumnChangedEventArgs e)
        {
            SetEnable();
        }

        private void treeListPermission_CellValueChanging(object sender, CellValueChangedEventArgs e)
        {
            int startLevel = e.Node.Level;
            TreeListNode currentNode = e.Node;
            TreeListNode parentNode = e.Node.ParentNode;
            string bit_str = e.Value.ToString();
            string fieldName = e.Column.FieldName;
            if (fieldName == "ISFULL_BIT")
            {
                currentNode["ISFULL_BIT"] = bit_str;
                currentNode["ISREAD_BIT"] = bit_str;
                currentNode["ISUPDATE_BIT"] = bit_str;
                currentNode["ISDELETE_BIT"] = bit_str;
                if (Is_Group||ResourcePer.Is_ResUseCreate)
                    currentNode["ISCREATE_BIT"] = bit_str;

                //if (checkOrUncheckChild)
                //{
                //    currentNode.ExpandAll();
                //    currentNode = currentNode.NextVisibleNode;
                //    while (currentNode != null && currentNode.Level > startLevel)
                //    {

                //        currentNode["ISFULL_BIT"] = bit_str;
                //        currentNode["ISREAD_BIT"] = bit_str;
                //        currentNode["ISUPDATE_BIT"] = bit_str;
                //        currentNode["ISDELETE_BIT"] = bit_str;
                //        currentNode["ISCREATE_BIT"] = bit_str;
                //        currentNode.Tag = readOnlyFields;
                //        currentNode.ExpandAll();
                //        currentNode = currentNode.NextVisibleNode;
                //    }
                //}

            }

            else
            {
                currentNode[fieldName] = bit_str;

                if (Is_Group == false && ResourcePer.Is_ResUseCreate==false)
                {
                    currentNode["ISFULL_BIT"] = (
                        currentNode["ISREAD_BIT"].ToString() == "N"
                        || currentNode["ISREAD_BIT"] is DBNull
                        || currentNode["ISUPDATE_BIT"].ToString() == "N"
                        || currentNode["ISUPDATE_BIT"] is DBNull
                        || currentNode["ISDELETE_BIT"].ToString() == "N"
                        || currentNode["ISDELETE_BIT"] is DBNull
                        ) ? "N" : "Y";
                }
                else
                {
                    currentNode["ISFULL_BIT"] = (
                        currentNode["ISREAD_BIT"].ToString() == "N"
                        || currentNode["ISREAD_BIT"] is DBNull
                        || currentNode["ISUPDATE_BIT"].ToString() == "N"
                        || currentNode["ISUPDATE_BIT"] is DBNull
                        || currentNode["ISDELETE_BIT"].ToString() == "N"
                        || currentNode["ISDELETE_BIT"] is DBNull
                        || currentNode["ISCREATE_BIT"].ToString() == "N"
                        || currentNode["ISCREATE_BIT"] is DBNull
                        ) ? "N" : "Y";
                }


                /*bool checkOrUncheckChild = false;
                // ((checkChoseChild.Checked && bit_str == "Y") || (checkUnChoseChild.Checked && bit_str == "N"));
                if (checkOrUncheckChild)
                {
                    currentNode.ExpandAll();
                    currentNode = currentNode.NextVisibleNode;
                    if (ResourcePer.UseCreatePerForRes == false)
                    {
                        while (currentNode != null && currentNode.Level > startLevel)
                        {
                            currentNode[fieldName] = bit_str;
                            currentNode["ISFULL_BIT"] = (
                        currentNode["ISREAD_BIT"].ToString() == "N"
                        || currentNode["ISREAD_BIT"] is DBNull
                        || currentNode["ISUPDATE_BIT"].ToString() == "N"
                        || currentNode["ISUPDATE_BIT"] is DBNull
                        || currentNode["ISDELETE_BIT"].ToString() == "N"
                        || currentNode["ISDELETE_BIT"] is DBNull
                        || currentNode["ISCREATE_BIT"].ToString() == "N"
                        || currentNode["ISCREATE_BIT"] is DBNull
                        ) ? "N" : "Y";

                            currentNode.ExpandAll();
                            currentNode = currentNode.NextVisibleNode;
                        }
                    }
                    else
                    {
                        while (currentNode != null && currentNode.Level > startLevel)
                        {
                            currentNode[fieldName] = bit_str;
                            currentNode["ISFULL_BIT"] = (
                        currentNode["ISREAD_BIT"].ToString() == "N"
                        || currentNode["ISREAD_BIT"] is DBNull
                        || currentNode["ISUPDATE_BIT"].ToString() == "N"
                        || currentNode["ISUPDATE_BIT"] is DBNull
                        || currentNode["ISDELETE_BIT"].ToString() == "N"
                        || currentNode["ISDELETE_BIT"] is DBNull
                        || currentNode["ISCREATE_BIT"].ToString() == "N"
                        || currentNode["ISCREATE_BIT"] is DBNull)
                         ? "N" : "Y";

                            currentNode.ExpandAll();
                            currentNode = currentNode.NextVisibleNode;
                        }
                    }
                }*/
            }
            if (currentNode.Expanded == true)
            {
                currentNode.Expanded = false;//để refresh màu
                currentNode.Expanded = true;
            }
        }
        
        private bool Save()
        {
            DbTransaction dbTrans = null;
            DatabaseFB db = null;
            FWTransaction fwTrans = null;
            try
            {
                db = HelpDB.getDatabase();
                dbTrans = FWTransaction.BeginTrans(db);
                fwTrans = FWTransaction.I(db, dbTrans);

                DataTable dtMain = (treeListPermission.DataSource as DataTable).Copy();
                if (Is_Group || ResourcePer.Is_ResUseCreate)
                {
                    dtMain.DefaultView.RowFilter = "ISREAD_BIT='Y' OR ISCREATE_BIT='Y' OR ISUPDATE_BIT='Y' OR ISDELETE_BIT='Y'";
                }
                else
                {
                    dtMain.DefaultView.RowFilter = "ISREAD_BIT='Y' OR ISUPDATE_BIT='Y' OR ISDELETE_BIT='Y'";

                }
                dtMain = dtMain.DefaultView.ToTable();


                DataSet dsSource = new DataSet();
                if (fwTrans.LoadDataSet(dsSource, string.Format("select * from PER_RESOURCE per where per.RESOURCE_ID={0} and per.RESOURCE_TYPE={1} and per.IS_GROUP='{2}'",
                    Is_Group ? doResource.Group_ID : doResource.ID, ResourcePer.Resource_Type_ID, Is_Group ? "Y" : "N"), "PER_RESOURCE") == false)
                {
                    FWTransaction.Rollback(dbTrans);
                    return false;

                }
                DataTable dtSource = dsSource.Tables[0];

                DataRow[] rows = dtMain.Select("ID IS NULL");
                List<long> ids = db.GetID("G_FW_ID", dbTrans, rows.Length);
                for (int i = 0; i < rows.Length; i++)
                {
                    rows[i]["ID"] = ids[i];
                    rows[i].AcceptChanges();
                    rows[i].SetAdded();
                    dtSource.ImportRow(rows[i]);
                }
                dtMain.PrimaryKey = new DataColumn[] { dtMain.Columns["ID"] };


                DataRow findRow = null;
                foreach (DataRow r in dtSource.Rows)
                {
                    if (r.RowState == DataRowState.Added) continue;
                    findRow = dtMain.Rows.Find(r["ID"]);
                    if (findRow == null)
                    {
                        r.Delete();
                    }
                    else
                    {
                        r["ISREAD_BIT"] = findRow["ISREAD_BIT"];
                        r["ISCREATE_BIT"] = findRow["ISCREATE_BIT"];
                        r["ISUPDATE_BIT"] = findRow["ISUPDATE_BIT"];
                        r["ISDELETE_BIT"] = findRow["ISDELETE_BIT"];
                    }
                }
                if (db.UpdateDataSet(dsSource, dbTrans) == false)
                {
                    FWTransaction.Rollback(dbTrans);
                    return false;
                }

                FWTransaction.Commit(dbTrans);
                return true;
            }
            catch
            {
                FWTransaction.Rollback(dbTrans);
                return false;
            }



        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Save())
            {
                ResourcePer.Init();
                HelpXtraForm.CloseFormNoConfirm(this);
            }
            else
            {
                HelpPhieuMsg.ErrorSave(this);
            }
        }

        private void checkChoseChild_CheckedChanged(object sender, EventArgs e)
        {
            CheckEdit ckc = sender as CheckEdit;
            Font f = ckc.Font;
            ckc.Font = new Font(f, ckc.Checked ? FontStyle.Bold : FontStyle.Regular);

        }

        private void treeListPermission_GetStateImage(object sender, GetStateImageEventArgs e)
        {
            if (e.Node.Level == 0)
            {
                e.Node.StateImageIndex = 0;
            }
            else
            {
                if (e.Node["IS_DEPARTMENT"].ToString() == "Y")
                    e.Node.StateImageIndex = 1;
                else e.Node.StateImageIndex = 2;
            }
        }
        private void treeListPermission_CustomDrawNodeCell(object sender, CustomDrawNodeCellEventArgs e)
        {
            bool parentCheck = IsParentChecked(e.Node, e.Column.FieldName);
            e.Appearance.BeginUpdate();
            if (parentCheck)
            {
                e.Appearance.BackColor = Color.DarkGray;
                e.Appearance.Options.UseBackColor = true;
            }
            else
            {
                e.Appearance.Options.UseBackColor = false;
            }
            //e.Handled = true;
            e.Appearance.EndUpdate();
            //  treeListPermission.Refresh();
        }
    }

}
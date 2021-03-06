using System;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraBars.Docking;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraTreeList.Nodes;
using ProtocolVN.Framework.Core;
using ProtocolVN.Framework.Win;
using DevExpress.XtraGrid.Menu;
using DevExpress.Utils.Menu;
using DevExpress.XtraTab;
using System.Collections.Generic;
using PermissionOfResource.Running;

namespace PermissionOfResource
{
    /// <summary>
    /// Khanhdtn: màn hình quản lý phân quyền nhân viên tài nguyên (chỉ có tài nguyên, không có nhóm tài nguyên)
    /// (Xây dựng theo PL-offcie)
    /// (Ghi chú: Emp: Employee, Dep:Department, Res: Resource, ResGroup: Resource Group)
    /// </summary>
    public partial class frmPermissionDataQL : XtraFormPL
    {

        public static string MenuItem(string ParentID, bool IsSep)
        {
            return MenuBuilder.CreateItem(typeof(frmPermissionDataQL).FullName,
                "Phân quyền dữ liệu",
                ParentID, true,
                typeof(frmPermissionDataQL).FullName,
                true, IsSep, "mnbPhieuPhanHoiKH.png", true, "", "");
        }
        #region "Variables"
        protected DMGrid dmGrid = null;
        protected DMTreeGroup dmTree = null;
        protected bool IsDMGrid;
        private DataSet dsNguoiDung = null;
        #endregion

        public frmPermissionDataQL()
        {
            InitializeComponent();
            lblMessage.Text = "";
            InitNguoiDung();
            InitCayTaiNguyen();
            HelpXtraForm.SetCloseForm(this, this.btnDong, true);
            HelpPhieuForm.InitBtnPhieu(this, true, null, null, null, btnLuu, null, btnDong);           
        }

        private void InitCayTaiNguyen()
        {
            IPermissionData iPer = PermissionOfResource.Running.FrameworkParams.iPermissionData;
            if(iPer==null)return;
            DataPermission[] DataPers = iPer.getObjectResources();
            foreach (DataPermission d in DataPers)
            {
                XtraTabPage tab = xtraTabControlPermission.TabPages.Add(
                    d.ResName == "" ? d.ResGroupName :
                    (d.ResGroupName != "" ? d.ResName + " - " + d.ResGroupName.ToLower() : d.ResName));               
                tab.Tag = d;                
            }
            LoadData(xtraTabControlPermission.SelectedTabPage);
        }
        private void LoadData(XtraTabPage page)
        {
            if (page == null||page.Tag==null) return;
            if (page.Controls.Count == 0)
            {
                UCTreeListDataPermission uc = new UCTreeListDataPermission();
                page.Controls.Add(uc);
                uc.Dock = DockStyle.Fill;
                uc.ColName.Caption = "Tên " + page.Text.ToLower();
                DataTable dt = GetDataSource(page.Tag as DataPermission);
                Filter(dt);
                uc.DataSource = dt;
                uc.TreePermission.ExpandAll();
            }
            else
            {
                UCTreeListDataPermission uc = page.Controls[0] as UCTreeListDataPermission;
                Filter(uc.DataSource);
            }

        }
        private void Filter(DataTable dt)
        {
            if (dt == null) return;
            string filter = "1=-1";
            if (treeListPermission.FocusedNode != null)
            {
                if (treeListPermission.FocusedNode["IS_DEPARTMENT"].ToString() == "Y")
                {
                    filter = string.Format("department_id ={0}", treeListPermission.FocusedNode["ID"]);
                }
                else
                {
                    filter = string.Format("employee_id ={0}", treeListPermission.FocusedNode["ID"]);
                }
            }
            dt.DefaultView.RowFilter = filter;

        }
        private DataTable GetDataSource(DataPermission dataPer)
        {
            if (dataPer.DMTableName_Res == "" && dataPer.DMTableName_ResGroup == "") return null;

            string sql = "";
            string ResFullBit = dataPer.Is_ResUseCreate ? "per.isread_bit='Y' and per.isupdate_bit ='Y' and per.isdelete_bit='Y' and per.iscreate_bit='Y'"
                : "per.isread_bit='Y' and per.isupdate_bit ='Y' and per.isdelete_bit='Y'";

            if (dataPer.Is_DM_Tree)
            {
                if (dataPer.DMTableName_Res == "")//Chỉ có nhóm danh mục
                {
                    sql = string.Format(@"  select * from (select resGroup.name, resGroup.{0} parent_id, nv.id employee_id, resGroup.id resource_id, null department_id,
                        iif(per.iscreate_bit='Y','Y','N') iscreate_bit,
                        iif(per.isread_bit='Y','Y','N') isread_bit,
                        iif(per.isupdate_bit='Y','Y','N') isupdate_bit,
                        iif(per.isdelete_bit='Y','Y','N') isdelete_bit,
                        iif(per.isread_bit='Y' and per.isupdate_bit ='Y' and per.isdelete_bit='Y' and per.iscreate_bit='Y', 'Y','N') ISFULL_BIT,
                       {1}  resource_type, 'Y' is_group,per.id,'Y' use_create
                        from {2} resGroup
                        inner join dm_nhan_vien nv on 1=1
                        left join per_resource per on resGroup.id=per.resource_id and per.employee_id=nv.id
                        and per.resource_type={1} and per.is_group='Y'

                        union

                        select resGroup.name, resGroup.{0} parent_id,null employee_id, resGroup.id resource_id, dep.id department_id,
                        iif(per.iscreate_bit='Y','Y','N') iscreate_bit,
                        iif(per.isread_bit='Y','Y','N') isread_bit,
                        iif(per.isupdate_bit='Y','Y','N') isupdate_bit,
                        iif(per.isdelete_bit='Y','Y','N') isdelete_bit,
                        iif(per.isread_bit='Y' and per.isupdate_bit ='Y' and per.isdelete_bit='Y' and per.iscreate_bit='Y', 'Y','N') ISFULL_BIT,
                        {1}  resource_type, 'Y' is_group,per.id,'Y' use_create
                        from {2} resGroup
                        inner join department dep on 1=1
                        left join per_resource per on resGroup.id=per.resource_id and per.department_id=dep.id
                        and per.resource_type={1} and per.is_group='Y') order by is_group desc, name asc",
                        dataPer.Parent_Field, dataPer.Resource_Type_ID, dataPer.DMTableName_ResGroup);
                }
                else if (dataPer.DMTableName_ResGroup == "")//chỉ có danh mục
                {
                    sql = string.Format(@"select * from (select resGroup.name, resGroup.id parent_id, nv.id employee_id, resGroup.id resource_id, null department_id,
                        iif(per.iscreate_bit='Y','Y','N') iscreate_bit,
                        iif(per.isread_bit='Y','Y','N') isread_bit,
                        iif(per.isupdate_bit='Y','Y','N') isupdate_bit,
                        iif(per.isdelete_bit='Y','Y','N') isdelete_bit,
                        iif({2}, 'Y','N') ISFULL_BIT,
                        {0}  resource_type, 'N' is_group,per.id,'{3}' use_create
                        from {1} resGroup
                        inner join dm_nhan_vien nv on 1=1
                        left join per_resource per on resGroup.id=per.resource_id and per.employee_id=nv.id
                        and per.resource_type={0} and per.is_group='N'

                        union

                        select resGroup.name, resGroup.id parent_id,null employee_id, resGroup.id resource_id, dep.id department_id,
                        iif(per.iscreate_bit='Y','Y','N') iscreate_bit,
                        iif(per.isread_bit='Y','Y','N') isread_bit,
                        iif(per.isupdate_bit='Y','Y','N') isupdate_bit,
                        iif(per.isdelete_bit='Y','Y','N') isdelete_bit,
                        iif({2}, 'Y','N') ISFULL_BIT,
                        {0}  resource_type, 'N' is_group,per.id,'{3}' use_create
                        from {1} resGroup
                        inner join department dep on 1=1
                        left join per_resource per on resGroup.id=per.resource_id and per.department_id=dep.id
                        and per.resource_type={0} and per.is_group='N') order by is_group desc, name asc",
                        dataPer.Resource_Type_ID, dataPer.DMTableName_Res, ResFullBit, dataPer.Is_ResUseCreate ? "Y" : "N");
                }
                else
                {
                    sql = string.Format(@"select * from (select resGroup.name, resGroup.{0} parent_id, nv.id employee_id, resGroup.id resource_id, null department_id,
                        iif(per.iscreate_bit='Y','Y','N') iscreate_bit,
                        iif(per.isread_bit='Y','Y','N') isread_bit,
                        iif(per.isupdate_bit='Y','Y','N') isupdate_bit,
                        iif(per.isdelete_bit='Y','Y','N') isdelete_bit,
                        iif(per.isread_bit='Y' and per.isupdate_bit ='Y' and per.isdelete_bit='Y' and per.iscreate_bit='Y', 'Y','N') ISFULL_BIT,
                        {1}  resource_type, 'Y' is_group,per.id,'Y' use_create
                        from {2} resGroup
                        inner join dm_nhan_vien nv on 1=1
                        left join per_resource per on resGroup.id=per.resource_id and per.employee_id=nv.id
                        and per.resource_type={1} and per.is_group='Y'

                        union

                        select res.name, res.{3} parent_id, nv.id employee_id, res.id resource_id, null department_id,
                        iif(per.iscreate_bit='Y','Y','N') iscreate_bit,
                        iif(per.isread_bit='Y','Y','N') isread_bit,
                        iif(per.isupdate_bit='Y','Y','N') isupdate_bit,
                        iif(per.isdelete_bit='Y','Y','N') isdelete_bit,
                        iif({5}, 'Y','N') ISFULL_BIT,
                        {1}  resource_type, 'N' is_group,per.id,'{6}' use_create
                        from {4} res
                        inner join dm_nhan_vien nv on 1=1
                        left join per_resource per on res.id=per.resource_id and per.employee_id=nv.id
                        and per.resource_type={1} and per.is_group='N'

                        union

                        select resGroup.name, resGroup.{0} parent_id,null employee_id, resGroup.id resource_id, dep.id department_id,
                        iif(per.iscreate_bit='Y','Y','N') iscreate_bit,
                        iif(per.isread_bit='Y','Y','N') isread_bit,
                        iif(per.isupdate_bit='Y','Y','N') isupdate_bit,
                        iif(per.isdelete_bit='Y','Y','N') isdelete_bit,
                        iif(per.isread_bit='Y' and per.isupdate_bit ='Y' and per.isdelete_bit='Y' and per.iscreate_bit='Y', 'Y','N') ISFULL_BIT,
                        {1}  resource_type, 'Y' is_group,per.id,'Y' use_create
                        from {2} resGroup
                        inner join department dep on 1=1
                        left join per_resource per on resGroup.id=per.resource_id and per.department_id=dep.id
                        and per.resource_type={1} and per.is_group='Y'

                        union

                        select res.name, res.{3} parent_id,null employee_id, res.id resource_id, dep.id department_id,
                        iif(per.iscreate_bit='Y','Y','N') iscreate_bit,
                        iif(per.isread_bit='Y','Y','N') isread_bit,
                        iif(per.isupdate_bit='Y','Y','N') isupdate_bit,
                        iif(per.isdelete_bit='Y','Y','N') isdelete_bit,
                        iif({5}, 'Y','N') ISFULL_BIT,
                        {1}  resource_type, 'N' is_group,per.id,'{6}' use_create
                        from {4} res
                        inner join department dep on 1=1
                        left join per_resource per on res.id=per.resource_id and per.department_id=dep.id
                        and per.resource_type={1} and per.is_group='N')  order by is_group desc, name asc"
                        , dataPer.Parent_Field, dataPer.Resource_Type_ID, dataPer.DMTableName_ResGroup,
                        dataPer.RefFieldNameDM_Res_ResGroup, dataPer.DMTableName_Res, ResFullBit, dataPer.Is_ResUseCreate ? "Y" : "N");
                }
            }
            else
            {
                if (dataPer.DMTableName_Res == "")//Chỉ có nhóm danh mục
                {
                    sql = string.Format(@"select * from (select resGroup.name, resGroup.id parent_id, nv.id employee_id, resGroup.id resource_id, null department_id,
                        iif(per.iscreate_bit='Y','Y','N') iscreate_bit,
                        iif(per.isread_bit='Y','Y','N') isread_bit,
                        iif(per.isupdate_bit='Y','Y','N') isupdate_bit,
                        iif(per.isdelete_bit='Y','Y','N') isdelete_bit,
                        iif(per.isread_bit='Y' and per.isupdate_bit ='Y' and per.isdelete_bit='Y' and per.iscreate_bit='Y', 'Y','N') ISFULL_BIT,
                        {0}  resource_type, 'Y' is_group,per.id,'Y' use_create
                        from {1} resGroup
                        inner join dm_nhan_vien nv on 1=1
                        left join per_resource per on resGroup.id=per.resource_id and per.employee_id=nv.id
                        and per.resource_type={0} and per.is_group='Y'

                        union

                        select resGroup.name, resGroup.id parent_id,null employee_id, resGroup.id resource_id, dep.id department_id,
                        iif(per.iscreate_bit='Y','Y','N') iscreate_bit,
                        iif(per.isread_bit='Y','Y','N') isread_bit,
                        iif(per.isupdate_bit='Y','Y','N') isupdate_bit,
                        iif(per.isdelete_bit='Y','Y','N') isdelete_bit,
                        iif(per.isread_bit='Y' and per.isupdate_bit ='Y' and per.isdelete_bit='Y' and per.iscreate_bit='Y', 'Y','N') ISFULL_BIT,
                        {0}  resource_type, 'Y' is_group,per.id,'Y' use_create
                        from {1} resGroup
                        inner join department dep on 1=1
                        left join per_resource per on resGroup.id=per.resource_id and per.department_id=dep.id
                        and per.resource_type={0} and per.is_group='Y') order by is_group desc, name asc",
                        dataPer.Resource_Type_ID, dataPer.DMTableName_ResGroup);
                }
                else if (dataPer.DMTableName_ResGroup == "")//chỉ có danh mục
                {
                    sql = string.Format(@"select * from (select resGroup.name, resGroup.id parent_id, nv.id employee_id, resGroup.id resource_id, null department_id,
                        iif(per.iscreate_bit='Y','Y','N') iscreate_bit,
                        iif(per.isread_bit='Y','Y','N') isread_bit,
                        iif(per.isupdate_bit='Y','Y','N') isupdate_bit,
                        iif(per.isdelete_bit='Y','Y','N') isdelete_bit,
                        iif({2}, 'Y','N') ISFULL_BIT,
                        {0}  resource_type, 'N' is_group,per.id,'{3}' use_create
                        from {1} resGroup
                        inner join dm_nhan_vien nv on 1=1
                        left join per_resource per on resGroup.id=per.resource_id and per.employee_id=nv.id
                        and per.resource_type={0} and per.is_group='N'

                        union

                        select resGroup.name, resGroup.id parent_id,null employee_id, resGroup.id resource_id, dep.id department_id,
                        iif(per.iscreate_bit='Y','Y','N') iscreate_bit,
                        iif(per.isread_bit='Y','Y','N') isread_bit,
                        iif(per.isupdate_bit='Y','Y','N') isupdate_bit,
                        iif(per.isdelete_bit='Y','Y','N') isdelete_bit,
                        iif({2}, 'Y','N') ISFULL_BIT,
                        {0}  resource_type, 'N' is_group,per.id,'{3}' use_create
                        from {1} resGroup
                        inner join department dep on 1=1
                        left join per_resource per on resGroup.id=per.resource_id and per.department_id=dep.id
                        and per.resource_type={0} and per.is_group='N') order by is_group desc, name asc",
                        dataPer.Resource_Type_ID, dataPer.DMTableName_Res, ResFullBit, dataPer.Is_ResUseCreate ? "Y" : "N");
                }
                else
                {
                    sql = string.Format(@"select * from (select resGroup.name, resGroup.id parent_id, nv.id employee_id, resGroup.id resource_id, null department_id,
                        iif(per.iscreate_bit='Y','Y','N') iscreate_bit,
                        iif(per.isread_bit='Y','Y','N') isread_bit,
                        iif(per.isupdate_bit='Y','Y','N') isupdate_bit,
                        iif(per.isdelete_bit='Y','Y','N') isdelete_bit,
                        iif(per.isread_bit='Y' and per.isupdate_bit ='Y' and per.isdelete_bit='Y' and per.iscreate_bit='Y', 'Y','N') ISFULL_BIT,
                        {0}  resource_type, 'Y' is_group,per.id,'Y' use_create
                        from {1} resGroup
                        inner join dm_nhan_vien nv on 1=1
                        left join per_resource per on resGroup.id=per.resource_id and per.employee_id=nv.id
                        and per.resource_type={0} and per.is_group='Y'

                        union

                        select res.name, res.{2} parent_id, nv.id employee_id, res.id resource_id, null department_id,
                        iif(per.iscreate_bit='Y','Y','N') iscreate_bit,
                        iif(per.isread_bit='Y','Y','N') isread_bit,
                        iif(per.isupdate_bit='Y','Y','N') isupdate_bit,
                        iif(per.isdelete_bit='Y','Y','N') isdelete_bit,
                        iif({4}, 'Y','N') ISFULL_BIT,
                        {0}  resource_type, 'N' is_group,per.id,'{5}' use_create
                        from {3} res
                        inner join dm_nhan_vien nv on 1=1
                        left join per_resource per on res.id=per.resource_id and per.employee_id=nv.id
                        and per.resource_type={0} and per.is_group='N'

                        union

                        select resGroup.name, resGroup.id parent_id,null employee_id, resGroup.id resource_id, dep.id department_id,
                        iif(per.iscreate_bit='Y','Y','N') iscreate_bit,
                        iif(per.isread_bit='Y','Y','N') isread_bit,
                        iif(per.isupdate_bit='Y','Y','N') isupdate_bit,
                        iif(per.isdelete_bit='Y','Y','N') isdelete_bit,
                        iif(per.isread_bit='Y' and per.isupdate_bit ='Y' and per.isdelete_bit='Y' and per.iscreate_bit='Y', 'Y','N') ISFULL_BIT,
                       {0} resource_type, 'Y' is_group,per.id,'Y' use_create
                        from {1} resGroup
                        inner join department dep on 1=1
                        left join per_resource per on resGroup.id=per.resource_id and per.department_id=dep.id
                        and per.resource_type={0} and per.is_group='Y'

                        union

                        select res.name, res.{2} parent_id,null employee_id, res.id resource_id, dep.id department_id,
                        iif(per.iscreate_bit='Y','Y','N') iscreate_bit,
                        iif(per.isread_bit='Y','Y','N') isread_bit,
                        iif(per.isupdate_bit='Y','Y','N') isupdate_bit,
                        iif(per.isdelete_bit='Y','Y','N') isdelete_bit,
                        iif({4}, 'Y','N') ISFULL_BIT,
                        {0}  resource_type, 'N' is_group,per.id,'{5}' use_create
                        from {3} res
                        inner join department dep on 1=1
                        left join per_resource per on res.id=per.resource_id and per.department_id=dep.id
                        and per.resource_type= {0} and per.is_group='N')
                        order by is_group desc, name asc",
                        dataPer.Resource_Type_ID, dataPer.DMTableName_ResGroup,
                        dataPer.RefFieldNameDM_Res_ResGroup, dataPer.DMTableName_Res, ResFullBit, dataPer.Is_ResUseCreate ? "Y" : "N");
                }
            }
            if (sql != "")
            {
                DataSet ds = HelpDB.getDatabase().LoadDataSet(sql, "PER_RESOURCE");
                if (ds != null && ds.Tables.Count > 0)
                    return ds.Tables[0];
            }
            return null;
        }
       
        public void InitNguoiDung()
        {
            HelpTreeList.CotTextLeft(ColEmpName, "NAME");
            HelpTreeList.CotCheckEdit(ColIsDepartment, "IS_DEPARTMENT");
            treeListPermission.ParentFieldName = "PARENT_ID";
            treeListPermission.KeyFieldName = "ID";
            ColID.FieldName = "ID";

            string sql = @"select * from
            (select dp.id,dp.parent_id,dp.name,'Y' is_department, dp.id_root
            from department dp
            union
            select nv.id, nv.department_id parent_id,nv.name,'N' is_department,
            (select dep.id_root from department dep where dep.id=nv.department_id) id_root

            from dm_nhan_vien nv where nv.department_id is not null)
            order by is_department desc, name asc";
            dsNguoiDung = HelpDB.getDBService().LoadDataSet(sql);
            if (dsNguoiDung != null && dsNguoiDung.Tables.Count > 0) treeListPermission.DataSource = dsNguoiDung.Tables[0];



        }      
        private void treeListPermission_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            if(xtraTabControlPermission.SelectedTabPage==null) return;
            UCTreeListDataPermission uc = xtraTabControlPermission.SelectedTabPage.Controls[0] as UCTreeListDataPermission;
            Filter(uc.DataSource);

            //if (e.Node == null) return;

            //IsChosingDeparment = e.Node["IS_DEPARTMENT"].ToString() == "Y";

            //SelectedID = HelpNumber.ParseInt64(treeListPermission.FocusedNode["ID"]);
            //SelectedName = treeListPermission.FocusedNode["NAME"].ToString();

            //// SetToolTips();
            ////UpdateLayout();
            //this.SetVisibleTabPage();
           // this.ApplyFilterByDeparment(gridViewDepRes);
            //this.ApplyFilterByEmployee(gridViewEmpRes);
        }
        private void treeListPermission_GetStateImage(object sender, DevExpress.XtraTreeList.GetStateImageEventArgs e)
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
        private void xtraTabControlPermission_SelectedPageChanged(object sender, TabPageChangedEventArgs e)
        {
            LoadData(e.Page);
        }

        bool resultSave = true;
        private void btnLuu_Click(object sender, EventArgs e)
        {
            WaitingMsg.LongProcess(Save);
            if (resultSave == false)
            {
                HelpMsgBox.ShowNotificationMessage("Lưu không thành công!");
            }
            else
            {
                MSSaveSuccess();
            }
        }
        private void Save()
        {
            DbTransaction dbTrans = null;
            DatabaseFB db = null;
            FWTransaction fwTrans = null;
            try
            {
                db = HelpDB.getDatabase();
                dbTrans = FWTransaction.BeginTrans(db);
                fwTrans = FWTransaction.I(db, dbTrans);
                DataTable dtMain = null;
                string typeIds = "";
                List<DataPermission> listDataPers = new List<DataPermission>();
                foreach (XtraTabPage tap in xtraTabControlPermission.TabPages)
                {
                    if (tap.Controls.Count == 0) continue;
                    listDataPers.Add((DataPermission)tap.Tag);
                    UCTreeListDataPermission uc = tap.Controls[0] as UCTreeListDataPermission;
                    DataTable dtTemp = uc.DataSource.Copy();
                    dtTemp.DefaultView.RowFilter = "ISREAD_BIT='Y' OR ISCREATE_BIT='Y' OR ISUPDATE_BIT='Y' OR ISDELETE_BIT='Y'";
                    if (dtMain == null)
                        dtMain = dtTemp.DefaultView.ToTable();
                    else
                    {
                        dtMain.Merge(dtTemp.DefaultView.ToTable());
                    }
                    typeIds += ((DataPermission)tap.Tag).Resource_Type_ID + ",";
                }
                typeIds = typeIds.TrimEnd(',');
                DataSet dsSource = new DataSet();
                if (fwTrans.LoadDataSet(dsSource, "select * from PER_RESOURCE where RESOURCE_TYPE in (" + typeIds + ")", "PER_RESOURCE") == false)
                {
                    FWTransaction.Rollback(dbTrans);
                    resultSave = false;
                    return;

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
                    resultSave = false;
                    return;
                }

                FWTransaction.Commit(dbTrans);
                //try
                //{
                //    foreach (DataPermission per in listDataPers)
                //    {
                //        per.Init();
                //    }
                //}
                //catch
                //{
                //}
                resultSave = true;
            }
            catch
            {
                resultSave = false;
            }
        }

        private void MSSaveSuccess()
        {
            lblMessage.Text = "Đã lưu dữ liệu.";
        }

        private void lblMessage_TextChanged(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            timer1.Stop();
        }   

    }
}
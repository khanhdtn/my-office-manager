using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using ProtocolVN.Framework.Core;
using ProtocolVN.Framework.Win;
using System;

namespace PermissionOfResource
{
   /// <summary>
   /// Lớp abstract định nghĩa tài nguyên cần phân quyền (xây dựng theo PL-Office)
    /// (Ghi chú: Emp: Employee, Dep:Department, Res: Resource, ResGroup: Resource Group)
    /// </summary>
    public abstract class DataPermission
    {
        #region "Variables"
        private long[] _PerRes_CREATE_Ids;
        private long[] _PerRes_READ_Ids;
        private long[] _PerRes_UPDATE_Ids;
        private long[] _PerRes_DELETE_Ids;

        private string _PerRes_CREATE_StrIds;
        private string _PerRes_READ_StrIds;
        private string _PerRes_UPDATE_StrIds;
        private string _PerRes_DELETE_StrIds;

        private long[] _PerResGroup_CREATE_Ids;
        private long[] _PerResGroup_READ_Ids;
        private long[] _PerResGroup_UPDATE_Ids;
        private long[] _PerResGroup_DELETE_Ids;

        private string _PerResGroup_CREATE_StrIds;
        private string _PerResGroup_READ_StrIds;
        private string _PerResGroup_UPDATE_StrIds;
        private string _PerResGroup_DELETE_StrIds;


        private bool _HasResGroup;
        private bool _Is_DM_Tree;
        private bool _Is_ResUseCreate;



        private string _ResName;
        private string _ResGroupName;
        private string _DMTableName_ResGroup = "";
        private string _DMTableName_Res = "";

        private string _RefFieldNameDM_Res_ResGroup;
        private long _Resource_Type_ID = -1;
        private string _Parent_Field = "";

        public string Parent_Field
        {
            get { return _Parent_Field; }
            set { _Parent_Field = value; }
        }

        public bool Is_ResUseCreate
        {
            get { return _Is_ResUseCreate; }
        }

        public bool Is_DM_Tree
        {
            get { return _Is_DM_Tree; }
        }
        public long Resource_Type_ID
        {
            get { return _Resource_Type_ID; }
        }
        private bool isPermission;

        public bool IsPermission
        {
            get { return isPermission; }
            set { this.isPermission = value; }
        }



        /// <summary>
        /// Chuỗi mô tả tên tài nguyên.
        /// </summary>
        public string ResName
        {
            get { return _ResName; }
        }

        /// <summary>
        /// Chuỗi mô tả tên nhóm tài nguyên.
        /// </summary>
        public string ResGroupName
        {
            get { return _ResGroupName; }
            set { _ResGroupName = value; }
        }
        /// <summary>
        /// Tên bảng danh mục nhóm tài nguyên.
        /// </summary>
        public string DMTableName_ResGroup
        {
            get { return _DMTableName_ResGroup; }
        }

        /// <summary>
        /// Tên bảng danh mục tài nguyên.
        /// </summary>
        public string DMTableName_Res
        {
            get { return _DMTableName_Res; }
        }

        /// <summary>
        /// Tên trường dữ liệu tham chiếu giữa danh mục tài nguyên và bảng danh mục nhóm tài nguyên (khóa ngoại).
        /// </summary>
        public string RefFieldNameDM_Res_ResGroup
        {
            get { return _RefFieldNameDM_Res_ResGroup; }
        }



        /// <summary>
        /// Cho biết có phân quyền tài nguyên dạng nhóm và con hay không.
        /// Nếu true phân quyền trên 2 danh mục nhóm và con. False là chỉ phân quyền một danh mục.
        /// </summary>
        public bool HasResGroup
        {
            get { return _HasResGroup; }
            //  set { _HasResGroup = value; }
        }
        #endregion

        #region "Constructor"
        public DataPermission(long resource_Type_ID, string dmTableName_Res, string dmTableName_ResGroup,
            string resName, string resGroupName, string refFieldNameDM_Res_ResGroup, string parent_Field, bool is_ResUseCreate)
        {
            if (resName == null) resName = "";
            if (resGroupName == null) resGroupName = "";
            if (dmTableName_ResGroup == null) dmTableName_ResGroup = "";
            if (dmTableName_Res == null) dmTableName_Res = "";
            if (parent_Field == null) parent_Field = "";

            this._ResName = resName;
            this._ResGroupName = resGroupName;
            this._Resource_Type_ID = resource_Type_ID;
            this._DMTableName_Res = dmTableName_Res;
            if (dmTableName_ResGroup != "")
            {
                this._HasResGroup = true;
                this._DMTableName_ResGroup = dmTableName_ResGroup;
            }
            else
            {
                this._HasResGroup = false;

            }
            if (parent_Field != "")
            {
                this._Is_DM_Tree = true;
                this._Parent_Field = parent_Field;
            }
            else
            {
                this._Is_DM_Tree = false;
            }
            this._Is_ResUseCreate = is_ResUseCreate;
            this._RefFieldNameDM_Res_ResGroup = refFieldNameDM_Res_ResGroup;
            isPermission = CheckApplyPermission();
        }
        public DataPermission(long resource_Type_ID, string dmTableName_Res, string dmTableName_ResGroup,
            string resName, string resGroupName, string refFieldNameDM_Res_ResGroup) :
            this(resource_Type_ID, dmTableName_Res, dmTableName_ResGroup, resName, resGroupName, refFieldNameDM_Res_ResGroup, "", false)
        {

        }
        public DataPermission(long resource_Type_ID, string dmTableName_Res, string dmTableName_ResGroup,
            string resName, string resGroupName, string refFieldNameDM_Res_ResGroup, string parent_Field) :
            this(resource_Type_ID, dmTableName_Res, dmTableName_ResGroup, resName, resGroupName, refFieldNameDM_Res_ResGroup, parent_Field, false)
        {
        }
        #endregion

        #region "Privarte Methods"



        /// <summary>
        /// Kiểm tra xem có áp dụng phân quyền với người dùng hiện hành hay không.
        /// </summary>
        /// <returns></returns>
        private bool CheckApplyPermission()
        {
            DataSet ds = new DataSet();

            if (FrameworkParams.currentUser.username == "admin")
            {
                //Không áp dụng phân quyền với admin
                return false;
            }

            return true;


        }

        private string GetFieldPermission(RES_PERMISSION_TYPE per_type)
        {
            switch (per_type)
            {
                case RES_PERMISSION_TYPE.CREATE:
                    return "ISCREATE_BIT";
                case RES_PERMISSION_TYPE.READ:
                    return "ISREAD_BIT";
                case RES_PERMISSION_TYPE.UPDATE:
                    return "ISUPDATE_BIT";
                case RES_PERMISSION_TYPE.DELETE:
                    return "ISDELETE_BIT";
                default:
                    return "ISREAD_BIT";
            }
        }

        /// <summary>
        /// Lấy ID nhóm tài nguyên
        /// </summary>
        /// <param name="ResID">ID tài nguyên</param>
        /// <returns></returns>
        private long GetResGroupID(long ResID)
        {
            if (_HasResGroup == false)
                throw new Exception("Hàm này chỉ dành cho phân quyền dạng chứa nhóm tài nguyên!");
            try
            {

                DatabaseFB db = HelpDB.getDatabase();
                DbCommand cmd_Get = db.GetSQLStringCommand(
                    "select ntn.id from " + this._DMTableName_ResGroup + " ntn inner join "
                    + this._DMTableName_Res + " tn on ntn.id=tn." + this._RefFieldNameDM_Res_ResGroup
                    + " where tn.id=" + ResID);
                return HelpNumber.ParseInt64(db.ExecuteScalar(cmd_Get));
            }
            catch
            {
                return -1;
            }
        }


        /// <summary>
        /// Lấy phòng ban của một nhân viên và các phòng ban cha của phòng ban đó
        /// </summary>
        /// <param name="Employee_ID"></param>
        /// <returns></returns>
        private string GetDepartmentIDs(long Employee_ID)
        {
            FWDBService db = HelpDB.getDBService();
            DbCommand cmd = db.GetSQLStringCommand(string.Format(
                          @"select department_id from dm_nhan_vien where id ={0}", Employee_ID));
            object department_id = db.ExecuteScalar(cmd);
            if (department_id == null) return "-1";
            return department_id + "," + GetDeparmentParentStrIDs(HelpNumber.ParseInt64(department_id));
        }

        /// <summary>
        /// Lấy chuỗi ID phòng ban cha của một phòng ban
        /// </summary>
        /// <param name="Department_ID"></param>
        /// <returns></returns>
        private string GetDeparmentParentStrIDs(long Department_ID)
        {
            string sql = @"Select * from department";
            DataSet ds = HelpDB.getDBService().LoadDataSet(sql);
            if (ds == null || ds.Tables.Count == 0) return "-1";
            DataTable dtDeparment = ds.Tables[0];
            dtDeparment.PrimaryKey = new DataColumn[] { dtDeparment.Columns["ID"] };
            string depParentStrIDs = "";
            DataRow rFind = null;
            while (1 == 1)
            {
                rFind = dtDeparment.Rows.Find(Department_ID);
                if (rFind == null || rFind["PARENT_ID"] is DBNull)
                    break;
                Department_ID = HelpNumber.ParseInt64(rFind["PARENT_ID"]);
                depParentStrIDs += Department_ID + ",";
            }
            if (depParentStrIDs == "") return "-1";
            return depParentStrIDs.TrimEnd(',');
        }
        private bool _checkPermissionResGroup(long Employee_ID, long ResGroupID, string DeparmentIDs, RES_PERMISSION_TYPE per_type)
        {
            if (_HasResGroup == false)
                throw new Exception("Hàm này chỉ dành cho phân quyền dạng có chứa nhóm tài nguyên!");
            try
            {
                if (DeparmentIDs == null) DeparmentIDs = this.GetDepartmentIDs(Employee_ID);
                string sql = string.Format(@"select per.id
                    from per_resource per
                    where per.resource_type={0} and per.resource_id={1} and per.is_group='Y' and per.{2}='Y'
                    and (per.employee_id= {3} or per.department_id in ({4}))",
                     this._Resource_Type_ID, ResGroupID, GetFieldPermission(per_type),
                     Employee_ID, DeparmentIDs);
                DataSet ds = HelpDB.getDBService().LoadDataSet(sql);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    return true;
                return false;
            }
            catch
            {
                return false;
            }
        }
        private bool ExistLong(long[] longArrays, long value)
        {
            if (longArrays == null || longArrays.Length == 0) return false;
            foreach (long l in longArrays)
            {
                if (l == value)
                    return true;
            }
            return false;
        }
        #endregion

        #region "Public Methods"
        /// <summary>
        /// Khởi tạo dữ liệu ban đầu
        /// </summary>
        public void Init()
        {
           // isPermission = CheckApplyPermission();
            if (isPermission)
            {
                //Nạp thông tin phân quyền trên tài nguyên cho người dùng hiện hành
                _PerRes_CREATE_StrIds = _getPermissionResStrIDs(
                    FrameworkParams.currentUser.employee_id, RES_PERMISSION_TYPE.CREATE);
                _PerRes_READ_StrIds = _getPermissionResStrIDs(
                    FrameworkParams.currentUser.employee_id, RES_PERMISSION_TYPE.READ);
                _PerRes_UPDATE_StrIds = _getPermissionResStrIDs(
                    FrameworkParams.currentUser.employee_id, RES_PERMISSION_TYPE.UPDATE);
                _PerRes_DELETE_StrIds = _getPermissionResStrIDs(
                    FrameworkParams.currentUser.employee_id, RES_PERMISSION_TYPE.DELETE);

                if (_PerRes_CREATE_StrIds != "")
                    _PerRes_CREATE_Ids = Array.ConvertAll<string, long>(_PerRes_CREATE_StrIds.Split(',')
                        , HelpNumber.ParseInt64);
                else _PerRes_CREATE_Ids = new long[0];

                if (_PerRes_READ_StrIds != "")
                    _PerRes_READ_Ids = Array.ConvertAll<string, long>(_PerRes_READ_StrIds.Split(',')
                            , HelpNumber.ParseInt64);
                else _PerRes_READ_Ids = new long[0];

                if (_PerRes_UPDATE_StrIds != "")
                    _PerRes_UPDATE_Ids = Array.ConvertAll<string, long>(_PerRes_UPDATE_StrIds.Split(',')
                                , HelpNumber.ParseInt64);
                else _PerRes_UPDATE_Ids = new long[0];

                if (_PerRes_DELETE_StrIds != "")
                    _PerRes_DELETE_Ids = Array.ConvertAll<string, long>(_PerRes_DELETE_StrIds.Split(',')
                                    , HelpNumber.ParseInt64);
                else _PerRes_DELETE_Ids = new long[0];
                if (this._HasResGroup)
                {
                    //Nạp thông tin phân quyền trên nhóm tài nguyên cho người dùng hiện hành

                    _PerResGroup_CREATE_StrIds = _getPermissionResGroupStrIDs(
                           FrameworkParams.currentUser.employee_id, RES_PERMISSION_TYPE.CREATE);
                    _PerResGroup_READ_StrIds = _getPermissionResGroupStrIDs(
                                   FrameworkParams.currentUser.employee_id, RES_PERMISSION_TYPE.READ);
                    _PerResGroup_UPDATE_StrIds = _getPermissionResGroupStrIDs(
                                    FrameworkParams.currentUser.employee_id, RES_PERMISSION_TYPE.UPDATE);
                    _PerResGroup_DELETE_StrIds = _getPermissionResGroupStrIDs(
                                    FrameworkParams.currentUser.employee_id, RES_PERMISSION_TYPE.DELETE);

                    if (_PerResGroup_CREATE_StrIds != "")
                        _PerResGroup_CREATE_Ids = Array.ConvertAll<string, long>(_PerResGroup_CREATE_StrIds.Split(',')
                            , HelpNumber.ParseInt64);
                    else _PerResGroup_CREATE_Ids = new long[0];

                    if (_PerResGroup_READ_StrIds != "")
                        _PerResGroup_READ_Ids = Array.ConvertAll<string, long>(_PerResGroup_READ_StrIds.Split(',')
                                , HelpNumber.ParseInt64);
                    else _PerResGroup_READ_Ids = new long[0];

                    if (_PerResGroup_UPDATE_StrIds != "")
                        _PerResGroup_UPDATE_Ids = Array.ConvertAll<string, long>(_PerResGroup_UPDATE_StrIds.Split(',')
                                    , HelpNumber.ParseInt64);
                    else _PerResGroup_UPDATE_Ids = new long[0];

                    if (_PerResGroup_DELETE_StrIds != "")
                        _PerResGroup_DELETE_Ids = Array.ConvertAll<string, long>(_PerResGroup_DELETE_StrIds.Split(',')
                                        , HelpNumber.ParseInt64);
                    else _PerResGroup_DELETE_Ids = new long[0];
                }
                else
                {
                    _PerResGroup_CREATE_StrIds = "";
                    _PerResGroup_READ_StrIds = "";
                    _PerResGroup_UPDATE_StrIds = "";
                    _PerResGroup_DELETE_StrIds = "";
                }

            }
        }

        #region Check Permission

        /// <summary>
        /// Kiểm tra người dùng hiện hành có quyền trên 1 tài nguyên cụ thể hay không.
        /// </summary>
        /// <param name="ResID">ID tài nguyên</param>
        /// <param name="per_type">Loại quyền</param>
        /// <returns></returns>            
        public bool _checkPermissionRes(long ResID, RES_PERMISSION_TYPE per_type)
        {
            if (isPermission == false) return true;
            switch (per_type)
            {
                case RES_PERMISSION_TYPE.CREATE:
                    return ExistLong(this._PerRes_CREATE_Ids, ResID);
                case RES_PERMISSION_TYPE.DELETE:
                    return ExistLong(this._PerRes_DELETE_Ids, ResID);
                case RES_PERMISSION_TYPE.READ:
                    return ExistLong(this._PerRes_READ_Ids, ResID);
                case RES_PERMISSION_TYPE.UPDATE:
                    return ExistLong(this._PerRes_UPDATE_Ids, ResID);
            }
            return false;
        }

        /// <summary>
        /// Kiểm tra người dùng chỉ định có quyền trên 1 tài nguyên cụ thể hay không.
        /// </summary>
        /// <param name="UserID">ID người dùng</param>
        /// <param name="ResID">ID tài nguyên</param>
        /// <param name="per_type">Loại quyền</param>
        /// <returns></returns>
        public bool _checkPermissionRes(long Employee_ID, long ResID, RES_PERMISSION_TYPE per_type)
        {
            try
            {
                if (this.DMTableName_Res == "")
                {
                    throw new Exception("Hàm này chỉ dành cho phân quyền có chứa tài nguyên!");
                }
                string deparmentIDs = this.GetDepartmentIDs(Employee_ID);
                string sql = string.Format(@"select per.id
                    from per_resource per
                    where per.resource_type={0} and per.resource_id={1} and per.is_group='N' and per.{2}='Y'
                    and (per.employee_id= {3} or per.department_id in ({4}))",
                       this._Resource_Type_ID, ResID, GetFieldPermission(per_type),
                       Employee_ID, deparmentIDs);

                DataSet ds = HelpDB.getDBService().LoadDataSet(sql);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    return true;
                else if (_HasResGroup && _checkPermissionResGroup(Employee_ID, GetResGroupID(ResID), deparmentIDs, per_type))
                    return true;
                return false;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Kiểm tra người dùng hiện hành có quyền trên 1 nhóm tài nguyên cụ thể hay không.
        /// </summary>
        /// <param name="ResGroupID">ID nhóm tài nguyên</param>
        /// <param name="per_type">Loại quyền</param>
        /// <returns></returns>
        public bool _checkPermissionResGroup(long ResGroupID, RES_PERMISSION_TYPE per_type)
        {
            if (_HasResGroup == false)
                throw new Exception("Hàm này chỉ dành cho phân quyền dạng nhóm tài nguyên và tài nguyên");
            if (isPermission == false) return true;
            switch (per_type)
            {
                case RES_PERMISSION_TYPE.CREATE:
                    return ExistLong(this._PerResGroup_CREATE_Ids, ResGroupID);
                case RES_PERMISSION_TYPE.DELETE:
                    return ExistLong(this._PerResGroup_DELETE_Ids, ResGroupID);
                case RES_PERMISSION_TYPE.READ:
                    return ExistLong(this._PerResGroup_READ_Ids, ResGroupID);
                case RES_PERMISSION_TYPE.UPDATE:
                    return ExistLong(this._PerResGroup_UPDATE_Ids, ResGroupID);

            }
            return false;
        }

        /// <summary>
        /// Kiểm tra người dùng chỉ định có quyền trên 1 nhóm tài nguyên cụ thể hay không.
        /// </summary>
        /// <param name="UserID">ID người dùng</param>
        /// <param name="ResGroupID">ID nhóm tài nguyên</param>
        /// <param name="per_type">Loại quyền</param>
        /// <returns></returns>
        public bool _checkPermissionResGroup(long Employee_ID, long ResGroupID, RES_PERMISSION_TYPE per_type)
        {
            if (_HasResGroup == false)
                throw new Exception("Hàm này chỉ dành cho phân quyền dạng nhóm tài nguyên và tài nguyên");
            return this._checkPermissionResGroup(Employee_ID, ResGroupID, null, per_type);
        }
        #endregion

        #region Get Permission IDs

        /// <summary>
        /// Trả về danh sách tài nguyên theo ID mà người dùng hiện hành có quyền.
        /// </summary>
        /// <param name="per_type">Loại quyền</param>
        /// <returns></returns>
        public long[] _getPermissionResIDs(RES_PERMISSION_TYPE per_type)
        {
            switch (per_type)
            {
                case RES_PERMISSION_TYPE.CREATE:
                    return _PerRes_CREATE_Ids;
                case RES_PERMISSION_TYPE.READ:
                    return _PerRes_READ_Ids;
                case RES_PERMISSION_TYPE.UPDATE:
                    return _PerRes_UPDATE_Ids;
                case RES_PERMISSION_TYPE.DELETE:
                    return _PerRes_DELETE_Ids;
                default:
                    return _PerRes_READ_Ids;
            }
        }

        /// <summary>
        /// Trả về chuỗi danh sách tài nguyên theo ID mà người dùng hiện hành có quyền.
        /// </summary>
        /// <param name="per_type">Loại quyền</param>
        /// <returns></returns>
        public string _getPermissionResStrIDs(RES_PERMISSION_TYPE per_type)
        {
            switch (per_type)
            {
                case RES_PERMISSION_TYPE.CREATE:
                    return _PerRes_CREATE_StrIds;
                case RES_PERMISSION_TYPE.READ:
                    return _PerRes_READ_StrIds;
                case RES_PERMISSION_TYPE.UPDATE:
                    return _PerRes_UPDATE_StrIds;
                case RES_PERMISSION_TYPE.DELETE:
                    return _PerRes_DELETE_StrIds;
                default:
                    return _PerRes_READ_StrIds;
            }
        }

        /// <summary>
        /// Trả về danh sách tài nguyên theo ID mà người dùng chỉ định có quyền.
        /// </summary>
        /// <param name="UserID">ID người dùng</param>
        /// <param name="per_type">Loại quyền</param>
        /// <returns></returns>
        public long[] _getPermissionResIDs(long Employee_ID, RES_PERMISSION_TYPE per_type)
        {
            try
            {
                string strIds = _getPermissionResStrIDs(Employee_ID, per_type);
                if (strIds == "") return null;
                return Array.ConvertAll<string, long>(strIds.Split(','), HelpNumber.ParseInt64);

            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Trả về chuỗi danh sách tài nguyên theo ID mà người dùng chỉ định có quyền.
        /// </summary>
        /// <param name="UserID">ID người dùng</param>
        /// <param name="per_type">Loại quyền</param>
        /// <returns></returns>
        public string _getPermissionResStrIDs(long Employee_ID, RES_PERMISSION_TYPE per_type)
        {
            try
            {
                if (this.DMTableName_Res == "")
                {
                    throw new Exception("Hàm này chỉ dành cho phân quyền có chứa tài nguyên!");
                }
                string deparmentIDs = this.GetDepartmentIDs(Employee_ID);
                string sql = "";

                if (_HasResGroup)
                {
                    sql = string.Format(@" select list(resource_id,',') from (select id resource_id
                        from {0} res
                        where res.{1} in( select per.resource_id
                                                        from per_resource per
                                                        where per.resource_type={2} and per.is_group='Y' and per.{3}='Y'
                                                        and (per.employee_id= {4} or per.department_id in ({5})))
                        union

                        select per.resource_id
                        from per_resource per
                        where per.resource_type={2} and per.is_group='N' and per.{3}='Y'
                        and (per.employee_id= {4} or per.department_id in ({5})))",
                        this._DMTableName_Res, this._RefFieldNameDM_Res_ResGroup, this._Resource_Type_ID, GetFieldPermission(per_type),
                        Employee_ID, deparmentIDs
                        );
                }
                else
                {
                    sql = string.Format(@"select list(distinct per.resource_id,',')
                                        from per_resource per
                                        where per.resource_type={0} and per.is_group='N' and per.{1}='Y'
                                        and (per.employee_id= {2} or per.department_id in ({3}))",
                                         _Resource_Type_ID, GetFieldPermission(per_type), Employee_ID, deparmentIDs);
                }

                FWDBService dbRes = HelpDB.getDBService();
                DbCommand cmdRes = dbRes.GetSQLStringCommand(sql);
                object resIDs = dbRes.ExecuteScalar(cmdRes);
                if (resIDs != null)
                    return resIDs.ToString();
                return "";
            }
            catch
            {
                return "";
            }
        }

        /// <summary>
        /// Trả về danh sách nhóm tài nguyên theo ID mà người dùng hiện hành có quyền.
        /// </summary>
        /// <param name="per_type">Loại quyền</param>
        /// <returns></returns>
        public long[] _getPermissionResGroupIDs(RES_PERMISSION_TYPE per_type)
        {
            if (_HasResGroup == false)
                throw new Exception("Hàm này chỉ dành cho phân quyền dạng nhóm tài nguyên và tài nguyên");
            switch (per_type)
            {
                case RES_PERMISSION_TYPE.CREATE:
                    return _PerResGroup_CREATE_Ids;
                case RES_PERMISSION_TYPE.READ:
                    return _PerResGroup_READ_Ids;
                case RES_PERMISSION_TYPE.UPDATE:
                    return _PerResGroup_UPDATE_Ids;
                case RES_PERMISSION_TYPE.DELETE:
                    return _PerResGroup_DELETE_Ids;
                default:
                    return _PerResGroup_READ_Ids;
            }
        }

        /// <summary>
        /// Trả về chuỗi danh sách nhóm tài nguyên theo ID mà người dùng hiện hành có quyền.
        /// </summary>
        /// <param name="per_type">Loại quyền</param>
        /// <returns></returns>
        public string _getPermissionResGroupStrIDs(RES_PERMISSION_TYPE per_type)
        {
            if (_HasResGroup == false)
                throw new Exception("Hàm này chỉ dành cho phân quyền dạng nhóm tài nguyên và tài nguyên");
            switch (per_type)
            {
                case RES_PERMISSION_TYPE.CREATE:
                    return _PerResGroup_CREATE_StrIds;
                case RES_PERMISSION_TYPE.READ:
                    return _PerResGroup_READ_StrIds;
                case RES_PERMISSION_TYPE.UPDATE:
                    return _PerResGroup_UPDATE_StrIds;
                case RES_PERMISSION_TYPE.DELETE:
                    return _PerResGroup_DELETE_StrIds;
                default:
                    return _PerResGroup_READ_StrIds;
            }
        }

        /// <summary>
        /// Trả về danh sách nhóm tài nguyên theo ID mà người dùng chỉ định có quyền.
        /// </summary>
        /// <param name="UserID">ID người dùng</param>
        /// <param name="per_type">Loại quyền</param>
        /// <returns></returns>
        public long[] _getPermissionResGroupIDs(long Employee_ID, RES_PERMISSION_TYPE per_type)
        {
            if (_HasResGroup == false)
                throw new Exception("Hàm này chỉ dành cho phân quyền dạng nhóm tài nguyên và tài nguyên");
            try
            {
                string strIds = _getPermissionResGroupStrIDs(Employee_ID, per_type);
                if (strIds == "") return null;
                return Array.ConvertAll<string, long>(strIds.Split(','), HelpNumber.ParseInt64);
            }
            catch
            {
                return null;
            }

        }

        /// <summary>
        /// Trả về chuỗi danh sách nhóm tài nguyên theo ID mà người dùng chỉ định có quyền.
        /// </summary>
        /// <param name="UserID">ID người dùng</param>
        /// <param name="per_type">Loại quyền</param>
        /// <returns></returns>
        public string _getPermissionResGroupStrIDs(long Employee_ID, RES_PERMISSION_TYPE per_type)
        {
            if (_HasResGroup == false)
                throw new Exception("Hàm này chỉ dành cho phân quyền dạng nhóm tài nguyên và tài nguyên");
            try
            {
                string deparmentIDs = this.GetDepartmentIDs(Employee_ID);
                string sql = string.Format(@"select list(distinct per.resource_id,',')
                                        from per_resource per
                                        where per.resource_type={0} and per.is_group='Y' and per.{1}='Y'
                                        and (per.employee_id= {2} or per.department_id in ({3}))",
                                          _Resource_Type_ID, GetFieldPermission(per_type), Employee_ID, deparmentIDs);

                FWDBService dbResGroup = HelpDB.getDBService();
                DbCommand cmdResGroup = dbResGroup.GetSQLStringCommand(sql);
                object resGroupIDs = dbResGroup.ExecuteScalar(cmdResGroup);
                if (resGroupIDs != null)
                    return resGroupIDs.ToString();
                return "";
            }
            catch
            {
                return "";
            }
        }
        #endregion

        #region Load dataset

        #region Res

        public DataSet _LoadDataSetWithResPermission(QueryBuilder query, string tableName, string KeyFieldRes)
        {
            if (isPermission)
            {
                if (_PerRes_READ_StrIds != "")
                {
                    query.addCondition(KeyFieldRes + " in (" + _PerRes_READ_StrIds + ")");
                }
                else
                {

                    query.addCondition("-1=1");

                }
            }
            return DABase.getDatabase().LoadDataSet(query, (tableName == null || tableName == "" ? "NO_NAME" : tableName));
        }
        public DataSet _LoadDataSetWithResPermission(QueryBuilder query, string KeyFieldRes)
        {
            return _LoadDataSetWithResPermission(query, "", KeyFieldRes);
        }
        public DataSet _LoadDataSetWithResPermission(QueryBuilder query, string tableName, string KeyFieldRes, long ResID)
        {
            if (isPermission)
            {

                if (_PerRes_READ_Ids != null && _PerRes_READ_Ids.Length > 0)
                {
                    if (ResID != -1)
                    {
                        bool IsPerMit = false;
                        foreach (long ID in _PerRes_READ_Ids)
                        {
                            if (ID == ResID)
                            {
                                IsPerMit = true;
                                break;
                            }

                        }
                        if (IsPerMit)
                            query.addID(KeyFieldRes, ResID);
                        else query.addCondition("-1=1");
                    }
                    else
                    {
                        query.addID(KeyFieldRes, _PerRes_READ_Ids);
                    }
                }
                else
                {
                    query.addCondition("-1=1");
                }

            }
            else
            {
                query.addID(KeyFieldRes, ResID);
            }
            return DABase.getDatabase().LoadDataSet(query, (tableName == null || tableName == "" ? "NO_NAME" : tableName));
        }
        public DataSet _LoadDataSetWithResPermission(QueryBuilder query, string KeyFieldRes, long ResID)
        {
            return _LoadDataSetWithResPermission(query, "", KeyFieldRes, ResID);
        }

        public DataSet _LoadDataSetWithResPermission(string queryStr, string tableName, string KeyFieldRes)
        {
            if (isPermission)
            {
                // string filter_str = _PerRes_READ_StrIds;
                if (_PerRes_READ_StrIds != "")
                    queryStr += " and " + KeyFieldRes + " in (" + _PerRes_READ_StrIds + ")";
                else
                {
                    queryStr += " and -1=1";
                }
            }
            DataSet dataSet = new DataSet();
            if (DABase.getDatabase().LoadDataSet(dataSet, queryStr, (tableName == null || tableName == "" ? "NO_NAME" : tableName)))
            {
                return dataSet;
            }
            return null;
        }
        public DataSet _LoadDataSetWithResPermission(string queryStr, string KeyFieldRes)
        {
            return _LoadDataSetWithResPermission(queryStr, "", KeyFieldRes);
        }
        public DataSet _LoadDataSetWithResPermission(string queryStr, string tableName, string KeyFieldRes, long ResID)
        {
            if (isPermission)
            {

                if (_PerRes_READ_Ids != null && _PerRes_READ_Ids.Length > 0)
                {
                    if (ResID != -1)
                    {
                        bool IsPerMit = false;
                        foreach (long ID in _PerRes_READ_Ids)
                        {
                            if (ID == ResID)
                            {
                                IsPerMit = true;
                                break;
                            }

                        }
                        if (IsPerMit)
                            queryStr += " and " + KeyFieldRes + " = " + ResID;
                        else
                        {
                            queryStr += " and -1=1";
                        }
                    }
                    else
                    {
                        queryStr += " and " + KeyFieldRes + "in( " + _PerRes_READ_Ids + ")";
                    }
                }
                else
                {
                    queryStr += " and -1=1";
                }

            }
            else
            {
                if (ResID != -1)
                    queryStr += " and " + KeyFieldRes + " = " + ResID;
            }
            DataSet dataSet = new DataSet();
            if (DABase.getDatabase().LoadDataSet(dataSet, queryStr, (tableName == null || tableName == "" ? "NO_NAME" : tableName)))
            {
                return dataSet;
            }
            return null;
        }
        public DataSet _LoadDataSetWithResPermission(string queryStr, string KeyFieldRes, long ResID)
        {
            return _LoadDataSetWithResPermission(queryStr, "", KeyFieldRes, ResID);
        }
        public bool _LoadDataSetWithResPermission(DataSet ds, string tableName, string KeyFieldRes, long ResID)
        {
            if (ds == null)
            {
                return false;
            }
            try
            {
                QueryBuilder query = new QueryBuilder("SELECT * FROM " + tableName + " WHERE  1=1");
                if (isPermission)
                {

                    if (_PerRes_READ_Ids != null && _PerRes_READ_Ids.Length > 0)
                    {
                        if (ResID != -1)
                        {
                            bool isPerMis = false;
                            foreach (long id in _PerRes_READ_Ids)
                            {
                                if (id == ResID)
                                {
                                    isPerMis = true;
                                    break;
                                }
                            }
                            if (isPerMis)
                                query.addID(KeyFieldRes, ResID);
                            else query.addCondition("1=-1");
                        }
                        else
                        {
                            query.addID(KeyFieldRes, _PerRes_READ_Ids);
                        }
                    }
                    else
                    {
                        query.addCondition("1=-1");
                    }

                }
                else
                {
                    if (ResID != -1)
                        query.addID(KeyFieldRes, ResID);
                }

                return DABase.getDatabase().LoadDataSet(query, tableName, ds);
            }
            catch (Exception exception)
            {
                PLException.AddException(exception);
                return false;
            }
        }

        public bool _LoadResDataSetWithPermission(DataSet ds, string KeyFieldRes, long ResID)
        {
            return _LoadDataSetWithResPermission(ds, this.DMTableName_Res, KeyFieldRes, ResID);
        }
        public DataSet _LoadResDataSetWithPermission(string KeyFieldRes, long ResID)
        {
            DataSet ds = new DataSet();
            if (_LoadResDataSetWithPermission(ds, KeyFieldRes, ResID))
                return ds;
            return null;
        }
        #endregion

        #region Res Group

        public DataSet _LoadDataSetWithResGroupPermission(QueryBuilder query, string tableName, string KeyFieldResGroup)
        {
            if (isPermission)
            {
                if (_PerResGroup_READ_StrIds != "")
                {
                    query.addCondition(KeyFieldResGroup + " in (" + _PerResGroup_READ_StrIds + ")");
                }
                else
                {

                    query.addCondition("-1=1");

                }
            }
            return DABase.getDatabase().LoadDataSet(query, (tableName == null || tableName == "" ? "NO_NAME" : tableName));
        }
        public DataSet _LoadDataSetWithResGroupPermission(QueryBuilder query, string KeyFieldResGroup)
        {
            return _LoadDataSetWithResGroupPermission(query, "", KeyFieldResGroup);
        }
        public DataSet _LoadDataSetWithResGroupPermission(QueryBuilder query, string tableName, string KeyFieldResGroup, long ResGroupID)
        {
            if (isPermission)
            {

                if (_PerResGroup_READ_Ids != null && _PerResGroup_READ_Ids.Length > 0)
                {
                    if (ResGroupID != -1)
                    {
                        bool IsPerMit = false;
                        foreach (long ID in _PerResGroup_READ_Ids)
                        {
                            if (ID == ResGroupID)
                            {
                                IsPerMit = true;
                                break;
                            }
                        }
                        if (IsPerMit)
                            query.addID(KeyFieldResGroup, ResGroupID);
                        else query.addCondition("-1=1");
                    }
                    else
                    {
                        query.addID(KeyFieldResGroup, _PerResGroup_READ_Ids);
                    }
                }
                else
                {
                    query.addCondition("-1=1");
                }

            }
            else
            {
                query.addID(KeyFieldResGroup, ResGroupID);
            }
            return DABase.getDatabase().LoadDataSet(query, (tableName == null || tableName == "" ? "NO_NAME" : tableName));
        }
        public DataSet _LoadDataSetWithResGroupPermission(QueryBuilder query, string KeyFieldResGroup, long ResGroupID)
        {
            return _LoadDataSetWithResGroupPermission(query, "", KeyFieldResGroup, ResGroupID);
        }

        public DataSet _LoadDataSetWithResGroupPermission(string queryStr, string tableName, string KeyFieldResGroup)
        {
            if (isPermission)
            {
                // string filter_str = _PerRes_READ_StrIds;
                if (_PerResGroup_READ_StrIds != "")
                    queryStr += " and " + KeyFieldResGroup + " in (" + _PerResGroup_READ_StrIds + ")";
                else
                {
                    queryStr += " and -1=1";
                }
            }
            DataSet dataSet = new DataSet();
            if (DABase.getDatabase().LoadDataSet(dataSet, queryStr, (tableName == null || tableName == "" ? "NO_NAME" : tableName)))
            {
                return dataSet;
            }
            return null;
        }
        public DataSet _LoadDataSetWithResGroupPermission(string queryStr, string KeyFieldResGroup)
        {
            return _LoadDataSetWithResGroupPermission(queryStr, "", KeyFieldResGroup);
        }
        public DataSet _LoadDataSetWithResGroupPermission(string queryStr, string tableName, string KeyFieldResGroup, long ResGroupID)
        {
            if (isPermission)
            {

                if (_PerResGroup_READ_Ids != null && _PerResGroup_READ_Ids.Length > 0)
                {
                    if (ResGroupID != -1)
                    {
                        bool IsPerMit = false;
                        foreach (long ID in _PerResGroup_READ_Ids)
                        {
                            if (ID == ResGroupID)
                            {
                                IsPerMit = true;
                                break;
                            }

                        }
                        if (IsPerMit)
                            queryStr += " and " + KeyFieldResGroup + " = " + ResGroupID;
                        else
                        {
                            queryStr += " and -1=1";
                        }
                    }
                    else
                    {
                        queryStr += " and " + KeyFieldResGroup + " in( " + _PerResGroup_READ_StrIds + ")";
                    }
                }
                else
                {
                    queryStr += " and -1=1";
                }

            }
            else
            {
                if (ResGroupID != -1)
                    queryStr += " and " + KeyFieldResGroup + " = " + ResGroupID;
            }
            DataSet dataSet = new DataSet();
            if (DABase.getDatabase().LoadDataSet(dataSet, queryStr, (tableName == null || tableName == "" ? "NO_NAME" : tableName)))
            {
                return dataSet;
            }
            return null;
        }
        public DataSet _LoadDataSetWithResGroupPermission(string queryStr, string KeyFieldResGroup, long ResGroupID)
        {
            return _LoadDataSetWithResGroupPermission(queryStr, "", KeyFieldResGroup, ResGroupID);
        }
        public bool _LoadDataSetWithResGroupPermission(DataSet ds, string tableName, string KeyFieldRes, long ResGroupID)
        {
            if (ds == null)
            {
                return false;
            }
            try
            {
                QueryBuilder query = new QueryBuilder("SELECT * FROM " + tableName + "where 1=1");
                if (isPermission)
                {
                    if (_PerResGroup_READ_Ids != null && _PerResGroup_READ_Ids.Length > 0)
                    {
                        if (ResGroupID != -1)
                        {
                            bool isPerMis = false;
                            foreach (long id in _PerResGroup_READ_Ids)
                            {
                                if (id == ResGroupID)
                                {
                                    isPerMis = true;
                                    break;
                                }
                            }
                            if (isPerMis)
                                query.addID(KeyFieldRes, ResGroupID);
                            else query.addCondition("1=-1");
                        }
                        else
                        {
                            query.addID(KeyFieldRes, _PerResGroup_READ_Ids);
                        }
                    }
                    else
                    {
                        query.addCondition("1=-1");
                    }
                }
                else
                {
                    if (ResGroupID != -1)
                        query.addID(KeyFieldRes, ResGroupID);
                }
                return DABase.getDatabase().LoadDataSet(query, tableName, ds);
            }
            catch (Exception exception)
            {
                PLException.AddException(exception);
                return false;
            }
        }

        public bool _LoadResGroupDataSetWithPermission(DataSet ds, string KeyFieldRes, long ResGroupID)
        {
            return _LoadDataSetWithResGroupPermission(ds, this.DMTableName_ResGroup, KeyFieldRes, ResGroupID);
        }
        public DataSet _LoadResGroupDataSetWithPermission(string KeyFieldRes, long ResGroupID)
        {
            DataSet ds = new DataSet();
            if (_LoadResGroupDataSetWithPermission(ds, KeyFieldRes, ResGroupID))
                return ds;
            return null;
        }
        #endregion

        #endregion

        public bool InsertPermis(long ResourceID, bool IsGroup, long DepartmentID, long EmployeeID,
            bool IsRead, bool IsCreate, bool IsUpdate, bool IsDelete)
        {
            if (IsCreate || IsRead || IsUpdate || IsDelete)
            {
                DatabaseFB db = null;
                DbTransaction dbTrans = null;
                try
                {
                    db = HelpDB.getDatabase();
                    dbTrans = FWTransaction.BeginTrans(db);
                    string sql = string.Format(@"select ID 
                                        from PER_RESOURCE
                                        where DEPARTMENT_ID {0} and EMPLOYEE_ID {1} and RESOURCE_ID ={2} and RESOURCE_TYPE={3} and IS_GROUP='{4}'",
                                            (DepartmentID > -1 ? "=" + DepartmentID : "IS NULL"), (EmployeeID > -1 ? "=" + EmployeeID : "IS NULL"),
                                            ResourceID, this._Resource_Type_ID, IsGroup ? "Y" : "N");
                    DbCommand cmdCheck = db.GetSQLStringCommand(sql);
                    object obj = db.ExecuteScalar(cmdCheck, dbTrans);
                    if (HelpNumber.ParseInt64(obj) > 0) return false;

                    long ID = db.GetID("G_FW_ID", dbTrans);
                    DbCommand cmd = db.GetSQLStringCommand(@"INSERT INTO 
                    PER_RESOURCE (ID,DEPARTMENT_ID,EMPLOYEE_ID,RESOURCE_ID,RESOURCE_TYPE,ISCREATE_BIT,ISREAD_BIT,ISUPDATE_BIT,ISDELETE_BIT,IS_GROUP)
                    VALUES( @ID,@DEPARTMENT_ID,@EMPLOYEE_ID,@RESOURCE_ID,@RESOURCE_TYPE,@ISCREATE_BIT,@ISREAD_BIT,@ISUPDATE_BIT,@ISDELETE_BIT,@IS_GROUP)");

                    db.AddInParameter(cmd, "@ID", DbType.Int64, ID);
                    db.AddInParameter(cmd, "@DEPARTMENT_ID", DbType.Int64, (DepartmentID > -1 ? (object)DepartmentID : DBNull.Value));
                    db.AddInParameter(cmd, "@EMPLOYEE_ID", DbType.Int64, (EmployeeID > -1 ? (object)EmployeeID : DBNull.Value));
                    db.AddInParameter(cmd, "@RESOURCE_ID", DbType.Int64, ResourceID);
                    db.AddInParameter(cmd, "@RESOURCE_TYPE", DbType.Int64, this._Resource_Type_ID);
                    db.AddInParameter(cmd, "@ISCREATE_BIT", DbType.String, IsCreate ? "Y" : "N");
                    db.AddInParameter(cmd, "@ISREAD_BIT", DbType.String, IsRead ? "Y" : "N");
                    db.AddInParameter(cmd, "@ISUPDATE_BIT", DbType.String, IsUpdate ? "Y" : "N");
                    db.AddInParameter(cmd, "@ISDELETE_BIT", DbType.String, IsDelete ? "Y" : "N");
                    db.AddInParameter(cmd, "@IS_GROUP", DbType.String, IsGroup ? "Y" : "N");
                    if (db.ExecuteNonQuery(cmd, dbTrans) > 0)
                    {
                        FWTransaction.Commit(dbTrans);
                        if (IsGroup)
                        {
                            if (IsCreate)
                            {
                                if (this._PerResGroup_CREATE_Ids == null || this._PerResGroup_CREATE_Ids.Length == 0)
                                {
                                    this._PerResGroup_CREATE_Ids = new long[] { ResourceID };
                                }
                                else
                                {

                                    Array.Resize(ref this._PerResGroup_CREATE_Ids, this._PerResGroup_CREATE_Ids.Length + 1);
                                    this._PerResGroup_CREATE_Ids[this._PerResGroup_CREATE_Ids.Length - 1] = ResourceID;
                                }
                                if (this._PerResGroup_CREATE_StrIds == "")
                                    this._PerResGroup_CREATE_StrIds = ResourceID.ToString();
                                else this._PerResGroup_CREATE_StrIds += "," + ResourceID;
                            }
                            if (IsDelete)
                            {
                                if (this._PerResGroup_DELETE_Ids == null || this._PerResGroup_DELETE_Ids.Length == 0)
                                {
                                    this._PerResGroup_DELETE_Ids = new long[] { ResourceID };
                                }
                                else
                                {

                                    Array.Resize(ref this._PerResGroup_DELETE_Ids, this._PerResGroup_DELETE_Ids.Length + 1);
                                    this._PerResGroup_DELETE_Ids[this._PerResGroup_DELETE_Ids.Length - 1] = ResourceID;
                                }
                                if (this._PerResGroup_DELETE_StrIds == "")
                                    this._PerResGroup_DELETE_StrIds = ResourceID.ToString();
                                else this._PerResGroup_DELETE_StrIds += "," + ResourceID;
                            }
                            if (IsRead)
                            {
                                if (this._PerResGroup_READ_Ids == null || this._PerResGroup_READ_Ids.Length == 0)
                                {
                                    this._PerResGroup_READ_Ids = new long[] { ResourceID };
                                }
                                else
                                {

                                    Array.Resize(ref this._PerResGroup_READ_Ids, this._PerResGroup_READ_Ids.Length + 1);
                                    this._PerResGroup_READ_Ids[this._PerResGroup_READ_Ids.Length - 1] = ResourceID;
                                }
                                if (this._PerResGroup_READ_StrIds == "")
                                    this._PerResGroup_READ_StrIds = ResourceID.ToString();
                                else this._PerResGroup_READ_StrIds += "," + ResourceID;
                            }
                            if (IsUpdate)
                            {
                                if (this._PerResGroup_UPDATE_Ids == null || this._PerResGroup_UPDATE_Ids.Length == 0)
                                {
                                    this._PerResGroup_UPDATE_Ids = new long[] { ResourceID };
                                }
                                else
                                {

                                    Array.Resize(ref this._PerResGroup_UPDATE_Ids, this._PerResGroup_UPDATE_Ids.Length + 1);
                                    this._PerResGroup_UPDATE_Ids[this._PerResGroup_UPDATE_Ids.Length - 1] = ResourceID;
                                }
                                if (this._PerResGroup_UPDATE_StrIds == "")
                                    this._PerResGroup_UPDATE_StrIds = ResourceID.ToString();
                                else this._PerResGroup_UPDATE_StrIds += "," + ResourceID;
                            }
                        }
                        else
                        {
                            if (IsCreate)
                            {
                                if (this._PerRes_CREATE_Ids == null || this._PerRes_CREATE_Ids.Length == 0)
                                {
                                    this._PerRes_CREATE_Ids = new long[] { ResourceID };
                                }
                                else
                                {

                                    Array.Resize(ref this._PerRes_CREATE_Ids, this._PerRes_CREATE_Ids.Length + 1);
                                    this._PerRes_CREATE_Ids[this._PerRes_CREATE_Ids.Length - 1] = ResourceID;
                                }
                                if (this._PerRes_CREATE_StrIds == "")
                                    this._PerRes_CREATE_StrIds = ResourceID.ToString();
                                else this._PerRes_CREATE_StrIds += "," + ResourceID;
                            }
                            if (IsDelete)
                            {
                                if (this._PerRes_DELETE_Ids == null || this._PerRes_DELETE_Ids.Length == 0)
                                {
                                    this._PerRes_DELETE_Ids = new long[] { ResourceID };
                                }
                                else
                                {

                                    Array.Resize(ref this._PerRes_DELETE_Ids, this._PerRes_DELETE_Ids.Length + 1);
                                    this._PerRes_DELETE_Ids[this._PerRes_DELETE_Ids.Length - 1] = ResourceID;
                                }
                                if (this._PerRes_DELETE_StrIds == "")
                                    this._PerRes_DELETE_StrIds = ResourceID.ToString();
                                else this._PerRes_DELETE_StrIds += "," + ResourceID;
                            }
                            if (IsRead)
                            {
                                if (this._PerRes_READ_Ids == null || this._PerRes_READ_Ids.Length == 0)
                                {
                                    this._PerRes_READ_Ids = new long[] { ResourceID };
                                }
                                else
                                {

                                    Array.Resize(ref this._PerRes_READ_Ids, this._PerRes_READ_Ids.Length + 1);
                                    this._PerRes_READ_Ids[this._PerRes_READ_Ids.Length - 1] = ResourceID;
                                }
                                if (this._PerRes_READ_StrIds == "")
                                    this._PerRes_READ_StrIds = ResourceID.ToString();
                                else this._PerRes_READ_StrIds += "," + ResourceID;
                            }
                            if (IsUpdate)
                            {
                                if (this._PerRes_UPDATE_Ids == null || this._PerRes_UPDATE_Ids.Length == 0)
                                {
                                    this._PerRes_UPDATE_Ids = new long[] { ResourceID };
                                }
                                else
                                {

                                    Array.Resize(ref this._PerRes_UPDATE_Ids, this._PerRes_UPDATE_Ids.Length + 1);
                                    this._PerRes_UPDATE_Ids[this._PerRes_UPDATE_Ids.Length - 1] = ResourceID;
                                }
                                if (this._PerRes_UPDATE_StrIds == "")
                                    this._PerRes_UPDATE_StrIds = ResourceID.ToString();
                                else this._PerRes_UPDATE_StrIds += "," + ResourceID;
                            }
                        }
                        return true;
                    }
                }
                catch
                {

                }
                FWTransaction.Rollback(dbTrans);
                return false;
            }
            return true;
        }
        public bool DeletePermis(long ResourceID, bool IsGroup)
        {
            DatabaseFB db = null;
            DbTransaction dbTrans = null;
            try
            {
                db = HelpDB.getDatabase();
                dbTrans = FWTransaction.BeginTrans(db);
                string sql = string.Format(@"DELETE
                                        from PER_RESOURCE
                                        where RESOURCE_ID ={0} and RESOURCE_TYPE={1} and IS_GROUP='{2}'",                                 
                                        ResourceID, this._Resource_Type_ID, IsGroup ? "Y" : "N");
                DbCommand cmd = db.GetSQLStringCommand(sql);
                if (db.ExecuteNonQuery(cmd, dbTrans) > 0)
                {
                    FWTransaction.Commit(dbTrans);
                    return true;
                }
            }
            catch
            {

            }
            FWTransaction.Rollback(dbTrans);
            return false;

        }
        #endregion

    }   
    
    public enum RES_PERMISSION_TYPE
    {
        CREATE = 1,
        READ = 2,
        UPDATE = 3,
        DELETE = 4,
    }
    public class DOResource
    {
        private long id;        
        private long group_ID;
        private long creater_ID;
        private DateTime? created_date;
        public DOResource(long id,long group_id, long creater_id, DateTime? created_date)
        {
            this.id =id;
            this.group_ID = group_id;
            this.creater_ID = creater_id;
            this.created_date = created_date;
        }
        public long ID
        {
            get { return id; }
            set { id = value; }
        }
     

        public long Group_ID
        {
            get { return group_ID; }
            set { group_ID = value; }
        }

        public long Creater_ID
        {
            get { return creater_ID; }
            set { creater_ID = value; }
        }

        public DateTime? Created_date
        {
            get { return created_date; }
            set { created_date = value; }
        }
      
    }   
}
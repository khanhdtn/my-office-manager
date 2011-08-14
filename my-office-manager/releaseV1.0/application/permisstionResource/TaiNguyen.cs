using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using ProtocolVN.Framework.Core;
using ProtocolVN.Framework.Win;

namespace ProtocolVN.Framework.Core
{
    /// <summary>
    /// DUYVT: Lớp tài nguyên trừu tượng hỗ trợ phân quyền
    /// </summary>
    public abstract class TaiNguyen
    {
        #region "Variables"
        private long[] _PerRes_CREATE_Ids;
        private long[] _PerRes_READ_Ids;
        private long[] _PerRes_UPDATE_Ids;
        private long[] _PerRes_DELETE_Ids;

        private long[] _PerResGroup_CREATE_Ids;
        private long[] _PerResGroup_READ_Ids;
        private long[] _PerResGroup_UPDATE_Ids;
        private long[] _PerResGroup_DELETE_Ids;

        private string _ResName;
        private string _PerTableResGroupName;
        private string _RefFieldPerResGroupName;
        private string _PerTableResName;
        private string _RefFieldPerResName;
        private string _DMTableResGroupName;
        private string _DMTableResName;
        private string _RefFieldDMResName;
        private string _FieldUserAllow;
        private IDanhMuc _DMResGroup;
        private IDanhMuc _DMRes;

        private bool isPermission;

        public bool IsPermission
        {
            get { return isPermission; }
        }

        
       
        /// <summary>
        /// Chuỗi mô tả tên tài nguyên.
        /// </summary>
        public string ResName
        {
            get { return _ResName; }
        }

       
        /// <summary>
        /// Tên bảng chứa thông tin quyền của người dùng với nhóm tài nguyên. 
        /// </summary>
        public string PerTableResGroupName
        {
            get { return _PerTableResGroupName; }
        }
        /// <summary>
        /// Tên trường dữ liệu tham chiếu đến bảng danh mục nhóm tài nguyên tương ứng.
        /// </summary>
        public string RefFieldPerResGroupName
        {
            get { return _RefFieldPerResGroupName; }
        }

        /// <summary>
        /// Tên bảng chứa thông tin quyền của người dùng với tài nguyên.
        /// </summary>
        public string PerTableResName
        {
            get { return _PerTableResName; }
        }

        /// <summary>
        /// Tên trường dữ liệu tham chiếu đến bảng danh mục tài nguyên tương ứng.
        /// </summary>
        public string RefFieldPerResName
        {
            get { return _RefFieldPerResName; }
        }

       
        /// <summary>
        /// Tên bảng danh mục nhóm tài nguyên.
        /// </summary>
        public string DMTableResGroupName
        {
            get { return _DMTableResGroupName; }
        }

        /// <summary>
        /// Tên bảng danh mục tài nguyên.
        /// </summary>
        public string DMTableResName
        {
            get { return _DMTableResName; }
        }

        /// <summary>
        /// Tên trường dữ liệu tham chiếu đến bảng danh mục nhóm tài nguyên tương ứng.
        /// </summary>
        public string RefFieldDMResName
        {
            get { return _RefFieldDMResName; }
        }


        /// <summary>
        /// Tên trường cho biết người dùng này có áp dụng phân quyền hay không, thuộc bảng USER_CAT_EX.
        /// </summary>
        public string FieldUserAllow
        {
            get { return _FieldUserAllow; }
        }

        /// <summary>
        /// Thể hiện của danh mục nhóm tài nguyên.
        /// </summary>
        public IDanhMuc DMResGroup
        {
            get { return _DMResGroup; }
        }

        /// <summary>
        /// Thể hiện của danh mục tài nguyên.
        /// </summary>
        public IDanhMuc DMRes
        {
            get { return _DMRes; }            
        }
        #endregion

        #region "Constructor"
        public TaiNguyen(string ResName,
            string PerTableResGroupName, string RefFieldPerResGroupName,
            string PerTableResName, string RefFieldPerResName,
            string DMTableResGroupName, string DMTableResName,
            string RefFieldDMResName, string FieldUserAllow,
            IDanhMuc DMResGroup, IDanhMuc DMRes)
        {
            this._ResName = ResName;
            this._PerTableResGroupName = PerTableResGroupName;
            this._RefFieldPerResGroupName = RefFieldPerResGroupName;
            this._PerTableResName = PerTableResName;
            this._RefFieldPerResName = RefFieldPerResName;
            this._DMTableResGroupName = DMTableResGroupName;
            this._DMTableResName = DMTableResName;
            this._RefFieldDMResName = RefFieldDMResName;
            this._FieldUserAllow = FieldUserAllow;
            this._DMResGroup = DMResGroup;
            this._DMRes = DMRes;

            Init();
        }
        #endregion

        #region "Privarte Methods"
        /// <summary>
        /// Khởi tạo dữ liệu ban đầu
        /// </summary>
        private void Init()
        {
            isPermission = CheckApplyPermission();
            if (isPermission)
            {
                //Nạp thông tin phân quyền trên tài nguyên cho người dùng hiện hành
                _PerRes_CREATE_Ids = _getPermissionResIDs(
                    FrameworkParams.currentUser.id, PERMISSION_RES.CREATE);
                _PerRes_READ_Ids = _getPermissionResIDs(
                    FrameworkParams.currentUser.id, PERMISSION_RES.READ);
                _PerRes_UPDATE_Ids = _getPermissionResIDs(
                    FrameworkParams.currentUser.id, PERMISSION_RES.UPDATE);
                _PerRes_DELETE_Ids = _getPermissionResIDs(
                    FrameworkParams.currentUser.id, PERMISSION_RES.DELETE);

                //Nạp thông tin phân quyền trên nhóm tài nguyên cho người dùng hiện hành
                _PerResGroup_CREATE_Ids = _getPermissionResGroupIDs(
                    FrameworkParams.currentUser.id, PERMISSION_RES.CREATE);
                _PerResGroup_READ_Ids = _getPermissionResGroupIDs(
                    FrameworkParams.currentUser.id, PERMISSION_RES.READ);
                _PerResGroup_UPDATE_Ids = _getPermissionResGroupIDs(
                    FrameworkParams.currentUser.id, PERMISSION_RES.UPDATE);
                _PerResGroup_DELETE_Ids = _getPermissionResGroupIDs(
                    FrameworkParams.currentUser.id, PERMISSION_RES.DELETE);
            }
        }

        /// <summary>
        /// Kiểm tra xem có áp dụng phân quyền với người dùng hiện hành hay không.
        /// </summary>
        /// <returns></returns>
        private bool CheckApplyPermission()
        {
            DataSet ds = new DataSet();
            try
            {
                if (FrameworkParams.currentUser.username == "admin")
                {
                    //Không áp dụng phân quyền với admin
                    return false;
                }
                else
                {
                    ds = HelpDB.getDatabase().LoadDataSet(@"select " + this._FieldUserAllow + @" from user_cat_ex
                                                           where userid=" + FrameworkParams.currentUser.id);
                    if (ds == null || ds.Tables[0].Rows.Count == 0)
                        return true;
                    else
                        return (ds.Tables[0].Rows[0][0].ToString() == "Y") ? true : false;
                }
            }
            catch { return false; }
        }

        private string GetFieldPermission(PERMISSION_RES per_type)
        {
            switch (per_type)
            {
                case PERMISSION_RES.CREATE:
                    return "ISCREATE_BIT";
                case PERMISSION_RES.READ:
                    return "ISREAD_BIT";
                case PERMISSION_RES.UPDATE:
                    return "ISUPDATE_BIT";
                case PERMISSION_RES.DELETE:
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
            try
            {
                DatabaseFB db = HelpDB.getDatabase();
                DbCommand cmd_Get = db.GetSQLStringCommand(
                    "select ntn.id from " + this._DMTableResGroupName + " ntn inner join "
                    + this._DMTableResName + " tn on ntn.id=tn." + this._RefFieldDMResName
                    + " where tn.id=" + ResID);
                return HelpNumber.ParseInt64(db.ExecuteScalar(cmd_Get));
            }
            catch
            {
                return -1;
            }
        }
        #endregion

        #region "Public Methods"
        /// <summary>
        /// Kiểm tra người dùng hiện hành có quyền trên 1 tài nguyên cụ thể hay không.
        /// </summary>
        /// <param name="ResID">ID tài nguyên</param>
        /// <param name="per_type">Loại quyền</param>
        /// <returns></returns>
        public bool _checkPermissionRes(long ResID, PERMISSION_RES per_type)
        {
            return _checkPermissionRes(FrameworkParams.currentUser.id, ResID, per_type);
        }

        /// <summary>
        /// Kiểm tra người dùng chỉ định có quyền trên 1 tài nguyên cụ thể hay không.
        /// </summary>
        /// <param name="UserID">ID người dùng</param>
        /// <param name="ResID">ID tài nguyên</param>
        /// <param name="per_type">Loại quyền</param>
        /// <returns></returns>
        public bool _checkPermissionRes(long UserID, long ResID, PERMISSION_RES per_type)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = HelpDB.getDatabase().LoadDataSet(
                    "select * from " + this._PerTableResName
                    + " where userid=" + UserID
                    + " and " + this._RefFieldPerResName + "=" + ResID + " and "
                    + GetFieldPermission(per_type) + "='Y'");
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    return true;
                else if (_checkPermissionResGroup(GetResGroupID(ResID), per_type))
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
        public bool _checkPermissionResGroup(long ResGroupID, PERMISSION_RES per_type)
        {
            return _checkPermissionResGroup(FrameworkParams.currentUser.id, ResGroupID, per_type);
        }

        /// <summary>
        /// Kiểm tra người dùng chỉ định có quyền trên 1 nhóm tài nguyên cụ thể hay không.
        /// </summary>
        /// <param name="UserID">ID người dùng</param>
        /// <param name="ResGroupID">ID nhóm tài nguyên</param>
        /// <param name="per_type">Loại quyền</param>
        /// <returns></returns>
        public bool _checkPermissionResGroup(long UserID, long ResGroupID, PERMISSION_RES per_type)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = HelpDB.getDatabase().LoadDataSet(
                    "select * from " + this._PerTableResGroupName
                    + " where userid=" + UserID
                    + " and " + this._RefFieldPerResGroupName + "=" + ResGroupID 
                    + " and " + GetFieldPermission(per_type) + "='Y'");
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    return true;
                return false;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Trả về danh sách tài nguyên theo ID mà người dùng hiện hành có quyền.
        /// </summary>
        /// <param name="per_type">Loại quyền</param>
        /// <returns></returns>
        public long[] _getPermissionResIDs(PERMISSION_RES per_type)
        {
            switch (per_type)
            {
                case PERMISSION_RES.CREATE:
                    return _PerRes_CREATE_Ids;
                case PERMISSION_RES.READ:
                    return _PerRes_READ_Ids;
                case PERMISSION_RES.UPDATE:
                    return _PerRes_UPDATE_Ids;
                case PERMISSION_RES.DELETE:
                    return _PerRes_DELETE_Ids;
                default:
                    return _PerRes_READ_Ids;
            }
        }

        /// <summary>
        /// Trả về danh sách tài nguyên theo ID mà người dùng chỉ định có quyền.
        /// </summary>
        /// <param name="UserID">ID người dùng</param>
        /// <param name="per_type">Loại quyền</param>
        /// <returns></returns>
        public long[] _getPermissionResIDs(long UserID, PERMISSION_RES per_type)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = HelpDB.getDatabase().LoadDataSet(
                    @"select id 
                    from (select tn.id from " + this._DMTableResName + @" tn
                        inner join " + this._PerTableResGroupName + " u_ntn on tn."
                                     + this._RefFieldDMResName + "=u_ntn."
                                     + this._RefFieldPerResGroupName
                    + @" where " + GetFieldPermission(per_type) + @"='Y' and userid=" + UserID + @"
                    union
                    select u_tn." + this._RefFieldPerResName + @" as id
                    from " + this._PerTableResName + @" u_tn
                    where " + GetFieldPermission(per_type) + @"='Y' and userid=" + UserID + ")");
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    List<long> list = new List<long>();
                    foreach (DataRow row in ds.Tables[0].Rows)                    
                        list.Add(HelpNumber.ParseInt64(row[0]));
                    return list.ToArray();
                }
                return null;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Trả về danh sách nhóm tài nguyên theo ID mà người dùng hiện hành có quyền.
        /// </summary>
        /// <param name="per_type">Loại quyền</param>
        /// <returns></returns>
        public long[] _getPermissionResGroupIDs(PERMISSION_RES per_type)
        {
            switch (per_type)
            {
                case PERMISSION_RES.CREATE:
                    return _PerResGroup_CREATE_Ids;
                case PERMISSION_RES.READ:
                    return _PerResGroup_READ_Ids;
                case PERMISSION_RES.UPDATE:
                    return _PerResGroup_UPDATE_Ids;
                case PERMISSION_RES.DELETE:
                    return _PerResGroup_DELETE_Ids;
                default:
                    return _PerResGroup_READ_Ids;
            }
        }

        /// <summary>
        /// Trả về danh sách nhóm tài nguyên theo ID mà người dùng chỉ định có quyền.
        /// </summary>
        /// <param name="UserID">ID người dùng</param>
        /// <param name="per_type">Loại quyền</param>
        /// <returns></returns>
        public long[] _getPermissionResGroupIDs(long UserID, PERMISSION_RES per_type)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = HelpDB.getDatabase().LoadDataSet(
                    "select " + this._RefFieldPerResGroupName + " from " + this._PerTableResGroupName
                    + " where userid=" + UserID + " and " + GetFieldPermission(per_type) + "='Y'");
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    List<long> list = new List<long>();
                    foreach (DataRow row in ds.Tables[0].Rows)
                        list.Add(HelpNumber.ParseInt64(row[0]));
                    return list.ToArray();
                }
                return null;
            }
            catch
            {
                return null;
            }
        }
        #endregion
    }

    /// <summary>
    /// Các loại quyền trên nhóm tài nguyên - tài nguyên
    /// </summary>
    public enum PERMISSION_RES
    {
        CREATE = 1,
        READ = 2,
        UPDATE = 3,
        DELETE = 4,
    }
}
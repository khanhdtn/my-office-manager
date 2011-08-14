using System;
using System.Collections.Generic;
using System.Text;
using ProtocolVN.Framework.Core;
using ProtocolVN.Framework.Win;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using System.Windows.Forms;
using System.Data.Common;
using System.Data;
using ProtocolVN.Plugin.TimeSheet.bo;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraEditors.Repository;
using DTO;
using ProtocolVN.DanhMuc;
using office;
using LumiSoft.Net.Mime;
using ProtocolVN.App.Office;
namespace ProtocolVN.Plugin.TimeSheet
{
    public class PLTimeSheetUtil
    {
        
        public static void ClosePhieu(XtraForm frm, bool? isAdd, System.Windows.Forms.FormClosingEventArgs e)
        {
            if (frm.Tag != null && frm.Tag.Equals("Q")) { e.Cancel = false; return; }
            if (isAdd == null) { e.Cancel = false; return; }
            if (HelpMsgBox.ShowConfirmMessage("Bạn có chắc muốn đóng?") == DialogResult.Yes) e.Cancel = false;
            else e.Cancel = true;
        }
        public static void HuyForm(XtraForm form)
        {
            //ErrorMsg.ErrorDeleted();
            throw new Exception();
        }
        public static void DisableGrid(GridControl gridControl, GridView gridView, bool? IsAdd)
        {
            gridView.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
            gridView.OptionsBehavior.Editable = false;
        }
        public static long GetNVID(long usercat)
        {
            string sql = "select EMPLOYEE_ID from USER_CAT where USERID=" + usercat;
            DataSet ds = new DataSet();
            DatabaseFB db = HelpDB.getDatabase();
            System.Data.Common.DbCommand cmd = db.GetSQLStringCommand(sql);
            db.LoadDataSet(cmd, ds, "USER");
            if (ds.Tables[0].Rows.Count > 0)
                return HelpNumber.ParseInt64(ds.Tables[0].Rows[0][0].ToString());
            else
                return -1;
        }
        public static string GetFullName(object ID)
        {
            DatabaseFB db = HelpDB.getDatabase();
            string strsql = "SELECT dm_nhan_vien.name FROM dm_nhan_vien WHERE dm_nhan_vien.ID='" + GetNVID(HelpNumber.ParseInt64(ID)) + "'";
            DbCommand cmd = db.GetSQLStringCommand(strsql);
            IDataReader reader = db.ExecuteReader(cmd);
            if (reader.Read())
                return reader[0].ToString();
            return ID.ToString();
        }
        public static void UpdateInfo_Duyet(PLInfoBox Info, DOChiTietCongViec Phieu)
        {
            try
            {
                string Duyet1 = "4";
                try
                {
                    Duyet1 = Phieu.GetType().GetProperty("DUYET").GetValue(Phieu, null).ToString().Trim();
                }
                catch { }
                string NguoiCapNhat = GetFullName(Phieu.GetType().GetProperty("NGUOI_CAP_NHAT").GetValue(Phieu, null));
                string NgayCapNhat = Phieu.GetType().GetProperty("NGAY_CAP_NHAT").GetValue(Phieu, null).ToString();
                if (Duyet1 == "2" || Duyet1 == "3")
                {
                    Info._init(NguoiCapNhat, NgayCapNhat,
                      GetFullName(Phieu.GetType().GetProperty("NGUOI_DUYET").GetValue(Phieu, null)),
                      Phieu.GetType().GetProperty("NGAY_DUYET").GetValue(Phieu, null).ToString());
                }
                else
                {
                    Info._init(NguoiCapNhat, NgayCapNhat);
                }
            }
            catch { }
        }


        public static int CalTime(object gioDi, object gioVe)
        {
            return HelpTime.CalTime(gioDi, gioVe);
        }

        private static void SetValueTable(ref DataTable source, DataTable srcValueObj, string[] fieldName, string fieldAo, string DisplayMember, string ValueMember)
        {
            foreach (DataRow row in source.Rows)
            {
                string objid = row[fieldName[0]].ToString();
                string objvalueid = row[fieldName[1]].ToString();
                DataView view = srcValueObj.DefaultView;
                view.RowFilter = "OBJVALUE='" + objid + "' and " + ValueMember + "='" + objvalueid + "'";
                if (view.Count > 0)
                    row[fieldAo] = view[0][DisplayMember];
            }
        }
        /// <summary>
        /// phieuGui: Phiếu sẽ gửi mail
        /// </summary>
        /// <param name="phieu"></param>
        /// <param name="tinhTrang"></param>
        /// <param name="dt"></param>
        /// <param name="phieuGui"></param>
        /// <returns></returns>
        public static bool _SendThongBao(DOTimeInOut phieu, string tinhTrang, DataTable dt, params object[] phieuGui)
        {
            AddressList To = new AddressList();
            string title = string.Empty;
            StringBuilder subject;
            //Thứ
            string date;
            string classform = "";
            switch (phieu.NGAY_LAM_VIEC.DayOfWeek)
            {
                case DayOfWeek.Monday:
                    date = "Thứ hai, ";
                    break;
                case DayOfWeek.Tuesday:
                    date = "Thứ ba, ";
                    break;
                case DayOfWeek.Wednesday:
                    date = "Thứ tư, ";
                    break;
                case DayOfWeek.Thursday:
                    date = "Thứ năm, ";
                    break;
                case DayOfWeek.Friday:
                    date = "Thứ sáu, ";
                    break;
                case DayOfWeek.Saturday:
                    date = "Thứ bảy, ";
                    break;
                default:
                    date = "Chủ nhật, ";
                    break;
            };

            //
            if (string.Compare(phieuGui[0].ToString(), LoaiPhieu.PhieuXinNghiPhep.ToString()) == 0)
            {
                ///1.Nội dung

                classform = typeof(frmNghiPhep).FullName;
                StringBuilder thoiGianNghi = new StringBuilder();
                if (phieu.NGHI_BUOI_SANG == "Y" && phieu.NGHI_BUOI_CHIEU == "Y") thoiGianNghi.Append("Nghỉ cả ngày");
                else
                {
                    if (phieu.NGHI_BUOI_SANG == "Y") thoiGianNghi.Append("Nghỉ buổi sáng");
                    if (phieu.NGHI_BUOI_CHIEU == "Y") thoiGianNghi.Append("Nghỉ buổi chiều");
                }

                subject = new StringBuilder(string.Format(PLConst.DES_MAIL_XNP, DMNhanVienX.I.GetEmployeeFullName(phieu.NV_ID),
                        thoiGianNghi.ToString(), date + phieu.NGAY_LAM_VIEC.ToShortDateString(), phieu.NGHI_PHEP_NAM == "Y" ? "Nghỉ phép năm" : "Nghỉ không lương",
                        phieu.LY_DO));
                if (tinhTrang == PLConst.CHO_DUYET)
                {
                    List<long> lstUser = new List<long>();
                    foreach (DataRow item in dt.Rows)
                    {
                        if (item["CHON"].ToString() == "Y")
                            lstUser.Add(HelpNumber.ParseInt64(item["ID"]));
                    }
                    if (!lstUser.Contains(phieu.NV_ID)) lstUser.Add(phieu.NV_ID);
                    title = "Có phiếu xin nghỉ phép đang chờ duyệt";
                    To = HelpZPLOEmail.GetAddressList((lstUser.ToArray()));
                }
                else if (tinhTrang == PLConst.DUYET)
                {
                    title = "Có phiếu xin nghỉ phép được duyệt";
                    To = HelpZPLOEmail.GetAddressList(new long[] { phieu.NV_ID });
                }
                else if (tinhTrang == PLConst.KHONG_DUYET)
                {
                    title = "Có phiếu xin nghỉ phép không được duyệt.";
                    To = HelpZPLOEmail.GetAddressList(new long[] { phieu.NV_ID });
                }
                else
                {
                    title = "Có phiếu xin nghỉ phép đã xóa";
                    To = HelpZPLOEmail.GetAddressList(new long[] { phieu.NV_ID });
                }
            }
            else if (string.Compare(phieuGui[0].ToString(), LoaiPhieu.PhieuXacNhanLamViec.ToString()) == 0)
            {
                classform = typeof(frmPhieuXNLamViec).FullName;
                subject = new StringBuilder(string.Format(PLConst.DES_MAIL_XNLV, DMNhanVienX.I.GetEmployeeFullName(phieu.NV_ID),
                        date + phieu.NGAY_LAM_VIEC.ToShortDateString(), Convert.ToDateTime(phieu.GIO_BAT_DAU.ToString()).ToString("HH:mm"),
                        Convert.ToDateTime(phieu.GIO_KET_THUC.ToString()).ToString("HH:mm"), phieu.NOI_DUNG));
                if (tinhTrang == PLConst.CHO_DUYET)
                {
                    List<long> lstUser = new List<long>();
                    foreach (DataRow item in dt.Rows)
                    {
                        if (item["CHON"].ToString() == "Y")
                            lstUser.Add(HelpNumber.ParseInt64(item["ID"]));
                    }
                    if (!lstUser.Contains(phieu.NV_ID)) lstUser.Add(phieu.NV_ID);
                    title = "Có phiếu xác nhận làm việc đang chờ duyệt";
                    To = HelpZPLOEmail.GetAddressList((lstUser.ToArray()));
                }
                else if (tinhTrang == PLConst.DUYET)
                {
                    title = "Có phiếu xác nhận làm việc được duyệt";
                    To = HelpZPLOEmail.GetAddressList(new long[] { phieu.NV_ID });
                }
                else if (tinhTrang == PLConst.KHONG_DUYET)
                {
                    title = "Có phiếu xác nhận làm việc không được duyệt";
                    To = HelpZPLOEmail.GetAddressList(new long[] { phieu.NV_ID });
                }
                else
                {
                    title = "Có phiếu xác nhận làm việc đã xóa";
                    To = HelpZPLOEmail.GetAddressList(new long[] { phieu.NV_ID });
                }
            }
            else
            {
                classform = typeof(frmPhieuRaVaoCty).FullName;

                subject = new StringBuilder(string.Format(PLConst.DES_MAIL_RVCTY, DMNhanVienX.I.GetEmployeeFullName(phieu.NV_ID),
                       date + phieu.NGAY_LAM_VIEC.ToShortDateString(), Convert.ToDateTime(phieu.GIO_BAT_DAU.ToString()).ToString("HH:mm"),
                       Convert.ToDateTime(phieu.GIO_KET_THUC.ToString()).ToString("HH:mm"), phieu.NOI_DUNG));
                if (tinhTrang == PLConst.CHO_DUYET)
                {
                    List<long> lstUser = new List<long>();
                    foreach (DataRow item in dt.Rows)
                    {
                        if (item["CHON"].ToString() == "Y")
                            lstUser.Add(HelpNumber.ParseInt64(item["ID"]));
                    }
                    if (!lstUser.Contains(phieu.NV_ID)) lstUser.Add(phieu.NV_ID);
                    title = "Có phiếu ra vào công ty đang chờ duyệt";
                    To = HelpZPLOEmail.GetAddressList((lstUser.ToArray()));
                }
                else if (tinhTrang == PLConst.DUYET)
                {
                    title = "Có phiếu ra vào công ty được duyệt";
                    To = HelpZPLOEmail.GetAddressList(new long[] { phieu.NV_ID });
                }
                else if (tinhTrang == PLConst.KHONG_DUYET)
                {
                    title = "Có phiếu ra vào công ty không được duyệt";
                    To = HelpZPLOEmail.GetAddressList(new long[] { phieu.NV_ID });
                }
                else
                {
                    title = "Có phiếu ra vào công ty đã xóa";
                    To = HelpZPLOEmail.GetAddressList(new long[] { phieu.NV_ID });
                }
            }
            title = HelpStringBuilder.GetTitleMailNewPageper(title);
            ///2.Gửi mail
            return HelpZPLOEmail.SendSmartHost(HelpAutoOpenForm.GeneratingCodeFromForm(classform, phieu.ID), title, null, To, null, null, subject.ToString(), "");
        }
        /// <summary>
        /// phieuGui: Phiếu sẽ gửi mail
        /// </summary>
        /// <param name="phieu"></param>
        /// <param name="tinhTrang"></param>
        /// <param name="dt"></param>
        /// <param name="phieuGui"></param>
        /// <returns></returns>
        public static bool _SendThongBao(long[] NguoiNhanMail, DOTimeInOut phieu, string tinhTrang, params object[] phieuGui)
        {
            AddressList To = new AddressList();
            string title = string.Empty;
            StringBuilder subject;
            //Thứ
            string date;
            string classform = "";
            switch (phieu.NGAY_LAM_VIEC.DayOfWeek)
            {
                case DayOfWeek.Monday:
                    date = "Thứ hai, ";
                    break;
                case DayOfWeek.Tuesday:
                    date = "Thứ ba, ";
                    break;
                case DayOfWeek.Wednesday:
                    date = "Thứ tư, ";
                    break;
                case DayOfWeek.Thursday:
                    date = "Thứ năm, ";
                    break;
                case DayOfWeek.Friday:
                    date = "Thứ sáu, ";
                    break;
                case DayOfWeek.Saturday:
                    date = "Thứ bảy, ";
                    break;
                default:
                    date = "Chủ nhật, ";
                    break;
            };

            //
            if (string.Compare(phieuGui[0].ToString(), LoaiPhieu.PhieuXinNghiPhep.ToString()) == 0)
            {
                ///1.Nội dung

                classform = typeof(frmNghiPhep).FullName;
                StringBuilder thoiGianNghi = new StringBuilder();
                if (phieu.NGHI_BUOI_SANG == "Y" && phieu.NGHI_BUOI_CHIEU == "Y") thoiGianNghi.Append("Nghỉ cả ngày");
                else
                {
                    if (phieu.NGHI_BUOI_SANG == "Y") thoiGianNghi.Append("Nghỉ buổi sáng");
                    if (phieu.NGHI_BUOI_CHIEU == "Y") thoiGianNghi.Append("Nghỉ buổi chiều");
                }

                subject = new StringBuilder(string.Format(PLConst.DES_MAIL_XNP, DMNhanVienX.I.GetEmployeeFullName(phieu.NV_ID),
                        thoiGianNghi.ToString(), date + phieu.NGAY_LAM_VIEC.ToShortDateString(), phieu.NGHI_PHEP_NAM == "Y" ? "Nghỉ phép năm" : "Nghỉ không lương",
                        phieu.LY_DO));
                if (tinhTrang == PLConst.CHO_DUYET)
                {
                    List<long> lstUser = new List<long>(NguoiNhanMail);
                    if (!lstUser.Contains(phieu.NV_ID)) lstUser.Add(phieu.NV_ID);
                    title = "Có phiếu xin nghỉ phép đang chờ duyệt";
                    To = HelpZPLOEmail.GetAddressList((lstUser.ToArray()));
                }
                else if (tinhTrang == PLConst.DUYET)
                {
                    title = "Có phiếu xin nghỉ phép được duyệt";
                    To = HelpZPLOEmail.GetAddressList(new long[] { phieu.NV_ID });
                }
                else if (tinhTrang == PLConst.KHONG_DUYET)
                {
                    title = "Có phiếu xin nghỉ phép không được duyệt.";
                    To = HelpZPLOEmail.GetAddressList(new long[] { phieu.NV_ID });
                }
                else
                {
                    title = "Có phiếu xin nghỉ phép đã xóa";
                    To = HelpZPLOEmail.GetAddressList(new long[] { phieu.NV_ID });
                }
            }
            else if (string.Compare(phieuGui[0].ToString(), LoaiPhieu.PhieuXacNhanLamViec.ToString()) == 0)
            {
                classform = typeof(frmPhieuXNLamViec).FullName;
                subject = new StringBuilder(string.Format(PLConst.DES_MAIL_XNLV, DMNhanVienX.I.GetEmployeeFullName(phieu.NV_ID),
                        date + phieu.NGAY_LAM_VIEC.ToShortDateString(), Convert.ToDateTime(phieu.GIO_BAT_DAU.ToString()).ToString("HH:mm"),
                        Convert.ToDateTime(phieu.GIO_KET_THUC.ToString()).ToString("HH:mm"), phieu.NOI_DUNG));
                if (tinhTrang == PLConst.CHO_DUYET)
                {
                    List<long> lstUser = new List<long>(NguoiNhanMail);

                    if (!lstUser.Contains(phieu.NV_ID)) lstUser.Add(phieu.NV_ID);
                    title = "Có phiếu xác nhận làm việc đang chờ duyệt";
                    To = HelpZPLOEmail.GetAddressList((lstUser.ToArray()));
                }
                else if (tinhTrang == PLConst.DUYET)
                {
                    title = "Có phiếu xác nhận làm việc được duyệt";
                    To = HelpZPLOEmail.GetAddressList(new long[] { phieu.NV_ID });
                }
                else if (tinhTrang == PLConst.KHONG_DUYET)
                {
                    title = "Có phiếu xác nhận làm việc không được duyệt";
                    To = HelpZPLOEmail.GetAddressList(new long[] { phieu.NV_ID });
                }
                else
                {
                    title = "Có phiếu xác nhận làm việc đã xóa";
                    To = HelpZPLOEmail.GetAddressList(new long[] { phieu.NV_ID });
                }
            }
            else
            {
                classform = typeof(frmPhieuRaVaoCty).FullName;

                subject = new StringBuilder(string.Format(PLConst.DES_MAIL_RVCTY, DMNhanVienX.I.GetEmployeeFullName(phieu.NV_ID),
                       date + phieu.NGAY_LAM_VIEC.ToShortDateString(), Convert.ToDateTime(phieu.GIO_BAT_DAU.ToString()).ToString("HH:mm"),
                       Convert.ToDateTime(phieu.GIO_KET_THUC.ToString()).ToString("HH:mm"), phieu.NOI_DUNG));
                if (tinhTrang == PLConst.CHO_DUYET)
                {
                    List<long> lstUser = new List<long>(NguoiNhanMail);
                    if (!lstUser.Contains(phieu.NV_ID)) lstUser.Add(phieu.NV_ID);
                    title = "Có phiếu ra vào công ty đang chờ duyệt";
                    To = HelpZPLOEmail.GetAddressList((lstUser.ToArray()));
                }
                else if (tinhTrang == PLConst.DUYET)
                {
                    title = "Có phiếu ra vào công ty được duyệt";
                    To = HelpZPLOEmail.GetAddressList(new long[] { phieu.NV_ID });
                }
                else if (tinhTrang == PLConst.KHONG_DUYET)
                {
                    title = "Có phiếu ra vào công ty không được duyệt";
                    To = HelpZPLOEmail.GetAddressList(new long[] { phieu.NV_ID });
                }
                else
                {
                    title = "Có phiếu ra vào công ty đã xóa";
                    To = HelpZPLOEmail.GetAddressList(new long[] { phieu.NV_ID });
                }
            }
            title = HelpStringBuilder.GetTitleMailNewPageper(title);
            ///2.Gửi mail
            return HelpZPLOEmail.SendSmartHost(HelpAutoOpenForm.GeneratingCodeFromForm(classform, phieu.ID), title, null, To, null, null, subject.ToString(), "");
        }
        public static List<long> getQuyen(long KeyFEATURE)
        {
            List<long> list = new List<long>();

            DataSet ds = dsGetQuyen(KeyFEATURE);
            foreach (DataRow r in ds.Tables[0].Rows)
            {
                list.Add(HelpNumber.DecimalToInt64(r["ID"]));
            }
            return list;
        }

        public static DataSet dsGetQuyen(long keyFeature) {
            QueryBuilder query = new QueryBuilder(@"
                SELECT e.ID FROM USER_FEATURE_REL rel, USER_CAT u, DM_NHAN_VIEN e ,FEATURE_CAT fcat
                WHERE e.ID = u.EMPLOYEE_ID AND rel.USERID=u.USERID AND fcat.ID=rel.FEATUREID AND 1=1");
            query.addID("fcat.ID", keyFeature);
            query.addBoolean("rel.ISREAD_BIT", true);
            return HelpDB.getDatabase().LoadDataSet(query);
        }

        [Obsolete("CHAUTV: Không sử dụng. Vui lòng sử dụng phương thức InitCtrlDuyet(...) để thay thế")]
        public static void InitCtrl(PLDMGrid Input, bool ReadOnly, bool? IsAdd)
        {
            QueryBuilder query = new QueryBuilder(@"
                SELECT e.ID,e.NAME,e.DEPARTMENT_ID FROM USER_FEATURE_REL rel, USER_CAT u, DM_NHAN_VIEN e ,FEATURE_CAT fcat
                WHERE e.ID = u.EMPLOYEE_ID AND rel.USERID=u.USERID AND fcat.ID=rel.FEATUREID AND 1=1");
            query.addID("fcat.ID", PLConst.QUYEN_DUYET_NGHI_PHEP);
            query.addBoolean("rel.ISREAD_BIT", true);
            if (IsAdd != null)
            {
                query.addBoolean("e.VISIBLE_BIT", true);
            }
            Input._init((ReadOnly == true ? GroupElementType.ONLY_CHOICE : GroupElementType.CHOICE_N_ADD), DABase.getDatabase().LoadDataSet(query, "DM_NHAN_VIEN").Tables[0], "ID", "NAME",
                new string[] { "ID" }, new string[] { "ID" }, DMNhanVienX.I.CreatePLDMGroupElementNhan_vien, DMNhanVienX.I.GetRuleDM_NHAN_VIEN, null, null, null, null);
            if (ReadOnly)
            {
                try
                {
                    ((System.Windows.Forms.ToolStrip)Input.Controls[0].Controls[0].Controls[1]).Items[4].Visible = true;// Ẩn nút sửa
                    ((System.Windows.Forms.ToolStrip)Input.Controls[0].Controls[0].Controls[1]).Items[5].Visible = true;// Ẩn nút Xóa
                }
                catch (Exception ex)
                {
                    PLException.AddException(ex);
                }
            }
        }
        public static void InitCtrlDuyet(PLDMGrid Input, bool ReadOnly, bool? IsAdd, string FeatureName)
        {
            QueryBuilder query = new QueryBuilder(@"
                SELECT e.ID,e.NAME,e.DEPARTMENT_ID FROM USER_FEATURE_REL rel, USER_CAT u, DM_NHAN_VIEN e ,FEATURE_CAT fcat
                WHERE e.ID = u.EMPLOYEE_ID AND rel.USERID=u.USERID AND fcat.ID=rel.FEATUREID AND 1=1");
            query.add("fcat.NAME", Operator.Equal, FeatureName, DbType.String);
            query.addBoolean("rel.ISREAD_BIT", true);
            if (IsAdd != null)
            {
                query.addBoolean("e.VISIBLE_BIT", true);
            }
            Input._init((ReadOnly == true ? GroupElementType.ONLY_CHOICE : GroupElementType.CHOICE_N_ADD), HelpDB.getDatabase().LoadDataSet(query, "DM_NHAN_VIEN").Tables[0], "ID", "NAME",
                new string[] { "ID" }, new string[] { "ID" }, DMNhanVienX.I.CreatePLDMGroupElementNhan_vien, DMNhanVienX.I.GetRuleDM_NHAN_VIEN, null, null, null, null);
            if (ReadOnly)
            {
                try
                {
                    ((System.Windows.Forms.ToolStrip)Input.Controls[0].Controls[0].Controls[1]).Items[4].Visible = true;// Ẩn nút sửa
                    ((System.Windows.Forms.ToolStrip)Input.Controls[0].Controls[0].Controls[1]).Items[5].Visible = true;// Ẩn nút Xóa
                }
                catch (Exception ex)
                {
                    PLException.AddException(ex);
                }
            }
        }
        #region PHUOCNC
        //- Cách sử dụng còn phức tạp có thể hỗ trợ nhiều hơn để việc khai 
        //báo sử dụng de hon
        //- Giải pháp không hiệu quả lắm chỗ mảng DataTable


        /// <summary>
        /// Thay đổi đối tượng trên cột thứ nhất sẽ load tất cả giá trị liên quan đến đối tượng đó trên cột thứ 2 
        /// </summary>
        /// <param name="gridView">GridView chứa 2 cột đối tượng và giá trị tương ứng của đối tượng</param>
        /// <param name="colObject">Cột đối tượng</param>
        /// <param name="valueOfObj">Cột thay đổi giá trị khi đối tượng thay đổi</param>
        /// <param name="fieldNames">Lần lượt là fieldName của cột đối tượng và giá trị liên quan đến đối tượng</param>
        /// <param name="DisplayMember">Giá trị Field hiện lên trên cột giá trị của đối tượng</param>
        /// <param name="ValueMember">Giá trị cần lấy trên cột giá trị của đối tượng</param>
        /// <param name="srcObj">Có bao nhiêu đối tượng thì truyền vào bấy nhiều datasource cho nó</param>
        /// 
        public static void ObjectChange(GridView gridView, GridColumn colObject, GridColumn valueOfObj, string[] fieldNames, string fieldForeignKey, string tableNameObj, string IdField, string tableNameValObj, string DisplayMember, string ValueMember)
        {

            DataTable srcValueObj = HelpDB.getDatabase().LoadTable(tableNameValObj).Tables[0];
            DataTable srcObj = DABase.getDatabase().LoadTable(tableNameObj).Tables[0];
            DataTable srcNew = new DataTable();
            srcNew.Columns.Add(new DataColumn("OBJVALUE"));
            srcNew.Columns.Add(new DataColumn(ValueMember));
            srcNew.Columns.Add(new DataColumn(DisplayMember));
            RepositoryItemImageComboBox resCombo = (RepositoryItemImageComboBox)colObject.ColumnEdit;
            for (int i = 0; i < resCombo.Items.Count; i++)
            {
                string objId = resCombo.Items[i].Value.ToString();
                DataRow[] selRow = srcObj.Select(IdField + "=" + objId);
                string typeObj = "";
                if (selRow.Length > 0)
                    typeObj = selRow[0][fieldForeignKey].ToString();

                DataRow[] srcRowObj = srcValueObj.Select(fieldForeignKey + "=" + typeObj);

                foreach (DataRow dr in srcRowObj)
                {
                    DataRow newRow = srcNew.NewRow();
                    newRow["OBJVALUE"] = objId;
                    newRow[ValueMember] = dr[ValueMember];
                    newRow[DisplayMember] = dr[DisplayMember];
                    srcNew.Rows.Add(newRow);
                }

            }
            string cotAo = fieldNames[1] + "_PLV";
            // colObject.FieldName = fieldNames[0];
            //Tao cot ao trong GridView
            try
            {
                DataTable source = (DataTable)gridView.GridControl.DataSource;
                if (source != null)
                    source.Columns.Add(new DataColumn(cotAo));
                else
                {
                    gridView.GridControl.DataSourceChanged += delegate(object sender, EventArgs e)
                    {
                        // gridView.SetFocusedRowCellValue(valueOfObj, "");
                        DataTable src = (DataTable)(gridView.GridControl.DataSource);
                        if (!src.Columns.Contains(cotAo))
                            src.Columns.Add(new DataColumn(cotAo));
                        SetValueTable(ref src, srcNew, fieldNames, cotAo, DisplayMember, ValueMember);
                    };
                }
            }
            catch { }
            valueOfObj.FieldName = cotAo;

            //Tao datasource moi

            int isUpdateLookup = 0;
            //Khoi tao doi tuong GridControl va GridView
            DevExpress.XtraGrid.Views.Grid.GridView gridViewLookup = new GridView();
            DevExpress.XtraGrid.GridControl gridLookup = new DevExpress.XtraGrid.GridControl();

            //Thiet lap cac thuoc tinh cho doi tuong GridControl va GridView
            gridLookup.Dock = System.Windows.Forms.DockStyle.Fill;
            gridLookup.EmbeddedNavigator.Name = "";
            gridLookup.FormsUseDefaultLookAndFeel = false;
            gridLookup.Location = new System.Drawing.Point(0, 0);
            gridLookup.MainView = gridViewLookup;
            gridLookup.Name = "gridLookup";
            gridLookup.Size = new System.Drawing.Size(200, 100);
            gridLookup.TabIndex = 2;
            gridLookup.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridViewLookup });
            gridLookup.MouseMove += delegate(object sender, MouseEventArgs e)
            {
                DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo hi = gridViewLookup.CalcHitInfo(new System.Drawing.Point(e.X, e.Y));
                if (hi.RowHandle >= 0)
                    gridViewLookup.FocusedRowHandle = hi.RowHandle;
            };
            gridLookup.Click += delegate(object sender, EventArgs e)
            {
                isUpdateLookup = 1;
                gridView.Focus();
            };
            gridLookup.DataSource = srcNew;
            //Tao gridView

            gridViewLookup.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            gridViewLookup.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            gridViewLookup.GridControl = gridLookup;
            gridViewLookup.Name = "gridViewLookup";
            gridViewLookup.OptionsBehavior.Editable = false;
            gridViewLookup.OptionsSelection.EnableAppearanceFocusedCell = false;
            gridViewLookup.OptionsView.ShowColumnHeaders = false;
            gridViewLookup.OptionsView.ShowDetailButtons = false;
            gridViewLookup.OptionsView.ShowGroupPanel = false;
            gridViewLookup.OptionsView.ShowIndicator = false;
            DevExpress.XtraGrid.Columns.GridColumn gridColumnNameObject = new DevExpress.XtraGrid.Columns.GridColumn();
            gridColumnNameObject.Caption = "NAME";
            gridColumnNameObject.FieldName = "NAME";
            gridColumnNameObject.Name = "gridColumnNameObject";
            gridColumnNameObject.Visible = true;
            gridColumnNameObject.VisibleIndex = 0;
            gridViewLookup.Columns.Add(gridColumnNameObject);

            gridViewLookup.KeyDown += delegate(object sender, KeyEventArgs e)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    isUpdateLookup = 1;
                    gridView.Focus();
                }
            };
            //Tao Grid Control


            DevExpress.XtraEditors.PopupContainerControl popupContainer = new DevExpress.XtraEditors.PopupContainerControl();
            popupContainer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly;
            popupContainer.AutoSize = true;
            popupContainer.Controls.Add(gridLookup);
            popupContainer.Location = new System.Drawing.Point(617, 242);
            popupContainer.Name = "popupContainer";
            popupContainer.Size = new System.Drawing.Size(200, 100);
            popupContainer.TabIndex = 1;

            //
            //containEdit          
            //
            DevExpress.XtraEditors.Repository.RepositoryItemPopupContainerEdit containEdit = new DevExpress.XtraEditors.Repository.RepositoryItemPopupContainerEdit();
            valueOfObj.ColumnEdit = containEdit;
            containEdit.AutoHeight = true;
            containEdit.Name = "containEdit";
            containEdit.PopupControl = popupContainer;
            containEdit.PopupSizeable = false;
            containEdit.ShowPopupCloseButton = false;
            containEdit.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            containEdit.QueryResultValue += delegate(object sender, DevExpress.XtraEditors.Controls.QueryResultValueEventArgs e)
            {
                try
                {
                    if (isUpdateLookup == 1)
                    {
                        DataRow rowGridLookup = (gridLookup.MainView as GridView).GetDataRow((gridLookup.MainView as GridView).FocusedRowHandle);
                        DataRow rowGridView = gridView.GetDataRow(gridView.FocusedRowHandle);
                        rowGridView[cotAo] = rowGridLookup[DisplayMember];
                        e.Value = rowGridLookup[DisplayMember];
                        rowGridView[fieldNames[1]] = rowGridLookup[ValueMember];
                    }
                }
                catch { }
            };
            containEdit.Popup += delegate(object sender, EventArgs e)
            {
                if ((DataTable)gridView.GridControl.DataSource != null)
                {
                    DataTable dt = (DataTable)gridLookup.DataSource;
                    if (dt != null)
                    {
                        DataRow dr = gridView.GetDataRow(gridView.FocusedRowHandle);
                        if (dr != null)
                        {
                            string objName = dr[fieldNames[0]].ToString();
                            dt.DefaultView.RowFilter = "OBJVALUE='" + objName + "'";
                        }
                        else
                            dt.DefaultView.RowFilter = "OBJVALUE=''";
                    }
                }
            };

            if (colObject.ColumnEdit is DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox)
            {
                DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox imgComboBoxLoai = colObject.ColumnEdit as DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox;
                imgComboBoxLoai.SelectedIndexChanged += delegate(object sender, EventArgs e)
                {
                    gridView.SetFocusedRowCellValue(valueOfObj, "");
                    DataTable dt = (DataTable)gridLookup.DataSource;
                    if (dt != null)
                    {
                        dt.DefaultView.RowFilter = "OBJVALUE='" + ((DevExpress.XtraEditors.ImageComboBoxEdit)sender).EditValue.ToString() + "'";
                    }
                };
            }

        }
        #endregion

        //PHUOCNC Code nay dung lam gi
        public static void FilterRow(ref DataTable dt, string[] filedNumber, string[] CmpField)
        {
            int rowTotal = dt.Rows.Count;
            int i = 0;
            while (i < rowTotal)
            {
                try
                {
                    DataRow rowMain = dt.Rows[i];
                    //Loc ra cac row trung
                    string filterStr = "";
                    for (int j = 0; j < CmpField.Length; j++)
                    {
                        filterStr += CmpField[j] + "='" + rowMain[CmpField[j]] + "'";
                        filterStr += " and ";
                    }
                    filterStr = filterStr.Remove(filterStr.LastIndexOf(" and "));
                    DataRow[] rowDup = dt.Select(filterStr);
                    //Xu ly cac row trung nhau                   
                    for (int k = 1; k < rowDup.Length; k++)
                    {
                        DataRow rowProcess = rowDup[k];
                        foreach (string field in filedNumber)
                        {
                            try
                            {
                                long cal = long.Parse(rowMain[field].ToString());
                                cal += long.Parse(rowProcess[field].ToString());
                                rowMain[field] = cal;
                            }
                            catch { }
                        }
                        rowProcess.Delete();
                    }
                }
                catch { }
                i++;
            }
        }


        /// <summary>
        ///CHAUTV : Phân quyền xem dữ liệu
        /// </summary>
        /// <param name="Input"></param>
        /// <param name="featureName"></param>
        public static void ApplyPermissionData(PLDMGrid Input, string featureName)
        {
            List<Feature> features = Permission.loadAllFeatureByUser(FrameworkParams.currentUser.username);
            bool IsFull = false;
            if (features.Exists(delegate(Feature e) {
                return e.featureName.Equals(featureName) && e.isRead.Equals(true);
            }) || FrameworkParams.currentUser.username.Equals("admin"))
                IsFull = true;
            //foreach (Feature f in features)
            //{
            //    if ((f.featureName == featureName && f.isRead == true) || FrameworkParams.currentUser.username.Equals("admin"))
            //    {
            //        IsFull = true;
            //        return;
            //    }
            //}
            if (FrameworkParams.isPermision.getPublicForm().Contains(typeof(frmTimeInOutQL).FullName) == false && !IsFull)
                Input.Enabled = false;
            Input._setSelectedID(FrameworkParams.currentUser.employee_id);
        }
        /// <summary>
        ///CHAUTV : Phân quyền xem dữ liệu
        /// </summary>
        /// <param name="Input"></param>
        /// <param name="featureName"></param>
        public static void ApplyPermissionData(PLDMTreeGroup Input, string featureName)
        {
            List<Feature> features = Permission.loadAllFeatureByUser(FrameworkParams.currentUser.username);
            bool IsFull = false;
            if (features.Exists(delegate(Feature e)
            {
                return e.featureName.Equals(featureName) && e.isRead.Equals(true);
            }) || FrameworkParams.currentUser.username.Equals("admin"))
                IsFull = true;
            //foreach (Feature f in features)
            //{
            //    if ((f.featureName == featureName && f.isRead == true) || FrameworkParams.currentUser.username.Equals("admin"))
            //    {
            //        IsFull = true;
            //        return;
            //    }
            //}
            if (FrameworkParams.isPermision.getPublicForm().Contains(typeof(frmTimeInOutQL).FullName) == false && !IsFull)
                Input.Enabled = false;
            Input._setSelectedID(FrameworkParams.currentUser.employee_id);
        }

        /// <summary>
        /// Permission for control(property Enable "True" or "False"). 
        /// Uses this because the Framework do not support.
        /// </summary>
        /// <param name="control">control for appling permission</param>
        /// <param name="adminPermission"></param>
        /// <param name="editorPermission"></param>
        public static void PermissionForControl(PLDMTreeGroup control,bool adminPermission,bool editorPermission){
            if (adminPermission) control.Visible = true;
            else if (editorPermission) control.Visible = true;
            else {
                control.Visible = true;
                control.Enabled = false;
            }

            if (control._getSelectedID() == -1)
                control._setSelectedID(FrameworkParams.currentUser.employee_id);
        }

        public static void PermissionForControl(ProtocolVN.App.Office.ApplicationCore.PLDMTreeMultiChoice control, bool adminPermission, bool editorPermission)
        {
            if (adminPermission) control.Visible = true;
            else if (editorPermission) control.Visible = true;
            else
            {
                control.Visible = true;
                control.Enabled = false;
            }

            if (control._CountSelectedIDs == 0)
                control._SelectedIDs = new long[] { FrameworkParams.currentUser.employee_id };
        }




        /// <summary>
        /// Ẩn dòng "Tổng số mẫu tin ..." trên lưới master
        /// </summary>
        /// <param name="gridControl1"></param>
        public static void InVisibleShowNumOfRecord(GridControl gridControl1)
        {
            gridControl1.EmbeddedNavigator.Buttons.Append.Visible = false;
            gridControl1.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            gridControl1.EmbeddedNavigator.Buttons.Edit.Visible = false;
            gridControl1.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            gridControl1.EmbeddedNavigator.Buttons.First.Visible = false;
            gridControl1.EmbeddedNavigator.Buttons.Last.Visible = false;
            gridControl1.EmbeddedNavigator.Buttons.Next.Visible = false;
            gridControl1.EmbeddedNavigator.Buttons.NextPage.Visible = false;
            gridControl1.EmbeddedNavigator.Buttons.Prev.Visible = false;
            gridControl1.EmbeddedNavigator.Buttons.PrevPage.Visible = false;
            gridControl1.EmbeddedNavigator.Buttons.Remove.Visible = false;
            gridControl1.EmbeddedNavigator.TextStringFormat = string.Empty;
            gridControl1.EmbeddedNavigator.Name = string.Empty;
            gridControl1.UseEmbeddedNavigator = true;
        }
        public static long[] GetNguoiNhanMail(long perForCurrentFormID, params long[] idNguoiNhans)
        {
            List<long> NguoiNhans = new List<long>();
            if (perForCurrentFormID >= 0)
                PLTimeSheetUtil.getQuyen(perForCurrentFormID);
            foreach (long id in idNguoiNhans)
            {
                if (NguoiNhans.Contains(id)) continue;
                NguoiNhans.Add(id);
            }
            return NguoiNhans.ToArray();
        }
    }
    
}

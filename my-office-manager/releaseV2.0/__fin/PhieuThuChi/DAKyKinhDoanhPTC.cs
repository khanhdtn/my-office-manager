using System;
using System.Data;
using DTO;
using ProtocolVN.Framework.Core;
using ProtocolVN.Framework.Win;
using System.Data.Common;

namespace DAO
{
    public class KyKinhDoanhPTCFields {
        public const string KKD_ID = "KKD_ID";
        public const string TU_NGAY = "TU_NGAY";
        public const string DEN_NGAY ="DEN_NGAY";
        public const string NGUOI_TAO_ID = "NGUOI_TAO_ID";
        public const string NGUOI_KHOA_SO_ID = "NGUOI_KHOA_SO_ID";
        public const string KHOA_SO_BIT ="KHOA_SO_BIT";
    }
    public class DAKyKinhDoanhPTC : DAPhieu<DOKyKinhDoanhPTC>
    {
        public static string KEY_FIELD_NAME = KyKinhDoanhPTCFields.KKD_ID;
        public static string TABLE_MAP = "KY_KINH_DOANH_PTC";
        private object[] FIELD_MAP = new object[] { 
            KyKinhDoanhPTCFields.KKD_ID,new IDConverter(),
            KyKinhDoanhPTCFields.TU_NGAY,null,
            KyKinhDoanhPTCFields.DEN_NGAY,null,
            KyKinhDoanhPTCFields.NGUOI_TAO_ID,new IDConverter(),
            KyKinhDoanhPTCFields.NGUOI_KHOA_SO_ID,new IDConverter(),
            KyKinhDoanhPTCFields.KHOA_SO_BIT,null
        };
        public static DAKyKinhDoanhPTC Instance = new DAKyKinhDoanhPTC();

        public DAKyKinhDoanhPTC() : base() { }

        public override DataTypeBuilder DefineDetailDataTypeBuilder()
        {
            return null;
        }

        public override DOKyKinhDoanhPTC LoadAll(long IDKey)
        {
            DOKyKinhDoanhPTC phieu = this.Load(IDKey);
            phieu.MasterDataSet = DatabaseFB.LoadDataSet(TABLE_MAP, KEY_FIELD_NAME, IDKey);
            return phieu;
        }

        public override bool UpdateDetail(System.Data.DataSet Detail, System.Data.DataSet Grid)
        {
            return true;
        }

        public override bool ValidateDetail(System.Data.DataRow row)
        {
            return true;
        }

        public override DataTypeBuilder DefineDataTypeBuilder()
        {
            return new DataTypeBuilder(FIELD_MAP);
        }

        public override bool Delete(long IDKey)
        {
            return DatabaseFB.DeleteRecord(TABLE_MAP, KEY_FIELD_NAME, IDKey);
        }

        public override DOKyKinhDoanhPTC Load(long IDKey)
        {
            IDataReader reader = DatabaseFB.LoadRecord(TABLE_MAP, KEY_FIELD_NAME, IDKey);
            using (reader)
            {
                if (reader.Read())
                {
                    DOKyKinhDoanhPTC data = (DOKyKinhDoanhPTC)this.Builder.CreateFilledObjectExt(typeof(DOKyKinhDoanhPTC), reader);

                    return data;
                }
            }
            return new DOKyKinhDoanhPTC();
        }

        public override bool Update(DOKyKinhDoanhPTC data)
        {
            bool flag = false;
            try
            {
                if (data.MasterDataSet.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in data.MasterDataSet.Tables[0].Rows)
                    {
                        flag = HelpDataSet.UpdataDataRowExt(row, FIELD_MAP, data);
                    }
                }
                else
                {
                    DataRow row = data.MasterDataSet.Tables[0].NewRow();
                    data.MasterDataSet.Tables[0].Rows.Add(row);
                    flag = HelpDataSet.UpdataDataRowExt(row, FIELD_MAP, data);
                }
                if (flag)
                {
                    try
                    {
                        DataSet dsMain = DatabaseFB.LoadDataSet(TABLE_MAP, KEY_FIELD_NAME, data.KKD_ID);
                        HelpDataSet.MergeDataSet(new string[] { KEY_FIELD_NAME }, dsMain, data.MasterDataSet);
                        if (data.KKD_ID == 0)
                        {
                            flag = DatabaseFB.Update2DataSet("G_NGHIEP_VU", dsMain, null, true);
                        }
                        else
                        {
                            flag = HelpDB.getDatabase().UpdateDataSet(dsMain);
                        }
                    }
                    catch (Exception ex)
                    {
                        PLException.AddException(ex);
                    }
                }
            }
            catch (Exception ex)
            {
                PLException.AddException(ex);
            }
            return flag;
        }

        public override bool Validate(DOKyKinhDoanhPTC element)
        {
            return true;
        }

        public void InitKyKinhDoanhPTC(PLCombobox Input) {
            string queryStr = @"
                SELECT
                    KKD_ID,
                    case WHEN DEN_NGAY is null THEN
                        'Từ ' || extract(day  from  TU_NGAY) || '/' || extract(month  from  TU_NGAY)
                        || '/' || extract(year from  TU_NGAY)
                        || ' đến '  ||
                        'Chưa xác định' 
                    ELSE
                        'Từ ' || extract(day  from  TU_NGAY) || '/' || extract(month  from  TU_NGAY)
                        || '/' || extract(year from  TU_NGAY)
                        || ' đến '  ||
                        extract(day  from  DEN_NGAY) || '/' || extract(month  from  DEN_NGAY)
                        || '/' || extract(year from  DEN_NGAY)
                    END as TITLE
                    FROM
                        KY_KINH_DOANH_PTC
                    WHERE 1=1";
            QueryBuilder query = new QueryBuilder(queryStr);
            query.setDescOrderBy("KKD_ID");
            DataSet ds = HelpDB.getDatabase().LoadDataSet(query);
            System.Drawing.Size oldSize = Input.MainCtrl.Size;
            Input._init(ds.Tables[0], "TITLE", "KKD_ID");
            Input._lookUpEdit.Properties.SortColumnIndex = -1;
            Input.MainCtrl.Size = oldSize;
        }

        public DOKyKinhDoanhPTC getKyKinhDoanh(DateTime date) {
            QueryBuilder query = new QueryBuilder(string.Format("SELECT * FROM {0} WHERE 1=1",TABLE_MAP));
            query.addCondition(string.Format(@"(TU_NGAY<='{0}' AND DEN_NGAY IS NULL) OR (TU_NGAY<='{0}' AND '{0}'<=DEN_NGAY)",date.ToString("MM/dd/yyyy")));
            DataSet ds = HelpDB.getDatabase().LoadDataSet(query);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count == 1)
                return this.LoadAll(HelpNumber.ParseInt64(ds.Tables[0].Rows[0]["KKD_ID"]));
            return this.LoadAll(-1);
        }
        /// <summary>
        /// Khóa hoặc mở kỳ kinh doanh(KKD)
        /// </summary>
        /// <param name="kyKD">KKD cần khóa</param>
        /// <param name="ngay">Ngày bắt đầu KKD mới. Chỉ dùng cho TH tạo mới KKD</param>
        /// <param name="IsKhoa"></param>
        /// <returns></returns>
        public bool KhoaMoKKD(DOKyKinhDoanhPTC kyKD,DateTime? ngay,bool IsKhoa) {
            try
            {
                if (IsKhoa)
                {
                    DOKyKinhDoanhPTC kyKDKeTiep = getKyKinhDoanhKeTiep((DateTime)kyKD.DEN_NGAY);
                    if (kyKDKeTiep.KKD_ID > 0)
                    {
                        //1.Cập nhật chốt kỳ hiện tại
                        kyKD.KHOA_SO_BIT = "Y";
                        DAKyKinhDoanhPTC.Instance.Update(kyKD);
                    }
                    else
                    {
                        //1.Khóa kỳ hiện tại
                        kyKD.KHOA_SO_BIT = "Y";
                        kyKD.NGUOI_KHOA_SO_ID = FrameworkParams.currentUser.employee_id;
                        DAKyKinhDoanhPTC.Instance.Update(kyKD);
                        //2.Tạo kỳ kế tiếp
                        kyKDKeTiep.KHOA_SO_BIT = "N";
                        kyKDKeTiep.TU_NGAY = kyKD.DEN_NGAY.Value.AddDays(1);
                        kyKDKeTiep.DEN_NGAY = null;
                        kyKDKeTiep.NGUOI_TAO_ID = FrameworkParams.currentUser.employee_id;
                        kyKDKeTiep.NGUOI_KHOA_SO_ID = null;
                        DAKyKinhDoanhPTC.Instance.Update(kyKDKeTiep);

                        //3.Cập nhật tiền mặt cho kỳ kế tiếp
                        DOTienMatKKDPTC tienMatKy = DATienMatKKDPTCPTC.Instance.LoadAll(kyKD.KKD_ID);
                        DOTienMatKKDPTC tienMatKyKeTiep = DATienMatKKDPTCPTC.Instance.LoadAll(kyKDKeTiep.KKD_ID);
                        tienMatKyKeTiep.KKD_ID = this.getKyKDMax().KKD_ID;
                        tienMatKyKeTiep.PHAT_SINH_GIAM = 0;
                        tienMatKyKeTiep.PHAT_SINH_TANG = 0;
                        tienMatKyKeTiep.TM_DAU_KY = tienMatKy.TM_CUOI_KY;
                        tienMatKyKeTiep.TM_CUOI_KY = tienMatKyKeTiep.TM_DAU_KY + tienMatKyKeTiep.PHAT_SINH_TANG - tienMatKyKeTiep.PHAT_SINH_GIAM;
                        DATienMatKKDPTCPTC.Instance.UpdateExce(tienMatKyKeTiep);
                    }
                    return true;
                }
                else
                {
                    //Trường hợp phát sinh KKD đầu tiên.
                    /*KKD này mặc định có ID là 1.
                     * Ngày bắt đầu là ngày được chọn để phát sinh KKD
                     * Ngày kết thúc là chưa xác định.
                     * Người tạo là user hiện hành.
                     * Người khóa sổ là chưa xác định.
                     * Tình trạng hiện tại là mở.
                     */
                    string sql = string.Format(@"Insert into {0}
                        values({1},'{2}',null,{3},null,'{4}')", TABLE_MAP, 1, ngay.Value.ToString("MM/dd/yyyy"),
                                                  FrameworkParams.currentUser.employee_id, "N");
                    DatabaseFB db = HelpDB.getDatabase();
                    DbCommand cmd = db.GetSQLStringCommand(sql);
                    try { db.ExecuteNonQuery(cmd); }
                    catch { HelpMsgBox.ShowDBErrorMessage("Phát sinh kỳ kinh doanh không thành công!"); }
                }
            }
            catch (Exception ex)
            {
                PLException.AddException(ex);
            }
            
            return false;
        }
        public DOKyKinhDoanhPTC getKyKinhDoanhKeTiep(DateTime date)
        {
            QueryBuilder query = new QueryBuilder(string.Format("SELECT first 1 * FROM {0} WHERE 1=1", TABLE_MAP));
            query.addCondition(string.Format(@"(TU_NGAY>'{0}')", date.ToString("MM/dd/yyyy")));
            DataSet ds = HelpDB.getDatabase().LoadDataSet(query);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count == 1)
                return this.LoadAll(HelpNumber.ParseInt64(ds.Tables[0].Rows[0]["KKD_ID"]));
            return this.LoadAll(-1);
        }
        public DOKyKinhDoanhPTC getKyKDMax() {
            DataSet dsKKDMax = HelpDB.getDatabase().LoadDataSet(
                        new QueryBuilder(@"select kkd.kkd_id, kkd.tu_ngay from ky_kinh_doanh_ptc kkd
                            where kkd.tu_ngay in (select max(t.tu_ngay) from ky_kinh_doanh_ptc t) and 1=1")
                        );
            if (dsKKDMax != null && dsKKDMax.Tables[0].Rows.Count == 1)
            {
                DOKyKinhDoanhPTC kkd = DAKyKinhDoanhPTC.Instance.LoadAll(HelpNumber.ParseInt64(dsKKDMax.Tables[0].Rows[0]["KKD_ID"]));
                return kkd;
            }
            else return DAKyKinhDoanhPTC.Instance.LoadAll(-1);
        }
    }
}

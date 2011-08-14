using System;
using System.Collections.Generic;
using System.Text;
using ProtocolVN.Framework.Core;
using System.Data;
using System.Data.Common;
using office;
using DevExpress.XtraGrid;
using System.Drawing;
using ProtocolVN.Framework.Win;
using DTO;
using System.Windows.Forms;
using ProtocolVN.DanhMuc;
using ProtocolVN.App.Office;
using LumiSoft.Net.Mime;

namespace DAO
{
    public class DAMeeting : DAPhieu<DOMeeting>
    {
        private static string KEY_FIELD_NAME = "ID";
        object[] FIELD_MAP = new object[] {  
                "ID", new IDConverter(),                                
                "NOI_DUNG", null,	                                           										
				"GIO_BAT_DAU", null,
                "GIO_KET_THUC",null, 
                "NGAY", null,	
                "DIA_DIEM",null,                             
                "NGUOI_TO_CHUC_ID",new IDConverter(),
                "KET_QUA",null,
                "NGUOI_CAP_NHAT_ID",null,
                "NGAY_CAP_NHAT",null,

                "GHI_CHU",null,
                "THANH_PHAN_THAM_DU",null,
                "THANH_PHAN_VANG_MAT",null,
                "CHU_DE",null,
                "MUC_DICH",null,
                "THU_KY",new IDConverter(),
                "LOAI_CUOC_HOP",new IDConverter()
                
        };
        public static DAMeeting Instance = new DAMeeting();
        public DAMeeting() : base() { }

        #region Các hàm kế thừa
        public override DataTypeBuilder DefineDetailDataTypeBuilder()
        {
            return null;
        }

        public override DOMeeting LoadAll(long IDKey)
        {
            DOMeeting phieu = this.Load(IDKey);
            phieu.DsFile = DALuuTruTapTin.Instance.GetTapTinByObjectID(IDKey, 6);
            phieu.DetailDataSet = FWDBService.LoadDataSet("MEETING_MANAGEMENT", "ID", IDKey);
            return phieu;
        }

        public override bool UpdateDetail(System.Data.DataSet Detail, System.Data.DataSet Grid)
        {
            throw new NotImplementedException();
        }

        public override bool ValidateDetail(System.Data.DataRow row)
        {
            throw new NotImplementedException();
        }

        public override DataTypeBuilder DefineDataTypeBuilder()
        {
            return new DataTypeBuilder(FIELD_MAP);
        }

        public override bool Delete(long IDKey)
        {
            return FWDBService.DeleteRecord("MEETING_MANAGEMENT", "ID", IDKey);
        }

        public override DOMeeting Load(long IDKey)
        {
            IDataReader reader = FWDBService.LoadRecord("MEETING_MANAGEMENT", KEY_FIELD_NAME, IDKey);
            using (reader)
            {
                if (reader.Read())
                {
                    DOMeeting data = (DOMeeting)this.Builder.CreateFilledObject(typeof(DOMeeting), reader);
                    return data;
                }
            }
            return new DOMeeting();
        }

        public override bool Update(DOMeeting data)
        {
            bool flag = false;
            FWDBService db = HelpDB.getDBService();
            DbTransaction dbTrans = FWTransaction.BeginTrans(db);
            FWTransaction fwTrans = new FWTransaction(db, dbTrans);
            try
            {
                DataSet MainDS = FWDBService.LoadDataSet("MEETING_MANAGEMENT", KEY_FIELD_NAME, data.ID);
                if (MainDS.Tables[0].Rows.Count == 1)
                {
                    HelpDataSet.UpdataDataRow(MainDS.Tables[0].Rows[0], FIELD_MAP, data);
                    flag = db.UpdateDataSet(MainDS, dbTrans);
                }
                else
                {
                    DataRow row = MainDS.Tables[0].NewRow();
                    row[KEY_FIELD_NAME] = data.ID;
                    HelpDataSet.UpdataDataRow(row, FIELD_MAP, data);
                    MainDS.Tables[0].Rows.Add(row);
                    flag = db.UpdateDataSet(MainDS, dbTrans);
                }
                if (flag)
                {
                    if (data.DsFile != null && data.DsFile.Tables.Count > 0)
                    {
                        DataSet DsLuuTruTapTin = data.DsFile.Copy();

                        DataRow[] rows = data.DsFile.Tables[0].Select("ID is null", "", DataViewRowState.Added);

                        List<long> taptinIDs = db.GetID("G_NGHIEP_VU", dbTrans, rows.Length);

                        int i = 0;
                        foreach (DataRow row in DsLuuTruTapTin.Tables[0].Rows)
                        {
                            if (row.RowState == DataRowState.Deleted) continue;
                            row["OBJECT_ID"] = data.ID;
                            row["TYPE_ID"] = (Int32)6;
                            if (row["ID"] is DBNull)
                            {
                                row["TAP_TIN_ID"] = taptinIDs[i];
                                row["ID"] = row["TAP_TIN_ID"];
                                i++;
                            }
                        }
                        DataSet DsObjectTapTin = DsLuuTruTapTin.Copy();
                        DsObjectTapTin.Tables[0].TableName = "OBJECT_TAP_TIN";
                        DataSet DsLuuTruTapTinSource = new DataSet();
                        string sqlTaptin = string.Format(@"SELECT LT.*
                            FROM LUU_TRU_TAP_TIN LT
                            INNER JOIN OBJECT_TAP_TIN OBJ ON OBJ.TAP_TIN_ID=LT.ID
                            AND OBJ.TYPE_ID=6 AND OBJ.OBJECT_ID={0}", data.ID);
                        if (fwTrans.LoadDataSet(DsLuuTruTapTinSource, sqlTaptin, "LUU_TRU_TAP_TIN") == false)
                        {
                            FWTransaction.Rollback(dbTrans);
                            return false;
                        }
                        HelpDataSet.MergeDataSet(new string[] { "ID" }, DsLuuTruTapTinSource, DsLuuTruTapTin, true);

                        DataSet DsObjectTapTinSource = new DataSet();
                        string sqlObj = string.Format(@"SELECT OBJ.*
                            FROM OBJECT_TAP_TIN OBJ WHERE OBJ.TYPE_ID=6 AND OBJ.OBJECT_ID={0}", data.ID);
                        if (fwTrans.LoadDataSet(DsObjectTapTinSource, sqlObj, "OBJECT_TAP_TIN") == false)
                        {
                            FWTransaction.Rollback(dbTrans);
                            return false;
                        }
                        HelpDataSet.MergeTable(new string[] { "TAP_TIN_ID" }, DsObjectTapTinSource.Tables[0], DsObjectTapTin.Tables[0], true, true);
                        flag = db.UpdateDataSet(DsLuuTruTapTinSource, dbTrans);
                        if (flag == true)
                        {
                            foreach (DataRow r in DsObjectTapTinSource.Tables[0].Rows)
                            {
                                DbCommand cmd = null;
                                if (r.RowState == DataRowState.Added)
                                {
                                    cmd = db.GetSQLStringCommand(string.Format(@"INSERT INTO OBJECT_TAP_TIN(TAP_TIN_ID,OBJECT_ID,TYPE_ID) VALUES({0},{1},6)", r["TAP_TIN_ID"], r["OBJECT_ID"], r["TYPE_ID"]));
                                }
                                if (cmd != null)
                                {
                                    if (db.ExecuteNonQuery(cmd, dbTrans) <= 0)
                                    {
                                        FWTransaction.Rollback(dbTrans);
                                        return false;
                                    }
                                }
                            }
                        }
                    }
                }
                if (flag == true) FWTransaction.Commit(dbTrans);
                else FWTransaction.Rollback(dbTrans);
            }
            catch (Exception ex)
            {
                flag = false;
                FWTransaction.Rollback(dbTrans);
                PLException.AddException(ex);
                HelpSysLog.AddException(ex, "Hàm cập nhật dữ liệu Meeting");
            }
            return flag;
        }

        public override bool Validate(DOMeeting element)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Mở rộng           
        public DataSet LoadTapTin(long iDMeeting, List<long> idTapTinDangXoa, ImageList imageList_layout, List<DOLuuTruTapTin> listDOTapTin)
        {
            DataSet ds = HelpDB.getDatabase().LoadDataSet(string.Format(@"
            SELECT * 
            FROM LUU_TRU_TAP_TIN WHERE ID IN (SELECT TAP_TIN_ID FROM OBJECT_TAP_TIN WHERE OBJECT_ID={0} AND TYPE_ID=6", iDMeeting));
            ds.Tables[0].Columns.Add("mo_file", typeof(Image));
            ds.Tables[0].Columns.Add("luu_file", typeof(Image));
            ds.Tables[0].Columns.Add("xoa_file", typeof(Image));
            ds.Tables[0].Columns.Add("sua_file", typeof(Image));
            foreach (DataRow r in ds.Tables[0].Rows)
            {
                r["NOI_DUNG"] = HelpByte.ImageToByteArray(AppCtrl.mapToImage(r["TEN_FILE"].ToString()));
                r["xoa_file"] = imageList_layout.Images[0];
                r["luu_file"] = imageList_layout.Images[1];
                r["sua_file"] = imageList_layout.Images[2];
                r["mo_file"] = imageList_layout.Images[3];
            }
            //Thêm vào lưới những cột chưa được lưu vào csdl
            foreach (DOLuuTruTapTin do_tt in listDOTapTin)
            {
                DataRow r = ds.Tables[0].NewRow();
                r["TIEU_DE"] = do_tt.TIEU_DE;
                r["TEN_FILE"] = do_tt.TEN_FILE;
                r["NOI_DUNG"] = HelpByte.ImageToByteArray(AppCtrl.mapToImage(r["TEN_FILE"].ToString()));
                r["GHI_CHU"] = do_tt.GHI_CHU;
                r["ID"] = do_tt.ID;
                r["xoa_file"] = imageList_layout.Images[0];
                r["luu_file"] = imageList_layout.Images[1];
                r["sua_file"] = imageList_layout.Images[2];
                r["mo_file"] = imageList_layout.Images[3];
                ds.Tables[0].Rows.Add(r);
            }
            foreach (long id_taptin in idTapTinDangXoa)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    if (HelpNumber.ParseInt64(row["ID"]) == id_taptin)
                    {
                        ds.Tables[0].Rows.Remove(row);
                        break;
                    }

                }
            }
            return ds;
        }
        public static void Luu_VanBanMeeting(long ID_Meeting, long ID_TapTin)
        {
            DatabaseFB db = HelpDB.getDatabase();
            DbTransaction trans = db.BeginTransaction(db.OpenConnection());
            DbCommand cm = db.GetSQLStringCommand(@"INSERT INTO OBJECT_TAP_TIN VALUES(@TAP_TIN_ID,@MEETING_ID},6)");
            db.AddInParameter(cm, "@MEETING_ID", DbType.Int64, ID_Meeting);
            db.AddInParameter(cm, "@TAP_TIN_ID", DbType.Int64, ID_TapTin);
            db.ExecuteNonQuery(cm, trans);
            db.CommitTransaction(trans);
        }
        public static void Xoa_VanbanMeeting (long id_taptin)
        {
            DatabaseFB db = HelpDB.getDatabase();
            DbTransaction trans = db.BeginTransaction(db.OpenConnection());
            DbCommand cm = db.GetSQLStringCommand(string.Format(@"DELETE FROM OBJECT_TAP_TIN WHERE OBJECT_ID={0} AND TYPE_ID=6", id_taptin));
            db.ExecuteNonQuery(cm, trans);
            db.CommitTransaction(trans);
        }

        public static void SendThongBao(DOMeeting doMeeting,long[] nguoiNhanMail)
        {
            AddressList to = new AddressList();
            DevExpress.XtraRichEdit.Demos.PLRichTextBox rft = new DevExpress.XtraRichEdit.Demos.PLRichTextBox();
            rft._setValue(doMeeting.NOI_DUNG);
            StringBuilder subject = new StringBuilder(string.Format(PLConst.DES_MAIL_MEETING, doMeeting.NGAY.ToString("dd/MM/yyyy")
                , doMeeting.GIO_BAT_DAU.ToString("HH:mm"), doMeeting.GIO_KET_THUC.ToString("HH:mm")
                , doMeeting.DIA_DIEM, rft.richEditControl.HtmlText));
            string title = "Có thông báo tham gia cuộc họp";
            title = HelpStringBuilder.GetTitleMailNewPageper(title);
            List<long> lstMail = new List<long>(DAMeeting.Instance.GetLongNguoiThucHien(doMeeting.THANH_PHAN_THAM_DU));
            foreach (long id in nguoiNhanMail)
                if (!lstMail.Contains(id)) lstMail.Add(id);
            to = HelpZPLOEmail.GetAddressList(lstMail.ToArray());
            HelpZPLOEmail.SendSmartHost(HelpAutoOpenForm.GeneratingCodeFromForm(typeof(frmMeeting).FullName, doMeeting.ID),
                title, null, to, null, null, subject.ToString(), "");
        }

        public long[] GetLongNguoiThucHien(string strIDs)
        {
            if (strIDs.Length == 0 || strIDs == null) return null;
            List<long> lstNguoiThucHien = new List<long>();
            string[] str = strIDs.Split(',');
            foreach (string item in str)
                lstNguoiThucHien.Add(HelpNumber.ParseInt64(item));
            return lstNguoiThucHien.ToArray();
        }
        #endregion        
    }
}

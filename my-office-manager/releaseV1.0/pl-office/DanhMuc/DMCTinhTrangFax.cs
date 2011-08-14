using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ProtocolVN.Framework.Win;
using DevExpress.XtraEditors.Controls;
namespace ProtocolVN.DanhMuc
{
    //Danh mục tình trạng Fax (Cấu hình cố định)
    public class DMCTinhTrangFax
    {
        public static DMCTinhTrangFax Instance = new DMCTinhTrangFax();

        private static DataTable TableTinhTrangIn = null;
        public Int64 CHO_FAX = 1;
        public Int64 DANG_FAX = 2;
        public Int64 DA_FAX = 3;
        public Int64 KHONG_FAX = 4;
        public static DataTable I()
        {
            if (TableTinhTrangIn != null)
            {
                return TableTinhTrangIn;
            }
            else
            {
                return HelpDataSetExt.CreateDataTable(
                                                        new string[] { "ID", "NAME" },
                                                        new string[] { "Int64", "" },
                                                        new object[] { Instance.CHO_FAX, "Chờ fax", 
                                                                       Instance.DA_FAX, "Ðã fax",
                                                                       Instance.KHONG_FAX, "Không fax"
                                                                     }
                                                      );
            }
        }
        public void InitCtrl(PLComboboxAdd Input, bool? IsAdd, bool ReadOnly)
        {
            DataSet ds = new DataSet();
            DataTable dt = I();
            ds.Tables.Add(dt);
            Input.DataSource = ds.Tables[0];
            Input.DisplayField = "NAME";
            Input.IDField = "ID";
            Input._init();
        }
        public void InitCtrl(PLCombobox Input, bool? IsAdd, bool ReadOnly)
        {
            DataSet ds = new DataSet();
            DataTable dt = I();
            ds.Tables.Add(dt);
            Input._init(ds.Tables[0], "NAME", "ID");
            if (ReadOnly)
                Input._lookUpEdit.Properties.TextEditStyle = TextEditStyles.DisableTextEditor;
        }
        public void InitCtrl(PLImgCombobox Input)
        {
            DataSet ds = new DataSet();
            DataTable dt = I();
            ds.Tables.Add(dt);
            Input._init(ds.Tables[0], "NAME", "ID");
        }
    }
}
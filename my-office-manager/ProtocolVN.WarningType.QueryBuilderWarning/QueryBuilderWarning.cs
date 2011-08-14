using System;
using System.Collections.Generic;
using System.Text;
using ProtocolVN.Plugin;
using ProtocolVN.Framework.Core;
using System.Data;
using ProtocolVN.Framework.Win;
using ProtocolVN.Plugin.WarningSystem;

namespace ProtocolVN.WarningType.QueryBuilderWarning
{
    public class QueryBuilderWarning : AWarningDefine
    {
        private QueryBuilder _queryBuilder;

        private int _newRecordMinimun;
        public int NewRecordMinimun
        {
            get { return _newRecordMinimun; }
            set { _newRecordMinimun = value; }
        }

        private QueryBuilderWarning()
        {
            _name = "Cảnh báo QueryBuilder";
            _des = "Cảnh báo số dòng dữ liệu thêm mới";
            _type = WarningExecType.FirstTime;
        }

        public QueryBuilderWarning(QueryBuilder queryBuilder, int num)
            : this()
        {
            _queryBuilder = queryBuilder;
            _newRecordMinimun = num;
        }

        public override void SetParams(List<object> param)
        {
            _queryBuilder = new QueryBuilder(param[0].ToString()); //CHAUTV : Sửa từ (QueryBuilder)param[0] thành new QueryBuilder(param[0].ToString());
            _newRecordMinimun = Int32.Parse(param[2].ToString());//CHAUTV Sửa từ param[1] thành param[2]
        }


        /// <summary>
        /// Lưu lại dữ liệu sau cùng
        /// Dùng so sánh sự thay đổi trên bảng dữ liệu
        /// </summary>
        private DataRow _lastRow;
        private bool compareTwoRow(DataRow r1, DataRow r2)
        {
            bool kq = true;
            object[] ob1 = r1.ItemArray;
            object[] ob2 = r2.ItemArray;

            for (int i = 0; i < ob1.Length; i++)
                if (!ob1[i].Equals(ob2[i]))
                {
                    kq = false;
                    break;
                }

            return kq;
        }
        public override object Supervise()
        {
            string result = "";
            try
            {
                DataTable dt = new DataTable();
                DataSet ds = DABase.getDatabase().LoadDataSet(_queryBuilder, "NO_NAME");
                if (ds != null) dt = ds.Tables[0];
                else return result;

                if (dt == null || dt.Rows.Count == 0) return result;

                if (this._lastRow == null)
                {
                    result = "Có " + dt.Rows.Count + " dữ liệu mới";
                    this._lastRow = dt.Rows[dt.Rows.Count - 1];
                }
                else
                {
                    int i = 0, j;
                    for (j = dt.Rows.Count - 1; j >= 0; j--)
                    {
                        if (!this.compareTwoRow(this._lastRow, dt.Rows[j])) i++;
                        else break;
                    }

                    if (i >= this._newRecordMinimun)
                    {
                        result = "Có " + i + " dữ liệu mới";
                        this._lastRow = dt.Rows[dt.Rows.Count - 1];
                    }
                }
            }
            catch { }
            return result;

            //string[] info = new string[] { "", "ABC", "CDF", "EHG" };
            //Random r = new Random();            
            //return info[r.Next(4)];
        }
        
        

        public override PLOut getOutputType()
        {
            return RibbonStatusOut.Instance();           
        }

        public override int getPeriod()
        {
            return 5000;
        }

        public override bool Install()
        {
            return true;
        }

        public override bool Uninstall()
        {
            return true;
        }

        public override bool Start()
        {
            return true;
        }

        public override bool Stop()
        {
            return true;
        }

        public override bool CheckConfig()
        {
            return true;
        }

        public override void ShowConfig(int war_id)
        {
            frmConfig config = new frmConfig(war_id);
            config.ShowDialog();
        }
    }

    public class ShowMessageWarning : AWarningDefine
    {
        public ShowMessageWarning()
        {
            _name = "Demo canh bao";
            _des =  "Hiện thông thông bao";
            _type = WarningExecType.FirstTime;
        }

        public override int getPeriod()
        {
            return -1;
        }

        public override bool Install()
        {
            return true;
        }

        public override bool Uninstall()
        {
            return false;
        }

        public override bool Start()
        {
            System.Windows.Forms.MessageBox.Show(Supervise().ToString());
            return true;
        }

        public override bool Stop()
        {
            return true;
        }

        public override object Supervise()
        {
            return "Demo canh bao";
        }

        public override void SetParams(List<object> param)
        {
        }

        public override PLOut getOutputType()
        {
            return SystemTrayOut.Instance();
        }

        public override bool CheckConfig()
        {
            return false;
        }

        public override void ShowConfig(int war_id)
        {
            
        }
    }

}


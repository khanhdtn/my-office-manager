using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ProtocolVN.Framework.Core;
using System.Data.Common;
using ProtocolVN.Plugin.WarningSystem;

namespace ProtocolVN.WarningType.QueryBuilderWarning
{
    public partial class frmConfig : ProtocolVN.Plugin.WarningSystem.frmConfigWarning,IConfigWarning
    {
        private int war_id;
        private string oldValue = "";
        public frmConfig(int war_id)
        {
            InitializeComponent();
            this.war_id = war_id;
            LoadData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region IConfigWarning Members

        public bool Save()
        {
            DbCommand command = DABase.getDatabase().GetSQLStringCommand("SELECT * FROM WARNING_PARAM WHERE WAR_ID=" + war_id);
            DataSet ds = DABase.getDatabase().LoadDataSet(command, "WARNING_PARAM");
            string value = "SELECT * FROM " + textEdit1.Text + " WHERE 1=1;" + textEdit1.Text + ";200";
            if (ds.Tables[0].Rows.Count > 0)
                ds.Tables[0].Rows[0][2] = value;
            else
            {
                DataRow dr = ds.Tables[0].NewRow();
                dr[0] = DABase.getDatabase().GetID("G_USER_CAT");
                dr[1] = war_id;
                dr[2] = value;
                ds.Tables[0].Rows.Add(dr);
            }
            if (DABase.getDatabase().UpdateTable(ds) != -1)
                this.Close();
            return true;
        }

        public void NoSave()
        {
            this.textEdit1.Text = oldValue;
        }

        public void LoadData()
        {
            try
            {
                DbCommand command = DABase.getDatabase().GetSQLStringCommand("SELECT * FROM WARNING_PARAM WHERE WAR_ID=" + war_id);
                DataSet ds = DABase.getDatabase().LoadDataSet(command, "WARNING_PARAM");
                string lstparam = ds.Tables[0].Rows[0][2].ToString();
                string[] param = lstparam.Split(';');
                int index1 = param[0].LastIndexOf("FROM ");
                int index2 = param[0].LastIndexOf(" WHERE");
                oldValue = param[0].Substring(index1 + 4, index2 - index1 - 4);
                this.textEdit1.Text = oldValue;
            }
            catch { }
        }

        #endregion

        private void btnNoSave_Click(object sender, EventArgs e)
        {
            NoSave();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }
    }
}
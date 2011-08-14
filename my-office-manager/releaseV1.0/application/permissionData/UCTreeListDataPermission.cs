using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ProtocolVN.Framework.Win;
using DevExpress.XtraTreeList.StyleFormatConditions;
using DevExpress.XtraTreeList.Nodes;

namespace PermissionOfResource
{
    internal partial class UCTreeListDataPermission : DevExpress.XtraEditors.XtraUserControl
    {
        public UCTreeListDataPermission()
        {
            InitializeComponent();

            HelpTreeList.CotCheckEdit(ColIsCreate_Bit, "ISCREATE_BIT");
            HelpTreeList.CotCheckEdit(ColIsRead_Bit, "ISREAD_BIT");
            HelpTreeList.CotCheckEdit(ColIsUpdate_Bit, "ISUPDATE_BIT");
            HelpTreeList.CotCheckEdit(ColIsDelete_Bit, "ISDELETE_BIT");
            HelpTreeList.CotCheckEdit(ColFull_Bit, "ISFULL_BIT");
            HelpTreeList.CotCheckEdit(ColISUseCreate, "USE_CREATE");
            HelpTreeList.CotTextLeft(ColName, "NAME");
            this.TreePermission.ParentFieldName = "PARENT_ID";
            this.TreePermission.KeyFieldName = "RESOURCE_ID";

            StyleFormatCondition style = new StyleFormatCondition();
            style.Column = ColIsCreate_Bit;
            style.Expression = "[USE_CREATE]=='N'";
            style.Condition = DevExpress.XtraGrid.FormatConditionEnum.Expression;
            style.Appearance.BackColor = Color.DarkGray;
            style.Appearance.Options.UseBackColor = true;
            TreePermission.FormatConditions.Add(style);
        }      

        public DataTable DataSource
        {
            get
            {
                if (this.TreePermission.DataSource != null && this.TreePermission.DataSource is DataTable)
                    return (DataTable)this.TreePermission.DataSource;
                return null;
            }
            set
            {
                this.TreePermission.DataSource = value;

            }
        }

        private void TreePermission_AfterExpand(object sender, DevExpress.XtraTreeList.NodeEventArgs e)
        {
            TreePermission.BestFitColumns();
        }

        private void TreePermission_AfterCollapse(object sender, DevExpress.XtraTreeList.NodeEventArgs e)
        {
            TreePermission.BestFitColumns();
        }

        private void TreePermission_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            if (TreePermission.FocusedColumn == null) return;
            TreePermission.FocusedColumn.OptionsColumn.AllowEdit = !(TreePermission.FocusedColumn.FieldName == ColIsCreate_Bit.FieldName &&
                 e.Node["USE_CREATE"].ToString() == "N");

        }

        private void TreePermission_FocusedColumnChanged(object sender, DevExpress.XtraTreeList.FocusedColumnChangedEventArgs e)
        {
            if (TreePermission.FocusedNode == null) return;
            e.Column.OptionsColumn.AllowEdit = !(e.Column.FieldName == ColIsCreate_Bit.FieldName &&
                  TreePermission.FocusedNode["USE_CREATE"].ToString() == "N");
        }

        private void TreePermission_CellValueChanging(object sender, DevExpress.XtraTreeList.CellValueChangedEventArgs e)
        {
            int startLevel = e.Node.Level;
            TreeListNode currentNode = e.Node;
            string bit_str = e.Value.ToString();
            string fieldName = e.Column.FieldName;
            if (fieldName == "ISFULL_BIT")
            {
                currentNode["ISFULL_BIT"] = bit_str;
                currentNode["ISREAD_BIT"] = bit_str;
                currentNode["ISUPDATE_BIT"] = bit_str;
                currentNode["ISDELETE_BIT"] = bit_str;
                if (currentNode["USE_CREATE"].ToString() == "Y")
                    currentNode["ISCREATE_BIT"] = bit_str;
            }
            else
            {
                currentNode[fieldName] = bit_str;

                if (currentNode["USE_CREATE"].ToString() == "N")
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
            }
        }
    }
}

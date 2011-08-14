using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ProtocolVN.Framework.Core;
using DevExpress.XtraTreeList.Nodes;

namespace office
{
    public partial class CustomerTree : DevExpress.XtraEditors.XtraUserControl
    {
        #region Properties
        int fristIndex, lastIndex;
        #endregion
        public CustomerTree()
        {
            InitializeComponent();
            popupContainerEdit1.CloseUp += new DevExpress.XtraEditors.Controls.CloseUpEventHandler(popupContainerEdit1_CloseUp);
        }
        /// <summary>
        /// TreeList's CloseUp event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void popupContainerEdit1_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            StringBuilder str = new StringBuilder();
            int i = fristIndex;
            TreeListNode nodes = treeListNhomKH.MoveFirst();
            if (nodes.GetValue("IS_CHON").Equals(true))str.Append(nodes.GetDisplayText("NAME") + ";");
            do {
                nodes = treeListNhomKH.MoveNext();
                if(nodes.GetValue("IS_CHON").Equals(true)) str.Append(nodes.GetDisplayText("NAME") + ";");
                i++;
            }
            while (i < lastIndex);
            e.Value = popupContainerEdit1.ToolTip = 
                str.Length > 0 ? str.Remove(str.Length - 1, 1).ToString().Replace("\r\n","") : string.Empty;
        }
        /// <summary>
        /// Initialize TreeList.
        /// </summary>
        public void CreateTree() 
        {
            DataTable dtParent = HelpDB.getDatabase().LoadDataSet(@"SELECT ID,NAME 
            FROM DM_KHACH_HANG_NHOM 
            WHERE ID_CHA =1 AND VISIBLE_BIT = 'Y'").Tables[0];
            dtParent.Columns.Add("IS_CHON", typeof(bool));
            DataTable dtChild = HelpDB.getDatabase().LoadDataSet(@"SELECT ID,NAME,ID_CHA 
            FROM DM_KHACH_HANG_NHOM 
            WHERE ID_CHA !=1 AND  ID_CHA != 0 AND VISIBLE_BIT = 'Y'" ).Tables[0];
            dtChild.Columns.Add("IS_CHON", typeof(bool));
            foreach (DataRow parentRow in dtParent.Rows) {
                TreeListNode parentNode = treeListNhomKH.AppendNode(new object[] { parentRow["NAME"], parentRow["ID"], false }, -1);
                foreach (DataRow childRow in dtChild.Rows) {
                    if (parentRow["ID"].ToString().Equals(childRow["ID_CHA"].ToString()))
                        treeListNhomKH.AppendNode(new object[] { childRow["NAME"], childRow["ID"], false }, parentNode.Id);
                }
            }
            fristIndex = 0;
            lastIndex = treeListNhomKH.AllNodesCount;
            //fristIndex = treeListNhomKH.GetVisibleIndexByNode(treeListNhomKH.MoveFirst());
            //lastIndex = treeListNhomKH.GetVisibleIndexByNode(treeListNhomKH.MoveLast());
            treeListNhomKH.ExpandAll();
            //treeListNhomKH.
        }
        /// <summary>
        /// Checks if nodes have selected on TreeList.
        /// </summary>
        /// <returns>False: haves node selected
        /// True: otherwise</returns>
        public bool IsEmptyTree() 
        {
            int i = fristIndex;
            TreeListNode nodes = treeListNhomKH.MoveFirst();
            if (nodes.GetValue("IS_CHON").Equals(true)) return false;
            do
            {
                nodes = treeListNhomKH.MoveNext();
                if (nodes.GetValue("IS_CHON").Equals(true)) return false;
                i++;
            }
            while (i < lastIndex);
            return true;
        }
        /// <summary>
        /// Gets selected nodes from TreeList.
        /// </summary>
        /// <returns></returns>
        public string GetSelectedID() 
        {
            StringBuilder str = new StringBuilder(",");
            int i = fristIndex;
            TreeListNode nodes = treeListNhomKH.MoveFirst();
            if (nodes.GetValue("IS_CHON").Equals(true)) str.Append(nodes.GetDisplayText("ID") + ",");
            do
            {
                nodes = treeListNhomKH.MoveNext();
                if (nodes.GetValue("IS_CHON").Equals(true)) str.Append(nodes.GetDisplayText("ID") + ",");
                i++;
            }
            while (i < lastIndex);
            return str.ToString();
        }
        /// <summary>
        /// Sets selected nodes from selected ids.
        /// </summary>
        /// <param name="strSelectedIDs">String ids to set.</param>
        public void SetSelectedID(string strSelectedIDs)
        {
            StringBuilder str = new StringBuilder();
            int i = fristIndex;
            TreeListNode nodes = treeListNhomKH.MoveFirst();
            if (strSelectedIDs.Contains("," + nodes.GetDisplayText("ID") + ",")) {
                str.Append(nodes.GetDisplayText("NAME") + ";");
                nodes.SetValue("IS_CHON", true);
            }
            do
            {
                nodes = treeListNhomKH.MoveNext();
                if (strSelectedIDs.Contains("," + nodes.GetDisplayText("ID") + ","))
                {
                    nodes.SetValue("IS_CHON", true);
                    str.Append(nodes.GetDisplayText("NAME") + ";");
                } 
                i++;
            }
            while (i < lastIndex);
            popupContainerEdit1.Text = str.Remove(str.Length - 1, 1).ToString().Replace("\r\n", "");
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ProtocolVN.Framework.Win;
using DevExpress.XtraTreeList.Columns;
using DevExpress.XtraTreeList.Nodes;
using ProtocolVN.Framework.Core;

namespace ProtocolVN.App.Office.ApplicationCore
{
    public partial class PLDMTreeMultiChoice : DevExpress.XtraEditors.XtraUserControl
    {
        #region Varibles

        private string IDField;
        private string ParentIDField;
        private string DisplayField;
        private string SelectedNames = "";
        private List<long> SelectedIDs;
        private bool IsGroup_Child;
        private string IsGroupField = "IS_GROUP";
        private bool CloseNoAccept = false;
        private int IndexGroupImage = -1;
        private int IndexImage = -1;
        private int IndexRootImage = -1;
        public delegate void AfterSelected(object sender, EventArgs e);
        public event AfterSelected _AfterSelected;
        private float zzzWidthFactor = 1f;
        #endregion

        #region _Init

        public PLDMTreeMultiChoice()
        {
            InitializeComponent();
            SelectedIDs = new List<long>();

            this.SizeChanged += new EventHandler(PLDMTreeMultiChoice_SizeChanged);
            this.Load += new EventHandler(PLDMTreeMultiChoice_Load);
        }

        void PLDMTreeMultiChoice_Load(object sender, EventArgs e)
        {
            if (zzzWidthFactor > 0)
            {
                this.popupContainerControl1.Width = this.Width * (int)zzzWidthFactor;
            }
        }

        void PLDMTreeMultiChoice_SizeChanged(object sender, EventArgs e)
        {
            if (zzzWidthFactor > 0)
            {
                this.popupContainerControl1.Width = this.Width * (int)zzzWidthFactor;
            }
        }
        public void _Init(DataTable DataSource, string IDField, string ParentIDField,
            string DisplayField, string[] VisibleFields, string[] Captions, TreeListColumnType[] ColumTypes, string RootImage,string GroupImage,string image)
        {
            if (VisibleFields == null)
                VisibleFields = new string[0];
            if (Captions == null)
                Captions = new string[0];
            if (ColumTypes == null)
                ColumTypes = new TreeListColumnType[0];
            if (VisibleFields.Length != Captions.Length &&
                VisibleFields.Length != ColumTypes.Length)
                throw new Exception("Vui lòng tryền 3 tham số mảng 'VisibleFields', 'Captions', 'ColumTypes' có cùng số phần tử!");


            Image rimg = ResourceMan.getImage(RootImage);
            Image gimg = ResourceMan.getImage(GroupImage);
            Image img = ResourceMan.getImage(image);
            if (gimg != null || img != null || rimg != null)
            {
                IndexRootImage = imageCollection1.Images.Add(rimg, RootImage);
                IndexGroupImage = imageCollection1.Images.Add(gimg, GroupImage);
                IndexImage = imageCollection1.Images.Add(img, image);
            }
            else treeList.StateImageList = null;
            this.IsGroup_Child = false;
            this.IDField = IDField;
            this.ParentIDField = ParentIDField;
            this.DisplayField = DisplayField;
            treeList.KeyFieldName = IDField;
            treeList.ParentFieldName = ParentIDField;
            treeList.Columns.Add().FieldName = IDField;
            for (int i = 0; i < VisibleFields.Length; i++)
            {
                TreeListColumn col = treeList.Columns.Add();
                col.OptionsColumn.AllowFocus = false;
                col.Visible = true;
                col.Caption = Captions[i];
                if (VisibleFields != null)
                    col.FieldName = VisibleFields[i];
                if (ColumTypes != null)
                    TreeListSupport.SetColumnType(col, ColumTypes[i]);
            }
            treeList.DataSource = DataSource;
            treeList.ExpandAll();
        }
        public void _Init(string GroupTableName, string GroupWhere, string GroupIDField, string GroupDisplayField, string GroupParentIDField,
            string TableName, string Where, string IDField, string DisplayField, string LinkField, string[] VisibleFields, string[] Captions,
            TreeListColumnType[] ColumnTypes, string RootImage, string GroupImage, string image)
        {
            if (VisibleFields == null)
                VisibleFields = new string[0];
            if (Captions == null)
                Captions = new string[0];
            if (ColumnTypes == null)
                ColumnTypes = new TreeListColumnType[0];
            if (VisibleFields.Length != Captions.Length ||
               VisibleFields.Length != ColumnTypes.Length || Captions.Length != ColumnTypes.Length)
                throw new Exception("Vui lòng tryền 3 tham số mảng 'VisibleFields', 'Captions', 'ColumTypes' có cùng số phần tử!");

            IsGroup_Child = true;
            this.IDField = IDField;
            this.ParentIDField = GroupParentIDField;
            this.DisplayField = DisplayField;
            treeList.KeyFieldName = IDField;
            treeList.ParentFieldName = ParentIDField;
            string sqlGroup = "";
            string sqlChild = "";
            string tempField = "";
            treeList.Columns.Add().FieldName = IDField;

            for (int i = 0; i < VisibleFields.Length; i++)
            {
                tempField = VisibleFields[i];
                if (tempField != GroupDisplayField)
                    sqlGroup += "NULL " + tempField + ",";
                if (tempField != DisplayField)
                    sqlChild += tempField + ",";
                TreeListColumn col = treeList.Columns.Add();
                col.OptionsColumn.AllowFocus = false;
                col.Visible = true;
                col.Caption = Captions[i];
                col.FieldName = tempField;
                TreeListSupport.SetColumnType(col, ColumnTypes[i]);
            }
            sqlGroup = sqlGroup.TrimEnd(',');
            sqlChild = sqlChild.TrimEnd(',');
            string sql = string.Format(@"select * from (select {0} {1}, {2} {3},{4}, 'Y' {5} {6}
                                       from {7}
                                       Where 1=1 {8}
                                       union
                                       select {1}, {3},{9} {4}, 'N' {5} {10}
                                       from {11}
                                       where {9} IS NOT NULL {12}) order by {5} desc, {3} asc", GroupIDField, IDField, GroupDisplayField, DisplayField, GroupParentIDField,
                                                                                     IsGroupField, (sqlGroup == "" ? "" : "," + sqlGroup), GroupTableName, (GroupWhere == "" ? "" : " AND " + GroupWhere),
                                                      LinkField, (sqlChild == "" ? "" : "," + sqlChild), TableName, (Where == "" ? "" : " AND " + Where));


            DataSet ds = HelpDB.getDBService().LoadDataSet(sql, TableName);
            Image rimg = ResourceMan.getImage(RootImage);
            Image gimg = ResourceMan.getImage(GroupImage);
            Image img = ResourceMan.getImage(image);
            if (gimg != null || image != null || rimg != null)
            {
                IndexRootImage = imageCollection1.Images.Add(rimg, RootImage);
                IndexGroupImage = imageCollection1.Images.Add(gimg, GroupImage);
                IndexImage = imageCollection1.Images.Add(img, image);
            }
            else treeList.StateImageList = null;
            if (ds != null && ds.Tables.Count > 0)
            {
                treeList.DataSource = ds.Tables[0];
                treeList.ExpandAll();
            }
        }
        #endregion

        #region Override

        public override Color BackColor
        {
            get
            {
                return this.popupContainerEdit1.BackColor;
            }
            set
            {
                this.popupContainerEdit1.BackColor = value;
            }
        }

        #endregion

        #region Pulic
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public long[] _SelectedIDs
        {
            get
            {
                return this.SelectedIDs.ToArray();
            }
            set
            {
                this.SelectedIDs = new List<long>(value);
                _UnChekedAll();
                SetCheckedValues(value);
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int _CountSelectedIDs
        {
            get
            {
                return SelectedIDs.Count;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string _SelectedStrIDs
        {
            get
            {
                string s = "";
                foreach (long id in SelectedIDs)
                {
                    s += id + ",";
                }
                if (s == "") s = "-1";
                else s = s.TrimEnd(',');
                return s;
            }
            set
            {
                if (value != null)
                {
                    string[] ids = value.Split(',');
                    this.SelectedIDs = new List<long>();
                    foreach (string s in ids)
                    {
                        SelectedIDs.Add(HelpNumber.ParseInt64(s));
                    }
                    SetCheckedValues(this.SelectedIDs.ToArray());
                }
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string _SelectedText
        {
            get
            {
                return SelectedNames;
            }
        }

        [DefaultValue(1f)]
        public float ZZZWidthFactor
        {
            set
            {
                zzzWidthFactor = value;
            }
            get
            {
                return zzzWidthFactor;
            }
        }
        public void _UnChekedAll()
        {
            foreach (TreeListNode n in treeList.Nodes)
            {
                n.Checked = false;
                SetCheckedChildNodes(n, CheckState.Unchecked);
            }
        }
        public void _CheckedAll()
        {
            foreach (TreeListNode n in treeList.Nodes)
            {
                n.Checked = true;
                SetCheckedChildNodes(n, CheckState.Checked);
            }
        }
        public void _SetError(DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider error, string message)
        {
            error.SetError(popupContainerEdit1, message);
        }
        public string _GetDisplayTextByID(long ID)
        {
            TreeListNode n = treeList.FindNodeByKeyID(ID);
            if (n != null)
                return n[DisplayField].ToString();
            return "";
        }
        #endregion

        #region Private

        private void SetCheckedChildNodes(TreeListNode node, CheckState check)
        {
            for (int i = 0; i < node.Nodes.Count; i++)
            {
                node.Nodes[i].CheckState = check;
                SetCheckedChildNodes(node.Nodes[i], check);
            }
        }
        private void SetCheckedParentNodes(TreeListNode node, CheckState check)
        {
            if (node.ParentNode != null)
            {
                bool b = false;
                CheckState state;
                for (int i = 0; i < node.ParentNode.Nodes.Count; i++)
                {
                    state = (CheckState)node.ParentNode.Nodes[i].CheckState;
                    if (!check.Equals(state))
                    {
                        b = !b;
                        break;
                    }
                }
                node.ParentNode.CheckState = b ? CheckState.Indeterminate : check;
                SetCheckedParentNodes(node.ParentNode, check);
            }
        }
        private void AcceptSelectedNode(TreeListNodes nodes)
        {
            foreach (TreeListNode n in nodes)
            {
                if (n.Checked)
                {
                    SelectedNames += n[DisplayField].ToString() + ",";
                    SelectedIDs.Add(HelpNumber.ParseInt64(n[IDField]));
                }
                AcceptSelectedNode(n.Nodes);
            }
        }
        private void AcceptSelectedNode_GroupChild(TreeListNodes nodes)
        {
            foreach (TreeListNode n in nodes)
            {
                if (n.Checked && n[IsGroupField].ToString() == "N")
                {
                    SelectedNames += n[DisplayField].ToString() + ",";
                    SelectedIDs.Add(HelpNumber.ParseInt64(n[IDField]));
                }
                AcceptSelectedNode_GroupChild(n.Nodes);
            }
        }

        private void treeList_AfterCheckNode(object sender, DevExpress.XtraTreeList.NodeEventArgs e)
        {
            SetCheckedChildNodes(e.Node, e.Node.CheckState);
            SetCheckedParentNodes(e.Node, e.Node.CheckState);
        }
        private void treeList_BeforeCheckNode(object sender, DevExpress.XtraTreeList.CheckNodeEventArgs e)
        {
            e.State = (e.PrevState == CheckState.Checked ? CheckState.Unchecked : CheckState.Checked);

        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            this.popupContainerEdit1.ClosePopup();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            CloseNoAccept = true;

            this.popupContainerEdit1.ClosePopup();
        }
        private void popupContainerEdit1_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            if (CloseNoAccept == false)
            {

                SelectedIDs = new List<long>();
                SelectedNames = "";
                if (IsGroup_Child)
                {
                    AcceptSelectedNode_GroupChild(treeList.Nodes);
                }
                else
                {
                    AcceptSelectedNode(treeList.Nodes);
                }
                SelectedNames = SelectedNames.TrimEnd(',');
                this.popupContainerEdit1.EditValue = SelectedIDs;
                this.popupContainerEdit1.ToolTip = SelectedNames;
                e.Value = SelectedNames;
                if (_AfterSelected != null)
                    _AfterSelected(this, new EventArgs());
            }
            else
            {
                CloseNoAccept = false;
                SetCheckedValues(SelectedIDs.ToArray());
            }
        }
        private void SetCheckedValues(long[] IDs)
        {
            _UnChekedAll();
            SelectedNames = "";
            foreach (long id in IDs)
            {

                TreeListNode n = treeList.FindNodeByKeyID(id);
                if (n != null)
                {
                    SelectedNames += n[DisplayField].ToString() + ",";
                    n.CheckState = CheckState.Checked;
                    SetCheckedChildNodes(n, CheckState.Checked);
                    SetCheckedParentNodes(n, CheckState.Checked);
                }
                else
                {
                    SelectedIDs.Remove(id);
                }
            }
            SelectedNames = SelectedNames.TrimEnd(',');
            this.popupContainerEdit1.Text = SelectedNames;
            this.popupContainerEdit1.ToolTip = SelectedNames;
        }
        private void treeList_GetStateImage(object sender, DevExpress.XtraTreeList.GetStateImageEventArgs e)
        {
            if (IsGroup_Child)
            {
                if (e.Node.Level == 0)
                {
                    e.Node.StateImageIndex = IndexRootImage;
                }
                else
                {
                    if (e.Node[IsGroupField].ToString() == "Y")
                    {
                        e.Node.StateImageIndex = IndexGroupImage;
                    }
                    else
                    {
                        e.Node.StateImageIndex = IndexImage;
                    }
                }
            }
            else
            {
                if (e.Node.Level == 0)
                {
                    e.Node.StateImageIndex = IndexRootImage;
                }
                else
                {
                    if (e.Node.Nodes.Count == 0)
                    {
                        e.Node.StateImageIndex = IndexImage;
                    }
                    else
                    {
                        e.Node.StateImageIndex = IndexGroupImage;
                    }
                }
            }
            
        }
        #endregion

    }
}

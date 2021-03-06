using System;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Windows.Forms;
using Chilkat;
using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using ProtocolVN.Framework.Core;
using ProtocolVN.Framework.Win;

namespace pl.mail
{
    public struct FolderRoot
    {
        public static string Local = "Hộp thư nội bộ";
        public static string Outside = "Hộp thư bên ngoài";
        public static string Private = "Thư mục cá nhân";       
    }

    public partial class frmMessage : DevExpress.XtraEditors.XtraForm
    {
        public static bool isConnectPrivateMailServer = false;

        private string UserMail;
        private string Password;
        private string UserId;
        private TreeListNode node ;
        private string state= null; //state = Rename; Add; Delete
        private Folder fol;
        private Email mail;
        private Message mess;
        private bool isShowMessage = false;
        private bool isFocusNodeEvent = false;
        private bool connectFail = false;
        private DataTable ListFolder = new DataTable();
        private DataSet DSListFolderMessage = new DataSet();
        

        /********************************************************************************/
        /******************************** Khở tạo form *********************************/
        #region Initailization
        /// <summary>
        /// Để chạy hệ thông mail application
        /// Thứ 1: Cần một mailserver nội bộ
        /// Thứ 2: Database liên quan gồm : DM_LOAITHU: Chứa loại thư, MAILINFO : Chứa tài khoản của người dùng
        /// </summary>
        public frmMessage()
        {
            try
            {
                ListFolder.Columns.Add("Thư mục", Type.GetType("System.String"));
                ListFolder.Columns.Add("Nhóm", Type.GetType("System.String"));
            }
            catch 
            {}
            isConnectPrivateMailServer = initConfig();      
            InitializeComponent();
            this.Text = "Quản lý mail nội bộ";
           
        }
        private bool initConfig()
        {
            if (Connect.SetConfigInfo())
            {
                UserMail = FrameworkParams.currentUser.username + "@" + Connect.domain;
                //HUYLX : Thiết lập lại password
                //Password = FrameworkParams.currentUser.password;
                Password = FrameworkParams.currentUser.id + "_protocolvn";
                UserId = FrameworkParams.currentUser.id.ToString();
            }
            fol = new Folder(UserMail, Password);
            mess = new Message(UserMail, Password);
            
            return CheckConnect();
        }

        private void _initGridView()
        {
            gridView1.OptionsBehavior.Editable = false;
            gridView1.OptionsView.ShowGroupPanel = false;
            gridView1.OptionsView.ShowFooter = false;
            gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            gridView1.OptionsMenu.EnableColumnMenu = false;
            gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
            gridView1.OptionsView.ShowVertLines = false;
            gridView1.OptionsView.ShowIndicator = false;
            gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            ColAnswered.OptionsColumn.AllowSize = false;
            ColAnswered.Width = 18;
            ColAttachment.OptionsColumn.AllowSize = false;
            ColAttachment.Width = 18;
            ColReaded.OptionsColumn.AllowSize = false;
            ColReaded.Width = 18;
        }  
               
        private void frmMessage_Load(object sender, EventArgs e)
        {
            _initGridView();
            load_tree();
            treeList1.OptionsBehavior.Editable = false; 
            treeList1.OptionsBehavior.AutoFocusNewNode = true;
            treeList1.OptionsSelection.MultiSelect = false;
           
            gridView1.FocusedRowChanged+=new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(gridView1_FocusedRowChanged);
            treeList1.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.treeList1_FocusedNodeChanged);
            treeList1.NodeCellStyle+=new DevExpress.XtraTreeList.GetCustomNodeCellStyleEventHandler(treeList1_NodeCellStyle);
            treeList1.Click += new EventHandler(treeList1_Click);
            gridView1.Click += new EventHandler(gridView1_Click);
            frmMessage_Resize(null, null);
            this.Resize += new EventHandler(frmMessage_Resize);
            
            //treeList1.SetFocusedNode(treeList1.Nodes[0].Nodes[0]);
        }
        
        #endregion

        /********************************************************************************/
        /******************************** Xử lý sự kiện *********************************/
        #region Xử lý sự kiện

        //*************************************************************************************************************************
        // TreeList Event
       
        private void treeList1_NodeCellStyle(object sender, DevExpress.XtraTreeList.GetCustomNodeCellStyleEventArgs e)
        {
            string caption = e.Node[1].ToString();
            try
            {
                int.Parse(caption.Substring(caption.LastIndexOf("(") + 1, caption.LastIndexOf(")") - caption.LastIndexOf("(") - 1));
                e.Appearance.Font = new Font(treeList1.Font, FontStyle.Bold);
            }
            catch {}
        }

        private void treeList1_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            try
            {
                if (state != null)
                {
                    treeList1.OptionsBehavior.Editable = false;
                    EditFolder();
                    return;
                }

                if (treeList1.FocusedNode[2] != null)
                {
                    resetView();
                    load_grid(treeList1.FocusedNode[2].ToString());
                    isFocusNodeEvent = true;
                    if ((treeList1.FocusedNode.ParentNode.Id == 0) | (treeList1.FocusedNode.ParentNode.Id == 1))
                    {
                        barBtRename.Enabled = false;
                        barBtDeleteFolder.Enabled = false;
                    }
                    else
                    {
                        barBtRename.Enabled = true;
                        barBtDeleteFolder.Enabled = true;
                    }

                    if (treeList1.FocusedNode[2].ToString() == "Deleted Items")
                        barBtDeleteMessage.Caption = "Xóa vĩnh viễn";
                    else
                        barBtDeleteMessage.Caption = "Xóa thư";

                    if (treeList1.FocusedNode[2].ToString() == "Drafts")
                        gridView1.DoubleClick += new EventHandler(gridView1_DoubleClick);
                    else
                        gridView1.DoubleClick -= new EventHandler(gridView1_DoubleClick);

                    if (gridView1.RowCount < 1)
                    {
                        barBtDeleteMessage.Enabled = false;
                        barBtForward.Enabled = false;
                        barBtReply.Enabled = false;
                    }
                    else
                    {
                        barBtDeleteMessage.Enabled = true;
                        barBtForward.Enabled = true;
                        barBtReply.Enabled = true;
                    }
                }
                else
                {
                    resetView();
                    barBtRename.Enabled = false;
                    barBtDeleteFolder.Enabled = false;
                }
            }
            catch { }
        }
        private void treeList1_Click(object sender, EventArgs e)
        {
            try
            {
                if (!isFocusNodeEvent)
                    load_grid(treeList1.FocusedNode[2].ToString());
                else
                    isFocusNodeEvent = false;
            }
            catch { }
        }
        
        //*************************************************************************************************************************
        // Grid Event
        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            if (gridView1.GetDataRow(gridView1.FocusedRowHandle)[0].ToString() != null)
            {
                mail = mess.GetMessage(treeList1.FocusedNode[2].ToString(), (int) gridView1.GetDataRow(gridView1.FocusedRowHandle)[0]);
                frmNewMessage form = new frmNewMessage(mail, "Drafts",this);
                ProtocolForm.ShowDialog(this, form);
            }
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gridView1.SelectedRowsCount > 1)
            {
                webHTML.DocumentText = "Chọn nhiều thư";
                return;
            }
            if (showMessage())
            {
                isShowMessage = true;
                DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
                dr["Readed"] = "Read";                
                UpdateSumMsg();
            }
            else
            {
                MessageError();
            }
        }

        private void gridView1_Click(object sender, EventArgs e)
        {
            if (gridView1.SelectedRowsCount > 1)
            {
                webHTML.DocumentText = "Chọn nhiều thư";
                return;
            }
            if (!isShowMessage)
            {
                if (showMessage())
                {
                    isShowMessage = true;
                    DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
                    dr["Readed"] = "Read";
                    UpdateSumMsg();
                }
                else
                {
                    MessageError();
                }
            }
            else
                isShowMessage = false;
        }
        //*************************************************************************************************************************
        // Bar button click event

        // Tạo thư mục mới
        private void barBtNewFolder_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (state != null)
                EditFolder();

            treeList1.OptionsBehavior.Editable = true;
            treeList1.FocusedNodeChanged -= new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.treeList1_FocusedNodeChanged);

            AddNode("Thư mục mới", 2,6,0);

            treeList1.FocusedNode = treeList1.Nodes[2].Nodes[treeList1.Nodes[2].Nodes.Count - 1];

            node = treeList1.FocusedNode;
            state = "Add";
            treeList1.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.treeList1_FocusedNodeChanged);
        }
        
        // Đổi tên thư mục
        private void barBtRename_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (state != null)
                EditFolder();
            
            treeList1.OptionsBehavior.Editable = true;
            node = treeList1.FocusedNode;
            node[1] = node[0];
            state = "Rename";
        }
        
        // Xóa thư mục
        private void barBtDeleteFolder_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (state != null)
                EditFolder();

            node = treeList1.FocusedNode;
            state = "Delete";
            EditFolder();
        }
        
        // Xóa messages
        private void barBtDeleteMessage_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (barBtDeleteMessage.Caption == "Xóa thư")
            {
                if (!MoveMessages(treeList1.FocusedNode[2].ToString(), "Deleted Items"))
                    PLMessageBox.ShowErrorMessage("Không xóa được thư");
                else
                    UpdateSumMsg();
            }
            else
            {
                int[] MsgID = new int[gridView1.SelectedRowsCount];

                int j = 0;
                foreach (int i in gridView1.GetSelectedRows())
                    MsgID[j++] = (int)gridView1.GetDataRow(i)[0];
                j--;

                if (mess.DeleteMessage(MsgID, treeList1.FocusedNode[2].ToString()))
                    gridView1.DeleteSelectedRows();
            }

        }
        
        // Tạo message mới
        private void barBtNewMessage_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmNewMessage form = new frmNewMessage();
            ProtocolForm.ShowDialog(this, form);
        }
        
        // Trả lời thư
        private void barBtReply_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (gridView1.GetDataRow(gridView1.FocusedRowHandle)[0].ToString() != null)
                {
                    mail = getMessage(treeList1.FocusedNode[2].ToString(),(int) gridView1.GetDataRow(gridView1.FocusedRowHandle)[0]);
                    frmNewMessage form = new frmNewMessage(mail, "Reply",this);
                    ProtocolForm.ShowDialog(this, form);
                }
            }
            catch
            {
                PLMessageBox.ShowErrorMessage("Có lỗi");
            }
        }
        
        // Chuyển tiếp thư
        private void barBtForward_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (gridView1.GetDataRow(gridView1.FocusedRowHandle)[0].ToString() != null)
                {
                    mail = getMessage(treeList1.FocusedNode[2].ToString(),(int) gridView1.GetDataRow(gridView1.FocusedRowHandle)[0]);
                    frmNewMessage form = new frmNewMessage(mail, "Forward",this);
                    ProtocolForm.ShowDialog(this, form);                
                }
            }
            catch
             {
                 PLMessageBox.ShowErrorMessage("Có lỗi");
             }
        }           
        
        private void barBtSyncMail_ItemClick(object sender, ItemClickEventArgs e)
        {            
            WaitingMsg.LongProcess(GetNewMail);
        }
        
        // Gọi form chỉnh sửa Account
        private void barbtConfig_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmAccount form = new frmAccount(this);
            ProtocolForm.ShowDialog(this, form);             
        }

        // Di chuyển message
        private void barEIListFolder_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                string ToFolder = barEIListFolder.EditValue.ToString();
                string FromFolder = treeList1.FocusedNode[2].ToString();
                if ((ToFolder != "[Chuyển tới]") & (treeList1.FocusedNode[1].ToString() != ToFolder))
                {
                    barEIListFolder.EditValue = "[Chuyển tới]";
                    if (!MoveMessages(FromFolder, ToFolder))
                        PLMessageBox.ShowErrorMessage("Không di chuyển thư được");
                    else
                        UpdateSumMsg();
                }
            }
            catch
            {
                PLMessageBox.ShowErrorMessage("Không chuyển thư được");
            }
        }
        
        // When user click to choose attachment in checkComboBox
        private void checkedComboBoxEdit1_EditValueChanged(object sender, EventArgs e)
        {
            if ((checkedComboBoxEdit1.Text != "Chọn file") & (checkedComboBoxEdit1.Text != ""))
                btDownLoad.Visible = true;
            else
                btDownLoad.Visible = false;
        }

        // Download attachment
        private void btDownLoad_Click(object sender, EventArgs e)//Download attachments 
        {
            folderBrowserDialog1.ShowDialog();
            string path = folderBrowserDialog1.SelectedPath;
            string[] attachment = new string[checkedComboBoxEdit1.Properties.Items.Count];
            string attName = "";
            int j = 0;
            for (int i = 0; i < checkedComboBoxEdit1.Text.Length; i++)
            {
                if (checkedComboBoxEdit1.Text[i].ToString() != ",")
                    attName += checkedComboBoxEdit1.Text[i];
                else
                {
                    attachment[j++] = attName;
                    attName = "";
                    i++;
                }
            }
            attachment[j++] = attName;
            mess.DownAttach(treeList1.FocusedNode[2].ToString(), (int)gridView1.GetDataRow(gridView1.FocusedRowHandle)[0], attachment, path);

        }

        // Resize from 
        private void frmMessage_Resize(object sender, EventArgs e)
        {
            this.splitContainerControl2.SplitterPosition = (this.Height / 7) * 3 + 15;
        }
        //*************************************************************************************************************************
        // Xử lý drag & drop
        GridHitInfo hitInfo = null;
        private void gridControl1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            hitInfo = gridView1.CalcHitInfo(new Point(e.X, e.Y));
        }

        private void gridControl1_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            try
            {
                if (hitInfo == null) return;
                if (e.Button != MouseButtons.Left) return;
                Rectangle dragRect = new Rectangle(new Point(
                    hitInfo.HitPoint.X - SystemInformation.DragSize.Width / 2,
                    hitInfo.HitPoint.Y - SystemInformation.DragSize.Height / 2), SystemInformation.DragSize);
                if (!dragRect.Contains(new Point(e.X, e.Y)))
                {
                    gridControl1.DoDragDrop((object)(treeList1.FocusedNode[2]), DragDropEffects.Move);
                }
            }
            catch { }
        }

        private void treeList1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data != null)
                e.Effect = DragDropEffects.Move;
        }

        private void treeList1_DragDrop(object sender, DragEventArgs e)
        {
            string FromFolder = (string)(e.Data.GetData(typeof(string)) as string);
            TreeListHitInfo hitinfo = treeList1.CalcHitInfo(treeList1.PointToClient(new Point(e.X, e.Y)));
            TreeListNode node = hitinfo.Node;

            if (node.ParentNode == null)
            {
                PLMessageBox.ShowErrorMessage("Không chuyển thư đến mục này");
                return;
            }
            else
            {
                string ToFolder = node[2].ToString();
                if (FromFolder != ToFolder)
                    if (!MoveMessages(FromFolder, ToFolder))
                        PLMessageBox.ShowErrorMessage("Không di chuyển thư được");
            }

        }
        #endregion

        /********************************************************************************/
        /******************************** Các hàm hỗ trợ ********************************/
        #region Function
        /// <summary>...
        /// True: Kết nối thành công
        /// False: Kết nối thất bại
        /// </summary>
        /// <returns></returns>
        private bool CheckConnect()
        {
            string error = "";
            try
            {
                FrameworkParams.wait = new WaitingMsg();                
                fol.TestConnectServer(ref error);
            }
            finally
            {
                if (FrameworkParams.wait != null) FrameworkParams.wait.Finish();
            }
            if (error !="")
            {
                if (error == "Server")
                {
                    DialogResult result = PLMessageBox.ShowConfirmMessage("Bạn có muốn cấu hình lại hệ thống mail nội bộ không?");
                    if (result == DialogResult.Yes)
                    {
                        frmConfigServer form = new frmConfigServer(this);
                        ProtocolForm.ShowModalDialog(FrameworkParams.MainForm, form, false);
                        if (connectFail)
                        {
                            return false;
                        }
                        initConfig();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    DialogResult result = PLMessageBox.ShowConfirmMessage("Ban không đăng nhập được với server, có thể phương thức đang nhập không đúng.\n Bạn có muốn cấu hình lại hệ thống mail nội bộ không?");
                    if (result == DialogResult.Yes)
                    {
                        frmConfigServer form = new frmConfigServer(this);
                        ProtocolForm.ShowModalDialog(FrameworkParams.MainForm, form, false);
                        if (connectFail) return false;
                        initConfig();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return false;
        }

        // Đóng chương trình
        public void closeform()
        {
            this.connectFail = true;
        }

        // Thêm button cho button Lấy thư mới
        private void AddMenuButton(string Caption)
        {
            DevExpress.XtraBars.BarItem item = new BarButtonItem (barManager1,Caption);
            item.ItemClick+= new ItemClickEventHandler(ItemClick);
            popupMenu1.AddItem(item);
        }
        private void ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                FrameworkParams.wait = new WaitingMsg();

                if (e.Item.Caption == "Hộp thư đến")
                    GetInternalMail();
                else
                    GetExternalMail(e.Item.Caption);
                treeList1.FocusedNode = treeList1.Nodes[0];
                UpdateSumMsgTreeList();
            }
            finally
            {
                if (FrameworkParams.wait != null) FrameworkParams.wait.Finish();
            }
        }

        // Load thư mục hệ thông lên trên treelist
        private void load_tree()
        {
            treeList1.ClearNodes();
           
            DataTable dt = fol.FolderMessage(UserId);

            this.treeList1.BeginUnboundLoad();
            this.treeList1.AppendNode(new object[] { FolderRoot.Local, FolderRoot.Local }, -1, 5, 5, 0);
            this.treeList1.AppendNode(new object[] { FolderRoot.Outside, FolderRoot.Outside }, -1, 12, 12, 0);
            this.treeList1.AppendNode(new object[] { FolderRoot.Private, FolderRoot.Private }, -1, 10, 10, 0);

            string mapFolderName;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow drListFolder = ListFolder.NewRow();
                string name = dt.Rows[i][0].ToString();
                switch (dt.Rows[i][1].ToString())
                {
                    case "0":
                        mapFolderName = MapDisplayText(name);
                        drListFolder[0] = mapFolderName;
                        drListFolder[1] = FolderRoot.Local;
                        
                        switch (name)
                        {
                            case "Inbox":
                                if (dt.Rows[i][2].ToString() != "0")
                                    this.treeList1.AppendNode(new object[] { mapFolderName, mapFolderName + " (" + dt.Rows[i][2].ToString() + ")", name, (int)dt.Rows[i][2] }, 0, 0, 0, 0);
                                else
                                    this.treeList1.AppendNode(new object[] { mapFolderName, mapFolderName, name, (int)dt.Rows[i][2] }, 0, 0, 0, 0);
                                AddMenuButton(mapFolderName);
                                break;
                            case "Deleted Items":
                                if (dt.Rows[i][2].ToString() != "0")
                                    this.treeList1.AppendNode(new object[] { mapFolderName, mapFolderName + " (" + dt.Rows[i][2].ToString() + ")", name }, 0, 3, 3, 0);
                                else
                                    this.treeList1.AppendNode(new object[] { mapFolderName, mapFolderName, name }, 0, 3, 3, 1);
                                break;
                            case "Drafts":
                                if (dt.Rows[i][2].ToString() != "0")
                                    this.treeList1.AppendNode(new object[] { mapFolderName, mapFolderName + " (" + dt.Rows[i][2].ToString() + ")", name }, 0, 11, 11, 1);
                                else
                                    this.treeList1.AppendNode(new object[] { mapFolderName, mapFolderName, name }, 0, 11, 11, 1);
                                break;
                            case "Junk E-mail":
                                if (dt.Rows[i][2].ToString() != "0")
                                    this.treeList1.AppendNode(new object[] { mapFolderName, mapFolderName + " (" + dt.Rows[i][2].ToString() + ")", name }, 0, 9, 9, 1);
                                else
                                    this.treeList1.AppendNode(new object[] { mapFolderName, mapFolderName, name }, 0, 9, 9, 1);
                                break;
                            case "Sent Items":
                                if (dt.Rows[i][2].ToString() != "0")
                                    this.treeList1.AppendNode(new object[] { mapFolderName, mapFolderName + " (" + dt.Rows[i][2].ToString() + ")", name }, 0, 2, 2, 1);
                                else
                                    this.treeList1.AppendNode(new object[] { mapFolderName, mapFolderName, name }, 0, 2, 2, 1);
                                break;                            
                        }
                        break;
                    case "1":
                        
                        drListFolder[0] = name;
                        drListFolder[1] = FolderRoot.Outside;
                        AddMenuButton(name);
                        if (dt.Rows[i][2].ToString() != "0")
                            this.treeList1.AppendNode(new object[] { name, name + " (" + dt.Rows[i][2].ToString() + ")", name, (int)dt.Rows[i][2] }, 1, 1, 1, 0);
                        else
                            this.treeList1.AppendNode(new object[] { name, name, name, (int)dt.Rows[i][2] }, 1, 1, 1, 0);
                        break;
                    case "2":
                        drListFolder[0] = name;
                        drListFolder[1] = FolderRoot.Private;
                        if (dt.Rows[i][2].ToString() != "0")
                            this.treeList1.AppendNode(new object[] { name, name + " (" + dt.Rows[i][2].ToString() + ")", name, (int)dt.Rows[i][2] }, 2, 6, 6, 0);
                        else
                            this.treeList1.AppendNode(new object[] { name, name, name, (int)dt.Rows[i][2] }, 2, 6, 6, 0);
                        break;
                }
                ListFolder.Rows.Add(drListFolder);
            }           
            
            repositoryItemGridLookUpEdit1.DataSource = ListFolder;
            repositoryItemGridLookUpEdit1.DisplayMember = "Thư mục";
            repositoryItemGridLookUpEdit1.ValueMember = "Thư mục";
            barEIListFolder.EditValue = "[Chuyển tới]";
            repositoryItemGridLookUpEdit1View.Columns[1].Group();
            repositoryItemGridLookUpEdit1View.ExpandAllGroups();
            this.barEIListFolder.EditValueChanged += new System.EventHandler(this.barEIListFolder_EditValueChanged);
            this.treeList1.EndUnboundLoad();
            this.treeList1.ExpandAll();
            this.treeList1.AllowDrop = true;
            
        }

        // Load grid
        private void load_grid(string FolderName)
        {
            if (DSListFolderMessage.Tables[FolderName] == null)
            {
                this.gridView1.FocusedRowChanged -= new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView1_FocusedRowChanged);
                DSListFolderMessage.Tables.Add(fol.ListMessage(FolderName,null));
                gridControl1.DataSource = DSListFolderMessage.Tables[FolderName];
                this.gridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView1_FocusedRowChanged);
            }
            else
            {
                this.gridView1.FocusedRowChanged -= new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView1_FocusedRowChanged);
                gridControl1.DataSource = DSListFolderMessage.Tables[FolderName];
                this.gridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView1_FocusedRowChanged);
            }
            
            UpdateSumMsg();
        }

        // Move message
        private bool MoveMessages(string FromFolder, string ToFolder)
        {
            int[] MsgID = new int[gridView1.SelectedRowsCount];
            ToFolder = GetOrgFolder(ToFolder);
            int j = 0;
            foreach (int i in gridView1.GetSelectedRows())
                MsgID[j++] = (int)gridView1.GetDataRow(i)[0];
            j--;
            if (MsgID.Length == 0)
                return true;
           
            if (mess.MoveMessage(MsgID, FromFolder, ToFolder))
            {
                if (DSListFolderMessage.Tables[ToFolder] != null)
                {
                    DataTable MovedMessage = fol.ListMessage(ToFolder, gridView1.SelectedRowsCount);
                    foreach (DataRow dr in MovedMessage.Rows)
                    {
                        DataRow newRow =  DSListFolderMessage.Tables[ToFolder].NewRow();
                        newRow.ItemArray = dr.ItemArray;
                        DSListFolderMessage.Tables[ToFolder].Rows.Add(newRow);
                    }
                }               

                gridView1.DeleteSelectedRows();
                return true;
            }
            return false;
        }

        // Đồng bộ thư
        private void GetNewMail()
        {
            GetExternalMail(null);
            GetInternalMail();

            treeList1.FocusedNode = treeList1.Nodes[0];
            UpdateSumMsgTreeList();
        }
        private void GetInternalMail()
        {
            if (DSListFolderMessage.Tables[treeList1.Nodes[0].Nodes[0][2].ToString()] != null)
            {
                DataTable dtTable = DSListFolderMessage.Tables[treeList1.Nodes[0].Nodes[0][2].ToString()];
                int UnreadMessage = fol.UpdateTableMessage(ref dtTable) + (int)treeList1.Nodes[0].Nodes[0][3];
                treeList1.Nodes[0].Nodes[0].SetValue(treeList1.Columns[3].FieldName, UnreadMessage);
            }
        }
        private void GetExternalMail(string FolderName)
        {
            DbCommand command = DABase.getDatabase().GetSQLStringCommand("SELECT * FROM MAILINFO WHERE IDUSER=" + UserId);
            DataSet ds = new DataSet();
            ds = DABase.getDatabase().LoadDataSet(command, "MAILINFO");
            bool exist = false;
            int numNewMessage = 0;
            for (int i = 0; i < ds.Tables["MailInfo"].Rows.Count; i++)
            {
                DataRow dr = ds.Tables["MailInfo"].Rows[i];
                if (FolderName!=null)
                    if(dr["FOLDER"].ToString()!=FolderName)
                        continue;
                if (dr["IsIMAP"].ToString() == "Y")
                    numNewMessage = mess.GetMailIMAPDelete((string)dr["FOLDER"], (string)dr["Host"], (int)dr["Port"], (dr["SSL"].ToString() == "1") ? true : false, (string)dr["UserMail"], (string)dr["Password"]);
                else
                    numNewMessage = mess.GetMailPOPDelete((string)dr["FOLDER"], (string)dr["Host"], (int)dr["Port"], (dr["SSL"].ToString() == "1") ? true : false, (string)dr["UserMail"], (string)dr["Password"]);

                exist = false;
                foreach (TreeListNode node in treeList1.Nodes[1].Nodes)
                {
                    if (node[0].ToString() == dr["FOLDER"].ToString())
                    {
                        exist = true;
                        node.SetValue(treeList1.Columns[3].FieldName, (int)node[3] + numNewMessage);
                        break;
                    }
                }
                if (!exist)
                {
                    AddNode(dr["FOLDER"].ToString(), 1, 1, numNewMessage);                    
                }                
                if (DSListFolderMessage.Tables[dr["Folder"].ToString()] != null)
                {
                    DataTable dtTable = DSListFolderMessage.Tables[dr["Folder"].ToString()];
                    fol.UpdateTableMessage(ref dtTable);
                }
            }                    
           
        }

        //Map folder he thong sang folder bang Tieng Viet cua minh
        private string MapDisplayText( string SysFolderName)
        {
            string MapName = "";
            switch (SysFolderName)
            {
                case "Inbox":
                    MapName = "Hộp thư đến";                    
                    break;
                case "Deleted Items":
                    MapName = "Hộp thư đã xóa";                   
                    break;
                case "Drafts":
                    MapName = "Thư nháp";                   
                    break;
                case "Junk E-mail":
                    MapName = "Thư linh tinh";                   
                    break;
                case "Sent Items":
                    MapName = "Hộp thư gửi";                    
                    break;
                default:
                    MapName = SysFolderName;                   
                    break;
            }
            return MapName;
        }
        private string GetOrgFolder(string Name)
        {
            switch (Name)
            {
                case "Hộp thư đến":
                    return "Inbox";
                case "Hộp thư đã xóa":                   
                    return "Deleted Items";
                case "Thư nháp":                   
                    return "Drafts";
                case "Thư linh tinh":                    
                    return "Junk E-mail";
                case "Hộp thư gửi":
                    return "Sent Items";
                default:
                    return Name;                 
            }
        }       
        
        // Thêm node vào tree        
        private void AddNode(string FolderName, int rootNode,int image,int numUnread)
        {
            this.treeList1.BeginUnboundLoad();

            this.treeList1.AppendNode(new object[] { FolderName, FolderName, FolderName ,numUnread }, rootNode, image, image, 0);
            this.treeList1.EndUnboundLoad();
            this.treeList1.ExpandAll();
            DataRow dr = ListFolder.NewRow();
            dr[0] = FolderName;
            switch (rootNode)
            {
                case 0: 
                    dr[1] = FolderRoot.Local;
                    break;
                case 1:
                    dr[1] = FolderRoot.Outside;
                    break;
                case 2:
                    dr[1] = FolderRoot.Private;
                    break;
            }
            ListFolder.Rows.Add(dr);
        }

        //Xóa node trong tree
        private void DelNode(TreeListNode node)
        {
            if (DSListFolderMessage.Tables[node[2].ToString()] != null)
                DSListFolderMessage.Tables.Remove(node[2].ToString());
            
            foreach (DataRow dr in ListFolder.Rows)
            {
                if (dr[0].ToString() == node[2].ToString())
                {
                    ListFolder.Rows.Remove(dr);
                    break;
                }
            }
            treeList1.DeleteNode(node); 
        }
        
        // Đổi tên trên barEIMoveMail 

        private void RenameMoveMail(string oldName, string newName)
        {
            foreach (DataRow dr in ListFolder.Rows)
            {
                if (dr[0].ToString() == oldName)
                {
                    dr[0] = newName;
                    break;
                }
            }
        }

        // Thêm, xóa, sửa thư mục 
        private void EditFolder()
        {
            switch (state)
            {
                case ("Add"):
                    if (!fol.NewFolder(node[1].ToString()))
                    {
                        //HUYLX : Thay lại bằng hàm trong framework
                        PLMessageBox.ShowErrorMessage("Thêm thư mục không thành công");
                        DelNode(node); 
                    }
                    else
                    {
                        RenameMoveMail(node[2].ToString(), node[1].ToString());
                        node[2] = node[1];
                        node[0] = node[1];                        
                    }
                    break;
                case ("Rename"):
                    if (!fol.RenameFolder(node[0].ToString(), node[1].ToString()))
                    {
                        //HUYLX : Thay lại bằng hàm trong framework
                        PLMessageBox.ShowErrorMessage("Đổi tên thư mục không thành công");
                        node[1] = node[0];
                    }
                    else
                    {
                        RenameMoveMail(node[2].ToString(), node[1].ToString());
                        node[2] = node[1];
                        node[0] = node[1];
                    }
                    break;
                case ("Delete"):
                    if (!fol.DeleteFolder(node[0].ToString()))
                        //HUYLX : Thay lại bằng hàm trong framework
                        PLMessageBox.ShowErrorMessage("Xóa thư mục không thành công");
                    else
                    {
                        state = null;
                        DelNode(node); 
                    }
                    break;
            }
            state = null;
        }
        
        // Hiển thị thư 
        private bool showMessage()
        {
            try
            {
                mail = mess.GetMessage(treeList1.FocusedNode[2].ToString(), (int)gridView1.GetDataRow(gridView1.FocusedRowHandle)[0]);
                mess.MarkFlagged((int)gridView1.GetDataRow(gridView1.FocusedRowHandle)[0], treeList1.FocusedNode[2].ToString());
                lbForm.Text = "Người gửi: " + mail.From;
                lbSubject.Text = "Tiêu đề: " + mail.Subject;
                if (mail.HasHtmlBody())
                {
                    string stringHTML = mail.GetHtmlBody();

                    if (mail.NumRelatedItems > 0)//show image
                    {
                        string path = FrameworkParams.TEMP_FOLDER+ @"\MailImage";
                        
                        //string path = Application.UserAppDataPath + "\\MailImage";
                        if (!System.IO.Directory.Exists(path))
                        {
                            System.IO.Directory.CreateDirectory(path);
                        }
                        for (int i = 0; i < mail.NumRelatedItems; i++)
                        {
                            mail.SaveRelatedItem(i, path);
                            string replace = mail.GetRelatedContentID(i);
                            int pos = stringHTML.IndexOf(replace);
                            pos--;
                            while (stringHTML[pos].ToString() != "\"")
                            {
                                replace = stringHTML[pos].ToString() + replace;
                                pos--;
                            }
                            stringHTML = stringHTML.Replace(replace, path + "\\\\" + mail.GetRelatedFilename(i));
                        }
                    }                   
                    webHTML.DocumentText = stringHTML;
                   
                }
                else
                {
                    webHTML.DocumentText = mail.GetPlainTextBody();
                }

                if (mail.NumAttachments == 0)
                {
                    checkedComboBoxEdit1.Visible = false;
                    btDownLoad.Visible = false;
                    lbAttach.Visible = false;
                }
                else
                {
                    checkedComboBoxEdit1.Visible = true;
                    lbAttach.Visible = true;
                    checkedComboBoxEdit1.Properties.Items.Clear();
                    for (int i = 0; i < mail.NumAttachments; i++)
                        checkedComboBoxEdit1.Properties.Items.Add(mail.GetAttachmentFilename(i));
                    checkedComboBoxEdit1.ResetText();
                    checkedComboBoxEdit1.Text = "Chọn file";
                }
                return true;
            }
            catch
            {
                return false;
            }
           
        }

        // Update lại số message chưa đọc
        private void UpdateSumMsg()
        {
            try
            {
                DataView view = (DataView)gridView1.DataSource;
                int numRow = view.Table.Select("Readed = 'Unread'").Length;
                
                if (numRow > 0)
                {
                    string text = treeList1.FocusedNode[0].ToString() + " (" + numRow.ToString() + ")";
                    treeList1.FocusedNode.SetValue(treeList1.Columns[1].FieldName, text);
                }
                else
                    treeList1.FocusedNode.SetValue(treeList1.Columns[1].FieldName, treeList1.FocusedNode[0].ToString());
            }
            catch { }
        }
        private void UpdateSumMsgTreeList()
        {
            try
            {
                for (int i = 0; i < 3; i++)
                    for (int j = 0; j < treeList1.Nodes[i].Nodes.Count; j++)
                    {
                        TreeListNode treenode = treeList1.Nodes[i].Nodes[j];
                        int numRow = 0;
                        if (treenode[3] != null)
                        {
                            if (DSListFolderMessage.Tables[treenode[2].ToString()] != null)
                            {
                                DataView view = DSListFolderMessage.Tables[treenode[2].ToString()].DefaultView;
                                numRow = view.Table.Select("Readed = 'Unread'").Length;
                            }
                            else
                            {
                                numRow = (int)treenode[3];
                            }

                            if (numRow > 0)
                            {
                                string text = treenode[0].ToString() + " (" + numRow.ToString() + ")";
                                treenode.SetValue(treeList1.Columns[1].FieldName, text);
                            }
                            else
                                treenode.SetValue(treeList1.Columns[1].FieldName, treenode[0].ToString());
                        }

                    }



            }
            catch { }
        }
        // Lấy thư mục thực của hệ thống trên mail server 
        private Email getMessage(string folderName, int MsgID)
        {
            Email msg;
            msg = mess.GetMessage(folderName, MsgID);
            return msg;
        }
       
        // Đánh đấu thư đã được trả lời
        public void reply()
        {
            mess.MarkAnwsered((int)gridView1.GetDataRow(gridView1.FocusedRowHandle)[0], treeList1.FocusedNode[2].ToString());            
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            dr["Answered"] = "Reply";
        }

        // Reset Khung nhìn
        private void resetView()
        {
            gridControl1.DataSource = null;
            lbForm.Text = "Người gửi: ";
            lbSubject.Text = "Tiêu đề: ";
            webHTML.DocumentText = "Bạn chưa chọn thư nào";
            checkedComboBoxEdit1.Visible = false;
            btDownLoad.Visible = false;
            lbAttach.Visible = false;
            barBtDeleteMessage.Enabled = false;
            barBtForward.Enabled = false;
            barBtReply.Enabled = false;            
        }

        // Reset hiển thị khi load mail lỗi
        private void MessageError()
        {
            lbForm.Text = "Người gửi: ";
            lbSubject.Text = "Tiêu đề: ";
            webHTML.DocumentText = "Có lỗi, không mở được thư";
            checkedComboBoxEdit1.Visible = false;
            btDownLoad.Visible = false;
            lbAttach.Visible = false;          
        }

        //Các hàm hỗ trợ thêm, xóa, sửa thư mục cho frmAccount
        public void DeleteFolder(string FolderName)//Xóa folder  bên ngoài, chuyển nó thành folder cá nhân
        {
            for (int i = 0; i < treeList1.Nodes[1].Nodes.Count;i++ )
            {
                TreeListNode treenode = treeList1.Nodes[1].Nodes[i];
                if (treenode[2].ToString() == FolderName)
                {

                    AddNode(FolderName, 2, 6, (int)treenode[3]);
                    treeList1.DeleteNode(treenode); 
                    break;
                }
            }
            for (int i = 0; i < popupMenu1.ItemLinks.Count; i++)
            {
                if (popupMenu1.ItemLinks[i].Caption == FolderName)
                {
                    popupMenu1.ItemLinks.RemoveAt(i);
                    break;
                }
            }
        }
        public void AddFolder(string FolderName)
        {
            if (fol.NewFolder(FolderName))
            {
                AddNode(FolderName, 1, 1,0);
                AddMenuButton(FolderName);
            }       

        }
        public void RenameFolder(string NameOld, string NameNew)
        {
            if (fol.RenameFolder(NameOld,NameNew))
            {
                RenameMoveMail(NameOld, NameNew);
                for (int i = 0; i < treeList1.Nodes[1].Nodes.Count; i++)
                {
                    TreeListNode treenode = treeList1.Nodes[1].Nodes[i];
                    if (treenode[2].ToString() == NameOld)
                    {
                        treenode.SetValue(treeList1.Columns[0].FieldName, NameNew);
                        treenode.SetValue(treeList1.Columns[1].FieldName, NameNew);
                        treenode.SetValue(treeList1.Columns[2].FieldName, NameNew);

                        break;
                    }
                }
                for (int i = 0; i < popupMenu1.ItemLinks.Count; i++)
                {
                    if (popupMenu1.ItemLinks[i].Caption == NameOld)
                    {
                        popupMenu1.ItemLinks[i].Caption = NameNew;
                        break;
                    }
                }
                UpdateSumMsgTreeList();
            }
        }
        public bool FolderExist(string FolderName)
        {
            foreach( TreeListNode treenode in treeList1.Nodes[1].Nodes)
            {
                if (treenode[2].ToString() == FolderName)
                {                    
                    return true;
                }
            }
            foreach (TreeListNode treenode in treeList1.Nodes[2].Nodes)
            {
                if (treenode[2].ToString() == FolderName)
                {
                    return true;
                }
            }
            return false;
        }
        #endregion               
    }
}

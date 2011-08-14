using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ProtocolVN.Framework.Win;
using ProtocolVN.Framework.Core;
using System.Data.Common;
using ProtocolVN.DanhMuc;
using System.IO;
using DevExpress.XtraRichEdit.API.Native;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraRichEdit;
using System.Reflection;

namespace office
{
    public partial class frmForumCardView : XtraFormPL
    {
        private DataTable dtListFile;
        private long BaiVietGocID;
        private long DienDanID;
        private long ChuyenMucID;
        private long NguoitaoBVGocID;
        private string chuDe;
        public frmForumCardView(long ID)
        {
            InitializeComponent();
            this.BaiVietGocID = ID;
            InitControl();
            UpdateControl();

        }

        private void InitControl()
        {
            DMFWNhanVien.I.InitCot(ColNguoiCapNhat, "NGUOI_GUI");
            HelpGridColumn.CotDateEdit(ColNgayCapNhat, "NGAY_GUI", FrameworkParams.option.DateTimeFomat);
            ColNgayCapNhat.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            ColNoiDung.FieldName = "NOI_DUNG_TEXT";
            ColListFile.FieldName = "LIST_FILE";
            gridViewMaster.ShownEditor += new EventHandler(layoutView1_ShownEditor);
            gridViewMaster.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            repositoryItemButtonEdit1.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(repositoryItemButtonEdit1_ButtonClick);
        }

      
        private void UpdateControl()
        {
            string sqlFile = string.Format(@"SELECT obj.object_id,lt.id,lt.ten_file,lt.noi_dung
                        from OBJECT_TAP_TIN obj
                        inner JOIN LUU_TRU_TAP_TIN LT ON LT.ID=obj.TAP_TIN_ID
                        WHERE obj.type_id=2 and
                        obj.object_id in (select bv.id from bai_viet bv where bv.id={0} or bv.id_bai_viet_parent={0})", BaiVietGocID);

            DataSet dsFile = HelpDB.getDBService().LoadDataSet(sqlFile);
            dtListFile = dsFile.Tables[0];
            dtListFile.PrimaryKey = new DataColumn[]{dtListFile.Columns["OBJECT_ID"],
                dtListFile.Columns["ID"] };


            string sql = string.Format(@"SELECT B.*,'' LIST_FILE,'' NOI_DUNG_TEXT,NDD.NAME NHOM_DIEN_DAN_NAME, CM.NAME CHUYEN_MUC_NAME
                          FROM BAI_VIET B 
                        LEFT JOIN NHOM_DIEN_DAN NDD ON B.ID_NHOM_DIEN_DAN=NDD.ID
                        LEFT JOIN CHUYEN_MUC CM ON B.ID_CHUYEN_MUC=CM.ID
                          WHERE B.ID={0} OR B.ID_BAI_VIET_PARENT={0} ORDER BY NGAY_GUI ASC", BaiVietGocID);

            DataSet ds = HelpDB.getDBService().LoadDataSet(sql);
            DataRow RChuDe = null;
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                if (HelpNumber.ParseInt64(row["ID_BAI_VIET_PARENT"]) <= 0)
                    RChuDe = row;
                row["NOI_DUNG_TEXT"] = HelpByte.BytesToUTF8String((byte[])row["NOI_DUNG"]);
                DataRow[] rowFiles = dtListFile.Select(string.Format("OBJECT_ID={0}", row["ID"]));
                string[] titles = new string[rowFiles.Length];
                string[] links = new string[titles.Length];
                int j = 0;
                foreach (DataRow r in rowFiles)
                {
                    titles[j] = r["ten_file"].ToString();
                    links[j] = r["ID"].ToString();
                    j++;
                }
                row["LIST_FILE"] = GetRTFLink(titles, links);
            }
            gridControlMaster.DataSource = ds.Tables[0];
            if (RChuDe != null)
            {
                chuDe=RChuDe["CHU_DE"].ToString();
                gridViewMaster.ViewCaption = "Chủ đề: " +chuDe ;
                this.Text = RChuDe["NHOM_DIEN_DAN_NAME"] + "\\" + RChuDe["CHUYEN_MUC_NAME"];
                DienDanID = HelpNumber.ParseInt64(RChuDe["ID_NHOM_DIEN_DAN"]);
                ChuyenMucID = HelpNumber.ParseInt64(RChuDe["ID_CHUYEN_MUC"]);
                NguoitaoBVGocID = HelpNumber.ParseInt64(RChuDe["NGUOI_GUI"]);
            }
        }
        private void layoutView1_ShownEditor(object sender, EventArgs e)
        {
            if (gridViewMaster.FocusedColumn.Name == ColListFile.Name)
            {
                BaseEdit edt = gridViewMaster.ActiveEditor;
                if (edt != null)
                {
                    edt.Cursor = System.Windows.Forms.Cursors.Hand;
                    PropertyInfo info = edt.GetType().GetProperty("InnerControl",
                        System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
                    if (info != null)
                    {
                        object obj = info.GetValue(edt, null);
                        if (obj != null && obj is RichEditControl)
                        {
                            RichEditControl rc = obj as RichEditControl;
                            rc.Options.Hyperlinks.ModifierKeys = Keys.None;
                            rc.Options.Hyperlinks.ShowToolTip = false;
                            rc.HyperlinkClick += delegate(object senderr, HyperlinkClickEventArgs ee)
                            {
                                DataRow fRow = gridViewMaster.GetFocusedDataRow();
                                if (fRow == null) return;
                                DataRow row = dtListFile.Rows.Find(new object[] { fRow["ID"], HelpNumber.ParseInt64(ee.Hyperlink.NavigateUri) });
                                if (row == null) return;
                                frmSaveOpen frm = new frmSaveOpen((byte[])row["NOI_DUNG"], row["TEN_FILE"].ToString());
                                HelpProtocolForm.ShowModalDialog(this, frm);
                                ee.Handled = true;
                            };
                        }
                    }
                }
            }
        }
        private DevExpress.XtraEditors.Controls.EditorButton GetEditButton(RepositoryItemButtonEdit edit, string tag)
        {
            foreach(DevExpress.XtraEditors.Controls.EditorButton b in edit.Buttons)
            {
                if (b.Tag.ToString() == tag)
                    return b;
            }
            return new DevExpress.XtraEditors.Controls.EditorButton();
        }
        private void layoutView1_CustomRowCellEdit(object sender, DevExpress.XtraGrid.Views.Layout.Events.LayoutViewCustomRowCellEditEventArgs e)
        {
            if (e.Column.Name == ColButtons.Name && e.RepositoryItem is RepositoryItemButtonEdit)
            {
                DataRow row = gridViewMaster.GetDataRow(e.RowHandle);
                if (row == null)
                    return;
                RepositoryItemButtonEdit repo = e.RepositoryItem as RepositoryItemButtonEdit;
                DevExpress.XtraEditors.Controls.EditorButton btDelete= GetEditButton(repo, "DELETE");
                DevExpress.XtraEditors.Controls.EditorButton btUpdate= GetEditButton(repo, "UPDATE");

                if (HelpNumber.ParseInt64(row["ID_BAI_VIET_PARENT"]) <= 0)
                {
                    btDelete.Visible = false;
                    btUpdate.Visible = false;
                }
                else if (FrameworkParams.currentUser.username != "admin" &&
                    FrameworkParams.currentUser.employee_id != HelpNumber.ParseInt64(row["NGUOI_GUI"]))
                {
                    if (FrameworkParams.currentUser.employee_id == NguoitaoBVGocID)
                    {
                        btUpdate.Visible = false;
                    }
                    else
                    {
                        btDelete.Visible = false;
                        btUpdate.Visible = false;

                    }

                }
                else
                {
                    btDelete.Visible = true;
                    btUpdate.Visible = true;
                }
            }
        }
        void repositoryItemButtonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            //DataRow row = gridViewMaster.GetFocusedDataRow();
            //if (row == null) return;

            //if (e.Button.Tag.ToString() == "DELETE")
            //{

            //}
            //else if (e.Button.Tag.ToString() == "UPDATE")
            //{
            //    frmBaiVietEtx frm = new frmBaiVietEtx(HelpNumber.ParseInt64(row["ID"]),
            //        DienDanID, ChuyenMucID, false, false, chuDe);
            //    frm.PLChuyenMuc.Enabled = false;
            //    HelpProtocolForm.ShowModalDialog(this, frm);
            //}
        }




        private string GetRTFLink(string[] titles, string[] links)
        {
            string init = @"{\rtf1\deff0{\fonttbl{\f0 Times New Roman;}}{\colortbl\red0\green0\blue0 ;\red0\green0\blue255 ;}{\*\listoverridetable}{\stylesheet {\ql\cf0 Normal;}{\*\cs1\cf0 Default Paragraph Font;}{\*\cs2\sbasedon1\cf0 Line Number;}{\*\cs3\ul\cf1\ulc1 Hyperlink;}}\sectd\pard\plain\ql@%$#&\par}";
            string oneLink = @"{\field{\*\fldinst{\cf0 HYPERLINK `!*&?_}}{\fldrslt{\ul\cf1\ulc1\cs3 %$%&*@!#}}}";
            string space = @"{\cf0 ; }";
            string strLink = "";
            for (int i = 0; i < titles.Length; i++)
            {
                string p = "\"" + links[i] + "\"";
                strLink += oneLink.Replace("`!*&?_", p).Replace("%$%&*@!#", titles[i]);
                if (i < titles.Length - 1)
                    strLink += space;
            }
            return init.Replace("@%$#&", strLink);
        }

        private void btnReply_Click(object sender, EventArgs e)
        {
            //frmBaiVietEtx frm = new frmBaiVietEtx(BaiVietGocID,
            //      DienDanID, ChuyenMucID, true, false, chuDe);
            //HelpProtocolForm.ShowModalDialog(this, frm);
        }


    }
}
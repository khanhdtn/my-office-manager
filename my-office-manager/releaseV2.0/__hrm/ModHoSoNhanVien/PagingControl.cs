using System;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraGrid;
using ProtocolVN.Framework.Core;
using DevExpress.XtraGrid.Views.Grid;

namespace pl.hrm.form
{
    public class PagerInfo
    {
        public static string PAGE_INFO = "PAGE_INFO";

        public DataTable Data;
        public int NumPerPage;
        public int CurrentPage = -1;
        public int TotalPage = -1;
        private int startIndex;
        private int endIndex;

        public DataTable GetCurrentPage()
        {
            if (CurrentPage == 1)
            {
                startIndex = 0;
                endIndex = CurrentPage * NumPerPage;
            }
            else
            {
                startIndex = (CurrentPage - 1) * NumPerPage;
                endIndex = CurrentPage * NumPerPage;
            }
            DataTable dtTempt = Data.Clone();

            for (int i = startIndex; i < endIndex; i++)
            {
                if (i <= Data.Rows.Count - 1)
                {
                    dtTempt.ImportRow(Data.Rows[i]);
                }
            }
            return dtTempt;
        }
        public void NextPage()
        {
            if (CurrentPage < TotalPage)
            {
                CurrentPage++;
            }
        }
        public void PrevPage()
        {
            if (CurrentPage > 1)
            {
                CurrentPage--;
            }
        }
        public void FirstPage()
        {
            CurrentPage = 1;
        }
        public void LastPage()
        {
            CurrentPage = TotalPage;
        }
    }

    public partial class PagerGrid : DevExpress.XtraEditors.XtraUserControl
    {
        // New update for get detail of Ung Vien
        public delegate DataTable GetDetail(long MasterID);
        public GetDetail DetailOfFirtsRows;
        //--------------------------------------
        private GridControl gridControl;
        private GridView gridView;

        //NumPerPage -- So dong tren 1 trang
        public PagerGrid(GridControl gridCtrl,PLGridView gridViewPL, int NumPerPage)
        {
            InitializeComponent();
            this.gridControl = gridCtrl;
            this.gridView = gridViewPL;
            this.Name = gridCtrl.Name + "pager";
            if (this.gridControl.Controls.ContainsKey(this.Name))
            {
                this.gridControl.Controls.RemoveByKey(this.Name);
            }
            this.gridControl.Controls.Add(this);
            this.BringToFront();
            this.Dock = DockStyle.Bottom;
            if (!this.DesignMode)
            {
                InitPager(NumPerPage);
            }
        }

        private void ShowCurrentPage(PagerInfo page)
        {
            DataTable tempt = page.GetCurrentPage();
            gridControl.DataSource = tempt;
            //New update for get detail of Ung Vien
            if (DetailOfFirtsRows != null)
                DetailOfFirtsRows(HelpNumber.ParseInt64(tempt.Rows[0]["ID"]));
            //--------------------
            //gridView.FocusedRowHandle = 0;
            textEdit1.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            textEdit1.Text = page.CurrentPage + "/" + page.TotalPage ;
            textEdit1.Properties.AllowFocused = false;
            textEdit1.BackColor = Color.White;
            textEdit1.Update();
            if (page.CurrentPage == page.TotalPage)
            {
                btnLast.Enabled = false;
                btnNextPage.Enabled = false;
            }
            else
            {
                btnLast.Enabled = true;
                btnNextPage.Enabled = true;
            }

            if (page.CurrentPage == 1)
            {
                btnFirst.Enabled = false;
                btnPrevPage.Enabled = false;
            }
            else
            {
                btnFirst.Enabled = true;
                btnPrevPage.Enabled = true;
            }
        }
 
        //NumPerPage -- so dong tren 1 trang
        public void InitPager(int NumPerPage)
        {
            DataTable dt = (DataTable)gridControl.DataSource;
            PagerInfo page = new PagerInfo();
            page.Data = dt;
            page.NumPerPage = NumPerPage; //Data la DataTable

            int totalRow = dt.Rows.Count;
            if (totalRow % NumPerPage == 0)
            {
                page.TotalPage = totalRow / NumPerPage;
            }
            else
            {
                page.TotalPage = totalRow / NumPerPage + 1;
            }
            if (dt.Rows.Count == 0)
            {
                this.Visible = false;
                return;
            }
            else
            {
                this.Visible = true;
                page.CurrentPage = 1;
            }
            lblTongSoDong.Text = totalRow.ToString();
            object temp = this.gridControl.Tag;
            TagPropertyMan.InsertOrUpdate(ref temp, PagerInfo.PAGE_INFO, page);
            this.gridControl.Tag = temp;

            ShowCurrentPage(page);
        }
       

        public int Get_Current_page()
        {   
            PagerInfo page = (PagerInfo)TagPropertyMan.Get(this.gridControl.Tag, PagerInfo.PAGE_INFO);
            return page.CurrentPage;
        }
        public void Set_Current_page(int Current_page)
        {
            PagerInfo page = (PagerInfo)TagPropertyMan.Get(this.gridControl.Tag, PagerInfo.PAGE_INFO);
            page.CurrentPage = Current_page;
            ShowCurrentPage(page);
        }
        private void btnPrevPage_Click(object sender, EventArgs e)
        {
            PagerInfo page = (PagerInfo)TagPropertyMan.Get(this.gridControl.Tag, PagerInfo.PAGE_INFO);
            page.PrevPage();
            ShowCurrentPage(page);
        }

        private void btnNextPage_Click(object sender, EventArgs e)
        {
            PagerInfo page = (PagerInfo)TagPropertyMan.Get(this.gridControl.Tag, PagerInfo.PAGE_INFO);
            page.NextPage();
            ShowCurrentPage(page);
            
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            PagerInfo page = (PagerInfo)TagPropertyMan.Get(this.gridControl.Tag, PagerInfo.PAGE_INFO);
            page.FirstPage();
            ShowCurrentPage(page);
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            PagerInfo page = (PagerInfo)TagPropertyMan.Get(this.gridControl.Tag, PagerInfo.PAGE_INFO);
            page.LastPage();
            ShowCurrentPage(page);
        }

    }
}

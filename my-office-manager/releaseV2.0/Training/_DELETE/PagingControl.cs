using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;

namespace pl.office
{
    public partial class PagingControl : DevExpress.XtraEditors.XtraUserControl
    {

        #region Variables
        private int numberRow; //So dong tren mot trang
        private GridControl gridControl; //grid control gan vao
        private static int index = 1; //vi tri index cua trang khi duyet
        private static int page = 0; 
        private DataTable dataTable;
        #endregion

        #region Contructor
        public PagingControl()
        {
            InitializeComponent();

        }
        #endregion
     
        #region Property

        public GridControl GridControl
        {
            get
            {
                return gridControl;
            }
            set
            {
                if (value == null)
                {
                    MessageBox.Show("Thuoc tinh gridcontrol chua duoc set");
                }
                else
                {
                    gridControl = value;
                }
            }
        }

        public int NumberRowInPage
        {
            get
            {
                return numberRow;
            }
            set
            {
                if (value == 0)
                {
                    MessageBox.Show("Number row <> 0");
                }
                else
                {
                    numberRow = value;
                }
            }
        }

        public DataTable DataSourceTable
        {
            get
            {
                return dataTable;
            }
            set
            {
                dataTable = value;
            }
        }

        public int NumberPage
        {
            get
            {
                return page;
            }
        }

        public int IndexPage
        {
            get
            {
                return index;
            }
        }

        #endregion

        #region MethodToUser
        //Phuong thuc cai dat bat buot
        public void Paging()
        {
            GetDataSourceTable();
            int totalRow = dataTable.Rows.Count;
            if (totalRow % numberRow == 0)
            {
                page = totalRow / numberRow;
            }
            else
            {
                page = totalRow / numberRow + 1 ;
            }
            DataTable tempt = SetPaging(index - 1, numberRow, dataTable);
            gridControl.DataSource = tempt;
            EmbededPagingToGrid();
            DisplayPageTextBox();
        }
        #endregion

        #region Internal Method

        //lay Data Table tu datasource cua grid control
        private void GetDataSourceTable()
        {
            DataTable dt = (DataTable)gridControl.DataSource;
            this.dataTable = dt;
        }
        //Set Page hien thi theo gioi han index cua datarow tu startIndex den endIndex
        private DataTable SetPaging(int startIndex, int endIndex, DataTable dt)
        {

            DataTable dtTempt = dataTable.Clone();

            for (int i = startIndex ; i < endIndex; i++)
            {
                if (i <= dataTable.Rows.Count - 1)
                {
                    dtTempt.ImportRow(dataTable.Rows[i]);
                }
            }
            return dtTempt;
        }

        private void NextPage()
        {
            if (index < page)
            {
                index++;
                DataTable tempt = SetPaging((index - 1) * numberRow, index * numberRow , dataTable);
                gridControl.DataSource = tempt;
            }
        }

        private void PreviousPage()
        {
            if (index > 1)
            {
                index--;
                DataTable tempt = SetPaging((index -1) * numberRow, index * numberRow, dataTable);
                gridControl.DataSource = tempt;
            }
        }

        private void FirstPage()
        {
            index = 1;
            DataTable tempt = SetPaging(index - 1, numberRow, dataTable);
            gridControl.DataSource = tempt;
        }

        private void LastPage()
        {
            index = page - 1;
            DataTable tempt = SetPaging(numberRow * index, dataTable.Rows.Count, dataTable);
            gridControl.DataSource = tempt;
        }
        //gan control vao grid
        private void EmbededPagingToGrid()
        {
            gridControl.Controls.Add(this);
            this.Dock = DockStyle.Bottom;
            this.BringToFront();

        }
        //hien thi thong tin so trang vao textbox
        private void DisplayPageTextBox()
        {
            textEdit1.Text = "  " + index.ToString() + " - " + page.ToString() + " pages" + "     ";
        }

        #endregion

        #region Event Button

        private void btnPrevPage_Click(object sender, EventArgs e)
        {
            PreviousPage();
            DisplayPageTextBox();
        }

        private void btnNextPage_Click(object sender, EventArgs e)
        {
            NextPage();
            DisplayPageTextBox();
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            FirstPage();
            DisplayPageTextBox();
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            LastPage();
            DisplayPageTextBox();
        }

        #endregion
    }
}

using System;
using System.Data;
using ProtocolVN.Framework.Core;
using ProtocolVN.Framework.Win;
using System.Collections.Generic;
using DevExpress.XtraBars;
using ProtocolVN.DanhMuc;

namespace office
{
    public partial class frmSendClientQL : PhieuQuanLy10Change//,IDuyetSupport
    //public partial class frmSendClientQL : XtraFormPL
    {
        //#region Các biến của form Quan Ly Tuyệt đối không thay đổi
        //protected DevExpress.XtraBars.BarManager barManager1;
        //protected DevExpress.XtraBars.Bar MainBar;
        //protected DevExpress.XtraBars.BarButtonItem barButtonItemAdd;
        //protected DevExpress.XtraBars.BarButtonItem barButtonItemDelete;
        //protected DevExpress.XtraBars.BarButtonItem barButtonItemUpdate;
        //protected DevExpress.XtraBars.BarButtonItem barButtonItemPrint;
        //protected DevExpress.XtraBars.BarButtonItem barButtonItemView;
        //protected DevExpress.XtraBars.BarDockControl barDockControlTop;
        //protected DevExpress.XtraBars.BarDockControl barDockControlBottom;
        //protected DevExpress.XtraBars.BarDockControl barDockControlLeft;
        //protected DevExpress.XtraBars.BarDockControl barDockControlRight;
        //protected DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        //protected DevExpress.XtraGrid.GridControl gridControlMaster;
        //protected DevExpress.XtraGrid.Views.Grid.PLGridView gridViewMaster;
        //protected DevExpress.XtraGrid.GridControl gridControlDetail;
        //protected DevExpress.XtraGrid.Views.Grid.PLGridView gridViewDetail;
        //protected DevExpress.XtraTab.XtraTabControl xtraTabControlDetail;
        //protected DevExpress.XtraTab.XtraTabPage xtraTabPageDetail;
        //protected DevExpress.XtraBars.PopupControlContainer popupControlContainerFilter;
        //protected DevExpress.XtraBars.BarStaticItem barStaticItem1;
        //protected DevExpress.XtraBars.BarButtonItem barButtonItem1;
        //protected DevExpress.XtraBars.BarButtonItem barButtonItem2;
        //protected DevExpress.XtraBars.BarButtonItem barButtonItemCommit;
        //protected DevExpress.XtraBars.BarButtonItem barButtonItemNoCommit;
        //protected DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        //protected DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        //protected DevExpress.XtraBars.BarButtonItem barButtonItemTaoPhieuMuaHang;
        //private System.ComponentModel.IContainer components;
        //private DevExpress.XtraBars.BarSubItem barSubItem1;
        //private DevExpress.XtraBars.BarButtonItem barButtonItemXem;
        //protected DevExpress.XtraBars.BarButtonItem barButtonItemClose;
        //private DevExpress.XtraBars.PopupMenu popupMenuFilter;
        //protected DevExpress.XtraBars.BarCheckItem barCheckItemFilter;
        //private DevExpress.XtraBars.BarButtonItem barButtonItemSearch;
        //private DevExpress.XtraBars.BarButtonItem barButtonItem3;
        //private DevExpress.XtraBars.PopupMenu popupMenu1;
        //private DevExpress.XtraBars.BarButtonItem barButtonItem4;
        //#endregion

        public static string MenuItem(string ParentID, bool IsSep)
        {
            return MenuBuilder.CreateItem(typeof(frmSendClient).FullName,
                "Gửi mail nội bộ",
                ParentID, true,
                typeof(frmSendClient).FullName,
                false, IsSep, "mnbmessage.gif", true, "", "");
        }
        private PhieuQuanLy10Fix that;
        public frmSendClientQL()
        {
            InitializeComponent();
            base.IDField = "ID";
            base.DisplayField = "NAME";
            that = new PhieuQuanLy10Fix(this);
            PLGUIUtil.InitBtnNghiepVu(this);
        } 
      
        public override void InitColumnMaster()
        {
            HelpGridColumn.CotTextLeft(HelpGridColumn.ThemCot(this.gridViewMaster,"ID", -1, 0),base.IDField);
            HelpGridColumn.CotTextLeft(HelpGridColumn.ThemCot(this.gridViewMaster, "Tên nhân viên", 0, 100),"NAME");
            HelpGridColumn.CotDateEdit(HelpGridColumn.ThemCot(this.gridViewMaster, "Ngày sinh", 1, 100), "NGAY_SINH", "");
        }

        public override void InitColumDetail()
        {
            
        } 
      
        public override void PLLoadFilterPart()
        {

        }

        public override QueryBuilder PLBuildQueryFilter()
        {
            QueryBuilder query = new QueryBuilder(@"SELECT * FROM DM_NHAN_VIEN WHERE 1=1");
            query.addBoolean("VISIBLE_BIT", true);
            return query;
        }

        //public override DataTable PLLoadDataDetailPart(long MasterID)
        //{
        //    return null;
        //}

        public override void ShowViewForm(long id)
        {
            
        }

        public override void ShowUpdateForm(long id)
        { 
        }

        public override long[] ShowAddForm()
        {
            return null;
        }

        public override bool XoaAction(long id)
        {
            return false;
        }

        public override string UpdateRow()
        {
            return
                @"SELECT * FROM DM_NHAN_VIEN WHERE 1=1";
        }
        public override _Print InAction(long[] ids)
        {
            return null;
        }

        public override _MenuItem GetBusinessMenuList()
        {
            _MenuItem menu = new _MenuItem(
              new string[] { "Gửi mail" },
              new string[] { "FGuiMail" },
              "ID",
              new DelegationLib.CallFunction_MulIn_NoOut[]{    
                    FGuiMail,                    
               },null);
            return menu;   
        }
        
        public override _MenuItem GetMenuAppendGridList()
        {
            return null;
        }

        public override void HookFocusRow()
        {

        }

        public void FGuiMail(List<object> ids)
        {
            
        }

        #region IDuyetSupport Members
        public bool DuyetAction(long ID, long NguoiDuyetID, DateTime NgayDuyet)
        {
            return true;
        }
        public bool KhongDuyetAction(long ID, long NguoiDuyetID, DateTime NgayDuyet)
        {
            return true;
        }
        #endregion
    }
}
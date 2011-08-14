using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ProtocolVN.Framework.Win;
using office;
using DevExpress.XtraNavBar;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Docking;
using DevExpress.XtraTreeList.Nodes;
namespace pl.office
{
    /// <summary>
    /// Dùng để xử lý định dạng
    /// </summary>
    public class AppFormat : IFormat
    {
        public List<Control> GetFormatControls(XtraForm formObj)
        {
            List<Control> controls = new List<Control>();
            if (formObj is frmDieuChinhLuong)
            {
                frmDieuChinhLuong frm = (frmDieuChinhLuong)formObj;
                controls.Add(frm.clLuongBTG);
                controls.Add(frm.clLuongCT);
                controls.Add(frm.clLuongTC);
                controls.Add(frm.clLuongTV);
                controls.Add(frm.clPhanTram);
            }
            else if (formObj is frmTreeUserManExt)
            {
                try
                {
                    frmTreeUserManExt frm = formObj as frmTreeUserManExt;
                    SplitContainerControl splitContainerControl2 = frm.Controls["splitContainerControl2"] as SplitContainerControl;
                    DevExpress.XtraTab.XtraTabControl xtap = splitContainerControl2.Panel2.Controls["xtraTabControlRight"] as DevExpress.XtraTab.XtraTabControl;
                    DevExpress.XtraTab.XtraTabPage p = xtap.TabPages[0];
                    DevExpress.XtraTreeList.TreeList tree = p.Controls["treeListFeature"] as DevExpress.XtraTreeList.TreeList;
                    //tree.AfterExpand += delegate(object sender, DevExpress.XtraTreeList.NodeEventArgs e)
                    //{
                    //    if (e.Node.Level == 0 && e.Node.Tag == null)
                    //    {
                    //        System.Data.DataTable dt = tree.DataSource as System.Data.DataTable;
                    //        dt.DefaultView.Sort = "DESCRIPTION ASC";
                    //        e.Node.Tag = "SORTED";
                    //        //tree.MoveFirst();
                    //    }
                        
                    //};

                }
                catch
                {

                }


                //splitContainerControl2.Panel1

            }
            ///CHAUTV: Phần này chỉnh sửa thay cho fw khi chưa đưa vào fw được

            //Khi để ở đây mỗi lần mở form nó sẽ chạy lên -->Nặng chương trình-->Nhanh chóng đưa vào fw để tránh tình trạng này
            //Hoặc đưa ra một phương thức để có thể cài đặt chạy 1 lần
            //PLFormat.UpdatePermission();

            return controls;
        }

      

       


       

        /// <summary>
        /// Update phân quyền trong FW.
        /// Lý do: Khi phân quyền 'Truy cập' & 'Chỉnh sửa' trong frm quản lý thì nhấn nút 'Sửa' không mở được form
        /// và khi chỉ cho quyền 'Sửa' thì Item menu 'Tạo mới' trên Ribbon vẫn hiển thị lên
        /// </summary>
        public static void UpdatePermission() {
            //Dictionary<string, string> featureMap = new PLPermission().getFormFeatureMap();
            //foreach (KeyValuePair<string, string> ft in featureMap)
            //{
            //    string ftName = ft.Value;
            //    if (ftName == "" || ftName.Contains(";") || ftName[0].ToString() != "O") continue;
            //    Feature ftForm = Permission.loadFeature(0, ftName, FrameworkParams.currentUser.username);
            //    if (ftForm == null) continue;
            //    DevExpress.XtraBars.BarItem item = ((frmRibbonMain)FrameworkParams.MainForm).RibbonCtrl.Items[ft.Key];
            //    if (item != null && ftForm.isInsert == false)
            //        item.Enabled = false;
            //}
        }
    }
}

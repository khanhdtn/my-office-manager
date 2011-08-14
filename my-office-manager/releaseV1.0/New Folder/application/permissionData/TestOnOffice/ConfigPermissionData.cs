using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PermissionOfResource.Running;
using PermissionOfResource;
using ProtocolVN.Framework.Win;
using System.Windows.Forms;

namespace office
{
    public class AppPermissionData : IPermissionData
    {
        public const long TAI_LIEU = 1;
        public const long DANH_BA_DC = 2;
        public const long TIN_TUC = 3;
        public const long DIEN_DAN = 4;      
        public const long PICTURE = 5;
        public const long WEBSITE = 6;
        #region IPermissionResource Members

        private DataPermission[] resourceList;
        public AppPermissionData()
        {          
            resourceList = new DataPermission[]
            {
               TinTucPermission.I,           
               DienDanPermission.I,
               TaiLieuPermission.I,
               DanhBaDCPermission.I,
               WebsitesPermission.I,
               PicturesPermission.I
            };
            #region đưa item phân quyền vào danh mục
            //Đoạn này cần chỉnh sửa lại và tách ra để sau hàm này nếu đưa vào framwork

            frmRibbonMain frm = ProtocolVN.Framework.Win.FrameworkParams.MainForm as frmRibbonMain;
            frm.MdiChildActivate += delegate(object sender, EventArgs e)
            {
                if (((DevExpress.XtraBars.Ribbon.RibbonForm)sender).ActiveMdiChild is ProtocolVN.Framework.Win.frmCategory)
                {
                    ProtocolVN.Framework.Win.frmCategory frmCate =
                        ((DevExpress.XtraBars.Ribbon.RibbonForm)sender).ActiveMdiChild as frmCategory;
                    Panel p = frmCate.Controls["panel1"] as Panel;
                    if (p == null) return;
                    if (p.Tag != null) return;
                    p.Tag = "RUNNING";
                    if (p.Controls.Count > 0)
                    {
                        HelpPermissionData.CreateItemOnDM(p.Controls[0]);
                    }
                    p.ControlAdded += delegate(object senderr, ControlEventArgs ee)
                    {
                        HelpPermissionData.CreateItemOnDM(ee.Control);
                    };

                }

            };
            #endregion

        }



        public DataPermission[] getObjectResources()
        {
            return this.resourceList;
        }
        #endregion
    }
    public class TaiLieuPermission : DataPermission
    {
        public static TaiLieuPermission I = new TaiLieuPermission();
        public TaiLieuPermission()
            : base(AppPermissionData.TAI_LIEU, "DM_TAI_LIEU", "DM_LOAI_TAI_LIEU",
            "Tài liệu", "Loại tài liệu", "LOAI_TAI_LIEU_ID", "PARENT_ID")
        {


        }
    }
    public class DanhBaDCPermission : DataPermission
    {
        public static DanhBaDCPermission I = new DanhBaDCPermission();
        public DanhBaDCPermission()
            : base(AppPermissionData.DANH_BA_DC, "", "DM_NHOM_DANH_BA",
            "", "Nhóm danh bạ", "", "")
        {

        }
    }
    public class TinTucPermission : DataPermission
    {
        public static TinTucPermission I = new TinTucPermission();
        public TinTucPermission()
            : base(AppPermissionData.TIN_TUC, "", "DM_NHOM_TIN_TUC",
            "", "Nhóm tin tức", "", "")
        {

        }
    }
    public class DienDanPermission : DataPermission
    {
        public static DienDanPermission I = new DienDanPermission();
        public DienDanPermission()
            : base(AppPermissionData.DIEN_DAN, "CHUYEN_MUC", "NHOM_DIEN_DAN",
            "Chuyên mục", "Nhóm diễn đàn", "ID_NHOM_DIEN_DAN", "ID_CHA",true)
        {

        }
    }    
    public class PicturesPermission : DataPermission
    {
        public static PicturesPermission I = new PicturesPermission();
        public PicturesPermission()
            : base(AppPermissionData.PICTURE, "", "DM_TM_HINH_ANH",
            "", "Thư mục hình ảnh", "", "ID_CHA")
        {

        }
    }
    public class WebsitesPermission : DataPermission
    {
        public static WebsitesPermission I = new WebsitesPermission();
        public WebsitesPermission()
            : base(AppPermissionData.WEBSITE, "", "DM_WEBSITE",
            "", "Phân loại website", "", "ID_CHA")
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace ProtocolVN.Framework.Win
{
    /// <summary>
    /// Mục đích của lớp là chứa đựng các hình cho toàn bộ ứng dụng.
    /// Giúp cho việc sử dụng các hình sưu tập được nhanh
    /// </summary>
    public partial class PLOImageCollectionMan : XtraForm, IEMBImageStore
    {
        public PLOImageCollectionMan()
        {
            InitializeComponent();
        }


        #region IEMBImageStore Members

        public Image GetImage1616(string ImageName)
        {
            return this.images1616.Images[ImageName];
        }

        public Image GetImage4848(string ImageName)
        {
            return this.images4848.Images[ImageName];
        }

        public Image GetImage2020(string ImageName)
        {
            return this.images2020.Images[ImageName];
        }

        #endregion

        #region IEMBImageStore Members


        public Image GetImage3232(string ImageName)
        {
            return this.images3232.Images[ImageName];
        }

        #endregion
    }
}
using System.Collections.Generic;
using ProtocolVN.Framework.Core;
using Test;

namespace office
{
    public class PLPermissionRes : IPermissionRes
    {

        #region IPermissionRes Members

        public List<TaiNguyen> getObjectResources()
        {
            List<TaiNguyen> tainguyenLst = new List<TaiNguyen>();

            tainguyenLst.Add(LoaiTaiLieu_TaiLieu.I);
            return tainguyenLst;
        }

        #endregion
    }
}

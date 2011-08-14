using System;
using System.Collections.Generic;
using System.Text;
using ProtocolVN.Framework.Win;
using DevExpress.XtraVerticalGrid.Rows;
using ProtocolVN.Framework.Core;

namespace pl.office
{
    /// <summary>
    /// Lớp lấy các tham số từ cấu hình 'Tham số nghiệp vụ'
    /// </summary>
    public class AppGetSysParam {
        #region Nhóm tham số chấm công
        public static TimeSpan GetGIO_BAT_DAU_SANG
        {
            get
            {
                return ((DateTime)frmAppParamsHelp.GetThamSo("GIO_BAT_DAU_SANG")).TimeOfDay;
            }
        }
        public static TimeSpan GetGIO_KET_THUC_SANG
        {
            get
            {
                return ((DateTime)frmAppParamsHelp.GetThamSo("GIO_KET_THUC_SANG")).TimeOfDay;
            }
        }
        public static TimeSpan GetGIO_BAT_DAU_CHIEU
        {
            get
            {
                return ((DateTime)frmAppParamsHelp.GetThamSo("GIO_BAT_DAU_CHIEU")).TimeOfDay;
            }
        }
        public static TimeSpan GetGIO_KET_THUC_CHIEU
        {
            get
            {
                return ((DateTime)frmAppParamsHelp.GetThamSo("GIO_KET_THUC_CHIEU")).TimeOfDay;
            }
        }
        public static Int32 GetHE_SO_TRU_LUONG
        {
            get
            {
                return HelpNumber.ParseInt32(frmAppParamsHelp.GetThamSo("HE_SO_TRU_LUONG"));
            }
        }
        public static Int32 GetTHOI_GIAN_CHO_PHEP_TRE
        {
            get
            {
                return HelpNumber.ParseInt32(frmAppParamsHelp.GetThamSo("THOI_GIAN_CHO_PHEP_TRE"));
            }
        }
        public static Int32 GetSO_PHUT_LAP_LAI_THONG_BAO
        {
            get
            {
                return HelpNumber.ParseInt32(frmAppParamsHelp.GetThamSo("SO_PHUT_LAP_LAI_THONG_BAO"));
            }
        }
        public static bool GetCHO_PHEP_THONG_BAO
        {
            get
            {
                object obj = frmAppParamsHelp.GetThamSo("CHO_PHEP_THONG_BAO");
                if (obj == null) return false;
                return obj.ToString() == "Y";
            }
        }
        #endregion
    }
    #region Cấu hình tham số kiểu củ,trước khi áp dụng kiểu của warehouse
    //public class AppMethodExec
    //{
    //    #region Cấu hình màn hình tham số hệ thống
    //    public void ShowAppParamForm()
    //    {
    //        /// <summary>
    //        /// DataType
    //        /// 1: Text
    //        /// 2: Number
    //        /// 3: Date
    //        /// 4: Bool
    //        /// </summary>
    //        frmAppParams frm = new frmAppParams(CreateVGrid_Basic, GetRuleVGrid_Basic);
    //        HelpProtocolForm.ShowModalDialog(FrameworkParams.MainForm, frm, false);
    //    }
    //    private static EditorRow[] CreateVGrid_Basic()
    //    {
    //        EditorRow[] Rows = HelpVerticalGrid.CreateEditorRow(
    //                  new string[]{ 
    //                            "GIO_BAT_DAU_SANG",
    //                            "GIO_KET_THUC_SANG",
    //                            "GIO_BAT_DAU_CHIEU",
    //                            "GIO_KET_THUC_CHIEU",
    //                            "THOI_GIAN_CHO_PHEP_TRE",
    //                            "HE_SO_TRU_LUONG"
    //                        },
    //                  new bool[]  {  
    //                            true,true,true,true,true,true
    //                        },
    //                  new int[]   {  
    //                            20,20,20,20,20,20
    //                        });

    //        HelpVerticalGrid.DongShortTimeEdit(Rows[0], "GIO_BAT_DAU_SANG");
    //        HelpVerticalGrid.DongShortTimeEdit(Rows[1], "GIO_KET_THUC_SANG");
    //        HelpVerticalGrid.DongShortTimeEdit(Rows[2], "GIO_BAT_DAU_CHIEU");
    //        HelpVerticalGrid.DongShortTimeEdit(Rows[3], "GIO_KET_THUC_CHIEU");
    //        HelpVerticalGrid.DongCalcEdit(Rows[4], "THOI_GIAN_CHO_PHEP_TRE", 0);
    //        HelpVerticalGrid.DongCalcEdit(Rows[5], "HE_SO_TRU_LUONG", 0);
    //        return Rows;
    //    }

    //    private static FieldNameCheck[] GetRuleVGrid_Basic(object param)
    //    {
    //        return new FieldNameCheck[] { 
    //                new FieldNameCheck("GIO_BAT_DAU_SANG",
    //                    new CheckType[]{ CheckType.Required},
    //                    new string[]{ ErrorMsgLib.errorRequired("Giờ bắt đầu buổi sáng")}, 
    //                    new object[]{ null }),
    //                new FieldNameCheck("GIO_KET_THUC_SANG",
    //                    new CheckType[]{ CheckType.Required},
    //                    new string[]{ ErrorMsgLib.errorRequired("Giờ kết thúc buổi sáng")}, 
    //                    new object[]{ null }),
    //                new FieldNameCheck("GIO_BAT_DAU_CHIEU",
    //                    new CheckType[]{ CheckType.Required},
    //                    new string[]{ ErrorMsgLib.errorRequired("Giờ bắt đầu buổi chiều")}, 
    //                    new object[]{ null }),
    //                new FieldNameCheck("GIO_KET_THUC_CHIEU",
    //                    new CheckType[]{ CheckType.Required},
    //                    new string[]{ ErrorMsgLib.errorRequired("Giờ kết thúc buổi chiều")}, 
    //                    new object[]{ null }),
    //                new FieldNameCheck("HE_SO_TRU_LUONG",
    //                    new CheckType[]{ CheckType.Required},
    //                    new string[]{ ErrorMsgLib.errorRequired("Hệ số trừ lương")}, 
    //                    new object[]{ null }),
    //                new FieldNameCheck("THOI_GIAN_CHO_PHEP_TRE",
    //                    new CheckType[]{ CheckType.Required},
    //                    new string[]{ ErrorMsgLib.errorRequired("Thời gian cho phép đi trễ")}, 
    //                    new object[]{ null })
    //        };
    //    }

    //    #endregion
    //}
    #endregion  
    public class AppMethodExec
    {
        #region Cấu hình số phiếu
        public void ShowCauHinhNghiepVu()
        {
            frmCauHinhNghiepVu frm = new frmCauHinhNghiepVu();
            frm._initCauHinhMauPhieu(cauHinhSoPhieu);
            frm._initThamSoNghiepVu(CreateVGrid_Basic, GetRuleVGrid_Basic);

            HelpProtocolForm.ShowModalDialog(FrameworkParams.MainForm, frm, false);
        }
        private static Dictionary<int, string> cauHinhSoPhieu()
        {
            //Khai báo đúng dạng bên dưới
            Dictionary<int, string> soPhieuList = new Dictionary<int, string>();           
            soPhieuList.Add(1, "MA_PTU;tạm ứng");
            soPhieuList.Add(2, "MA_PTH;thu");
            soPhieuList.Add(3, "MA_PCH;chi");
            soPhieuList.Add(4, "MA_PUV;hồ sơ ứng viên");           

            return soPhieuList;
        }
        private static EditorRow[] CreateVGrid_Basic()
        {
            EditorRow[] Rows = HelpVerticalGrid.CreateEditorRow(
                      new string[]{ 
                                "GIO_BAT_DAU_SANG",
                                "GIO_KET_THUC_SANG",
                                "GIO_BAT_DAU_CHIEU",
                                "GIO_KET_THUC_CHIEU",
                                "THOI_GIAN_CHO_PHEP_TRE",
                                "HE_SO_TRU_LUONG",
                                "CHO_PHEP_THONG_BAO",
                                "SO_PHUT_LAP_LAI_THONG_BAO"
                            },
                      new bool[]  {  
                                true,true,true,true,true,true,true,true
                            },
                      new int[]   {  
                                20,20,20,20,20,20,20,20
                            });

            HelpVerticalGrid.DongShortTimeEdit(Rows[0], "GIO_BAT_DAU_SANG");
            HelpVerticalGrid.DongShortTimeEdit(Rows[1], "GIO_KET_THUC_SANG");
            HelpVerticalGrid.DongShortTimeEdit(Rows[2], "GIO_BAT_DAU_CHIEU");
            HelpVerticalGrid.DongShortTimeEdit(Rows[3], "GIO_KET_THUC_CHIEU");
            HelpVerticalGrid.DongCalcEdit(Rows[4], "THOI_GIAN_CHO_PHEP_TRE", 0);
            HelpVerticalGrid.DongCalcEdit(Rows[5], "HE_SO_TRU_LUONG", 0);
            HelpVerticalGrid.DongCheckEdit(Rows[6], "CHO_PHEP_THONG_BAO");
            HelpVerticalGrid.DongCalcEdit(Rows[7], "SO_PHUT_LAP_LAI_THONG_BAO", 0);

            return Rows;
        }

        private static FieldNameCheck[] GetRuleVGrid_Basic(object param)
        {
            return new FieldNameCheck[] { 
                    new FieldNameCheck("GIO_BAT_DAU_SANG",
                        new CheckType[]{ CheckType.Required},
                        new string[]{ ErrorMsgLib.errorRequired("Giờ bắt đầu buổi sáng")}, 
                        new object[]{ null }),
                    new FieldNameCheck("GIO_KET_THUC_SANG",
                        new CheckType[]{ CheckType.Required},
                        new string[]{ ErrorMsgLib.errorRequired("Giờ kết thúc buổi sáng")}, 
                        new object[]{ null }),
                    new FieldNameCheck("GIO_BAT_DAU_CHIEU",
                        new CheckType[]{ CheckType.Required},
                        new string[]{ ErrorMsgLib.errorRequired("Giờ bắt đầu buổi chiều")}, 
                        new object[]{ null }),
                    new FieldNameCheck("GIO_KET_THUC_CHIEU",
                        new CheckType[]{ CheckType.Required},
                        new string[]{ ErrorMsgLib.errorRequired("Giờ kết thúc buổi chiều")}, 
                        new object[]{ null }),
                    new FieldNameCheck("HE_SO_TRU_LUONG",
                        new CheckType[]{ CheckType.Required},
                        new string[]{ ErrorMsgLib.errorRequired("Hệ số trừ lương")}, 
                        new object[]{ null }),
                    new FieldNameCheck("THOI_GIAN_CHO_PHEP_TRE",
                        new CheckType[]{ CheckType.Required},
                        new string[]{ ErrorMsgLib.errorRequired("Thời gian cho phép đi trễ")}, 
                        new object[]{ null }),
                   new FieldNameCheck("CHO_PHEP_THONG_BAO",
                        new CheckType[]{ CheckType.Required},
                        new string[]{ ErrorMsgLib.errorRequired("Cho phép thông báo rộng rãi")}, 
                        new object[]{ null }),
                    new FieldNameCheck("SO_PHUT_LAP_LAI_THONG_BAO",
                        new CheckType[]{ CheckType.Required},
                        new string[]{ ErrorMsgLib.errorRequired("Số phút lặp lại thông báo rộng rãi")}, 
                        new object[]{ null })

            };
        }
        #endregion


        public void ViewChartXY()
        {
            ProtocolVN.Framework.Win.frmChartXY frm = new ProtocolVN.Framework.Win.frmChartXY(new ProtocolVN.Framework.Win.Demo.ChartXYDemo());
            ProtocolForm.ShowWindow(FrameworkParams.MainForm, frm, false);
        }

        public void ViewChartXYZ()
        {
            ProtocolVN.Framework.Win.frmChartXYZ frm = new ProtocolVN.Framework.Win.frmChartXYZ(new ProtocolVN.Framework.Win.Demo.ChartXYZDemo());
            ProtocolForm.ShowWindow(FrameworkParams.MainForm, frm, false);
        }
    }
}

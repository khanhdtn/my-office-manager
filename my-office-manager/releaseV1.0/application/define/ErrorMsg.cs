using System;
using System.Collections.Generic;
using System.Text;
using ProtocolVN.Framework.Core;
using ProtocolVN.Framework.Win;
using System.Data;

namespace office
{
    public class ErrorMsg
    {
        public static void ErrorDelete(object a)
        {
            string msg = "Xóa thông tin không thành công. Vui lòng kiểm tra lại số liệu.";
            if (PLException.GetLastestExceptions().Count >= 0)
            {
                string tmp = HelpDebug.GetUserErrorMsg(PLException.GetLastestExceptions());
                if (tmp != "" && tmp.IndexOf("PROTOCOL") == 0) msg = tmp;
            }
            HelpMsgBox.ShowNotificationMessage(msg);
        }
        public static void ErrorSave(object a)
        {
            string msg = "Lưu thông tin không thành công. Vui lòng kiểm tra lại số liệu.";
            List<Exception> listExs = PLException.GetLastestExceptions();

            if (listExs.Count >= 0)
            {
                string tmp = HelpDebug.GetUserErrorMsg(PLException.GetLastestExceptions());
                if (tmp != "" && tmp.IndexOf("PROTOCOL") == 0) msg = tmp;
            }
            HelpMsgBox.ShowNotificationMessage(msg);
        }
        public static void ErrorDeleted()
        {
          
            HelpMsgBox.ShowNotificationMessage("Dữ liệu không tồn tại. Vui lòng kiểm tra lại.");
        }
        public static string errorMaxLength(string subject,object MaxLength)
        {
            if (subject != string.Empty && subject.Trim() != "" && MaxLength!=null)
                return ("Vui lòng nhập vào thông tin \"" + subject + "\" ngắn hơn " + MaxLength.ToString() + " ký tự!");
            return ErrorMsgLib.errorMaxLength(subject);
        }
        #region Thông báo ràng buộc
        private static void ShowBizRuleProblems(DataSet dsBizRuleProblems)
        {
            if (dsBizRuleProblems != null &&
                dsBizRuleProblems.Tables.Count > 0 &&
                dsBizRuleProblems.Tables[0].Rows.Count > 0)
            {
                frmGridInfo frm = new frmGridInfo();
                frm.InitData(dsBizRuleProblems, "Thông báo");
                frm.TopMost = true;
                ProtocolForm.ShowModalDialog(FrameworkParams.MainForm, frm);
            }

        }
        private static DataSet CreateDsBizRule(string[] noiDungs, string[] cachXuLys, string[] loaiLois)
        {
            DataSet DataInfo = new DataSet("InvalidRangBuoc");
            DataTable tb = new DataTable("ErrorInfo");
            tb.Columns.AddRange(new DataColumn[] { 
                        new DataColumn("Nội dung",Type.GetType("System.String")),
                        new DataColumn("Cách xử lý",Type.GetType("System.String")),
                        new DataColumn("Loại",Type.GetType("System.String")),
                    }
            );
            for (int i = 0; i < noiDungs.Length; i++)
            {
                tb.Rows.Add(
                    (noiDungs[i] == null || noiDungs[i] == "") ? "..." : noiDungs[i],
                    (cachXuLys[i] == null || cachXuLys[i] == "") ? "..." : cachXuLys[i],
                    (loaiLois[i] == null || loaiLois[i] == "") ? "..." : loaiLois[i]
                    );
                DataInfo.Tables.Add(tb);
            }
            return DataInfo;
        }
        public static void ShowBizRuleProblems(string noiDung, string cachXuLy, string loaiLoi)
        {
            ShowBizRuleProblems(CreateDsBizRule(
                new string[] { noiDung },
                new string[] { cachXuLy },
                new string[] { loaiLoi }));

        }
        public static void ShowBizRuleProblems(string[] noiDung, string[] cachXuLy, string[] loaiLoi)
        {
            ShowBizRuleProblems(CreateDsBizRule(noiDung, cachXuLy, loaiLoi));
        }
        #endregion
    }
}

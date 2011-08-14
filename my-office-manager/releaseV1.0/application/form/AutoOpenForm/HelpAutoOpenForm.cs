using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProtocolVN.Framework.Win;
using System.Windows.Forms;
using ProtocolVN.Framework.Core;
namespace office
{
    public class HelpAutoOpenForm
    {
        private static char[] NumberChar = new char[]
        {
            'z','y','x','w','v','u','t','s','r','q'
        };
        private static string GerneratingStringFromNumber(long number)
        {
            string s = "";
            foreach (char c in number.ToString())
            {
                s += NumberChar[HelpNumber.ParseInt32(c.ToString())];
            }
            return s;
        }
        private static long GerNumberFromString(string str)
        {
            string s = new string(NumberChar);
            string r = "";
            foreach (char c in str)
            {
                r += s.IndexOf(c).ToString();
            }
            return HelpNumber.ParseInt64(r);
        }
        private static string ReverseString(string str)
        {
            char[] arr = str.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }
        public static string GeneratingCodeFromForm(Form frm, long id)
        {
            return GeneratingCodeFromForm(frm.GetType().FullName, id);
        }
        public static string GeneratingCodeFromForm(string ClassFormName, long id)
        {
            return ReverseString(ClassFormName).Replace(".", "-") + "-" + GerneratingStringFromNumber(id);
        }
        public static bool OpenFormFromCode(string code)
        {
            try
            {
                string classstring = ReverseString(code.Remove(code.LastIndexOf("-"))).Replace("-", ".");
                long objectID = GerNumberFromString(code.Substring(code.LastIndexOf("-") + 1));
                if (HelpXtraForm.ShowModalForm(FrameworkParams.MainForm, classstring, objectID) == null)
                    return false;
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}

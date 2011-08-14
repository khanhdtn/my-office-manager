using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Runtime.InteropServices;
using Microsoft.Win32;
using System.Reflection;

namespace pl.mail
{
    struct SHFILEINFO
    {
        public IntPtr hIcon;
        public int iIcon;
        public uint dwAttributes;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
        public string szDisplayName;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
        public string szTypeName;
    };

    class SysIcon
    {
        [DllImport("shell32.dll")]
        static extern IntPtr SHGetFileInfo(
            string pszPath,				//path
            uint dwFileAttributes,		//attributes
            ref SHFILEINFO psfi,		//struct pointer
            uint cbSizeFileInfo,		//size
            uint uFlags);	//flags

        public SysIcon()
        {
        }

        public static Icon  GetIcon(string Extension)
        {
            try
            {
                Icon TempIcon;
                //temp struct for getting file shell info
                SHFILEINFO TempFileInfo = new SHFILEINFO();

                SHGetFileInfo(Extension, 0, ref TempFileInfo, (uint)Marshal.SizeOf(TempFileInfo), 0x100 | 0x10 | 0x0);

                TempIcon = (Icon)Icon.FromHandle(TempFileInfo.hIcon);
                return TempIcon;
            }
            catch
            {
                return null;
            }
        }

        public static string FileType(string FileName)
        {
            string Extension = "";

            for (int i = FileName.Length - 1; i >= 0; i--)
            {
                if (FileName[i].ToString() != ".")
                    Extension = FileName[i].ToString() + Extension;
                else
                    break;
            }
            Extension = "." + Extension;
            return Extension;
        }
    }
}

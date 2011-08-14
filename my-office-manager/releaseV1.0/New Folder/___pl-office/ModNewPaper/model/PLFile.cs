using System;
using System.IO;
using ProtocolVN.Framework.Win;
namespace office
{
    public class PLFile
    {
        /// <summary>
        /// Folder that file is copied to
        /// </summary>
        public static string Directory_folder = FrameworkParams.TEMP_FOLDER;
        /// <summary>
        /// Copy file from pathSource to pathNew
        /// </summary>
        /// <param name="pathSource"></param>
        /// <param name="pathNew"></param>
        public static  void SaveFile(string pathSource,string pathNew)
        {            
            if (!File.Exists(pathNew))
            {
                FileStream filestream = new FileStream(pathNew, FileMode.CreateNew);               
                filestream.Close();
            }
            try
            {
                using (FileStream fsSource = new FileStream(pathSource,
                    FileMode.Open, FileAccess.Read))
                {

                    // Read the source file into a byte array.
                    byte[] bytes = new byte[fsSource.Length];
                    int numBytesToRead = (int)fsSource.Length;
                    int numBytesRead = 0;
                    while (numBytesToRead > 0)
                    {
                        // Read may return anything from 0 to numBytesToRead.
                        int n = fsSource.Read(bytes, numBytesRead, numBytesToRead);

                        // Break when the end of the file is reached.
                        if (n == 0)
                            break;

                        numBytesRead += n;
                        numBytesToRead -= n;
                    }
                    numBytesToRead = bytes.Length;
                    // Write the byte array to the other FileStream.
                    using (FileStream fsNew = new FileStream(pathNew,
                        FileMode.Create, FileAccess.Write))
                    {
                        fsNew.Write(bytes, 0, numBytesToRead);
                    }
                }
            }
            catch (FileNotFoundException ioEx)
            {
                Console.WriteLine(ioEx.Message);
            }
        }
    }
}

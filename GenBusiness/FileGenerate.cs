using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace GenBusiness
{
    public class FileGenerate
    {
        public void SaveFile(string dir, string filename, StringBuilder strBuilder)
        {
            #region
            string codeFilePath = dir + "\\" + filename;

            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);

            StreamWriter sw;
            if (!File.Exists(codeFilePath))
                sw = File.CreateText(codeFilePath);
            else
            {
                File.Delete(codeFilePath);
                sw = File.CreateText(codeFilePath);
            }
            sw.WriteLine(strBuilder.ToString());
            sw.WriteLine();
            sw.Dispose();
            #endregion
        }
        public void SaveFile(string filePath, string strCode)
        {
            StreamWriter sw;
            if (!File.Exists(filePath))
                sw = File.CreateText(filePath);
            else
            {
                File.Delete(filePath);
                sw = File.CreateText(filePath);
            }
            sw.WriteLine(strCode);
            sw.WriteLine();
            sw.Dispose();
        }
    }
}

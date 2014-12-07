using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.IO;
using System.Windows.Forms;

namespace GenAutoUpdate
{
    class FileList
    {
        private int aaa = 0;

        private void DirSearch(string strBaseDir, ArrayList fileList)
        {
            DirectoryInfo di = new DirectoryInfo(strBaseDir);
            DirectoryInfo[] diA = di.GetDirectories();
            if (aaa == 0)
            {
                FileInfo[] fis2 = di.GetFiles();   //有关目录下的文件   
                for (int i2 = 0; i2 < fis2.Length; i2++)
                {
                    fileList.Add(fis2[i2].FullName);
                    //fis2[i2].FullName是根目录中文件的绝对地址，把它记录在ArrayList中
                }
            }
            for (int i = 0; i < diA.Length; i++)
            {
                aaa++;
                fileList.Add(diA[i].FullName); //+ "\t<目录>"
                //diA[i].FullName是某个子目录的绝对地址，把它记录在ArrayList中
                DirectoryInfo di1 = new DirectoryInfo(diA[i].FullName);
                DirectoryInfo[] diA1 = di1.GetDirectories();
                FileInfo[] fis1 = di1.GetFiles();   //有关目录下的文件   
                for (int ii = 0; ii < fis1.Length; ii++)
                {
                    fileList.Add(fis1[ii].FullName);
                    //fis1[ii].FullName是某个子目录中文件的绝对地址，把它记录在ArrayList中

                }
                DirSearch(diA[i].FullName, fileList);
                //注意：递归了。逻辑思维正常的人应该能反应过来
            }
        }
        public string[] getUpdateList(string sDir)
        {
            string updateDir = Application.StartupPath + "\\" + (sDir);
            ArrayList fileList = new ArrayList();

            this.DirSearch(updateDir, fileList);
            string[] filePathArr = new string[fileList.Count];
            for (int i = 0; i < fileList.Count; i++)
                filePathArr[i] = fileList[i].ToString();
            return filePathArr;
        }
    }
}

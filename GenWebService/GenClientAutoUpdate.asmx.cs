using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Collections;
using System.IO;

namespace GenWebService
{
    /// <summary>
    /// GenClientAutoUpdate 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://GenClientAutoUpdate/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    // [System.Web.Script.Services.ScriptService]
    public class GenClientAutoUpdate : System.Web.Services.WebService
    {
        /*
        private string getUpdateDir()
        { 
            string url = this.
        }
         * */
        [WebMethod]
        public string HelloWorld(string sDir)
        {

            return Server.MapPath("~/") ;
        }
        private int aaa = 0;

        public void DirSearch(string strBaseDir, ArrayList fileList)
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
        /*
        private void DirSearch(string sDir, ArrayList fileList)
        {
            //当前目录下的文件未遍历到
            foreach (string d in Directory.GetDirectories(sDir))
            {
                foreach (string f in Directory.GetFiles(d))
                {
                    fileList.Add(f);
                }
                DirSearch(d, fileList); //递归查询 调用自己
            }
        }
        */

        [WebMethod]
        public string[] getUpdateList(string sDir)
        {
            string updateDir = Server.MapPath(sDir);
            ArrayList fileList = new ArrayList();

            this.DirSearch(updateDir, fileList);
            string[] filePathArr = new string[fileList.Count];
            for (int i = 0; i < fileList.Count; i++)
                filePathArr[i] = fileList[i].ToString().Replace(this.HelloWorld(""), "");
            return filePathArr;
        }
    }
}

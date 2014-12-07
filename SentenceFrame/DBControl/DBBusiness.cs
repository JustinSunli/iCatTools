using AccessLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SentenceFrame.DBControl
{
    class DBBusiness : AccessBase
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DataSet SelectSentence()
        {
            #region
            DataSet sentence = new DataSet();
            this.sqlSelectCommand1.CommandText = "select * from dbo.frame_relation";
            try
            {
                this.OpenDatabase();
                this.sqlDataAdapter1.Fill(sentence, "frame_relation");
            }
            catch
            {
                throw;
            }
            finally {
                this.CloseDatabase();
            }
            return sentence;
            #endregion
        }
    }
}

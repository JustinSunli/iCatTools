using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BaseBusiness
{
    public class SqlType
    {
        /// <summary>
        /// 从前台获取的字符串，转各类型forSql
        /// </summary>
        /// <param name="src"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static object ConvertForSQL(string src, EnumSqlType type)
        {
            #region
            string source = src.Trim();
            object rtValue = null;
            bool issuccess = false;
            switch (type)
            {
                case EnumSqlType.bigint:
                    {
                        long temp;
                        issuccess = Int64.TryParse(source, out temp);
                        rtValue = temp;
                        break;
                    }
                case EnumSqlType.bit:
                    {
                        bool temp;
                        issuccess = bool.TryParse(source, out temp);
                        rtValue = temp;
                        break;
                    }
                case EnumSqlType.datetime:
                    {
                        DateTime temp;
                        issuccess = DateTime.TryParse(source, out temp);
                        rtValue = temp;
                        break;
                    }
                case EnumSqlType.sqldecimal:
                    {
                        decimal temp;
                        issuccess = decimal.TryParse(source, out temp);
                        rtValue = temp;
                        break;
                    }
                case EnumSqlType.ntext:
                    {
                        if (source != string.Empty)
                        {
                            issuccess = true;
                            rtValue = source;
                        }
                        break;
                    }
                case EnumSqlType.nvarchar:
                    {
                        if (source != string.Empty)
                        {
                            issuccess = true;
                            rtValue = source;
                        }
                        break;
                    }
                case EnumSqlType.varchar:
                    {
                        if (source != string.Empty)
                        {
                            issuccess = true;
                            rtValue = source;
                        }
                        break;
                    }
                case EnumSqlType.tinyint:
                    {
                        byte temp;
                        issuccess = byte.TryParse(source, out temp);
                        rtValue = temp;
                        break;
                    }
                case EnumSqlType.uniqguid:
                    {
                        Guid temp;
                        issuccess = Guid.TryParse(source, out temp);
                        rtValue = temp;
                        break;
                    }
                case EnumSqlType.text:
                    {
                        if (source != string.Empty)
                        {
                            issuccess = true;
                            rtValue = source;
                        }
                        break;
                    }
                case EnumSqlType.sqlnumeric:
                    {
                        decimal temp;
                        issuccess = decimal.TryParse(source, out temp);
                        rtValue = temp;
                        break;
                    }
                case EnumSqlType.sqlint:
                    {
                        int temp;
                        issuccess = int.TryParse(source, out temp);
                        rtValue = temp;
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
            if (!issuccess)
                return System.DBNull.Value;
            else
                return rtValue;
            #endregion
        }
        /// <summary>
        /// 根据sql数据类型返回c#枚举
        /// </summary>
        /// <param name="sqlIntType"></param>
        /// <returns></returns>
        public static string GetEnumString(string sqlIntType)
        {
            #region
            string sqlEnumType = "EnumSqlType.";
            switch (sqlIntType)
            {
                case "127":
                    {
                        sqlEnumType += "bigint";
                        break;
                    }
                case "173":
                    {
                        sqlEnumType += "binary";
                        break;
                    }
                case "104":
                    {
                        sqlEnumType += "bit";
                        break;
                    }
                case "175":
                    {
                        sqlEnumType += "sqlchar";
                        break;
                    }
                case "61":
                    {
                        sqlEnumType += "datetime";
                        break;
                    }
                case "106":
                    {
                        sqlEnumType += "sqldecimal";
                        break;
                    }
                case "62":
                    {
                        sqlEnumType += "sqlfloat";
                        break;
                    }
                case "34":
                    {
                        sqlEnumType += "sqlimage";
                        break;
                    }
                case "56":
                    {
                        sqlEnumType += "sqlint";
                        break;
                    }
                case "60":
                    {
                        sqlEnumType += "money";
                        break;
                    }
                case "239":
                    {
                        sqlEnumType += "nchar";
                        break;
                    }
                case "99":
                    {
                        sqlEnumType += "ntext";
                        break;
                    }
                case "108":
                    {
                        sqlEnumType += "sqlnumeric";
                        break;
                    }
                case "231":
                    {
                        sqlEnumType += "nvarchar";
                        break;
                    }
                case "59":
                    {
                        sqlEnumType += "real";
                        break;
                    }
                case "58":
                    {
                        sqlEnumType += "smalldatetime";
                        break;
                    }
                case "52":
                    {
                        sqlEnumType += "smallint";
                        break;
                    }
                case "122":
                    {
                        sqlEnumType += "smallmoney";
                        break;
                    }
                case "98":
                    {
                        sqlEnumType += "sqlvariant";
                        break;
                    }
                case "35":
                    {
                        sqlEnumType += "text";
                        break;
                    }
                case "189":
                    {
                        sqlEnumType += "timestamp";
                        break;
                    }
                case "48":
                    {
                        sqlEnumType += "tinyint";
                        break;
                    }
                case "36":
                    {
                        sqlEnumType += "uniqguid";
                        break;
                    }
                case "165":
                    {
                        sqlEnumType += "varbinary";
                        break;
                    }
                case "167":
                    {
                        sqlEnumType += "varchar";
                        break;
                    }
                case "241":
                    {
                        sqlEnumType += "xml";
                        break;
                    }
                default:
                    {
                        sqlEnumType += "NULL";
                        break;
                    }
            }
            return sqlEnumType;
            #endregion
        }
    }
}

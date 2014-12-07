using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using GenClassLibrary;
using System.Data;

namespace GenBusiness
{
    public class TableBmp : GenTools
    {
        //private string tableName = "";
        private DataSet tableStructure = null;
        private DataSet tablePrimaryKey = null;
        private SizeF fieldNameSize = new SizeF(120, 16);
        private SizeF fieldDescribeSize = new SizeF(150, 16);
        private SizeF fieldTypeSize = new SizeF(150, 16);
        private int marginLeft = 15;
        private int marginRight = 15;
        private int marginTop = 15;
        private int marginBottom = 40;
        private int topContentHeight = 0;
        private int bottomContentHeight = 0;

        private Size formViewSize = new Size(0, 0);

        public TableBmp(string connectString)
            : base(connectString)
        {

        }
        /// <summary>
        /// 目标表名
        /// </summary>
        /*
        public String TableName
        {
            #region
            get
            {
                return tableName;
            }
            set
            {
                tableName = value;
            }
            #endregion
        }
         * */
        /// <summary>
        /// 根据内容计算图像各区域的大小。
        /// </summary>
        /// <param name="tablename"></param>
        /// <returns></returns>
        public Size GetSize()
        {
            #region
            int width = 0;
            int height = 0;

            if (this.tableName != "")
            {
                SqlColumn sqlcolclass = new SqlColumn(this._connectString);
                Bitmap measurecontainer = new Bitmap(1000, 300);
                Graphics g = Graphics.FromImage(measurecontainer);

                this.tableStructure = sqlcolclass.getColumnsAndType(tableName);
                this.tablePrimaryKey = sqlcolclass.getPkOfTable(tableName);
                DataRowCollection strucollect = this.tableStructure.Tables[0].Rows;
                SizeF colomnsizetemp = new SizeF(0, 0);
                SizeF describesizetemp = new SizeF(0, 0);
                SizeF fieldtypesizetemp = new SizeF(0, 0);
                for (int i = 0; i < strucollect.Count; i++)
                {
                    colomnsizetemp = g.MeasureString(strucollect[i]["name"].ToString(), new Font("Tahoma", 9));
                    describesizetemp = g.MeasureString(strucollect[i]["value"].ToString(), new Font("宋体", 9));
                    fieldtypesizetemp = g.MeasureString(strucollect[i]["xtypename"].ToString(), new Font("Tahoma", 9));
                    if (colomnsizetemp.Width > this.fieldNameSize.Width)
                        this.fieldNameSize = colomnsizetemp;
                    if (describesizetemp.Width > this.fieldDescribeSize.Width)
                        this.fieldDescribeSize = describesizetemp;
                    if (fieldtypesizetemp.Width > this.fieldTypeSize.Width)
                        this.fieldTypeSize = fieldtypesizetemp;
                }
                this.topContentHeight = (int)g.MeasureString("GJ", new Font("Tahoma", 12, FontStyle.Bold)).Height + 10;
                //this.bottomContentHeight = (int)g.MeasureString("GJ", new Font("Tahoma", 9)).Height + 20;
                width = this.marginLeft + this.marginRight + (int)this.fieldNameSize.Width + (int)this.fieldDescribeSize.Width + (int)this.fieldTypeSize.Width + 60;//富余宽度20
                height = this.topContentHeight + this.bottomContentHeight + this.marginTop + this.marginBottom + ((int)this.fieldNameSize.Height + 8) * strucollect.Count + 60;//菜单高度24+标题title高
                this.formViewSize.Width = width;
                this.formViewSize.Height = height;
            }
            return this.formViewSize;
            #endregion
        }
        /// <summary>
        /// 在图像顶端添加内容
        /// </summary>
        /// <param name="g"></param>
        /// <param name="startPoint"></param>
        private void AddTitle(Graphics g, ref Size startPoint)
        {
            #region
            string s = "TableName:" + this.tableName;
            g.DrawString(s, new Font("Tahoma", 12, FontStyle.Bold), Brushes.Red, startPoint.Width, startPoint.Height);
            startPoint.Height += this.topContentHeight;
            #endregion
        }
        /// <summary>
        /// 在图像底端添加内容
        /// </summary>
        /// <param name="g"></param>
        /// <param name="startPoint"></param>
        private void AddBottom(Graphics g, ref Size startPoint)
        {
            #region
            string s = "生成者：" + this.UserName;
            g.DrawString(s, new Font("Tahoma", 9), Brushes.Black, this.marginLeft, startPoint.Height + 5);
            startPoint.Height += this.bottomContentHeight + 5;
            #endregion
        }
        /// <summary>
        /// 添加字段名
        /// </summary>
        /// <param name="g"></param>
        /// <param name="struCollect"></param>
        /// <param name="startWidth"></param>
        /// <param name="contentFormat"></param> 
        private void AddFieldName(Graphics g, DataRowCollection struCollect, ref Size startPoint, StringFormat contentFormat)
        {
            #region
            int cellheight = (int)this.fieldNameSize.Height + 8;
            int cellwidth = (int)this.fieldNameSize.Width + 40;
            //添加表格头部
            DataRowCollection primarykeycollect = this.tablePrimaryKey.Tables[0].Rows;
            Point cellLocation = new Point(startPoint.Width, startPoint.Height);
            Rectangle cellRect = new Rectangle(cellLocation.X, cellLocation.Y, cellwidth, cellheight);
            g.FillRectangle(Brushes.LightGray, cellRect);
            g.DrawRectangle(Pens.Black, cellRect);
            string s = "表字段";
            g.DrawString(s, new Font("宋体", 9), Brushes.Black, cellRect, contentFormat);
            //添加数据表结构
            for (int row = 0; row < struCollect.Count; ++row)
            {
                cellLocation = new Point(startPoint.Width, (row + 1) * cellheight + startPoint.Height);
                cellRect = new Rectangle(cellLocation.X, cellLocation.Y, cellwidth, cellheight);
                
                s = struCollect[row]["name"].ToString();
                bool iskey = false;

                for (int i = 0; i < primarykeycollect.Count; i++)
                {
                    if (s == primarykeycollect[i]["COLUMN_NAME"].ToString())
                    {
                        g.FillRectangle(Brushes.Aqua, cellRect);
                        g.DrawString(s+"(PK)", new Font("Tahoma", 9, FontStyle.Underline), Brushes.Black, cellRect, contentFormat);
                        iskey = true;
                    }
                }
                if (!iskey)
                {
                    g.FillRectangle(Brushes.White, cellRect);
                    g.DrawString(s, new Font("Tahoma", 9), Brushes.Black, cellRect, contentFormat);
                }
                g.DrawRectangle(Pens.Black, cellRect);
            }
            startPoint.Width += cellwidth;
            
            #endregion
        }
        /// <summary>
        /// 添加字段类型
        /// </summary>
        /// <param name="g"></param>
        /// <param name="struCollect"></param>
        /// <param name="startWidth"></param>
        /// <param name="contentFormat"></param>
        private void AddFieldType(Graphics g, DataRowCollection struCollect, ref Size startPoint, StringFormat contentFormat)
        {
            #region
            int cellheight = (int)this.fieldNameSize.Height + 8;
            int cellwidth = (int)this.fieldTypeSize.Width + 10;
            Point cellLocation = new Point(startPoint.Width, startPoint.Height);
            Rectangle cellRect = new Rectangle(cellLocation.X, cellLocation.Y, cellwidth, cellheight);
            g.FillRectangle(Brushes.LightGray, cellRect);
            g.DrawRectangle(Pens.Black, cellRect);
            string s = "字段类型、精度";
            g.DrawString(s, new Font("宋体", 9), Brushes.Black, cellRect, contentFormat);
            //添加数据表结构
            for (int row = 0; row < struCollect.Count; ++row)
            {
                cellLocation = new Point(cellLocation.X, (row + 1) * cellheight + startPoint.Height);
                cellRect = new Rectangle(cellLocation.X, cellLocation.Y, cellwidth, cellheight);
                g.FillRectangle(Brushes.White, cellRect);
                g.DrawRectangle(Pens.Black, cellRect);
                s = struCollect[row]["xtypename"].ToString();
                g.DrawString(s, new Font("Tahoma", 9), Brushes.Black, cellRect, contentFormat);
            }

            startPoint.Width += cellwidth;
            #endregion
        }
        /// <summary>
        /// 添加字段描述
        /// </summary>
        /// <param name="g"></param>
        /// <param name="struCollect"></param>
        /// <param name="startWidth"></param>
        /// <param name="contentFormat"></param>
        private void AddDescribe(Graphics g, DataRowCollection struCollect, ref Size startPoint, StringFormat contentFormat)
        {
            #region
            int cellheight = (int)this.fieldNameSize.Height + 8;
            int cellwidth = (int)this.fieldDescribeSize.Width + 10;
            Point cellLocation = new Point(startPoint.Width, startPoint.Height);
            Rectangle cellRect = new Rectangle(cellLocation.X, cellLocation.Y, cellwidth, cellheight);
            g.FillRectangle(Brushes.LightGray, cellRect);
            g.DrawRectangle(Pens.Black, cellRect);
            string s = "字段描述";
            g.DrawString(s, new Font("宋体", 9), Brushes.Black, cellRect, contentFormat);
            //添加数据表结构
            for (int row = 0; row < struCollect.Count; ++row)
            {
                cellLocation = new Point(cellLocation.X, (row + 1) * cellheight + startPoint.Height);
                cellRect = new Rectangle(cellLocation.X, cellLocation.Y, cellwidth, cellheight);
                g.FillRectangle(Brushes.White, cellRect);
                g.DrawRectangle(Pens.Black, cellRect);
                s = struCollect[row]["value"].ToString();
                g.DrawString(s, new Font("宋体", 9), Brushes.Black, cellRect, contentFormat);
            }
            startPoint.Height += (struCollect.Count+1) * cellheight;
            #endregion
        }
        /// <summary>
        /// 根据单个表名获取表结构的图像。
        /// </summary>
        /// <param name="tablename"></param>
        /// <returns></returns>
        public Bitmap GetSingle()
        {
            #region
            DataRowCollection strucollect = this.tableStructure.Tables[0].Rows;
            Bitmap tablemap = new Bitmap(this.formViewSize.Width+1, this.formViewSize.Height - 60 + 1);
            Graphics g = Graphics.FromImage(tablemap);
            g.FillRectangle(Brushes.White, 0, 0, this.formViewSize.Width+1, this.formViewSize.Height-60+1);

            StringFormat sf = new StringFormat();
            sf.LineAlignment = StringAlignment.Center;

            Size startPoint = new Size(this.marginLeft, this.marginTop);

            this.AddTitle(g, ref startPoint);
            this.AddFieldName(g, strucollect, ref startPoint, sf);
            this.AddFieldType(g, strucollect, ref startPoint, sf);
            this.AddDescribe(g, strucollect, ref startPoint, sf);
            //this.AddBottom(g, ref startPoint);

            startPoint.Width = this.marginLeft;
            startPoint.Height = this.marginTop;
            fieldNameSize = new SizeF(120, 16);
            fieldDescribeSize = new SizeF(150, 16);
            fieldTypeSize = new SizeF(150, 16);

            return tablemap;
            #endregion
        }
    }
}

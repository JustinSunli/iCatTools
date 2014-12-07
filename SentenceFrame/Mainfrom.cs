using SentenceFrame.DBControl;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace SentenceFrame
{
    public partial class Mainfrom : Form
    {
        private string xmlFileName = "";
        private double[] matchFrameProps = new double[5] { 1.0, 0.8, 0.6, 0, 0 };
        private DataSet framedataset = null;
        public Mainfrom()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 选择文件事件方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBrowserFile_Click(object sender, EventArgs e)
        {
            #region
            this.openXMLFile.Title = "选择原始文件";
            this.openXMLFile.Filter = "XML files|*.xml";
            this.openXMLFile.FileName = string.Empty;
            this.openXMLFile.RestoreDirectory = true;

            DialogResult dr = this.openXMLFile.ShowDialog();

            if (dr == DialogResult.OK)
            {
                xmlFileName = this.openXMLFile.FileName;
                this.tbXMLFile.Text = xmlFileName;
            }
            #endregion

        }
        /// <summary>
        /// 生成txt文本
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGenTXT_Click(object sender, EventArgs e)
        {
            #region
            string sentencepath = "corpus/documents/document/paragraphs/paragraph/sentences/sentence";
            XmlDocument doc = new XmlDocument();
            doc.Load(this.openXMLFile.FileName);
            XmlNodeList xnl = doc.SelectNodes(sentencepath);
            StreamWriter xchangefile = this.getFileStream();
            StreamWriter sentenceresultfile = this.getFileResultStream();

            for (int i = 0; i < xnl.Count; i = i + 2)
            {
                ArrayList tframeelements = new ArrayList();
                ArrayList hframeelements = new ArrayList();
                String[] tFrames = this.writeSentence(xchangefile, xnl[i], i, tframeelements);
                String[] hFrames = this.writeSentence(xchangefile, xnl[i + 1], i + 1, hframeelements);

                this.calculateFrameMatch(tFrames, hFrames, sentenceresultfile, i);
                this.calculateFEMatch(tframeelements, hframeelements, sentenceresultfile, hFrames.Length);
            }

            xchangefile.Dispose();
            sentenceresultfile.Dispose();
            MessageBox.Show("生成成功！", "系统提示");
            #endregion
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tEle"></param>
        /// <param name="hEle"></param>
        /// <param name="hFramesCount"></param>
        private void calculateFEMatch(ArrayList tEle, ArrayList hEle, 
            StreamWriter sentenceResultFile, int hFramesCount)
        {
            #region
            int equalEle = 0;
            for (int m = 0; m < hEle.Count; m++)
            {
                for (int n = 0; n < tEle.Count; n++)
                {
                    if (hEle[m].Equals(tEle[n]))
                    {
                        equalEle++;
                        break;
                    }
                }
            }
            double matchelementrate = hFramesCount == 0 ? 0: Math.Round((double)(equalEle/hFramesCount),2);
            sentenceResultFile.WriteLine(string.Format("12:{0}", matchelementrate));
            #endregion
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="queryIN"></param>
        private DataRow[] getFrameName1IN(ref string queryIN)
        {
            #region
            if (string.IsNullOrEmpty(queryIN))
                return null;

            DataRow[] framerows = this.framedataset.Tables[0]
                .Select("frame_name1 in (" + queryIN + ")");

            queryIN = "";

            for (int i = 0; i < framerows.Length; i++)
            {
                queryIN += String.Format("'{0}'", framerows[i]["frame_name2"]);
                if (i != framerows.Length - 1)
                    queryIN += ",";
            }
            return framerows;
            #endregion
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tFrames"></param>
        /// <param name="hFrames"></param>
        /// <param name="matchprop"></param>
        /// <param name="matchframecount"></param>
        /// <param name="hFramesIndex"></param>
        private void Level5MatchFrame(String[] tFrames, String[] hFrames, 
            double[] matchprop, int[] matchframecount, int hFramesIndex, int matchTimes)
        {
            #region
            DataRow[] framerows = null;
            string queryIn = String.Format("'{0}'", hFrames[hFramesIndex]);
            for (int i = 0; i < matchTimes; i++)
            {
                framerows = null;
                framerows = getFrameName1IN(ref queryIn);
            }

            if (framerows == null)
                return;

            bool againjump = false;
            for (int n = 0; n < tFrames.Length; n++)
            {
                for (int p = 0; p < framerows.Length; p++)
                {
                    if (framerows[p]["frame_name2"].Equals(tFrames[n]))
                    {
                        matchprop[matchTimes] += this.matchFrameProps[matchTimes];
                        matchframecount[matchTimes]++;
                        againjump = true;
                        break;
                    }
                }
                if (againjump)
                    break;
            }

            framerows = null;
            #endregion
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tFrames"></param>
        /// <param name="hFrames"></param>
        /// <param name="sentenceResultFile"></param>
        /// <param name="sentenceIndex"></param>
        private void calculateFrameMatch(String[] tFrames, String[] hFrames, 
            StreamWriter sentenceResultFile, int sentenceIndex)
        {
            #region
            int equalcount = 0;
            double[] matchprop = new double[5] { 0, 0, 0, 0, 0 };
            int[] matchframecount = new int[5] { 0, 0, 0, 0, 0 };

            for (int m = 0; m < hFrames.Length; m++)
            {
                for (int i = 0; i < 3; i++)
                    this.Level5MatchFrame(tFrames, hFrames, matchprop, matchframecount, m, i);
                
                for (int x = 0; x < tFrames.Length; x++)
                {
                    if (hFrames[m].Equals(tFrames[x]))
                    {
                        equalcount++;
                        break;
                    }
                }
            }
            string[] matchpropsresult = new string[5];
            for (int f = 0; f < matchprop.Length; f++)
                matchpropsresult[f] = matchprop[f].ToString();

            double matchframerate = (hFrames.Length == 0) ? 0 : 
                Math.Round((double)(matchframecount[0] + matchframecount[1] + 
                matchframecount[2] + matchframecount[3] + matchframecount[4]) / hFrames.Length, 2);

            //sentenceResultFile.WriteLine(string.Format("[Group {0}]", sentenceIndex / 2 + 1));
            //sentenceResultFile.WriteLine(string.Format("TFrameCount = {0}; HFrameCount = {1};", tFrames.Length, hFrames.Length));
            //sentenceResultFile.WriteLine(string.Format("EqualFrameCount = {0};", equalcount));
            //sentenceResultFile.Write(string.Format("11:{0} 12:{1} 13:{2} ", matchpropsresult));
            sentenceResultFile.Write(string.Format("11:{0} ", matchframerate));
            //sentenceResultFile.WriteLine(string.Format("matchFrameRate = {0};", matchframerate));
            #endregion
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sw"></param>
        private String[] writeSentence(StreamWriter sw, XmlNode sentenceNode, 
            int sentenceIndex, ArrayList fElement)
        {
            #region
            string frameformat = "[{0}]";
            XmlNode txtvalue = sentenceNode.SelectSingleNode("text");
            string sentence = txtvalue.InnerText;
            String[] frames = null;
            sw.WriteLine(String.Format("(Root={0})", sentenceIndex + 1));
            sw.WriteLine(sentence);
            sw.WriteLine(String.Format(frameformat,
                this.getFrameInnertxt(sentence, sentenceNode, ref frames, fElement)));
            return frames;
            #endregion
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sentenceString"></param>
        /// <param name="sentence"></param>
        /// <returns></returns>
        private string getFrameInnertxt(string sentenceString, XmlNode sentence, 
            ref String[] frames, ArrayList fElement)
        {
            #region
            string feformat = "({0})";
            string frameinnertxt = "";
            string feinnertxt = "";

            XmlNodeList annotationSets = sentence.SelectNodes("annotationSets/annotationSet");
            frames = new String[annotationSets.Count];

            for (int m = 0; m < annotationSets.Count; m++)
            {
                feinnertxt = string.Format(feformat,
                    this.getFE(sentenceString, annotationSets[m], fElement));
                frames[m] = annotationSets[m].Attributes["frameName"].Value;
                frameinnertxt += frames[m] + feinnertxt;
                if (m != annotationSets.Count - 1)
                    frameinnertxt += ",";
            }
            return frameinnertxt;
            #endregion
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sentence"></param>
        /// <param name="annotationSet"></param>
        /// <returns></returns>
        private String getFE(string sentence, XmlNode annotationSet, ArrayList fElement)
        {
            #region
            XmlNodeList layers = annotationSet.SelectNodes("layers/layer");
            string feinnertxt = "";
            for (int n = 0; n < layers.Count; n++)
            {
                if (layers[n].Attributes["name"].Value == "FE")
                {
                    XmlNodeList label = layers[n].SelectNodes("labels/label");
                    for (int p = 0; p < label.Count; p++)
                    {
                        int startindex = 0, endindex = 0;
                        int.TryParse(label[p].Attributes["start"].Value, out startindex);
                        int.TryParse(label[p].Attributes["end"].Value, out endindex);

                        if (sentence.Length > endindex
                            && startindex <= endindex)
                        {
                            string ele = sentence.Substring(startindex, endindex - startindex + 1);
                            feinnertxt += ele;
                            if (p != label.Count - 1)
                                feinnertxt += ";";
                            fElement.Add(ele);
                        }
                    }
                }
            }
            return feinnertxt;
            #endregion
        }
        /// <summary>
        /// 获得保存后的文件流
        /// </summary>
        /// <returns></returns>
        private StreamWriter getFileStream()
        {
            #region
            StreamWriter sw;
            string txtfilepath = DateTime.Now.ToString("yyyyMMddHHmmss") + ".txt";
            if (!File.Exists(txtfilepath))
                sw = File.CreateText(txtfilepath);
            else
                sw = File.AppendText(txtfilepath);
            return sw;
            #endregion
        }
        /// <summary>
        /// 获得匹配度结果文件
        /// </summary>
        /// <returns></returns>
        private StreamWriter getFileResultStream()
        {
            #region
            StreamWriter sw;
            string txtfilepath = DateTime.Now.ToString("yyyyMMddHHmmss") + "Result.txt";
            if (!File.Exists(txtfilepath))
                sw = File.CreateText(txtfilepath);
            else
                sw = File.AppendText(txtfilepath);
            return sw;
            #endregion
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Mainfrom_Load(object sender, EventArgs e)
        {
            #region
            DBBusiness dbclass = new DBBusiness();
            this.framedataset = dbclass.SelectSentence();

            #endregion
        }
    }
}

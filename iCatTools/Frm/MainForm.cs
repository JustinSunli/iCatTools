/****************************************
###�����ˣ�lify
###����ʱ�䣺���ǵ���
###��˾��Cat Studio
###����޸�ʱ�䣺2012-03-02
###����޸��ˣ�lify
###�޸�ժҪ��
****************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using iCatTools.common;
using GenBusiness;
using GenClassLibrary;
using System.Threading;
using iCatTools.handle;
using iCatTools.socket;
using GenDataLibrary;
using iCatTools.business;
using System.IO;
using System.Drawing.Text;
using System.Collections;
using iCat.TextEditor.Document;

namespace iCatTools.Frm
{
    public partial class MainForm : Form
    {
        public static DataSet _DataSetAllTableName = new DataSet();
        public static string _ConnectionString = "";
        public static string _DatabaseName = "";

        
        private delegate void DLInitTableList(string xmlFile);
        private delegate string DLGetInsertString(string tableName);
        /// <summary>
        /// ���캯��
        /// </summary>
        public MainForm()
        {
            #region
            InitializeComponent();
            /*
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmSetParams,
            this.tsmView,
            this.tsmSql,this.tsmGenCode,this.AboutToolStripMenuItem});
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusLabelConnection});
            */
            #endregion
        }
        /// <summary>
        /// ���ɲ�����SQL���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmGenInsertSql_Click(object sender, EventArgs e)
        {
            #region
            string tableName = "";
            if (this.dataGridViewTableName.CurrentCell != null)
            {
                tableName = this.dataGridViewTableName.CurrentCell.Value.ToString();
                SqlGenBusiness sqlgenClass = new SqlGenBusiness(MainForm._ConnectionString);

                DLGetInsertString dlClass = new DLGetInsertString(sqlgenClass.GetInsertString);
                IAsyncResult result = dlClass.BeginInvoke(tableName, null, null);
                this.tbLogView.AppendText(dlClass.EndInvoke(result));
            }
            else
            {
                MessageBase.Show("δѡ���κα�");
                return;
            }
            #endregion
        }
        /// <summary>
        /// ��ʼ��������ݿ��б�
        /// </summary>
        /// <param name="xmlFileName"></param>
        private void InitTableList(string xmlFileName)
        {
            #region

            ConnectionData dsTemp = new ConnectionData();
            dsTemp.ReadXml(Application.StartupPath + "\\" + xmlFileName, XmlReadMode.Auto);
            DataRow dr = dsTemp.Tables[0].Rows[dsTemp.Tables[0].Rows.Count - 1];
            if (dr != null)
                _ConnectionString = "Data Source=" + dr["DataSource"].ToString() + ";Initial Catalog=" + dr["InitialCatalog"].ToString() + ";Persist Security Info=True;User ID=" + dr["UserID"].ToString() + ";Password=" + dr["Password"].ToString() + ";";
            this.StatusLabelConnection.Text = "��ǰ���ӣ�" + _ConnectionString;
            if (_ConnectionString != "")
            {
                try
                {
                    SqlTable sqlTableClass = new SqlTable(MainForm._ConnectionString);
                    _DataSetAllTableName = sqlTableClass.getTableName();
                    if (_DataSetAllTableName.Tables[0] != null)
                        this.dataGridViewTableName.DataSource = _DataSetAllTableName.Tables["tableName"].DefaultView;
                }
                catch
                {
                    MessageBase.ShowError("���ݿ����ӳ���");
                    return;
                }
            }
            #endregion
        }
        /// <summary>
        /// �������״�����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            #region
            Log.EnableViewError(true);
            Log.Listen();
            AutoUpdate.Execute();
            SysParameters.Init();
            CurrBusiBase.Init();
            MainView.SetViewForm(this);
            MainView.SetTitle();
            MainView.SetStatusIcon(this.nIconSystem);
            business.Register.Check();
            this.IsConnected(false);
            this.ToolButtonInit();
            this.EnableLogView(ApplicationBase.IsViewLog);
            //this.StartBckThread();
            #endregion
        }

        /// <summary>
        /// ���������ַ���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmSetConnect_Click(object sender, EventArgs e)
        {
            #region
            SelectConnection sc = new SelectConnection();
            sc.ShowDialog();
            if (_DataSetAllTableName.Tables["tableName"] != null)
            {
                this.StatusLabelConnection.Text = "��ǰ���ӣ�" + _ConnectionString;
                this.dataGridViewTableName.DataSource = _DataSetAllTableName.Tables["tableName"].DefaultView;
                this.IsConnected(true);
            }
            #endregion
        }
        /// <summary>
        /// ����ҵ��㱣�淽��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiGenCode_Click(object sender, EventArgs e)
        {
            #region
            //BusiLayerBusiness busiLayerGenClass = new BusiLayerBusiness(_ConnectionString);
            //StringBuilder codeStr = busiLayerGenClass.getAddCode(this.dataGridViewTableName.CurrentCell.Value.ToString(), null);
            //this.consolecode.Text = codeStr.ToString();
            #endregion
        }
        /// <summary>
        /// ��ȡ����ҵ���ļ�����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiGenSingleBusiFile_Click(object sender, EventArgs e)
        {
            #region
            this.consolecode.SetHighlighting("C#");
            BusiLayerBusiness busiLayerGenClass = new BusiLayerBusiness(_ConnectionString);
            busiLayerGenClass.Company = ApplicationBase.Company;
            busiLayerGenClass.UserName = ApplicationBase.KeyUser;
            busiLayerGenClass.SetTableName(this.dataGridViewTableName.CurrentCell.Value.ToString());
            StringBuilder codeStr = busiLayerGenClass.getSingleBusiFileCode(
                CurrBusiBase.CurrentLibData, CurrBusiBase.CommonLibBusi, CurrBusiBase.CurrentLibAcc, CurrBusiBase.CurrentLibBusi);
            this.consolecode.Text = codeStr.ToString();
            #endregion
        }

        /// <summary>
        /// ��������Դ���ļ�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiBatchGen_Click(object sender, EventArgs e)
        {
            #region
            if (this.folderSelectDlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.tsProcessBar.Visible = true;
                this.tsProcessBar.Value = 0;
                BusinessLayer busiLayer = new BusinessLayer(this.folderSelectDlg.SelectedPath, _DataSetAllTableName);
                ControlView ctrlView = new ControlView();

                ControlView.UpdateRTBControl dlupdlbl = new ControlView.UpdateRTBControl(ctrlView.UpdateRTB_Method);
                //ControlView.UpdatePBControl dlupProgress = new ControlView.UpdatePBControl(ctrlView.UpdatePB_Method);
                BusinessLayer.dl_DoBatchSaveBusi dl_doThings = new BusinessLayer.dl_DoBatchSaveBusi(busiLayer.BatchSave);
                AsyncCallback callbak = new AsyncCallback(busiLayer.SaveCallback);
                dl_doThings.BeginInvoke(this.tbLogView, dlupdlbl, this.tsProcessBar, callbak, dl_doThings);
            }
            #endregion
        }

        /// <summary>
        /// �Ҽ�����ѡ�д���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmCopy_Click(object sender, EventArgs e)
        {
            #region
            //if(this.consolecode.SelectedText != "")
            //    Clipboard.SetDataObject(this.consolecode.SelectedText);
            #endregion
        }
        /// <summary>
        /// �Ҽ����ļ����Ϊ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmTxtSave_Click(object sender, EventArgs e)
        {
            #region
            if (this.saveFileDlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                FileGenerate fileGen = new FileGenerate();
                fileGen.SaveFile(this.saveFileDlg.FileName, this.consolecode.Text);
                MessageBase.Show("����ɹ���");
            }
            #endregion
        }
        /// <summary>
        /// ���ɵ����ļ�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmGenSingleDataLayer_Click(object sender, EventArgs e)
        {
            #region
            this.consolecode.SetHighlighting("C#");
            DataLayerBusiness dataLayerGenClass = new DataLayerBusiness(_ConnectionString);
            dataLayerGenClass.Company = ApplicationBase.Company;
            dataLayerGenClass.UserName = ApplicationBase.KeyUser;
            dataLayerGenClass.SetTableName(this.dataGridViewTableName.CurrentCell.Value.ToString());
            StringBuilder codeStr = dataLayerGenClass.GetDataLayerString(
                CurrBusiBase.CurrentLibData, CurrBusiBase.CommonLibBusi);
            this.consolecode.Text = codeStr.ToString();
            #endregion
        }
        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmBatchGenDataLayer_Click(object sender, EventArgs e)
        {
            #region
            if (this.folderSelectDlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.tsProcessBar.Visible = true;
                this.tsProcessBar.Value = 0;
                DataLayer dataLayer = new DataLayer(this.folderSelectDlg.SelectedPath, _DataSetAllTableName);
                ControlView ctrlView = new ControlView();

                ControlView.UpdateRTBControl dlupdlbl = new ControlView.UpdateRTBControl(ctrlView.UpdateRTB_Method);
                DataLayer.dl_DoBatchSaveData dl_doThings = new DataLayer.dl_DoBatchSaveData(dataLayer.BatchSave);
                AsyncCallback callbak = new AsyncCallback(dataLayer.SaveCallback);
                dl_doThings.BeginInvoke(this.tbLogView, dlupdlbl, this.tsProcessBar, callbak, dl_doThings);
            }
            #endregion
        }
        /// <summary>
        /// ��տ���̨
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmClearConsole_Click(object sender, EventArgs e)
        {
            #region
            this.consolecode.Text = "";
            #endregion
        }
        /// <summary>
        /// �����������ݷ��ʲ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmGenAccSingleFile_Click(object sender, EventArgs e)
        {
            #region
            this.consolecode.SetHighlighting("C#");
            AccessLayerBusiness accLayerClass = new AccessLayerBusiness(_ConnectionString);
            accLayerClass.Company = ApplicationBase.Company;
            accLayerClass.UserName = ApplicationBase.KeyUser;
            accLayerClass.SetTableName(this.dataGridViewTableName.CurrentCell.Value.ToString());
            StringBuilder codeStr = accLayerClass.GetAccLayerString(
                CurrBusiBase.CurrentLibAcc, CurrBusiBase.CurrentLibData, CurrBusiBase.CommonLibACC, CurrBusiBase.CommonLibBusi);
            this.consolecode.Text = codeStr.ToString();
            #endregion
        }
        /// <summary>
        /// �����������ݷ��ʲ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmBatchAccessLayer_Click(object sender, EventArgs e)
        {
            #region
            if (this.folderSelectDlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.tsProcessBar.Visible = true;
                this.tsProcessBar.Value = 0;
                AccessLayer accessLayer = new AccessLayer(this.folderSelectDlg.SelectedPath, _DataSetAllTableName);
                ControlView ctrlView = new ControlView();

                ControlView.UpdateRTBControl dlupdlbl = new ControlView.UpdateRTBControl(ctrlView.UpdateRTB_Method);
                AccessLayer.dl_DoBatchSaveAcc dl_doThings = new AccessLayer.dl_DoBatchSaveAcc(accessLayer.BatchSave);
                AsyncCallback callbak = new AsyncCallback(accessLayer.SaveCallback);
                dl_doThings.BeginInvoke(this.tbLogView, dlupdlbl, this.tsProcessBar, callbak, dl_doThings);
            }
            #endregion
        }
        /// <summary>
        /// �����������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmSetLibName_Click(object sender, EventArgs e)
        {
            #region
            SetLibrary sl = new SetLibrary();
            sl.Show();
            #endregion
        }
        /// <summary>
        /// ���ڱ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmAbout_Click(object sender, EventArgs e)
        {
            #region
            AboutBox abox = new AboutBox();
            abox.Show();
            #endregion
        }
        /// <summary>
        /// ע�᱾���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmRegister_Click(object sender, EventArgs e)
        {
            #region
            Register reg = new Register();
            reg.Show();
            #endregion
        }
        /// <summary>
        /// �˳����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmExit_Click(object sender, EventArgs e)
        {
            #region
            if (DialogResult.OK == MessageBase.ShowConfirm("�Ƿ�Ҫ�˳��������"))
            {
                this.nIconSystem.Visible = false;
                System.Environment.Exit(0);
            }
            #endregion
        }
        /// <summary>
        /// ������Ϣ�������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmSendSrv_Click(object sender, EventArgs e)
        {
            #region
            SendMessage sndMsg = new SendMessage();
            sndMsg.ShowDialog();
            #endregion
        }
        /// <summary>
        /// ��ѯ�����ж��ټ�¼
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmQueryAllTableRowCount_Click(object sender, EventArgs e)
        {
            #region
            this.tsProcessBar.Visible = true;
            this.tsProcessBar.Value = 0;
            SqlGen sqlgen = new SqlGen(_DataSetAllTableName);
            ControlView ctrlView = new ControlView();

            ControlView.UpdateRTBControl dlupdlbl = new ControlView.UpdateRTBControl(ctrlView.UpdateRTB_Method);
            AccessLayer.dl_DoBatchSaveAcc dl_doThings = new AccessLayer.dl_DoBatchSaveAcc(sqlgen.GetAllTableRowCount);
            //AsyncCallback callbak = new AsyncCallback(accessLayer.SaveCallback);
            dl_doThings.BeginInvoke(this.tbLogView, dlupdlbl, this.tsProcessBar, null, null);
            #endregion
        }
        /// <summary>
        /// ���ݿ��Ƿ����������ƽ�����ʾ״̬
        /// </summary>
        /// <param name="isConnected"></param>
        private void IsConnected(bool isConnected)
        {
            #region
            this.tsmGenCode.Enabled = isConnected;
            this.tsmSql.Enabled = isConnected;
            this.tsmDevDesign.Enabled = isConnected;
            this.tsmcodetemplate.Enabled = isConnected;
            #endregion
        }
        /// <summary>
        /// ��ݰ�ť��UI��ʼ��
        /// </summary>
        private void ToolButtonInit()
        {
            #region
            this.tsbSetConnect.Text = this.tsmSetConnect.Text;
            this.tsbClearConsole.Text = this.tsmClearConsole.Text;
            this.tsbRegister.Text = this.tsmRegister.Text;
            this.tsbSetLib.Text = this.tsmSetLibName.Text;
            this.tsbAbout.Text = this.tsmAbout.Text;
            
            
            InstalledFontCollection fontcollect = new InstalledFontCollection();
            ArrayList fontfamily = new ArrayList();
            foreach (FontFamily family in fontcollect.Families)
                fontfamily.Add(family.Name);

            this.tscmbFontfamily.ComboBox.DataSource = fontfamily;
            ApplicationBase.ConsoleFontFamily = Config.Get("ConsoleFontFamily", ApplicationBase.ConsoleFontFamily);
            this.consolecode.ShowVRuler = false;
            this.consolecode.Font = new Font(ApplicationBase.ConsoleFontFamily, int.Parse(ApplicationBase.ConsoleFontSize), this.consolecode.Font.Style);
            this.tscmbFontfamily.ComboBox.SelectedItem = ApplicationBase.ConsoleFontFamily;
            this.tscbConsoleFontSize.ComboBox.SelectedItem = ApplicationBase.ConsoleFontSize;
            this.tscmbFontfamily.SelectedIndexChanged += new System.EventHandler(this.tscbConsoleFontSize_SelectedIndexChanged);
            this.tscbConsoleFontSize.SelectedIndexChanged += new System.EventHandler(this.tscbConsoleFontSize_SelectedIndexChanged);
            #endregion
        }
        /// <summary>
        /// �Ƿ���ʾ������־
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbEnableViewLog_Click(object sender, EventArgs e)
        {
            #region
            this.EnableLogView(!ApplicationBase.IsViewLog);
            #endregion
        }
        /// <summary>
        /// �Ƿ���ʾ��־
        /// </summary>
        /// <param name="isViewLog"></param>
        private void EnableLogView(bool isViewLog)
        {
            #region
            if (!isViewLog)
            {
                this.tsbEnableViewLog.Image = global::iCatTools.Properties.Resources.addlog;
                this.tsbEnableViewLog.Text = "��Ӵ�����־��ʾ����";
                ApplicationBase.IsViewLog = bool.Parse(Config.Update("IsViewLog", false.ToString()));
                this.gbErrorLog.Visible = false;
                this.tbLogView.Visible = false;
                this.splitter1.Visible = false;
            }
            else
            {
                this.tsbEnableViewLog.Image = global::iCatTools.Properties.Resources.dellog;
                this.tsbEnableViewLog.Text = "���ش�����־��ʾ����";
                ApplicationBase.IsViewLog = bool.Parse(Config.Update("IsViewLog", true.ToString()));
                this.gbErrorLog.Visible = true;
                this.tbLogView.Visible = true;
                this.splitter1.Visible = true;
            }
            #endregion
        }
        /// <summary>
        /// �鿴���д�����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmGetTrigger_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// �鿴���п����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmGetAllObjects_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// ���ɱ�ṹͼ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmGenTablebmp_Click(object sender, EventArgs e)
        {
            #region
            GenTableImage gentableimage = new GenTableImage();
            gentableimage.TableName = this.dataGridViewTableName.CurrentCell.Value.ToString();
            gentableimage.Show();
            #endregion
        }
        /// <summary>
        /// �������ɱ�ṹͼ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmBatchAllTableBmp_Click(object sender, EventArgs e)
        {
            #region
            if (this.folderSelectDlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.tsProcessBar.Visible = true;
                this.tsProcessBar.Value = 0;
                DBImage dbimagesave = new DBImage(this.folderSelectDlg.SelectedPath, _DataSetAllTableName);
                ControlView ctrlView = new ControlView();

                ControlView.UpdateRTBControl dlupdlbl = new ControlView.UpdateRTBControl(ctrlView.UpdateRTB_Method);
                DBImage.dl_DoBatchSaveAcc dl_doThings = new DBImage.dl_DoBatchSaveAcc(dbimagesave.BatchSave);
                AsyncCallback callbak = new AsyncCallback(dbimagesave.SaveCallback);
                dl_doThings.BeginInvoke(this.tbLogView, dlupdlbl, this.tsProcessBar, callbak, dl_doThings);
            }
            #endregion
        }
        /// <summary>
        /// ����UI�������õ����ݿ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmGenUIObject_Click(object sender, EventArgs e)
        {
            #region
            this.consolecode.SetHighlighting("JavaScript");
            UILayerBusiness uilayerbusi = new UILayerBusiness(_ConnectionString);
            uilayerbusi.Company = ApplicationBase.Company;
            uilayerbusi.UserName = ApplicationBase.KeyUser;

            StringBuilder codeStr = uilayerbusi.GetDataBaseObjectsForUI();
            this.consolecode.Text = codeStr.ToString();
            #endregion
        }
        /// <summary>
        /// ����Extjs���͵�CRUD����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmGenUICRUD_Click(object sender, EventArgs e)
        {
            #region
            this.consolecode.SetHighlighting("JavaScript");
            SetUIParams uiparams = new SetUIParams();
            uiparams.ShowDialog();
            if (uiparams.Finished)
            {
                UILayerBusiness uilayerbusi = new UILayerBusiness(_ConnectionString);
                uilayerbusi.Company = ApplicationBase.Company;
                uilayerbusi.UserName = ApplicationBase.KeyUser;

                StringBuilder codeStr = uilayerbusi.GetUI(ApplicationBase.UINamespace, ApplicationBase.UIPerpageRecord, ApplicationBase.UIStartrecord, ApplicationBase.UIHandlerName,
                    ApplicationBase.UIDeleteInformation, ApplicationBase.UINewEditTitle, ApplicationBase.UIQueryTitle, ApplicationBase.UIIsQuery,ApplicationBase.UIIsDelete, 
                    ApplicationBase.UIIsNewEdit, this.dataGridViewTableName.CurrentCell.Value.ToString());
                this.consolecode.Text = codeStr.ToString();
            }
            #endregion
        }
        /// <summary>
        /// ����UI���ҵ�����м����Ӵ���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmGenUIHandle_Click(object sender, EventArgs e)
        {
            #region
            this.consolecode.SetHighlighting("C#");
            HandleBusiness uilayerbusi = new HandleBusiness(_ConnectionString);
            uilayerbusi.Company = ApplicationBase.Company;
            uilayerbusi.UserName = ApplicationBase.KeyUser;
            uilayerbusi.SetTableName(this.dataGridViewTableName.CurrentCell.Value.ToString());
            StringBuilder codeStr = uilayerbusi.GetHandleFile();
            this.consolecode.Text = codeStr.ToString();
            #endregion
        }
        /// <summary>
        /// ����UICommon���͵�ģ�����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmuicommon_Click(object sender, EventArgs e)
        {
            #region
            this.consolecode.SetHighlighting("JavaScript");
            System.Reflection.Assembly asm = System.Reflection.Assembly.GetExecutingAssembly();
            Stream manifestResourceStream = null;
            manifestResourceStream = asm.GetManifestResourceStream("iCatTools.codetemplate.uicommon.txt");
            StreamReader SReader = new StreamReader(manifestResourceStream, Encoding.UTF8);
            this.consolecode.Text = SReader.ReadToEnd();
            #endregion
        }
        /// <summary>
        /// combobox��UI��ʵ�ֵ�ģ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmuicombobox_Click(object sender, EventArgs e)
        {
            #region
            this.consolecode.SetHighlighting("JavaScript");
            System.Reflection.Assembly asm = System.Reflection.Assembly.GetExecutingAssembly();
            Stream manifestResourceStream = null;
            manifestResourceStream = asm.GetManifestResourceStream("iCatTools.codetemplate.uieditcombo.txt");
            StreamReader SReader = new StreamReader(manifestResourceStream, Encoding.UTF8);
            this.consolecode.Text = SReader.ReadToEnd();
            #endregion
        }
        /// <summary>
        /// ���ƴ������̨�����С
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tscbConsoleFontSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            #region
            this.setconsolefont(this.tscmbFontfamily.SelectedItem.ToString(), this.tscbConsoleFontSize.SelectedItem.ToString());
            #endregion
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fontfamily"></param>
        /// <param name="fontsize"></param>
        private void setconsolefont(string fontfamily, string fontsize)
        {
            #region
            int fontsizecurrent = 12;
            string fontfamilycurrent = String.IsNullOrEmpty(fontfamily) ? "����" : fontfamily;
            int.TryParse(fontsize, out fontsizecurrent);
            this.consolecode.Font = new Font(fontfamilycurrent, fontsizecurrent, this.consolecode.Font.Style);
            ApplicationBase.ConsoleFontFamily = Config.Update("ConsoleFontFamily", fontfamilycurrent);
            ApplicationBase.ConsoleFontSize = Config.Update("ConsoleFontSize", fontsize);
            #endregion
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmAnalysisTools_Click(object sender, EventArgs e)
        {
            #region
            ExecSql execsqlfrm = new ExecSql();
            execsqlfrm.Show();
            #endregion
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmTestCodeEditor_Click(object sender, EventArgs e)
        {
            #region
            CodeEditor.CodeEditorShow();
            #endregion
        }
        /// <summary>
        /// ���ݿ������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmDBManager_Click(object sender, EventArgs e)
        {
            #region
            DBManager.TopShow();
            #endregion
        }
        /// <summary>
        /// ���ÿ���̨�Ĵ�����ʾΪJAVA��ʽ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbSetJavaFormat_Click(object sender, EventArgs e)
        {
            #region
            this.consolecode.SetHighlighting("Java");
            #endregion
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmGenEntityDataCode_Click(object sender, EventArgs e)
        {
            #region
            this.consolecode.SetHighlighting("C#");
            DataLayerBusiness dataLayerGenClass = new DataLayerBusiness(_ConnectionString);
            dataLayerGenClass.Company = ApplicationBase.Company;
            dataLayerGenClass.UserName = ApplicationBase.KeyUser;
            dataLayerGenClass.SetTableName(this.dataGridViewTableName.CurrentCell.Value.ToString());
            StringBuilder codeStr = dataLayerGenClass.GetEntityString(CurrBusiBase.CurrentLibData);
            this.consolecode.Text = codeStr.ToString();
            #endregion
        }

        private void tsmFileManage_Click(object sender, EventArgs e)
        {
            #region
            FileList.TopShow();
            #endregion
        }
    }
}
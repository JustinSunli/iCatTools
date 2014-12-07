using iCatTools.common;
namespace iCatTools.Frm
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tsmSetParams = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmSetConnect = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmSetLibName = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmView = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmClearConsole = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmSql = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmQueryAllTableRowCount = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmGetTrigger = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmGetAllObjects = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmGenInsertSql = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmDevDesign = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmGenTablebmp = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmBatchAllTableBmp = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmGenCode = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmGenUIObject = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmGenUICRUD = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmGenUIHandle = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiGenSingleBusiFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiBatchGen = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmGenSingleDataLayer = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmGenEntityDataCode = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmBatchGenDataLayer = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmGenAccSingleFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmBatchAccessLayer = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmcodetemplate = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmuicommon = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmuicombobox = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmDBManager = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmAnalysisTools = new System.Windows.Forms.ToolStripMenuItem();
            this.计算器ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.语音记事本ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmTestCodeEditor = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmFileManage = new System.Windows.Forms.ToolStripMenuItem();
            this.AboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmRegister = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmExit = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.StatusLabelConnection = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsProcessBar = new System.Windows.Forms.ToolStripProgressBar();
            this.cmsConsole = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmTxtSave = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmSendSrv = new System.Windows.Forms.ToolStripMenuItem();
            this.folderSelectDlg = new System.Windows.Forms.FolderBrowserDialog();
            this.saveFileDlg = new System.Windows.Forms.SaveFileDialog();
            this.nIconSystem = new System.Windows.Forms.NotifyIcon(this.components);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridViewTableName = new System.Windows.Forms.DataGridView();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.consolecode = new iCat.TextEditor.TextEditorControl();
            this.gbErrorLog = new System.Windows.Forms.GroupBox();
            this.tbLogView = new System.Windows.Forms.TextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbSetConnect = new System.Windows.Forms.ToolStripButton();
            this.tsbSetLib = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbClearConsole = new System.Windows.Forms.ToolStripButton();
            this.tsbEnableViewLog = new System.Windows.Forms.ToolStripButton();
            this.tsbRegister = new System.Windows.Forms.ToolStripButton();
            this.tsbAbout = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.tscmbFontfamily = new System.Windows.Forms.ToolStripComboBox();
            this.tscbConsoleFontSize = new System.Windows.Forms.ToolStripComboBox();
            this.tsbSetJavaFormat = new System.Windows.Forms.ToolStripButton();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.cmsConsole.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTableName)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.gbErrorLog.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmSetParams,
            this.tsmView,
            this.tsmSql,
            this.tsmDevDesign,
            this.tsmGenCode,
            this.tsmcodetemplate,
            this.toolStripMenuItem1,
            this.AboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(721, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tsmSetParams
            // 
            this.tsmSetParams.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmSetConnect,
            this.tsmSetLibName});
            this.tsmSetParams.Name = "tsmSetParams";
            this.tsmSetParams.Size = new System.Drawing.Size(84, 20);
            this.tsmSetParams.Text = "设置参数(&O)";
            // 
            // tsmSetConnect
            // 
            this.tsmSetConnect.Name = "tsmSetConnect";
            this.tsmSetConnect.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.S)));
            this.tsmSetConnect.Size = new System.Drawing.Size(208, 22);
            this.tsmSetConnect.Text = "设置连接字符串(&S)";
            this.tsmSetConnect.Click += new System.EventHandler(this.tsmSetConnect_Click);
            // 
            // tsmSetLibName
            // 
            this.tsmSetLibName.Name = "tsmSetLibName";
            this.tsmSetLibName.Size = new System.Drawing.Size(208, 22);
            this.tsmSetLibName.Text = "设置类库名称";
            this.tsmSetLibName.Click += new System.EventHandler(this.tsmSetLibName_Click);
            // 
            // tsmView
            // 
            this.tsmView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmClearConsole});
            this.tsmView.Name = "tsmView";
            this.tsmView.Size = new System.Drawing.Size(58, 20);
            this.tsmView.Text = "视图(&V)";
            // 
            // tsmClearConsole
            // 
            this.tsmClearConsole.Name = "tsmClearConsole";
            this.tsmClearConsole.ShortcutKeyDisplayString = "Alt+C";
            this.tsmClearConsole.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.C)));
            this.tsmClearConsole.Size = new System.Drawing.Size(188, 22);
            this.tsmClearConsole.Text = "清空控制台(&C)";
            this.tsmClearConsole.Click += new System.EventHandler(this.tsmClearConsole_Click);
            // 
            // tsmSql
            // 
            this.tsmSql.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmQueryAllTableRowCount,
            this.tsmGetTrigger,
            this.tsmGetAllObjects,
            this.toolStripSeparator4,
            this.tsmGenInsertSql});
            this.tsmSql.Enabled = false;
            this.tsmSql.Name = "tsmSql";
            this.tsmSql.Size = new System.Drawing.Size(78, 20);
            this.tsmSql.Text = "SQL辅助(&S)";
            // 
            // tsmQueryAllTableRowCount
            // 
            this.tsmQueryAllTableRowCount.Name = "tsmQueryAllTableRowCount";
            this.tsmQueryAllTableRowCount.Size = new System.Drawing.Size(182, 22);
            this.tsmQueryAllTableRowCount.Text = "查询各表数据量";
            this.tsmQueryAllTableRowCount.Click += new System.EventHandler(this.tsmQueryAllTableRowCount_Click);
            // 
            // tsmGetTrigger
            // 
            this.tsmGetTrigger.Name = "tsmGetTrigger";
            this.tsmGetTrigger.Size = new System.Drawing.Size(182, 22);
            this.tsmGetTrigger.Text = "查询库中触发器";
            this.tsmGetTrigger.Click += new System.EventHandler(this.tsmGetTrigger_Click);
            // 
            // tsmGetAllObjects
            // 
            this.tsmGetAllObjects.Name = "tsmGetAllObjects";
            this.tsmGetAllObjects.Size = new System.Drawing.Size(182, 22);
            this.tsmGetAllObjects.Text = "查询表所有对象信息";
            this.tsmGetAllObjects.Click += new System.EventHandler(this.tsmGetAllObjects_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(179, 6);
            // 
            // tsmGenInsertSql
            // 
            this.tsmGenInsertSql.Name = "tsmGenInsertSql";
            this.tsmGenInsertSql.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.I)));
            this.tsmGenInsertSql.Size = new System.Drawing.Size(182, 22);
            this.tsmGenInsertSql.Text = "导出插入语句";
            this.tsmGenInsertSql.Click += new System.EventHandler(this.tsmGenInsertSql_Click);
            // 
            // tsmDevDesign
            // 
            this.tsmDevDesign.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmGenTablebmp,
            this.tsmBatchAllTableBmp});
            this.tsmDevDesign.Enabled = false;
            this.tsmDevDesign.Name = "tsmDevDesign";
            this.tsmDevDesign.Size = new System.Drawing.Size(67, 20);
            this.tsmDevDesign.Text = "详细设计";
            // 
            // tsmGenTablebmp
            // 
            this.tsmGenTablebmp.Name = "tsmGenTablebmp";
            this.tsmGenTablebmp.Size = new System.Drawing.Size(182, 22);
            this.tsmGenTablebmp.Text = "查看目标表结构";
            this.tsmGenTablebmp.Click += new System.EventHandler(this.tsmGenTablebmp_Click);
            // 
            // tsmBatchAllTableBmp
            // 
            this.tsmBatchAllTableBmp.Name = "tsmBatchAllTableBmp";
            this.tsmBatchAllTableBmp.Size = new System.Drawing.Size(182, 22);
            this.tsmBatchAllTableBmp.Text = "批量生成表结构图像";
            this.tsmBatchAllTableBmp.Click += new System.EventHandler(this.tsmBatchAllTableBmp_Click);
            // 
            // tsmGenCode
            // 
            this.tsmGenCode.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmGenUIObject,
            this.tsmGenUICRUD,
            this.tsmGenUIHandle,
            this.toolStripSeparator5,
            this.tsmiGenSingleBusiFile,
            this.tsmiBatchGen,
            this.toolStripSeparator2,
            this.tsmGenSingleDataLayer,
            this.tsmGenEntityDataCode,
            this.tsmBatchGenDataLayer,
            this.toolStripSeparator3,
            this.tsmGenAccSingleFile,
            this.tsmBatchAccessLayer});
            this.tsmGenCode.Enabled = false;
            this.tsmGenCode.Name = "tsmGenCode";
            this.tsmGenCode.Size = new System.Drawing.Size(83, 20);
            this.tsmGenCode.Text = "生成代码(&G)";
            // 
            // tsmGenUIObject
            // 
            this.tsmGenUIObject.Name = "tsmGenUIObject";
            this.tsmGenUIObject.Size = new System.Drawing.Size(206, 22);
            this.tsmGenUIObject.Text = "生成UI对象文件";
            this.tsmGenUIObject.Click += new System.EventHandler(this.tsmGenUIObject_Click);
            // 
            // tsmGenUICRUD
            // 
            this.tsmGenUICRUD.Name = "tsmGenUICRUD";
            this.tsmGenUICRUD.Size = new System.Drawing.Size(206, 22);
            this.tsmGenUICRUD.Text = "生成UI层CRUD功能";
            this.tsmGenUICRUD.Click += new System.EventHandler(this.tsmGenUICRUD_Click);
            // 
            // tsmGenUIHandle
            // 
            this.tsmGenUIHandle.Name = "tsmGenUIHandle";
            this.tsmGenUIHandle.Size = new System.Drawing.Size(206, 22);
            this.tsmGenUIHandle.Text = "生成UI层一般处理文件";
            this.tsmGenUIHandle.Click += new System.EventHandler(this.tsmGenUIHandle_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(203, 6);
            // 
            // tsmiGenSingleBusiFile
            // 
            this.tsmiGenSingleBusiFile.Name = "tsmiGenSingleBusiFile";
            this.tsmiGenSingleBusiFile.Size = new System.Drawing.Size(206, 22);
            this.tsmiGenSingleBusiFile.Text = "生成单个业务层文件";
            this.tsmiGenSingleBusiFile.Click += new System.EventHandler(this.tsmiGenSingleBusiFile_Click);
            // 
            // tsmiBatchGen
            // 
            this.tsmiBatchGen.Name = "tsmiBatchGen";
            this.tsmiBatchGen.Size = new System.Drawing.Size(206, 22);
            this.tsmiBatchGen.Text = "批量生成业务层";
            this.tsmiBatchGen.Click += new System.EventHandler(this.tsmiBatchGen_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(203, 6);
            // 
            // tsmGenSingleDataLayer
            // 
            this.tsmGenSingleDataLayer.Name = "tsmGenSingleDataLayer";
            this.tsmGenSingleDataLayer.Size = new System.Drawing.Size(206, 22);
            this.tsmGenSingleDataLayer.Text = "生成单个数据层文件";
            this.tsmGenSingleDataLayer.Click += new System.EventHandler(this.tsmGenSingleDataLayer_Click);
            // 
            // tsmGenEntityDataCode
            // 
            this.tsmGenEntityDataCode.Name = "tsmGenEntityDataCode";
            this.tsmGenEntityDataCode.Size = new System.Drawing.Size(206, 22);
            this.tsmGenEntityDataCode.Text = "生成单个数据层实体文件";
            this.tsmGenEntityDataCode.Click += new System.EventHandler(this.tsmGenEntityDataCode_Click);
            // 
            // tsmBatchGenDataLayer
            // 
            this.tsmBatchGenDataLayer.Name = "tsmBatchGenDataLayer";
            this.tsmBatchGenDataLayer.Size = new System.Drawing.Size(206, 22);
            this.tsmBatchGenDataLayer.Text = "批量生成数据层";
            this.tsmBatchGenDataLayer.Click += new System.EventHandler(this.tsmBatchGenDataLayer_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(203, 6);
            // 
            // tsmGenAccSingleFile
            // 
            this.tsmGenAccSingleFile.Name = "tsmGenAccSingleFile";
            this.tsmGenAccSingleFile.Size = new System.Drawing.Size(206, 22);
            this.tsmGenAccSingleFile.Text = "生成单个数据访问层文件";
            this.tsmGenAccSingleFile.Click += new System.EventHandler(this.tsmGenAccSingleFile_Click);
            // 
            // tsmBatchAccessLayer
            // 
            this.tsmBatchAccessLayer.Name = "tsmBatchAccessLayer";
            this.tsmBatchAccessLayer.Size = new System.Drawing.Size(206, 22);
            this.tsmBatchAccessLayer.Text = "批量生成数据访问层";
            this.tsmBatchAccessLayer.Click += new System.EventHandler(this.tsmBatchAccessLayer_Click);
            // 
            // tsmcodetemplate
            // 
            this.tsmcodetemplate.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmuicommon,
            this.tsmuicombobox});
            this.tsmcodetemplate.Enabled = false;
            this.tsmcodetemplate.Name = "tsmcodetemplate";
            this.tsmcodetemplate.Size = new System.Drawing.Size(67, 20);
            this.tsmcodetemplate.Text = "代码模板";
            // 
            // tsmuicommon
            // 
            this.tsmuicommon.Name = "tsmuicommon";
            this.tsmuicommon.Size = new System.Drawing.Size(141, 22);
            this.tsmuicommon.Text = "uicommon";
            this.tsmuicommon.Click += new System.EventHandler(this.tsmuicommon_Click);
            // 
            // tsmuicombobox
            // 
            this.tsmuicombobox.Name = "tsmuicombobox";
            this.tsmuicombobox.Size = new System.Drawing.Size(141, 22);
            this.tsmuicombobox.Text = "uicombobox";
            this.tsmuicombobox.Click += new System.EventHandler(this.tsmuicombobox_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmDBManager,
            this.tsmAnalysisTools,
            this.计算器ToolStripMenuItem,
            this.语音记事本ToolStripMenuItem,
            this.tsmTestCodeEditor,
            this.tsmFileManage});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(67, 20);
            this.toolStripMenuItem1.Text = "其他工具";
            // 
            // tsmDBManager
            // 
            this.tsmDBManager.Name = "tsmDBManager";
            this.tsmDBManager.Size = new System.Drawing.Size(218, 22);
            this.tsmDBManager.Text = "数据库管理（备份、还原）";
            this.tsmDBManager.Click += new System.EventHandler(this.tsmDBManager_Click);
            // 
            // tsmAnalysisTools
            // 
            this.tsmAnalysisTools.Name = "tsmAnalysisTools";
            this.tsmAnalysisTools.Size = new System.Drawing.Size(218, 22);
            this.tsmAnalysisTools.Text = "简易查询分析器";
            this.tsmAnalysisTools.Click += new System.EventHandler(this.tsmAnalysisTools_Click);
            // 
            // 计算器ToolStripMenuItem
            // 
            this.计算器ToolStripMenuItem.Name = "计算器ToolStripMenuItem";
            this.计算器ToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.计算器ToolStripMenuItem.Text = "计算器";
            // 
            // 语音记事本ToolStripMenuItem
            // 
            this.语音记事本ToolStripMenuItem.Name = "语音记事本ToolStripMenuItem";
            this.语音记事本ToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.语音记事本ToolStripMenuItem.Text = "语音记事精灵";
            // 
            // tsmTestCodeEditor
            // 
            this.tsmTestCodeEditor.Name = "tsmTestCodeEditor";
            this.tsmTestCodeEditor.Size = new System.Drawing.Size(218, 22);
            this.tsmTestCodeEditor.Text = "测试代码编辑器";
            this.tsmTestCodeEditor.Click += new System.EventHandler(this.tsmTestCodeEditor_Click);
            // 
            // tsmFileManage
            // 
            this.tsmFileManage.Name = "tsmFileManage";
            this.tsmFileManage.Size = new System.Drawing.Size(218, 22);
            this.tsmFileManage.Text = "文件夹/文件管理";
            this.tsmFileManage.Click += new System.EventHandler(this.tsmFileManage_Click);
            // 
            // AboutToolStripMenuItem
            // 
            this.AboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmAbout,
            this.tsmRegister,
            this.tsmExit});
            this.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem";
            this.AboutToolStripMenuItem.Size = new System.Drawing.Size(79, 20);
            this.AboutToolStripMenuItem.Text = "关于本软件";
            // 
            // tsmAbout
            // 
            this.tsmAbout.Name = "tsmAbout";
            this.tsmAbout.Size = new System.Drawing.Size(122, 22);
            this.tsmAbout.Text = "关于";
            this.tsmAbout.Click += new System.EventHandler(this.tsmAbout_Click);
            // 
            // tsmRegister
            // 
            this.tsmRegister.Name = "tsmRegister";
            this.tsmRegister.Size = new System.Drawing.Size(122, 22);
            this.tsmRegister.Text = "注册信息";
            this.tsmRegister.Click += new System.EventHandler(this.tsmRegister_Click);
            // 
            // tsmExit
            // 
            this.tsmExit.Name = "tsmExit";
            this.tsmExit.Size = new System.Drawing.Size(122, 22);
            this.tsmExit.Text = "退出软件";
            this.tsmExit.Click += new System.EventHandler(this.tsmExit_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusLabelConnection,
            this.tsProcessBar});
            this.statusStrip1.Location = new System.Drawing.Point(0, 447);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(721, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // StatusLabelConnection
            // 
            this.StatusLabelConnection.Image = global::iCatTools.Properties.Resources.currconn;
            this.StatusLabelConnection.Name = "StatusLabelConnection";
            this.StatusLabelConnection.Size = new System.Drawing.Size(16, 17);
            // 
            // tsProcessBar
            // 
            this.tsProcessBar.Name = "tsProcessBar";
            this.tsProcessBar.Size = new System.Drawing.Size(100, 17);
            this.tsProcessBar.Visible = false;
            // 
            // cmsConsole
            // 
            this.cmsConsole.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmCopy,
            this.tsmTxtSave,
            this.tsmSendSrv});
            this.cmsConsole.Name = "cmsConsole";
            this.cmsConsole.Size = new System.Drawing.Size(171, 70);
            // 
            // tsmCopy
            // 
            this.tsmCopy.Name = "tsmCopy";
            this.tsmCopy.Size = new System.Drawing.Size(170, 22);
            this.tsmCopy.Text = "复制";
            this.tsmCopy.Click += new System.EventHandler(this.tsmCopy_Click);
            // 
            // tsmTxtSave
            // 
            this.tsmTxtSave.Name = "tsmTxtSave";
            this.tsmTxtSave.Size = new System.Drawing.Size(170, 22);
            this.tsmTxtSave.Text = "文本另存为……";
            this.tsmTxtSave.Click += new System.EventHandler(this.tsmTxtSave_Click);
            // 
            // tsmSendSrv
            // 
            this.tsmSendSrv.Name = "tsmSendSrv";
            this.tsmSendSrv.Size = new System.Drawing.Size(170, 22);
            this.tsmSendSrv.Text = "发送消息给服务端";
            this.tsmSendSrv.Click += new System.EventHandler(this.tsmSendSrv_Click);
            // 
            // folderSelectDlg
            // 
            this.folderSelectDlg.Description = "请选择保存目录";
            // 
            // saveFileDlg
            // 
            this.saveFileDlg.RestoreDirectory = true;
            // 
            // nIconSystem
            // 
            this.nIconSystem.Icon = ((System.Drawing.Icon)(resources.GetObject("nIconSystem.Icon")));
            this.nIconSystem.Text = "notifyIcon1";
            this.nIconSystem.Visible = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 49);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitter1);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox3);
            this.splitContainer1.Panel2.Controls.Add(this.gbErrorLog);
            this.splitContainer1.Size = new System.Drawing.Size(721, 398);
            this.splitContainer1.SplitterDistance = 208;
            this.splitContainer1.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridViewTableName);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(208, 398);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "所有数据表";
            // 
            // dataGridViewTableName
            // 
            this.dataGridViewTableName.AllowUserToAddRows = false;
            this.dataGridViewTableName.AllowUserToDeleteRows = false;
            this.dataGridViewTableName.AllowUserToResizeColumns = false;
            this.dataGridViewTableName.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Green;
            this.dataGridViewTableName.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewTableName.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewTableName.BackgroundColor = System.Drawing.SystemColors.ControlDark;
            this.dataGridViewTableName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewTableName.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridViewTableName.ColumnHeadersHeight = 18;
            this.dataGridViewTableName.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewTableName.ColumnHeadersVisible = false;
            this.dataGridViewTableName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewTableName.EnableHeadersVisualStyles = false;
            this.dataGridViewTableName.Location = new System.Drawing.Point(3, 16);
            this.dataGridViewTableName.MultiSelect = false;
            this.dataGridViewTableName.Name = "dataGridViewTableName";
            this.dataGridViewTableName.ReadOnly = true;
            this.dataGridViewTableName.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridViewTableName.RowHeadersVisible = false;
            this.dataGridViewTableName.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridViewTableName.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewTableName.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Green;
            this.dataGridViewTableName.RowTemplate.Height = 18;
            this.dataGridViewTableName.ShowCellErrors = false;
            this.dataGridViewTableName.ShowCellToolTips = false;
            this.dataGridViewTableName.ShowEditingIcon = false;
            this.dataGridViewTableName.ShowRowErrors = false;
            this.dataGridViewTableName.Size = new System.Drawing.Size(202, 379);
            this.dataGridViewTableName.TabIndex = 3;
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter1.Location = new System.Drawing.Point(0, 196);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(509, 3);
            this.splitter1.TabIndex = 5;
            this.splitter1.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.consolecode);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(509, 199);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "代码控制台";
            // 
            // consolecode
            // 
            this.consolecode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.consolecode.IsReadOnly = false;
            this.consolecode.Location = new System.Drawing.Point(3, 16);
            this.consolecode.Name = "consolecode";
            this.consolecode.Size = new System.Drawing.Size(503, 180);
            this.consolecode.TabIndex = 0;
            // 
            // gbErrorLog
            // 
            this.gbErrorLog.Controls.Add(this.tbLogView);
            this.gbErrorLog.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gbErrorLog.Location = new System.Drawing.Point(0, 199);
            this.gbErrorLog.Name = "gbErrorLog";
            this.gbErrorLog.Size = new System.Drawing.Size(509, 199);
            this.gbErrorLog.TabIndex = 7;
            this.gbErrorLog.TabStop = false;
            this.gbErrorLog.Text = "日志跟踪";
            // 
            // tbLogView
            // 
            this.tbLogView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbLogView.Location = new System.Drawing.Point(3, 16);
            this.tbLogView.Multiline = true;
            this.tbLogView.Name = "tbLogView";
            this.tbLogView.ReadOnly = true;
            this.tbLogView.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbLogView.Size = new System.Drawing.Size(503, 180);
            this.tbLogView.TabIndex = 6;
            this.tbLogView.WordWrap = false;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbSetConnect,
            this.tsbSetLib,
            this.toolStripSeparator1,
            this.tsbClearConsole,
            this.tsbEnableViewLog,
            this.tsbRegister,
            this.tsbAbout,
            this.toolStripSeparator6,
            this.toolStripLabel1,
            this.tscmbFontfamily,
            this.tscbConsoleFontSize,
            this.tsbSetJavaFormat});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(721, 25);
            this.toolStrip1.TabIndex = 5;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbSetConnect
            // 
            this.tsbSetConnect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSetConnect.Image = global::iCatTools.Properties.Resources.connectdb;
            this.tsbSetConnect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSetConnect.Name = "tsbSetConnect";
            this.tsbSetConnect.Size = new System.Drawing.Size(23, 22);
            this.tsbSetConnect.Text = "toolStripButton1";
            this.tsbSetConnect.Click += new System.EventHandler(this.tsmSetConnect_Click);
            // 
            // tsbSetLib
            // 
            this.tsbSetLib.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSetLib.Image = global::iCatTools.Properties.Resources.setlib;
            this.tsbSetLib.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSetLib.Name = "tsbSetLib";
            this.tsbSetLib.Size = new System.Drawing.Size(23, 22);
            this.tsbSetLib.Text = "toolStripButton2";
            this.tsbSetLib.Click += new System.EventHandler(this.tsmSetLibName_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbClearConsole
            // 
            this.tsbClearConsole.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbClearConsole.Image = global::iCatTools.Properties.Resources.del;
            this.tsbClearConsole.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbClearConsole.Name = "tsbClearConsole";
            this.tsbClearConsole.Size = new System.Drawing.Size(23, 22);
            this.tsbClearConsole.Text = "toolStripButton3";
            this.tsbClearConsole.Click += new System.EventHandler(this.tsmClearConsole_Click);
            // 
            // tsbEnableViewLog
            // 
            this.tsbEnableViewLog.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbEnableViewLog.Image = global::iCatTools.Properties.Resources.dellog;
            this.tsbEnableViewLog.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEnableViewLog.Name = "tsbEnableViewLog";
            this.tsbEnableViewLog.Size = new System.Drawing.Size(23, 22);
            this.tsbEnableViewLog.Text = "toolStripButton1";
            this.tsbEnableViewLog.Click += new System.EventHandler(this.tsbEnableViewLog_Click);
            // 
            // tsbRegister
            // 
            this.tsbRegister.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbRegister.Image = ((System.Drawing.Image)(resources.GetObject("tsbRegister.Image")));
            this.tsbRegister.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRegister.Name = "tsbRegister";
            this.tsbRegister.Size = new System.Drawing.Size(23, 22);
            this.tsbRegister.Text = "toolStripButton4";
            this.tsbRegister.Click += new System.EventHandler(this.tsmRegister_Click);
            // 
            // tsbAbout
            // 
            this.tsbAbout.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbAbout.Image = global::iCatTools.Properties.Resources.about;
            this.tsbAbout.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAbout.Name = "tsbAbout";
            this.tsbAbout.Size = new System.Drawing.Size(23, 22);
            this.tsbAbout.Text = "toolStripButton5";
            this.tsbAbout.Click += new System.EventHandler(this.tsmAbout_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(103, 22);
            this.toolStripLabel1.Text = "控制台字体大小：";
            // 
            // tscmbFontfamily
            // 
            this.tscmbFontfamily.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tscmbFontfamily.Name = "tscmbFontfamily";
            this.tscmbFontfamily.Size = new System.Drawing.Size(121, 25);
            // 
            // tscbConsoleFontSize
            // 
            this.tscbConsoleFontSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tscbConsoleFontSize.Items.AddRange(new object[] {
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18"});
            this.tscbConsoleFontSize.Name = "tscbConsoleFontSize";
            this.tscbConsoleFontSize.Size = new System.Drawing.Size(80, 25);
            // 
            // tsbSetJavaFormat
            // 
            this.tsbSetJavaFormat.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSetJavaFormat.Image = global::iCatTools.Properties.Resources.AA;
            this.tsbSetJavaFormat.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSetJavaFormat.Name = "tsbSetJavaFormat";
            this.tsbSetJavaFormat.Size = new System.Drawing.Size(23, 22);
            this.tsbSetJavaFormat.Text = "toolStripButton1";
            this.tsbSetJavaFormat.Click += new System.EventHandler(this.tsbSetJavaFormat_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(721, 469);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "代码生成器";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.cmsConsole.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTableName)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.gbErrorLog.ResumeLayout(false);
            this.gbErrorLog.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmSetParams;
        private System.Windows.Forms.ToolStripMenuItem AboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmSetConnect;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel StatusLabelConnection;
        private System.Windows.Forms.ContextMenuStrip cmsConsole;
        private System.Windows.Forms.ToolStripMenuItem tsmCopy;
        private System.Windows.Forms.ToolStripMenuItem tsmTxtSave;
        private System.Windows.Forms.ToolStripMenuItem tsmView;
        private System.Windows.Forms.ToolStripMenuItem tsmClearConsole;
        private System.Windows.Forms.FolderBrowserDialog folderSelectDlg;
        private System.Windows.Forms.SaveFileDialog saveFileDlg;
        private System.Windows.Forms.ToolStripMenuItem tsmSetLibName;
        private System.Windows.Forms.NotifyIcon nIconSystem;
        private System.Windows.Forms.ToolStripMenuItem tsmAbout;
        private System.Windows.Forms.ToolStripMenuItem tsmRegister;
        private System.Windows.Forms.ToolStripMenuItem tsmExit;
        private System.Windows.Forms.ToolStripProgressBar tsProcessBar;
        private System.Windows.Forms.ToolStripMenuItem tsmSendSrv;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dataGridViewTableName;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.TextBox tbLogView;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.ToolStripMenuItem tsmSql;
        private System.Windows.Forms.ToolStripMenuItem tsmQueryAllTableRowCount;
        private System.Windows.Forms.ToolStripMenuItem tsmGenInsertSql;
        private System.Windows.Forms.ToolStripMenuItem tsmGenCode;
        private System.Windows.Forms.ToolStripMenuItem tsmiGenSingleBusiFile;
        private System.Windows.Forms.ToolStripMenuItem tsmiBatchGen;
        private System.Windows.Forms.ToolStripMenuItem tsmGenSingleDataLayer;
        private System.Windows.Forms.ToolStripMenuItem tsmBatchGenDataLayer;
        private System.Windows.Forms.ToolStripMenuItem tsmGenAccSingleFile;
        private System.Windows.Forms.ToolStripMenuItem tsmBatchAccessLayer;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox gbErrorLog;
        private System.Windows.Forms.ToolStripButton tsbSetConnect;
        private System.Windows.Forms.ToolStripButton tsbSetLib;
        private System.Windows.Forms.ToolStripButton tsbClearConsole;
        private System.Windows.Forms.ToolStripButton tsbRegister;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbAbout;
        private System.Windows.Forms.ToolStripButton tsbEnableViewLog;
        private System.Windows.Forms.ToolStripMenuItem tsmGetTrigger;
        private System.Windows.Forms.ToolStripMenuItem tsmGetAllObjects;
        private System.Windows.Forms.ToolStripMenuItem tsmDevDesign;
        private System.Windows.Forms.ToolStripMenuItem tsmGenTablebmp;
        private System.Windows.Forms.ToolStripMenuItem tsmBatchAllTableBmp;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem tsmGenUIObject;
        private System.Windows.Forms.ToolStripMenuItem tsmGenUICRUD;
        private System.Windows.Forms.ToolStripMenuItem tsmGenUIHandle;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem tsmcodetemplate;
        private System.Windows.Forms.ToolStripMenuItem tsmuicommon;
        private System.Windows.Forms.ToolStripMenuItem tsmuicombobox;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox tscbConsoleFontSize;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem tsmAnalysisTools;
        private System.Windows.Forms.ToolStripMenuItem 计算器ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 语音记事本ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmDBManager;
        private System.Windows.Forms.ToolStripMenuItem tsmTestCodeEditor;
        private iCat.TextEditor.TextEditorControl consolecode;
        private System.Windows.Forms.ToolStripComboBox tscmbFontfamily;
        private System.Windows.Forms.ToolStripButton tsbSetJavaFormat;
        private System.Windows.Forms.ToolStripMenuItem tsmGenEntityDataCode;
        private System.Windows.Forms.ToolStripMenuItem tsmFileManage;
    }
}
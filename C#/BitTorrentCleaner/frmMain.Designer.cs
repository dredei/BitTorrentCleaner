namespace BitTorrentCleaner
{
    partial class FrmMain
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose( bool disposing )
        {
            if ( disposing && ( components != null ) )
            {
                components.Dispose();
            }
            base.Dispose( disposing );
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.lblPathToTorrents = new System.Windows.Forms.Label();
            this.btnSelectPath = new System.Windows.Forms.Button();
            this.tbTorrentsPath = new System.Windows.Forms.TextBox();
            this.pbAll = new System.Windows.Forms.ProgressBar();
            this.btnStart = new System.Windows.Forms.Button();
            this.lblDeleted = new System.Windows.Forms.Label();
            this.tbLog = new System.Windows.Forms.TextBox();
            this.rbRus = new System.Windows.Forms.RadioButton();
            this.rbEng = new System.Windows.Forms.RadioButton();
            this.lblSite = new System.Windows.Forms.Label();
            this.fbd1 = new System.Windows.Forms.FolderBrowserDialog();
            this.cbRecycle = new System.Windows.Forms.CheckBox();
            this.lblPathToResume = new System.Windows.Forms.Label();
            this.tbResumePath = new System.Windows.Forms.TextBox();
            this.btnSelResumePath = new System.Windows.Forms.Button();
            this.ofdResume = new System.Windows.Forms.OpenFileDialog();
            this.btnAnalys = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblPathToTorrents
            // 
            resources.ApplyResources(this.lblPathToTorrents, "lblPathToTorrents");
            this.lblPathToTorrents.Name = "lblPathToTorrents";
            // 
            // btnSelectPath
            // 
            resources.ApplyResources(this.btnSelectPath, "btnSelectPath");
            this.btnSelectPath.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSelectPath.Name = "btnSelectPath";
            this.btnSelectPath.UseVisualStyleBackColor = true;
            this.btnSelectPath.Click += new System.EventHandler(this.btnSelectPath_Click);
            // 
            // tbTorrentsPath
            // 
            resources.ApplyResources(this.tbTorrentsPath, "tbTorrentsPath");
            this.tbTorrentsPath.Name = "tbTorrentsPath";
            // 
            // pbAll
            // 
            resources.ApplyResources(this.pbAll, "pbAll");
            this.pbAll.Name = "pbAll";
            this.pbAll.Step = 1;
            // 
            // btnStart
            // 
            resources.ApplyResources(this.btnStart, "btnStart");
            this.btnStart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStart.Name = "btnStart";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // lblDeleted
            // 
            resources.ApplyResources(this.lblDeleted, "lblDeleted");
            this.lblDeleted.Name = "lblDeleted";
            // 
            // tbLog
            // 
            resources.ApplyResources(this.tbLog, "tbLog");
            this.tbLog.Name = "tbLog";
            this.tbLog.ReadOnly = true;
            // 
            // rbRus
            // 
            resources.ApplyResources(this.rbRus, "rbRus");
            this.rbRus.Checked = true;
            this.rbRus.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbRus.Name = "rbRus";
            this.rbRus.TabStop = true;
            this.rbRus.UseVisualStyleBackColor = true;
            this.rbRus.CheckedChanged += new System.EventHandler(this.rbRus_CheckedChanged);
            // 
            // rbEng
            // 
            resources.ApplyResources(this.rbEng, "rbEng");
            this.rbEng.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbEng.Name = "rbEng";
            this.rbEng.UseVisualStyleBackColor = true;
            this.rbEng.CheckedChanged += new System.EventHandler(this.rbEng_CheckedChanged);
            // 
            // lblSite
            // 
            resources.ApplyResources(this.lblSite, "lblSite");
            this.lblSite.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblSite.ForeColor = System.Drawing.Color.Blue;
            this.lblSite.Name = "lblSite";
            this.lblSite.Click += new System.EventHandler(this.lblSite_Click);
            // 
            // fbd1
            // 
            resources.ApplyResources(this.fbd1, "fbd1");
            // 
            // cbRecycle
            // 
            resources.ApplyResources(this.cbRecycle, "cbRecycle");
            this.cbRecycle.Checked = true;
            this.cbRecycle.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbRecycle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbRecycle.Name = "cbRecycle";
            this.cbRecycle.UseVisualStyleBackColor = true;
            // 
            // lblPathToResume
            // 
            resources.ApplyResources(this.lblPathToResume, "lblPathToResume");
            this.lblPathToResume.Name = "lblPathToResume";
            // 
            // tbResumePath
            // 
            resources.ApplyResources(this.tbResumePath, "tbResumePath");
            this.tbResumePath.Name = "tbResumePath";
            // 
            // btnSelResumePath
            // 
            resources.ApplyResources(this.btnSelResumePath, "btnSelResumePath");
            this.btnSelResumePath.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSelResumePath.Name = "btnSelResumePath";
            this.btnSelResumePath.UseVisualStyleBackColor = true;
            this.btnSelResumePath.Click += new System.EventHandler(this.btnSelResumePath_Click);
            // 
            // ofdResume
            // 
            this.ofdResume.FileName = "resume.dat";
            resources.ApplyResources(this.ofdResume, "ofdResume");
            // 
            // btnAnalys
            // 
            resources.ApplyResources(this.btnAnalys, "btnAnalys");
            this.btnAnalys.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAnalys.Name = "btnAnalys";
            this.btnAnalys.UseVisualStyleBackColor = true;
            this.btnAnalys.Click += new System.EventHandler(this.btnAnalys_Click);
            // 
            // FrmMain
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnAnalys);
            this.Controls.Add(this.btnSelResumePath);
            this.Controls.Add(this.tbResumePath);
            this.Controls.Add(this.lblPathToResume);
            this.Controls.Add(this.cbRecycle);
            this.Controls.Add(this.lblSite);
            this.Controls.Add(this.rbEng);
            this.Controls.Add(this.rbRus);
            this.Controls.Add(this.tbLog);
            this.Controls.Add(this.lblDeleted);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.pbAll);
            this.Controls.Add(this.tbTorrentsPath);
            this.Controls.Add(this.btnSelectPath);
            this.Controls.Add(this.lblPathToTorrents);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmMain";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMain_FormClosed);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPathToTorrents;
        private System.Windows.Forms.Button btnSelectPath;
        private System.Windows.Forms.TextBox tbTorrentsPath;
        private System.Windows.Forms.ProgressBar pbAll;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label lblDeleted;
        private System.Windows.Forms.TextBox tbLog;
        private System.Windows.Forms.RadioButton rbRus;
        private System.Windows.Forms.RadioButton rbEng;
        private System.Windows.Forms.Label lblSite;
        private System.Windows.Forms.FolderBrowserDialog fbd1;
        private System.Windows.Forms.CheckBox cbRecycle;
        private System.Windows.Forms.Label lblPathToResume;
        private System.Windows.Forms.TextBox tbResumePath;
        private System.Windows.Forms.Button btnSelResumePath;
        private System.Windows.Forms.OpenFileDialog ofdResume;
        private System.Windows.Forms.Button btnAnalys;
    }
}


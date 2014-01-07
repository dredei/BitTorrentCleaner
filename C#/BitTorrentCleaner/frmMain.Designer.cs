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
            this.SuspendLayout();
            // 
            // lblPathToTorrents
            // 
            this.lblPathToTorrents.AutoSize = true;
            this.lblPathToTorrents.Location = new System.Drawing.Point(0, 39);
            this.lblPathToTorrents.Name = "lblPathToTorrents";
            this.lblPathToTorrents.Size = new System.Drawing.Size(177, 13);
            this.lblPathToTorrents.TabIndex = 0;
            this.lblPathToTorrents.Text = "Путь к папке с торрент-файлами:";
            // 
            // btnSelectPath
            // 
            this.btnSelectPath.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSelectPath.Location = new System.Drawing.Point(279, 53);
            this.btnSelectPath.Name = "btnSelectPath";
            this.btnSelectPath.Size = new System.Drawing.Size(26, 23);
            this.btnSelectPath.TabIndex = 1;
            this.btnSelectPath.Text = "...";
            this.btnSelectPath.UseVisualStyleBackColor = true;
            this.btnSelectPath.Click += new System.EventHandler(this.btnSelectPath_Click);
            // 
            // tbTorrentsPath
            // 
            this.tbTorrentsPath.Location = new System.Drawing.Point(3, 55);
            this.tbTorrentsPath.Name = "tbTorrentsPath";
            this.tbTorrentsPath.Size = new System.Drawing.Size(270, 20);
            this.tbTorrentsPath.TabIndex = 2;
            this.tbTorrentsPath.Text = "c:\\Users\\Home\\AppData\\Roaming\\BitTorrent\\";
            // 
            // pbAll
            // 
            this.pbAll.Location = new System.Drawing.Point(3, 81);
            this.pbAll.Name = "pbAll";
            this.pbAll.Size = new System.Drawing.Size(302, 15);
            this.pbAll.Step = 1;
            this.pbAll.TabIndex = 3;
            // 
            // btnStart
            // 
            this.btnStart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStart.Location = new System.Drawing.Point(3, 187);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(302, 23);
            this.btnStart.TabIndex = 4;
            this.btnStart.Text = "Старт";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // lblDeleted
            // 
            this.lblDeleted.AutoSize = true;
            this.lblDeleted.Location = new System.Drawing.Point(0, 99);
            this.lblDeleted.Name = "lblDeleted";
            this.lblDeleted.Size = new System.Drawing.Size(54, 13);
            this.lblDeleted.TabIndex = 5;
            this.lblDeleted.Text = "Удалено:";
            // 
            // tbLog
            // 
            this.tbLog.Location = new System.Drawing.Point(3, 115);
            this.tbLog.Multiline = true;
            this.tbLog.Name = "tbLog";
            this.tbLog.ReadOnly = true;
            this.tbLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbLog.Size = new System.Drawing.Size(302, 66);
            this.tbLog.TabIndex = 6;
            // 
            // rbRus
            // 
            this.rbRus.AutoSize = true;
            this.rbRus.Checked = true;
            this.rbRus.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbRus.Location = new System.Drawing.Point(3, 216);
            this.rbRus.Name = "rbRus";
            this.rbRus.Size = new System.Drawing.Size(67, 17);
            this.rbRus.TabIndex = 7;
            this.rbRus.TabStop = true;
            this.rbRus.Text = "Русский";
            this.rbRus.UseVisualStyleBackColor = true;
            this.rbRus.CheckedChanged += new System.EventHandler(this.rbRus_CheckedChanged);
            // 
            // rbEng
            // 
            this.rbEng.AutoSize = true;
            this.rbEng.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbEng.Location = new System.Drawing.Point(76, 216);
            this.rbEng.Name = "rbEng";
            this.rbEng.Size = new System.Drawing.Size(59, 17);
            this.rbEng.TabIndex = 8;
            this.rbEng.Text = "English";
            this.rbEng.UseVisualStyleBackColor = true;
            this.rbEng.CheckedChanged += new System.EventHandler(this.rbEng_CheckedChanged);
            // 
            // lblSite
            // 
            this.lblSite.AutoSize = true;
            this.lblSite.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblSite.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblSite.ForeColor = System.Drawing.Color.Blue;
            this.lblSite.Location = new System.Drawing.Point(276, 218);
            this.lblSite.Name = "lblSite";
            this.lblSite.Size = new System.Drawing.Size(29, 13);
            this.lblSite.TabIndex = 9;
            this.lblSite.Text = "Site";
            this.lblSite.Click += new System.EventHandler(this.lblSite_Click);
            // 
            // cbRecycle
            // 
            this.cbRecycle.AutoSize = true;
            this.cbRecycle.Checked = true;
            this.cbRecycle.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbRecycle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbRecycle.Location = new System.Drawing.Point(141, 217);
            this.cbRecycle.Name = "cbRecycle";
            this.cbRecycle.Size = new System.Drawing.Size(122, 17);
            this.cbRecycle.TabIndex = 10;
            this.cbRecycle.Text = "Удалять в корзину";
            this.cbRecycle.UseVisualStyleBackColor = true;
            // 
            // lblPathToResume
            // 
            this.lblPathToResume.AutoSize = true;
            this.lblPathToResume.Location = new System.Drawing.Point(0, 0);
            this.lblPathToResume.Name = "lblPathToResume";
            this.lblPathToResume.Size = new System.Drawing.Size(98, 13);
            this.lblPathToResume.TabIndex = 11;
            this.lblPathToResume.Text = "Путь к resume.dat:";
            // 
            // tbResumePath
            // 
            this.tbResumePath.Location = new System.Drawing.Point(3, 16);
            this.tbResumePath.Name = "tbResumePath";
            this.tbResumePath.Size = new System.Drawing.Size(270, 20);
            this.tbResumePath.TabIndex = 12;
            this.tbResumePath.Text = "c:\\Users\\Home\\AppData\\Roaming\\BitTorrent\\resume.dat";
            // 
            // btnSelResumePath
            // 
            this.btnSelResumePath.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSelResumePath.Location = new System.Drawing.Point(279, 14);
            this.btnSelResumePath.Name = "btnSelResumePath";
            this.btnSelResumePath.Size = new System.Drawing.Size(26, 23);
            this.btnSelResumePath.TabIndex = 13;
            this.btnSelResumePath.Text = "...";
            this.btnSelResumePath.UseVisualStyleBackColor = true;
            this.btnSelResumePath.Click += new System.EventHandler(this.btnSelResumePath_Click);
            // 
            // ofdResume
            // 
            this.ofdResume.FileName = "resume.dat";
            this.ofdResume.Filter = "resume.dat|resume.dat";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(307, 236);
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
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BitTorrent Cleaner v1.0.2";
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
    }
}


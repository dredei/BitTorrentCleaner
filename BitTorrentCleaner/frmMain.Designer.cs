namespace BitTorrentCleaner
{
    partial class frmMain
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
            this.lblPathToResume = new System.Windows.Forms.Label();
            this.btnSelectPath = new System.Windows.Forms.Button();
            this.tbPath = new System.Windows.Forms.TextBox();
            this.pbAll = new System.Windows.Forms.ProgressBar();
            this.btnStart = new System.Windows.Forms.Button();
            this.lblDeleted = new System.Windows.Forms.Label();
            this.tbLog = new System.Windows.Forms.TextBox();
            this.rbRus = new System.Windows.Forms.RadioButton();
            this.rbEng = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // lblPathToResume
            // 
            this.lblPathToResume.AutoSize = true;
            this.lblPathToResume.Location = new System.Drawing.Point(0, 0);
            this.lblPathToResume.Name = "lblPathToResume";
            this.lblPathToResume.Size = new System.Drawing.Size(132, 13);
            this.lblPathToResume.TabIndex = 0;
            this.lblPathToResume.Text = "Путь к файлу resume.dat:";
            // 
            // btnSelectPath
            // 
            this.btnSelectPath.Location = new System.Drawing.Point(279, 14);
            this.btnSelectPath.Name = "btnSelectPath";
            this.btnSelectPath.Size = new System.Drawing.Size(26, 23);
            this.btnSelectPath.TabIndex = 1;
            this.btnSelectPath.Text = "...";
            this.btnSelectPath.UseVisualStyleBackColor = true;
            // 
            // tbPath
            // 
            this.tbPath.Location = new System.Drawing.Point(3, 16);
            this.tbPath.Name = "tbPath";
            this.tbPath.Size = new System.Drawing.Size(270, 20);
            this.tbPath.TabIndex = 2;
            this.tbPath.Text = "c:\\Users\\Home\\AppData\\Roaming\\BitTorrent\\";
            // 
            // pbAll
            // 
            this.pbAll.Location = new System.Drawing.Point(3, 42);
            this.pbAll.Name = "pbAll";
            this.pbAll.Size = new System.Drawing.Size(302, 15);
            this.pbAll.Step = 1;
            this.pbAll.TabIndex = 3;
            // 
            // btnStart
            // 
            this.btnStart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStart.Location = new System.Drawing.Point(3, 148);
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
            this.lblDeleted.Location = new System.Drawing.Point(0, 60);
            this.lblDeleted.Name = "lblDeleted";
            this.lblDeleted.Size = new System.Drawing.Size(54, 13);
            this.lblDeleted.TabIndex = 5;
            this.lblDeleted.Text = "Удалено:";
            // 
            // tbLog
            // 
            this.tbLog.Location = new System.Drawing.Point(3, 76);
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
            this.rbRus.Location = new System.Drawing.Point(3, 177);
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
            this.rbEng.Location = new System.Drawing.Point(76, 177);
            this.rbEng.Name = "rbEng";
            this.rbEng.Size = new System.Drawing.Size(59, 17);
            this.rbEng.TabIndex = 8;
            this.rbEng.Text = "English";
            this.rbEng.UseVisualStyleBackColor = true;
            this.rbEng.CheckedChanged += new System.EventHandler(this.rbEng_CheckedChanged);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(307, 196);
            this.Controls.Add(this.rbEng);
            this.Controls.Add(this.rbRus);
            this.Controls.Add(this.tbLog);
            this.Controls.Add(this.lblDeleted);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.pbAll);
            this.Controls.Add(this.tbPath);
            this.Controls.Add(this.btnSelectPath);
            this.Controls.Add(this.lblPathToResume);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BitTorrentCleaner";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPathToResume;
        private System.Windows.Forms.Button btnSelectPath;
        private System.Windows.Forms.TextBox tbPath;
        private System.Windows.Forms.ProgressBar pbAll;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label lblDeleted;
        private System.Windows.Forms.TextBox tbLog;
        private System.Windows.Forms.RadioButton rbRus;
        private System.Windows.Forms.RadioButton rbEng;
    }
}


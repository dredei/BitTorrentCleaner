#region Using

using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using ExtensionMethods;
using Ini;

#endregion

namespace BitTorrentCleaner
{
    public partial class FrmMain : Form
    {
        public string Locale = "ru-RU";

        private Thread _thr;
        private bool _loading = true;

        public FrmMain()
        {
            this.LoadLang();
            Thread.CurrentThread.CurrentUICulture = new CultureInfo( this.Locale );
            this.InitializeComponent();
        }

        private string GetBitTorrentPath()
        {
            string path = Environment.GetFolderPath( Environment.SpecialFolder.ApplicationData )
                          + @"\BitTorrent";
            if ( !File.Exists( path + @"\resume.dat" ) )
            {
                path = Environment.GetFolderPath( Environment.SpecialFolder.ApplicationData )
                       + @"\uTorrent";
            }
            return path;
        }

        private void LoadLang()
        {
            IniFile ini = new IniFile( Application.StartupPath + @"\Settings.ini" );
            this.Locale = ini.Read( "Lang", "Options", this.Locale );
        }

        private void SaveSettings()
        {
            IniFile ini = new IniFile( Application.StartupPath + @"\Settings.ini" );
            ini.Write( "TorrentsPath", this.tbTorrentsPath.Text, "Options" );
            ini.Write( "ResumePath", this.tbResumePath.Text, "Options" );
            ini.Write( "RemoveToRec", this.cbRecycle.Checked.ToString(), "Options" );
            ini.Write( "Lang", this.Locale, "Options" );
        }

        private void LoadSettings()
        {
            IniFile ini = new IniFile( Application.StartupPath + @"\Settings.ini" );
            this.tbTorrentsPath.Text = ini.Read( "TorrentsPath", "Options", this.tbTorrentsPath.Text );
            this.tbResumePath.Text = ini.Read( "ResumePath", "Options", this.tbResumePath.Text );
            this.cbRecycle.Checked = bool.Parse( ini.Read( "RemoveToRec", "Options", this.cbRecycle.Checked.ToString() ) );

            switch ( this.Locale )
            {
                case "ru-RU":
                    rbRus.Checked = true;
                    break;
                case "en-GB":
                    rbEng.Checked = true;
                    break;
                default:
                    rbRus.Checked = true;
                    break;
            }
        }

        private void SetLocale( string locale = "ru-RU" )
        {
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo( locale );
            this.Locale = locale;
            DialogResult res = MessageBox.Show( strings.RestartApp, strings.Warning, MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning );
            if ( res == DialogResult.Yes )
            {
                Application.Restart();
            }
        }

        private void WorkDelete()
        {
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo( this.Locale );
            Cleaner cln = new Cleaner( this.tbTorrentsPath.Text, this.tbResumePath.Text );
            cln.UpdEvent += this.UpdProgress;
            cln.Clean( this.cbRecycle.Checked );
            MessageBox.Show( strings.Done, strings.Information, MessageBoxButtons.OK, MessageBoxIcon.Information );
            this.btnStart.Enabled = true;
            this.btnAnalys.Enabled = true;
            this.tbLog.AppendText( strings.Done );
        }

        private void WorkAnalys()
        {
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo( this.Locale );
            Cleaner cln = new Cleaner( this.tbTorrentsPath.Text, this.tbResumePath.Text );
            cln.UpdEvent += this.UpdProgress;
            int deletedCount;
            long cleanSize;
            cln.Analys( out deletedCount, out cleanSize );
            string infoString = strings.AnalysDone.f( deletedCount, ExMethods.getSizeReadable( cleanSize ) );
            MessageBox.Show( infoString, strings.Information, MessageBoxButtons.OK, MessageBoxIcon.Information );
            this.btnStart.Enabled = true;
            this.btnAnalys.Enabled = true;
            this.tbLog.AppendText( infoString );
        }

        private void UpdProgress( object sender, UpdEventArgs e )
        {
            this.pbAll.Maximum = e.MaxProgress;
            this.pbAll.Value = e.Progress;
            if ( !string.IsNullOrEmpty( e.Msg ) && this.tbLog.Text.IndexOf( e.Msg ) < 0 )
            {
                this.tbLog.AppendText( e.Msg + "\r\n" );
            }
            this.lblDeleted.Text = strings.Deleted.f( ExMethods.getSizeReadable( e.CleanSize ), e.DeletedCount );
        }

        private void btnStart_Click( object sender, EventArgs e )
        {
            this.tbLog.Clear();
            if ( !File.Exists( this.tbResumePath.Text ) )
            {
                this.tbLog.AppendText( strings.WrongPath );
                MessageBox.Show( strings.WrongPath, strings.Error, MessageBoxButtons.OK, MessageBoxIcon.Error );
                return;
            }
            FrmWaiting frm = new FrmWaiting( this );
            var dRes = frm.ShowDialog();
            if ( dRes == DialogResult.Cancel )
            {
                return;
            }
            this.btnStart.Enabled = false;
            this.btnAnalys.Enabled = false;
            this._thr = new Thread( this.WorkDelete );
            this._thr.Start();
        }

        private void btnAnalys_Click( object sender, EventArgs e )
        {
            this.tbLog.Clear();
            if ( !File.Exists( this.tbResumePath.Text ) )
            {
                this.tbLog.AppendText( strings.WrongPath );
                MessageBox.Show( strings.WrongPath, strings.Error, MessageBoxButtons.OK, MessageBoxIcon.Error );
                return;
            }
            FrmWaiting frm = new FrmWaiting( this );
            var dRes = frm.ShowDialog();
            if ( dRes == DialogResult.Cancel )
            {
                return;
            }
            this.btnStart.Enabled = false;
            this.btnAnalys.Enabled = false;
            this._thr = new Thread( this.WorkAnalys );
            this._thr.Start();
        }

        private void frmMain_Load( object sender, EventArgs e )
        {
            CheckForIllegalCrossThreadCalls = false;
            this.tbTorrentsPath.Text = this.GetBitTorrentPath();
            this.tbResumePath.Text = this.tbTorrentsPath.Text + @"\resume.dat";
            this.LoadSettings();
            this._loading = false;
        }

        private void rbRus_CheckedChanged( object sender, EventArgs e )
        {
            if ( rbRus.Checked && !this._loading )
            {
                this.SetLocale();
            }
        }

        private void rbEng_CheckedChanged( object sender, EventArgs e )
        {
            if ( rbEng.Checked && !this._loading )
            {
                this.SetLocale( "en-GB" );
            }
        }

        private void lblSite_Click( object sender, EventArgs e )
        {
            Process.Start( @"http://www.softez.pp.ua/" );
        }

        private void btnSelectPath_Click( object sender, EventArgs e )
        {
            this.fbd1.SelectedPath = this.tbTorrentsPath.Text;
            if ( this.fbd1.ShowDialog() == DialogResult.OK )
            {
                this.tbTorrentsPath.Text = this.fbd1.SelectedPath;
            }
        }

        private void frmMain_FormClosed( object sender, FormClosedEventArgs e )
        {
            this.SaveSettings();
        }

        private void btnSelResumePath_Click( object sender, EventArgs e )
        {
            if ( this.ofdResume.ShowDialog() == DialogResult.OK )
            {
                this.tbResumePath.Text = this.ofdResume.FileName;
            }
        }
    }
}
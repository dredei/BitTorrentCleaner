using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using ExtensionMethods;
using Ini;

namespace BitTorrentCleaner
{
    public partial class frmMain : Form
    {
        Thread thr = null;
        string locale = "ru-Ru";
        string done;
        string wrongPath;
        string closeBT;

        public frmMain()
        {
            InitializeComponent();
            setLocale();
        }

        private string getBitTorrentPath()
        {
            string path = string.Empty;
            path = Environment.GetFolderPath( Environment.SpecialFolder.ApplicationData )
                + @"\BitTorrent";
            if ( !File.Exists( path + @"\resume.dat" ) )
            {
                path = Environment.GetFolderPath( Environment.SpecialFolder.ApplicationData )
                + @"\uTorrent";
            }
            return path;
        }

        private void saveSettings()
        {
            IniFile ini = new IniFile( Application.StartupPath + @"\Settings.ini" );
            ini.Write( "TorrentsPath", tbTorrentsPath.Text, "Options" );
            ini.Write( "ResumePath", tbResumePath.Text, "Options" );
            ini.Write( "RemoveToRec", cbRecycle.Checked.ToString(), "Options" );
        }

        private void loadSettings()
        {
            IniFile ini = new IniFile( Application.StartupPath + @"\Settings.ini" );
            tbTorrentsPath.Text = ini.Read( "TorrentsPath", "Options", tbTorrentsPath.Text );
            tbResumePath.Text = ini.Read( "ResumePath", "Options", tbResumePath.Text );
            cbRecycle.Checked = bool.Parse( ini.Read( "RemoveToRec", "Options", cbRecycle.Checked.ToString() ) );
        }

        private void setLocale( string locale = "ru-Ru" )
        {
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo( locale );
            lblPathToTorrents.Text = strings.PathToTorrents;
            lblDeleted.Text = strings.Deleted.f( 0, 0 );
            lblPathToResume.Text = strings.PathToResumeDat;
            btnStart.Text = strings.Start;
            cbRecycle.Text = strings.RemoveRecycle;
            this.done = strings.Done;
            this.wrongPath = strings.WrongPath;
            this.closeBT = strings.CloseBT;
            this.locale = locale;
        }

        private void work()
        {
            setLocale( locale );
            Cleaner cln = new Cleaner( tbTorrentsPath.Text, tbResumePath.Text );
            cln.updEvent += new EventHandler<UpdEventArgs>( updProgress );
            cln.Clean( cbRecycle.Checked );
            MessageBox.Show( this.done, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information );
            btnStart.Enabled = true;
            tbLog.AppendText( strings.Done );
        }

        private void updProgress( object sender, UpdEventArgs e )
        {
            pbAll.Maximum = e.maxProgress;
            pbAll.Value = e.progress;
            if ( !string.IsNullOrEmpty( e.msg ) && tbLog.Text.IndexOf( e.msg ) < 0 )
            {
                tbLog.AppendText( e.msg + "\r\n" );
            }
            lblDeleted.Text = strings.Deleted.f( ExMethods.getSizeReadable( e.cleanSize ), e.deletedCount );
        }

        private void btnStart_Click( object sender, EventArgs e )
        {
            setLocale( locale );
            tbLog.Clear();
            if ( !File.Exists( tbResumePath.Text ) )
            {
                tbLog.AppendText( this.wrongPath );
                MessageBox.Show( this.wrongPath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error );
                return;
            }
            Process[] btp = Process.GetProcessesByName( "BitTorrent" );
            if ( btp.Length > 0 )
            {
                MessageBox.Show( this.closeBT, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning );
                btp[ 0 ].WaitForExit();
            }
            Process[] up = Process.GetProcessesByName( "uTorrent" );
            if ( up.Length > 0 )
            {
                MessageBox.Show( this.closeBT, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning );
                up[ 0 ].WaitForExit();
            }
            btnStart.Enabled = false;
            thr = new Thread( work );
            thr.Start();
        }

        private void frmMain_Load( object sender, EventArgs e )
        {
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;
            tbTorrentsPath.Text = getBitTorrentPath();
            tbResumePath.Text = tbTorrentsPath.Text + @"\resume.dat";
            this.loadSettings();
        }

        private void rbRus_CheckedChanged( object sender, EventArgs e )
        {
            if ( rbRus.Checked )
            {
                setLocale( "ru-Ru" );
            }
        }

        private void rbEng_CheckedChanged( object sender, EventArgs e )
        {
            if ( rbEng.Checked )
            {
                setLocale( "en-Us" );
            }
        }

        private void lblSite_Click( object sender, EventArgs e )
        {
            Process.Start( @"http://softez.pp.ua/" );
        }

        private void btnSelectPath_Click( object sender, EventArgs e )
        {
            fbd1.SelectedPath = tbTorrentsPath.Text;
            if ( fbd1.ShowDialog() == DialogResult.OK )
            {
                tbTorrentsPath.Text = fbd1.SelectedPath;
            }
        }

        private void frmMain_FormClosed( object sender, FormClosedEventArgs e )
        {
            this.saveSettings();
        }

        private void btnSelResumePath_Click( object sender, EventArgs e )
        {
            if ( ofdResume.ShowDialog() == DialogResult.OK )
            {
                tbResumePath.Text = ofdResume.FileName;
            }
        }
    }
}

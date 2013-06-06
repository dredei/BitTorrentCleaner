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
            return path;
        }

        private void setLocale( string locale = "ru-Ru" )
        {
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo( locale );
            lblPathToResume.Text = strings.PathToResumeDat;
            lblDeleted.Text = strings.Deleted.f( 0, 0 );
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
            Cleaner cln = new Cleaner( tbPath.Text );
            cln.updEvent += new EventHandler<UpdEventArgs>( updProgress );
            cln.Clean( cbRecycle.Checked );
            MessageBox.Show( this.done, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information );
            btnStart.Enabled = true;
            tbLog.AppendText( strings.Done );
        }

        private string hSize( long sizeB )
        {
            string[] sizes = { "B", "KB", "MB", "GB" };
            int order = 0;
            while ( sizeB >= 1024 && order + 1 < sizes.Length )
            {
                order++;
                sizeB = sizeB / 1024;
            }
            string result = String.Format( "{0:0.##} {1}", sizeB, sizes[ order ] );
            return result;
        }

        private void updProgress( object sender, UpdEventArgs e )
        {
            pbAll.Maximum = e.maxProgress;
            pbAll.Value = e.progress;
            if ( !string.IsNullOrEmpty( e.msg ) && tbLog.Text.IndexOf( e.msg ) < 0 )
            {
                tbLog.AppendText( e.msg + "\n" );
            }
            lblDeleted.Text = strings.Deleted.f( hSize( e.cleanSize ), e.deletedCount );
        }

        private void btnStart_Click( object sender, EventArgs e )
        {
            setLocale( locale );
            tbLog.Clear();
            if ( !File.Exists( tbPath.Text + @"\resume.dat" ) )
            {
                tbLog.AppendText( this.wrongPath );
                MessageBox.Show( this.wrongPath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error );
                return;
            }
            if ( tbPath.Text.IndexOf( "BitTorrent" ) >= 0 )
            {
                Process[] btp = Process.GetProcessesByName( "BitTorrent" );
                if ( btp.Length > 0 )
                {
                    MessageBox.Show( this.closeBT, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning );
                    btp[ 0 ].WaitForExit();
                }
            }
            else if ( tbPath.Text.IndexOf( "uTorrent" ) >= 0 )
            {
                Process[] up = Process.GetProcessesByName( "uTorrent" );
                if ( up.Length > 0 )
                {
                    MessageBox.Show( this.closeBT, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning );
                    up[ 0 ].WaitForExit();
                }
            }
            btnStart.Enabled = false;
            thr = new Thread( work );
            thr.Start();
        }

        private void frmMain_Load( object sender, EventArgs e )
        {
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;
            tbPath.Text = getBitTorrentPath();
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
            fbd1.SelectedPath = tbPath.Text;
            if ( fbd1.ShowDialog() == DialogResult.OK )
            {
                tbPath.Text = fbd1.SelectedPath;
            }
        }
    }

    public static class ExtensionMethods
    {
        public static string f( this string str, params object[] args )
        {
            return string.Format( str, args );
        }
    }
}

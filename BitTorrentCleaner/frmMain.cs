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

        public frmMain()
        {
            InitializeComponent();
            setLocale();
        }

        private string getBitTorrentPath()
        {
            System.OperatingSystem os = System.Environment.OSVersion;
            string path = string.Empty;
            /*switch ( os.Platform )
            {
                case System.PlatformID.Win32NT:
                    switch ( os.Version.Major )
                    {
                        case 5: // 2000 - XP
                            path = Environment.GetFolderPath( Environment.SpecialFolder.ApplicationData )
                                + @"\BitTorrent";
                            break;
                        case 6: // >=Vista
                            path = Environment.GetFolderPath( Environment.SpecialFolder.ApplicationData ) 
                                +@"\BitTorrent";
                            break;
                    }
                    break;
            }*/
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
            this.locale = locale;
        }

        private void work()
        {
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo( locale );
            Cleaner cln = new Cleaner( tbPath.Text );
            cln.updEvent += new EventHandler<UpdEventArgs>( updProgress );
            cln.Clean();
            MessageBox.Show( strings.Done, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information );
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
            if ( !string.IsNullOrEmpty( e.msg ) )
            {
                tbLog.AppendText( e.msg + "\n" );
            }
            lblDeleted.Text = strings.Deleted.f( hSize( e.cleanSize ), e.deletedCount );
        }

        private void btnStart_Click( object sender, EventArgs e )
        {
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo( locale );
            tbLog.Clear();
            if ( !File.Exists( tbPath.Text + @"\resume.dat" ) )
            {
                tbLog.AppendText( strings.WrongPath );
                MessageBox.Show( strings.WrongPath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error );
                return;
            }
            Process[] btp = Process.GetProcessesByName( "BitTorrent" );
            Process[] up = Process.GetProcessesByName( "uTorrent" );
            if ( btp.Length > 0 || up.Length > 0 )
            {
                MessageBox.Show( strings.CloseBT, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning );
                if ( btp.Length > 0 )
                    btp[ 0 ].WaitForExit();
                if ( up.Length > 0 )
                    up[ 0 ].WaitForExit();
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

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BitTorrentCleaner
{
    public partial class FrmWaiting : Form
    {
        private readonly string[] _proccess = { "BitTorrent", "uTorrent" };

        public FrmWaiting()
        {
            InitializeComponent();
            this.DialogResult = DialogResult.Cancel;
        }

        private void tmrCheck_Tick( object sender, EventArgs e )
        {
            // если запущен один из процессов торрент-клиента, то выходим из функции
            if ( this._proccess.Select( Process.GetProcessesByName ).Any( torrProc => torrProc.Length > 0 ) )
            {
                return;
            }
            tmrCheck.Stop();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}

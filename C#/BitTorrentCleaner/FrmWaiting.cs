#region Using

using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

#endregion

namespace BitTorrentCleaner
{
    public partial class FrmWaiting : Form
    {
        private readonly string[] _proccess = { "BitTorrent", "uTorrent" };

        public FrmWaiting()
        {
            this.InitializeComponent();
            this.DialogResult = DialogResult.Cancel;
        }

        private void tmrCheck_Tick( object sender, EventArgs e )
        {
            // если запущен один из процессов торрент-клиента, то выходим из функции
            if ( this._proccess.Select( Process.GetProcessesByName ).Any( torrProc => torrProc.Length > 0 ) )
            {
                return;
            }
            this.tmrCheck.Stop();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
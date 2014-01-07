#region Using

using System;
using System.IO;
using ExtensionMethods;
using Microsoft.VisualBasic.FileIO;
using MonoTorrent.BEncoding;

#endregion

namespace BitTorrentCleaner
{
    public class UpdEventArgs : EventArgs
    {
        public int Progress { get; set; }
        public int MaxProgress { get; set; }
        public int DeletedCount { get; set; }
        public long CleanSize { get; set; }
        public string Msg { get; set; }
    }

    internal class Cleaner
    {
        private readonly string _torrentsPath;
        private readonly string _resumePath;
        public event EventHandler<UpdEventArgs> UpdEvent = delegate { };
        private long _cleanSize;

        public Cleaner( string torrentsPath, string resumePath )
        {
            this._torrentsPath = torrentsPath;
            this._resumePath = resumePath;
        }

        private static long GetFileSize( string file )
        {
            FileInfo fi = new FileInfo( file );
            return fi.Length;
        }

        public void Clean( bool moveToRecycle )
        {
            this._cleanSize = 0;
            UpdEventArgs args = new UpdEventArgs();
            BEncodedDictionary resume = BEncodedValue.Decode<BEncodedDictionary>( File.ReadAllBytes( this._resumePath ) );
            string[] torrentFilesList = Directory.GetFiles( this._torrentsPath, @"*.torrent",
                System.IO.SearchOption.TopDirectoryOnly );
            args.MaxProgress = torrentFilesList.Length;
            args.Progress = 0;
            args.DeletedCount = 0;
            this.UpdEvent( this, args );
            foreach ( string file in torrentFilesList )
            {
                string fileName = Path.GetFileName( file );
                if ( !resume.ContainsKey( new BEncodedString( fileName ) ) )
                {
                    RecycleOption ro = RecycleOption.DeletePermanently;
                    if ( moveToRecycle )
                    {
                        ro = RecycleOption.SendToRecycleBin;
                    }
                    this._cleanSize += GetFileSize( file );
                    FileSystem.DeleteFile( file, UIOption.OnlyErrorDialogs, ro );
                    args.Msg = strings.DeletingFile.f( fileName );
                    args.CleanSize = this._cleanSize;
                    args.DeletedCount++;
                }
                args.Progress++;
                this.UpdEvent( this, args );
            }
        }
    }
}
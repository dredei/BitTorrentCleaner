﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using MonoTorrent.BEncoding;
using Microsoft.VisualBasic.FileIO;
using ExtensionMethods;

namespace BitTorrentCleaner
{
    public class UpdEventArgs : EventArgs
    {
        public int progress { get; set; }
        public int maxProgress { get; set; }
        public int deletedCount { get; set; }
        public long cleanSize { get; set; }
        public string msg { get; set; }
    }

    class Cleaner
    {
        string torrentsPath;
        string resumePath;
        public event EventHandler<UpdEventArgs> updEvent = delegate { };
        long cleanSize = 0;

        public Cleaner( string torrentsPath, string resumePath )
        {
            this.torrentsPath = torrentsPath;
            this.resumePath = resumePath;
        }

        public long getFileSize( string file )
        {
            FileInfo fi = new FileInfo( file );
            return fi.Length;
        }

        public void Clean( bool moveToRecycle )
        {
            cleanSize = 0;
            UpdEventArgs args = new UpdEventArgs();
            BEncodedDictionary resume;
            resume = BEncodedValue.Decode<BEncodedDictionary>( File.ReadAllBytes( this.resumePath ) );
            string[] torrentFilesList = Directory.GetFiles( this.torrentsPath, @"*.torrent", System.IO.SearchOption.TopDirectoryOnly );
            args.maxProgress = torrentFilesList.Length;
            args.progress = 0;
            args.deletedCount = 0;
            updEvent( this, args );
            for ( int i = 0; i < torrentFilesList.Length; i++ )
            {
                string fileName = Path.GetFileName( torrentFilesList[ i ] );
                if ( !resume.ContainsKey( new BEncodedString( fileName ) ) )
                {
                    RecycleOption ro = RecycleOption.DeletePermanently;
                    if ( moveToRecycle )
                    {
                        ro = RecycleOption.SendToRecycleBin;
                    }
                    cleanSize += getFileSize( torrentFilesList[ i ] );
                    FileSystem.DeleteFile( torrentFilesList[ i ], UIOption.OnlyErrorDialogs, ro );
                    args.msg = strings.DeletingFile.f( fileName );                    
                    args.cleanSize = cleanSize;
                    args.deletedCount++;
                }
                args.progress++;
                updEvent( this, args );
            }
        }
    }
}

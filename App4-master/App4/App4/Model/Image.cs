using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace App4.Model
{
    class Image
    {

        int id;
        string fileName;
        string mimeType;
        byte[] content;

        
        //public ImageSource ImageSource { get; set; }

        public Image() { }
        [PrimaryKey, AutoIncrement]
        public int Id { get => id; set => id = value; }

        public string FileName { get => fileName; set => fileName = value; }
        public string MimeType { get => mimeType; set => mimeType = value; }
        public byte[] Content { get => content; set => content = value; }
    }
}

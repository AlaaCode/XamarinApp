using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace App4.Model
{
    class ImageWithSource : Image
    {
        Xamarin.Forms.ImageSource imageSource;
        public ImageWithSource(Image image)
        {
            this.Content = image.Content;
            this.FileName = image.FileName;
            this.Id = image.Id;
            this.MimeType = image.MimeType;
            
        }

        public ImageSource ImageSource { get => imageSource; set => imageSource = value; }
    }
}

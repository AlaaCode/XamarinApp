using System;
using System.Collections.Generic;
using System.Text;

namespace App4.Model
{
    interface IImageOperation
    {
        int CreateImage(Image image);
        Image ReadImage(int id);
        List<Image> ReadImages();
        int UpdateImage(Image image);
        int DeleteImage(Image image);
    }
}

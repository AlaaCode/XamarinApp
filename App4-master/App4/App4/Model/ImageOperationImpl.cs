using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace App4.Model
{
    class ImageOperationImpl: IImageOperation
    {
        SQLite.SQLiteConnection database;
        public ImageOperationImpl()
        {
            throw new NotImplementedException();
        }
        public ImageOperationImpl(SQLite.SQLiteConnection database)
        {
            this.database = database;
        }
        public int CreateImage(Image image)
        {
            //database.CreateTable<Image>();

            return database.Insert(image);
        }
        public Image ReadImage(int id)
        {
            //database.CreateTable<Image>();
            return (Image)database.Find<Image>(id);
        }
        public List<Image> ReadImages()
        {
            return database.Table< App4.Model.Image> ().ToList();
        }

        public int DeleteImage(Image image)
        {
            return database.Delete(image);
        }

        public int UpdateImage(Image image)
        {
            Image i = (Image)database.Find<Image>(image.Id);
            int id = image.Id;
            i = image;
            i.Id = id;
            return database.Update(i);

        }
        public int CreateImageFromPath(string path, string name)
        {
            Image image = new Image();
            image.FileName = name;
            try
            {
                image.Content = File.ReadAllBytes(path);
                Console.WriteLine("*********************************************"+image.Content.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return CreateImage(image);
        }
        public string ReadImageToPath(Image image, string path)
        {
            try
            {
                if (image.Content != null)
                {
                    File.WriteAllBytes(path, image.Content);
                }
                else
                {
                    Console.WriteLine("Binary data not read");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return path;
        }
    public ImageSource CreateSource(object value)
        {
            ImageSource retSource = null;
            if (value != null)
            {
                byte[] imageAsBytes = (byte[])value;
                retSource = ImageSource.FromStream(() => new MemoryStream(imageAsBytes));
            }
            return retSource;
        }
}
}

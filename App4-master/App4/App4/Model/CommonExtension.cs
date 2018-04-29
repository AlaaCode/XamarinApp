using PCLStorage;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App4.Model
{
    public static class CommonExtension
    {
        private static IFolder StorageData=FileSystem.Current.LocalStorage;

        /// <summary>
        /// Covert byte array to Ifile
        /// </summary>
        /// <param name="byteArray"></param>
        /// <param name="fileNameEx"></param>
        /// <returns></returns>
        public async static Task<IFile> AsIFileAsync(this byte[] byteArray, string fileNameEx)
        {
            IFile file = await StorageData.CreateFileAsync(fileNameEx, CreationCollisionOption.ReplaceExisting);
            using (var fileHandler = await file.OpenAsync(FileAccess.ReadAndWrite))
            {
                byte[] dataBuffer = byteArray;
                await fileHandler.WriteAsync(dataBuffer, 0, dataBuffer.Length);
            }
            return file;
        }
        /// <summary>
        /// Covert byte array to imagesource
        /// </summary>
        /// <param name="byteArray"></param>
        /// <returns></returns>
        public static ImageSource AsImageSource(this byte[] byteArray)
        {
            ImageSource retSource = null;
            if (byteArray != null)
            {
                byte[] imageAsBytes = byteArray;
                retSource = ImageSource.FromStream(() => new System.IO.MemoryStream(imageAsBytes));
            }
            return retSource;
        }
        /// <summary>
        /// Covert IFile to byte array
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public async static Task<byte[]> AsByteArrayAsync(this IFile file)
        {
            IFile Ifile = file;
            byte[] fileBytes = null;
            var stream = await Ifile.OpenAsync(PCLStorage.FileAccess.ReadAndWrite);
            using (var memoryStream = new System.IO.MemoryStream())
            {
                stream.CopyTo(memoryStream);
                stream.Dispose();
                fileBytes = memoryStream.ToArray();
            }
            return fileBytes;
        }
        /// <summary>
        /// Convert stream to byte array
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="fileNameEx"></param>
        /// <returns></returns>
        public async static Task<IFile> AsIFileAsync(this System.IO.Stream stream, string fileNameEx)
        {
            var byteArray = ReadFully(stream);
            IFile file = await StorageData.CreateFileAsync(fileNameEx, CreationCollisionOption.ReplaceExisting);
            using (var fileHandler = await file.OpenAsync(FileAccess.ReadAndWrite))
            {
                byte[] dataBuffer = byteArray;
                await fileHandler.WriteAsync(dataBuffer, 0, dataBuffer.Length);
            }
            return file;
        }
        /// <summary>
        /// type is a name of class in current assembly
        /// </summary>
        /// <param name="pathDot"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static System.IO.Stream GetResourceStreamAsync(string fullPathFileNameEmbeddedResource, Type type)
        {
            var assembly = type.GetTypeInfo().Assembly;
            System.IO.Stream stream = assembly.GetManifestResourceStream(fullPathFileNameEmbeddedResource);
            return stream;
        }
        public static byte[] ReadFully(System.IO.Stream input)
        {
            byte[] buffer = new byte[16 * 1024];
            using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();
            }
        }
    }
}

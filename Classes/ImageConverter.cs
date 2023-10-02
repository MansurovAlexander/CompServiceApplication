using System.Collections;
using System.Drawing;
using System.Drawing.Imaging;
using static System.Net.Mime.MediaTypeNames;

namespace CompServiceApplication.Classes
{
    public static class ImageConverter
    {
        public static byte[] ImagesToByte(IFormFile image)
        {
            using var fileStream = image.OpenReadStream();
            byte[] bytes = new byte[image.Length];
            fileStream.Read(bytes, 0, (int)image.Length);
            return bytes;
            //return new BinaryReader(image.OpenReadStream()).ReadBytes((int)image.Length);
        }
        public static string ByteToImage(byte[] byteArray, string imageExt)
        {
            var b64String = Convert.ToBase64String(byteArray);
            return "data:"+ imageExt + ";base64," + b64String;
        }
    }
}

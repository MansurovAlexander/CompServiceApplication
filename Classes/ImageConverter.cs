using System.Collections;
using System.Drawing;
using System.Drawing.Imaging;

namespace CompServiceApplication.Classes
{
    public static class ImageConverter
    {
        public static List<byte[]> ImagesToByte(IFormFileCollection images)
        {
            List<byte[]> result = new List<byte[]>();
            foreach (var image in images)
            {
                var imagesToDB = new BinaryReader(image.OpenReadStream()).ReadBytes((int)image.Length);
                result.Add(imagesToDB);
            }
            return result;
        }
        public static string ByteToImage(byte[] byteArray)
        {
            string? imageExt="";
            using (MemoryStream stream = new MemoryStream(byteArray))
            {
                System.Drawing.Image image = Image.FromStream(stream);
                imageExt=ImageCodecInfo.GetImageEncoders().First(codec => codec.FormatID == image.RawFormat.Guid).MimeType;
            }
            var b64String = Convert.ToBase64String(byteArray);
            return "data:"+ imageExt + ";base64," + b64String;
        }
    }
}

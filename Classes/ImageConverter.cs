using System.Collections;

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
        public static IFormFile ByteToImage(byte[] byteArray)
        {
            var fileName = DateTime.UtcNow.ToString();
            var stream = new MemoryStream(byteArray);
            return new FormFile(stream, 0, byteArray.Length, "Condition", fileName);
        }
    }
}

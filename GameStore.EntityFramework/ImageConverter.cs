using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace GameStore.EntityFramework
{
    public static class ImageConverter
    {
        public static byte[] Convert(Image image)
        {
            using (var stream = new MemoryStream())
            {
                image.Save(stream, ImageFormat.Gif);
                return stream.ToArray();
            }
        }
        public static Image Convert(byte[] imageArray)
        {
            using (var stream = new MemoryStream(imageArray))
            {
                Image returnImage = Image.FromStream(stream);
                return returnImage;
            }
        }

        public static String FormatToString(ImageFormat format)
        {
            if (ImageFormat.Jpeg.Equals(format))
                return "jpeg";
            else if (ImageFormat.Png.Equals(format))
                return "png";
            else if (ImageFormat.Gif.Equals(format))
                return "gif";
            else
                return null;
        }
    }
}

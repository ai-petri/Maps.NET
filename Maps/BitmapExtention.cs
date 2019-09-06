using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using Encoder = System.Drawing.Imaging.Encoder;

namespace Maps
{

   public static class BitmapExtention
    {

        public static BitmapImage ToBitmapImage(this Bitmap bitmap)
        {
            using (MemoryStream memory = new MemoryStream())
            {
                bitmap.Save(memory, ImageFormat.Bmp);
                memory.Position = 0;
                BitmapImage bitmapimage = new BitmapImage();
                bitmapimage.BeginInit();
                bitmapimage.StreamSource = memory;
                bitmapimage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapimage.EndInit();

                return bitmapimage;
            }
        }

        public static void FillRectangle(this Bitmap bitmap, int x, int y, int width, int height, Color color)
        {
            for (int i = x; i < x + width; i++)
            {
                for (int j = y; j < y + height; j++)
                {
                    bitmap.SetPixel(i, j, color);
                }
            }
        }

        public static void StrokeRectangle(this Bitmap bitmap, int x, int y, int width, int height, int thickness, Color color)
        {
            FillRectangle(bitmap, x, y, width, thickness, color); // верх

            FillRectangle(bitmap, x, y, thickness, height, color); // лево

            FillRectangle(bitmap, x + (width - thickness), y, thickness, height, color); // право

            FillRectangle(bitmap, x, y + (height - thickness), width, thickness, color); // низ

        }

        public static void FillCircle(this Bitmap bitmap, int x, int y, int R, Color color)
        {
            for (int i = Math.Max(0, x - R); i < Math.Min(bitmap.Width, x + R); i++)
            {
                for (int j = Math.Max(0, y - R); j < Math.Min(bitmap.Height, y + R); j++)
                {
                    double rr = ((i - x) * (i - x) + (j - y) * (j - y));

                    if (rr < R * R)
                    {
                        bitmap.SetPixel(i, j, color);
                    }
                }
            }
        }


        public static void SaveAsJpeg(this Bitmap bitmap, string filename)
        {
            ImageCodecInfo jpgEncoder = null;
            foreach (var c in ImageCodecInfo.GetImageEncoders())
            {
                if (c.FormatID == ImageFormat.Jpeg.Guid)
                {
                    jpgEncoder = c;
                }
            }

            EncoderParameters parameters = new EncoderParameters(1);

            parameters.Param[0] = new EncoderParameter(Encoder.Quality, 100L);

            bitmap.Save(filename, jpgEncoder, parameters);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnsafeImageProcessing
{
    public static class ImageProcessor
    {

        /// <summary>
        /// Locks Image so we can work with it
        /// </summary>
        /// <param name="Image"></param>
        /// <param name="Write"></param>
        /// <returns></returns>
        public static BitmapData LockImage(Bitmap Image, bool Write)
        {
            if (Write)
                return Image.LockBits(new Rectangle(0, 0, Image.Width, Image.Height)
                    , ImageLockMode.ReadWrite, Image.PixelFormat);
            else
                return Image.LockBits(new Rectangle(0, 0, Image.Width, Image.Height)
               , ImageLockMode.ReadOnly, Image.PixelFormat);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static int GetPixelSize(BitmapData data)
        {
            if (data.PixelFormat == PixelFormat.Format24bppRgb)
                return 3;
            else if (data.PixelFormat == PixelFormat.Format32bppArgb
               || data.PixelFormat == PixelFormat.Format32bppPArgb
               || data.PixelFormat == PixelFormat.Format32bppRgb)
                return 4;
            return 0;
        }


        /// <summary>
        /// Gets the pixels color using pointers
        /// </summary>
        /// <param name="data"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="PixelSizeInBytes"></param>
        /// <returns></returns>
        public static unsafe Color GetPixelUnsafe(BitmapData data, int x, int y, int PixelSizeInBytes)
        {
            try
            {
                byte* DataPointer = (byte*)data.Scan0;
                DataPointer = DataPointer + (y * data.Stride) + (x * PixelSizeInBytes);
                if (PixelSizeInBytes == 3)
                    return Color.FromArgb(DataPointer[2], DataPointer[1], DataPointer[0]);

                return Color.FromArgb(DataPointer[3], DataPointer[2], DataPointer[1], DataPointer[0]);

            }
            catch { throw; }
        }


        /// <summary>
        /// Sets the pixels colors using pointers
        /// </summary>
        /// <param name="data"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="PixelColor"></param>
        /// <param name="PixelSizeInBytes"></param>
        public static unsafe void SetPixelUnsafe(BitmapData data, int x, int y, Color PixelColor, int PixelSizeInBytes)
        {
            try
            {
                byte* DataPointer = (byte*)data.Scan0;
                DataPointer = DataPointer + (y * data.Stride) + (x * PixelSizeInBytes);

                if(PixelSizeInBytes == 3)
                {
                    DataPointer[2] = PixelColor.R;
                    DataPointer[1] = PixelColor.G;
                    DataPointer[0] = PixelColor.B;

                    return;
                }
                DataPointer[3] = PixelColor.A;
                DataPointer[2] = PixelColor.R;
                DataPointer[1] = PixelColor.G;
                DataPointer[0] = PixelColor.B;
            }
            catch { throw; }
        }

        /// <summary>
        /// Unlocks Bitmap object
        /// </summary>
        /// <param name="Image"></param>
        /// <param name="ImageData"></param>
        public static void UnlockImage(Bitmap Image, BitmapData ImageData)
        {
            Image.UnlockBits(ImageData);

        }

    }
}

using ImageDiff;
//compile with: /unsafe
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using UnsafeImageProcessing;

namespace ImageCompareGui
{
    public class WorkPerformedArgs : EventArgs
    {
        public string Data { get; set; }
    }
    public class ImageComparer
    {


        //Declaring delegat/event
        public event EventHandler<WorkPerformedArgs> WorkPerformed;

        //EventFormat Call this elsewhere to raise an event
        protected virtual void OnWorkPerformed(string data)
        {
            WorkPerformed?.Invoke(this, new WorkPerformedArgs() { Data = data });
        }
        public ImageComparer()
        {

        }

        public void CompareImages(BitmapComparer comparer, FileInfo baseline, FileInfo runtime, string saveDirectory)
        {
            using (Bitmap baselineBM = new Bitmap(baseline.FullName))
            {
                using (Bitmap runtimeBM = new Bitmap(runtime.FullName))
                {
                    if (UnsafeCompare(baselineBM, runtimeBM, baseline.Name) > 0)
                    {
                        string newSave = String.Format(saveDirectory + baseline.Name);
                        using (Bitmap diffBM = comparer.Compare(baselineBM, runtimeBM))
                        {
                            Bitmap[] mergeBMs = new Bitmap[] { baselineBM, diffBM };
                            using (Bitmap mergedBM = MergeImages(mergeBMs))
                                mergedBM.Save(newSave);
                        }
                    }
                }
            }
        }


        /// <summary>
        /// Stitches Images side by side
        /// </summary>
        /// <param name="images"></param>
        /// <returns></returns>
        public Bitmap MergeImages(IEnumerable<Bitmap> images)
        {
            var enumerable = images as IList<Bitmap> ?? images.ToList();

            var width = 0;
            var height = 0;

            foreach (var image in enumerable)
            {
                width += image.Width;
                height = image.Height > height
                    ? image.Height
                    : height;
            }

            var bitmap = new Bitmap(width, height);
            using (var g = Graphics.FromImage(bitmap))
            {
                var localWidth = 0;
                foreach (var image in enumerable)
                {
                    g.DrawImage(image, localWidth, 0);
                    localWidth += image.Width;
                    localWidth += 10; //Adds 10px of space between images
                }
            }
            return bitmap;
        }

        //Code to compare images
        public double CompareBitMaps(Bitmap img1, Bitmap img2, string fileName)
        {
            OnWorkPerformed(String.Format("Comparing image {0}...", fileName));
            if (img1.Size != img2.Size)
            {
                return 100;
            }

            float diff = 0;

            for (int y = 0; y < img1.Height; y++)
            {
                for (int x = 0; x < img1.Width; x++)
                {

                    diff += (float)Math.Abs(img1.GetPixel(x, y).R - img2.GetPixel(x, y).R) / 255;
                    diff += (float)Math.Abs(img1.GetPixel(x, y).G - img2.GetPixel(x, y).G) / 255;
                    diff += (float)Math.Abs(img1.GetPixel(x, y).B - img2.GetPixel(x, y).B) / 255;
                }
            }
            diff = diff * 100 / (img1.Width * img1.Height * 3);
            OnWorkPerformed(String.Format("\tdiff: {0} %", Math.Round(diff, 2)));
            return Math.Round(diff, 2);
        }

        unsafe public double UnsafeCompare(Bitmap img1, Bitmap img2, string fileName)
        {
            OnWorkPerformed(String.Format("Comparing image {0}...", fileName));
            if (img1.Size != img2.Size)
            {
                return 100;
            }

            float diff = 0;

            BitmapData img1Data = ImageProcessor.LockImage(img1, false);
            BitmapData img2Data = ImageProcessor.LockImage(img2, false);
            int img1PixelSize = ImageProcessor.GetPixelSize(img1Data);
            int img2PixelSize = ImageProcessor.GetPixelSize(img2Data);

            for (int y = 0; y < img1.Height; y++)
            {
                for (int x = 0; x < img1.Width; x++)
                {
                    Color color1 = ImageProcessor.GetPixelUnsafe(img1Data, x, y, img1PixelSize);
                    Color color2 = ImageProcessor.GetPixelUnsafe(img2Data, x, y, img2PixelSize);

                    diff += (float)Math.Abs(color1.R - color2.R) / 255;
                    diff += (float)Math.Abs(color1.G - color2.G) / 255;
                    diff += (float)Math.Abs(color1.B - color2.B) / 255;
                }
            }

            diff = diff * 100 / (img1.Width * img1.Height * 3);
            OnWorkPerformed(String.Format("\tdiff: {0} %", Math.Round(diff, 2)));

            ImageProcessor.UnlockImage(img1, img1Data);
            ImageProcessor.UnlockImage(img2, img2Data);

            return Math.Round(diff, 2);
        }


        //Returns all jpgs in a dir
        public List<FileInfo> GetImages(string path)
        {

            OnWorkPerformed("Loading Images " + path);
            DirectoryInfo dir = new DirectoryInfo(path);
            if (dir.Exists)
                return dir.GetFiles("*.jpg").ToList();

            else
                return new List<FileInfo>();
        }

        public List<string> FilterMatches(List<FileInfo> one, List<FileInfo> two)
        {
            List<FileInfo> matches = one.Intersect(two, new NameComparer()).ToList();
            OnWorkPerformed(String.Format("Matches found {0}", matches.Count));

            return matches.Select(x => x.Name).ToList();
            //List<FileInfo> matched1 = new List<FileInfo>();
            //List<FileInfo> matched2 = new List<FileInfo>();
            //for (int i = 0; i < one.Count; i++)
            //{
            //    string name = one[i].Name;
            //    if (two.Exists(x => x.Name == one[i].Name))
            //    {
            //        matched1.Add(one[i]);
            //        OnWorkPerformed(String.Format("Original {0} has a match. Added to compare list.", name));
            //    }
            //    else
            //        OnWorkPerformed(String.Format("Original {0} does not have a match", name));

            //}
            //for (int i = 0; i < two.Count; i++)
            //{
            //    string name = two[i].Name;
            //    if (one.Exists(x => x.Name == two[i].Name))
            //    {
            //        matched2.Add(two[i]);
            //        OnWorkPerformed(String.Format("Comparing {0} has a match. Added to compare list.", name));
            //    }
            //    else
            //        OnWorkPerformed(String.Format("Original {0} does not have a match", name));

            //}
            //return Tuple.Create(matched1, matched2);

        }

    }
    public class NameComparer : IEqualityComparer<FileInfo>
    {
        public bool Equals(FileInfo x, FileInfo y)
        {
            if (x == y)
            {
                return true;
            }

            if (x == null || y == null)
            {
                return false;
            }

            return string.Equals(x.Name, y.Name, StringComparison.OrdinalIgnoreCase);
        }

        public int GetHashCode(FileInfo obj)
        {
            return obj.Name.GetHashCode();
        }
    }

}

using System.IO;


namespace ImageCompareGui
{
    public class Logging
    {
        public FileInfo Log { get; set; }

        public Logging(string directory)
        {
            string path = directory + "Log.txt";
            File.Create(path).Close();
            Log = new FileInfo(path);
        }


        public void OnWorkPerformed(object source, WorkPerformedArgs args)
        {
            using (StreamWriter writer = new StreamWriter(Log.FullName, true))
                writer.WriteLine(args.Data);
        }
    }
}

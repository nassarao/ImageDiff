using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageCompareGui
{
    public class FormData
    {
        public string BaselineDirectory { get; set; }
        public string RuntimeDirectory { get; set; }
        public string Log { get; set; }
        public string ResultsDirectory { get; set; }

        public FormData(string Bdir, string Rdir)
        {
            BaselineDirectory = Bdir;
            RuntimeDirectory = Rdir;
            ResultsDirectory = Rdir + "\\Results\\";
            Directory.CreateDirectory(ResultsDirectory);
           
        }
    }
}

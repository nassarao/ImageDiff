using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageCompareGui
{
    public partial class ImageViewerForm : Form
    {

        public FormData data { get; set; }
        private List<FileInfo> images { get; set; }
        private int currentIndex = 0;
        private int maxIndex;
        public ImageViewerForm(List<FileInfo> images)
        {
            InitializeComponent();
            this.images = images;
            InitializeTxtFileName();
            maxIndex = this.images.Count - 1;
            lblMax.Text = maxIndex.ToString();
            picBox.SizeMode = PictureBoxSizeMode.StretchImage;
            ImageChange();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (currentIndex < maxIndex)
            {
                currentIndex++;
                ImageChange();
            }
            else
            {
                MessageBox.Show("This is the last image");
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (currentIndex > 0)
            {
                currentIndex--;
                ImageChange();
            }
            else
            {
                MessageBox.Show("This is the first image");
            }
        }

        private void btnCopyToBaseline_Click(object sender, EventArgs e)
        {
            string imgName = images[currentIndex].Name;
            string baselineLog = data.BaselineDirectory + "\\Baseline_Log.txt";

            try
            {
                string runtimeImage = data.RuntimeDirectory + "\\" + imgName;
                string baselineLocation = data.BaselineDirectory + "\\" + imgName;
                File.Copy(runtimeImage, baselineLocation, true);
                string logMessage = String.Format("{0} \r\n\t {1} copied to \r\n\t\t {2} \r\n",
                    DateTime.Now, runtimeImage, baselineLocation);
                //if (File.Exists(baselineLog))
                using (StreamWriter writer = new StreamWriter(baselineLog, true))
                    writer.WriteLine(logMessage);

                btnNext.PerformClick();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void baselineLocationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImageViewerCopyLocationForm form = new ImageViewerCopyLocationForm(data.BaselineDirectory);
            if (form.ShowDialog() == DialogResult.OK)
                data.BaselineDirectory = form.CopyPath;
        }

        private void ImageChange()
        {
            picBox.ImageLocation = images[currentIndex].FullName;
            lblCurrentIndex.Text = currentIndex.ToString();
            txtFileName.Text = images[currentIndex].Name;
        }

        private void InitializeTxtFileName()
        {
            txtFileName.ReadOnly = true;
            txtFileName.BorderStyle = 0;
            txtFileName.BackColor = this.BackColor;
            txtFileName.TabStop = false;
            txtFileName.TextAlign = HorizontalAlignment.Center;

        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageCompareGui
{
    public partial class ImageViewerCopyLocationForm : Form
    {
        public string CopyPath { get; set; }
        public ImageViewerCopyLocationForm(string copyPath)
        {
            InitializeComponent();
            txtCopyLocation.Text = copyPath;
            CopyPath = copyPath;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            CopyPath = txtCopyLocation.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnFBD_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (Directory.Exists(CopyPath))
                fbd.SelectedPath = CopyPath;
            else
                fbd.SelectedPath = ConfigurationManager.AppSettings["BaselineDirectory"];
            if (fbd.ShowDialog() == DialogResult.OK)
                txtCopyLocation.Text = fbd.SelectedPath;
        }
    }
}

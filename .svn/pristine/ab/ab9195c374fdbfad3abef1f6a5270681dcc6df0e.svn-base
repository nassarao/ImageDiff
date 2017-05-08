using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageCompareGui
{
    public partial class EditDefaultValues : Form
    {
        public EditDefaultValues()
        {
            InitializeComponent();
            txtBaselinePath.Text = ConfigurationManager.AppSettings["BaselineDirectory"];
            txtRuntimePath.Text = ConfigurationManager.AppSettings["RuntimeDirectory"];
            txtPythonPath.Text = ConfigurationManager.AppSettings["PythonPath"];

        }

        private void btnPythonPath_Click(object sender, EventArgs e)
        {
            OpenFileDialog fbd = new OpenFileDialog();
            fbd.FileName = ConfigurationManager.AppSettings["PythonPath"];
            if (fbd.ShowDialog() == DialogResult.OK)
                txtPythonPath.Text = fbd.FileName;
        }

        private void btnBaselinePath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.SelectedPath = ConfigurationManager.AppSettings["BaselineDirectory"];
            if (fbd.ShowDialog() == DialogResult.OK)
                txtBaselinePath.Text = fbd.SelectedPath;
        }

        private void btnRuntimePath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.SelectedPath = ConfigurationManager.AppSettings["RuntimeDirectory"];
            if (fbd.ShowDialog() == DialogResult.OK)
                txtRuntimePath.Text = fbd.SelectedPath;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            ConfigurationManager.AppSettings["BaselineDirectory"] = txtBaselinePath.Text;
            ConfigurationManager.AppSettings["RuntimeDirectory"] = txtRuntimePath.Text;
            ConfigurationManager.AppSettings["PythonPath"] = txtPythonPath.Text;
            this.Close();
        }
    }
}

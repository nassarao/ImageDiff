namespace ImageCompareGui
{
    partial class ImageViewerCopyLocationForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnOk = new System.Windows.Forms.Button();
            this.btnFBD = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCopyLocation = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(209, 56);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnFBD
            // 
            this.btnFBD.Location = new System.Drawing.Point(443, 12);
            this.btnFBD.Name = "btnFBD";
            this.btnFBD.Size = new System.Drawing.Size(41, 23);
            this.btnFBD.TabIndex = 1;
            this.btnFBD.Text = "...";
            this.btnFBD.UseVisualStyleBackColor = true;
            this.btnFBD.Click += new System.EventHandler(this.btnFBD_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(217, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Edit where to Copy these Photos:";
            // 
            // txtCopyLocation
            // 
            this.txtCopyLocation.Location = new System.Drawing.Point(235, 12);
            this.txtCopyLocation.Name = "txtCopyLocation";
            this.txtCopyLocation.Size = new System.Drawing.Size(202, 22);
            this.txtCopyLocation.TabIndex = 3;
            this.txtCopyLocation.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // ImageViewerCopyLocationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(496, 91);
            this.Controls.Add(this.txtCopyLocation);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnFBD);
            this.Controls.Add(this.btnOk);
            this.Name = "ImageViewerCopyLocationForm";
            this.Text = "ImageViewerCopyLocationForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnFBD;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCopyLocation;
    }
}
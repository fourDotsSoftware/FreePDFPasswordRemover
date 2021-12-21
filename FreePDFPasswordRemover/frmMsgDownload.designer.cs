namespace FreePDFPasswordRemover
{
    partial class frmMsgDownload
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMsgDownload));
            this.label1 = new System.Windows.Forms.Label();
            this.urlLinkLabel1 = new FreePDFPasswordRemover.URLLinkLabel();
            this.chkDoNotShowAgain = new System.Windows.Forms.CheckBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // urlLinkLabel1
            // 
            resources.ApplyResources(this.urlLinkLabel1, "urlLinkLabel1");
            this.urlLinkLabel1.BackColor = System.Drawing.Color.Transparent;
            this.urlLinkLabel1.Name = "urlLinkLabel1";
            this.urlLinkLabel1.TabStop = true;
            // 
            // chkDoNotShowAgain
            // 
            resources.ApplyResources(this.chkDoNotShowAgain, "chkDoNotShowAgain");
            this.chkDoNotShowAgain.BackColor = System.Drawing.Color.Transparent;
            this.chkDoNotShowAgain.Name = "chkDoNotShowAgain";
            this.chkDoNotShowAgain.UseVisualStyleBackColor = false;
            // 
            // btnOK
            // 
            this.btnOK.Image = global::FreePDFPasswordRemover.Properties.Resources.check;
            resources.ApplyResources(this.btnOK, "btnOK");
            this.btnOK.Name = "btnOK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // frmMsgDownload
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.chkDoNotShowAgain);
            this.Controls.Add(this.urlLinkLabel1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMsgDownload";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private URLLinkLabel urlLinkLabel1;
        private System.Windows.Forms.CheckBox chkDoNotShowAgain;
        private System.Windows.Forms.Button btnOK;
    }
}

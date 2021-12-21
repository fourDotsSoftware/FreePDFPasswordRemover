using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FreePDFPasswordRemover
{
    public partial class frmMsgDownload : FreePDFPasswordRemover.CustomForm
    {
        public frmMsgDownload()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (chkDoNotShowAgain.Checked)
            {
                Properties.Settings.Default.MsgDownloadPDFPasswordCrackerExpert = false;
            }

            this.DialogResult = DialogResult.OK;
        }
    }

    public class URLLinkLabel : System.Windows.Forms.LinkLabel
    {
        public URLLinkLabel()
            : base()
        {

        }

        protected override void OnClick(EventArgs e)
        {
            System.Diagnostics.Process.Start(this.Text);
        }
    }
}

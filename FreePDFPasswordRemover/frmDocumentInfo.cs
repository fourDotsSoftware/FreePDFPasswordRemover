using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FreePDFPasswordRemover
{
    public partial class frmDocumentInfo : FreePDFPasswordRemover.CustomForm
    {
        public static frmDocumentInfo Instance = new frmDocumentInfo();
                
        public frmDocumentInfo()
        {
            InitializeComponent();
            //Instance = this;
        }


        private void btnExit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void frmDocumentInfo_Load(object sender, EventArgs e)
        {
            txtAuthor.Text = EncryptHelper.Author;
            txtKeywords.Text = EncryptHelper.Keywords;
            txtSubject.Text = EncryptHelper.Subject;
            txtTitle.Text = EncryptHelper.Title;
            txtCreator.Text = EncryptHelper.Creator;

            dpCreationDate.Value = EncryptHelper.CreationDate;
            dpModificationDate.Value = EncryptHelper.ModificationDate;
        }

        private void chkTitle_CheckedChanged(object sender, EventArgs e)
        {
            txtTitle.Enabled = chkTitle.Checked;
        }

        private void chkAuthor_CheckedChanged(object sender, EventArgs e)
        {
            txtAuthor.Enabled = chkAuthor.Checked;
        }

        private void chkSubject_CheckedChanged(object sender, EventArgs e)
        {
            txtSubject.Enabled = chkSubject.Checked;
        }

        private void chkKeywords_CheckedChanged(object sender, EventArgs e)
        {
            txtKeywords.Enabled = chkKeywords.Checked;
        }

        private void chkCreator_CheckedChanged(object sender, EventArgs e)
        {
            txtCreator.Enabled = chkCreator.Checked;
        }

        private void chkCreationDate_CheckedChanged(object sender, EventArgs e)
        {
            dpCreationDate.Enabled = chkCreationDate.Checked;
            //tpCreationDate.Enabled = tpCreationDate.Checked;
        }

        private void chkModificationDate_CheckedChanged(object sender, EventArgs e)
        {
            dpModificationDate.Enabled = chkModificationDate.Checked;
            //tpModificationDate.Enabled = chkModificationDate.Checked;
        }
    }
}


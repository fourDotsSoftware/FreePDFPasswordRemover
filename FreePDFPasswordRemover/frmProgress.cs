using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FreePDFPasswordRemover
{
    public partial class frmProgress : CustomForm
    {
        private static frmProgress _Instance = null;

        public static frmProgress Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new frmProgress();
                }

                return _Instance;
            }
            set
            {
                _Instance = value;
            }
        }

        public frmProgress()
        {
            InitializeComponent();
            Instance = this;
        }

        private delegate void HideFormDelegate();

        public void HideForm()
        {
            if (this.InvokeRequired)
            {
                this.Invoke((HideFormDelegate)HideForm, null);
            }
            else
            {
                this.Visible = false;
            }
        }

        private delegate void ShowFormDelegate();

        public void ShowForm()
        {
            if (this.InvokeRequired)
            {
                this.Invoke((ShowFormDelegate)ShowForm, null);
            }
            else
            {
                this.Visible = false;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            RemovePasswordsHelper.CANCELLED = true;
            frmMain.Instance.bwRemovePasswords.CancelAsync();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.DrawRectangle(Pens.Gray, new Rectangle(2, 2, this.Width - 4, this.Height - 4));
        }

    }
}


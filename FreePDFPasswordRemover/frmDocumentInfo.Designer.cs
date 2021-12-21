namespace FreePDFPasswordRemover
{
    partial class frmDocumentInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDocumentInfo));
            this.dpModificationDate = new System.Windows.Forms.DateTimePicker();
            this.dpCreationDate = new System.Windows.Forms.DateTimePicker();
            this.txtCreator = new System.Windows.Forms.TextBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.txtKeywords = new System.Windows.Forms.TextBox();
            this.txtSubject = new System.Windows.Forms.TextBox();
            this.txtAuthor = new System.Windows.Forms.TextBox();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.chkTitle = new System.Windows.Forms.CheckBox();
            this.chkAuthor = new System.Windows.Forms.CheckBox();
            this.chkSubject = new System.Windows.Forms.CheckBox();
            this.chkKeywords = new System.Windows.Forms.CheckBox();
            this.chkCreator = new System.Windows.Forms.CheckBox();
            this.chkCreationDate = new System.Windows.Forms.CheckBox();
            this.chkModificationDate = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // dpModificationDate
            // 
            resources.ApplyResources(this.dpModificationDate, "dpModificationDate");
            this.dpModificationDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dpModificationDate.Name = "dpModificationDate";
            // 
            // dpCreationDate
            // 
            resources.ApplyResources(this.dpCreationDate, "dpCreationDate");
            this.dpCreationDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dpCreationDate.Name = "dpCreationDate";
            // 
            // txtCreator
            // 
            resources.ApplyResources(this.txtCreator, "txtCreator");
            this.txtCreator.Name = "txtCreator";
            // 
            // btnExit
            // 
            resources.ApplyResources(this.btnExit, "btnExit");
            this.btnExit.Name = "btnExit";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnOK
            // 
            this.btnOK.Image = global::FreePDFPasswordRemover.Properties.Resources.check;
            resources.ApplyResources(this.btnOK, "btnOK");
            this.btnOK.Name = "btnOK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // txtKeywords
            // 
            resources.ApplyResources(this.txtKeywords, "txtKeywords");
            this.txtKeywords.Name = "txtKeywords";
            // 
            // txtSubject
            // 
            resources.ApplyResources(this.txtSubject, "txtSubject");
            this.txtSubject.Name = "txtSubject";
            // 
            // txtAuthor
            // 
            resources.ApplyResources(this.txtAuthor, "txtAuthor");
            this.txtAuthor.Name = "txtAuthor";
            // 
            // txtTitle
            // 
            resources.ApplyResources(this.txtTitle, "txtTitle");
            this.txtTitle.Name = "txtTitle";
            // 
            // chkTitle
            // 
            this.chkTitle.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.chkTitle, "chkTitle");
            this.chkTitle.Name = "chkTitle";
            this.chkTitle.UseVisualStyleBackColor = false;
            this.chkTitle.CheckedChanged += new System.EventHandler(this.chkTitle_CheckedChanged);
            // 
            // chkAuthor
            // 
            this.chkAuthor.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.chkAuthor, "chkAuthor");
            this.chkAuthor.Name = "chkAuthor";
            this.chkAuthor.UseVisualStyleBackColor = false;
            this.chkAuthor.CheckedChanged += new System.EventHandler(this.chkAuthor_CheckedChanged);
            // 
            // chkSubject
            // 
            this.chkSubject.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.chkSubject, "chkSubject");
            this.chkSubject.Name = "chkSubject";
            this.chkSubject.UseVisualStyleBackColor = false;
            this.chkSubject.CheckedChanged += new System.EventHandler(this.chkSubject_CheckedChanged);
            // 
            // chkKeywords
            // 
            this.chkKeywords.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.chkKeywords, "chkKeywords");
            this.chkKeywords.Name = "chkKeywords";
            this.chkKeywords.UseVisualStyleBackColor = false;
            this.chkKeywords.CheckedChanged += new System.EventHandler(this.chkKeywords_CheckedChanged);
            // 
            // chkCreator
            // 
            this.chkCreator.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.chkCreator, "chkCreator");
            this.chkCreator.Name = "chkCreator";
            this.chkCreator.UseVisualStyleBackColor = false;
            this.chkCreator.CheckedChanged += new System.EventHandler(this.chkCreator_CheckedChanged);
            // 
            // chkCreationDate
            // 
            this.chkCreationDate.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.chkCreationDate, "chkCreationDate");
            this.chkCreationDate.Name = "chkCreationDate";
            this.chkCreationDate.UseVisualStyleBackColor = false;
            this.chkCreationDate.CheckedChanged += new System.EventHandler(this.chkCreationDate_CheckedChanged);
            // 
            // chkModificationDate
            // 
            this.chkModificationDate.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.chkModificationDate, "chkModificationDate");
            this.chkModificationDate.Name = "chkModificationDate";
            this.chkModificationDate.UseVisualStyleBackColor = false;
            this.chkModificationDate.CheckedChanged += new System.EventHandler(this.chkModificationDate_CheckedChanged);
            // 
            // frmDocumentInfo
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.chkModificationDate);
            this.Controls.Add(this.chkCreationDate);
            this.Controls.Add(this.chkCreator);
            this.Controls.Add(this.chkKeywords);
            this.Controls.Add(this.chkSubject);
            this.Controls.Add(this.chkAuthor);
            this.Controls.Add(this.chkTitle);
            this.Controls.Add(this.dpModificationDate);
            this.Controls.Add(this.dpCreationDate);
            this.Controls.Add(this.txtCreator);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtKeywords);
            this.Controls.Add(this.txtSubject);
            this.Controls.Add(this.txtAuthor);
            this.Controls.Add(this.txtTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDocumentInfo";
            this.Load += new System.EventHandler(this.frmDocumentInfo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox txtKeywords;
        public System.Windows.Forms.TextBox txtSubject;
        public System.Windows.Forms.TextBox txtAuthor;
        public System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnOK;
        public System.Windows.Forms.TextBox txtCreator;
        public System.Windows.Forms.DateTimePicker dpCreationDate;
        public System.Windows.Forms.DateTimePicker dpModificationDate;
        public System.Windows.Forms.CheckBox chkTitle;
        public System.Windows.Forms.CheckBox chkAuthor;
        public System.Windows.Forms.CheckBox chkSubject;
        public System.Windows.Forms.CheckBox chkKeywords;
        public System.Windows.Forms.CheckBox chkCreator;
        public System.Windows.Forms.CheckBox chkCreationDate;
        public System.Windows.Forms.CheckBox chkModificationDate;
    }
}

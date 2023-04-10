namespace WinForms
{
    partial class AnnouncementForm
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
            lblTitle = new Label();
            tbTitle = new TextBox();
            lblDescription = new Label();
            tbDescription = new TextBox();
            lblPublishDate = new Label();
            btnSave = new Button();
            ckbImportant = new CheckBox();
            ckbSticky = new CheckBox();
            dtpPublishDate = new DateTimePicker();
            lblAuthor = new Label();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(12, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(32, 15);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Title:";
            // 
            // tbTitle
            // 
            tbTitle.Location = new Point(94, 6);
            tbTitle.Name = "tbTitle";
            tbTitle.Size = new Size(405, 23);
            tbTitle.TabIndex = 1;
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.Location = new Point(12, 38);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(70, 15);
            lblDescription.TabIndex = 2;
            lblDescription.Text = "Description:";
            // 
            // tbDescription
            // 
            tbDescription.Location = new Point(94, 35);
            tbDescription.Multiline = true;
            tbDescription.Name = "tbDescription";
            tbDescription.Size = new Size(405, 112);
            tbDescription.TabIndex = 3;
            // 
            // lblPublishDate
            // 
            lblPublishDate.AutoSize = true;
            lblPublishDate.Location = new Point(12, 159);
            lblPublishDate.Name = "lblPublishDate";
            lblPublishDate.Size = new Size(76, 15);
            lblPublishDate.TabIndex = 4;
            lblPublishDate.Text = "Publish Date:";
            // 
            // btnSave
            // 
            btnSave.Location = new Point(424, 180);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 6;
            btnSave.Text = "Save changes";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // ckbImportant
            // 
            ckbImportant.AutoSize = true;
            ckbImportant.Location = new Point(300, 155);
            ckbImportant.Name = "ckbImportant";
            ckbImportant.Size = new Size(79, 19);
            ckbImportant.TabIndex = 7;
            ckbImportant.Text = "Important";
            ckbImportant.UseVisualStyleBackColor = true;
            // 
            // ckbSticky
            // 
            ckbSticky.AutoSize = true;
            ckbSticky.Location = new Point(385, 155);
            ckbSticky.Name = "ckbSticky";
            ckbSticky.Size = new Size(78, 19);
            ckbSticky.TabIndex = 8;
            ckbSticky.Text = "Pin to top";
            ckbSticky.UseVisualStyleBackColor = true;
            // 
            // dtpPublishDate
            // 
            dtpPublishDate.Location = new Point(94, 153);
            dtpPublishDate.Name = "dtpPublishDate";
            dtpPublishDate.Size = new Size(200, 23);
            dtpPublishDate.TabIndex = 9;
            // 
            // lblAuthor
            // 
            lblAuthor.AutoSize = true;
            lblAuthor.Location = new Point(12, 184);
            lblAuthor.Name = "lblAuthor";
            lblAuthor.Size = new Size(70, 15);
            lblAuthor.TabIndex = 10;
            lblAuthor.Text = "Created by: ";
            // 
            // AnnouncementForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(511, 216);
            Controls.Add(lblAuthor);
            Controls.Add(dtpPublishDate);
            Controls.Add(ckbSticky);
            Controls.Add(ckbImportant);
            Controls.Add(btnSave);
            Controls.Add(lblPublishDate);
            Controls.Add(tbDescription);
            Controls.Add(lblDescription);
            Controls.Add(tbTitle);
            Controls.Add(lblTitle);
            Name = "AnnouncementForm";
            Text = "Announcement";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private TextBox tbTitle;
        private Label lblDescription;
        private TextBox tbDescription;
        private Label lblPublishDate;
        private Button btnSave;
        private CheckBox ckbImportant;
        private CheckBox ckbSticky;
        private DateTimePicker dtpPublishDate;
        private Label lblAuthor;
    }
}
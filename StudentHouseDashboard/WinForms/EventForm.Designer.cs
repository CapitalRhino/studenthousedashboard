namespace WinForms
{
    partial class EventForm
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
            dtpPublishDate = new DateTimePicker();
            lblAuthor = new Label();
            lblStart = new Label();
            dtpStartDate = new DateTimePicker();
            lblEnd = new Label();
            dtpEndDate = new DateTimePicker();
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
            lblPublishDate.Size = new Size(75, 15);
            lblPublishDate.TabIndex = 4;
            lblPublishDate.Text = "Publish date:";
            // 
            // btnSave
            // 
            btnSave.Location = new Point(424, 212);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 6;
            btnSave.Text = "Save changes";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // dtpPublishDate
            // 
            dtpPublishDate.CustomFormat = "dd-MM-yyyy hh:mm";
            dtpPublishDate.Format = DateTimePickerFormat.Custom;
            dtpPublishDate.Location = new Point(94, 153);
            dtpPublishDate.Name = "dtpPublishDate";
            dtpPublishDate.Size = new Size(141, 23);
            dtpPublishDate.TabIndex = 9;
            // 
            // lblAuthor
            // 
            lblAuthor.AutoSize = true;
            lblAuthor.Location = new Point(241, 159);
            lblAuthor.Name = "lblAuthor";
            lblAuthor.Size = new Size(70, 15);
            lblAuthor.TabIndex = 10;
            lblAuthor.Text = "Created by: ";
            // 
            // lblStart
            // 
            lblStart.AutoSize = true;
            lblStart.Location = new Point(12, 188);
            lblStart.Name = "lblStart";
            lblStart.Size = new Size(60, 15);
            lblStart.TabIndex = 11;
            lblStart.Text = "Start date:";
            // 
            // dtpStartDate
            // 
            dtpStartDate.CustomFormat = "dd-MM-yyyy hh:mm";
            dtpStartDate.Format = DateTimePickerFormat.Custom;
            dtpStartDate.Location = new Point(94, 182);
            dtpStartDate.Name = "dtpStartDate";
            dtpStartDate.Size = new Size(141, 23);
            dtpStartDate.TabIndex = 12;
            // 
            // lblEnd
            // 
            lblEnd.AutoSize = true;
            lblEnd.Location = new Point(241, 188);
            lblEnd.Name = "lblEnd";
            lblEnd.Size = new Size(56, 15);
            lblEnd.TabIndex = 13;
            lblEnd.Text = "End date:";
            // 
            // dtpEndDate
            // 
            dtpEndDate.CustomFormat = "dd-MM-yyyy hh:mm";
            dtpEndDate.Format = DateTimePickerFormat.Custom;
            dtpEndDate.Location = new Point(303, 183);
            dtpEndDate.Name = "dtpEndDate";
            dtpEndDate.Size = new Size(141, 23);
            dtpEndDate.TabIndex = 14;
            // 
            // EventForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(511, 246);
            Controls.Add(dtpEndDate);
            Controls.Add(lblEnd);
            Controls.Add(dtpStartDate);
            Controls.Add(lblStart);
            Controls.Add(lblAuthor);
            Controls.Add(dtpPublishDate);
            Controls.Add(btnSave);
            Controls.Add(lblPublishDate);
            Controls.Add(tbDescription);
            Controls.Add(lblDescription);
            Controls.Add(tbTitle);
            Controls.Add(lblTitle);
            Name = "EventForm";
            Text = "Event";
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
        private DateTimePicker dtpPublishDate;
        private Label lblAuthor;
        private Label lblStart;
        private DateTimePicker dtpStartDate;
        private Label lblEnd;
        private DateTimePicker dtpEndDate;
    }
}
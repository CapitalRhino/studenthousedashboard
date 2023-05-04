namespace WinForms
{
    partial class CommentForm
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
            btnCreateComment = new Button();
            btnDeleteComment = new Button();
            btnEditComment = new Button();
            btnViewComment = new Button();
            listBox1 = new ListBox();
            lblComments = new Label();
            lblAuthor = new Label();
            dtpPublishDate = new DateTimePicker();
            btnSave = new Button();
            lblPublishDate = new Label();
            tbDescription = new TextBox();
            lblDescription = new Label();
            tbTitle = new TextBox();
            lblTitle = new Label();
            SuspendLayout();
            // 
            // btnCreateComment
            // 
            btnCreateComment.Location = new Point(424, 358);
            btnCreateComment.Name = "btnCreateComment";
            btnCreateComment.Size = new Size(75, 23);
            btnCreateComment.TabIndex = 30;
            btnCreateComment.Text = "New";
            btnCreateComment.UseVisualStyleBackColor = true;
            btnCreateComment.Click += btnCreateComment_Click;
            // 
            // btnDeleteComment
            // 
            btnDeleteComment.Location = new Point(424, 329);
            btnDeleteComment.Name = "btnDeleteComment";
            btnDeleteComment.Size = new Size(75, 23);
            btnDeleteComment.TabIndex = 29;
            btnDeleteComment.Text = "Delete";
            btnDeleteComment.UseVisualStyleBackColor = true;
            btnDeleteComment.Click += btnDeleteComment_Click;
            // 
            // btnEditComment
            // 
            btnEditComment.Location = new Point(424, 300);
            btnEditComment.Name = "btnEditComment";
            btnEditComment.Size = new Size(75, 23);
            btnEditComment.TabIndex = 28;
            btnEditComment.Text = "Edit";
            btnEditComment.UseVisualStyleBackColor = true;
            btnEditComment.Click += btnEditComment_Click;
            // 
            // btnViewComment
            // 
            btnViewComment.Location = new Point(424, 271);
            btnViewComment.Name = "btnViewComment";
            btnViewComment.Size = new Size(75, 23);
            btnViewComment.TabIndex = 27;
            btnViewComment.Text = "View";
            btnViewComment.UseVisualStyleBackColor = true;
            btnViewComment.Click += btnViewComment_Click;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(12, 227);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(399, 154);
            listBox1.TabIndex = 26;
            // 
            // lblComments
            // 
            lblComments.AutoSize = true;
            lblComments.Location = new Point(12, 209);
            lblComments.Name = "lblComments";
            lblComments.Size = new Size(66, 15);
            lblComments.TabIndex = 25;
            lblComments.Text = "Comments";
            // 
            // lblAuthor
            // 
            lblAuthor.AutoSize = true;
            lblAuthor.Location = new Point(12, 184);
            lblAuthor.Name = "lblAuthor";
            lblAuthor.Size = new Size(70, 15);
            lblAuthor.TabIndex = 24;
            lblAuthor.Text = "Created by: ";
            // 
            // dtpPublishDate
            // 
            dtpPublishDate.Location = new Point(94, 153);
            dtpPublishDate.Name = "dtpPublishDate";
            dtpPublishDate.Size = new Size(200, 23);
            dtpPublishDate.TabIndex = 23;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(424, 180);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 22;
            btnSave.Text = "Save changes";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // lblPublishDate
            // 
            lblPublishDate.AutoSize = true;
            lblPublishDate.Location = new Point(12, 159);
            lblPublishDate.Name = "lblPublishDate";
            lblPublishDate.Size = new Size(76, 15);
            lblPublishDate.TabIndex = 21;
            lblPublishDate.Text = "Publish Date:";
            // 
            // tbDescription
            // 
            tbDescription.Location = new Point(94, 35);
            tbDescription.Multiline = true;
            tbDescription.Name = "tbDescription";
            tbDescription.Size = new Size(405, 112);
            tbDescription.TabIndex = 20;
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.Location = new Point(12, 38);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(70, 15);
            lblDescription.TabIndex = 19;
            lblDescription.Text = "Description:";
            // 
            // tbTitle
            // 
            tbTitle.Location = new Point(94, 6);
            tbTitle.Name = "tbTitle";
            tbTitle.Size = new Size(405, 23);
            tbTitle.TabIndex = 18;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(12, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(32, 15);
            lblTitle.TabIndex = 17;
            lblTitle.Text = "Title:";
            // 
            // CommentForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(517, 395);
            Controls.Add(btnCreateComment);
            Controls.Add(btnDeleteComment);
            Controls.Add(btnEditComment);
            Controls.Add(btnViewComment);
            Controls.Add(listBox1);
            Controls.Add(lblComments);
            Controls.Add(lblAuthor);
            Controls.Add(dtpPublishDate);
            Controls.Add(btnSave);
            Controls.Add(lblPublishDate);
            Controls.Add(tbDescription);
            Controls.Add(lblDescription);
            Controls.Add(tbTitle);
            Controls.Add(lblTitle);
            Name = "CommentForm";
            Text = "Comment";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCreateComment;
        private Button btnDeleteComment;
        private Button btnEditComment;
        private Button btnViewComment;
        private ListBox listBox1;
        private Label lblComments;
        private Label lblAuthor;
        private DateTimePicker dtpPublishDate;
        private Button btnSave;
        private Label lblPublishDate;
        private TextBox tbDescription;
        private Label lblDescription;
        private TextBox tbTitle;
        private Label lblTitle;
    }
}
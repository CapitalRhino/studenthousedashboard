﻿using Data;
using Logic;
using Models;

namespace WinForms
{
    public partial class CommentForm : Form
    {
        Comment? comment;
        User currentUser;
        string responseType;
        bool complaint;
        int parentId;
        public CommentForm(Comment? comment, bool readOnly, User currentUser)
        {
            InitializeComponent();
            this.comment = comment;
            this.currentUser = currentUser;

            // restriction: no need to create events in the past
            dtpPublishDate.Enabled = false;

            if (comment != null)
            {
                tbTitle.Text = comment.Title;
                lblAuthor.Text = $"Created by: {comment.Author.Name}";
                tbDescription.Text = comment.Description;
                dtpPublishDate.Value = comment.PublishDate;
                RefreshComments();
            }
            else
            {
                btnCreateComment.Enabled = false;
                btnDeleteComment.Enabled = false;
                btnEditComment.Enabled = false;
                btnViewComment.Enabled = false;
            }

            if (comment != null && currentUser != null && currentUser.ID != comment.Author.ID)
            {
                // restriction: only edit personal comments
                readOnly = true;
            }

            if (readOnly)
            {
                btnSave.Enabled = false;
                tbTitle.Enabled = false;
                tbDescription.Enabled = false;
            }

            if (currentUser != null)
            {
                lblAuthor.Text = $"Created by: {currentUser.Name}";
            }
        }
        public CommentForm(Comment? comment, bool readOnly, User? currentUser, string responseType, int parentId) : this(comment, readOnly, currentUser)
        {
            this.responseType = responseType;
            this.parentId = parentId;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            CommentManager commentManager = new CommentManager(new CommentRepository());
            if (string.IsNullOrEmpty(tbTitle.Text) || string.IsNullOrEmpty(tbDescription.Text))
            {
                MessageBox.Show("Please enter a title and comment text");
                return;
            }
            if (this.comment == null)
            {
                switch (responseType)
                {
                    case "announcement":
                        commentManager.CreateCommentOnAnnouncement(currentUser, tbDescription.Text, tbTitle.Text, dtpPublishDate.Value, parentId);
                        break;
                    case "comment":
                        commentManager.CreateResponseOnComment(currentUser, tbDescription.Text, tbTitle.Text, dtpPublishDate.Value, parentId);
                        break;
                    case "complaint":
                        commentManager.CreateCommentOnComplaint(currentUser, tbDescription.Text, tbTitle.Text, dtpPublishDate.Value, parentId);
                        break;
                    default:
                        break;
                }
            }
            else
            {
                commentManager.UpdateComment(comment.ID, tbDescription.Text);
            }
        }

        private void btnViewComment_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Please select an item from the list");
            }
            else
            {
                CommentForm form = new CommentForm((Comment)listBox1.SelectedItem, true, currentUser);
                form.ShowDialog();
                RefreshComments();
            }

        }

        private void btnEditComment_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Please select an item from the list");
            }
            else
            {
                CommentForm form = new CommentForm((Comment)listBox1.SelectedItem, false, currentUser);
                form.ShowDialog();
                RefreshComments();
            }
        }

        private void btnDeleteComment_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Please select an item from the list");
            }
            else
            {
                Comment currentResponse = (Comment)listBox1.SelectedItem;
                if (MessageBox.Show($"Are you sure you want to delete\n{currentResponse.Title}\nCreated at {currentResponse.PublishDate.ToString("g")} by {currentResponse.Author.Name}",
        "Delete announcement", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    CommentManager commentManager = new CommentManager(new CommentRepository());
                    commentManager.DeleteResponseOnComment(currentResponse.ID, comment.ID);
                }
                RefreshComments();
            }
        }

        private void btnCreateComment_Click(object sender, EventArgs e)
        {
            CommentForm form = new CommentForm(null, false, currentUser, "comment", comment.ID);
            form.ShowDialog();
            RefreshComments();
        }
        private void RefreshComments()
        {
            listBox1.Items.Clear();
            foreach (var item in comment.Responses)
            {
                listBox1.Items.Add(item);
            }
        }
    }
}

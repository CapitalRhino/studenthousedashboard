using StudentHouseDashboard.Managers;
using StudentHouseDashboard.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForms
{
    public partial class CommentForm : Form
    {
        Comment? comment;
        User currentUser;
        bool announcementResponse;
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

            if (comment != null && currentUser != null)
            {
                if (currentUser.ID != comment.Author.ID)
                {
                    // restriction: only edit personal comments
                    readOnly = true;
                }
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
        public CommentForm(Comment? comment, bool readOnly, User? currentUser, bool announcementResponse, int parentId) : this(comment, readOnly, currentUser)
        {
            this.announcementResponse = announcementResponse;
            this.parentId = parentId;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            CommentManager commentManager = new CommentManager();
            if (string.IsNullOrEmpty(tbTitle.Text) || string.IsNullOrEmpty(tbDescription.Text))
            {
                MessageBox.Show("Please enter a title and comment text");
                return;
            }
            if (this.comment == null)
            {
                if (announcementResponse)
                {
                    commentManager.CreateCommentToAnnouncement(currentUser, tbDescription.Text, tbTitle.Text, dtpPublishDate.Value, parentId);
                }
                else
                {
                    commentManager.CreateResponseToComment(currentUser, tbDescription.Text, tbTitle.Text, dtpPublishDate.Value, parentId);
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
                    CommentManager commentManager = new CommentManager();
                    commentManager.DeleteResponseOnComment(currentResponse.ID, comment.ID);
                }
                RefreshComments();
            }
        }

        private void btnCreateComment_Click(object sender, EventArgs e)
        {
            CommentForm form = new CommentForm(null, false, currentUser, false, comment.ID);
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

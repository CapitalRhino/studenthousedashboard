using Logic;
using Models;
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
    public partial class AnnouncementForm : Form
    {
        Announcement announcement;
        User currentUser;
        public AnnouncementForm(Announcement? announcement, bool readOnly, User currentUser)
        {
            InitializeComponent();
            this.announcement = announcement;
            this.currentUser = currentUser;

            dtpPublishDate.Enabled = false;
            if (readOnly)
            {
                btnSave.Enabled = false;
                tbTitle.Enabled = false;
                tbDescription.Enabled = false;
                ckbImportant.Enabled = false;
                ckbSticky.Enabled = false;
            }
            if (announcement != null)
            {
                tbTitle.Text = announcement.Title;
                lblAuthor.Text = $"Created by: {announcement.Author.Name}";
                tbDescription.Text = announcement.Description;
                dtpPublishDate.Value = announcement.PublishDate;
                ckbImportant.Checked = announcement.IsImportant;
                ckbSticky.Checked = announcement.IsSticky;
                RefreshComments();
            }
            else
            {
                btnCreateComment.Enabled = false;
                btnDeleteComment.Enabled = false;
                btnEditComment.Enabled = false;
                btnViewComment.Enabled = false;
            }
            if (currentUser != null)
            {
                lblAuthor.Text = $"Created by: {currentUser.Name}";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            AnnouncementManager announcementManager = new AnnouncementManager();
            if (string.IsNullOrEmpty(tbTitle.Text))
            {
                MessageBox.Show("Please enter a title");
                return;
            }

            if (this.announcement == null)
            {
                announcementManager.CreateAnnouncement(tbTitle.Text, tbDescription.Text, currentUser, dtpPublishDate.Value, ckbImportant.Checked, ckbSticky.Checked);
            }
            else
            {
                announcementManager.UpdateAnnouncement(announcement.ID, tbTitle.Text, tbDescription.Text, ckbImportant.Checked, ckbSticky.Checked);
            }
            this.DialogResult = DialogResult.OK;
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
                Comment currentComment = (Comment)listBox1.SelectedItem;
                if (MessageBox.Show($"Are you sure you want to delete\n{currentComment.Title}\nCreated at {currentComment.PublishDate.ToString("g")} by {currentComment.Author.Name}",
        "Delete announcement", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    CommentManager commentManager = new CommentManager();
                    commentManager.DeleteCommentOnAnnouncement(currentComment.ID, announcement.ID);
                }
                RefreshComments();
            }
        }

        private void btnCreateComment_Click(object sender, EventArgs e)
        {
            CommentForm form = new CommentForm(null, false, currentUser, true, announcement.ID);
            form.ShowDialog();
            RefreshComments();
        }

        private void RefreshComments()
        {
            listBox1.Items.Clear();
            foreach (var item in announcement.Comments)
            {
                listBox1.Items.Add(item);
            }
        }
    }
}

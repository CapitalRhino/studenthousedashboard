using Data;
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
    public partial class ComplaintForm : Form
    {
        Complaint complaint;
        User currentUser;
        public ComplaintForm(Complaint? complaint, bool readOnly, User currentUser)
        {
            InitializeComponent();
            this.complaint = complaint;
            this.currentUser = currentUser;

            dtpPublishDate.Enabled = false;
            tbTitle.Enabled = false;
            tbDescription.Enabled = false;

            foreach (var item in Enum.GetValues(typeof(ComplaintStatus)))
            {
                cbStatus.Items.Add(item);
            }
            foreach (var item in Enum.GetValues(typeof(ComplaintSeverity)))
            {
                cbSeverity.Items.Add(item);
            }

            if (readOnly)
            {
                btnSave.Enabled = false;
                cbStatus.Enabled = false;
                cbSeverity.Enabled = false;
            }
            if (complaint != null)
            {
                tbTitle.Text = complaint.Title;
                lblAuthor.Text = $"Created by: {complaint.Author.Name}";
                tbDescription.Text = complaint.Description;
                dtpPublishDate.Value = complaint.PublishDate;
                cbStatus.SelectedIndex = (int)complaint.Status;
                cbSeverity.SelectedIndex = (int)complaint.Severity;
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
            ComplaintManager complaintManager = new ComplaintManager(new ComplaintRepository());
            if (string.IsNullOrEmpty(tbTitle.Text))
            {
                MessageBox.Show("Please enter a title");
                return;
            }

            if (this.complaint == null)
            {
                complaintManager.CreateComplaint(tbTitle.Text, tbDescription.Text, currentUser, dtpPublishDate.Value, (ComplaintStatus)cbStatus.SelectedIndex, (ComplaintSeverity)cbSeverity.SelectedIndex);
            }
            else
            {
                complaintManager.UpdateComplaint(complaint.ID, tbTitle.Text, tbDescription.Text, (ComplaintStatus)cbStatus.SelectedIndex, (ComplaintSeverity)cbSeverity.SelectedIndex);
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
                    CommentManager commentManager = new CommentManager(new CommentRepository());
                    commentManager.DeleteCommentOnAnnouncement(currentComment.ID, complaint.ID);
                }
                RefreshComments();
            }
        }

        private void btnCreateComment_Click(object sender, EventArgs e)
        {
            CommentForm form = new CommentForm(null, false, currentUser, "complaint", complaint.ID);
            form.ShowDialog();
            RefreshComments();
        }

        private void RefreshComments()
        {
            listBox1.Items.Clear();
            foreach (var item in complaint.Responses)
            {
                listBox1.Items.Add(item);
            }
        }
    }
}

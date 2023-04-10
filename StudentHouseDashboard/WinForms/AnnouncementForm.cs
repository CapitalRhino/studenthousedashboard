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
    public partial class AnnouncementForm : Form
    {
        Announcement announcement;
        User currentUser;
        public AnnouncementForm(Announcement? announcement, bool readOnly, User? currentUser)
        {
            InitializeComponent();
            this.announcement = announcement;
            this.currentUser = currentUser;
            if (readOnly)
            {
                btnSave.Enabled = false;
                tbTitle.Enabled = false;
                tbDescription.Enabled = false;
                dtpPublishDate.Enabled = false;
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
                announcementManager.UpdateAnnouncement(announcement.ID, tbTitle.Text, tbDescription.Text, currentUser, dtpPublishDate.Value, ckbImportant.Checked, ckbSticky.Checked);
            }
            this.DialogResult = DialogResult.OK;
        }
    }
}

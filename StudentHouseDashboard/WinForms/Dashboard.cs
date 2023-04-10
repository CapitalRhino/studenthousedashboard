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
    public partial class Dashboard : Form
    {
        Login loginForm;
        User user;
        public Dashboard(Login loginForm, User user)
        {
            this.loginForm = loginForm;
            this.user = user;
            InitializeComponent();
            lblUserStatus.Text = $"Logged in as: {user.Role} {user.Name}";
            if (user.Role == UserRole.MANAGER)
            {
                btnCreateUser.Enabled = false;
                btnDeleteUser.Enabled = false;
                btnUpdateUser.Enabled = true;
                btnNewAnnouncement.Enabled = false;
                btnDeleteAnnouncement.Enabled = false;
                btnEditAnnouncement.Enabled = true;
            }
            else if (user.Role == UserRole.ADMIN)
            {
                btnCreateUser.Enabled = true;
                btnDeleteUser.Enabled = true;
                btnUpdateUser.Enabled = true;
                btnNewAnnouncement.Enabled = true;
                btnDeleteAnnouncement.Enabled = true;
                btnEditAnnouncement.Enabled = true;
            }
            else
            {
                btnCreateUser.Enabled = false;
                btnDeleteUser.Enabled = false;
                btnUpdateUser.Enabled = false;
                btnNewAnnouncement.Enabled = false;
                btnDeleteAnnouncement.Enabled = false;
                btnEditAnnouncement.Enabled = false;
            }
            RefreshLists();
        }

        private void btnCreateUser_Click(object sender, EventArgs e)
        {
            UserForm userForm = new UserForm(null, false);
            userForm.ShowDialog();
            RefreshLists();
        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            User currentUser = (User)lbUsers.SelectedItem;
            if (MessageBox.Show($"Are you sure you want to delete\n{currentUser.Name}\n{currentUser.Role}", "Delete user", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                UserManager userManager = new UserManager();
                userManager.DisableUser(currentUser.ID);
            }
            RefreshLists();
        }

        private void btnUpdateUser_Click(object sender, EventArgs e)
        {
            UserForm userForm = new UserForm((User)lbUsers.SelectedItem, false);
            userForm.ShowDialog();
            RefreshLists();
        }

        private void btnViewUser_Click(object sender, EventArgs e)
        {
            UserForm userForm = new UserForm((User)lbUsers.SelectedItem, true);
            userForm.ShowDialog();
            RefreshLists();
        }

        private void RefreshLists()
        {
            UserManager userManager = new UserManager();
            lbUsers.Items.Clear();
            foreach (User _user in userManager.GetAllUsers())
            {
                lbUsers.Items.Add(_user);
            }
            AnnouncementManager announcementManager = new AnnouncementManager();
            lbAnnouncements.Items.Clear();
            foreach (Announcement announcement in announcementManager.GetAllAnnouncements())
            {
                lbAnnouncements.Items.Add(announcement);
            }
        }

        private void Dashboard_FormClosed(object sender, FormClosedEventArgs e)
        {
            loginForm.Show();
        }

        private void btnNewAnnouncement_Click(object sender, EventArgs e)
        {
            AnnouncementForm announcementForm = new AnnouncementForm(null, false, user);
            announcementForm.ShowDialog();
            RefreshLists();
        }

        private void btnDeleteAnnouncement_Click(object sender, EventArgs e)
        {
            Announcement currentAnnouncement = (Announcement)lbAnnouncements.SelectedItem;
            if (MessageBox.Show($"Are you sure you want to delete\n{currentAnnouncement.Title}\nCreated at {currentAnnouncement.PublishDate.ToString("g")} by {currentAnnouncement.Author.Name}",
                "Delete announcement", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                AnnouncementManager announcementManager = new AnnouncementManager();
                announcementManager.DeleteAnnouncement(currentAnnouncement.ID);
            }
            RefreshLists();
        }

        private void btnEditAnnouncement_Click(object sender, EventArgs e)
        {
            AnnouncementForm announcementForm = new AnnouncementForm((Announcement)lbAnnouncements.SelectedItem, false, null);
            announcementForm.ShowDialog();
            RefreshLists();
        }

        private void btnViewAnnouncement_Click(object sender, EventArgs e)
        {
            AnnouncementForm announcementForm = new AnnouncementForm((Announcement)lbAnnouncements.SelectedItem, true, null);
            announcementForm.ShowDialog();
            RefreshLists();
        }
    }
}

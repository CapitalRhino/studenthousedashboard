﻿using Data;
using Logic;
using Models;

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
                btnEditComplaint.Enabled = false;
            }
            else if (user.Role == UserRole.ADMIN)
            {
                btnCreateUser.Enabled = true;
                btnDeleteUser.Enabled = true;
                btnUpdateUser.Enabled = true;
                btnNewAnnouncement.Enabled = true;
                btnDeleteAnnouncement.Enabled = true;
                btnEditAnnouncement.Enabled = true;
                btnEditComplaint.Enabled = true;
            }
            else
            {
                btnCreateUser.Enabled = false;
                btnDeleteUser.Enabled = false;
                btnUpdateUser.Enabled = false;
                btnNewAnnouncement.Enabled = false;
                btnDeleteAnnouncement.Enabled = false;
                btnEditAnnouncement.Enabled = false;
                btnEditComplaint.Enabled = false;
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
            if (lbUsers.SelectedIndex == -1)
            {
                MessageBox.Show("Please select an item from the list");
            }
            else
            {
                User currentUser = (User)lbUsers.SelectedItem;
                if (MessageBox.Show($"Are you sure you want to delete\n{currentUser.Name}\n{currentUser.Role}", "Delete user", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    UserManager userManager = new UserManager(new UserRepository());
                    userManager.DisableUser(currentUser.ID);
                }
            }
            RefreshLists();
        }

        private void btnUpdateUser_Click(object sender, EventArgs e)
        {
            if (lbUsers.SelectedIndex == -1)
            {
                MessageBox.Show("Please select an item from the list");
            }
            else
            {
                UserForm userForm = new UserForm((User)lbUsers.SelectedItem, false);
                userForm.ShowDialog();
            }
            RefreshLists();
        }

        private void btnViewUser_Click(object sender, EventArgs e)
        {
            if (lbUsers.SelectedIndex == -1)
            {
                MessageBox.Show("Please select an item from the list");
            }
            else
            {
                UserForm userForm = new UserForm((User)lbUsers.SelectedItem, true);
                userForm.ShowDialog();
            }
            RefreshLists();
        }

        private void RefreshLists()
        {
            UserManager userManager = new UserManager(new UserRepository());
            lbUsers.Items.Clear();
            foreach (User _user in userManager.GetAllUsers())
            {
                lbUsers.Items.Add(_user);
            }
            AnnouncementManager announcementManager = new AnnouncementManager(new AnnouncementRepository());
            lbAnnouncements.Items.Clear();
            foreach (Announcement announcement in announcementManager.GetAllAnnouncements())
            {
                lbAnnouncements.Items.Add(announcement);
            }
            ComplaintManager complaintManager = new ComplaintManager(new ComplaintRepository());
            lbComplaints.Items.Clear();
            foreach (Complaint complaint in complaintManager.GetAllComplaints())
            {
                lbComplaints.Items.Add(complaint);
            }
            EventManager eventManager = new EventManager(new EventRepository());
            lbEvents.Items.Clear();
            foreach (Event @event in eventManager.GetAllEvents())
            {
                lbEvents.Items.Add(@event);
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
            if (lbAnnouncements.SelectedIndex == -1)
            {
                MessageBox.Show("Please select an item from the list");
            }
            else
            {
                Announcement currentAnnouncement = (Announcement)lbAnnouncements.SelectedItem;
                if (MessageBox.Show($"Are you sure you want to delete\n{currentAnnouncement.Title}\nCreated at {currentAnnouncement.PublishDate.ToString("g")} by {currentAnnouncement.Author.Name}",
                    "Delete announcement", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    AnnouncementManager announcementManager = new AnnouncementManager(new AnnouncementRepository());
                    announcementManager.DeleteAnnouncement(currentAnnouncement.ID);
                }
                RefreshLists();
            }
        }

        private void btnEditAnnouncement_Click(object sender, EventArgs e)
        {
            if (lbAnnouncements.SelectedIndex == -1)
            {
                MessageBox.Show("Please select an item from the list");
            }
            else
            {
                AnnouncementForm announcementForm = new AnnouncementForm((Announcement)lbAnnouncements.SelectedItem, false, user);
                announcementForm.ShowDialog();
                RefreshLists();
            }
        }

        private void btnViewAnnouncement_Click(object sender, EventArgs e)
        {
            if (lbAnnouncements.SelectedIndex == -1)
            {
                MessageBox.Show("Please select an item from the list");
            }
            else
            {
                AnnouncementForm announcementForm = new AnnouncementForm((Announcement)lbAnnouncements.SelectedItem, true, user);
                announcementForm.ShowDialog();
                RefreshLists();
            }
        }

        private void btnArchiveComplaint_Click(object sender, EventArgs e)
        {
            if (lbComplaints.SelectedIndex == -1)
            {
                MessageBox.Show("Please select an item from the list");
            }
            else
            {
                Complaint currentComplaint = (Complaint)lbComplaints.SelectedItem;
                if (MessageBox.Show($"Are you sure you want to archive\n{currentComplaint.Title}\nCreated at {currentComplaint.PublishDate.ToString("g")} by {currentComplaint.Author.Name}",
                    "Archive complaint", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ComplaintManager complaintManager = new ComplaintManager(new ComplaintRepository());
                    complaintManager.UpdateComplaint(currentComplaint.ID, currentComplaint.Title, currentComplaint.Description, ComplaintStatus.ARCHIVED, currentComplaint.Severity);
                }
                RefreshLists();
            }
        }

        private void btnEditComplaint_Click(object sender, EventArgs e)
        {
            if (lbComplaints.SelectedIndex == -1)
            {
                MessageBox.Show("Please select an item from the list");
            }
            else
            {
                ComplaintForm complaintForm = new ComplaintForm((Complaint)lbComplaints.SelectedItem, false, user);
                complaintForm.ShowDialog();
                RefreshLists();
            }
        }

        private void btnViewComplaint_Click(object sender, EventArgs e)
        {
            if (lbComplaints.SelectedIndex == -1)
            {
                MessageBox.Show("Please select an item from the list");
            }
            else
            {
                ComplaintForm complaintForm = new ComplaintForm((Complaint)lbComplaints.SelectedItem, true, user);
                complaintForm.ShowDialog();
                RefreshLists();
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to log out?", "Log out", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Close();
            }
        }

        private void btnNewEvent_Click(object sender, EventArgs e)
        {
            EventForm eventForm = new EventForm(null, false, user);
            eventForm.ShowDialog();
            RefreshLists();
        }

        private void btnDeleteEvent_Click(object sender, EventArgs e)
        {
            if (lbEvents.SelectedIndex == -1)
            {
                MessageBox.Show("Please select an item from the list");
            }
            else
            {
                Event currentEvent = (Event)lbEvents.SelectedItem;
                if (MessageBox.Show($"Are you sure you want to delete\n{currentEvent.Title}\nCreated at {currentEvent.PublishDate.ToString("g")} by {currentEvent.Author.Name}",
                    "Delete announcement", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    EventManager eventManager = new EventManager(new EventRepository());
                    eventManager.DeleteEvent(currentEvent.ID);
                }
                RefreshLists();
            }
        }

        private void btnEditEvent_Click(object sender, EventArgs e)
        {
            if (lbEvents.SelectedIndex == -1)
            {
                MessageBox.Show("Please select an item from the list");
            }
            else
            {
                EventForm eventForm = new EventForm((Event)lbEvents.SelectedItem, false, user);
                eventForm.ShowDialog();
                RefreshLists();
            }
        }

        private void btnViewEvent_Click(object sender, EventArgs e)
        {
            if (lbEvents.SelectedIndex == -1)
            {
                MessageBox.Show("Please select an item from the list");
            }
            else
            {
                EventForm eventForm = new EventForm((Event)lbEvents.SelectedItem, true, user);
                eventForm.ShowDialog();
                RefreshLists();
            }
        }
    }
}

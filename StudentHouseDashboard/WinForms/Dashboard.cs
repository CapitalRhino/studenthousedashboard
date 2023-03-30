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
        public Dashboard(Login loginForm, User user)
        {
            this.loginForm = loginForm;
            InitializeComponent();
            lblUserStatus.Text = $"Logged in as: {user.Role} {user.Name}";
            if (user.Role == UserRole.ADMIN || user.Role == UserRole.MANAGER)
            {
                btnCreateUser.Enabled = true;
                btnDeleteUser.Enabled = true;
                btnUpdateUser.Enabled = true;
            }
            else
            {
                btnCreateUser.Enabled = false;
                btnDeleteUser.Enabled = false;
                btnUpdateUser.Enabled = false;
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
        }

        private void Dashboard_FormClosed(object sender, FormClosedEventArgs e)
        {
            loginForm.Show();
        }
    }
}

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
    public partial class UserForm : Form
    {
        User user;
        public UserForm(User? user, bool readOnly)
        {
            InitializeComponent();
            this.user = user;
            if (readOnly)
            {
                btnSave.Enabled = false;
                tbUsername.Enabled = false;
                tbPassword.Enabled = false;
                cbUserRole.Enabled = false;
            }
            cbUserRole.Items.Clear();
            foreach (var item in Enum.GetValues(typeof(UserRole)))
            {
                cbUserRole.Items.Add(item);
            }
            if (user != null)
            {
                tbUsername.Text = user.Name;
                cbUserRole.SelectedIndex = (int)user.Role;
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            UserManager userManager = new UserManager();
            if (string.IsNullOrEmpty(tbUsername.Text) || string.IsNullOrEmpty(tbPassword.Text) || cbUserRole.SelectedIndex == -1)
            {
                MessageBox.Show("Please enter data in all fields");
                return;
            }

            if (this.user == null)
            {
                userManager.CreateUser(tbUsername.Text, BCrypt.Net.BCrypt.HashPassword(tbPassword.Text), (UserRole)cbUserRole.SelectedItem);
            }
            else
            {
                if (string.IsNullOrEmpty(tbPassword.Text))
                {
                    //userManager.UpdateUser(this.user.ID, tbUsername.Text,)
                }
                else
                {
                    userManager.UpdateUser(this.user.ID, tbUsername.Text, BCrypt.Net.BCrypt.HashPassword(tbPassword.Text), (UserRole)cbUserRole.SelectedItem);
                }
            }
            this.DialogResult = DialogResult.OK;
        }
    }
}

using StudentHouseDashboard.Managers;
using StudentHouseDashboard.Models;

namespace WinForms
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            UserManager userManager = new UserManager();
            User? user = userManager.AuthenticatedUser(tbUsername.Text, tbPassword.Text);
            if (user == null)
            {
                MessageBox.Show("Wrong username or password", "Login failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show($"Welcome, {user.Name}", "Login successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
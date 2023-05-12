using Logic;
using Models;

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
                Dashboard dashboard = new Dashboard(this, user);
                this.Hide();
                dashboard.Show();
            }
            tbUsername.Text = "";
            tbPassword.Text = "";
        }
    }
}
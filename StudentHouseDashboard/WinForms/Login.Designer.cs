namespace WinForms
{
    partial class Login
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblLogo = new Label();
            lblUsername = new Label();
            tbUsername = new TextBox();
            lblPassword = new Label();
            tbPassword = new TextBox();
            btnLogin = new Button();
            SuspendLayout();
            // 
            // lblLogo
            // 
            lblLogo.Location = new Point(12, 9);
            lblLogo.Name = "lblLogo";
            lblLogo.Size = new Size(230, 37);
            lblLogo.TabIndex = 0;
            lblLogo.Text = "Welcome to Student House Dashboard";
            lblLogo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Location = new Point(12, 64);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(63, 15);
            lblUsername.TabIndex = 1;
            lblUsername.Text = "Username:";
            // 
            // tbUsername
            // 
            tbUsername.Location = new Point(81, 61);
            tbUsername.Name = "tbUsername";
            tbUsername.Size = new Size(161, 23);
            tbUsername.TabIndex = 2;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(12, 93);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(60, 15);
            lblPassword.TabIndex = 3;
            lblPassword.Text = "Password:";
            // 
            // tbPassword
            // 
            tbPassword.Location = new Point(81, 90);
            tbPassword.Name = "tbPassword";
            tbPassword.PasswordChar = '*';
            tbPassword.Size = new Size(161, 23);
            tbPassword.TabIndex = 4;
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(167, 119);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(75, 23);
            btnLogin.TabIndex = 5;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(266, 163);
            Controls.Add(btnLogin);
            Controls.Add(tbPassword);
            Controls.Add(lblPassword);
            Controls.Add(tbUsername);
            Controls.Add(lblUsername);
            Controls.Add(lblLogo);
            Name = "Login";
            ShowIcon = false;
            Text = "StudentHouseDashboard";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblLogo;
        private Label lblUsername;
        private TextBox tbUsername;
        private Label lblPassword;
        private TextBox tbPassword;
        private Button btnLogin;
    }
}
namespace WinForms
{
    partial class Dashboard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblUserStatus = new Label();
            lbUsers = new ListBox();
            btnCreateUser = new Button();
            btnDeleteUser = new Button();
            btnUpdateUser = new Button();
            btnViewUser = new Button();
            SuspendLayout();
            // 
            // lblUserStatus
            // 
            lblUserStatus.AutoSize = true;
            lblUserStatus.Location = new Point(13, 18);
            lblUserStatus.Name = "lblUserStatus";
            lblUserStatus.Size = new Size(80, 15);
            lblUserStatus.TabIndex = 0;
            lblUserStatus.Text = "Logged in as: ";
            // 
            // lbUsers
            // 
            lbUsers.FormattingEnabled = true;
            lbUsers.ItemHeight = 15;
            lbUsers.Location = new Point(13, 86);
            lbUsers.Name = "lbUsers";
            lbUsers.Size = new Size(318, 154);
            lbUsers.TabIndex = 1;
            // 
            // btnCreateUser
            // 
            btnCreateUser.Location = new Point(13, 257);
            btnCreateUser.Name = "btnCreateUser";
            btnCreateUser.Size = new Size(75, 23);
            btnCreateUser.TabIndex = 2;
            btnCreateUser.Text = "New User";
            btnCreateUser.UseVisualStyleBackColor = true;
            btnCreateUser.Click += btnCreateUser_Click;
            // 
            // btnDeleteUser
            // 
            btnDeleteUser.Location = new Point(94, 257);
            btnDeleteUser.Name = "btnDeleteUser";
            btnDeleteUser.Size = new Size(75, 23);
            btnDeleteUser.TabIndex = 3;
            btnDeleteUser.Text = "Delete User";
            btnDeleteUser.UseVisualStyleBackColor = true;
            btnDeleteUser.Click += btnDeleteUser_Click;
            // 
            // btnUpdateUser
            // 
            btnUpdateUser.Location = new Point(175, 257);
            btnUpdateUser.Name = "btnUpdateUser";
            btnUpdateUser.Size = new Size(75, 23);
            btnUpdateUser.TabIndex = 4;
            btnUpdateUser.Text = "Edit User";
            btnUpdateUser.UseVisualStyleBackColor = true;
            btnUpdateUser.Click += btnUpdateUser_Click;
            // 
            // btnViewUser
            // 
            btnViewUser.Location = new Point(256, 257);
            btnViewUser.Name = "btnViewUser";
            btnViewUser.Size = new Size(75, 23);
            btnViewUser.TabIndex = 5;
            btnViewUser.Text = "View User";
            btnViewUser.UseVisualStyleBackColor = true;
            btnViewUser.Click += btnViewUser_Click;
            // 
            // Dashboard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(359, 302);
            Controls.Add(btnViewUser);
            Controls.Add(btnUpdateUser);
            Controls.Add(btnDeleteUser);
            Controls.Add(btnCreateUser);
            Controls.Add(lbUsers);
            Controls.Add(lblUserStatus);
            Name = "Dashboard";
            Text = "Dashboard";
            FormClosed += Dashboard_FormClosed;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblUserStatus;
        private ListBox lbUsers;
        private Button btnCreateUser;
        private Button btnDeleteUser;
        private Button btnUpdateUser;
        private Button btnViewUser;
    }
}
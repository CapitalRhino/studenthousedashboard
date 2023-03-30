namespace WinForms
{
    partial class UserForm
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
            lblUsername = new Label();
            tbUsername = new TextBox();
            lblPassword = new Label();
            tbPassword = new TextBox();
            lblUserRole = new Label();
            cbUserRole = new ComboBox();
            btnSave = new Button();
            SuspendLayout();
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Location = new Point(12, 9);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(63, 15);
            lblUsername.TabIndex = 0;
            lblUsername.Text = "Username:";
            // 
            // tbUsername
            // 
            tbUsername.Location = new Point(84, 6);
            tbUsername.Name = "tbUsername";
            tbUsername.Size = new Size(121, 23);
            tbUsername.TabIndex = 1;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(12, 38);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(60, 15);
            lblPassword.TabIndex = 2;
            lblPassword.Text = "Password:";
            // 
            // tbPassword
            // 
            tbPassword.Location = new Point(84, 35);
            tbPassword.Name = "tbPassword";
            tbPassword.Size = new Size(121, 23);
            tbPassword.TabIndex = 3;
            // 
            // lblUserRole
            // 
            lblUserRole.AutoSize = true;
            lblUserRole.Location = new Point(12, 67);
            lblUserRole.Name = "lblUserRole";
            lblUserRole.Size = new Size(33, 15);
            lblUserRole.TabIndex = 4;
            lblUserRole.Text = "Role:";
            // 
            // cbUserRole
            // 
            cbUserRole.DropDownStyle = ComboBoxStyle.DropDownList;
            cbUserRole.FormattingEnabled = true;
            cbUserRole.Location = new Point(84, 64);
            cbUserRole.Name = "cbUserRole";
            cbUserRole.Size = new Size(121, 23);
            cbUserRole.TabIndex = 5;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(130, 93);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 6;
            btnSave.Text = "Save changes";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // UserForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(230, 135);
            Controls.Add(btnSave);
            Controls.Add(cbUserRole);
            Controls.Add(lblUserRole);
            Controls.Add(tbPassword);
            Controls.Add(lblPassword);
            Controls.Add(tbUsername);
            Controls.Add(lblUsername);
            Name = "UserForm";
            Text = "UserForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblUsername;
        private TextBox tbUsername;
        private Label lblPassword;
        private TextBox tbPassword;
        private Label lblUserRole;
        private ComboBox cbUserRole;
        private Button btnSave;
    }
}
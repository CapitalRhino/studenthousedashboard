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
            tabControl1 = new TabControl();
            tpUsers = new TabPage();
            panelUserFunctions = new Panel();
            tpAnnouncements = new TabPage();
            panelAnnouncementsFunctions = new Panel();
            btnNewAnnouncement = new Button();
            btnDeleteAnnouncement = new Button();
            btnViewAnnouncement = new Button();
            btnEditAnnouncement = new Button();
            lbAnnouncements = new ListBox();
            tpComplaints = new TabPage();
            panelComplaintFunctions = new Panel();
            btnArchiveComplaint = new Button();
            btnViewComplaint = new Button();
            btnEditComplaint = new Button();
            lbComplaints = new ListBox();
            tpEvents = new TabPage();
            btnLogout = new Button();
            panel1 = new Panel();
            btnNewEvent = new Button();
            btnDeleteEvent = new Button();
            btnViewEvent = new Button();
            btnEditEvent = new Button();
            lbEvents = new ListBox();
            tabControl1.SuspendLayout();
            tpUsers.SuspendLayout();
            panelUserFunctions.SuspendLayout();
            tpAnnouncements.SuspendLayout();
            panelAnnouncementsFunctions.SuspendLayout();
            tpComplaints.SuspendLayout();
            panelComplaintFunctions.SuspendLayout();
            tpEvents.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // lblUserStatus
            // 
            lblUserStatus.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblUserStatus.AutoSize = true;
            lblUserStatus.Location = new Point(396, 4);
            lblUserStatus.Name = "lblUserStatus";
            lblUserStatus.Size = new Size(80, 15);
            lblUserStatus.TabIndex = 0;
            lblUserStatus.Text = "Logged in as: ";
            lblUserStatus.TextAlign = ContentAlignment.TopRight;
            // 
            // lbUsers
            // 
            lbUsers.Dock = DockStyle.Fill;
            lbUsers.FormattingEnabled = true;
            lbUsers.ItemHeight = 15;
            lbUsers.Location = new Point(3, 3);
            lbUsers.Name = "lbUsers";
            lbUsers.Size = new Size(717, 334);
            lbUsers.TabIndex = 1;
            // 
            // btnCreateUser
            // 
            btnCreateUser.Location = new Point(3, 3);
            btnCreateUser.Name = "btnCreateUser";
            btnCreateUser.Size = new Size(75, 23);
            btnCreateUser.TabIndex = 2;
            btnCreateUser.Text = "New";
            btnCreateUser.UseVisualStyleBackColor = true;
            btnCreateUser.Click += btnCreateUser_Click;
            // 
            // btnDeleteUser
            // 
            btnDeleteUser.Location = new Point(84, 3);
            btnDeleteUser.Name = "btnDeleteUser";
            btnDeleteUser.Size = new Size(75, 23);
            btnDeleteUser.TabIndex = 3;
            btnDeleteUser.Text = "Delete";
            btnDeleteUser.UseVisualStyleBackColor = true;
            btnDeleteUser.Click += btnDeleteUser_Click;
            // 
            // btnUpdateUser
            // 
            btnUpdateUser.Location = new Point(165, 3);
            btnUpdateUser.Name = "btnUpdateUser";
            btnUpdateUser.Size = new Size(75, 23);
            btnUpdateUser.TabIndex = 4;
            btnUpdateUser.Text = "Edit";
            btnUpdateUser.UseVisualStyleBackColor = true;
            btnUpdateUser.Click += btnUpdateUser_Click;
            // 
            // btnViewUser
            // 
            btnViewUser.Location = new Point(246, 3);
            btnViewUser.Name = "btnViewUser";
            btnViewUser.Size = new Size(75, 23);
            btnViewUser.TabIndex = 5;
            btnViewUser.Text = "View";
            btnViewUser.UseVisualStyleBackColor = true;
            btnViewUser.Click += btnViewUser_Click;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tpUsers);
            tabControl1.Controls.Add(tpAnnouncements);
            tabControl1.Controls.Add(tpComplaints);
            tabControl1.Controls.Add(tpEvents);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(731, 368);
            tabControl1.TabIndex = 6;
            // 
            // tpUsers
            // 
            tpUsers.Controls.Add(panelUserFunctions);
            tpUsers.Controls.Add(lbUsers);
            tpUsers.Location = new Point(4, 24);
            tpUsers.Name = "tpUsers";
            tpUsers.Padding = new Padding(3);
            tpUsers.Size = new Size(723, 340);
            tpUsers.TabIndex = 0;
            tpUsers.Text = "Users";
            tpUsers.UseVisualStyleBackColor = true;
            // 
            // panelUserFunctions
            // 
            panelUserFunctions.Controls.Add(btnCreateUser);
            panelUserFunctions.Controls.Add(btnDeleteUser);
            panelUserFunctions.Controls.Add(btnViewUser);
            panelUserFunctions.Controls.Add(btnUpdateUser);
            panelUserFunctions.Dock = DockStyle.Bottom;
            panelUserFunctions.Location = new Point(3, 298);
            panelUserFunctions.Name = "panelUserFunctions";
            panelUserFunctions.Size = new Size(717, 39);
            panelUserFunctions.TabIndex = 6;
            // 
            // tpAnnouncements
            // 
            tpAnnouncements.Controls.Add(panelAnnouncementsFunctions);
            tpAnnouncements.Controls.Add(lbAnnouncements);
            tpAnnouncements.Location = new Point(4, 24);
            tpAnnouncements.Name = "tpAnnouncements";
            tpAnnouncements.Padding = new Padding(3);
            tpAnnouncements.Size = new Size(723, 340);
            tpAnnouncements.TabIndex = 1;
            tpAnnouncements.Text = "Announcements";
            tpAnnouncements.UseVisualStyleBackColor = true;
            // 
            // panelAnnouncementsFunctions
            // 
            panelAnnouncementsFunctions.Controls.Add(btnNewAnnouncement);
            panelAnnouncementsFunctions.Controls.Add(btnDeleteAnnouncement);
            panelAnnouncementsFunctions.Controls.Add(btnViewAnnouncement);
            panelAnnouncementsFunctions.Controls.Add(btnEditAnnouncement);
            panelAnnouncementsFunctions.Dock = DockStyle.Bottom;
            panelAnnouncementsFunctions.Location = new Point(3, 298);
            panelAnnouncementsFunctions.Name = "panelAnnouncementsFunctions";
            panelAnnouncementsFunctions.Size = new Size(717, 39);
            panelAnnouncementsFunctions.TabIndex = 7;
            // 
            // btnNewAnnouncement
            // 
            btnNewAnnouncement.Location = new Point(3, 3);
            btnNewAnnouncement.Name = "btnNewAnnouncement";
            btnNewAnnouncement.Size = new Size(75, 23);
            btnNewAnnouncement.TabIndex = 2;
            btnNewAnnouncement.Text = "New";
            btnNewAnnouncement.UseVisualStyleBackColor = true;
            btnNewAnnouncement.Click += btnNewAnnouncement_Click;
            // 
            // btnDeleteAnnouncement
            // 
            btnDeleteAnnouncement.Location = new Point(84, 3);
            btnDeleteAnnouncement.Name = "btnDeleteAnnouncement";
            btnDeleteAnnouncement.Size = new Size(75, 23);
            btnDeleteAnnouncement.TabIndex = 3;
            btnDeleteAnnouncement.Text = "Delete";
            btnDeleteAnnouncement.UseVisualStyleBackColor = true;
            btnDeleteAnnouncement.Click += btnDeleteAnnouncement_Click;
            // 
            // btnViewAnnouncement
            // 
            btnViewAnnouncement.Location = new Point(246, 3);
            btnViewAnnouncement.Name = "btnViewAnnouncement";
            btnViewAnnouncement.Size = new Size(75, 23);
            btnViewAnnouncement.TabIndex = 5;
            btnViewAnnouncement.Text = "View";
            btnViewAnnouncement.UseVisualStyleBackColor = true;
            btnViewAnnouncement.Click += btnViewAnnouncement_Click;
            // 
            // btnEditAnnouncement
            // 
            btnEditAnnouncement.Location = new Point(165, 3);
            btnEditAnnouncement.Name = "btnEditAnnouncement";
            btnEditAnnouncement.Size = new Size(75, 23);
            btnEditAnnouncement.TabIndex = 4;
            btnEditAnnouncement.Text = "Edit";
            btnEditAnnouncement.UseVisualStyleBackColor = true;
            btnEditAnnouncement.Click += btnEditAnnouncement_Click;
            // 
            // lbAnnouncements
            // 
            lbAnnouncements.Dock = DockStyle.Fill;
            lbAnnouncements.FormattingEnabled = true;
            lbAnnouncements.ItemHeight = 15;
            lbAnnouncements.Location = new Point(3, 3);
            lbAnnouncements.Name = "lbAnnouncements";
            lbAnnouncements.Size = new Size(717, 334);
            lbAnnouncements.TabIndex = 0;
            // 
            // tpComplaints
            // 
            tpComplaints.Controls.Add(panelComplaintFunctions);
            tpComplaints.Controls.Add(lbComplaints);
            tpComplaints.Location = new Point(4, 24);
            tpComplaints.Name = "tpComplaints";
            tpComplaints.Size = new Size(723, 340);
            tpComplaints.TabIndex = 2;
            tpComplaints.Text = "Complaints";
            tpComplaints.UseVisualStyleBackColor = true;
            // 
            // panelComplaintFunctions
            // 
            panelComplaintFunctions.Controls.Add(btnArchiveComplaint);
            panelComplaintFunctions.Controls.Add(btnViewComplaint);
            panelComplaintFunctions.Controls.Add(btnEditComplaint);
            panelComplaintFunctions.Dock = DockStyle.Bottom;
            panelComplaintFunctions.Location = new Point(0, 285);
            panelComplaintFunctions.Name = "panelComplaintFunctions";
            panelComplaintFunctions.Size = new Size(723, 55);
            panelComplaintFunctions.TabIndex = 1;
            // 
            // btnArchiveComplaint
            // 
            btnArchiveComplaint.Location = new Point(8, 10);
            btnArchiveComplaint.Name = "btnArchiveComplaint";
            btnArchiveComplaint.Size = new Size(75, 23);
            btnArchiveComplaint.TabIndex = 7;
            btnArchiveComplaint.Text = "Archive";
            btnArchiveComplaint.UseVisualStyleBackColor = true;
            btnArchiveComplaint.Click += btnArchiveComplaint_Click;
            // 
            // btnViewComplaint
            // 
            btnViewComplaint.Location = new Point(170, 10);
            btnViewComplaint.Name = "btnViewComplaint";
            btnViewComplaint.Size = new Size(75, 23);
            btnViewComplaint.TabIndex = 9;
            btnViewComplaint.Text = "View";
            btnViewComplaint.UseVisualStyleBackColor = true;
            btnViewComplaint.Click += btnViewComplaint_Click;
            // 
            // btnEditComplaint
            // 
            btnEditComplaint.Location = new Point(89, 10);
            btnEditComplaint.Name = "btnEditComplaint";
            btnEditComplaint.Size = new Size(75, 23);
            btnEditComplaint.TabIndex = 8;
            btnEditComplaint.Text = "Edit";
            btnEditComplaint.UseVisualStyleBackColor = true;
            btnEditComplaint.Click += btnEditComplaint_Click;
            // 
            // lbComplaints
            // 
            lbComplaints.Dock = DockStyle.Top;
            lbComplaints.FormattingEnabled = true;
            lbComplaints.ItemHeight = 15;
            lbComplaints.Location = new Point(0, 0);
            lbComplaints.Name = "lbComplaints";
            lbComplaints.Size = new Size(723, 289);
            lbComplaints.TabIndex = 0;
            // 
            // tpEvents
            // 
            tpEvents.Controls.Add(panel1);
            tpEvents.Controls.Add(lbEvents);
            tpEvents.Location = new Point(4, 24);
            tpEvents.Name = "tpEvents";
            tpEvents.Size = new Size(723, 340);
            tpEvents.TabIndex = 3;
            tpEvents.Text = "Events";
            tpEvents.UseVisualStyleBackColor = true;
            // 
            // btnLogout
            // 
            btnLogout.Location = new Point(651, 0);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(75, 23);
            btnLogout.TabIndex = 7;
            btnLogout.Text = "Log out";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(btnNewEvent);
            panel1.Controls.Add(btnDeleteEvent);
            panel1.Controls.Add(btnViewEvent);
            panel1.Controls.Add(btnEditEvent);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 301);
            panel1.Name = "panel1";
            panel1.Size = new Size(723, 39);
            panel1.TabIndex = 8;
            // 
            // btnNewEvent
            // 
            btnNewEvent.Location = new Point(3, 3);
            btnNewEvent.Name = "btnNewEvent";
            btnNewEvent.Size = new Size(75, 23);
            btnNewEvent.TabIndex = 2;
            btnNewEvent.Text = "New";
            btnNewEvent.UseVisualStyleBackColor = true;
            btnNewEvent.Click += btnNewEvent_Click;
            // 
            // btnDeleteEvent
            // 
            btnDeleteEvent.Location = new Point(84, 3);
            btnDeleteEvent.Name = "btnDeleteEvent";
            btnDeleteEvent.Size = new Size(75, 23);
            btnDeleteEvent.TabIndex = 3;
            btnDeleteEvent.Text = "Delete";
            btnDeleteEvent.UseVisualStyleBackColor = true;
            btnDeleteEvent.Click += btnDeleteEvent_Click;
            // 
            // btnViewEvent
            // 
            btnViewEvent.Location = new Point(246, 3);
            btnViewEvent.Name = "btnViewEvent";
            btnViewEvent.Size = new Size(75, 23);
            btnViewEvent.TabIndex = 5;
            btnViewEvent.Text = "View";
            btnViewEvent.UseVisualStyleBackColor = true;
            btnViewEvent.Click += btnViewEvent_Click;
            // 
            // btnEditEvent
            // 
            btnEditEvent.Location = new Point(165, 3);
            btnEditEvent.Name = "btnEditEvent";
            btnEditEvent.Size = new Size(75, 23);
            btnEditEvent.TabIndex = 4;
            btnEditEvent.Text = "Edit";
            btnEditEvent.UseVisualStyleBackColor = true;
            btnEditEvent.Click += btnEditEvent_Click;
            // 
            // lbEvents
            // 
            lbEvents.Dock = DockStyle.Top;
            lbEvents.FormattingEnabled = true;
            lbEvents.ItemHeight = 15;
            lbEvents.Location = new Point(0, 0);
            lbEvents.Name = "lbEvents";
            lbEvents.Size = new Size(723, 304);
            lbEvents.TabIndex = 9;
            // 
            // Dashboard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(731, 368);
            Controls.Add(btnLogout);
            Controls.Add(lblUserStatus);
            Controls.Add(tabControl1);
            Name = "Dashboard";
            Text = "Dashboard";
            FormClosed += Dashboard_FormClosed;
            tabControl1.ResumeLayout(false);
            tpUsers.ResumeLayout(false);
            panelUserFunctions.ResumeLayout(false);
            tpAnnouncements.ResumeLayout(false);
            panelAnnouncementsFunctions.ResumeLayout(false);
            tpComplaints.ResumeLayout(false);
            panelComplaintFunctions.ResumeLayout(false);
            tpEvents.ResumeLayout(false);
            panel1.ResumeLayout(false);
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
        private TabControl tabControl1;
        private TabPage tpUsers;
        private TabPage tpAnnouncements;
        private Panel panelUserFunctions;
        private Panel panelAnnouncementsFunctions;
        private Button btnNewAnnouncement;
        private Button btnDeleteAnnouncement;
        private Button btnViewAnnouncement;
        private Button btnEditAnnouncement;
        private ListBox lbAnnouncements;
        private TabPage tpComplaints;
        private Panel panelComplaintFunctions;
        private ListBox lbComplaints;
        private TabPage tpEvents;
        private Button btnArchiveComplaint;
        private Button btnViewComplaint;
        private Button btnEditComplaint;
        private Button btnLogout;
        private Panel panel1;
        private Button btnNewEvent;
        private Button btnDeleteEvent;
        private Button btnViewEvent;
        private Button btnEditEvent;
        private ListBox lbEvents;
    }
}
using Data;
using Logic;
using Models;

namespace WinForms
{
    public partial class EventForm : Form
    {
        Event @event;
        User currentUser;
        public EventForm(Event? @event, bool readOnly, User currentUser)
        {
            InitializeComponent();
            this.@event = @event;
            this.currentUser = currentUser;

            dtpPublishDate.Enabled = false;
            if (readOnly)
            {
                btnSave.Enabled = false;
                tbTitle.Enabled = false;
                tbDescription.Enabled = false;
                dtpStartDate.Enabled = false;
                dtpEndDate.Enabled = false;
            }
            if (@event != null)
            {
                tbTitle.Text = @event.Title;
                lblAuthor.Text = $"Created by: {@event.Author.Name}";
                tbDescription.Text = @event.Description;
                dtpPublishDate.Value = @event.PublishDate;
                dtpStartDate.Value = @event.EndDate;
            }
            if (currentUser != null)
            {
                lblAuthor.Text = $"Created by: {currentUser.Name}";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            EventManager eventManager = new EventManager(new EventRepository());
            if (string.IsNullOrEmpty(tbTitle.Text))
            {
                MessageBox.Show("Please enter a title");
                return;
            }

            if (this.@event == null)
            {
                eventManager.CreateEvent(tbTitle.Text, tbDescription.Text, currentUser, dtpPublishDate.Value, dtpStartDate.Value, dtpEndDate.Value);
            }
            else
            {
                eventManager.UpdateEvent(@event.ID, tbTitle.Text, tbDescription.Text, dtpStartDate.Value, dtpEndDate.Value);
            }
            this.DialogResult = DialogResult.OK;
        }
    }
}

#region Using directives

using System;
using System.Windows.Forms;

#endregion

namespace SobekCM.METS_Editor
{
    public partial class Progress_Form : Form
    {
        public Progress_Form( string title, string initial_task )
        {
            InitializeComponent();

            Text = title;
            currentTaskLabel.Text = initial_task;
        }

        public void New_Task(string task_group, string task, int progress_current, int progress_max)
        {
            if (currentTaskLabel.Text != task)
                currentTaskLabel.Text = task;

            if (progressBar1.Maximum != progress_max)
                progressBar1.Maximum = progress_max;

            if (progress_current > progressBar1.Maximum)
                progressBar1.Maximum = progress_current;

            if (progressBar1.Value != progress_current)
                progressBar1.Value = progress_current;
        }

        public void New_Task(string task, int progress_current, int progress_max)
        {
            if (currentTaskLabel.Text != task)
                currentTaskLabel.Text = task;

            if (progressBar1.Maximum != progress_max)
                progressBar1.Maximum = progress_max;

            if (progress_current > progressBar1.Maximum)
                progressBar1.Maximum = progress_current;

            if (progressBar1.Value != progress_current)
                progressBar1.Value = progress_current;
        }

        public void New_Task(int progress_current, int progress_max)
        {
            if (progressBar1.Maximum != progress_max)
                progressBar1.Maximum = progress_max;

            if (progress_current > progressBar1.Maximum)
                progressBar1.Maximum = progress_current;

            if (progressBar1.Value != progress_current)
                progressBar1.Value = progress_current;
        }

        public void Increment_Progress()
        {
            int progress_value_new = progressBar1.Value + 1;

            if (progress_value_new > progressBar1.Maximum)
                progressBar1.Maximum = progress_value_new;

            if (progressBar1.Value != progress_value_new)
                progressBar1.Value = progress_value_new;
        }

        private void exitButton_Button_Pressed(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you wish to cancel this operation?     ", "Confirm Cancellation", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if ( result == DialogResult.Yes )
                Close();
        }

    }
}

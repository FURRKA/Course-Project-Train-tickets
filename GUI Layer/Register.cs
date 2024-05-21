using DataLayer.Repository;
using DataLayer.Entity;
using System.Text.RegularExpressions;

namespace GUI_Layer
{
    public partial class Register : Form
    {
        private UserDataRepository repository;
        public Register(UserDataRepository repository)
        {
            InitializeComponent();
            this.repository = repository;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Regex.IsMatch(emailTextBox.Text, "[.\\-_a-z0-9]+@([a-z0-9][\\-a-z0-9]+\\.)+[a-z]{2,6}"))
            {
                repository.Create(new UserEnity(repository.Count + 1, loginTextBox.Text, passwordTextBox.Text,
                    "user", nameTextBox.Text, lastNameTextBox.Text, surNameTextBox.Text, passPortTextBox.Text,
                    emailTextBox.Text));
                Dispose();
            }
            else
                MessageBox.Show("Формат почты неверный");
        }

        private void updateButton(object sender, EventArgs e)
        {
            var textBoxses = Controls.OfType<TextBox>();
            if (textBoxses.All(item => item.Text != ""))
                button1.Enabled = true;
            else
                button1.Enabled = false;
        }
    }
}

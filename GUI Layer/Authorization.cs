using DataLayer.Entity;
using DataLayer.Repository;

namespace GUI_Layer
{
    public partial class Authorization : Form
    {
        private UserDataRepository userData;
        private string DBPath;
        public Authorization(string path)
        {
            InitializeComponent();
            DBPath = path;
            userData = new UserDataRepository(path);
            userData.Read();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (userData.Data.Any(item => item.Login == textBox1.Text && item.Password == textBox2.Text))
            {
                var user = userData.Data.Find(item => item.Login == textBox1.Text && item.Password == textBox2.Text);
                var mainForm = new Form1(DBPath, user);
                mainForm.Show();
            }
            else
                MessageBox.Show("Пользователя с таким логином или паролем не найдено");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var registerForm = new Register(userData);
            registerForm.ShowDialog();
        }
    }
}

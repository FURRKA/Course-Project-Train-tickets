using DataLayer.Entity;

namespace GUI_Layer
{
    public partial class ClientFillForm : Form
    {
        public ClientFillForm(UserEnity user)
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            var box = (TextBox)sender;
            label5.Text = textBox1.Text + " " + textBox2.Text + " " + textBox3.Text;
        }
    }
}

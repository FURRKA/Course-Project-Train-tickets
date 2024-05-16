using BIL.Services;

namespace GUI_Layer
{
    public partial class SeatCar : Form
    {
        private DateTime departureDate;
        public SeatCar(int carNumber,int trainId, int distance, double cost, DateTime time)
        {
            InitializeComponent();
            label2.Text = $"Вагон №{carNumber}";
            label3.Text = $"Стоимость: {distance * cost}";
            departureDate = time;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            button.Enabled = false;
            button.BackColor = Color.LightBlue;
            int number = Convert.ToInt32(button.Text);
            label1.Text = $"Место №{number}";

            foreach (Control control in this.Controls)
            {
                if (control is Button && control != button)
                {
                    Button otherButton = (Button)control;
                    otherButton.Enabled = false;
                }
            }
            buttonAccept.Enabled = true;
        }

        private void buttonAccept_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Ghbdtn");
        }
    }
}

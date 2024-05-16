using BIL.Services;

namespace GUI_Layer
{
    public partial class SeatCar : Form
    {
        private DataService service;
        private List<int> seats;
        private int trainId;
        private int carNumber;
        private DateTime date;
        public SeatCar(int trainId, int carNumber, int distance, double cost, DateTime date, DataService service)
        {
            InitializeComponent();
            this.trainId = trainId;
            this.carNumber = carNumber;
            this.date = date;
            this.service = service;

            Text = $"Вагон №{carNumber}";
            label2.Text = $"Вагон №{carNumber}";
            label3.Text = $"Стоимость: {distance * cost}";
            seats = service.SeatsList(trainId, carNumber, date.Date.ToString());

            foreach (Control control in Controls)
            {
                if (control is Button && control != buttonAccept)
                {
                    var button = (Button)control;
                    if (seats.Contains(Convert.ToInt32(button.Text)))
                    {
                        button.BackColor = Color.Gray;
                        button.Enabled = false;
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            button.Enabled = false;
            button.BackColor = Color.LightBlue;
            int number = Convert.ToInt32(button.Text);
            label1.Text = $"Место №{number}";
            seats.Add(Convert.ToInt32(button.Text));
            service.SeatsDataUpdate(trainId, carNumber, date.Date.ToString()); //Перенести в успешную регистрацию

            foreach (Control control in this.Controls)
            {
                if (control is Button && control != buttonAccept)
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

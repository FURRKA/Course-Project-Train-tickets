namespace GUI_Layer
{
    public partial class SeatCar : Form
    {
        public SeatCar(int carNumber, int distance)
        {
            InitializeComponent();
            label2.Text = $"Вагон №{carNumber}";
            label3.Text = $"Стоимость: {distance * 0.09}";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button1.BackColor = Color.LightBlue;
        }
    }
}

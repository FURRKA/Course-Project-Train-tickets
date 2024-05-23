using BIL.Services;
using DataLayer.Entity;

namespace GUI_Layer
{
    public partial class SeatCar : Form
    {
        private DataService service;
        private RouteService route;
        private List<int> seats;
        private int trainId;
        private int carNumber;
        public int SeatNumber { get; set; }
        private double totalCost;
        private DateTime date;
        private UserEnity user;
        public SeatCar(int trainId, int carNumber, int distance, double cost, DateTime date, DataService service, RouteService routeService, UserEnity user)
        {
            InitializeComponent();
            this.trainId = trainId;
            this.carNumber = carNumber;
            this.date = date;
            this.service = service;
            this.user = user;
            route = routeService;
            totalCost = distance * cost;

            Text = $"Вагон №{carNumber}";
            label2.Text = $"Вагон №{carNumber}";
            label3.Text = $"Стоимость: {totalCost:F2}";
            seats = service.SeatsList(trainId, carNumber, date.Date.ToString());

            foreach (var button in Controls.OfType<Button>().Where(b => b != buttonAccept &&
            seats.Contains(Convert.ToInt32(b.Text))))
            {
                button.BackColor = Color.Gray;
                button.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            button.Enabled = false;
            button.BackColor = Color.LightBlue;

            SeatNumber = Convert.ToInt32(button.Text);
            label1.Text = $"Место №{SeatNumber}";

            seats.Add(SeatNumber);

            foreach (var buttons in Controls.OfType<Button>().Where(b => b != buttonAccept))
            {
                buttons.Enabled = false;
            }
            buttonAccept.Enabled = true;
        }

        private void buttonAccept_Click(object sender, EventArgs e)
        {
            var clientFillForm = new ClientFillForm(user, trainId, carNumber, "Сидячий", totalCost, SeatNumber, date,
                route.StartStation, route.FinalStation,
                route.FindStationTime(route.RouteId, route.StartStation),
                route.FindStationTime(route.RouteId, route.FinalStation));
            if (clientFillForm.ShowDialog() == DialogResult.OK)
            {
                service.SeatsDataUpdate(trainId, carNumber, date.Date.ToString());
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                seats.RemoveAt(seats.Count - 1);
                Close();
            }
        }
    }
}

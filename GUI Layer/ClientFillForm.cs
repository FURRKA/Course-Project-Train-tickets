using DataLayer.Entity;

namespace GUI_Layer
{
    public partial class ClientFillForm : Form
    {
        private UserEnity user;
        private int trainId;
        private int carNumber;
        private string carType;
        private double cost;
        private int seatNumber;
        private DateTime date;
        private string startStation;
        private string finalStation;
        private string timeStartStation;
        private string timeFinalStation;

        public ClientFillForm(UserEnity user, int trainId, int carNumber, string carType, double cost, int seatNumber, DateTime date, string startStation, string finalStation, string timeStartStation, string timeFinalStation)
        {
            InitializeComponent();
            this.user = user;
            this.trainId = trainId;
            this.carNumber = carNumber;
            this.carType = carType;
            this.cost = cost;
            this.seatNumber = seatNumber;
            this.date = date;
            this.startStation = startStation;
            this.finalStation = finalStation;
            this.timeStartStation = timeStartStation;
            this.timeFinalStation = timeFinalStation;

            datalabel.Text = $"ФИО: {user.Name} {user.LastName} {user.SurName}\n" +
                $"Пасспорт: {user.Passport}\n" +
                $"Поезд: {trainId}\nВагон {carNumber}  Тип {carType}  Место {seatNumber}\n" +
                $"Дата: {date}\n" +
                $"Начальная станция: {startStation}\nОтправление {timeStartStation}\n" +
                $"Конечная стацния: {finalStation}\nПрибытие {timeFinalStation}\n" +
                $"Стоимость: {cost:F2} BYN";
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}

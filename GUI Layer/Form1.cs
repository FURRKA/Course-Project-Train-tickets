using BIL.Services;
using DataLayer.Entity;

namespace GUI_Layer
{
    public partial class Form1 : Form
    {
        private RouteService routeService;
        private DataService dataService;
        private PaymentService paymentService;
        private UserEnity user;
        private bool isColumnAdded = false;
        private bool cancelColumndAdded = false;
        private bool eventAdded = false;
        public Form1(string path, UserEnity user)
        {
            InitializeComponent();
            routeService = new RouteService(path);
            dataService = new DataService(path);
            paymentService = new PaymentService(path);

            dateTimePicker1.MinDate = DateTime.Now;
            dateTimePicker1.MaxDate = DateTime.Now + TimeSpan.FromDays(60);
            this.user = user;

            tabControl1.ItemSize = new Size(tabControl1.Size.Width / tabControl1.TabPages.Count - 1, tabControl1.ItemSize.Height);

            routeService.StationsNames().ForEach(name => comboBox1.Items.Add(name));
            routeService.StationsNames().ForEach(name => comboBox2.Items.Add(name));
            dataService.DeleteNonPaidTickets();

            label10.Text = $"ФИО: {user.Name} {user.LastName} {user.SurName}\n" +
                $"Паспорт: {user.Passport}\nEmail: {user.Email}";

            var cancelButton = new DataGridViewButtonColumn { HeaderText = "Отмена", Text = "Отменить", UseColumnTextForButtonValue = true };

            if (dataService.HasOrders)
            {
                bool unPaidTickets = dataService.UserHasUnpaidOrders(user.Id);
                bool paidTickets = dataService.UserHasOrders(user.Id);

                paymentBasketGrid.Visible = unPaidTickets;
                orderGrid.Visible = paidTickets;

                ordersLabel.Visible = !paidTickets;
                bagLabel.Visible = !unPaidTickets;
                button3.Enabled = unPaidTickets;

                paymentBasketGrid.DataSource = dataService.GetTickets(user.Id).Where(ticket => !ticket.Paid)
                    .Select(item => new
                    {
                        Заказ = item.Id,
                        Поезд = item.TrainId,
                        Тип = item.CarType,
                        НомерВагона = item.CarNumber,
                        Место = item.SeatNumber,
                        Стоимость = item.TotalCost,
                        Дата = item.Date,
                        НачальнаяСтанция = item.StartStation,
                        Отправление = item.DepartTime,
                        КонечнаяСтанция = item.FinalStation,
                        Прибытие = item.ArriveTime
                    }).ToList();

                orderGrid.DataSource = dataService.GetTickets(user.Id).Where(ticket => ticket.Paid)
                    .Select(item => new
                    {
                        Заказ = item.Id,
                        Поезд = item.TrainId,
                        Тип = item.CarType,
                        НомерВагона = item.CarNumber,
                        Место = item.SeatNumber,
                        Стоимость = item.TotalCost,
                        Дата = item.Date,
                        НачальнаяСтанция = item.StartStation,
                        Отправление = item.DepartTime,
                        КонечнаяСтанция = item.FinalStation,
                        Прибытие = item.ArriveTime
                    }).ToList();


                if (!cancelColumndAdded && paidTickets)
                {
                    cancelColumndAdded = true;
                    orderGrid.Columns.Add(cancelButton);
                }

            }

            orderGrid.CellContentClick += (sender, e) =>
            {
                if (orderGrid.Columns[e.ColumnIndex].HeaderText == cancelButton.HeaderText)
                {
                    dataService.CancelTicket(user.Id, (int)orderGrid[1, e.RowIndex].Value, paymentService);
                    orderGrid.DataSource = orderGrid.DataSource = dataService.GetTickets(user.Id).Where(ticket => ticket.Paid)
                    .Select(item => new
                    {
                        Заказ = item.Id,
                        Поезд = item.TrainId,
                        Тип = item.CarType,
                        НомерВагона = item.CarNumber,
                        Место = item.SeatNumber,
                        Стоимость = item.TotalCost,
                        Дата = item.Date,
                        НачальнаяСтанция = item.StartStation,
                        Отправление = item.DepartTime,
                        КонечнаяСтанция = item.FinalStation,
                        Прибытие = item.ArriveTime
                    }).ToList();
                    orderGrid.Visible = dataService.UserHasOrders(user.Id);
                    ordersLabel.Visible = !dataService.UserHasOrders(user.Id);
                }
            };
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label7.Text = "Маршруты";
            var resultRoutes = routeService.FindRoute(comboBox1.Text, comboBox2.Text)
                .ToList();

            if (resultRoutes.Count > 0)
            {
                routeGrid.Visible = true;
                routeGrid.Columns.Clear();
                routeGrid.DataSource = resultRoutes.Select(item => new { Маршрут = item.RouteName }).ToList();

                if (!isColumnAdded)
                {
                    var informationButtonsColumn = new DataGridViewButtonColumn { HeaderText = "Информация", Text = "Станции", UseColumnTextForButtonValue = true };
                    var activeButtonsColumn = new DataGridViewButtonColumn { HeaderText = "Действие", Text = "Выбрать", UseColumnTextForButtonValue = true };
                    var selectButtonsColumn = new DataGridViewButtonColumn { HeaderText = "Выбрать", Text = "Выбрать", UseColumnTextForButtonValue = true };

                    if (!eventAdded)
                    {
                        routeGrid.CellContentClick += (sender, e) =>
                        {
                            if (routeGrid.Columns[e.ColumnIndex].HeaderText == informationButtonsColumn.HeaderText)
                            {
                                routeService.RouteId = resultRoutes[e.RowIndex].Id;
                                var info = new StaitonsInRouteForm(resultRoutes[e.RowIndex].RouteName, routeService.StationsInRoute());
                                info.ShowDialog();
                            }
                            if (routeGrid.Columns[e.ColumnIndex].HeaderText == selectButtonsColumn.HeaderText)
                            {
                                int dist = routeService.GetRouteDistance();
                                var car = new SeatCar(routeService.TrainId, (int)routeGrid[0, e.RowIndex].Value, dist, routeService.Cost, dateTimePicker1.Value, dataService, routeService, user);
                                if (car.ShowDialog() == DialogResult.OK)
                                {
                                    dataService.CreateOrder(user, routeService.TrainId, routeGrid[1, e.RowIndex].Value.ToString(), (int)routeGrid[0, e.RowIndex].Value, car.SeatNumber, dist * routeService.Cost,
                                        dateTimePicker1.Value.Date, routeService.StartStation, routeService.FinalStation, routeService.FindStationTime(routeService.RouteId, routeService.StartStation),
                                        routeService.FindStationTime(routeService.RouteId, routeService.FinalStation));



                                    paymentBasketGrid.Visible = true;
                                    bagLabel.Visible = false;
                                    button3.Enabled = true;

                                    paymentBasketGrid.DataSource = dataService.GetTickets(user.Id).Where(ticket => !ticket.Paid)
                                    .Select(item => new
                                    {
                                        Заказ = item.Id,
                                        Поезд = item.TrainId,
                                        Тип = item.CarType,
                                        НомерВагона = item.CarNumber,
                                        Место = item.SeatNumber,
                                        Стоимость = item.TotalCost,
                                        Дата = item.Date,
                                        НачальнаяСтанция = item.StartStation,
                                        Отправление = item.DepartTime,
                                        КонечнаяСтанция = item.FinalStation,
                                        Прибытие = item.ArriveTime
                                    }).ToList();
                                }
                            }
                            if (routeGrid.Columns[e.ColumnIndex].HeaderText == activeButtonsColumn.HeaderText)
                            {
                                routeService.RouteId = resultRoutes[e.RowIndex].Id;
                                routeService.GetTrainId();
                                routeGrid.Columns.Clear();

                                routeGrid.DataSource = dataService.GetCarsInfo(routeService.TrainId)
                                    .Select(item => new { Номер = item.Number, Тип = item.Type }).ToList();
                                routeGrid.Columns.Add(selectButtonsColumn);
                                label7.Text = "Выбор вагона";
                                isColumnAdded = false;
                            }
                        };
                    }

                    routeGrid.Columns.AddRange(informationButtonsColumn, activeButtonsColumn);
                    isColumnAdded = true;
                    eventAdded = true;
                    label8.Visible = false;
                }
                tabControl1.SelectedIndex = 1;
            }
            else
            {
                routeGrid.Visible = false;
                label7.Text = "Маршруты";
                label8.Visible = true;
                routeGrid.DataSource = null;
                tabControl1.SelectedIndex = 1;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (dataService.DeleteNonPaidTickets())
            {
                paymentBasketGrid.DataSource = null;
                paymentBasketGrid.DataSource = dataService.GetTickets(user.Id).Where(ticket => !ticket.Paid)
                    .Select(item => new
                    {
                        Заказ = item.Id,
                        Поезд = item.TrainId,
                        Тип = item.CarType,
                        НомерВагона = item.CarNumber,
                        Место = item.SeatNumber,
                        Стоимость = item.TotalCost,
                        Дата = item.Date,
                        НачальнаяСтанция = item.StartStation,
                        Отправление = item.DepartTime,
                        КонечнаяСтанция = item.FinalStation,
                        Прибытие = item.ArriveTime
                    }).ToList();

                if (!dataService.UserHasUnpaidOrders(user.Id))
                {
                    paymentBasketGrid.Visible = false;
                    bagLabel.Visible = true;
                    button3.Enabled = false;
                }
            }
        }

        private void UpdateComboBoxes(Object sender, EventArgs e)
        {
            var comboBoxes = tabControl1.TabPages[0].Controls.OfType<ComboBox>();
            button1.Enabled = comboBoxes.All(cb => cb.SelectedItem != null && !string.IsNullOrWhiteSpace(cb.Text));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var orders = dataService.GetTickets(user.Id).Where(t => !t.Paid).ToList();
            var id = orders.Select(or => or.Id).ToList();
            double totalCost = orders.Sum(t => t.TotalCost);

            var payForm = new PayForm(paymentService, totalCost, $"Заказ №{orders[0].Id}\nК оплате: {totalCost:F2}");
            if (payForm.ShowDialog() == DialogResult.OK)
            {
                dataService.ChangePaidStatus(user.Id, id, payForm.CardNumber, payForm.CVC);
                paymentBasketGrid.DataSource = null;
                paymentBasketGrid.Visible = false;
                bagLabel.Visible = true;

                ordersLabel.Visible = false;
                orderGrid.Visible = true;

                orderGrid.DataSource = dataService.GetTickets(user.Id).Where(ticket => ticket.Paid)
                    .Select(item => new
                    {
                        Заказ = item.Id,
                        Поезд = item.TrainId,
                        Тип = item.CarType,
                        НомерВагона = item.CarNumber,
                        Место = item.SeatNumber,
                        Стоимость = item.TotalCost,
                        Дата = item.Date,
                        НачальнаяСтанция = item.StartStation,
                        Отправление = item.DepartTime,
                        КонечнаяСтанция = item.FinalStation,
                        Прибытие = item.ArriveTime
                    }).ToList();

                var cancelButton = new DataGridViewButtonColumn { HeaderText = "Отмена", Text = "Отменить", UseColumnTextForButtonValue = true };
                if (!cancelColumndAdded)
                {
                    cancelColumndAdded = true;
                    orderGrid.Columns.Add(cancelButton);
                }
            }
        }

        private void deleteAccount_Click(object sender, EventArgs e)
        {
            if (dataService.UserHasOrders(user.Id))
                MessageBox.Show("У вас есть активные заказы. Удаление аккаунта доступно при отсутвии заказов", "Операция запрещена", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                var result = MessageBox.Show("Вы уверены в удалении своего аккаунта?\nДля использования приложением потребуется заново создать аккаунт!", "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    dataService.DeleteUser(user.Id);
                    DialogResult = DialogResult.Abort;
                    Close();
                }
            }
        }
    }
}
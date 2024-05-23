using BIL.Services;
using DataLayer.Entity;
using System.Reflection;

namespace GUI_Layer
{
    public partial class Form1 : Form
    {
        private RouteService routeService;
        private DataService dataService;
        private UserEnity user;
        private bool isColumnAdded = false;
        private bool eventAdded = false;
        public Form1(string path, UserEnity user)
        {
            InitializeComponent();
            routeService = new RouteService(path);
            dataService = new DataService(path);
            dateTimePicker1.MinDate = DateTime.Now;
            dateTimePicker1.MaxDate = DateTime.Now + TimeSpan.FromDays(60);
            this.user = user;

            tabControl1.ItemSize = new Size(tabControl1.Size.Width / tabControl1.TabPages.Count - 1, tabControl1.ItemSize.Height);

            routeService.StationsNames().ForEach(name => comboBox1.Items.Add(name));
            routeService.StationsNames().ForEach(name => comboBox2.Items.Add(name));

            label10.Text = $"ФИО: {user.Name} {user.LastName} {user.SurName}\n" +
                $"Пасспорт: {user.Passport}\nEmail: {user.Email}";

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
                                        dateTimePicker1.Value, routeService.StartStation, routeService.FinalStation, routeService.FindStationTime(routeService.RouteId, routeService.StartStation),
                                        routeService.FindStationTime(routeService.RouteId, routeService.FinalStation));
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
                                label7.Text = "Выбор места";
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
                routeGrid.Visible=false;
                label7.Text = "Маршруты";
                label8.Visible = true;
                routeGrid.DataSource = null;
                tabControl1.SelectedIndex = 1;
            }
        }
    }
}
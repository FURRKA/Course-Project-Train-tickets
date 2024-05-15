using BIL.Services;

namespace GUI_Layer
{
    public partial class Form1 : Form
    {
        private RouteService routeService;
        private bool isColumnAdded = false;
        public Form1()
        {
            string path = "Data Source=D:\\GSTU\\ЯПВУ\\Course Project Train tickets\\DataLayer\\DB_CourseWork.db";
            InitializeComponent();
            routeService = new RouteService(path);
            dateTimePicker1.MinDate = DateTime.Now;
            dateTimePicker1.MaxDate = DateTime.Now + TimeSpan.FromDays(60);

            tabControl1.ItemSize = new Size(tabControl1.Size.Width / tabControl1.TabPages.Count - 1, tabControl1.ItemSize.Height);

            routeService.StationsNames().ForEach(name => comboBox1.Items.Add(name));
            routeService.StationsNames().ForEach(name => comboBox2.Items.Add(name));

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var resultRoutes = routeService.FindRoute(comboBox1.Text, comboBox2.Text)
                .ToList();

            if (resultRoutes.Count > 0)
            {
                routeGrid.Visible = true;
                routeGrid.DataSource = resultRoutes.Select(item => new { Маршрут = item.RouteName }).ToList();
                if (!isColumnAdded)
                {
                    var informationButtonsColumn = new DataGridViewButtonColumn { HeaderText = "Информация", Text = "Станции", UseColumnTextForButtonValue = true };
                    var activeButtonsCilumn = new DataGridViewButtonColumn { HeaderText = "Действие", Text = "Выбрать", UseColumnTextForButtonValue = true };
                    routeGrid.CellContentClick += (sender, e) =>
                    {
                        if (routeGrid.Columns[e.ColumnIndex].HeaderText == informationButtonsColumn.HeaderText)
                        {
                            routeService.RouteId = resultRoutes[e.RowIndex].Id;
                            var info = new StaitonsInRouteForm(routeService.StationsInRoute());
                            info.Show();
                        }
                        if (routeGrid.Columns[e.ColumnIndex].HeaderText == activeButtonsCilumn.HeaderText)
                        {
                            routeService.RouteId = resultRoutes[e.RowIndex].Id;
                            int dist = routeService.GetRouteDistance();
                            var car = new SeatCar(2, dist);
                            car.ShowDialog();
                        }
                    };
                    routeGrid.Columns.AddRange(informationButtonsColumn, activeButtonsCilumn);
                    isColumnAdded = true;
                    label8.Visible = false;
                }
                tabControl1.SelectedIndex = 1;
            }
            else
            {
                routeGrid.Visible=false;
                label8.Visible = true;
                tabControl1.SelectedIndex = 1;
            }
        }
    }
}
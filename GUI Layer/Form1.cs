using BIL.Services;
using System.Windows.Forms;

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
                .Select(item => new { Маршрут = item.RouteName })
                .ToList();

            if (resultRoutes.Count > 0)
            {
                routeGrid.Visible = true;
                routeGrid.DataSource = resultRoutes;
                if (!isColumnAdded)
                {
                    var informationButtonsColumn = new DataGridViewButtonColumn { HeaderText = "Информация", Text = "Станции", UseColumnTextForButtonValue = true };
                    routeGrid.CellContentClick += (sender, e) =>
                    {
                        if (routeGrid.Columns[e.ColumnIndex].Name == informationButtonsColumn.HeaderText)
                        {
                            MessageBox.Show("Привет!");
                        }
                    };
                    routeGrid.Columns.Add(informationButtonsColumn);
                    isColumnAdded = true;
                    label8.Visible = false;
                }
                tabControl1.SelectedIndex = 1;
            }
            else
            {
                routeGrid.Visible=false;
                label8.Visible = true;
            }

        }
    }
}
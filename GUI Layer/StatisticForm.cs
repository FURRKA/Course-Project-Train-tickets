using BIL.Services;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GUI_Layer
{
    public partial class StatisticForm : Form
    {
        private StatisticService service;
        private RouteService routeService;
        public StatisticForm(StatisticService service, RouteService route)
        {
            InitializeComponent();
            this.service = service;
            routeService = route;
            chart1.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chart1.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
            chart2.Series[0]["PieLabelStyle"] = "Disabled";

            chart2.ChartAreas[0].Area3DStyle.Enable3D = true;
            dateTimePicker1.Value = dateTimePicker2.Value = DateTime.Now;

            SelectStatisticData();
            SelectRouteStatisticData();           
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e) => SelectStatisticData();

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e) => SelectRouteStatisticData();
        private void SelectStatisticData()
        {
            var year = dateTimePicker1.Value.Year;
            var statistic = service.GetStatistic(year)
                .OrderBy(s => s.Month)
                .Select(s => s.Revenue)
                .ToList();


            while (statistic.Count < 12)
                statistic.Add(0);

            chart1.Series[0].Points.Clear();
            chart1.ChartAreas[0].AxisY.Maximum = statistic.Max() + 20;
            chart1.Titles[0].Text = $"Доходы за {year} год";
            chart1.Series[0].Points.DataBindXY(Enumerable.Range(1, 12).ToList(), statistic);
        }

        private void SelectRouteStatisticData()
        {
            var year = dateTimePicker2.Value.Year;
            var month = dateTimePicker2.Value.Month;

            var statistic = service.GetRouteStatistic(month, year)
                .Select(item => item.SelectCount)
                .ToList();

            if (statistic.Count > 0)
            {
                while (routeService.RouteCount() > statistic.Count)
                    statistic.Add(0);

                RouteInfoLabal.Visible = false;
                chart2.Series[0].Points.DataBindXY(routeService.GetRoutesNames(), statistic);
                chart2.Visible = true;
            }
            else
            {
                RouteInfoLabal.Text = $"Нету статистики маршрутов\nза {(Month)month} {year} года";
                RouteInfoLabal.Visible = true;
                chart2.Visible = false;
            }
        }
    }
}

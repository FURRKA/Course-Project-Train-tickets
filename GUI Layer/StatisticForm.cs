using BIL.Services;
using DataLayer.Repository;
using System.Windows.Forms.DataVisualization.Charting;

namespace GUI_Layer
{
    public partial class StatisticForm : Form
    {
        private StatisticService service;
        public StatisticForm(StatisticService service)
        {
            InitializeComponent();
            this.service = service;

            var data = new List<double>() { 4, 3.2, 10, 2, 1 };
            var names = new List<string>() { "station1", "station2", "station3", "station4", "station5" };
            var dohods = new List<double>() { 3.3, 3.1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            var id = Enumerable.Range(1, 12).ToList();

            chart1.Series[0].Points.DataBindXY(id, dohods);
            chart1.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chart1.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
            
            dateTimePicker1.Value = dateTimePicker2.Value = DateTime.Now;
            chart2.ChartAreas[0].Area3DStyle.Enable3D = true;
            chart2.Series[0].Points.DataBindXY(names, data);
        }
    }
}

namespace GUI_Layer
{
    public partial class StaitonsInRouteForm : Form
    {
        public StaitonsInRouteForm(List<dynamic> data)
        {
            InitializeComponent();
            routeGrid.DataSource = data;
        }
    }
}

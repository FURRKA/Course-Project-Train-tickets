namespace GUI_Layer
{
    public partial class StaitonsInRouteForm : Form
    {
        public StaitonsInRouteForm(string routeName, List<dynamic> data)
        {
            InitializeComponent();
            routeGrid.DataSource = data;
            Text = routeName;
        }
    }
}

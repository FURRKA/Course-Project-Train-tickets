using DataLayer.Repository;
using System.Text;

namespace GUI_Layer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            string path = "Data Source=D:\\GSTU\\ßÏÂÓ\\Course Project Train tickets\\DataLayer\\DB_CourseWork.db";
            InitializeComponent();
            var stations = new StationsRepository(path);
            stations.Read();

            stations.Data.ForEach(x => comboBox1.Items.Add(x.Name));
        }
    }
}
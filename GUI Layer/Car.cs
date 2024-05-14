using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace GUI_Layer
{
    public partial class Car : Form
    {
        public Car(int carNumber, int distance)
        {
            InitializeComponent();
            label2.Text = $"Вагон №{carNumber}";
            label3.Text = $"Стоимость: {distance * 3.45}";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button1.BackColor = Color.LightBlue;
        }
    }
}

﻿using BIL.Services;
using System.Text.Json.Serialization;

namespace GUI_Layer
{
    public partial class PayForm : Form
    {
        private PaymentService service;
        private double totalCost;
        public PayForm(PaymentService service, double totalCost)
        {
            InitializeComponent();
            this.service = service;
            this.totalCost = totalCost;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Int64 number = Convert.ToInt64(textBox1.Text);
            int cvc = Convert.ToInt32(textBox2.Text);

            if (service.CardExist(number, cvc))
            {
                if (service.WithdrawBalance(number, cvc, totalCost))
                {
                    MessageBox.Show("Оплата успешно прошла");
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                    MessageBox.Show("Недостаточно средств");

            }
            else
                MessageBox.Show("Карты с таким номером нет в системе");            
        }

        private void Update(object sender, EventArgs e)
        {
            var textBoxses = Controls.OfType<TextBox>();
            button1.Enabled = textBoxses.All(t => t.Text != "" && textBox1.Text.Length == 16 && textBox2.Text.Length == 3);
        }
    }
}
namespace GUI_Layer
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.label8 = new System.Windows.Forms.Label();
            this.routeGrid = new System.Windows.Forms.DataGridView();
            this.label7 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.ordersLabel = new System.Windows.Forms.Label();
            this.orderGrid = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.deleteAccount = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.bagLabel = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.paymentBasketGrid = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.routeGrid)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.orderGrid)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.paymentBasketGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.ItemSize = new System.Drawing.Size(61, 20);
            this.tabControl1.Location = new System.Drawing.Point(-4, -1);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(390, 453);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.dateTimePicker1);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.comboBox2);
            this.tabPage1.Controls.Add(this.comboBox1);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.tabPage1.Location = new System.Drawing.Point(4, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(382, 425);
            this.tabPage1.TabIndex = 3;
            this.tabPage1.Text = "Поиск";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.button1.Enabled = false;
            this.button1.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button1.ForeColor = System.Drawing.SystemColors.Control;
            this.button1.Location = new System.Drawing.Point(12, 255);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(355, 55);
            this.button1.TabIndex = 8;
            this.button1.Text = "Найти";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(12, 188);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(180, 22);
            this.label4.TabIndex = 7;
            this.label4.Text = "Дата отправления";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CalendarFont = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dateTimePicker1.CalendarMonthBackground = System.Drawing.SystemColors.Info;
            this.dateTimePicker1.Location = new System.Drawing.Point(12, 213);
            this.dateTimePicker1.MinDate = new System.DateTime(2024, 5, 12, 0, 0, 0, 0);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(208, 23);
            this.dateTimePicker1.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(12, 126);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 22);
            this.label3.TabIndex = 5;
            this.label3.Text = "Куда";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(12, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 22);
            this.label2.TabIndex = 4;
            this.label2.Text = "Откуда";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(12, 151);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(355, 23);
            this.comboBox2.TabIndex = 3;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.UpdateComboBoxes);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(12, 93);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(355, 23);
            this.comboBox1.TabIndex = 2;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.UpdateComboBoxes);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(12, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(363, 30);
            this.label1.TabIndex = 1;
            this.label1.Text = "Куда Вы собираетесь ехать?";
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.label8);
            this.tabPage5.Controls.Add(this.routeGrid);
            this.tabPage5.Controls.Add(this.label7);
            this.tabPage5.Location = new System.Drawing.Point(4, 4);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(382, 425);
            this.tabPage5.TabIndex = 7;
            this.tabPage5.Text = "Маршруты";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(43, 161);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(295, 30);
            this.label8.TabIndex = 8;
            this.label8.Text = "Маршурты не найдены";
            // 
            // routeGrid
            // 
            this.routeGrid.AllowUserToAddRows = false;
            this.routeGrid.AllowUserToDeleteRows = false;
            this.routeGrid.BackgroundColor = System.Drawing.Color.White;
            this.routeGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.routeGrid.Location = new System.Drawing.Point(0, 36);
            this.routeGrid.Name = "routeGrid";
            this.routeGrid.ReadOnly = true;
            this.routeGrid.RowTemplate.Height = 25;
            this.routeGrid.Size = new System.Drawing.Size(382, 389);
            this.routeGrid.TabIndex = 6;
            this.routeGrid.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(111, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(145, 30);
            this.label7.TabIndex = 5;
            this.label7.Text = "Маршруты";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.ordersLabel);
            this.tabPage2.Controls.Add(this.orderGrid);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Location = new System.Drawing.Point(4, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(382, 425);
            this.tabPage2.TabIndex = 4;
            this.tabPage2.Text = "Заказы";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // ordersLabel
            // 
            this.ordersLabel.AutoSize = true;
            this.ordersLabel.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ordersLabel.Location = new System.Drawing.Point(24, 200);
            this.ordersLabel.Name = "ordersLabel";
            this.ordersLabel.Size = new System.Drawing.Size(343, 30);
            this.ordersLabel.TabIndex = 9;
            this.ordersLabel.Text = "Нету действующих билетов";
            // 
            // orderGrid
            // 
            this.orderGrid.BackgroundColor = System.Drawing.Color.White;
            this.orderGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.orderGrid.Location = new System.Drawing.Point(0, 39);
            this.orderGrid.Name = "orderGrid";
            this.orderGrid.RowTemplate.Height = 25;
            this.orderGrid.Size = new System.Drawing.Size(382, 386);
            this.orderGrid.TabIndex = 3;
            this.orderGrid.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(138, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 30);
            this.label5.TabIndex = 2;
            this.label5.Text = "Заказы";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.deleteAccount);
            this.tabPage3.Controls.Add(this.label11);
            this.tabPage3.Controls.Add(this.label10);
            this.tabPage3.Controls.Add(this.label9);
            this.tabPage3.Location = new System.Drawing.Point(4, 4);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(382, 425);
            this.tabPage3.TabIndex = 5;
            this.tabPage3.Text = "Профиль";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // deleteAccount
            // 
            this.deleteAccount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.deleteAccount.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.deleteAccount.ForeColor = System.Drawing.SystemColors.Control;
            this.deleteAccount.Location = new System.Drawing.Point(12, 371);
            this.deleteAccount.Name = "deleteAccount";
            this.deleteAccount.Size = new System.Drawing.Size(355, 37);
            this.deleteAccount.TabIndex = 9;
            this.deleteAccount.Text = "Удалить аккаунт";
            this.deleteAccount.UseVisualStyleBackColor = false;
            this.deleteAccount.Click += new System.EventHandler(this.deleteAccount_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label11.Location = new System.Drawing.Point(12, 44);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(143, 22);
            this.label11.TabIndex = 8;
            this.label11.Text = "Информация";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label10.Location = new System.Drawing.Point(12, 77);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(50, 21);
            this.label10.TabIndex = 7;
            this.label10.Text = "data";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label9.Location = new System.Drawing.Point(120, 6);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(126, 30);
            this.label9.TabIndex = 6;
            this.label9.Text = "Профиль";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.bagLabel);
            this.tabPage4.Controls.Add(this.button3);
            this.tabPage4.Controls.Add(this.paymentBasketGrid);
            this.tabPage4.Controls.Add(this.label6);
            this.tabPage4.Location = new System.Drawing.Point(4, 4);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(382, 425);
            this.tabPage4.TabIndex = 6;
            this.tabPage4.Text = "Корзина";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // bagLabel
            // 
            this.bagLabel.AutoSize = true;
            this.bagLabel.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.bagLabel.Location = new System.Drawing.Point(20, 197);
            this.bagLabel.Name = "bagLabel";
            this.bagLabel.Size = new System.Drawing.Size(338, 30);
            this.bagLabel.TabIndex = 10;
            this.bagLabel.Text = "Нету действующих заказов";
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.button3.Enabled = false;
            this.button3.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(0, 376);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(382, 46);
            this.button3.TabIndex = 7;
            this.button3.Text = "Оплатить";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // paymentBasketGrid
            // 
            this.paymentBasketGrid.BackgroundColor = System.Drawing.Color.White;
            this.paymentBasketGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.paymentBasketGrid.Location = new System.Drawing.Point(0, 36);
            this.paymentBasketGrid.Name = "paymentBasketGrid";
            this.paymentBasketGrid.RowTemplate.Height = 25;
            this.paymentBasketGrid.Size = new System.Drawing.Size(382, 343);
            this.paymentBasketGrid.TabIndex = 6;
            this.paymentBasketGrid.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(138, 3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(114, 30);
            this.label6.TabIndex = 5;
            this.label6.Text = "Корзина";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 60000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(381, 450);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.Text = "Поиск билетов";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.routeGrid)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.orderGrid)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.paymentBasketGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private Label label1;
        private TabPage tabPage3;
        private ComboBox comboBox1;
        private Label label4;
        private DateTimePicker dateTimePicker1;
        private Label label3;
        private Label label2;
        private ComboBox comboBox2;
        private Button button1;
        private DataGridView orderGrid;
        private Label label5;
        private TabPage tabPage4;
        private Button button3;
        private DataGridView paymentBasketGrid;
        private Label label6;
        private TabPage tabPage5;
        private DataGridView routeGrid;
        private Label label7;
        private Label label8;
        private Label ordersLabel;
        private Label bagLabel;
        private Label label10;
        private Label label9;
        private Label label11;
        private System.Windows.Forms.Timer timer1;
        private Button deleteAccount;
    }
}
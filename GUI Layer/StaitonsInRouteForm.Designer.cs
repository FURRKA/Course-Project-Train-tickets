namespace GUI_Layer
{
    partial class StaitonsInRouteForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.routeGrid = new System.Windows.Forms.DataGridView();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.routeGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // routeGrid
            // 
            this.routeGrid.AllowUserToAddRows = false;
            this.routeGrid.AllowUserToDeleteRows = false;
            this.routeGrid.BackgroundColor = System.Drawing.Color.White;
            this.routeGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.routeGrid.Location = new System.Drawing.Point(-3, 35);
            this.routeGrid.Name = "routeGrid";
            this.routeGrid.ReadOnly = true;
            this.routeGrid.RowHeadersVisible = false;
            this.routeGrid.RowTemplate.Height = 25;
            this.routeGrid.Size = new System.Drawing.Size(355, 395);
            this.routeGrid.TabIndex = 8;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(47, 2);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(273, 30);
            this.label7.TabIndex = 7;
            this.label7.Text = "Станции в маршруте";
            // 
            // StaitonsInRouteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(349, 428);
            this.Controls.Add(this.routeGrid);
            this.Controls.Add(this.label7);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "StaitonsInRouteForm";
            this.Text = "StaitonsInRouteForm";
            ((System.ComponentModel.ISupportInitialize)(this.routeGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataGridView routeGrid;
        private Label label7;
    }
}
namespace TESTSH
{
    partial class Form2
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numberYears = new System.Windows.Forms.TextBox();
            this.numberMonth = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.tableOperations = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.balance = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.chartBalance = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.tableOperations)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartBalance)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Год";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(101, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Месяц";
            // 
            // numberYears
            // 
            this.numberYears.Location = new System.Drawing.Point(43, 12);
            this.numberYears.Name = "numberYears";
            this.numberYears.Size = new System.Drawing.Size(41, 20);
            this.numberYears.TabIndex = 2;
            this.numberYears.Text = "1";
            // 
            // numberMonth
            // 
            this.numberMonth.Location = new System.Drawing.Point(147, 12);
            this.numberMonth.Name = "numberMonth";
            this.numberMonth.Size = new System.Drawing.Size(44, 20);
            this.numberMonth.TabIndex = 3;
            this.numberMonth.Text = "0";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(213, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(121, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Показать отчет";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tableOperations
            // 
            this.tableOperations.AllowUserToAddRows = false;
            this.tableOperations.AllowUserToDeleteRows = false;
            this.tableOperations.AllowUserToOrderColumns = true;
            this.tableOperations.AllowUserToResizeColumns = false;
            this.tableOperations.AllowUserToResizeRows = false;
            this.tableOperations.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tableOperations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableOperations.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column5,
            this.Column2,
            this.Column3,
            this.Column4});
            this.tableOperations.Location = new System.Drawing.Point(15, 104);
            this.tableOperations.Name = "tableOperations";
            this.tableOperations.RowHeadersVisible = false;
            this.tableOperations.Size = new System.Drawing.Size(363, 326);
            this.tableOperations.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(141, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Баланс на начало месяца:";
            // 
            // balance
            // 
            this.balance.AutoSize = true;
            this.balance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.balance.Location = new System.Drawing.Point(160, 51);
            this.balance.Name = "balance";
            this.balance.Size = new System.Drawing.Size(49, 13);
            this.balance.TabIndex = 7;
            this.balance.Text = "0 Coins";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 83);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Все операции";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 447);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "График баланса ";
            // 
            // chartBalance
            // 
            this.chartBalance.BackColor = System.Drawing.Color.Transparent;
            this.chartBalance.BorderlineColor = System.Drawing.Color.Black;
            chartArea1.Name = "Balance";
            this.chartBalance.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartBalance.Legends.Add(legend1);
            this.chartBalance.Location = new System.Drawing.Point(15, 472);
            this.chartBalance.Name = "chartBalance";
            this.chartBalance.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Berry;
            series1.ChartArea = "Balance";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartBalance.Series.Add(series1);
            this.chartBalance.Size = new System.Drawing.Size(363, 193);
            this.chartBalance.TabIndex = 10;
            this.chartBalance.Text = "chart1";
            // 
            // Column1
            // 
            this.Column1.HeaderText = "ID";
            this.Column1.Name = "Column1";
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Тип";
            this.Column5.Name = "Column5";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "С Кем";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Сумма";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Дата";
            this.Column4.Name = "Column4";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(390, 677);
            this.Controls.Add(this.chartBalance);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.balance);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tableOperations);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.numberMonth);
            this.Controls.Add(this.numberYears);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form2";
            this.Text = "Отчет";
            ((System.ComponentModel.ISupportInitialize)(this.tableOperations)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartBalance)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox numberYears;
        private System.Windows.Forms.TextBox numberMonth;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView tableOperations;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label balance;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartBalance;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
    }
}
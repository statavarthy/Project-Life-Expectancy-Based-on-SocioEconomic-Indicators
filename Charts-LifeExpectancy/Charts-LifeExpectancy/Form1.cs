using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization;
using System.Windows.Forms.DataVisualization.Charting;

namespace Project
{
    public partial class Form1 : Form
    {
        Chart pieChart;
        Chart barChart;
        public Form1()
        {
            InitializeComponent();
             InitializeChart();
        }
         private void InitializeChart()
        {

            this.components = new System.ComponentModel.Container();
            ChartArea chartArea1 = new ChartArea();
            Legend legend1 = new Legend() 
              { BackColor = Color.Green, ForeColor = Color.Black, Title = "Salary" };
            Legend legend2 = new Legend() 
              { BackColor = Color.Green, ForeColor = Color.Black, Title = "Salary" };
            pieChart = new Chart();
            barChart = new Chart();

            ((ISupportInitialize)(pieChart)).BeginInit();
            ((ISupportInitialize)(barChart)).BeginInit();

            SuspendLayout();

            //===Pie chart
            chartArea1.Name = "PieChartArea";
            pieChart.ChartAreas.Add(chartArea1);
            pieChart.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            pieChart.Legends.Add(legend1);
            pieChart.Location = new System.Drawing.Point(0, 50);

            //====Bar Chart
            chartArea1 = new ChartArea();
            chartArea1.Name = "BarChartArea";
            barChart.ChartAreas.Add(chartArea1);
            barChart.Dock = System.Windows.Forms.DockStyle.Fill;
            legend2.Name = "Legend3";
            barChart.Legends.Add(legend2);

            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            //this.ClientSize = new System.Drawing.Size(284, 262);           
            this.Load += new EventHandler(Form1_Load);
            ((ISupportInitialize)(this.pieChart)).EndInit();
            ((ISupportInitialize)(this.barChart)).EndInit();
            this.ResumeLayout(false);

        }

         void Form1_Load(object sender, EventArgs e)
        {
            LoadPieChart();
            LoadBarChart();
        }

        void LoadPieChart()
        {
            pieChart.Series.Clear();
            pieChart.Palette = ChartColorPalette.Fire;
            pieChart.BackColor = Color.LightYellow;
            pieChart.Titles.Add("Employee Salary");
            pieChart.ChartAreas[0].BackColor = Color.Transparent;
            Series series1 = new Series
            {
                Name = "series1",
                IsVisibleInLegend = true,
                Color = System.Drawing.Color.Green,
                ChartType = SeriesChartType.Pie
            };
            pieChart.Series.Add(series1);
            ParseData pd = new ParseData();
            string filePath = "..\\..\\..\\..\\Data\\";    
            string lifeExpectancyFilePath = filePath + "LifeExpectancy_Chicago.csv";
            Project.ParseData.lifeExpectancy[] lifeExpectancyData = pd.parselifeExpectancyData(lifeExpectancyFilePath);
            Console.WriteLine("sfasfsafsaf");
            
            series1.Points.Add(70000);
            series1.Points.Add(30000);
            var p1 = series1.Points[0];
            p1.AxisLabel = "70000";
            p1.LegendText = "Hiren Khirsaria";
            var p2 = series1.Points[1];
            p2.AxisLabel = "30000";
            p2.LegendText = "ABC XYZ";
            pieChart.Invalidate();
            panel1.Controls.Add(pieChart);
        }
        void LoadBarChart()
        {
            barChart.Series.Clear();
            barChart.BackColor = Color.LightYellow;           
            barChart.Palette = ChartColorPalette.Fire;
            barChart.ChartAreas[0].BackColor = Color.Transparent;
            barChart.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            barChart.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
            Series series = new Series
            {
                Name = "series2",
                IsVisibleInLegend = false,
                ChartType = SeriesChartType.Column
            };
            barChart.Series.Add(series);
            series.Points.Add(70000);
            var p1 = series.Points[0];
            p1.Color = Color.Red;
            p1.AxisLabel = "Hiren Khirsaria";
            p1.LegendText = "Hiren Khirsaria";
            p1.Label = "70000";
           
            series.Points.Add(30000);
            var p2 = series.Points[1];
            p2.Color = Color.Yellow;
            p2.AxisLabel = "ABC XYZ";
            p2.LegendText = "ABC XYZ";
            p2.Label = "30000";
            barChart.Invalidate();
            
            panel2.Controls.Add(barChart);
        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

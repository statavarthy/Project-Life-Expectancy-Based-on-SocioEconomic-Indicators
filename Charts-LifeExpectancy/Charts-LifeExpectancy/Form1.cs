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
         public void InitializeChart()
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

         public void Form1_Load(object sender, EventArgs e)
        {

            //LoadPieChart();
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
                                                                 
            pieChart.Invalidate();
            //panel1.Controls.Add(pieChart);
        }
        void LoadBarChart()
        {
            barChart.Series.Clear();
            barChart.BackColor = Color.PowderBlue;           
            barChart.Palette = ChartColorPalette.Fire;
            barChart.ChartAreas[0].BackColor = Color.Transparent;
            barChart.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            barChart.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
            barChart.ChartAreas[0].AxisX.LabelStyle.Angle = 45;
            barChart.ChartAreas[0].AxisX.LabelAutoFitMinFontSize = 5;
            barChart.ChartAreas[0].AxisX.IsStartedFromZero = true;
            barChart.ChartAreas[0].AxisX.LabelStyle.Interval= 1;
            barChart.ChartAreas[0].AxisX.Maximum = 79;
                       
            Series series = new Series
            {
                Name = "series2",
                IsVisibleInLegend = false,
                ChartType = SeriesChartType.Column
            };

            ParseData pd = new ParseData();
            string filePath = "..\\..\\..\\..\\Data\\";
            string lifeExpectancyFilePath = filePath + "LifeExpectancy_Chicago.csv";
            Project.ParseData.lifeExpectancy[] lifeExpectancyData = pd.parselifeExpectancyData(lifeExpectancyFilePath);
            double[] expectancy = new double[78];
            for (int k = 0; k < lifeExpectancyData.Length; k++)
            {
                expectancy[k] = Convert.ToDouble(lifeExpectancyData[k].expectancy);
            }
            for (int i = 0; i < lifeExpectancyData.Length; i++)
            {
                series.Points.Add(expectancy[i]);
                series.Points[i].Label = lifeExpectancyData[i].expectancy;                
                series.Points[i].AxisLabel = lifeExpectancyData[i].communityName;
                series.Points[i].Color = Color.Green;                               
            }
            series["PointWidth"] = (0.7).ToString();

            barChart.Series.Add(series);                                                          
            barChart.Invalidate();
            
            panel2.Controls.Add(barChart);
        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }
    }
}

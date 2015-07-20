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
    public partial class Form5 : Form
    {
        Chart barChart;
        public Form5()
        {
            InitializeComponent();
            InitializeChart();
        }

        public void InitializeChart()
        {

            this.components = new System.ComponentModel.Container();
            ChartArea chartArea1 = new ChartArea();
            Legend legend1 = new Legend() { BackColor = Color.Green, ForeColor = Color.Black, Title = "Salary" };
            Legend legend2 = new Legend() { BackColor = Color.Green, ForeColor = Color.Black, Title = "Salary" };
            barChart = new Chart();

            ((ISupportInitialize)(barChart)).BeginInit();

            SuspendLayout();
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
            this.Load += new EventHandler(Form5_Load);
            ((ISupportInitialize)(this.barChart)).EndInit();
            this.ResumeLayout(false);

        }

        private void Form5_Load(object sender, EventArgs e)
        {
            LoadBarChart();

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
            barChart.ChartAreas[0].AxisX.LabelStyle.Interval = 1;
            barChart.ChartAreas[0].AxisX.Maximum = 80;

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
            double[] expectancy_2010 = new double[78];
            double[] expectancy_2000 = new double[78];
            double[] expectancy_1990 = new double[78];
            for (int k = 0; k < lifeExpectancyData.Length; k++)
            {
                expectancy_2010[k] = Convert.ToDouble(lifeExpectancyData[k].expectancy);
            }
            for (int k = 0; k < lifeExpectancyData.Length; k++)
            {
                expectancy_2000[k] = Convert.ToDouble(lifeExpectancyData[k].expectancy_2000);
            }
            for (int k = 0; k < lifeExpectancyData.Length; k++)
            {
                expectancy_1990[k] = Convert.ToDouble(lifeExpectancyData[k].expectancy_1990);
            }
            for (int i = 0; i < lifeExpectancyData.Length; i++)
            {
                series.Points.Add(perCapitaIncome[i]);
                series.Points[i].Label = perCapitaIncome[i].ToString();
                series.Points[i].AxisLabel = socioEconomicData[i].communityName;
                series.Points[i].Color = Color.DarkSlateGray;
            }
            series["PointWidth"] = (0.7).ToString();

            barChart.Series.Add(series);
            barChart.Invalidate();

            panel1.Controls.Add(barChart);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

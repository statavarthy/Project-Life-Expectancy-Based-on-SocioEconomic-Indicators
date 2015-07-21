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
    public partial class PieChart_CommunityWise : Form
    {
        Chart pieChart;
        public PieChart_CommunityWise()
        {
            this.WindowState = FormWindowState.Maximized;
            int newWidth = 1400;
            InitializeComponent();
            panel1.MaximumSize = new Size(newWidth, panel1.Height);
            panel1.Size = new Size(newWidth, panel1.Height);
            InitializeChart();
        }
        public void InitializeChart()
        {

            this.components = new System.ComponentModel.Container();
            ChartArea chartArea1 = new ChartArea();
            Legend legend1 = new Legend() { BackColor = Color.Green, ForeColor = Color.Black, Title = "SocioEconomic Indicators" };

            pieChart = new Chart();


            ((ISupportInitialize)(pieChart)).BeginInit();


            SuspendLayout();

            //===Pie chart
            chartArea1.Name = "PieChartArea";
            pieChart.ChartAreas.Add(chartArea1);
            pieChart.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            pieChart.Legends.Add(legend1);
            pieChart.Location = new System.Drawing.Point(0, 50);

            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            //this.ClientSize = new System.Drawing.Size(284, 262);           
            this.Load += new EventHandler(Form1_Load);
            ((ISupportInitialize)(this.pieChart)).EndInit();
            
            this.ResumeLayout(false);
        }

        public void Form1_Load(object sender, EventArgs e)
        {

            LoadPieChart();
            
        }

        void LoadPieChart()
        {
            pieChart.Series.Clear();
            pieChart.BackColor = Color.AntiqueWhite;
            pieChart.Palette = ChartColorPalette.BrightPastel;
            pieChart.ChartAreas[0].BackColor = Color.Transparent;
            pieChart.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            pieChart.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
            pieChart.ChartAreas[0].AxisX.LabelStyle.Angle = 45;
            pieChart.ChartAreas[0].AxisX.LabelAutoFitMinFontSize = 5;
            pieChart.ChartAreas[0].AxisX.IsStartedFromZero = true;
            pieChart.ChartAreas[0].AxisX.LabelStyle.Interval = 1;
            pieChart.ChartAreas[0].AxisX.Maximum = 3;
            pieChart.ChartAreas[0].AxisY.Maximum = 100;
            pieChart.ChartAreas[0].AxisY.Title = "% Life Expectancy";
            pieChart.ChartAreas[0].AxisX.Title = "Year";

            Series series = new Series
            {
                Name = "series2",
                IsVisibleInLegend = false,
                ChartType = SeriesChartType.Pie
            };

            ParseData pd = new ParseData();
            string filePath = "..\\..\\..\\..\\Data\\";
            string SocioEconomicIndicatorsFilePath = filePath + "SocioEconomicIndicators.csv";
            Project.ParseData.SocioEconomicIndicators[] socioEconomicData = pd.parsesocioEconomicData(SocioEconomicIndicatorsFilePath);
            double[] housingCrowded = new double[78];
            double[] poverty = new double[78];
            double[] unemployment = new double[78];
            double[] noDiploma = new double[78];
            double[] under18over65 = new double[78];
            for (int k = 0; k < socioEconomicData.Length; k++)
            {
                poverty[k] = Convert.ToDouble(socioEconomicData[k].poverty);
            }
            for (int k = 0; k < socioEconomicData.Length; k++)
            {
                unemployment[k] = Convert.ToDouble(socioEconomicData[k].unemployment);
            }
            for (int k = 0; k < socioEconomicData.Length; k++)
            {
                noDiploma[k] = Convert.ToDouble(socioEconomicData[k].noDiploma);
            }
            for (int k = 0; k < socioEconomicData.Length; k++)
            {
                under18over65[k] = Convert.ToDouble(socioEconomicData[k].under18over65);
            }

            for (int i = 0; i < lifeExpectancyData.Length; i++)
            {
                if (lifeExpectancyData[i].communityName.Equals(value_selected))
                {

                    series.Points.Add(expectancy_1990[i]);
                    series.Points.Add(expectancy_2000[i]);
                    series.Points.Add(expectancy_2010[i]);
                    series.Points[0].Label = expectancy_1990[i].ToString();
                    series.Points[1].Label = expectancy_2000[i].ToString();
                    series.Points[2].Label = expectancy_2010[i].ToString();
                    series.Points[0].AxisLabel = "1990";
                    series.Points[1].AxisLabel = "2000";
                    series.Points[2].AxisLabel = "2010";
                }
            }
            series["PointWidth"] = (0.5).ToString();

            barChart.Series.Add(series);
            barChart.Invalidate();

            panel1.Controls.Add(barChart);
        }



        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

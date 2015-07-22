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
    public partial class unemployment_Vs_Community : Form
    {
        Chart barChart;
        public unemployment_Vs_Community()
        {
            this.WindowState = FormWindowState.Maximized;
            InitializeComponent();
            int newWidth = 1400;            
            panel1.MaximumSize = new Size(newWidth, panel1.Height);
            panel1.Size = new Size(newWidth, panel1.Height);
            InitializeChart();
        }

        public void InitializeChart()
        {

            this.components = new System.ComponentModel.Container();
            ChartArea chartArea1 = new ChartArea();
           // Legend legend1 = new Legend() { BackColor = Color.Green, ForeColor = Color.Black, Title = "Salary" };
            //Legend legend2 = new Legend() { BackColor = Color.Green, ForeColor = Color.Black, Title = "Salary" };
            barChart = new Chart();

            ((ISupportInitialize)(barChart)).BeginInit();

            SuspendLayout();
            //====Bar Chart
            chartArea1 = new ChartArea();
            chartArea1.Name = "BarChartArea";
            barChart.ChartAreas.Add(chartArea1);
            barChart.Dock = System.Windows.Forms.DockStyle.Fill;
           // legend2.Name = "Legend3";
            //barChart.Legends.Add(legend2);

            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            //this.ClientSize = new System.Drawing.Size(284, 262);           
            this.Load += new EventHandler(Form3_Load);
            ((ISupportInitialize)(this.barChart)).EndInit();
            this.ResumeLayout(false);

        }

        private void Form3_Load(object sender, EventArgs e)
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
            barChart.ChartAreas[0].AxisY.Title = "% Unemployment";
            barChart.ChartAreas[0].AxisX.Title = "Community Name";

            Series series = new Series
            {
                Name = "series2",
                IsVisibleInLegend = false,
                ChartType = SeriesChartType.Column
            };

            ParseData pd = new ParseData();
            string filePath = "..\\..\\..\\..\\Data\\";
            string SocioEconomicIndicatorsFilePath = filePath + "SocioEconomic_Indicators_Chicago.csv";
            Project.ParseData.SocioEconomicIndicators[] socioEconomicData = pd.parsesocioEconomicData(SocioEconomicIndicatorsFilePath);
            double[] unemployment = new double[78];
            for (int k = 0; k < socioEconomicData.Length; k++)
            {
                unemployment[k] = Convert.ToDouble(socioEconomicData[k].unemployment);
            }
            for (int i = 0; i < socioEconomicData.Length; i++)
            {
                series.Points.Add(unemployment[i]);
                series.Points[i].Label = unemployment[i].ToString();
                series.Points[i].AxisLabel = socioEconomicData[i].communityName;
                series.Points[i].Color = Color.Blue;
            }
            series["PointWidth"] = (0.7).ToString();
            barChart.Titles.Add(new Title("UnEmployment for different communities in Chicago" , Docking.Top, new Font("Verdana", 28f, FontStyle.Bold), Color.Black));
            barChart.Series.Add(series);
            barChart.Invalidate();

            panel1.Controls.Add(barChart);
        }



        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

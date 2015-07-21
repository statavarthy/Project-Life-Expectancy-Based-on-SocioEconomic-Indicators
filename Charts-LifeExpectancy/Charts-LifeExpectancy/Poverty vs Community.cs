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
    public partial class poverty_Vs_Community : Form
    {
        Chart barChart;
        public poverty_Vs_Community()
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
            //Legend legend1 = new Legend() { BackColor = Color.Green, ForeColor = Color.Black, Title = "Salary" };
            Legend legend2 = new Legend() {BackColor = Color.AntiqueWhite, Title = "Legend" };           
            barChart = new Chart();
           
            ((ISupportInitialize)(barChart)).BeginInit();

            SuspendLayout();
            //====Bar Chart
            chartArea1 = new ChartArea();
            chartArea1.Name = "BarChartArea";
            barChart.ChartAreas.Add(chartArea1);
            barChart.Dock = System.Windows.Forms.DockStyle.Fill;
            legend2.Name = "Legend";
            //barChart.Legends.Add(legend2);

            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            //this.ClientSize = new System.Drawing.Size(284, 262);           
            this.Load += new EventHandler(Form2_Load);            
            ((ISupportInitialize)(this.barChart)).EndInit();
            this.ResumeLayout(false);

        }


        private void Form2_Load(object sender, EventArgs e)
        {
            LoadBarChart();

        }

        void LoadBarChart()
        {
            barChart.Series.Clear();
            barChart.BackColor = Color.PowderBlue;
            barChart.Palette = ChartColorPalette.Grayscale;
            barChart.ChartAreas[0].BackColor = Color.Transparent;
            barChart.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            barChart.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
            barChart.ChartAreas[0].AxisX.LabelStyle.Angle = 45;
            barChart.ChartAreas[0].AxisX.LabelAutoFitMinFontSize = 5;
            barChart.ChartAreas[0].AxisX.IsStartedFromZero = true;
            barChart.ChartAreas[0].AxisX.LabelStyle.Interval = 1;
            barChart.ChartAreas[0].AxisX.Maximum = 80;
            barChart.ChartAreas[0].AxisY.Title = "% Household below Poverty";
            barChart.ChartAreas[0].AxisX.Title = "Community Name";

            Series series = new Series
            {
                Name = "Percent Households below Poverty",
                IsVisibleInLegend = true,
                ChartType = SeriesChartType.Column
            };

            ParseData pd = new ParseData();
            string filePath = "..\\..\\..\\..\\Data\\";
            string SocioEconomicIndicatorsFilePath = filePath + "SocioEconomic_Indicators_Chicago.csv";
            Project.ParseData.SocioEconomicIndicators[] socioEconomicData = pd.parsesocioEconomicData(SocioEconomicIndicatorsFilePath);
            double[] poverty = new double[78];
            for (int k = 0; k < socioEconomicData.Length; k++)
            {
                poverty[k] = Convert.ToDouble(socioEconomicData[k].poverty);
            }
            for (int i = 0; i < socioEconomicData.Length; i++)
            {
                series.Points.Add(poverty[i]);
                series.Points[i].Label = poverty[i].ToString();
                series.Points[i].AxisLabel = socioEconomicData[i].communityName;
                series.Points[i].Color = Color.Red;
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

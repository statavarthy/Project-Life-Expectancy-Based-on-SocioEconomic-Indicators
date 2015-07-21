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
        string value_selected = "";
        Chart pieChart;
        public PieChart_CommunityWise(string value)
        {
            this.WindowState = FormWindowState.Maximized;
            int newWidth = 1400;
            InitializeComponent();
            panel1.MaximumSize = new Size(newWidth, panel1.Height);
            panel1.Size = new Size(newWidth, panel1.Height);
            InitializeChart();
            value_selected = value;
            
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
            this.Load += new EventHandler(PieChart_CommunityWise_Load);
            ((ISupportInitialize)(this.pieChart)).EndInit();
            
            this.ResumeLayout(false);
        }

        public void PieChart_CommunityWise_Load(object sender, EventArgs e)
        {

            LoadPieChart();
            
        }

        void LoadPieChart()
        {
            pieChart.Series.Clear();
            pieChart.BackColor = Color.AntiqueWhite;
            pieChart.Palette = ChartColorPalette.BrightPastel;
            pieChart.ChartAreas[0].BackColor = Color.Transparent;
            
           
           
            
           

            Series series = new Series
            {
                Name = "series2",
                IsVisibleInLegend = false,
                ChartType = SeriesChartType.Pie
            };

            ParseData pd = new ParseData();
            string filePath = "..\\..\\..\\..\\Data\\";
            string SocioEconomicIndicatorsFilePath = filePath + "SocioEconomic_Indicators_Chicago.csv";
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
            for (int k = 0; k < socioEconomicData.Length; k++)
            {
                housingCrowded[k] = Convert.ToDouble(socioEconomicData[k].housingCrowded);
            }

            for (int i = 0; i < socioEconomicData.Length; i++)
            {
                if (socioEconomicData[i].communityName.Equals(value_selected))
                {

                    series.Points.Add(poverty[i]);
                    series.Points.Add(unemployment[i]);
                    series.Points.Add(noDiploma[i]);
                    series.Points.Add(under18over65[i]);
                    series.Points.Add(housingCrowded[i]);
                    series.Points[0].Label = poverty[i].ToString();
                    series.Points[1].Label = unemployment[i].ToString();
                    series.Points[2].Label = noDiploma[i].ToString();
                    series.Points[3].Label = under18over65[i].ToString();
                    series.Points[4].Label = housingCrowded[i].ToString();
                   
                }
            }
            series["PointWidth"] = (0.5).ToString();

            pieChart.Series.Add(series);
            pieChart.Invalidate();

            panel1.Controls.Add(pieChart);
        }



        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

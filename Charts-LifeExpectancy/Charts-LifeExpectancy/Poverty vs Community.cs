///////////////////////////////////////////////////////////////////////
// LifeExpectancy.cs - Program for Poverty Chart                     //
// Language:    C#, .Net Framework 4.0                               //
// Application: Open Source Computing, Project, Summer 2015          //
// Author:      SMRUTI TATAVARTHY, COMP 412, Loyola University       //
//              statavarthy@luc.edu                                  //
///////////////////////////////////////////////////////////////////////
/*Summary
 * 
 * The aim of this program is to display the graph for the poverties
 * of different communitities
 * This program contains logic for populating the poverties
 * and communitites and adding them to the bar chart.
 * This is a Windows forms application that will show on click of the 
 * Poverty statistics button
 */

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
        //Initialising bar chart
        Chart barChart;
        //Initialising chart area and window size
        public poverty_Vs_Community()
        {
            this.WindowState = FormWindowState.Maximized;
            InitializeComponent();
            int newWidth = 1400;            
            panel1.MaximumSize = new Size(newWidth, panel1.Height);
            panel1.Size = new Size(newWidth, panel1.Height);
            InitializeChart();            
        }
        //Initializing Chart area
        public void InitializeChart()
        {
            this.components = new System.ComponentModel.Container();
            ChartArea chartArea1 = new ChartArea();                        
            barChart = new Chart();           
            ((ISupportInitialize)(barChart)).BeginInit();
            SuspendLayout();
            //====Bar Chart
            chartArea1 = new ChartArea();
            chartArea1.Name = "BarChartArea";
            barChart.ChartAreas.Add(chartArea1);
            barChart.Dock = System.Windows.Forms.DockStyle.Fill;          
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;            
            ((ISupportInitialize)(this.barChart)).EndInit();
            this.ResumeLayout(false);
        }
        //Form2 definition to load bar chart
        private void Form2_Load(object sender, EventArgs e)
        {
            LoadBarChart();

        }
        //Setting properties of the bar chart
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
            //reading socio economic indicators and populating them in bar chart
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
            barChart.Titles.Add(new Title("Poverties in different communities in Chicago", Docking.Top, new Font("Verdana", 28f, FontStyle.Bold), Color.Black));
            barChart.Series.Add(series);
            barChart.Invalidate();
            panel1.Controls.Add(barChart);
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

    }
}

/////////////////////////////////////////////////////////////////////////
// LifeExpectancy.cs - Program for Pie Chart for differennt communities//
// Language:    C#, .Net Framework 4.0                                 //
// Application: Open Source Computing, Project, Summer 2015            //
// Author:      SMRUTI TATAVARTHY, COMP 412, Loyola University         //
//              statavarthy@luc.edu                                    //
/////////////////////////////////////////////////////////////////////////
/*Summary
 * 
 * The aim of this program is to display the pie chart showing the percentage
 * of socio economic indicators contribution for dfferent communities
 * This program contains logic for populating the socio economic indicators
 * and then adding them to the pie chart
 * This is a Windows forms application that will show on selection of the 
 * community from the drop down and then clicking the show statistics button
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
    public partial class PieChart_CommunityWise : Form
    {
        //Initialising pie chart
        string value_selected = "";
        Chart pieChart;

        //Initialising chart area and window size
        public PieChart_CommunityWise(string value)
        {
            this.WindowState = FormWindowState.Maximized;
            InitializeComponent();
            InitializeChart();
            value_selected = value;            
        }
        //Initializing Chart area
        public void InitializeChart()
        {
            this.components = new System.ComponentModel.Container();
            ChartArea chartArea1 = new ChartArea();
            Legend legend1 = new Legend() { BackColor = Color.FloralWhite, ForeColor = Color.Black, Title = "SocioEconomic Indicators" };
            pieChart = new Chart();
            ((ISupportInitialize)(pieChart)).BeginInit();
            SuspendLayout();
            //===Pie chart
            chartArea1.Name = "PieChartArea";
            pieChart.ChartAreas.Add(chartArea1);
            pieChart.Dock = System.Windows.Forms.DockStyle.Fill;           
            legend1.Name = "Legend1";
            pieChart.Legends.Add(legend1);
            pieChart.Location = new System.Drawing.Point(0, 500);            
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            //this.ClientSize = new System.Drawing.Size(284, 262);           
            this.Load += new EventHandler(PieChart_CommunityWise_Load);
            ((ISupportInitialize)(this.pieChart)).EndInit();            
            this.ResumeLayout(false);
        }
        //Form5 definition to load pie chart
        public void PieChart_CommunityWise_Load(object sender, EventArgs e)
        {
            LoadPieChart();            
        }
        //Setting properties of the pie chart
        void LoadPieChart()
        {
            pieChart.Series.Clear();
            pieChart.Palette = ChartColorPalette.Fire;
            pieChart.BackColor = Color.LightYellow;            
            pieChart.ChartAreas[0].BackColor = Color.Transparent;      
            Series series = new Series
            {
                Name = "Socio Economic Indicators",
                IsVisibleInLegend = true,
                ChartType = SeriesChartType.Pie
            };
            pieChart.Series.Add(series);
            //reading life expectancies and populating them in pie chart
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
                    series.Points[0].LegendText = "Poverty";
                    series.Points[1].LegendText = "Unemployment";
                    series.Points[2].LegendText = "Percent people with no Diploma";
                    series.Points[3].LegendText = "Percent people under the age 18 and over 65";
                    series.Points[4].LegendText = "Percent housing crowded";
                    series.Points[0].Label = poverty[i].ToString();
                    series.Points[1].Label = unemployment[i].ToString();
                    series.Points[2].Label = noDiploma[i].ToString();
                    series.Points[3].Label = under18over65[i].ToString();
                    series.Points[4].Label = housingCrowded[i].ToString();
                    //pieChart.Titles.Add("Socio Economic Indicators for " + value_selected);
                    pieChart.Titles.Add(new Title("Socio Economic Indicators for " + value_selected, Docking.Top, new Font("Verdana", 28f, FontStyle.Bold), Color.Black));
                }
            }
            series["PointWidth"] = (0.5).ToString();
            pieChart.Invalidate();
            panel1.Controls.Add(pieChart);
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

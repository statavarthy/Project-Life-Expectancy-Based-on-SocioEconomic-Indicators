///////////////////////////////////////////////////////////////////////
// LifeExpectancy.cs - Program for Life Expectancy Chart             //
// Language:    C#, .Net Framework 4.0                               //
// Application: Open Source Computing, Project, Summer 2015          //
// Author:      SMRUTI TATAVARTHY, COMP 412, Loyola University       //
//              statavarthy@luc.edu                                  //
///////////////////////////////////////////////////////////////////////
/*Summary
 * 
 * The aim of this program is to display the graph for the life expectancies
 * of different communitities
 * This program contains logic for populating the life expectancies
 * and communitites and adding them to the bar chart.
 * This is a Windows forms application that will show on click of the 
 * life expectancies statistics button
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
    public partial class LifeExpectancy_Vs_Community : Form
    {
        //Initialising bar chart
        Chart barChart;

        //Initialising chart area and window size
        public LifeExpectancy_Vs_Community()
        {
            this.WindowState = FormWindowState.Maximized;
            int newWidth = 1400;
            InitializeComponent();
            panel2.MaximumSize = new Size(newWidth, panel2.Height);
            panel2.Size = new Size(newWidth, panel2.Height);
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
            //this.ClientSize = new System.Drawing.Size(284, 262);           
            this.Load += new EventHandler(Form1_Load);
            ((ISupportInitialize)(this.barChart)).EndInit();
            this.ResumeLayout(false);
        }

         //Form1 definition to load bar chart
         public void Form1_Load(object sender, EventArgs e)
        {

            LoadBarChart();
        }
         //Setting properties of the bar chart
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
            barChart.ChartAreas[0].AxisY.Title = "% Life Expectancies for the year 2010";
            barChart.ChartAreas[0].AxisX.Title = "Community Name";
                       
            Series series = new Series
            {
                Name = "series2",
                IsVisibleInLegend = false,
                ChartType = SeriesChartType.Column
            };
            //reading socio economic indicators and populating them in bar chart
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
            barChart.Titles.Add(new Title("Life Expectancies of different communities in Chicago", Docking.Top, new Font("Verdana", 28f, FontStyle.Bold), Color.Black));
            barChart.Series.Add(series);                                                          
            barChart.Invalidate();            
            panel2.Controls.Add(barChart);
        }
        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

    }
}

///////////////////////////////////////////////////////////////////////
// LifeExpectancy.cs - Program for GUI                               //
// Language:    C#, .Net Framework 4.0                               //
// Application: Open Source Computing, Project, Summer 2015          //
// Author:      SMRUTI TATAVARTHY, COMP 412, Loyola University       //
//              statavarthy@luc.edu                                  //
///////////////////////////////////////////////////////////////////////
/*Summary
 * 
 * The aim of this program is to display the front end GUI
 * This program contains logic for execution of a small action
 * on click of buttons.
 * Code for different buttons, dropdowns have been included and
 * their corresponding actions on click are included in this program
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Forms;
using System.Windows.Controls;
using System.Windows.Forms.DataVisualization;
using System.Windows.Forms.DataVisualization.Charting;

namespace Project
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class SubWindow : Window
    {
        
        //subwindow that will be displayed after the start button click   
        public SubWindow()
        {

            this.WindowState = WindowState.Maximized;
            InitializeComponent();
            
        }

       //logic for displaying correlation alues on click of button
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Project.ParseData.correlation result;
            LifeExpectancy lf1 = new LifeExpectancy();
            result=lf1.processData();
            string data_lifePoverty = (result.correlLifePoverty).ToString();
            string data_lifeUnemp = (result.correlLifeUnemp).ToString();
            string data_lifeperCapita = (result.correlLifePerCapita).ToString();
            ///bool variables to verify if the checkboxes are checked
            bool isLifePovertyChked=LifePoverty.IsChecked.Value;            
            bool isLifeUnempChked=LifeUnemployment.IsChecked.Value;
            bool isLifeperCapita = LifeperCapita.IsChecked.Value;
            ResultBox.Text = "";
            //checking for the checkboxes and displaying if checked
            if(isLifePovertyChked)
                ResultBox.Text = "Correlation between Life Expectancy and Poverty is " + data_lifePoverty;           
            if (isLifeUnempChked)
                ResultBox.AppendText("\nCorrelation between Life Expectancy and Unemployment is " + data_lifeUnemp);
            if (isLifeperCapita)
                ResultBox.AppendText("\nCorrelation between Life Expectancy and per Capita Income is " + data_lifeperCapita);                         
        }
        //logic for the clear button to clear the results in the box
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ResultBox.Text = "";
            LifeUnemployment.IsChecked = false;
            LifeperCapita.IsChecked = false;
            LifePoverty.IsChecked = false;
        }        
        //Button to display graph of life expectancy
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            
            LifeExpectancy_Vs_Community F1 = new LifeExpectancy_Vs_Community();
            F1.Show();
        }
        //Button to display graph of poverty
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            poverty_Vs_Community F2 = new poverty_Vs_Community();
            F2.Show();
        }
        //Button to display graph of unemployment
        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            unemployment_Vs_Community F3 = new unemployment_Vs_Community();
            F3.Show();
        }
        //Button to display graph of per capita Incomes
        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            perCapita_Vs_Community F4 = new perCapita_Vs_Community();
            F4.Show();
        }
        // Drop Down to select different communities       
        private void ComboBox_Loaded(object sender, RoutedEventArgs e)
        {
            List<string> data = new List<string>();

            ParseData pd = new ParseData();
            string filePath = "..\\..\\..\\..\\Data\\";
            string lifeExpectancyFilePath = filePath + "LifeExpectancy_Chicago.csv";
            Project.ParseData.lifeExpectancy[] lifeExpectancyData = pd.parselifeExpectancyData(lifeExpectancyFilePath);
            data.Add("Community Name");
            //Added different coummunities to drop down
            for (int i = 0; i < lifeExpectancyData.Length; i++)
            {
                data.Add(lifeExpectancyData[i].communityName);
            }

            var comboBox = sender as System.Windows.Controls.ComboBox;
            comboBox.ItemsSource = data;
            comboBox.SelectedIndex = 0;
        }
        // Button to display line graph on selection in drop down
        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            // ... Get the ComboBox.
            var comboBox = sender as System.Windows.Controls.ComboBox;
            string value = comboBox1.SelectedItem.ToString();
            Form5 F5 = new Form5(value);
            F5.Show(); 
        }
        // Button to disply pie chart on selection in dropdown
        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            // ... Get the ComboBox.
            var comboBox = sender as System.Windows.Controls.ComboBox;
            string value = comboBox1.SelectedItem.ToString();
            PieChart_CommunityWise Pie = new PieChart_CommunityWise(value);
            Pie.Show();
        }     
    }
}

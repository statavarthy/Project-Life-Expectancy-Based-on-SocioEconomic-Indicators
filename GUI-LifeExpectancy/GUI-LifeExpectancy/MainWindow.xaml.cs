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
    public partial class MainWindow : Window
    {
        
           
        public MainWindow()
        {
            
            InitializeComponent();
            
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

       
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Project.ParseData.correlation result;
            LifeExpectancy lf1 = new LifeExpectancy();
            result=lf1.processData();
            string data_lifePoverty = (result.correlLifePoverty).ToString();
            string data_lifeUnemp = (result.correlLifeUnemp).ToString();
            string data_lifeperCapita = (result.correlLifePerCapita).ToString();
            bool isLifePovertyChked=LifePoverty.IsChecked.Value;
            
            bool isLifeUnempChked=LifeUnemployment.IsChecked.Value;
            bool isLifeperCapita = LifeperCapita.IsChecked.Value;
            ResultBox.Text = "";
            
            if(isLifePovertyChked)
                ResultBox.Text = "Correlation between Life Expectancy and Poverty is " + data_lifePoverty;           
            if (isLifeUnempChked)
                ResultBox.AppendText("\n Correlation between Life Expectancy and Unemployment is " + data_lifeUnemp);
            if (isLifeperCapita)
                ResultBox.AppendText("\n Correlation between Life Expectancy and per Capita Income is " + data_lifeperCapita);                         
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ResultBox.Text = "";



            LifeUnemployment.IsChecked = false;
            LifeperCapita.IsChecked = false;
            LifePoverty.IsChecked = false;

        }

        

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
           
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            
            LifeExpectancy_Vs_Community F1 = new LifeExpectancy_Vs_Community();
            F1.Show();

        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            poverty_Vs_Community F2 = new poverty_Vs_Community();
            F2.Show();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            unemployment_Vs_Community F3 = new unemployment_Vs_Community();
            F3.Show();
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            perCapita_Vs_Community F4 = new perCapita_Vs_Community();
            F4.Show();
        }
       
        

        private void ComboBox_Loaded(object sender, RoutedEventArgs e)
        {
            List<string> data = new List<string>();

            ParseData pd = new ParseData();
            string filePath = "..\\..\\..\\..\\Data\\";
            string lifeExpectancyFilePath = filePath + "LifeExpectancy_Chicago.csv";
            Project.ParseData.lifeExpectancy[] lifeExpectancyData = pd.parselifeExpectancyData(lifeExpectancyFilePath);
            data.Add("Community Name");
            for (int i = 0; i < lifeExpectancyData.Length; i++)
            {
                data.Add(lifeExpectancyData[i].communityName);
            }

            var comboBox = sender as System.Windows.Controls.ComboBox;
            comboBox.ItemsSource = data;
            comboBox.SelectedIndex = 0;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //// ... Get the ComboBox.
            //var comboBox = sender as System.Windows.Controls.ComboBox;

            //// ... Set SelectedItem as Window Title.
            //string value = comboBox.SelectedItem as string;
            //this.Title = "Selected: " + value;
            //Form5 F5 = new Form5(value);
            //F5.Show();            

        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            // ... Get the ComboBox.
            var comboBox = sender as System.Windows.Controls.ComboBox;

            string value = comboBox1.SelectedItem.ToString();

            // ... Set SelectedItem as Window Title.
           // string value = comboBox.SelectedItem as string;
            //this.Title = "Selected: " + value;
            Form5 F5 = new Form5(value);
            F5.Show(); 

        }
     
    }


}

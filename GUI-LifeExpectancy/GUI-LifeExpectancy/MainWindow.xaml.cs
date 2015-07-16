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

        private void life_poverty(object sender, RoutedEventArgs e)
        {
            Handle1(sender as CheckBox);
        }
        private void life_unemployment(object sender, RoutedEventArgs e)
        {
            Handle2(sender as CheckBox);
        }
        private void life_perCapitaIncome(object sender, RoutedEventArgs e)
        {
            Handle3(sender as CheckBox);
        }
        void Handle1(CheckBox checkbox)
        {
            bool flag = checkbox.IsChecked.Value;
            if (flag)
            {
                
            }
        }
        void Handle2(CheckBox checkbox)
        {
           
        }
        void Handle3(CheckBox checkbox)
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
            ResultBox.Text = "Correlation between Life Expectancy and Poverty is " + data_lifePoverty;
            ResultBox.AppendText("\n Correlation between Life Expectancy and Unemployment is " + data_lifeUnemp);
            ResultBox.AppendText("\n Correlation between Life Expectancy and per Capita Income is " + data_lifeperCapita);


            
            

        }


       
    }
}

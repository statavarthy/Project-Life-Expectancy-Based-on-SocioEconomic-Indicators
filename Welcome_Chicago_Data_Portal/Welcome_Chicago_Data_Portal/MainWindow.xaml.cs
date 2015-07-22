﻿using System;
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
            this.WindowState = WindowState.Maximized;
            InitializeComponent();
            ImageBrush myBrush = new ImageBrush();
            myBrush.ImageSource =
                new BitmapImage(new Uri("../../Images/background2.jpg", UriKind.Relative));
            this.Background = myBrush;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SubWindow win = new SubWindow();
            win.Show();
            this.Close();
            
           
        }

       

        
    }
}

///////////////////////////////////////////////////////////////////////
// LifeExpectancy.cs - Program for Welcome Screen                    //
// Language:    C#, .Net Framework 4.0                               //
// Application: Open Source Computing, Project, Summer 2015          //
// Author:      SMRUTI TATAVARTHY, COMP 412, Loyola University       //
//              statavarthy@luc.edu                                  //
///////////////////////////////////////////////////////////////////////
/*Summary
 * The aim of this program is to display the Welcome Screen
 * This program contains logic for starting the code and directing it towards
 * the rest of the GUI
 * It contains logic for the start button which calls the sub window containing the
 * rest of the GUI.
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

namespace Project
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
       //Main window with background image initialization
        public MainWindow()
        {
            this.WindowState = WindowState.Maximized;
            InitializeComponent();
            ImageBrush myBrush = new ImageBrush();
            myBrush.ImageSource =
                new BitmapImage(new Uri("../../Images/background2.jpg", UriKind.Relative));
            this.Background = myBrush;
        }
        //Click of the start button that calls the sub window
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SubWindow win = new SubWindow();
            win.Show();
            this.Close();                       
        }              
    }
}

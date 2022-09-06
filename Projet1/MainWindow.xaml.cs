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

namespace Projet1
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

        private void openPage1(object sender, RoutedEventArgs e)
        {
            page1 p1 = new page1();
            p1.Show();
        }
        private void openPage2(object sender, RoutedEventArgs e)
        {
            page2 p2 = new page2();
            p2.Show();
        }
        private void openPage3(object sender, RoutedEventArgs e)
        {
            page3 p3 = new page3();
            p3.Show();
        }
    }
}

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
using System.Diagnostics;

namespace Livrable2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Process[] process = Process.GetProcessesByName("Livrable2");

            if (process.Length != 1)
            {
                MessageBox.Show("L'application est déjà en route");
                Environment.Exit(0);
            }

        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Window1 gg = new Window1();
            gg.Show();
            this.Close();

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Window2 g = new Window2();
            g.Show();
            this.Close();
        }
    }
}
